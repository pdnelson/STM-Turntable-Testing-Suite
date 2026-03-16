using System;
using System.Collections.Generic;
using System.Text;

namespace StmTestingSuite.Model.Command
{
    internal class StmCommandResult<T>(T? result, string resultString) : IStmCommandResult
    {
        public T? Result { get; set; } = result;

        public string ResultString { get; set; } = resultString;
    }
}
