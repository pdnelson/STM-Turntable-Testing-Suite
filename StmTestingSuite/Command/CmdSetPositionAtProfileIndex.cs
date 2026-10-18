using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.StmEnum;
using System.Text.RegularExpressions;

namespace StmTestingSuite.Command
{
    internal partial class CmdSetPositionAtProfileIndex(StmConnector comm, StmLogger? logger) : BaseStmInputCommand(comm, logger)
    {
        [GeneratedRegex(@"\s+")]
        private static partial Regex RemoveSpaces();

        public override string FieldName => "Index,Position";
        public override string? ReadableInputData { get; set; }
        public override byte[]? InputData { get; set; }
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.SET;
        public override ExternalCommand ExternalCommandType => ExternalCommand.SET_POSITION_AT_PROFILE_INDEX;
        public override StmExternalCommandInputType InputType => StmExternalCommandInputType.CUSTOM;
        public override string Name => "Set Position at Profile Index";

        /**
         * Returns a string if there's a validation error. Otherwise, nothing.
         **/
        public override string UpdateInputData(string readableData)
        {
            string normalizedString = RemoveSpaces().Replace(readableData, "");
            string[] commandParts = normalizedString.Split(',');

            if(commandParts.Length != 2)
            {
                return "Invalid format; must be index,position";
            } else if (!Validator.validInt(commandParts[0]) || !Validator.validInt(commandParts[1])) {
                return "Both sides of comma must be valid numbers";
            }

            byte index = byte.Parse(commandParts[0]);
            ushort position = ushort.Parse(commandParts[1]);

            if(index > 29) {
                return "Index cannot exceed 29";
            }

            byte[] positionBytes = BitConverter.GetBytes(position);
            byte[] data = [index, positionBytes[0], positionBytes[1]];

            ReadableInputData = "Index: " + index + "; Position: " + position;
            InputData = data;

            return "";
        }
    }
}
