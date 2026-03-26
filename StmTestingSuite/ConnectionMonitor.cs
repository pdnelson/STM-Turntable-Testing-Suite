using StmTestingSuite.Command;
using StmTestingSuite.Model.Com;
using StmTestingSuite.Model.Key;
using System.IO.Ports;

namespace StmTestingSuite
{
    internal class ConnectionMonitor(
        Form mainForm,
        StmConnector conn, 
        StmLogger logger, 
        ComboBox serialOptions, 
        Label lblConnectionStatus,
        Button btnConnect,
        GroupBox grpSimpleInput,
        Button btnRefreshSerial,
        Button btnSimpleSendCommand
        )
    {
        Form Form { get; } = mainForm;
        StmConnector Conn { get; } = conn;
        StmLogger Logger { get; } = logger;
        ComboBox CboSerialOptions { get; } = serialOptions;
        Label LblConnectionStatus { get; } = lblConnectionStatus;
        Button BtnConnect { get; } = btnConnect;
        GroupBox GrpSimpleInput { get; } = grpSimpleInput;
        Button BtnRefreshSerialPorts { get; } = btnRefreshSerial;
        Button BtnSimpleSendCommand { get; } = btnSimpleSendCommand;

        Task? MonitorTask { get; set; }

        private bool Monitoring { get; set; } = true;

        public void ToggleConnection(bool explicitDisconnect = true)
        {
            // Disconnect
            if (Conn.Connected)
            {
                if (Conn.CloseCommunication())
                {
                    CancelMonitor();
                    ComOption? comPort = (ComOption?)CboSerialOptions.SelectedValue;
                    if (explicitDisconnect && comPort != null)
                    {
                        Logger.LogMessage("Disconnect from " + comPort.Name, "Disconnection successful");
                    }

                    LblConnectionStatus.Text = "Not Connected";
                    BtnConnect.Text = "Connect";
                    GrpSimpleInput.Enabled = false;
                    CboSerialOptions.Enabled = true;
                    BtnRefreshSerialPorts.Enabled = true;
                    Conn.Key = ModelKey.INIT;
                }
            }

            // Connect
            else
            {
                ComOption? comPort = (ComOption?)CboSerialOptions.SelectedValue;

                if (comPort is not null)
                {
                    Conn.Key = comPort.Key;

                    if (Conn.OpenCommunication(comPort.ComName))
                    {
                        // Execute the CmdConnectionTest command when connecting to the COM port. If this is successful, then we know a Statimatic STM turntable
                        // is on the other end. If it fails, then either the connection is bad, or it's another random serial device.
                        Task commandTask = new(async () =>
                        {
                            bool successfulConnection = await new CmdConnectionTest(Conn, null).ExecuteWithResult() == true;
                            string connectMessageTitle = "Connect to " + comPort.Name;

                            // Connection failed
                            if (!successfulConnection)
                            {
                                Logger.LogMessage(connectMessageTitle, "Connection failed");
                                MessageBox.Show("Connection to " + comPort.Name + " failed.", "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Utilities.WriteToUiFromThread(Form, () =>
                                {
                                    ToggleConnection(false);
                                });
                            }

                            // Connection succeeded
                            else
                            {
                                Logger.LogMessage(connectMessageTitle, "Connection successful");
                                Utilities.WriteToUiFromThread(Form, () =>
                                {
                                    LblConnectionStatus.Text = "Connected";
                                    BtnConnect.Text = "Disconnect";
                                    GrpSimpleInput.Enabled = true;
                                    CboSerialOptions.Enabled = false;
                                    BtnRefreshSerialPorts.Enabled = false;
                                    BtnSimpleSendCommand.Enabled = true;
                                });


                                MonitorTask?.Dispose();
                                Monitoring = true;
                                var failedResultCount = 0;

                                MonitorTask = new(async () =>
                                {

                                    // Check that the connection is still active every second
                                    while(Monitoring)
                                    {
                                        var result = false;

                                        try
                                        {
                                            result = await new CmdConnectionTest(Conn, null).ExecuteWithResult() == true;
                                        } catch (Exception) {  /* do nothing */ }

                                        if (!result)
                                        {
                                            // After 3 consecutive failures, we will presume the device disconnected.
                                            if(failedResultCount <= 2)
                                            {
                                                failedResultCount++;
                                            } else
                                            {
                                                DeviceDisconnected();
                                            }
                                        } else
                                        {
                                            failedResultCount = 0;
                                        }

                                        await Task.Delay(300);
                                    }
                                });

                                MonitorTask.Start();
                            }
                        });

                        commandTask.Start();
                    }
                }
                else if (comPort is null)
                {
                    MessageBox.Show("No COM ports are available. Is the turntable connected to the computer?", "No COM Ports", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    RefreshSerialOptions();
                }
                else
                {
                    RefreshSerialOptions();
                }
            }
        }

        public void RefreshSerialOptions()
        {
            Conn.Key = ModelKey.INIT;

            Task initTask = new(async () =>
            {
                List<ComOption> comOptions = [];

                foreach (string port in SerialPort.GetPortNames().Distinct())
                {
                    try
                    {
                        var success = Conn.OpenCommunication(port, false);

                        if (success)
                        {
                            var result = await new CmdInit(Conn).Execute();

                            if (result != null)
                            {
                                comOptions.Add(result);
                            }
                            else
                            {
                                success = false;
                            }
                        }
                    }
                    finally
                    {
                        Conn.CloseCommunication();
                    }
                }

                Utilities.WriteToUiFromThread(Form, () =>
                {
                    CboSerialOptions.DataSource = comOptions.OrderBy(x => x.Name).ToList();
                    CboSerialOptions.DisplayMember = "Name";
                });
            });

            initTask.Start();
        }

        public void DeviceDisconnected()
        {
            Monitoring = false;
            Utilities.WriteToUiFromThread(Form, () =>
            {
                ToggleConnection();
                RefreshSerialOptions();
            });
        }

        public void CancelMonitor()
        {
            Monitoring = false;
        }
    }
}
