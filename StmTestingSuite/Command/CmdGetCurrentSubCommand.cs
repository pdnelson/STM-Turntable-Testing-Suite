using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdGetCurrentSubCommand(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_CURRENT_SUB_COMMAND;

        public override string Name => "Current Subcommand";

        public override ushort ResponseSize => 1;

        public override IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            var currentCommand = rawData[0] switch
            {
                (byte)SubCommandId.NONE => "Idle",
                (byte)SubCommandId.DISENGAGE_AZ_CLUTCH => "Disengage Azimuth Clutch",
                (byte)SubCommandId.ENGAGE_AZ_CLUTCH => "Engage Azimuth Clutch",
                (byte)SubCommandId.LIFT_TONEARM => "Lift Tonearm",
                (byte)SubCommandId.SET_DOWN_TONEARM => "Set Down Tonearm",
                (byte)SubCommandId.MOVE_N_STEPS_HORIZONTALLY => "Move n Steps Horizontally",
                (byte)SubCommandId.ERROR => "Error",
                (byte)SubCommandId.GO_TO_POSITION => "Go To Position",
                _ => "Invalid Data Received"
            };

            return new StmCommandResult<CommandId>((CommandId)rawData[0], currentCommand);
        }

        public async Task<CommandId?> ExecuteWithResult()
        {
            return ((StmCommandResult<CommandId>?)Execute().Result)?.Result;
        }
    }
}
