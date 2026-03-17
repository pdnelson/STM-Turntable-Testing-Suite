using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdGetLiftStatus(StmConnector conn) : BaseStmCommand(conn)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_LIFT_STATUS;

        public override StmExternalCommandInputType InputType => StmExternalCommandInputType.NONE;

        public override string Name => "Lift Status";

        public override ushort ResponseSize => 1;

        public override IStmCommandResult InterpretResponseData(byte[]? rawData)
        {
            var liftStatus = rawData?[0] switch
            {
                (byte)LiftStatus.LIFTED => "Lifted",
                (byte)LiftStatus.SET_DOWN => "Set Down",
                _ => "Invalid Data Received"
            };

            return new StmCommandResult<LiftStatus?>((LiftStatus?)rawData?[0], liftStatus);
        }
    }
}
