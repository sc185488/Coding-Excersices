using NCR.EG.Client.POS.BusinessObjects.CommandHandlers;
using Retalix.Client.POS.BusinessObjects.CommandHandlers;
using System.ComponentModel.Composition;

namespace Retalix.Jumbo.Client.POS.API.CommandHandlers
{
    [Export(typeof(IServerConfigurationBackCommandHandler))]
    class ServerConfigurationBackCommandHandler : PosCommandHandlerBase  , IServerConfigurationBackCommandHandler
    {
        private const string ServerConfigurationBackOutcome = "ServerConfigurationBackOutcome";

        protected override string ExecuteLogic()
        {
            return ServerConfigurationBackOutcome;
        }
    }
}
