using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdGetCurrentCommand(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_CURRENT_COMMAND;

        public override string Name => "Current Command";

        public override ushort ResponseSize => 1;

        public override IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            var commandId = (CommandId)rawData[0];
            var commandString = commandId.GetString();

            return new StmCommandResult<CommandId>(commandId, commandString);
        }

        public async Task<CommandId?> ExecuteWithResult()
        {
            return ((StmCommandResult<CommandId>?)Execute().Result)?.Result;
        }
    }
}
