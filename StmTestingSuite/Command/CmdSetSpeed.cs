using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdSetSpeed(StmConnector conn) : BaseStmDropDownCommand(conn)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.SET;
        public override ExternalCommand ExternalCommandType => ExternalCommand.SET_SPEED;
        public override StmExternalCommandInputType InputType => StmExternalCommandInputType.DROP_DOWN;
        public override string Name => "Speed";
        public override ushort ResponseSize => 0;
        public override string FieldName => "RPM";
        public override byte[]? InputData { get; set; }

        public override string? ReadableInputData { get; set; }

        public override List<StmExternalCommandInputOption> Options => [
            new("33", (byte)SpeedOption.RPM_33),
            new("45", (byte)SpeedOption.RPM_45),
            new("78", (byte)SpeedOption.RPM_78),
            new("Auto", (byte)SpeedOption.AUTO)
        ];
    }
}
