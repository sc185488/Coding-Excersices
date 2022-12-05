using Retalix.Jumbo.BusinessServices.Common;
using Retalix.Jumbo.Contracts.Generated.ServerConfiguration;
using Retalix.Jumbo.Model.ServerConfiguration;
using Retalix.Jumbo.ModuleInstaller.Model.RegistrationAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.BusinessServices.ServerConfiguration
{
    [RegisterAddition("ServerConfigurationLookupService")]
    public class ServerConfigurationLookupService : BusinessService<ServerConfigurationLookupRequestType , ServerConfigurationLookupResponseType>
    {
        private readonly IServerConfigurationProvider _serverConfigurationProvider;
        public ServerConfigurationLookupService(IServerConfigurationProvider serverConfigurationProvider)
        {
            _serverConfigurationProvider = serverConfigurationProvider;
        }
        public override ServerConfigurationLookupResponseType ExecuteService(ServerConfigurationLookupRequestType request)
        {
            var response = new ServerConfigurationLookupResponseType();

            var criteria = CreateCriteria(request);
            IEnumerable<IServerConfiguration> touchpointConfigurations;
            if (criteria != null && string.IsNullOrEmpty(criteria.ServerConfigurationName) && criteria.EntityType != null && criteria.EntityType == ServerConfigurationConstants.EntityType.TouchPointGroup)
            {
                var entityParamter = criteria.EntityParameter;
                criteria.ServerConfigurationName = null;
                criteria.EntityType = null;
                criteria.EntityParameter = null;

                var touchpointConfigurationsForAll = _serverConfigurationProvider.GetServerConfigurations(criteria);
                touchpointConfigurations = touchpointConfigurationsForAll.Where(tpc => FilterTouchPointGroupId(tpc, entityParamter));
            }
            else
            {
                touchpointConfigurations = _serverConfigurationProvider.GetServerConfigurations(criteria);
            }

            if (touchpointConfigurations != null)
            {
                var contractTouchPointConfigurations =
                    touchpointConfigurations.ToList().ConvertAll(ConvertModelToContract).ToArray();
                response.ServerConfigurations = contractTouchPointConfigurations;
            }
            return response;
        }

        #region Private Methods
        private ServerConfigurationCriteria CreateCriteria(ServerConfigurationLookupRequestType request)
        {
            ServerConfigurationCriteria criteria = null;

            if (request.SearchCriteria != null)
            {
                criteria = CreateCriteriaFromRequest(request);
            }

            return criteria;
        }
        private ServerConfigurationCriteria CreateCriteriaFromRequest(
            ServerConfigurationLookupRequestType request)
        {
            return new ServerConfigurationCriteria
            {
                ServerConfigurationId = request.SearchCriteria.ServerConfigurationId ,
            };
        }

        private bool FilterTouchPointGroupId(IServerConfiguration serverConfiguration, string entityParameterServerId)
        {
            if (serverConfiguration.EntityType != ServerConfigurationConstants.EntityType.TouchPointGroup) return true;

            return serverConfiguration.EntityParameter == entityParameterServerId;
        }

        private static ServerConfigurationType ConvertModelToContract(
            IServerConfiguration serverConfiguration)
        {
            return new ServerConfigurationType
            {
                ServerConfigurationId = serverConfiguration.ServerConfigurationId ,
                EntityParameter = serverConfiguration.EntityParameter,
                ServerConfigurationName = serverConfiguration.ServerConfigurationName ,
                Value = serverConfiguration.Value,
                EntityType = serverConfiguration.EntityType,
            };
        }
        #endregion
    }
}
