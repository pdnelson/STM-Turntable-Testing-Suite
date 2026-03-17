using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.StmEnum;
using System.Text;

namespace StmTestingSuite.Command
{
    internal class CmdGetUpTime(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_UP_TIME;

        public override StmExternalCommandInputType InputType => StmExternalCommandInputType.NONE;

        public override string Name => "Up Time";

        public override ushort ResponseSize => 4;

        public override IStmCommandResult InterpretResponseData(byte[]? rawData)
        {
            if (rawData == null) return new StmCommandResult<uint?>(null, "");

            uint finalInt = BitConverter.ToUInt32(rawData);

            TimeSpan timeSpan = TimeSpan.FromSeconds(finalInt);

            StringBuilder finalString = new();

            if (timeSpan.Days > 0) finalString.Append(timeSpan.Days + "d, ");
            finalString.Append(timeSpan.Hours.ToString("D2") + ":" + timeSpan.Minutes.ToString("D2") + ":" + timeSpan.Seconds.ToString("D2"));

            return new StmCommandResult<uint>(finalInt, finalString.ToString());
        }
    }
}
