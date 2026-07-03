using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdGetHomeStatus(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_HOME_STATUS;

        public override string Name => "Home Status";

        public override ushort ResponseSize => 1;

        public override IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            var homeStatus = (HomeStatus)rawData[0];
            var homeStatusString = homeStatus.GetString();

            return new StmCommandResult<HomeStatus>((HomeStatus)rawData[0], homeStatusString);
        }

        public async Task<HomeStatus?> ExecuteWithResult()
        {
            return ((StmCommandResult<HomeStatus>?)Execute().Result)?.Result;
        }
    }
}
