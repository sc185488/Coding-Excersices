using Retalix.Client.POS.BusinessObjects.CommandHandlers;
using Retalix.Jumbo.Client.POS.API.Model;
using Retalix.Jumbo.Client.POS.API.Model.CommanHandler;
using Retalix.Jumbo.Client.POS.API.Model.ServiceAgents;
using Retalix.Jumbo.Contracts.Generated.ServerConfiguration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.CommandHandlers
{
    [Export(typeof(IServerConfigurationLookupCommandHandler))]

    public class ServerConfigurationLookupCommandHandler : PosCommandHandlerBase, IServerConfigurationLookupCommandHandler
    {
        private string _serverConfigurationMakerName;
        private const string ServerConfigurationLookupOutcome = "ServerConfigurationLookupOutcome";

        public void Init(string serverConfigurationName)
        {
            _serverConfigurationMakerName = serverConfigurationName;
        }

        protected override string ExecuteLogic()
        {
            var serverConfigurationLookupResponse = ExecuteServerConfigurationLookupServiceAgent();
            SetupServerConfigurationDataModel(serverConfigurationLookupResponse);
            return ServerConfigurationLookupOutcome;
        }

        private void SetupServerConfigurationDataModel(ServerConfigurationLookupResponseType serverConfigurationLookupResponse)
        {
            var serverConfigurationDataModel = GetDataModel<IServerConfigurationDataModel>();
            serverConfigurationDataModel.serverConfigurationLookupResponseType = serverConfigurationLookupResponse;
        }

        private ServerConfigurationLookupResponseType ExecuteServerConfigurationLookupServiceAgent()
        {
            var serverConfigurationLookupServiceAgent = GetServiceAgent<IServerConfigurationLookupServiceAgent>();
            return serverConfigurationLookupServiceAgent.Execute(_serverConfigurationMakerName);
        }
    }
}
