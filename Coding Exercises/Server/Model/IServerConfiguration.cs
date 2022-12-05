using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Model.ServerConfiguration
{
    public interface IServerConfiguration : IMovable , INamedObject
    {
        string ServerConfigurationId { get; set; }
        string ServerConfigurationName { get; set; }
        string EntityType { get; set; }
        string EntityParameter { get; set; }
        string Value { get; set; }
    }
}
