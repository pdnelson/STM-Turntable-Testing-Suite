using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using System.IO.Ports;
using System.Text;

namespace StmTestingSuite
{
    internal class StmConnector(DataGridView logger, Form form)
    {
        SerialPort? Port { get; set; }
        public bool Connected { get; private set; } = false;
        DataGridView Logger { get; } = logger;
        Form Form { get; } = form;

        public bool OpenCommunication(string port)
        {
            Port = new SerialPort(port, Constants.BaudRate);
            Port?.ReadTimeout = Constants.CommandTimeoutTimeMs;
            try
            {
                Port?.Open();
                Connected = true;
                return true;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Opening Connection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public bool CloseCommunication()
        {
            Connected = false;
            if (Port is not null)
            {
                try
                {
                    Port.Close();
                    Port = null;
                    return true;
                } catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error Closing Connection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            } else
            {
                return false;
            }
        }

        public async Task<byte[]?> SendCommand(byte[] data, ushort responseDataSize)
        {
            if (Port is null) return null;

            // Clear out the buffer before sending a command, just in case
            // some other junk from another command accidentally got left over.
            Port?.DiscardInBuffer();
            Port?.DiscardOutBuffer();

            await Task.Delay(Constants.CommandResponseTimeMs);

            Port?.Write(data, 0, data.Length);

            byte[]? response = null;

            // If a response is expected, wait a little, and then read that response.
            if (responseDataSize > 0)
            {
                await Task.Delay(Constants.CommandResponseTimeMs);

                response = new byte[responseDataSize];

                try
                {
                    Port?.Read(response, 0, response.Length);
                }
                catch (TimeoutException)
                {
                    response = null;
                }
            }

            return response;
        }

        public void LogCommand(BaseStmCommand command, string? responseData)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");

            StringBuilder commandSent = new();

            if(command.GroupType != StmExternalCommandGroupType.OTHER && command.GroupType != StmExternalCommandGroupType.ACTION)
            {
                var actionType = new StmExternalCommandGroup(command.GroupType).Name[..3];

                commandSent.Append(actionType + " ");
            }

            commandSent.Append(command.Name);

            if(command is BaseStmInputCommand inputCommand)
            {
                commandSent.Append(": ");
                commandSent.Append(inputCommand.ReadableInputData + " " + inputCommand.FieldName);
            }

            string response = "";

            if(responseData != null)
            {
                response = responseData;
            } else if(responseData == null && command.ResponseSize > 0)
            {
                response = "Response timed out";
            }

            Utilities.WriteToUiFromThread(Form, () =>
            {
                Logger.Rows.Add(timestamp, commandSent.ToString(), response);
                Logger.FirstDisplayedScrollingRowIndex = Logger.RowCount - 1;
            });
        }

        public void ClearLog()
        {
            Logger.Rows.Clear();
        }
    }
}
