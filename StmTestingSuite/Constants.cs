using System;
using System.Collections.Generic;
using System.Text;

namespace StmTestingSuite
{
    internal class Constants
    {
        public const int BaudRate = 115200;
        public const byte CommandKey = 0b01101101;
        public const byte ConnectionTestSuccessResponse = 0b10010010;
        public const int CommandResponseTimeMs = 1;
        public const int CommandTimeoutTimeMs = 2;
        public const int SendCommandDebounceMs = 10;
    }
}
