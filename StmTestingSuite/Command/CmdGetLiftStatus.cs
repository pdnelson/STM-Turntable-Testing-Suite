using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdGetLiftStatus(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_LIFT_STATUS;

        public override string Name => "Lift Status";

        public override ushort ResponseSize => 1;

        public override IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            var liftStatus = rawData[0] switch
            {
                (byte)LiftStatus.LIFTED => "Lifted",
                (byte)LiftStatus.SET_DOWN => "Set Down",
                _ => "Invalid Data Received"
            };

            return new StmCommandResult<LiftStatus>((LiftStatus)rawData[0], liftStatus);
        }

        public async Task<LiftStatus?> ExecuteWithResult()
        {
            return ((StmCommandResult<LiftStatus>?)Execute().Result)?.Result;
        }
    }
}
