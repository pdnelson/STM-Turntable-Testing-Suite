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
            var liftStatus = (LiftStatus)rawData[0];
            var liftStatusString = liftStatus.GetString();

            return new StmCommandResult<LiftStatus>(liftStatus, liftStatusString);
        }

        public async Task<LiftStatus?> ExecuteWithResult()
        {
            return ((StmCommandResult<LiftStatus>?)Execute().Result)?.Result;
        }
    }
}
