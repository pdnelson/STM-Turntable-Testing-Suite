using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdGetCurrentCommand(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_CURRENT_COMMAND;

        public override string Name => "Current Command";

        public override ushort ResponseSize => 1;

        public override IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            var currentCommand = rawData[0] switch
            {
                (byte)ActionCommand.NO_ACTION => "Idle",
                (byte)ActionCommand.PAUSE => "Pause",
                (byte)ActionCommand.UNPAUSE => "Unpause",
                (byte)ActionCommand.PLAY => "Play",
                (byte)ActionCommand.HOME => "Home",
                (byte)ActionCommand.CALIBRATION => "Calibration",
                (byte)ActionCommand.TEST_MODE => "Test Mode",
                (byte)ActionCommand.ERROR => "Error",
                _ => "Invalid Data Received"
            };

            return new StmCommandResult<ActionCommand>((ActionCommand)rawData[0], currentCommand);
        }

        public async Task<ActionCommand?> ExecuteWithResult()
        {
            return ((StmCommandResult<ActionCommand>?)Execute().Result)?.Result;
        }
    }
}
