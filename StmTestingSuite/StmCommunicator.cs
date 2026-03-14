using StmTestingSuite.Model.Command;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace StmTestingSuite
{
    internal class StmCommunicator
    {
        SerialPort? Port { get; set; }
        public bool IsOpen { get; private set; }

        public StmCommunicator()
        {
            IsOpen = false;
        }

        public bool OpenCommunication(string port)
        {
            Port = new SerialPort(port, Constants.BaudRate);
            try
            {
                Port.Open();
                IsOpen = true;
                return true;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Opening Connection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public bool CloseCommunication()
        {
            IsOpen = false;
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
            }
        }
    }
}
