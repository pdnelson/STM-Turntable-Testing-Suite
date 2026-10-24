using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.StmEnum;
using System.Text.RegularExpressions;

namespace StmTestingSuite.Command
{
    internal partial class CmdActionPlayAtTrackIndex(StmConnector comm, StmLogger? logger) : BaseStmInputCommand(comm, logger)
    {
        [GeneratedRegex(@"\s+")]
        private static partial Regex RemoveSpaces();

        public override string FieldName => "Index";
        public override string? ReadableInputData { get; set; }
        public override byte[]? InputData { get; set; }
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.ACTION;
        public override ExternalCommand ExternalCommandType => ExternalCommand.ACTION_PLAY_AT_TRACK_INDEX;
        public override StmExternalCommandInputType InputType => StmExternalCommandInputType.NUMERIC_INT;
        public override string Name => "Play At Track Index";

        /**
         * Returns a string if there's a validation error. Otherwise, nothing.
         **/
        public override string UpdateInputData(string readableData)
        {
            string normalizedString = RemoveSpaces().Replace(readableData, "");

            ushort index = ushort.Parse(normalizedString);

            if(index < 0)
            {
                return "Index must be greater than -1.";
            } 
            else if(index > 50) {
                return "Speed RPM cannot exceed 50";
            }

            byte[] indexBytes = BitConverter.GetBytes(index);
            byte[] data = [indexBytes[0]];

            ReadableInputData = "Index: " + index;
            InputData = data;

            return "";
        }
    }
}
