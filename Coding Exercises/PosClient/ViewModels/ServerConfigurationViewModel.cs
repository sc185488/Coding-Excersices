using NCR.EG.Client.POS.BusinessObjects.CommandHandlers;
using Retalix.Client.POS.Presentation.ViewModels.ViewModels;
using Retalix.Client.Presentation.Core.Command;
using Retalix.Jumbo.Client.POS.API.DataModels;
using Retalix.Jumbo.Client.POS.API.Model;
using Retalix.Jumbo.Contracts.Generated.ServerConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Retalix.Jumbo.Client.POS.Presentation.ViewModels.ViewModels
{
    public class ServerConfigurationViewModel : PosViewModelBase
    {
        private IServerConfigurationDataModel _serverConfigurationDataModel;
        public ICommand BackCommand { get; private set; }

        private List<ServerConfigurationType> _serverConfigurationElement;
        public List<ServerConfigurationType> ServerConfigurationElement
        {
            get { return _serverConfigurationElement; }
            set { _serverConfigurationElement = value; }
        }

        public ServerConfigurationViewModel()
        {
            Init();
            InitCommands();
        }

        private void Init()
        {
            _serverConfigurationDataModel = _dataModelProvider.GetDataModel<IServerConfigurationDataModel>();
            var serverConfigurationList = new List<ServerConfigurationType>();
            var serverConfigurationObj = _serverConfigurationDataModel.serverConfigurationLookupResponseType.ServerConfigurations;
            for(int i = 0; i < serverConfigurationObj.Length; i++)
            {
                serverConfigurationList.Add(serverConfigurationObj[i]);
            }
            _serverConfigurationElement = serverConfigurationList;
        }


        private void InitCommands()
        {
            BackCommand = new CommandAction<object>(ExecuteBackCommand, x => true);
        }

        protected virtual void ExecuteBackCommand(object obj)
        {

            ExecuteBackCommandHandler();
        }

        protected virtual void ExecuteBackCommandHandler()
        {
            var command = CommandHandlerFactory.Create<IServerConfigurationBackCommandHandler>();
            ExecuteCommandHandlerAndStartFlow(command);
        }
    }
}
