namespace StmTestingSuite.Model.StmEnum
{
    public enum SubCommandId : byte
    {
        NONE = 0,
        ERROR = 1,
        DISENGAGE_AZ_CLUTCH = 2,
        ENGAGE_AZ_CLUTCH = 3,
        MOVE_N_STEPS_HORIZONTALLY = 6,
        GO_TO_POSITION_H = 7,
        DELAY = 8,
        SET_MOVEMENT_VERTICAL = 9,
        CALIBRATE_7_IN = 10,
        CALIBRATE_10_IN = 11,
        CALIBRATE_12_IN = 12,
        CALIBRATE_HOME = 13,
        GO_TO_POSITION_V = 14,
        MOVE_N_STEPS_V = 15
    }
}
