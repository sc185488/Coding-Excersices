using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Model.ServerConfiguration
{
    public interface IServerConfigurationProvider
    {
        IEnumerable<IServerConfiguration> GetServerConfigurations(ServerConfigurationCriteria serverConfigurationCriteria);
        string GetServerConfiguration(string ServerConfigurationId, string ServerConfigurationName, string entityType, string entityParameter, string value);
    }
}
