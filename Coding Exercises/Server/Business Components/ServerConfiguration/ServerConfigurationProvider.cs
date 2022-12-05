using Common.Logging;
using Retalix.Jumbo.Model.ServerConfiguration;
using Retalix.Jumbo.ModuleInstaller.Model.RegistrationAttributes;
using Retalix.StoreServices.Model.Infrastructure.StoreApplication;
using Retalix.StoreServices.Model.Organization.BusinessUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.BusinessComponents.ServerConfiguration
{
    [RegisterAddition("ServerConfigurationProvider")]
    public class ServerConfigurationProvider : IServerConfigurationProvider
    {
        private readonly IServerConfigurationDao _serverConfigurationDao;
        private readonly IStoreNetRequest _storeNetRequest;
        private readonly IBusinessUnitDao _businessUnitDao;
        private readonly ILog _logger;

        public ServerConfigurationProvider(
            IServerConfigurationDao serverConfigurationDao , IStoreNetRequest storeNetRequest,
            IBusinessUnitDao businessUnitDao)
        {
            _serverConfigurationDao = serverConfigurationDao;
            _logger = LogManager.GetCurrentClassLogger();
            _businessUnitDao = businessUnitDao;
            _storeNetRequest = storeNetRequest;
        }

        public IEnumerable<IServerConfiguration> GetServerConfigurations(ServerConfigurationCriteria criteria)
        {
            if (criteria.ServerConfigurationName == null && criteria.EntityParameter == null && criteria.EntityType == null)
            {
                var businessUnit = GetBusinessUnit(criteria.ServerConfigurationId);
                return GetAllServerConfigurationsIncludingFromParents(criteria , businessUnit);
            }
            else
            {
                var businessUnit = GetBusinessUnit(criteria.ServerConfigurationId);
                return GetServerConfigurationsFromParent(criteria , businessUnit);
            }
        }

        private IBusinessUnit GetBusinessUnit(string serverConfigurationId)
        {
            var businessUnit = _storeNetRequest.BusinessUnit; // for POS request
            return businessUnit ?? _businessUnitDao.Get(serverConfigurationId); // for Office request 
        }

        private IEnumerable<IServerConfiguration> GetServerConfigurationsFromParent(
            ServerConfigurationCriteria criteria, IBusinessUnit businessUnit)
        {
            IEnumerable<IServerConfiguration> serverConfigurations = new List<IServerConfiguration> { };

            while (businessUnit != null)
            {
                criteria.ServerConfigurationId = businessUnit.Id;
                serverConfigurations = _serverConfigurationDao.GetByCriteria(criteria);

                if (serverConfigurations.Any())
                    return serverConfigurations;

                businessUnit = businessUnit.ParentUnit;
            }

            _logger.Debug(string.Format("Server Configuration was not found for criteria - ServerConfigurationId: {0}, EntityType: {1}, EntityParameter:{2}; null returned", criteria.ServerConfigurationId, criteria.EntityType, criteria.EntityParameter));
            return serverConfigurations;
        }

        private IEnumerable<IServerConfiguration> GetAllServerConfigurationsIncludingFromParents(ServerConfigurationCriteria criteria, IBusinessUnit businessUnit)
        {
            ServerConfigurationCriteria ServerConfigurationCriteria = new ServerConfigurationCriteria();

            List<IServerConfiguration> allTouchpointConfigurations = _serverConfigurationDao.GetAllBusinessServiceForAllBusinessUnitId(ServerConfigurationCriteria);

            List<IServerConfiguration> serverConfigurations = new List<IServerConfiguration>();

            while (businessUnit != null)
            {
                List<IServerConfiguration> businessUnitList = allTouchpointConfigurations.Where(o => o.ServerConfigurationId == businessUnit.Id).ToList();

                businessUnitList.ForEach(configuration => AddServerConfigurationToFinalList(serverConfigurations , configuration));

                businessUnit = businessUnit.ParentUnit;
            }

            return serverConfigurations;
        }

        private static void AddServerConfigurationToFinalList(List<IServerConfiguration> touchpointConfigurations,
            IServerConfiguration serverConfiguration)
        {
            if (touchpointConfigurations.Any(o => o.ServerConfigurationName == serverConfiguration.ServerConfigurationName
                && o.EntityParameter == serverConfiguration.EntityParameter && o.EntityType == serverConfiguration.EntityType)) return;

            touchpointConfigurations.Add(serverConfiguration);
        }

        public string GetServerConfiguration(string ServerConfigurationId, string ServerConfigurationName, string entityType, string entityParameter , string value)
        {
            ServerConfigurationCriteria criteria = BuildCriteria(ServerConfigurationId , ServerConfigurationName.ToString(), entityType.ToString(), entityParameter.ToString() , value);
            return GetServerConfigurationValue(criteria);
        }

        private string GetServerConfigurationValue(ServerConfigurationCriteria criteria)
        {
            var touchpointConfigurations = GetServerConfigurations(criteria);
            if (touchpointConfigurations == null || !touchpointConfigurations.Any())
            {
                //throw new TouchpointConfigurationNotFoundException(criteria);//"To write Exception related Code"; 
            }

            return touchpointConfigurations.First().Value;
        }

        private ServerConfigurationCriteria BuildCriteria(string ServerConfigurationId, string ServerConfigurationName, string entityType, string entityParameter, string value)
        {
            ServerConfigurationCriteria criteria = new ServerConfigurationCriteria();
            criteria.ServerConfigurationId = ServerConfigurationId;
            criteria.ServerConfigurationName = ServerConfigurationName;
            criteria.EntityParameter = entityParameter;
            criteria.EntityType = entityType;
            criteria.Value = value;
            return criteria;
        }
    }
}
