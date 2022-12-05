using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Model.ServerConfiguration
{
    public class ServerConfigurationCriteria
    {
        public string ServerConfigurationId { get; set; }
        public string ServerConfigurationName { get; set; }
        public string EntityType { get; set; }
        public string EntityParameter { get; set; }
        public string Value { get; set; }
    }
}
