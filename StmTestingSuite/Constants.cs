using System;
using System.Collections.Generic;
using System.Text;

namespace StmTestingSuite
{
    internal class Constants
    {
        public static int BaudRate = 115200;
        public static byte CommandKey = 0b01101101;
        public static int CommandResponseTimeMs = 1;
        public static int CommandTimeoutTimeMs = 2;
        public static int SendCommandDebounceMs = 10;
    }
}
