using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.StmEnum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StmTestingSuite.Command
{
    internal partial class CmdActionGoToPositionH(StmConnector comm, StmLogger? logger) : BaseStmInputCommand(comm, logger)
    {
        [GeneratedRegex(@"\s+")]
        private static partial Regex RemoveSpaces();

        public override string FieldName => "Position,Speed";
        public override string? ReadableInputData { get; set; }
        public override byte[]? InputData { get; set; }
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.ACTION;
        public override ExternalCommand ExternalCommandType => ExternalCommand.ACTION_GO_TO_POSITION_H;
        public override StmExternalCommandInputType InputType => StmExternalCommandInputType.CUSTOM;
        public override string Name => "Go To Position";

        /**
         * Returns a string if there's a validation error. Otherwise, nothing.
         **/
        public override string UpdateInputData(string readableData)
        {
            string normalizedString = RemoveSpaces().Replace(readableData, "");
            string[] commandParts = normalizedString.Split(',');

            if (commandParts.Length != 2)
            {
                return "Invalid format; must be position,speed";
            }
            else if (!Validator.validInt(commandParts[0]) || !Validator.validInt(commandParts[1]))
            {
                return "Both sides of comma must be valid numbers";
            }

            Int16 position = Int16.Parse(commandParts[0]);
            ushort speed = ushort.Parse(commandParts[1]);

            if (speed < 1)
            {
                return "Speed must be greater than 0.";
            }
            else if (speed > 14)
            {
                return "Speed cannot exceed 14";
            }

            if (position > 16384)
            {
                return "Cannot exceed 1000 steps.";
            }
            else if (position < 0)
            {
                return "Steps cannot be below -1000.";
            }

            byte[] stepBytes = BitConverter.GetBytes(position);
            byte[] speedBytes = BitConverter.GetBytes(speed);
            byte[] data = [stepBytes[0], stepBytes[1], speedBytes[0]];

            ReadableInputData = "Position: " + position + "; Speed: " + speed;
            InputData = data;

            return "";
        }
    }
}
