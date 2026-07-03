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
            var subCommandId = (SubCommandId)rawData[0];
            var subCommandString = subCommandId.GetString();

            return new StmCommandResult<SubCommandId>(subCommandId, subCommandString);
        }

        public async Task<CommandId?> ExecuteWithResult()
        {
            return ((StmCommandResult<CommandId>?)Execute().Result)?.Result;
        }
    }
}
