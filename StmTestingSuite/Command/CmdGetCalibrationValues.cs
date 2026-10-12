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
        public override ushort ResponseSize => 17;
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
                HorizontalMotorPolarity = (EncoderPolarity)rawData[1];
                HorizontalPolarity = (EncoderPolarity)rawData[2];
                VerticalPolarity = (EncoderPolarity)rawData[3];

                byte[] homeBytes = { rawData[4], rawData[5] };
                Home = BitConverter.ToUInt16(homeBytes);

                byte[] upperLimitBytes = { rawData[6], rawData[7] };
                UpperLimit = BitConverter.ToUInt16(upperLimitBytes);

                byte[] lowerLimitBytes = { rawData[8], rawData[9] };
                LowerLimit = BitConverter.ToUInt16(lowerLimitBytes);

                byte[] in7Bytes = { rawData[10], rawData[11] };
                In7 = BitConverter.ToUInt16(in7Bytes);

                byte[] in10Bytes = { rawData[12], rawData[13] };
                In10 = BitConverter.ToUInt16(in10Bytes);

                byte[] in12Bytes = { rawData[14], rawData[15] };
                In12 = BitConverter.ToUInt16(in12Bytes);
            }
            public EncoderPolarity HorizontalMotorPolarity { get; }
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
                return $"({HorizontalMotorPolarity}, {HorizontalPolarity}, {VerticalPolarity}, {Home}, {UpperLimit}, {LowerLimit}, {In7}, {In10}, {In12})";
            }
        }
    }
}
