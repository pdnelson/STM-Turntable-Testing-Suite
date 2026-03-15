using System;
using System.Collections.Generic;
using System.Text;

namespace StmTestingSuite.Model.Response
{
    enum CommandError : byte
    {
        NO_ERROR = 0,
        LIFT_STALLED_MOVING_UP = 1,
        LIFT_STALLED_MOVING_DOWN = 2,
        NOT_LIFTED = 3
    }
}
