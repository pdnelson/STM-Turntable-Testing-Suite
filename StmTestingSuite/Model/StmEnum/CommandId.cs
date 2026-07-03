namespace StmTestingSuite.Model.StmEnum
{
    public enum CommandId : byte
    {
        NONE = 0,
        PAUSE = 1,
        UNPAUSE = 2,
        PLAY = 3,
        HOME = 4,
        CALIBRATION = 5,
        TEST_MODE = 6,
        ERROR = 7,
        TOGGLE_CLUTCH = 8,
        STEP_H_MOTOR = 9,
        GO_TO_POSITION = 10
    }
}
