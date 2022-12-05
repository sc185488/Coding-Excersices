using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Model.ServerConfiguration
{
    public interface IServerConfigurationDao : IMovableDao
    {
        void SaveOrUpdate(IServerConfiguration serverConfiguration);
        void Delete(IServerConfiguration serverConfiguration);
        IEnumerable<IServerConfiguration> GetByCriteria(ServerConfigurationCriteria serverConfiguration);
        List<IServerConfiguration> GetAllBusinessServiceForAllBusinessUnitId(ServerConfigurationCriteria searchingCriteria);
    }
}
