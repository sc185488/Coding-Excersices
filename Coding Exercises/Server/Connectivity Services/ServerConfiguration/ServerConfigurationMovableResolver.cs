using Retalix.Jumbo.Model.DMS;
using Retalix.Jumbo.Model.Infrastructure.DataMovement;
using Retalix.Jumbo.Model.ServerConfiguration;
using Retalix.Jumbo.ModuleInstaller.Model.RegistrationAttributes;
using Retalix.StoreServices.Infrastructure;
using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using Retalix.StoreServices.Model.Infrastructure.DataMovement.Versioning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.ConnectivityServices.ServerConfiguration
{
    [RegisterAddition(Id = "ServerConfiguration")]
    public class ServerConfigurationMovableResolver : ICompatibilityMovableServicesResolver
    {
        private readonly IServerConfigurationDao _movableDao;
        private readonly IEntityToDtoMapper _entityToDtoMapper;
        private readonly IResolver _resolver;

        public ServerConfigurationMovableResolver(IServerConfigurationDao movableDao, IResolver resolver)
        {
            _movableDao = movableDao;
            _resolver = resolver;
            _entityToDtoMapper = new ServerConfigurationEntityToDtoMapper();
        }

        public string ComponentName
        {
            get
            {
                return _resolver.CanResolve<IMovableComponentProvider>() ? _resolver.Resolve<IMovableComponentProvider>().GetComponent() : "JumboRetail";
            }
        }

        public IEntityToDtoMapper EntityToDtoMapper
        {
            get { return _entityToDtoMapper; }
        }

        public IMovableFormatter Formatter
        {
            get { return new MovableFormatterEmpty(); }
        }

        public IMovableDao MovableDao
        {
            get { return _movableDao as IMovableDao; }
        }
    }
}
