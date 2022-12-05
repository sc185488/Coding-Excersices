using NCR.EG.Client.POS.BusinessObjects.CommandHandlers;
using Retalix.Client.POS.Presentation.ViewModels.ViewModels;
using Retalix.Client.Presentation.Core.Command;
using Retalix.Jumbo.Client.POS.API.Model.CommanHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Retalix.Jumbo.Client.POS.Presentation.ViewModels.ViewModels
{
    public class ServerConfigurationInputViewModel : PosViewModelBase
    {
        public ICommand GetCommand { get; private set; }
        public ICommand BackCommand { get; private set; }


        private string _serverConfigurationName;
        public string ServerConfigurationName
        {
            get { return _serverConfigurationName; }
            set
            {
                _serverConfigurationName = value;
                NotifyPropertyChanged("ServerConfigurationName");
            }
        }

        public ServerConfigurationInputViewModel()
        {
            Init();
        }
        private void Init()
        {
            InitCommands();
        }

        private void InitCommands()
        {
            GetCommand = new CommandAction<object>(ExecuteGetCommand, CanExecuteGetCommand);
            BackCommand = new CommandAction<object>(ExecuteBackCommand, x => true);


        }

        private bool CanExecuteGetCommand(object obj)
        {
            return !string.IsNullOrWhiteSpace(ServerConfigurationName);
        }

        protected virtual void ExecuteGetCommand(object obj)
        {

            ExecuteCarLookupCommandHandler(_serverConfigurationName);
        }

        protected virtual void ExecuteBackCommand(object obj)
        {

            ExecuteBackCommandHandler();
        }

        protected virtual void ExecuteCarLookupCommandHandler(string serverConfigurationName)
        {
            var command = CommandHandlerFactory.Create<IServerConfigurationLookupCommandHandler>();
            command.Init(serverConfigurationName);
            ExecuteCommandHandlerAndStartFlow(command);
        }

        protected virtual void ExecuteBackCommandHandler()
        {
            var command = CommandHandlerFactory.Create<IServerConfigurationBackCommandHandler>();
            ExecuteCommandHandlerAndStartFlow(command);
        }
    
    }
}
