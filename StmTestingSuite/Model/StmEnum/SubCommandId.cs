namespace StmTestingSuite.Model.StmEnum
{
    public enum SubCommandId : byte
    {
        NONE = 0,
        ERROR = 1,
        DISENGAGE_AZ_CLUTCH = 2,
        ENGAGE_AZ_CLUTCH = 3,
        LIFT_TONEARM = 4,
        SET_DOWN_TONEARM = 5,
        MOVE_N_STEPS_HORIZONTALLY = 6,
        GO_TO_POSITION = 7
    }
}
