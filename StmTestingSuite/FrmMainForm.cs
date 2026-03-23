using StmTestingSuite.Command;
using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Com;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.Key;
using System.IO.Ports;

namespace StmTestingSuite
{
    public partial class FrmMainForm : Form
    {
        private readonly StmConnector Conn;
        private readonly StmLogger Logger;
        private List<BaseStmCommand> Commands = [];

        public FrmMainForm()
        {
            InitializeComponent();

            Conn = new StmConnector();
            Logger = new StmLogger(DgvSimpleLog, this);
            RefreshSerialOptions();
            RegisterCommands();

            // Populate command group list items
            List<StmExternalCommandGroup> groupOptions = [];
            foreach (StmExternalCommandGroupType commandGroup in Enum.GetValues<StmExternalCommandGroupType>())
            {
                groupOptions.Add(new StmExternalCommandGroup(commandGroup));
            }
            CboSimpleCommandGroupOptions.DataSource = groupOptions;
            CboSimpleCommandGroupOptions.DisplayMember = "Name";

            GrpSimpleInput.Enabled = false;
        }

        private void CboSimpleCommandGroupOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            StmExternalCommandGroup? selectedGroup = (StmExternalCommandGroup?)CboSimpleCommandGroupOptions.SelectedValue;

            // Populate combo box commands based on group selection
            List<BaseStmCommand> commandOptions = [];
            foreach (BaseStmCommand command in Commands)
            {
                if (command.GroupType == selectedGroup?.Type)
                {
                    commandOptions.Add(command);
                }
            }
            CboSimpleCommandOptions.DataSource = commandOptions.OrderBy(x => x.Name).ToList();
            CboSimpleCommandOptions.DisplayMember = "Name";
        }

        private void CboSimpleCommandOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            BaseStmCommand? selectedCommand = (BaseStmCommand?)CboSimpleCommandOptions.SelectedValue;
            if (selectedCommand is null) return;

            TxtSimpleCommandInput.Visible = false;
            CboSimpleCommandInput.Visible = false;
            NumSimpleCommandInput.Visible = false;
            LblSimpleExtraData.Visible = false;

