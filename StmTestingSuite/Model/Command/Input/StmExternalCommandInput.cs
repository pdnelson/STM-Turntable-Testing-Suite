using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StmTestingSuite.Model.Command.Input
{
    internal class StmExternalCommandInput
    {
        public StmExternalCommandInputType Type { get; }
        public string Name { get; }
        public List<StmExternalCommandInputOption> Options { get; }

        public StmExternalCommandInput(StmExternalCommandInputType type, string name, List<StmExternalCommandInputOption> options)
        {
            Type = type;
            Name = name;
            Options = options;
        }

        public StmExternalCommandInput(StmExternalCommandInputType type, string inputName)
        {
            Type = type;
            Name = inputName;
            Options = new List<StmExternalCommandInputOption>();
        }

        public StmExternalCommandInput(StmExternalCommandInputType type)
        {
            Type = type;
            Name = "";
            Options = new List<StmExternalCommandInputOption>();
        }
    }
}
