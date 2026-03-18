using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdSetSize(StmConnector comm, StmLogger? logger) : BaseStmDropDownCommand(comm, logger)
    {
        public override List<StmExternalCommandInputOption> Options => [
            new("7", (byte)SizeOption.IN_7),
            new("10", (byte)SizeOption.IN_10),
            new("12", (byte)SizeOption.IN_12),
            new("Auto", (byte)SizeOption.AUTO)
        ];

        public override string FieldName => "Inches";

        public override string? ReadableInputData { get; set; }
        public override byte[]? InputData { get; set; }

        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.SET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.SET_SIZE;

        public override string Name => "Size";
    }
}
