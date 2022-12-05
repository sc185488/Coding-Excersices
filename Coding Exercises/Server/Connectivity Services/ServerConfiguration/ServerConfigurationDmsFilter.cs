using Retalix.Jumbo.Model.ServerConfiguration;
using Retalix.Jumbo.ModuleInstaller.Model.RegistrationAttributes;
using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using Retalix.StoreServices.Model.Infrastructure.DataMovement.Filter;
using Retalix.StoreServices.Model.Organization.BusinessUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.ConnectivityServices.ServerConfiguration
{
    [RegisterAddition("ServerConfigurationDmsFilter", ImplInterfaceType = typeof(IDmsFilter))]
    public class ServerConfigurationDmsFilter : IDmsFilter
    {
        private readonly IBusinessUnitDao _businessUnitDao;

        public ServerConfigurationDmsFilter(IBusinessUnitDao businessUnitDao)
        {
            _businessUnitDao = businessUnitDao;
        }

        public IEnumerable<IBusinessUnit> GetRelevantBusinessUnits(IMovable entity)
        {
            var serverConfiguration = entity as IServerConfiguration;
            if (serverConfiguration != null)
            {
                var businessUnit = _businessUnitDao.Get(serverConfiguration.ServerConfigurationId);
                if (businessUnit != null)
                {
                    return new List<IBusinessUnit> { businessUnit };
                }
            }

            return Enumerable.Empty<IBusinessUnit>();
        }

        public bool IsRelevant(IMovable entity)
        {
            return entity is IServerConfiguration;
        }
    }
}
