using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdGetErrorStatus(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_ERROR_CODE;

        public override string Name => "Command Status";

        public override ushort ResponseSize => 1;

        public override IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            var errorCode = rawData[0] switch
            {
                (byte)ErrorStatus.NONE => "None",
                (byte)ErrorStatus.SUCCESS => "Success",
                (byte)ErrorStatus.LIFT_STALLED_MOVING_UP => "Lift error: Stalled moving up",
                (byte)ErrorStatus.LIFT_STALLED_MOVING_DOWN => "Lift error: Stalled moving down",
                (byte)ErrorStatus.NOT_LIFTED => "Lift error: Not lifted at the end of \"Pause\" routine",
                (byte)ErrorStatus.CLUTCH_FAILED_TO_ENGAGE => "Azimuth clutch failed to engage",
                (byte)ErrorStatus.CLUTCH_FAILED_TO_DISENGAGE => "Azimuth clutch failed to disengage",
                _ => "Invalid Data Received"
            };

            return new StmCommandResult<ErrorStatus>((ErrorStatus)rawData[0], errorCode);
        }

        public async Task<ErrorStatus?> ExecuteWithResult()
        {
            return ((StmCommandResult<ErrorStatus>?)Execute().Result)?.Result;
        }
    }
}
