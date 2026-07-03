namespace StmTestingSuite.Model.StmEnum
{
    enum ExternalCommand : byte
    {
        CONNECTION_TEST = 0,

        // Actions
        ACTION_PAUSE_UNPAUSE = 1,
        ACTION_PROTO_PLAY = 2,
        ACTION_TOGGLE_CLUTCH = 3,
        ACTION_STEP_HORIZONTALLY = 4,
        ACTION_GO_TO_POSITION_H = 5,
        ACTION_PLAY_RETURN = 6,

        // Set commands
        SET_SPEED = 31,
        SET_SIZE = 32,
        SET_CUSTOM_SPEED = 33,
        SET_ROTATE_SPEED = 34,
        SET_CLEAR_ACTION_COMMAND = 35,
        SET_ROTATE_SIZE = 36,

        // Get commands
        GET_VERTICAL_ENCODER_POS = 100,
        GET_HORIZONTAL_ENCODER_POS = 101,
        GET_LIFT_STATUS = 102,
        GET_HOME_STATUS = 103,
        GET_CURRENT_COMMAND = 104,
        GET_COMMAND_STATUS = 105,
        GET_UP_TIME = 106,
        GET_SPEED_SETTING = 107,
        GET_SPEED_TARGET = 108,
        GET_SIZE_SETTING = 109,
        GET_CURRENT_SUB_COMMAND = 110,
        GET_ADVANCED_SUITE_DATA = 111
    }
}
