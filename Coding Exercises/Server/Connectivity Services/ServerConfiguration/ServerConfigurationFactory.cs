using Retalix.Jumbo.Model.ServerConfiguration;
using Retalix.Jumbo.ModuleInstaller.Model.RegistrationAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.ConnectivityServices.ServerConfiguration
{
    [RegisterAddition]
    public class ServerConfigurationFactory : IServerConfigurationFactory
    {
        public IServerConfiguration Create(string ServerConfigurationId, string ServerConfigurationName, string EntityType, string EntityParameter, string Value)
        {
            return new ServerConfiguration
            {
                ServerConfigurationId = ServerConfigurationId,
                ServerConfigurationName = ServerConfigurationName,
                EntityType = EntityType,
                EntityParameter = EntityParameter,
                Value = Value
            };
        }
    }
}
