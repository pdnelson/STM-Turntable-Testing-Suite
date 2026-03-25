using StmTestingSuite.Command;
using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;

namespace StmTestingSuite
{
    public partial class FrmMainForm : Form
    {
        private readonly Semaphore CommSem;
        private readonly StmConnector Conn;
        private readonly StmLogger Logger;
        private readonly ConnectionMonitor ConnMonitor;
        private List<BaseStmCommand> Commands = [];

        public FrmMainForm()
        {
            InitializeComponent();
            CommSem = new Semaphore(0, 2);
            CommSem.Release();
            Conn = new StmConnector(CommSem);
            Logger = new StmLogger(DgvSimpleLog, this);
            ConnMonitor = new ConnectionMonitor(this, Conn, Logger, CboSerialOptions, LblConnectionStatus, BtnConnect, GrpSimpleInput, BtnRefreshSerialPorts, BtnSimpleSendCommand);
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
                new CmdSetRotateSize(Conn, Logger),
                new CmdSetRotateSpeed(Conn, Logger),

                // get
                new CmdGetCurrentCommand(Conn, Logger),
                new CmdGetErrorCode(Conn, Logger),
                new CmdGetHomeStatus(Conn, Logger),
                new CmdGetHorizontalEncoderPos(Conn, Logger),
                new CmdGetLiftStatus(Conn, Logger),
                new CmdGetSizeSetting(Conn, Logger),
                new CmdGetSpeedSetting(Conn, Logger),
                new CmdGetTargetSpeed(Conn, Logger),
                new CmdGetUpTime(Conn, Logger),
                new CmdGetVerticalEncoderPos(Conn, Logger)
            ];
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
                    ConnMonitor.DeviceDisconnected();
                }
            });

            commandTask.Start();
        }
    }
}
