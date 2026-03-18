using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdGetErrorCode(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_ERROR_CODE;

        public override string Name => "Error Code";

        public override ushort ResponseSize => 1;

        public override IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            var errorCode = rawData[0] switch
            {
                (byte)CommandError.NO_ERROR => "No error",
                (byte)CommandError.LIFT_STALLED_MOVING_UP => "Lift error: Stalled moving up",
                (byte)CommandError.LIFT_STALLED_MOVING_DOWN => "Lift error: Stalled moving down",
                (byte)CommandError.NOT_LIFTED => "Lift error: Not lifted at the end of \"Pause\" routine",
                _ => "Invalid Data Received"
            };

            return new StmCommandResult<CommandError>((CommandError)rawData[0], errorCode);
        }

        public async Task<CommandError?> ExecuteWithResult()
        {
            return ((StmCommandResult<CommandError>?)Execute().Result)?.Result;
        }
    }
}
