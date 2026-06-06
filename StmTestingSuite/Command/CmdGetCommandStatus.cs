using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdGetCommandStatus(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_ERROR_CODE;

        public override string Name => "Command Status";

        public override ushort ResponseSize => 1;

        public override IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            var errorCode = rawData[0] switch
            {
                (byte)CommandStatus.RUNNING => "Running",
                (byte)CommandStatus.SUCCESS => "Success",
                (byte)CommandStatus.LIFT_STALLED_MOVING_UP => "Lift error: Stalled moving up",
                (byte)CommandStatus.LIFT_STALLED_MOVING_DOWN => "Lift error: Stalled moving down",
                (byte)CommandStatus.NOT_LIFTED => "Lift error: Not lifted at the end of \"Pause\" routine",
                (byte)CommandStatus.CLUTCH_FAILED_TO_ENGAGE => "Azimuth clutch failed to engage",
                (byte)CommandStatus.CLUTCH_FAILED_TO_DISENGAGE => "Azimuth clutch failed to disengage",
                _ => "Invalid Data Received"
            };

            return new StmCommandResult<CommandStatus>((CommandStatus)rawData[0], errorCode);
        }

        public async Task<CommandStatus?> ExecuteWithResult()
        {
            return ((StmCommandResult<CommandStatus>?)Execute().Result)?.Result;
        }
    }
}
