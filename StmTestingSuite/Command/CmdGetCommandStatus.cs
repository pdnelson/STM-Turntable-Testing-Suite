using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdGetCommandStatus(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_COMMAND_STATUS;

        public override string Name => "Command Status";

        public override ushort ResponseSize => 1;

        public override IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            var errorStatus = (CommandStatus)rawData[0];
            var errorString = errorStatus.GetString();

            return new StmCommandResult<CommandStatus>(errorStatus, errorString);
        }

        public async Task<CommandStatus?> ExecuteWithResult()
        {
            return ((StmCommandResult<CommandStatus>?)Execute().Result)?.Result;
        }
    }
}
