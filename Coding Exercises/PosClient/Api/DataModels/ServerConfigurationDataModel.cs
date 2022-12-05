using Retalix.Client.Common.DataModels;
using Retalix.Jumbo.Client.POS.API.Model;
using Retalix.Jumbo.Contracts.Generated.ServerConfiguration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.DataModels
{
    [Export(typeof(IDataModel))]
    public class ServerConfigurationDataModel : IServerConfigurationDataModel
    {
        public ServerConfigurationLookupResponseType serverConfigurationLookupResponseType { get; set; }

        public void Clear()
        {
            serverConfigurationLookupResponseType = null;
        }
    }
}
