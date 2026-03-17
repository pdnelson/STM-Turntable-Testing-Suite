using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdSetCustomSpeed(StmConnector comm, StmLogger? logger) : BaseStmInputCommand(comm, logger)
    {
        public override string FieldName => "RPM";

        public override string? ReadableInputData { get; set; }
        public override byte[]? InputData { get; set; }

        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.SET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.SET_CUSTOM_SPEED;

        public override StmExternalCommandInputType InputType => StmExternalCommandInputType.NUMERIC_DEC;

        public override string Name => "Speed (Custom)";

        public override ushort ResponseSize => 0;
    }
}
