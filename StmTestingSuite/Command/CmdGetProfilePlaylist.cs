using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdGetProfilePlaylist(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        private const ushort KnownDataSize = 7;

        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;
        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_PROFILE_PLAYLIST;
        public override string Name => "Record Profile and Playlist";

        // This is not the actual response size, this is just the max the response size could be.
        public override ushort ResponseSize => 163;

        public override IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            Response? response = null;
            string responseString = "";

            ushort lastIndex = (ushort)(KnownDataSize + rawData[2] + rawData[3]);

            // Verify both the start and end key are intact. If they aren't, then throw out the whole response.
            if (rawData[0] == Constants.AdvancedDataStartKey && rawData[lastIndex - 1] == Constants.AdvancedDataEndKey)
            {
                response = new Response(rawData);
                responseString = ((Response)response).ToString();
            }

            return new StmCommandResult<Response?>(response, responseString);
        }

        public async Task<Response?> ExecuteWithResult()
        {
            return ((StmCommandResult<Response?>?)Execute().Result)?.Result;
        }

        public struct Response
        {
            public Response(byte[] rawData)
            {
                CurrentPlaylistIndex = (sbyte)rawData[1];

                ushort normalizedProfileSize = rawData[2];
                NormalizedProfile = new ushort[normalizedProfileSize >> 1];

                ushort profileIndex = 0;
                ushort dataIndex = KnownDataSize - 1;

                while(NormalizedProfile.Length > profileIndex)
                {
                    byte[] data = { rawData[dataIndex], rawData[dataIndex + 1] };
                    NormalizedProfile[profileIndex] = BitConverter.ToUInt16(data);

                    profileIndex++;
                    dataIndex += 2;
                }

                Playlist = new ushort[rawData[3]];

                ushort playlistStart = (ushort)((KnownDataSize - 1) + normalizedProfileSize);

                for (ushort i = playlistStart; i < playlistStart + Playlist.Length; i++)
                {
                    Playlist[i - playlistStart] = rawData[i];
                }

                byte[] normHorizontalBytes = { rawData[4], rawData[5] };
                CurrentPosition = BitConverter.ToUInt16(normHorizontalBytes);
            }

            public ushort CurrentPosition { get; }
            public short CurrentPlaylistIndex { get; }
            public ushort[] NormalizedProfile { get; }
            public ushort[] Playlist { get; }

            public readonly override string ToString()
            {
                return $"{CurrentPosition}, {CurrentPlaylistIndex}, {{ {string.Join(", ", NormalizedProfile)} }}, {{ {string.Join(", ", Playlist)} }}";
            }
        }
    }
}
