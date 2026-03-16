using StmTestingSuite.Model.Command.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace StmTestingSuite.Command.Base
{
    abstract class BaseStmDropDownCommand(StmConnector conn) : BaseStmInputCommand(conn)
    {
        public override StmExternalCommandInputType InputType => StmExternalCommandInputType.DROP_DOWN;

        public abstract List<StmExternalCommandInputOption> Options { get; }

        public void UpdateInputData(StmExternalCommandInputOption option)
        {
            UpdateInputData(option.Name, [option.Value]);
        }

        public void UpdateInputData(byte data)
        {
            string dataName = Options.Find(x => x.Value == data).Name;

            UpdateInputData("", [data]);
        }
    }
}
