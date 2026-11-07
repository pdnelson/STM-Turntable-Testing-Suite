using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdGetRecordProfileBounds(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;
        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_RECORD_PROFILE_BOUNDS;
        public override string Name => "Record Profile Bounds";

        public override ushort ResponseSize => 4;

        public override IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            Response response = new(rawData);
            return new StmCommandResult<Response>(response, response.ToString());
        }

        public async Task<Response?> ExecuteWithResult()
        {
            return ((StmCommandResult<Response>?)Execute().Result)?.Result;
        }

        public struct Response
        {
            public Response(byte[] rawData)
            {
                byte[] homeBytes = { rawData[0], rawData[1] };
                Lower = BitConverter.ToUInt16(homeBytes);

                byte[] scanEndBytes = { rawData[2], rawData[3] };
                Upper = BitConverter.ToUInt16(scanEndBytes);
            }

            public ushort Lower { get; }
            public ushort Upper { get; }

            public readonly override string ToString()
            {
                return $"{Lower}, {Upper}";
            }
        }
    }
}
