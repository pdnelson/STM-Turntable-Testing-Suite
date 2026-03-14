using System;
using System.Collections.Generic;
using System.Text;

namespace StmTestingSuite.Model.Response
{
    enum ActionCommand : byte
    {
        NO_ACTION = 0,
        PAUSE = 1,
        UNPAUSE = 2,
        PLAY = 3,
        HOME = 4,
        CALIBRATION = 5,
        TEST_MODE = 6,
        ERROR = 7
    }
}
