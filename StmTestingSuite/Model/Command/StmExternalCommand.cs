using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.Command.Input.Value;
using static System.Windows.Forms.Design.AxImporter;

namespace StmTestingSuite.Model.Command
{
    internal class StmExternalCommand
    {
        public StmExternalCommandType Type { get; }
        public StmExternalCommandInput Input { get; }
        public StmExternalCommandGroup Group { get; }
        public string Name { get; }
        public StmExternalCommandType? Type1 { get; }

        public StmExternalCommand(StmExternalCommandType type)
        {
            Type = type;
            Group = PopulateGroup(type);

            // Default values that will cover most use cases. Special cases are handed in the switch statement below.
            Input = new StmExternalCommandInput(StmExternalCommandInputType.NONE);
            Name = "";

            switch (type)
            {
                case StmExternalCommandType.NO_OP:
                    Name = "Blank Command";
                    break;
                case StmExternalCommandType.ACTION_PAUSE_UNPAUSE:
                    Name = "Pause/Unpause";
                    break;
                case StmExternalCommandType.SET_SPEED:
                    {
                        Name = "Speed";
                        List<StmExternalCommandInputOption> options = new List<StmExternalCommandInputOption>
                        {
                            new StmExternalCommandInputOption("33 1/3", (ushort)SpeedValue.RPM_33),
                            new StmExternalCommandInputOption("45", (ushort)SpeedValue.RPM_45),
                            new StmExternalCommandInputOption("78", (ushort)SpeedValue.RPM_78)
                        };
                        Input = new StmExternalCommandInput(StmExternalCommandInputType.DROP_DOWN, "RPM", options);
                        break;
                    }
                case StmExternalCommandType.SET_SIZE:
                    {
                        Name = "Size";
                        List<StmExternalCommandInputOption> options = new List<StmExternalCommandInputOption>
                        {
                            new StmExternalCommandInputOption("7", (ushort)SizeValue.IN_7),
                            new StmExternalCommandInputOption("10", (ushort)SizeValue.IN_10),
                            new StmExternalCommandInputOption("12", (ushort)SizeValue.IN_12)
                        };
                        Input = new StmExternalCommandInput(StmExternalCommandInputType.DROP_DOWN, "Inches", options);
                        break;
                    }
                case StmExternalCommandType.SET_CUSTOM_SPEED:
                    Name = "Custom Speed";
                    Input = new StmExternalCommandInput(StmExternalCommandInputType.NUMERIC_DEC, "RPM");
                    break;
                case StmExternalCommandType.SET_CUSTOM_SIZE:
                    Name = "Custom Size";
                    Input = new StmExternalCommandInput(StmExternalCommandInputType.NUMERIC_INT, "Encoder Ticks");
                    break;
                case StmExternalCommandType.GET_VERTICAL_ENCODER_POS:
                    Name = "Vertical Encoder Position";
                    break;
                case StmExternalCommandType.GET_HORIZONTAL_ENCODER_POS:
                    Name = "Horizontal Encoder Position";
                    break;
                case StmExternalCommandType.GET_LIFT_STATUS:
                    Name = "Lift Status";
                    break;
                case StmExternalCommandType.GET_HOME_STATUS:
                    Name = "Home Status";
                    break;
                case StmExternalCommandType.GET_CURRENT_COMMAND:
                    Name = "Current Command";
                    break;
            }
        }

        private static StmExternalCommandGroup PopulateGroup(StmExternalCommandType type)
        {
            if ((ushort)type == 0)
            {
                return new StmExternalCommandGroup(StmExternalCommandGroupType.OTHER);
            }
            else if ((ushort)type > 0 && (ushort)type < 31)
            {
                return new StmExternalCommandGroup(StmExternalCommandGroupType.ACTION);
            }
            else if ((ushort)type > 30 && (ushort)type < 100)
            {
                return new StmExternalCommandGroup(StmExternalCommandGroupType.SET);
            }
            else
            {
                return new StmExternalCommandGroup(StmExternalCommandGroupType.GET);
            }
        }
    }
}
