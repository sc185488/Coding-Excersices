using Retalix.Contracts.Generated.Common;
using Retalix.Jumbo.BusinessServices.Common;
using Retalix.Jumbo.Contracts.Generated.ServerConfiguration;
using Retalix.Jumbo.Model.ServerConfiguration;
using Retalix.Jumbo.ModuleInstaller.Model.RegistrationAttributes;
using Retalix.StoreServices.Model.Customer.Legacy.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.BusinessServices.ServerConfiguration
{
    [RegisterAddition("ServerConfigurationMaintenanceService")]
    public class ServerConfigurationMaintenanceService : BusinessService<ServerConfigurationMaintenanceRequestType, ServerConfigurationMaintenanceResponseType>
    {
        private readonly IServerConfigurationDao _serverConfigurationDao;
        private readonly IServerConfigurationFactory _serverConfigurationFactory;
        public ServerConfigurationMaintenanceService(IServerConfigurationDao serverConfigurationDao , IServerConfigurationFactory serverConfigurationFactory)
        {
            _serverConfigurationDao = serverConfigurationDao;
            _serverConfigurationFactory = serverConfigurationFactory;
        }

        public override ServerConfigurationMaintenanceResponseType ExecuteService(ServerConfigurationMaintenanceRequestType request)
        {
            HandleServerConfigurationMaintenanceAction(request);
            return new ServerConfigurationMaintenanceResponseType();
        }

        private void HandleServerConfigurationMaintenanceAction(ServerConfigurationMaintenanceRequestType request)
        {
            switch (request.Action)
            {
                case ActionTypeCodes.Add:
                case ActionTypeCodes.Update:
                case ActionTypeCodes.AddUpdate:
                case ActionTypeCodes.AddOrUpdate:
                    ExecuteAddOrUpdateAction(request);
                    break;
                case ActionTypeCodes.Delete:
                    ExecuteDeleteAction(request);
                    break;
            }
        }

        private void ExecuteAddOrUpdateAction(ServerConfigurationMaintenanceRequestType request)
        {
            foreach (var configuration in request.ServerConfiguration)
            {
                ValidateRequest(configuration);
                var configurationModel = ConvertContractToModel(configuration);
                _serverConfigurationDao.SaveOrUpdate(configurationModel);
            }
        }

        private void ValidateRequest(ServerConfigurationType serverConfigurationType)
        {
            if (serverConfigurationType == null) throw new ArgumentNullException("serverConfigurationType");

            if (string.IsNullOrEmpty(serverConfigurationType.ServerConfigurationId))
                throw new MissingMandatoryFieldException(PropertyResolver.GetName<ServerConfigurationType>(u => u.ServerConfigurationId));

            if (string.IsNullOrEmpty(serverConfigurationType.ServerConfigurationName))
                throw new MissingMandatoryFieldException(PropertyResolver.GetName<ServerConfigurationType>(u => u.ServerConfigurationName));

            if (string.IsNullOrEmpty(serverConfigurationType.EntityParameter))
                throw new MissingMandatoryFieldException(PropertyResolver.GetName<ServerConfigurationType>(u => u.EntityParameter));
        }

        private IServerConfiguration ConvertContractToModel(ServerConfigurationType serverConfigurationType)
        {
            return _serverConfigurationFactory.Create(serverConfigurationType.ServerConfigurationId ,
                serverConfigurationType.ServerConfigurationName , serverConfigurationType.EntityType ,
                serverConfigurationType.EntityParameter , serverConfigurationType.Value);

        }

        private void ExecuteDeleteAction(ServerConfigurationMaintenanceRequestType request)
        {
            foreach (var configuration in request.ServerConfiguration)
            {
                ValidateRequest(configuration);
                var configurationModel = ConvertContractToModel(configuration);
                _serverConfigurationDao.Delete(configurationModel);
            }
        }
    }
}
