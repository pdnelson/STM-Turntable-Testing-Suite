using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdGetRecordSensorTabData(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;
        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_RECORD_SENSOR_TAB;
        public override string Name => "Record Sensor Tab Data";
        public override ushort ResponseSize => 7;
        public override IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            Response? response = null;
            string responseString = "";

            // Verify both the start and end key are intact. If they aren't, then throw out the whole response.
            if (rawData[0] == Constants.AdvancedDataStartKey && rawData[ResponseSize - 1] == Constants.AdvancedDataEndKey)
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
                byte[] photoDiodeBytes = { rawData[1], rawData[2] };
                PhotoDiodeValue = BitConverter.ToUInt16(photoDiodeBytes);

                HeadshellLEDStatus = rawData[3] == 1;

                byte[] hPosBytes = { rawData[4], rawData[5] };
                HorizontalPosition = BitConverter.ToUInt16(hPosBytes);
            }
            public ushort PhotoDiodeValue { get; }
            public bool HeadshellLEDStatus { get; }
            public ushort HorizontalPosition { get; }

            public readonly override string ToString()
            {
                return $"({HeadshellLEDStatus}, {PhotoDiodeValue}, {HorizontalPosition})";
            }
        }
    }
}
