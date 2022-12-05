using Retalix.Client.POS.BusinessObjects.ServiceAgents.Validations;
using Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Validators;
using Retalix.Jumbo.Contracts.Generated.ServerConfiguration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.ServiceAgents.Validators
{
    [Export(typeof(IServerConfigurationLookupValidator))]
    public class ServerConfigurationLookupValidator : RetalixValidatorBase , IServerConfigurationLookupValidator
    {
        public void Validate(ServerConfigurationLookupRequestType request , ServerConfigurationLookupResponseType response)
        {
            ValidateResponseError(response.Header);
        }
    }
}
