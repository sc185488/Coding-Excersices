using Retalix.Client.Net;
using Retalix.Jumbo.Contracts.Generated.ServerConfiguration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.Model.Services
{
    [Export(typeof(IServerConfigurationLookupService))]
    public class ServerConfigurationLookupService : ServiceBase, IServerConfigurationLookupService
    {
        private const string ServiceName = "ServerConfigurationLookup";
        public ServerConfigurationLookupResponseType Execute(ServerConfigurationLookupRequestType request)
        {
            return Execute<ServerConfigurationLookupRequestType, ServerConfigurationLookupResponseType>(request, ServiceName);
        }
    }
}
