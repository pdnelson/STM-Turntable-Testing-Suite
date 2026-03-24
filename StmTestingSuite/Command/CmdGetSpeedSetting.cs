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
            var liftStatus = rawData[0] switch
            {
                (byte)SpeedOption.RPM_33 => "33 RPM",
                (byte)SpeedOption.RPM_45 => "45 RPM",
                (byte)SpeedOption.RPM_78 => "78 RPM",
                (byte)SpeedOption.AUTO => "Automatic",
                (byte)SpeedOption.CUSTOM => "Custom",
                _ => "Invalid Data Received"
            };

            return new StmCommandResult<SpeedOption>((SpeedOption)rawData[0], liftStatus);
        }

        public async Task<SpeedOption?> ExecuteWithResult()
        {
            return ((StmCommandResult<SpeedOption>?)Execute().Result)?.Result;
        }
    }
}
