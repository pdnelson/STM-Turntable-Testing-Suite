using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdGetHomeStatus(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_HOME_STATUS;

        public override StmExternalCommandInputType InputType => StmExternalCommandInputType.NONE;

        public override string Name => "Home Status";

        public override ushort ResponseSize => 1;

        public override IStmCommandResult InterpretResponseData(byte[]? rawData)
        {
            var homeStatus = rawData[0] switch
            {
                (byte)HomeStatus.HOMED => "Homed",
                (byte)HomeStatus.NOT_HOMED => "Not Homed",
                _ => "Invalid Data Received"
            };

            return new StmCommandResult<HomeStatus?>((HomeStatus?)rawData?[0], homeStatus);
        }
    }
}
