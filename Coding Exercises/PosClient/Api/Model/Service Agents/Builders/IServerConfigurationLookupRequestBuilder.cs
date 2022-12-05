using Retalix.Jumbo.Contracts.Generated.ServerConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Builders
{
    public interface IServerConfigurationLookupRequestBuilder
    {
        ServerConfigurationLookupRequestType BuildLookupRequest(string serverConfigurationId);
    }
}
