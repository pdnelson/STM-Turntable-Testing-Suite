using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using System.Text;

namespace StmTestingSuite
{
    internal class StmLogger(DataGridView dgv, Form form)
    {
        DataGridView Dgv { get; } = dgv;
        Form Form { get; } = form;

        private string TimeStamp()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        public void LogCommand(BaseStmCommand command, string? responseData)
        {

            StringBuilder commandSent = new();

            if (command.GroupType != StmExternalCommandGroupType.OTHER && command.GroupType != StmExternalCommandGroupType.ACTION)
            {
                var actionType = new StmExternalCommandGroup(command.GroupType).Name[..3];

                commandSent.Append(actionType + " ");
            }

            commandSent.Append(command.Name);

            if (command is BaseStmInputCommand inputCommand)
            {
                commandSent.Append(": ");

                // If the field name contains a comma, don't write the field name at the end of the readable input data. 
                // In this scenario, the ReadableInputData will be formatted in a special, readable way.
                if(inputCommand.FieldName.Contains(','))
                {
                    commandSent.Append(inputCommand.ReadableInputData);
                } 
                else
                {
                    commandSent.Append(inputCommand.ReadableInputData + " " + inputCommand.FieldName);
                }
            }

            string response = "";

            if (responseData != null)
            {
                response = responseData;
            }
            else if (responseData == null && command.ResponseSize > 0)
            {
                response = "Error: The turntable did not respond in time";
            }

            Utilities.WriteToUiFromThread(Form, () =>
            {
                Dgv.Rows.Add(TimeStamp(), commandSent.ToString(), response);
                Dgv.FirstDisplayedScrollingRowIndex = Dgv.RowCount - 1;
            });
        }

        public void LogMessage(string title, string message)
        {
            Utilities.WriteToUiFromThread(Form, () =>
            {
                Dgv.Rows.Add(TimeStamp(), title, message);
                Dgv.FirstDisplayedScrollingRowIndex = Dgv.RowCount - 1;
            });
        }

        public void ClearLog()
        {
            Dgv.Rows.Clear();
        }
    }
}
