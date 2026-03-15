using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.Command.Input.Value;
using StmTestingSuite.Model.Response;

namespace StmTestingSuite.Model.Command
{
    internal class StmExternalCommand
    {
        public StmExternalCommandType Type { get; }
        public StmExternalCommandInput Input { get; }
        public StmExternalCommandGroup Group { get; }
        public string Name { get; }
        public StmExternalCommandType? Type1 { get; }

        public ushort ResponseSize { get; }

        public StmExternalCommand(StmExternalCommandType type)
        {
            Type = type;
            Group = PopulateGroup(type);

            // Default values that will cover most use cases. Special cases are handed in the switch statement below.
            Input = new StmExternalCommandInput(StmExternalCommandInputType.NONE);
            Name = "";
            ResponseSize = 0;

            switch (type)
            {
                case StmExternalCommandType.CONNECTION_TEST:
                    Name = "Connection Test";
                    ResponseSize = 1;
                    break;
                case StmExternalCommandType.ACTION_PAUSE_UNPAUSE:
                    Name = "Pause/Unpause";
                    break;
                case StmExternalCommandType.SET_CLEAR_ACTION_COMMAND:
                    Name = "Clear Errors/Current Command";
                    break;
                case StmExternalCommandType.SET_SPEED:
                    {
                        Name = "Speed";
                        List<StmExternalCommandInputOption> options =
                        [
                            new("33 1/3", (ushort)SpeedValue.RPM_33),
                            new("45", (ushort)SpeedValue.RPM_45),
                            new("78", (ushort)SpeedValue.RPM_78),
                            new("Auto", (ushort)SpeedValue.AUTO)
                        ];
                        Input = new StmExternalCommandInput(StmExternalCommandInputType.DROP_DOWN, "RPM", options);
                        break;
                    }
                case StmExternalCommandType.SET_SIZE:
                    {
                        Name = "Size";
                        List<StmExternalCommandInputOption> options =
                        [
                            new("7", (ushort)SizeValue.IN_7),
                            new("10", (ushort)SizeValue.IN_10),
                            new("12", (ushort)SizeValue.IN_12),
                            new("Auto", (ushort)SizeValue.AUTO)
                        ];
                        Input = new StmExternalCommandInput(StmExternalCommandInputType.DROP_DOWN, "Inches", options);
                        break;
                    }
                case StmExternalCommandType.SET_CUSTOM_SPEED:
                    Name = "Custom Speed";
                    Input = new StmExternalCommandInput(StmExternalCommandInputType.NUMERIC_DEC, "RPM");
                    break;
                case StmExternalCommandType.GET_VERTICAL_ENCODER_POS:
                    Name = "Vertical Encoder Position";
                    ResponseSize = 2;
                    break;
                case StmExternalCommandType.GET_HORIZONTAL_ENCODER_POS:
                    Name = "Horizontal Encoder Position";
                    ResponseSize = 2;
                    break;
                case StmExternalCommandType.GET_LIFT_STATUS:
                    Name = "Lift Status";
                    ResponseSize = 1;
                    break;
                case StmExternalCommandType.GET_HOME_STATUS:
                    Name = "Home Status";
                    ResponseSize = 1;
                    break;
                case StmExternalCommandType.GET_CURRENT_COMMAND:
                    Name = "Current Command";
                    ResponseSize = 1;
                    break;
                case StmExternalCommandType.GET_ERROR_CODE:
                    Name = "Error Code";
                    ResponseSize = 1;
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

        public string InterpretResponseData(byte[] data)
        {
            string result = "";

            switch(Type)
            {
                case StmExternalCommandType.CONNECTION_TEST:
                    return data[0] switch
                    {
                        Constants.ConnectionTestSuccessResponse => "Success",
                        _ => "Error"
                    };
                case StmExternalCommandType.GET_LIFT_STATUS:
                    return data[0] switch
                    {
                        (byte)LiftStatus.LIFTED => "Lifted",
                        (byte)LiftStatus.SET_DOWN => "Set Down",
                        _ => "Invalid Data Received"
                    };
                case StmExternalCommandType.GET_HOME_STATUS:
                    return data[0] switch
                    {
                        (byte)HomeStatus.HOMED => "Homed",
                        (byte)HomeStatus.NOT_HOMED => "Not Homed",
                        _ => "Invalid Data Received"
                    };
                case StmExternalCommandType.GET_CURRENT_COMMAND:
                    return data[0] switch
                    {
                        (byte)ActionCommand.NO_ACTION => "Idle",
                        (byte)ActionCommand.PAUSE => "Pause",
                        (byte)ActionCommand.UNPAUSE => "Unpause",
                        (byte)ActionCommand.PLAY => "Play",
                        (byte)ActionCommand.HOME => "Home",
                        (byte)ActionCommand.CALIBRATION => "Calibration",
                        (byte)ActionCommand.TEST_MODE => "Test Mode",
                        (byte)ActionCommand.ERROR => "Error",
                        _ => "Invalid Data Received"
                    };
                case StmExternalCommandType.GET_VERTICAL_ENCODER_POS:
                    byte lsb = data[0];
                    byte msb = data[1];

                    UInt16 finalInt = (UInt16)(((UInt16)msb << 8) | (UInt16)lsb);

                    return finalInt.ToString();
                case StmExternalCommandType.GET_ERROR_CODE:
                    return data[0] switch
                    {
                        (byte)CommandError.NO_ERROR => "No error",
                        (byte)CommandError.LIFT_STALLED_MOVING_UP => "Lift error: Stalled moving up",
                        (byte)CommandError.LIFT_STALLED_MOVING_DOWN => "Lift error: Stalled moving down",
                        (byte)CommandError.NOT_LIFTED => "Lift error: Not lifted at the end of \"Pause\" routine",
                        _ => "Invalid Data Received"
                    };
            }

            return result;
        }
    }
}
