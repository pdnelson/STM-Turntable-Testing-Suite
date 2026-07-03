using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdGetSpeedSetting(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_SPEED_SETTING;

        public override string Name => "Speed Setting";

        public override ushort ResponseSize => 1;

        public override IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            var speedOption = (SpeedOption)rawData[0];
            var speedOptionString = speedOption.GetString();

            return new StmCommandResult<SpeedOption>(speedOption, speedOptionString);
        }

        public async Task<SpeedOption?> ExecuteWithResult()
        {
            return ((StmCommandResult<SpeedOption>?)Execute().Result)?.Result;
        }
    }
}
