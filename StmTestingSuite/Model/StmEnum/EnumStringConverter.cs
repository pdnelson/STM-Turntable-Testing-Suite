namespace StmTestingSuite.Model.StmEnum
{
    public static class EnumStringConverter
    {
        public static String GetString(this CommandStatus errorStatus)
        {
            return errorStatus switch
            {
                CommandStatus.NONE => "None",
                CommandStatus.SUCCESS => "Success",
                CommandStatus.LIFT_STALLED_MOVING_UP => "Lift error: Stalled moving up",
                CommandStatus.LIFT_STALLED_MOVING_DOWN => "Lift error: Stalled moving down",
                CommandStatus.NOT_LIFTED => "Lift error: Not lifted at the end of \"Pause\" routine",
                CommandStatus.CLUTCH_FAILED_TO_HOME => "Azimuth clutch failed to home",
                CommandStatus.FAILED_TO_SET_VERTICAL_POLARITY => "Failed to set vertical polarity",
                CommandStatus.FAILED_TO_SET_HORIZONTAL_POLARITY => "Failed to set horizontal polarity",
                CommandStatus.STALLED_MOVING_CLOCKWISE => "Stalled moving clockwise",
                CommandStatus.STALLED_MOVING_COUNTERCLOCKWISE => "Stalled moving counterclockwise",
                _ => "Invalid Data Received"
            };
        }

        public static String GetString(this CommandId commandId)
        {
            return commandId switch
            {
                CommandId.NONE => "Idle",
                CommandId.PAUSE => "Pause",
                CommandId.UNPAUSE => "Unpause",
                CommandId.MOVE_N_STEPS_H => "Move n Steps (Horizontal)",
                CommandId.HOME => "Home",
                CommandId.CALIBRATION => "Calibration",
                CommandId.TEST_MODE => "Test Mode",
                CommandId.ERROR => "Error",
                CommandId.TOGGLE_CLUTCH => "Toggle Clutch",
                CommandId.STEP_H_MOTOR => "Step Horizontal Motor",
                CommandId.GO_TO_POSITION_H => "Go To Position (Horizontal)",
                CommandId.GO_TO_POSITION_V => "Go To Position (Vertical)",
                CommandId.MOVE_N_STEPS_V => "Move n Steps (Vertical)",
                CommandId.HOME_CLUTCH => "Home Clutch",
                CommandId.SET_CLUTCH => "Set Clutch",
                _ => "Invalid Data Received"
            };
        }

        public static String GetString(this SubCommandId subCommandId)
        {
            return subCommandId switch
            {
                SubCommandId.NONE => "Idle",
                SubCommandId.SET_AZ_CLUTCH => "Set Azimuth Clutch",
                SubCommandId.MOVE_N_STEPS_HORIZONTALLY => "Move n Steps (Horizontal)",
                SubCommandId.ERROR => "Error",
                SubCommandId.GO_TO_POSITION_H => "Go To Position (Horizontal)",
                SubCommandId.DELAY => "Delay",
                SubCommandId.SET_MOVEMENT_VERTICAL => "Set Movement To Vertical",
                SubCommandId.CALIBRATE_7_IN => "Calibrate 7\" Size",
                SubCommandId.CALIBRATE_10_IN => "Calibrate 10\" Size",
                SubCommandId.CALIBRATE_12_IN => "Calibrate 12\" Size",
                SubCommandId.CALIBRATE_HOME => "Calibrate Home Position",
                SubCommandId.GO_TO_POSITION_V => "Go To Position (Vertical)",
                SubCommandId.MOVE_N_STEPS_V => "Move n Steps (Vertical)",
                SubCommandId.CALIBRATE_HORIZONTAL_POLARITY => "Calibrate Horizontal Polarity",
                SubCommandId.CALIBRATE_PLATTER_HEIGHT => "Calibrate Platter Height",
                SubCommandId.CALIBRATE_HOME_HEIGHT => "Calibrate Home Height",
                SubCommandId.CALIBRATE_VERTICAL_BOUNDS => "Calibrate Vertical Bounds",
                SubCommandId.NORMALIZE_AZ_ENCODER => "Normalize Azimuth Encoder",
                SubCommandId.SET_H_MOTOR_POLARITY => "Set Horizontal Motor Polarity",
                SubCommandId.SET_POLL_SPEED => "Set Horizontal Encoder Poll Speed",
                SubCommandId.MOVE_CLUTCH_TO_HOME => "Move clutch to home",
                SubCommandId.MOVE_CLUTCH_TO_LIMIT => "Move clutch to limit",
                SubCommandId.H_ERROR_CORRECT => "Error Correct Horizontal Position",
                _ => "Invalid Data Received"
            };
        }

        public static String GetString(this HomeStatus homeStatus)
        {
            return homeStatus switch
            {
                HomeStatus.HOMED => "Homed",
                HomeStatus.NOT_HOMED => "Not Homed",
                _ => "Invalid Data Received"
            };
        }

        public static String GetString(this LiftStatus liftStatus)
        {
            return liftStatus switch
            {
                LiftStatus.LIFTED => "Lifted",
                LiftStatus.SET_DOWN => "Set Down",
                _ => "Invalid Data Received"
            };
        }

        public static String GetString(this SizeOption sizeOption)
        {
            return sizeOption switch
            {
                SizeOption.IN_7 => "7\"",
                SizeOption.IN_10 => "10\"",
                SizeOption.IN_12 => "12\"",
                SizeOption.AUTO => "Automatic",
                _ => "Invalid Data Received"
            };
        }

        public static String GetString(this SpeedOption speedOption)
        {
            return speedOption switch
            {
                SpeedOption.RPM_33 => "33 RPM",
                SpeedOption.RPM_45 => "45 RPM",
                SpeedOption.RPM_78 => "78 RPM",
                SpeedOption.AUTO => "Automatic",
                SpeedOption.CUSTOM => "Custom",
                _ => "Invalid Data Received"
            };
        }

        public static String GetString(this ClutchStatus speedOption)
        {
            return speedOption switch
            {
                ClutchStatus.ENGAGED => "Engaged",
                ClutchStatus.DISENGAGED => "Disengaged",
                _ => "Invalid Data Received"
            };
        }

        public static String GetString(this EncoderPolarity polarity)
        {
            return polarity switch { 
                EncoderPolarity.NORMAL => "Normal",
                EncoderPolarity.REVERSED => "Reversed",
                _ => "Invalid Data Received"
            };
        }
    }
}
