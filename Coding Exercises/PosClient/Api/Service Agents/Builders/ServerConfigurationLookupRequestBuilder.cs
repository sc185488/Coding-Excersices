using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Retalix.Client.CommonServices.Utils;
using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
using Retalix.Contracts.Generated.Common;
using Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Builders;
using Retalix.Jumbo.Contracts.Generated.ServerConfiguration;

namespace Retalix.Jumbo.Client.POS.API.ServiceAgents.Builders
{
    [Export(typeof(IServerConfigurationLookupRequestBuilder))]
    public class ServerConfigurationLookupRequestBuilder : IServerConfigurationLookupRequestBuilder
    {
        public ServerConfigurationLookupRequestType BuildLookupRequest(string ServerConfigurationId)
        {
            var searchCriteria = new SearchCriteriaType { ServerConfigurationId = ServerConfigurationId };
            var carLookupRequest = new ServerConfigurationLookupRequestType()
            {
                Header = new RetalixCommonHeaderType()
                {
                    MessageId = new RequestIDCommonData()
                    {
                        Value = MessageIdGenerator.GetId().ToString()
                    }
                },
                SearchCriteria = searchCriteria
            };
            return carLookupRequest;
        }
    }
}
