using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Input;
using System.IO.Ports;
using System.Text;

namespace StmTestingSuite
{
    internal class StmCommunicator
    {
        SerialPort? Port { get; set; }
        public bool Connected { get; private set; }
        DataGridView Logger { get; }

        Form Form { get; }

        public StmCommunicator(DataGridView logger, Form form)
        {
            Logger = logger;
            Form = form;
            Connected = false;
        }

        public bool OpenCommunication(string port)
        {
            Port = new SerialPort(port, Constants.BaudRate);
            Port.ReadTimeout = Constants.CommandTimeoutTimeMs;
            try
            {
                Port.Open();
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

        public async Task<string> SendCommand(StmExternalCommand command)
        {
            var commandBytes = new byte[] { Constants.CommandKey, (byte)command.Type };

            if (Port is not null)
            {
                string responseString = "";

                // Clear out the buffer before sending a command, just in case
                // some other junk from another command accidentally got left over.
                Port.DiscardInBuffer();
                Port.DiscardOutBuffer();

                await Task.Delay(Constants.CommandResponseTimeMs);

                Port.Write(commandBytes, 0, 2);

                // If a response is expected, wait a little, and then read that response.
                if(command.ResponseSize > 0)
                {
                    await Task.Delay(Constants.CommandResponseTimeMs);

                    byte[] rawData = new byte[command.ResponseSize];

                    try
                    {
                        Port?.Read(rawData, 0, rawData.Length);
                        responseString = command.InterpretResponseData(rawData);
                    }
                    catch (TimeoutException)
                    {
                        responseString = "Response timed out";
                    }

                }

                LogCommand(command, null, responseString);

                return responseString;
            } else
            {
                return "";
            }
        }


        private void LogCommand(StmExternalCommand command, StmExternalCommandInputOption? option, string responseData)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");

            StringBuilder commandSent = new StringBuilder(command.Name);

            if(option is not null)
            {
                commandSent.Append(": ");
                commandSent.Append(option.Value.Name);
            }

            Utilities.WriteToUiFromThread(Form, () =>
            {
                Logger.Rows.Add(timestamp, commandSent.ToString(), responseData);
                Logger.FirstDisplayedScrollingRowIndex = Logger.RowCount - 1;
            });
        }

        public void ClearLog()
        {
            Logger.Rows.Clear();
        }
    }
}
