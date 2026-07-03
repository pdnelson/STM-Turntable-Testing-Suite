using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdGetSizeSetting(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_SIZE_SETTING;

        public override string Name => "Size Setting";

        public override ushort ResponseSize => 1;

        public override IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            var sizeOption = (SizeOption)rawData[0];
            var sizeOptionString = sizeOption.GetString();

            return new StmCommandResult<SizeOption>(sizeOption, sizeOptionString);
        }

        public async Task<SizeOption?> ExecuteWithResult()
        {
            return ((StmCommandResult<SizeOption>?)Execute().Result)?.Result;
        }
    }
}
