using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Input;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace StmTestingSuite
{
    internal class StmCommunicator
    {
        SerialPort? Port { get; set; }
        public bool Connected { get; private set; }
        DataGridView Logger { get; }

        public StmCommunicator(DataGridView logger)
        {
            Logger = logger;
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

        /**
         * Sends a command, taking no arguments.
         */
        public void sendCommand(StmExternalCommand command)
        {
            var commandBytes = new byte[] { Constants.CommandKey, (byte)command.Type };

            if(Port is not null)
            {
                Port.Write(commandBytes, 0, 2);
                logCommand(command, null, "");
            }
        }

        private void logCommand(StmExternalCommand command, StmExternalCommandInputOption? option, string responseData)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");

            StringBuilder commandSent = new StringBuilder(command.Name);

            if(option is not null)
            {
                commandSent.Append(": ");
                commandSent.Append(option.Value.Name);
            }

            Logger.Rows.Add(timestamp, commandSent.ToString(), responseData);
        }

        public void clearLog()
        {
            Logger.Rows.Clear();
        }
    }
}
