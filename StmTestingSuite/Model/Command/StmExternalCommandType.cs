namespace StmTestingSuite.Model.Command
{
    enum StmExternalCommandType : byte
    {
        CONNECTION_TEST = 0,

        // Actions
        ACTION_PAUSE_UNPAUSE = 1,

        // Set commands
        SET_SPEED = 31,
        SET_SIZE = 32,
        SET_CUSTOM_SPEED = 33,
        SET_CLEAR_ACTION_COMMAND = 35,

        // Get commands
        GET_VERTICAL_ENCODER_POS = 100,
        GET_HORIZONTAL_ENCODER_POS = 101,
        GET_LIFT_STATUS = 102,
        GET_HOME_STATUS = 103,
        GET_CURRENT_COMMAND = 104,
        GET_ERROR_CODE = 105
    }
}
