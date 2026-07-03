using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;
using System.Text;

namespace StmTestingSuite.Command
{
    internal class CmdGetUpTime(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_UP_TIME;

        public override string Name => "Up Time";

        public override ushort ResponseSize => 4;

        public override IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            uint finalInt = BitConverter.ToUInt32(rawData);

            string finalString = Utilities.secondsToTimeString(finalInt);

            return new StmCommandResult<uint>(finalInt, finalString.ToString());
        }

        public async Task<uint?> ExecuteWithResult()
        {
            return ((StmCommandResult<uint>?)Execute().Result)?.Result;
        }
    }
}
