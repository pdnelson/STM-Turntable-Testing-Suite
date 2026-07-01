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
                (byte)CommandId.NONE => "Idle",
                (byte)CommandId.PAUSE => "Pause",
                (byte)CommandId.UNPAUSE => "Unpause",
                (byte)CommandId.PLAY => "Play",
                (byte)CommandId.HOME => "Home",
                (byte)CommandId.CALIBRATION => "Calibration",
                (byte)CommandId.TEST_MODE => "Test Mode",
                (byte)CommandId.ERROR => "Error",
                (byte)CommandId.TOGGLE_CLUTCH => "Toggle Clutch",
                (byte)CommandId.STEP_H_MOTOR => "Step Horizontal Motor",
                (byte)CommandId.GO_TO_POSITION => "Go To Position",
                _ => "Invalid Data Received"
            };

            return new StmCommandResult<CommandId>((CommandId)rawData[0], currentCommand);
        }

        public async Task<CommandId?> ExecuteWithResult()
        {
            return ((StmCommandResult<CommandId>?)Execute().Result)?.Result;
        }
    }
}
