using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdGetHorizontalEncoderPos(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_HORIZONTAL_ENCODER_POS;

        public override StmExternalCommandInputType InputType => StmExternalCommandInputType.NONE;

        public override string Name => "Horizontal Encoder Position";

        public override ushort ResponseSize => 2;

        public override IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            // TODO!!!!

            return base.InterpretResponseData(rawData);
        }
    }
}
