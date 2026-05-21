using System;
using System.Collections.Generic;
using System.Text;

namespace StmTestingSuite
{
    internal class Validator
    {
        public static bool validInt(string s)
        {
            return int.TryParse(s, out _);
        }
    }
}
