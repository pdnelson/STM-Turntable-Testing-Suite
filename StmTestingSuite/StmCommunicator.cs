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
                Port.Write(commandBytes, 0, 2);

                // If a response is expected, wait a little, and then read that response.
                if(command.ResponseSize > 0)
                {
                    await Task.Delay(100);

                    byte[] rawData = new byte[command.ResponseSize];
                    Port.Read(rawData, 0, command.ResponseSize);

                    responseString = command.InterpretResponseData(rawData);
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
            });
        }

        public void ClearLog()
        {
            Logger.Rows.Clear();
        }
    }
}
