using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdGetVerticalEncoderPos(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_VERTICAL_ENCODER_POS;

        public override StmExternalCommandInputType InputType => StmExternalCommandInputType.NONE;

        public override string Name => "Vertical Encoder Position";

        public override ushort ResponseSize => 2;

        public override IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            ushort finalInt = BitConverter.ToUInt16(rawData);

            return new StmCommandResult<ushort>(finalInt, finalInt.ToString());
        }
    }
}
