using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Model.ServerConfiguration
{
    public interface IServerConfigurationFactory
    {
        IServerConfiguration Create(string ServerConfigurationId , 
                                    string ServerConfigurationName , 
                                    string EntityType ,
                                    string EntityParameter , 
                                    string Value
                                    );
    }
}
