using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.StmEnum;
using System.Text.RegularExpressions;

namespace StmTestingSuite.Command
{
    internal partial class CmdStepHorizontally(StmConnector comm, StmLogger? logger) : BaseStmInputCommand(comm, logger)
    {
        [GeneratedRegex(@"\s+")]
        private static partial Regex RemoveSpaces();

        public override string FieldName => "Steps,Speed";
        public override string? ReadableInputData { get; set; }
        public override byte[]? InputData { get; set; }
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.ACTION;
        public override ExternalCommand ExternalCommandType => ExternalCommand.ACTION_STEP_HORIZONTALLY;
        public override StmExternalCommandInputType InputType => StmExternalCommandInputType.CUSTOM;
        public override string Name => "Step Horizontally (Prototype)";

        /**
         * Returns a string if there's a validation error. Otherwise, nothing.
         **/
        public override string UpdateInputData(string readableData)
        {
            string normalizedString = RemoveSpaces().Replace(readableData, "");
            string[] commandParts = normalizedString.Split(',');

            if(commandParts.Length != 2)
            {
                return "Invalid format; must be steps,speed";
            } else if (!Validator.validInt(commandParts[0]) || !Validator.validInt(commandParts[1])) {
                return "Both sides of comma must be valid numbers";
            }

            Int16 steps = Int16.Parse(commandParts[0]);
            ushort speed = ushort.Parse(commandParts[1]);

            if(speed < 1)
            {
                return "Speed must be greater than 0.";
            } 
            else if(speed > 14) {
                return "Speed cannot exceed 14";
            }

            if(steps > 1000)
            {
                return "Cannot exceed 1000 steps.";
            }
            else if(steps < -1000)
            {
                return "Steps cannot be below -1000.";
            }

            byte[] stepBytes = BitConverter.GetBytes(steps);
            byte[] speedBytes = BitConverter.GetBytes(speed);
            byte[] data = [stepBytes[0], stepBytes[1], speedBytes[0]];

            ReadableInputData = "Steps: " + steps + "; Speed: " + speed;
            InputData = data;

            return "";
        }
    }
}
