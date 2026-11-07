using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdGetRecordProfile(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        private const ushort KnownDataSize = 4;

        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_RECORD_PROFILE;

        public override string Name => "Record Profile";

        // This is not the actual response size, this is just the max the response size could be.
        public override ushort ResponseSize => 5004;

        public override IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            ushort[]? response = null;
            string responseString = "";

            if (rawData[0] == Constants.AdvancedDataStartKey)
            {
                byte[] profileSizeBytes = { rawData[1], rawData[2] };
                ushort profileSize = BitConverter.ToUInt16(profileSizeBytes);
                ushort lastIndex = (ushort)(KnownDataSize + profileSize - 1);

                if (rawData[lastIndex] == Constants.AdvancedDataEndKey)
                {
                    response = new ushort[profileSize >> 1];

                    ushort profileIndex = 0;
                    ushort dataIndex = KnownDataSize - 1;

                    while(response.Length > profileIndex)
                    {
                        byte[] data = { rawData[dataIndex], rawData[dataIndex + 1] };
                        response[profileIndex] = BitConverter.ToUInt16(data);

                        profileIndex++;
                        dataIndex += 2;
                    }

                    responseString = $"{{ {string.Join(", ", response)} }}";
                }
            }

            return new StmCommandResult<ushort[]>(response, responseString);
        }

        public async Task<ushort[]> ExecuteWithResult()
        {
            var commandResult = (StmCommandResult<ushort[]>?)Execute().Result;

            if(commandResult == null || commandResult.Result == null)
            {
                return [];
            } else
            {
                return commandResult.Result;
            }
        }
    }
}
