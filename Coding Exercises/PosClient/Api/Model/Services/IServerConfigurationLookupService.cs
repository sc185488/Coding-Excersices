using Retalix.Jumbo.Contracts.Generated.ServerConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.Model.Services
{
    public interface IServerConfigurationLookupService
    {
        ServerConfigurationLookupResponseType Execute(ServerConfigurationLookupRequestType request);
    }
}
