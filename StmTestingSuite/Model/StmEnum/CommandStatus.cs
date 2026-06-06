namespace StmTestingSuite.Model.StmEnum
{
    enum CommandStatus : byte
    {
        RUNNING = 0,
        SUCCESS = 1,
        LIFT_STALLED_MOVING_UP = 2,
        LIFT_STALLED_MOVING_DOWN = 3,
        NOT_LIFTED = 4,
        CLUTCH_FAILED_TO_ENGAGE = 5,
        CLUTCH_FAILED_TO_DISENGAGE = 6
    }
}
