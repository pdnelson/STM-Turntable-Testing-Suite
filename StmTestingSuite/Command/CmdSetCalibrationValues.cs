using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal partial class CmdSetCalibrationValues(StmConnector comm, StmLogger? logger) : BaseStmInputCommand(comm, logger)
    {
        public override string FieldName => "n/a";
        public override string? ReadableInputData { get; set; }
        public override byte[]? InputData { get; set; }
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.SET;
        public override ExternalCommand ExternalCommandType => ExternalCommand.SET_CALIBRATION_VALUES;
        public override StmExternalCommandInputType InputType => StmExternalCommandInputType.CUSTOM;
        public override string Name => "Update Calibration Values";

        public void UpdateInputData(Polarity hStepper, Polarity h, Polarity v, ushort home, ushort vUpperLimit, ushort vLowerLimit, ushort in7, ushort in10, ushort in12, ushort scanEnd, ushort azOffset)
        {
            byte[] data = new byte[19];

            data[0] = (byte)hStepper;
            data[1] = (byte)h;
            data[2] = (byte)v;

            byte[] homeBytes = BitConverter.GetBytes(home);
            data[3] = homeBytes[0];
            data[4] = homeBytes[1];

            byte[] vUpperLimitBytes = BitConverter.GetBytes(vUpperLimit);
            data[5] = vUpperLimitBytes[0];
            data[6] = vUpperLimitBytes[1];

            byte[] vLowerLimitBytes = BitConverter.GetBytes(vLowerLimit);
            data[7] = vLowerLimitBytes[0];
            data[8] = vLowerLimitBytes[1];

            byte[] in7Bytes = BitConverter.GetBytes(in7);
            data[9] = in7Bytes[0];
            data[10] = in7Bytes[1];

            byte[] in10Bytes = BitConverter.GetBytes(in10);
            data[11] = in10Bytes[0];
            data[12] = in10Bytes[1];

            byte[] in12Bytes = BitConverter.GetBytes(in12);
            data[13] = in12Bytes[0];
            data[14] = in12Bytes[1];

            byte[] scanEndBytes = BitConverter.GetBytes(scanEnd);
            data[15] = scanEndBytes[0];
            data[16] = scanEndBytes[1];

            byte[] azOffsetBytes = BitConverter.GetBytes(azOffset);
            data[17] = azOffsetBytes[0];
            data[18] = azOffsetBytes[1];

            ReadableInputData = "patrick is too lazy to wire up the calibration values here";
            InputData = data;
        }
    }
}
