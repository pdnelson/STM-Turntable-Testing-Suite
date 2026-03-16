using StmTestingSuite.Command;
using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using System.Diagnostics.Contracts;
using System.IO.Ports;

namespace StmTestingSuite
{
    public partial class FrmMainForm : Form
    {
        StmConnector Conn;
        List<BaseStmCommand> Commands;

        public FrmMainForm()
        {
            InitializeComponent();

            Conn = new StmConnector(dgvSimpleLog, this);
            RefreshSerialOptions();
            RegisterCommands();

            // Populate command group list items
            List<StmExternalCommandGroup> groupOptions = new List<StmExternalCommandGroup>();
            foreach (StmExternalCommandGroupType commandGroup in Enum.GetValues(typeof(StmExternalCommandGroupType)))
            {
                groupOptions.Add(new StmExternalCommandGroup(commandGroup));
            }
            cboSimpleCommandGroupOptions.DataSource = groupOptions;
            cboSimpleCommandGroupOptions.DisplayMember = "Name";
            cboSimpleCommandGroupOptions.DropDownStyle = ComboBoxStyle.DropDownList;

            cboSimpleCommandOptions.Enabled = false;

            cboSimpleCommandOptions.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSimpleCommandInput.DropDownStyle = ComboBoxStyle.DropDownList;
            btnSimpleSendCommand.Enabled = false;
        }

        private void cboSimpleCommandGroupOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            StmExternalCommandGroup? selectedGroup = (StmExternalCommandGroup?)cboSimpleCommandGroupOptions.SelectedValue;
            if (selectedGroup is null) return;

            if (selectedGroup.Type == StmExternalCommandGroupType.OTHER)
            {
                cboSimpleCommandOptions.Enabled = false;
            }
            else
            {
                cboSimpleCommandOptions.Enabled = true;
            }

            // Populate combo box commands based on group selection
            List<BaseStmCommand> commandOptions = new List<BaseStmCommand>();
            foreach (BaseStmCommand command in Commands)
            {
                if (command.GroupType == selectedGroup.Type)
                {
                    commandOptions.Add(command);
                }
            }
            cboSimpleCommandOptions.DataSource = commandOptions.OrderBy(x => x.Name).ToList();
            cboSimpleCommandOptions.DisplayMember = "Name";
        }

        private void cboSimpleCommandOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            BaseStmCommand? selectedCommand = (BaseStmCommand?)cboSimpleCommandOptions.SelectedValue;
            if (selectedCommand is null) return;

            txtSimpleCommandInput.Visible = false;
            cboSimpleCommandInput.Visible = false;
            numSimpleCommandInput.Visible = false;

