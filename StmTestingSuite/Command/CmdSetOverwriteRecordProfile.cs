using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.StmEnum;
using System.Text.RegularExpressions;

namespace StmTestingSuite.Command
{
    internal partial class CmdSetOverwriteRecordProfile(StmConnector comm, StmLogger? logger) : BaseStmInputCommand(comm, logger)
    {
        [GeneratedRegex(@"\s+")]
        private static partial Regex RemoveSpaces();

        public override string FieldName => "CSV";
        public override string? ReadableInputData { get; set; }
        public override byte[]? InputData { get; set; }
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.SET;
        public override ExternalCommand ExternalCommandType => ExternalCommand.SET_OVERWRITE_RECORD_PROFILE;
        public override StmExternalCommandInputType InputType => StmExternalCommandInputType.CUSTOM;
        public override string Name => "Overwrite Record Profile";

        public void UpdateInputData(ushort[] positions)
        {
            byte dataSize = (byte)(1 + positions.Length << 1);

            byte[] data = new byte[dataSize];

            data[0] = dataSize;

            ushort dataIndex = 1;
            ushort positionIndex = 0;

            while(positionIndex < positions.Length)
            {
                var dataBytes = BitConverter.GetBytes(positions[positionIndex]);
                data[dataIndex] = dataBytes[0];
                data[dataIndex + 1] = dataBytes[1];

                dataIndex += 2;
                positionIndex++;
            }

            ReadableInputData = string.Join(", ", positions);
            InputData = data;
        }
    }
}
