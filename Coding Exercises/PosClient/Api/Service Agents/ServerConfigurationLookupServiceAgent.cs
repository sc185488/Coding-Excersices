using Retalix.Client.Common.ServiceAgents;
using Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Builders;
using Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Validators;
using Retalix.Jumbo.Client.POS.API.Model.Services;
using Retalix.Jumbo.Contracts.Generated.ServerConfiguration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.Model.ServiceAgents
{
    [Export(typeof(IServiceAgent))]
    public class ServerConfigurationLookupServiceAgent : IServerConfigurationLookupServiceAgent
    {
        [Import] private IServerConfigurationLookupService _serverConfigurationLookupService;

        [Import] private IServerConfigurationLookupValidator _serverConfigurationLookupValidator;

        [Import] private IServerConfigurationLookupRequestBuilder _serverConfigurationLookupRequestBuilder;


        public ServerConfigurationLookupResponseType Execute(string serverConfigurationId)
        {
            var serverConfigurationLookupRequest = _serverConfigurationLookupRequestBuilder.BuildLookupRequest(serverConfigurationId);
            var serverConfigurationLookupResponse = _serverConfigurationLookupService.Execute(serverConfigurationLookupRequest);
            _serverConfigurationLookupValidator.Validate(serverConfigurationLookupRequest, serverConfigurationLookupResponse);
            // ClientLog.ClientBusinessFlows.Debug("Test Log {0}", new BusinessException());
            return serverConfigurationLookupResponse;
        }
    }
}