            if (selectedCommand.InputType == StmExternalCommandInputType.NONE)
            {
                lblSimpleExtraData.Visible = false;
            }
            else
            {
                lblSimpleExtraData.Text = ((BaseStmInputCommand)selectedCommand).FieldName + ":";
                lblSimpleExtraData.Visible = true;

                switch (selectedCommand.InputType)
                {
                    case StmExternalCommandInputType.NUMERIC_INT:
                        numSimpleCommandInput.Value = 0;
                        numSimpleCommandInput.DecimalPlaces = 0;
                        numSimpleCommandInput.Visible = true;
                        break;
                    case StmExternalCommandInputType.NUMERIC_DEC:
                        numSimpleCommandInput.Value = 0;
                        numSimpleCommandInput.DecimalPlaces = 3;
                        numSimpleCommandInput.Visible = true;
                        break;
                    case StmExternalCommandInputType.DROP_DOWN:
                        cboSimpleCommandInput.DataSource = ((BaseStmDropDownCommand)selectedCommand).Options;
                        cboSimpleCommandInput.DisplayMember = "Name";
                        cboSimpleCommandInput.SelectedIndex = 0;
                        cboSimpleCommandInput.Visible = true;
                        break;
                }
            }
        }

        private void btnSimpleSendCommand_Click(object sender, EventArgs e)
        {
            BaseStmCommand? selectedCommand = (BaseStmCommand?)cboSimpleCommandOptions.SelectedValue;

            if (selectedCommand is not null)
            {
                ExecuteSimpleCommand(selectedCommand);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ToggleConnection();
        }

        private void btnSimpleClearLog_Click(object sender, EventArgs e)
        {
            Conn.ClearLog();
        }

        private void RefreshSerialOptions()
        {
            // Initialize COM ports
            cboSerialOptions.DataSource = SerialPort.GetPortNames().ToList();
            cboSerialOptions.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ToggleConnection()
        {
            if (Conn.Connected)
            {
                if (Conn.CloseCommunication())
                {
                    lblConnectionStatus.Text = "Not Connected";
                    btnConnect.Text = "Connect";
                    btnSimpleSendCommand.Enabled = false;
                    cboSerialOptions.Enabled = true;
                    BtnRefreshSerialPorts.Enabled = true;
                }
            }
            else
            {
                string? comPort = (string?)cboSerialOptions.SelectedValue;

                if (comPort is not null && Conn.OpenCommunication(comPort))
                {
                    lblConnectionStatus.Text = "Connected";
                    btnConnect.Text = "Disconnect";
                    btnSimpleSendCommand.Enabled = true;
                    cboSerialOptions.Enabled = false;
                    ExecuteSimpleCommand(Commands.First());
                    BtnRefreshSerialPorts.Enabled = false;
                }
                else if (comPort is null)
                {
                    MessageBox.Show("No COM ports are available. Is the turntable connected to the computer?", "No COM Ports", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    RefreshSerialOptions();
                }
            }
        }

        private void ExecuteSimpleCommand(BaseStmCommand command)
        {
            btnSimpleSendCommand.Enabled = false;

            Task commandTask = new Task(async () =>
            {
                try
                {
                    await command.Execute();

                    await Task.Delay(Constants.SendCommandDebounceMs);

                    Utilities.WriteToUiFromThread(this, () =>
                    {
                        btnSimpleSendCommand.Enabled = true;
                        btnSimpleSendCommand.Focus();
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

        private void BtnRefreshSerialPorts_Click(object sender, EventArgs e)
        {
            RefreshSerialOptions();
        }

        private void RegisterCommands()
        {
            Commands =
            [
                // other
                new CmdConnectionTest(Conn),

                // action
                new CmdPauseUnpause(Conn),

                // set
                new CmdSetClearActionCommand(Conn),
                new CmdSetCustomSpeed(Conn),
                new CmdSetSize(Conn),
                new CmdSetSpeed(Conn),

                // get
                new CmdGetCurrentCommand(Conn),
                new CmdGetErrorCode(Conn),
                new CmdGetHomeStatus(Conn),
                new CmdGetHorizontalEncoderPos(Conn),
                new CmdGetLiftStatus(Conn),
                new CmdGetUpTime(Conn),
                new CmdGetVerticalEncoderPos(Conn)
            ];
        }

        private void cboSimpleCommandInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            BaseStmDropDownCommand? command = (BaseStmDropDownCommand?)cboSimpleCommandOptions.SelectedValue;

            if (command is not null)
            {
                StmExternalCommandInputOption? option = (StmExternalCommandInputOption?)cboSimpleCommandInput.SelectedValue;

                if (option is not null)
                {
                    command.UpdateInputData((StmExternalCommandInputOption)option);
                }
            }
        }

        private void numSimpleCommandInput_ValueChanged(object sender, EventArgs e)
        {
            BaseStmInputCommand? command = (BaseStmInputCommand?)cboSimpleCommandOptions.SelectedValue;

            if(command is not null)
            {
                decimal value = numSimpleCommandInput.Value;

                if (command.InputType == StmExternalCommandInputType.NUMERIC_INT)
                {
                    command.UpdateInputData(Decimal.ToUInt16(value));
                } else
                {
                    command.UpdateInputData(Decimal.ToSingle(value));
                }
            }
        }
    }
}
