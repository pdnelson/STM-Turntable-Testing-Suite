using StmTestingSuite.Model.Key;
using System.IO.Ports;

namespace StmTestingSuite
{
    internal class StmConnector
    {
        SerialPort? Port { get; set; }
        public bool Connected { get; private set; } = false;

        public ModelKey Key { get; set; } = ModelKey.INIT;

        public string PortName { get; private set; } = "";

        Semaphore Sem { get; }

        public StmConnector()
        {
            Sem = new Semaphore(0, 2);
            Sem.Release();
        }

        public bool OpenCommunication(string port, bool alertWhenFailed = true)
        {
            Port = new SerialPort(port, Constants.BaudRate);
            Port?.ReadTimeout = Constants.CommandTimeoutTimeMs;
            try
            {
                Port?.Open();
                Connected = true;
                PortName = port;
                return true;
            } 
            catch (FileNotFoundException)
            {
                PortName = "";
                if(alertWhenFailed) MessageBox.Show(port + " does not appear to be connected.", "Error Opening Connection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            catch (Exception ex)
            {
                PortName = "";
                if (alertWhenFailed) MessageBox.Show(ex.ToString(), "Error Opening Connection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    Port.Dispose();
                    PortName = "";
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
            Sem.WaitOne();

            if (Port is null) return null;

            // build key + data
            byte[] dataToSend = new byte[data.Length + 1];

            dataToSend[0] = (byte)Key;

            for (int i = 1; i < dataToSend.Length; i++)
            {
                dataToSend[i] = data[i - 1];
            }

            // Clear out the buffer before sending a command, just in case
            // some other junk from another command accidentally got left over.
            try
            {
                Port?.DiscardInBuffer();
                Port?.DiscardOutBuffer();
            } catch(Exception)
            {
                Sem.Release();
                return null;
            }

            await Task.Delay(Constants.CommandResponseTimeMs);

            try
            {
                Port?.Write(dataToSend, 0, dataToSend.Length);
            } catch(Exception)
            {
                Sem.Release();
                return null;
            }

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
                catch (Exception)
                {
                    response = null;
                }
            }

            // Hold off for a bit more so another command can't be executed immediately after the port is read.
            await Task.Delay(Constants.CommandResponseTimeMs);

            Sem.Release();

            return response;
        }
    }
}
