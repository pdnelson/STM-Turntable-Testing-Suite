using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdConnectionTest(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.OTHER;
        public override ExternalCommand ExternalCommandType => ExternalCommand.CONNECTION_TEST;
        public override string Name => "Connection Test";
        public override ushort ResponseSize => 1;

        public override IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            var response = rawData.First();

            string stringResponse = response switch
            {
                Constants.ConnectionTestSuccessResponse => "Success",
                _ => "Error"
            };

            return new StmCommandResult<bool>(response == Constants.ConnectionTestSuccessResponse, stringResponse);
        }

        public async Task<bool?> ExecuteWithResult()
        {
            return ((StmCommandResult<bool>?)Execute().Result)?.Result;
        }
    }
}
