using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdSetAzEncoderZero(StmConnector comm, StmLogger? logger) : BaseStmInputCommand(comm, logger)
    {
        public override string FieldName => "Encoder Ticks";

        public override string? ReadableInputData { get; set; }
        public override byte[]? InputData { get; set; }

        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.SET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.SET_AZ_ENCODER_ZERO;

        public override StmExternalCommandInputType InputType => StmExternalCommandInputType.NUMERIC_INT;

        public override string Name => "Azimuth Encoder Zero";
    }
}
