using StmTestingSuite.Model.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace StmTestingSuite.Model.Response
{
    abstract class BaseCommandResponse
    {
        public StmExternalCommandType Type { get; }

        public BaseCommandResponse(StmExternalCommandType type)
        {
            Type = type;
        }
    }
}
