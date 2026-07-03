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
                CommandStatus.CLUTCH_FAILED_TO_ENGAGE => "Azimuth clutch failed to engage",
                CommandStatus.CLUTCH_FAILED_TO_DISENGAGE => "Azimuth clutch failed to disengage",
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
                CommandId.MOVE_N_STEPS_H => "Move n Steps Horizontally",
                CommandId.HOME => "Home",
                CommandId.CALIBRATION => "Calibration",
                CommandId.TEST_MODE => "Test Mode",
                CommandId.ERROR => "Error",
                CommandId.TOGGLE_CLUTCH => "Toggle Clutch",
                CommandId.STEP_H_MOTOR => "Step Horizontal Motor",
                CommandId.GO_TO_POSITION => "Go To Position",
                _ => "Invalid Data Received"
            };
        }

        public static String GetString(this SubCommandId subCommandId)
        {
            return subCommandId switch
            {
                SubCommandId.NONE => "Idle",
                SubCommandId.DISENGAGE_AZ_CLUTCH => "Disengage Azimuth Clutch",
                SubCommandId.ENGAGE_AZ_CLUTCH => "Engage Azimuth Clutch",
                SubCommandId.LIFT_TONEARM => "Lift Tonearm",
                SubCommandId.SET_DOWN_TONEARM => "Set Down Tonearm",
                SubCommandId.MOVE_N_STEPS_HORIZONTALLY => "Move n Steps Horizontally",
                SubCommandId.ERROR => "Error",
                SubCommandId.GO_TO_POSITION => "Go To Position",
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
    }
}
