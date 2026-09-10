using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdGetCalibrationValues(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.GET;
        public override ExternalCommand ExternalCommandType => ExternalCommand.GET_CALIBRATION_VALUES;
        public override string Name => "Calibration Values";
        public override ushort ResponseSize => 16;
        public override IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            Response? response = null;
            string responseString = "";

            // Verify both the start and end key are intact. If they aren't, then throw out the whole response.
            if (rawData[0] == Constants.AdvancedDataStartKey && rawData[15] == Constants.AdvancedDataEndKey)
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
                HorizontalPolarity = (EncoderPolarity)rawData[1];
                VerticalPolarity = (EncoderPolarity)rawData[2];

                byte[] homeBytes = { rawData[3], rawData[4] };
                Home = BitConverter.ToUInt16(homeBytes);

                byte[] upperLimitBytes = { rawData[5], rawData[6] };
                UpperLimit = BitConverter.ToUInt16(upperLimitBytes);

                byte[] lowerLimitBytes = { rawData[7], rawData[8] };
                LowerLimit = BitConverter.ToUInt16(lowerLimitBytes);

                byte[] in7Bytes = { rawData[9], rawData[10] };
                In7 = BitConverter.ToUInt16(in7Bytes);

                byte[] in10Bytes = { rawData[11], rawData[12] };
                In10 = BitConverter.ToUInt16(in10Bytes);

                byte[] in12Bytes = { rawData[13], rawData[14] };
                In12 = BitConverter.ToUInt16(in12Bytes);
            }

            public EncoderPolarity HorizontalPolarity { get; }
            public EncoderPolarity VerticalPolarity { get; }
            public ushort Home { get; }
            public ushort UpperLimit { get; }
            public ushort LowerLimit { get; }
            public ushort In7 { get; }
            public ushort In10 { get; }
            public ushort In12 { get; }

            public readonly override string ToString()
            {
                return $"({HorizontalPolarity}, {VerticalPolarity}, {Home}, {UpperLimit}, {LowerLimit}, {In7}, {In10}, {In12})";
            }
        }
    }
}
