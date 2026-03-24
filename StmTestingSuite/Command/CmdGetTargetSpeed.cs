using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdGetTargetSpeed(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_SPEED_TARGET;

        public override string Name => "Target Speed";

        public override ushort ResponseSize => 4;

        public override IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            var rpm = BitConverter.ToSingle(rawData);

            var stringRpm = rpm + " RPM";

            if (rpm < 0)
            {
                stringRpm = "Not moving";
            }

            return new StmCommandResult<float>(rpm, stringRpm);
        }

        public async Task<float?> ExecuteWithResult()
        {
            return ((StmCommandResult<float>?)Execute().Result)?.Result;
        }
    }
}
