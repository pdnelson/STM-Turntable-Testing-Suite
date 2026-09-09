using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.StmEnum;
using System.Text.RegularExpressions;

namespace StmTestingSuite.Command
{
    internal partial class CmdActionMoveNStepsV(StmConnector comm, StmLogger? logger) : BaseStmInputCommand(comm, logger)
    {
        [GeneratedRegex(@"\s+")]
        private static partial Regex RemoveSpaces();

        public override string FieldName => "Steps,Speed,Release";
        public override string? ReadableInputData { get; set; }
        public override byte[]? InputData { get; set; }
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.ACTION;
        public override ExternalCommand ExternalCommandType => ExternalCommand.ACTION_MOVE_N_STEPS_V;
        public override StmExternalCommandInputType InputType => StmExternalCommandInputType.CUSTOM;
        public override string Name => "Move N Steps (Vertical)";

        /**
         * Returns a string if there's a validation error. Otherwise, nothing.
         **/
        public override string UpdateInputData(string readableData)
        {
            string normalizedString = RemoveSpaces().Replace(readableData, "");
            string[] commandParts = normalizedString.Split(',');

            if(commandParts.Length != 3)
            {
                return "Invalid format; must be steps,speed,release current after movement (0 = no; 1 = yes)";
            } else if (!Validator.validInt(commandParts[0]) || !Validator.validInt(commandParts[1]) || !Validator.validInt(commandParts[2])) {
                return "All entries must be valid numbers";
            }

            Int16 steps = Int16.Parse(commandParts[0]);
            ushort speed = ushort.Parse(commandParts[1]);
            ushort releaseMotorCurrentAfterMovement = ushort.Parse(commandParts[2]);

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

            if(releaseMotorCurrentAfterMovement != 1 && releaseMotorCurrentAfterMovement != 0)
            {
                return "Release current after movement must be 0 or 1.";
            }

            byte[] stepBytes = BitConverter.GetBytes(steps);
            byte[] speedBytes = BitConverter.GetBytes(speed);
            byte[] releaseMotorCurrentAfterMovementBytes = BitConverter.GetBytes(releaseMotorCurrentAfterMovement);
            byte[] data = [stepBytes[0], stepBytes[1], speedBytes[0], releaseMotorCurrentAfterMovementBytes[0]];

            ReadableInputData = "Steps: " + steps + "; Speed: " + speed;
            InputData = data;

            return "";
        }
    }
}
