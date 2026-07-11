using StmTestingSuite.Command;
using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite
{
    public partial class FrmMainForm : Form
    {
        private readonly StmConnector Conn;
        private readonly StmLogger Logger;
        private readonly ConnectionMonitor ConnMonitor;
        private readonly AdvancedTabMonitor AdvTabMonitor;
        private List<BaseStmCommand> Commands = [];

        public FrmMainForm()
        {
            InitializeComponent();
            Conn = new StmConnector();
            Logger = new StmLogger(DgvSimpleLog, this);
            AdvTabMonitor = new AdvancedTabMonitor(this, Conn, BtnPlay, BtnPause, RadSize7In, RadSize10In, RadSize12In, RadSizeAuto, LblSpeedSettingData, LblTargetSpeedData, LblActualSpeedData, LblVerticalPositionData, LblHorizontalPositionData, LblLiftStatusData, LblHomeStatusData, LblClutchData, LblCurrCommandData, LblCurrSubCommandData, LblCurrCommandStatusData, LblUpTimeData);
            ConnMonitor = new ConnectionMonitor(this, Conn, Logger, TabMain, CboSerialOptions, LblConnectionStatus, BtnConnect, GrpSimpleInput, BtnRefreshSerialPorts, BtnSimpleSendCommand);
            ConnMonitor.RefreshSerialOptions();
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
            BtnSimpleSendCommand.Enabled = true;

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
                    case StmExternalCommandInputType.CUSTOM:
                        TxtSimpleCommandInput.Text = "";
                        TxtSimpleCommandInput.Visible = true;
                        BtnSimpleSendCommand.Enabled = false;
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
            ConnMonitor.ToggleConnection();
        }

        private void BtnSimpleClearLog_Click(object sender, EventArgs e)
        {
            Logger.ClearLog();
        }

        private void BtnRefreshSerialPorts_Click(object sender, EventArgs e)
        {
            ConnMonitor.RefreshSerialOptions();
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

            if (command is not null)
            {
                decimal value = NumSimpleCommandInput.Value;

                if (command.InputType == StmExternalCommandInputType.NUMERIC_INT)
                {
                    command.UpdateInputData(Decimal.ToUInt16(value));
                }
                else
                {
                    command.UpdateInputData(Decimal.ToSingle(value));
                }
            }
        }

        private void TxtSimpleCommandInput_TextChanged(object sender, EventArgs e)
        {
            BaseStmInputCommand? command = (BaseStmInputCommand?)CboSimpleCommandOptions.SelectedValue;

            if (command is not null)
            {
                string error = command.UpdateInputData(TxtSimpleCommandInput.Text);

                if (error.Length == 0)
                {
                    BtnSimpleSendCommand.Enabled = true;
                }
                else
                {
                    BtnSimpleSendCommand.Enabled = false;
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
                new CmdActionGoToPositionH(Conn, Logger),
                new CmdPauseUnpause(Conn, Logger),
                new CmdProtoPlay(Conn, Logger),
                new CmdStepHorizontally(Conn, Logger),
                new CmdToggleClutch(Conn, Logger),

                // set
                new CmdSetClearActionCommand(Conn, Logger),
                new CmdSetCustomSpeed(Conn, Logger),
                new CmdSetSize(Conn, Logger),
                new CmdSetSpeed(Conn, Logger),
                new CmdSetRotateSize(Conn, Logger),
                new CmdSetRotateSpeed(Conn, Logger),

                // get
                new CmdGetCurrentCommand(Conn, Logger),
                new CmdGetCurrentSubCommand(Conn, Logger),
                new CmdGetCommandStatus(Conn, Logger),
                new CmdGetHomeStatus(Conn, Logger),
                new CmdGetHorizontalEncoderPos(Conn, Logger),
                new CmdGetLiftStatus(Conn, Logger),
                new CmdGetSizeSetting(Conn, Logger),
                new CmdGetSpeedSetting(Conn, Logger),
                new CmdGetTargetSpeed(Conn, Logger),
                new CmdGetUpTime(Conn, Logger),
                new CmdGetVerticalEncoderPos(Conn, Logger),
                new CmdGetAdvancedSuiteData(Conn, Logger)
            ];
        }

        private void ExecuteSimpleCommand(BaseStmCommand command)
        {
            BtnCancelCommand.Enabled = false;
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
                        BtnCancelCommand.Enabled = true;
                        BtnSimpleSendCommand.Focus();
                    });

                }
                catch (InvalidOperationException)
                {
                    ConnMonitor.DeviceDisconnected();
                }
            });

            commandTask.Start();
        }

        private void BtnCancelCommand_Click_1(object sender, EventArgs e)
        {
            ExecuteSimpleCommand(new CmdSetClearActionCommand(Conn, Logger));
        }

        private void TabMain_Selecting(object sender, TabControlCancelEventArgs e)
        {
            TabPage? current = ((TabControl)sender).SelectedTab;

            // Don't let the user change tabs if the turntable isn't connected
            if (current != null)
            {
                if (current.Text != "Simple" && !Conn.Connected)
                {
                    e.Cancel = true;
                    MessageBox.Show("Must connnect to a turntable before changing tabs.", "Cannot Change Tabs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (current.Text == "Advanced")
                {
                    AdvTabMonitor.Start();
                    Logger.LogMessage("Advanced Tab", "Started monitoring");
                }
                else if (current.Text != "Advanced")
                {
                    AdvTabMonitor.Stop();
                    Logger.LogMessage("Advanced Tab", "Ended monitoring");
                }
            }
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            ExecuteSimpleCommand(new CmdPlayOrReturn(Conn, Logger));
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            ExecuteSimpleCommand(new CmdPauseUnpause(Conn, Logger));
        }

        private void BtnRotateSpeed_Click(object sender, EventArgs e)
        {
            ExecuteSimpleCommand(new CmdSetRotateSpeed(Conn, Logger));
        }

        private void btnRotateSize_Click(object sender, EventArgs e)
        {
            ExecuteSimpleCommand(new CmdSetRotateSize(Conn, Logger));
        }

        private void RadSize7In_Click(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                var command = new CmdSetSize(Conn, Logger);
                command.UpdateInputData((byte)SizeOption.IN_7);

                ExecuteSimpleCommand(command);
            }
        }

        private void RadSize10In_Click(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                var command = new CmdSetSize(Conn, Logger);
                command.UpdateInputData((byte)SizeOption.IN_10);

                ExecuteSimpleCommand(command);
            }
        }

        private void RadSize12In_Click(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                var command = new CmdSetSize(Conn, Logger);
                command.UpdateInputData((byte)SizeOption.IN_12);

                ExecuteSimpleCommand(command);
            }
        }

        private void RadSizeAuto_Click(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                var command = new CmdSetSize(Conn, Logger);
                command.UpdateInputData((byte)SizeOption.AUTO);

                ExecuteSimpleCommand(command);
            }
        }

        private void BtnSubmitSpeed_Click(object sender, EventArgs e)
        {
            var command = new CmdSetCustomSpeed(Conn, Logger);
            decimal value = NumSpeed.Value;
            command.UpdateInputData(Decimal.ToSingle(value));

            ExecuteSimpleCommand(command);
        }

        private void BtnToggleClutch_Click(object sender, EventArgs e)
        {
            ExecuteSimpleCommand(new CmdToggleClutch(Conn, Logger));
        }

        private void BtnStepClockwise_Click(object sender, EventArgs e)
        {
            var command = new CmdStepHorizontally(Conn, Logger);
            command.UpdateInputData("1,14");

            ExecuteSimpleCommand(command);
        }

        private void BtnStepCounterClockwise_Click(object sender, EventArgs e)
        {
            var command = new CmdStepHorizontally(Conn, Logger);
            command.UpdateInputData("-1,14");

            ExecuteSimpleCommand(command);
        }

        private void TrkAdvMovementSpeed_Scroll(object sender, EventArgs e)
        {
            TrackBar trackBar = (TrackBar)sender;
            LblAdvSpeedData.Text = trackBar.Value.ToString();
        }

        private void BtnMoveNStepsSend_Click(object sender, EventArgs e)
        {
            var speed = TrkAdvMovementSpeed.Value;
            var steps = (int)NumMoveNStepsInput.Value;

            if (steps != 0)
            {
                var command = new CmdProtoPlay(Conn, Logger);
                command.UpdateInputData($"{steps},{speed}");

                ExecuteSimpleCommand(command);
            }
        }

        private void BtnMoveToPositionSend_Click(object sender, EventArgs e)
        {
            var speed = TrkAdvMovementSpeed.Value;
            var tolerance = NumAdvancedMTPTolerance.Value;
            var position = NumMoveNStepsInput.Value;
            var command = new CmdActionGoToPositionH(Conn, Logger);
            command.UpdateInputData($"{position},{tolerance},{speed}");

            ExecuteSimpleCommand(command);
        }
    }
}