            if (selectedCommand.InputType != StmExternalCommandInputType.NONE)
            {
                LblSimpleExtraData.Text = ((BaseStmInputCommand)selectedCommand).FieldName + ":";
                LblSimpleExtraData.Visible = true;

                switch (selectedCommand.InputType)
                {
                    case StmExternalCommandInputType.NUMERIC_INT:
                        NumSimpleCommandInput.Value = 0;
                        NumSimpleCommandInput.DecimalPlaces = 0;
                        NumSimpleCommandInput.Visible = true;
                        break;
                    case StmExternalCommandInputType.NUMERIC_DEC:
                        NumSimpleCommandInput.Value = 0;
                        NumSimpleCommandInput.DecimalPlaces = 3;
                        NumSimpleCommandInput.Visible = true;
                        break;
                    case StmExternalCommandInputType.DROP_DOWN:
                        CboSimpleCommandInput.DataSource = ((BaseStmDropDownCommand)selectedCommand).Options;
                        CboSimpleCommandInput.DisplayMember = "Name";
                        CboSimpleCommandInput.SelectedIndex = 0;
                        CboSimpleCommandInput.Visible = true;
                        break;
                }
            }
        }

        private void BtnSimpleSendCommand_Click(object sender, EventArgs e)
        {
            BaseStmCommand? selectedCommand = (BaseStmCommand?)CboSimpleCommandOptions.SelectedValue;

            if (selectedCommand is not null)
            {
                ExecuteSimpleCommand(selectedCommand);
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            ToggleConnection();
        }

        private void BtnSimpleClearLog_Click(object sender, EventArgs e)
        {
            Logger.ClearLog();
        }

        private void BtnRefreshSerialPorts_Click(object sender, EventArgs e)
        {
            RefreshSerialOptions();
        }

        private void CboSimpleCommandInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            BaseStmDropDownCommand? command = (BaseStmDropDownCommand?)CboSimpleCommandOptions.SelectedValue;

            if (command is not null)
            {
                StmExternalCommandInputOption? option = (StmExternalCommandInputOption?)CboSimpleCommandInput.SelectedValue;

                if (option is not null)
                {
                    command.UpdateInputData((StmExternalCommandInputOption)option);
                }
            }
        }

        private void NumSimpleCommandInput_ValueChanged(object sender, EventArgs e)
        {
            BaseStmInputCommand? command = (BaseStmInputCommand?)CboSimpleCommandOptions.SelectedValue;

            if(command is not null)
            {
                decimal value = NumSimpleCommandInput.Value;

                if (command.InputType == StmExternalCommandInputType.NUMERIC_INT)
                {
                    command.UpdateInputData(Decimal.ToUInt16(value));
                } else
                {
                    command.UpdateInputData(Decimal.ToSingle(value));
                }
            }
        }

        /**
         * Beyond here lie helper methods.
         **/

        private void RegisterCommands()
        {
            Commands =
            [
                // other
                new CmdConnectionTest(Conn, Logger),

                // action
                new CmdPauseUnpause(Conn, Logger),

                // set
                new CmdSetClearActionCommand(Conn, Logger),
                new CmdSetCustomSpeed(Conn, Logger),
                new CmdSetSize(Conn, Logger),
                new CmdSetSpeed(Conn, Logger),

                // get
                new CmdGetCurrentCommand(Conn, Logger),
                new CmdGetErrorCode(Conn, Logger),
                new CmdGetHomeStatus(Conn, Logger),
                new CmdGetHorizontalEncoderPos(Conn, Logger),
                new CmdGetLiftStatus(Conn, Logger),
                new CmdGetUpTime(Conn, Logger),
                new CmdGetVerticalEncoderPos(Conn, Logger)
            ];
        }
        private void ToggleConnection()
        {
            // Disconnect
            if (Conn.Connected)
            {
                if (Conn.CloseCommunication())
                {
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
                    
                    if(Conn.OpenCommunication(comPort.ComName))
                    {
                        // Execute the CmdConnectionTest command when connecting to the COM port. If this is successful, then we know a Statimatic STM turntable
                        // is on the other end. If it fails, then either the connection is bad, or it's another random serial device.
                        Task commandTask = new(async () =>
                        {
                            bool successfulConnection = new CmdConnectionTest(Conn, null).ExecuteWithResult().Result == true;
                            string connectMessageTitle = "Connect to " + comPort.Name;

                            // Connection failed
                            if (!successfulConnection)
                            {
                                Logger.LogMessage(connectMessageTitle, "Connection failed");
                                MessageBox.Show(comPort + " is not a valid STM turntable, or the connection failed.", "Invalid COM Port", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Utilities.WriteToUiFromThread(this, () =>
                                {
                                    ToggleConnection();
                                });
                            }

                            // Connection succeeded
                            else
                            {
                                Logger.LogMessage(connectMessageTitle, "Connection successful");
                                Utilities.WriteToUiFromThread(this, () =>
                                {
                                    LblConnectionStatus.Text = "Connected";
                                    BtnConnect.Text = "Disconnect";
                                    GrpSimpleInput.Enabled = true;
                                    CboSerialOptions.Enabled = false;
                                    BtnRefreshSerialPorts.Enabled = false;
                                });
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


        private void ExecuteSimpleCommand(BaseStmCommand command)
        {
            BtnSimpleSendCommand.Enabled = false;

            Task commandTask = new(async () =>
            {
                try
                {
                    await command.Execute();

                    await Task.Delay(Constants.SendCommandDebounceMs);

                    Utilities.WriteToUiFromThread(this, () =>
                    {
                        BtnSimpleSendCommand.Enabled = true;
                        BtnSimpleSendCommand.Focus();
                    });

                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("The device has been disconnected", "Device Disconnected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Utilities.WriteToUiFromThread(this, () =>
                    {
                        ToggleConnection();
                        RefreshSerialOptions();
                    });
                }
            });

            commandTask.Start();
        }

        private void RefreshSerialOptions()
        {
            Conn.Key = ModelKey.INIT;

            Task initTask = new(async () =>
            {
                List<ComOption> comOptions = [];

                foreach (string port in SerialPort.GetPortNames())
                {
                    try
                    {
                        var success = Conn.OpenCommunication(port, false);

                        if(success)
                        {
                            var result = await new CmdInit(Conn).Execute();

                            if (result != null)
                            {
                                comOptions.Add(result);
                            } else
                            {
                                success = false;
                            }
                        }

                        // If the COM port didn't succeed, add it anyway, just so we can see it in the list.
                        if(!success)
                        {
                            comOptions.Add(new ComOption(port));
                        }
                    } finally
                    {
                        Conn.CloseCommunication();
                    }
                }

                Utilities.WriteToUiFromThread(this, () =>
                {
                    CboSerialOptions.DataSource = comOptions.OrderBy(x => x.Name).ToList();
                    CboSerialOptions.DisplayMember = "Name";
                });
            });

            initTask.Start();
        }
    }
}
