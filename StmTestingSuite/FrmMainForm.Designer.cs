namespace StmTestingSuite
{
    partial class FrmMainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainForm));
            TabMain = new TabControl();
            TabSimple = new TabPage();
            BtnSimpleClearLog = new Button();
            DgvSimpleLog = new DataGridView();
            cmnSimpleTime = new DataGridViewTextBoxColumn();
            cmnSimpleSent = new DataGridViewTextBoxColumn();
            cmnSimpleReceived = new DataGridViewTextBoxColumn();
            GrpSimpleInput = new GroupBox();
            BtnCancelCommand = new Button();
            CboSimpleCommandOptions = new ComboBox();
            BtnSimpleSendCommand = new Button();
            LblSimpleExtraData = new Label();
            CboSimpleCommandGroupOptions = new ComboBox();
            LblSimpleCommand = new Label();
            TxtSimpleCommandInput = new TextBox();
            CboSimpleCommandInput = new ComboBox();
            NumSimpleCommandInput = new NumericUpDown();
            tabAdvanced = new TabPage();
            GrpAdvancedMovement = new GroupBox();
            LblMoveToPosition = new Label();
            LblMoveNSteps = new Label();
            BtnMoveToPositionSend = new Button();
            BtnMoveNStepsSend = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            LblAdvSpeedData = new Label();
            LblAdvSpeed = new Label();
            TrkAdvMovementSpeed = new TrackBar();
            GrpManualMovement = new GroupBox();
            BtnStepCounterClockwise = new Button();
            BtnStepClockwise = new Button();
            BtnToggleClutch = new Button();
            GrpCurrentCommand = new GroupBox();
            LblCurrCommandStatusData = new Label();
            LblCurrSubCommandData = new Label();
            LblCurrCommandData = new Label();
            LblCommandStatus = new Label();
            LblSubCommand = new Label();
            LblCurrCommand = new Label();
            GrpPosition = new GroupBox();
            LblHomeStatusData = new Label();
            LblLiftStatusData = new Label();
            LblHorizontalPositionData = new Label();
            LblVerticalPositionData = new Label();
            LblHomeStatus = new Label();
            LblLiftStatus = new Label();
            LblHorizontalPosition = new Label();
            LblVerticalPosition = new Label();
            GrpStatistics = new GroupBox();
            LblUpTimeData = new Label();
            LblUpTime = new Label();
            GrpSimpleCommands = new GroupBox();
            BtnRotateSpeed = new Button();
            btnRotateSize = new Button();
            BtnPause = new Button();
            BtnPlay = new Button();
            GrpSizeGroup = new GroupBox();
            RadSizeAuto = new RadioButton();
            RadSize12In = new RadioButton();
            RadSize10In = new RadioButton();
            RadSize7In = new RadioButton();
            GrpSpeedGroup = new GroupBox();
            LblActualSpeedData = new Label();
            LblTargetSpeedData = new Label();
            LblSpeedSettingData = new Label();
            BtnSubmitSpeed = new Button();
            LblNewSpeed = new Label();
            LblActualSpeed = new Label();
            LblTargetSpeed = new Label();
            LblSpeedSetting = new Label();
            tabGraphical = new TabPage();
            LblTodo2 = new Label();
            CboSerialOptions = new ComboBox();
            LblSerialOptions = new Label();
            LblConnectionStatus = new Label();
            BtnConnect = new Button();
            BtnRefreshSerialPorts = new Button();
            NumSpeed = new NumericUpDown();
            TabMain.SuspendLayout();
            TabSimple.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvSimpleLog).BeginInit();
            GrpSimpleInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumSimpleCommandInput).BeginInit();
            tabAdvanced.SuspendLayout();
            GrpAdvancedMovement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrkAdvMovementSpeed).BeginInit();
            GrpManualMovement.SuspendLayout();
            GrpCurrentCommand.SuspendLayout();
            GrpPosition.SuspendLayout();
            GrpStatistics.SuspendLayout();
            GrpSimpleCommands.SuspendLayout();
            GrpSizeGroup.SuspendLayout();
            GrpSpeedGroup.SuspendLayout();
            tabGraphical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumSpeed).BeginInit();
            SuspendLayout();
            // 
            // TabMain
            // 
            TabMain.Controls.Add(TabSimple);
            TabMain.Controls.Add(tabAdvanced);
            TabMain.Controls.Add(tabGraphical);
            TabMain.Location = new Point(12, 35);
            TabMain.Name = "TabMain";
            TabMain.SelectedIndex = 0;
            TabMain.Size = new Size(769, 497);
            TabMain.TabIndex = 4;
            TabMain.Selecting += TabMain_Selecting;
            // 
            // TabSimple
            // 
            TabSimple.Controls.Add(BtnSimpleClearLog);
            TabSimple.Controls.Add(DgvSimpleLog);
            TabSimple.Controls.Add(GrpSimpleInput);
            TabSimple.Location = new Point(4, 24);
            TabSimple.Name = "TabSimple";
            TabSimple.Padding = new Padding(3);
            TabSimple.Size = new Size(761, 469);
            TabSimple.TabIndex = 0;
            TabSimple.Text = "Simple";
            TabSimple.UseVisualStyleBackColor = true;
            // 
            // BtnSimpleClearLog
            // 
            BtnSimpleClearLog.Location = new Point(640, 62);
            BtnSimpleClearLog.Name = "BtnSimpleClearLog";
            BtnSimpleClearLog.Size = new Size(115, 23);
            BtnSimpleClearLog.TabIndex = 8;
            BtnSimpleClearLog.Text = "Clear Log";
            BtnSimpleClearLog.UseVisualStyleBackColor = true;
            BtnSimpleClearLog.Click += BtnSimpleClearLog_Click;
            // 
            // DgvSimpleLog
            // 
            DgvSimpleLog.AllowUserToAddRows = false;
            DgvSimpleLog.AllowUserToDeleteRows = false;
            DgvSimpleLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvSimpleLog.Columns.AddRange(new DataGridViewColumn[] { cmnSimpleTime, cmnSimpleSent, cmnSimpleReceived });
            DgvSimpleLog.Location = new Point(6, 91);
            DgvSimpleLog.Name = "DgvSimpleLog";
            DgvSimpleLog.ReadOnly = true;
            DgvSimpleLog.Size = new Size(749, 372);
            DgvSimpleLog.TabIndex = 9;
            // 
            // cmnSimpleTime
            // 
            cmnSimpleTime.HeaderText = "Time";
            cmnSimpleTime.Name = "cmnSimpleTime";
            cmnSimpleTime.ReadOnly = true;
            cmnSimpleTime.Width = 75;
            // 
            // cmnSimpleSent
            // 
            cmnSimpleSent.HeaderText = "Sent";
            cmnSimpleSent.Name = "cmnSimpleSent";
            cmnSimpleSent.ReadOnly = true;
            cmnSimpleSent.Width = 250;
            // 
            // cmnSimpleReceived
            // 
            cmnSimpleReceived.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            cmnSimpleReceived.HeaderText = "Received";
            cmnSimpleReceived.Name = "cmnSimpleReceived";
            cmnSimpleReceived.ReadOnly = true;
            // 
            // GrpSimpleInput
            // 
            GrpSimpleInput.Controls.Add(BtnCancelCommand);
            GrpSimpleInput.Controls.Add(CboSimpleCommandOptions);
            GrpSimpleInput.Controls.Add(BtnSimpleSendCommand);
            GrpSimpleInput.Controls.Add(LblSimpleExtraData);
            GrpSimpleInput.Controls.Add(CboSimpleCommandGroupOptions);
            GrpSimpleInput.Controls.Add(LblSimpleCommand);
            GrpSimpleInput.Controls.Add(TxtSimpleCommandInput);
            GrpSimpleInput.Controls.Add(CboSimpleCommandInput);
            GrpSimpleInput.Controls.Add(NumSimpleCommandInput);
            GrpSimpleInput.Location = new Point(6, 6);
            GrpSimpleInput.Name = "GrpSimpleInput";
            GrpSimpleInput.Size = new Size(521, 79);
            GrpSimpleInput.TabIndex = 8;
            GrpSimpleInput.TabStop = false;
            GrpSimpleInput.Text = "Input Data";
            // 
            // BtnCancelCommand
            // 
            BtnCancelCommand.BackColor = Color.FromArgb(237, 44, 44);
            BtnCancelCommand.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnCancelCommand.ForeColor = Color.White;
            BtnCancelCommand.Location = new Point(457, 19);
            BtnCancelCommand.Name = "BtnCancelCommand";
            BtnCancelCommand.Size = new Size(56, 50);
            BtnCancelCommand.TabIndex = 11;
            BtnCancelCommand.Text = "■";
            BtnCancelCommand.UseVisualStyleBackColor = false;
            BtnCancelCommand.Click += BtnCancelCommand_Click_1;
            // 
            // CboSimpleCommandOptions
            // 
            CboSimpleCommandOptions.DropDownStyle = ComboBoxStyle.DropDownList;
            CboSimpleCommandOptions.FormattingEnabled = true;
            CboSimpleCommandOptions.Location = new Point(203, 16);
            CboSimpleCommandOptions.Name = "CboSimpleCommandOptions";
            CboSimpleCommandOptions.Size = new Size(248, 23);
            CboSimpleCommandOptions.TabIndex = 3;
            CboSimpleCommandOptions.SelectedIndexChanged += CboSimpleCommandOptions_SelectedIndexChanged;
            // 
            // BtnSimpleSendCommand
            // 
            BtnSimpleSendCommand.Location = new Point(339, 45);
            BtnSimpleSendCommand.Name = "BtnSimpleSendCommand";
            BtnSimpleSendCommand.Size = new Size(112, 23);
            BtnSimpleSendCommand.TabIndex = 7;
            BtnSimpleSendCommand.Text = "Send Command";
            BtnSimpleSendCommand.UseVisualStyleBackColor = true;
            BtnSimpleSendCommand.Click += BtnSimpleSendCommand_Click;
            // 
            // LblSimpleExtraData
            // 
            LblSimpleExtraData.AutoSize = true;
            LblSimpleExtraData.Location = new Point(6, 48);
            LblSimpleExtraData.Name = "LblSimpleExtraData";
            LblSimpleExtraData.Size = new Size(94, 15);
            LblSimpleExtraData.TabIndex = 10;
            LblSimpleExtraData.Text = "Command Data:";
            LblSimpleExtraData.TextAlign = ContentAlignment.MiddleRight;
            // 
            // CboSimpleCommandGroupOptions
            // 
            CboSimpleCommandGroupOptions.DropDownStyle = ComboBoxStyle.DropDownList;
            CboSimpleCommandGroupOptions.FormattingEnabled = true;
            CboSimpleCommandGroupOptions.Location = new Point(106, 16);
            CboSimpleCommandGroupOptions.Name = "CboSimpleCommandGroupOptions";
            CboSimpleCommandGroupOptions.Size = new Size(91, 23);
            CboSimpleCommandGroupOptions.TabIndex = 2;
            CboSimpleCommandGroupOptions.SelectedIndexChanged += CboSimpleCommandGroupOptions_SelectedIndexChanged;
            // 
            // LblSimpleCommand
            // 
            LblSimpleCommand.AutoSize = true;
            LblSimpleCommand.Location = new Point(33, 19);
            LblSimpleCommand.Name = "LblSimpleCommand";
            LblSimpleCommand.Size = new Size(67, 15);
            LblSimpleCommand.TabIndex = 9;
            LblSimpleCommand.Text = "Command:";
            // 
            // TxtSimpleCommandInput
            // 
            TxtSimpleCommandInput.Location = new Point(106, 45);
            TxtSimpleCommandInput.Name = "TxtSimpleCommandInput";
            TxtSimpleCommandInput.Size = new Size(227, 23);
            TxtSimpleCommandInput.TabIndex = 6;
            TxtSimpleCommandInput.TextChanged += TxtSimpleCommandInput_TextChanged;
            // 
            // CboSimpleCommandInput
            // 
            CboSimpleCommandInput.DropDownStyle = ComboBoxStyle.DropDownList;
            CboSimpleCommandInput.FormattingEnabled = true;
            CboSimpleCommandInput.Location = new Point(106, 45);
            CboSimpleCommandInput.Name = "CboSimpleCommandInput";
            CboSimpleCommandInput.Size = new Size(227, 23);
            CboSimpleCommandInput.TabIndex = 4;
            CboSimpleCommandInput.SelectedIndexChanged += CboSimpleCommandInput_SelectedIndexChanged;
            // 
            // NumSimpleCommandInput
            // 
            NumSimpleCommandInput.Location = new Point(106, 45);
            NumSimpleCommandInput.Name = "NumSimpleCommandInput";
            NumSimpleCommandInput.Size = new Size(227, 23);
            NumSimpleCommandInput.TabIndex = 5;
            NumSimpleCommandInput.ValueChanged += NumSimpleCommandInput_ValueChanged;
            // 
            // tabAdvanced
            // 
            tabAdvanced.Controls.Add(GrpAdvancedMovement);
            tabAdvanced.Controls.Add(GrpManualMovement);
            tabAdvanced.Controls.Add(GrpCurrentCommand);
            tabAdvanced.Controls.Add(GrpPosition);
            tabAdvanced.Controls.Add(GrpStatistics);
            tabAdvanced.Controls.Add(GrpSimpleCommands);
            tabAdvanced.Controls.Add(GrpSizeGroup);
            tabAdvanced.Controls.Add(GrpSpeedGroup);
            tabAdvanced.Location = new Point(4, 24);
            tabAdvanced.Name = "tabAdvanced";
            tabAdvanced.Padding = new Padding(3);
            tabAdvanced.Size = new Size(761, 469);
            tabAdvanced.TabIndex = 1;
            tabAdvanced.Text = "Advanced";
            tabAdvanced.UseVisualStyleBackColor = true;
            // 
            // GrpAdvancedMovement
            // 
            GrpAdvancedMovement.Controls.Add(LblMoveToPosition);
            GrpAdvancedMovement.Controls.Add(LblMoveNSteps);
            GrpAdvancedMovement.Controls.Add(BtnMoveToPositionSend);
            GrpAdvancedMovement.Controls.Add(BtnMoveNStepsSend);
            GrpAdvancedMovement.Controls.Add(textBox2);
            GrpAdvancedMovement.Controls.Add(textBox1);
            GrpAdvancedMovement.Controls.Add(LblAdvSpeedData);
            GrpAdvancedMovement.Controls.Add(LblAdvSpeed);
            GrpAdvancedMovement.Controls.Add(TrkAdvMovementSpeed);
            GrpAdvancedMovement.Location = new Point(183, 138);
            GrpAdvancedMovement.Name = "GrpAdvancedMovement";
            GrpAdvancedMovement.Size = new Size(364, 132);
            GrpAdvancedMovement.TabIndex = 7;
            GrpAdvancedMovement.TabStop = false;
            GrpAdvancedMovement.Text = "Advanced Azimuth Movement";
            // 
            // LblMoveToPosition
            // 
            LblMoveToPosition.AutoSize = true;
            LblMoveToPosition.Location = new Point(259, 84);
            LblMoveToPosition.Name = "LblMoveToPosition";
            LblMoveToPosition.Size = new Size(99, 15);
            LblMoveToPosition.TabIndex = 8;
            LblMoveToPosition.Text = "Move To Position";
            // 
            // LblMoveNSteps
            // 
            LblMoveNSteps.AutoSize = true;
            LblMoveNSteps.Location = new Point(4, 84);
            LblMoveNSteps.Name = "LblMoveNSteps";
            LblMoveNSteps.Size = new Size(80, 15);
            LblMoveNSteps.TabIndex = 7;
            LblMoveNSteps.Text = "Move N Steps";
            // 
            // BtnMoveToPositionSend
            // 
            BtnMoveToPositionSend.Location = new Point(233, 103);
            BtnMoveToPositionSend.Name = "BtnMoveToPositionSend";
            BtnMoveToPositionSend.Size = new Size(47, 23);
            BtnMoveToPositionSend.TabIndex = 6;
            BtnMoveToPositionSend.Text = "Send";
            BtnMoveToPositionSend.UseVisualStyleBackColor = true;
            // 
            // BtnMoveNStepsSend
            // 
            BtnMoveNStepsSend.Location = new Point(84, 103);
            BtnMoveNStepsSend.Name = "BtnMoveNStepsSend";
            BtnMoveNStepsSend.Size = new Size(47, 23);
            BtnMoveNStepsSend.TabIndex = 5;
            BtnMoveNStepsSend.Text = "Send";
            BtnMoveNStepsSend.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(286, 102);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(72, 23);
            textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 102);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(72, 23);
            textBox1.TabIndex = 3;
            // 
            // LblAdvSpeedData
            // 
            LblAdvSpeedData.AutoSize = true;
            LblAdvSpeedData.Location = new Point(177, 49);
            LblAdvSpeedData.Name = "LblAdvSpeedData";
            LblAdvSpeedData.Size = new Size(46, 15);
            LblAdvSpeedData.TabIndex = 2;
            LblAdvSpeedData.Text = "[speed]";
            // 
            // LblAdvSpeed
            // 
            LblAdvSpeed.AutoSize = true;
            LblAdvSpeed.Location = new Point(138, 49);
            LblAdvSpeed.Name = "LblAdvSpeed";
            LblAdvSpeed.Size = new Size(42, 15);
            LblAdvSpeed.TabIndex = 1;
            LblAdvSpeed.Text = "Speed:";
            // 
            // TrkAdvMovementSpeed
            // 
            TrkAdvMovementSpeed.Location = new Point(6, 19);
            TrkAdvMovementSpeed.Maximum = 15;
            TrkAdvMovementSpeed.Minimum = 1;
            TrkAdvMovementSpeed.Name = "TrkAdvMovementSpeed";
            TrkAdvMovementSpeed.Size = new Size(352, 45);
            TrkAdvMovementSpeed.TabIndex = 0;
            TrkAdvMovementSpeed.Value = 1;
            // 
            // GrpManualMovement
            // 
            GrpManualMovement.Controls.Add(BtnStepCounterClockwise);
            GrpManualMovement.Controls.Add(BtnStepClockwise);
            GrpManualMovement.Controls.Add(BtnToggleClutch);
            GrpManualMovement.Location = new Point(6, 138);
            GrpManualMovement.Name = "GrpManualMovement";
            GrpManualMovement.Size = new Size(171, 132);
            GrpManualMovement.TabIndex = 6;
            GrpManualMovement.TabStop = false;
            GrpManualMovement.Text = "Manual Azimuth Movement";
            // 
            // BtnStepCounterClockwise
            // 
            BtnStepCounterClockwise.Location = new Point(91, 83);
            BtnStepCounterClockwise.Name = "BtnStepCounterClockwise";
            BtnStepCounterClockwise.Size = new Size(75, 43);
            BtnStepCounterClockwise.TabIndex = 2;
            BtnStepCounterClockwise.Text = "Step CCW";
            BtnStepCounterClockwise.UseVisualStyleBackColor = true;
            // 
            // BtnStepClockwise
            // 
            BtnStepClockwise.Location = new Point(6, 83);
            BtnStepClockwise.Name = "BtnStepClockwise";
            BtnStepClockwise.Size = new Size(75, 43);
            BtnStepClockwise.TabIndex = 1;
            BtnStepClockwise.Text = "Step CW";
            BtnStepClockwise.UseVisualStyleBackColor = true;
            // 
            // BtnToggleClutch
            // 
            BtnToggleClutch.Location = new Point(3, 19);
            BtnToggleClutch.Name = "BtnToggleClutch";
            BtnToggleClutch.Size = new Size(163, 58);
            BtnToggleClutch.TabIndex = 0;
            BtnToggleClutch.Text = "Toggle Clutch";
            BtnToggleClutch.UseVisualStyleBackColor = true;
            // 
            // GrpCurrentCommand
            // 
            GrpCurrentCommand.Controls.Add(LblCurrCommandStatusData);
            GrpCurrentCommand.Controls.Add(LblCurrSubCommandData);
            GrpCurrentCommand.Controls.Add(LblCurrCommandData);
            GrpCurrentCommand.Controls.Add(LblCommandStatus);
            GrpCurrentCommand.Controls.Add(LblSubCommand);
            GrpCurrentCommand.Controls.Add(LblCurrCommand);
            GrpCurrentCommand.Location = new Point(553, 105);
            GrpCurrentCommand.Name = "GrpCurrentCommand";
            GrpCurrentCommand.Size = new Size(200, 81);
            GrpCurrentCommand.TabIndex = 5;
            GrpCurrentCommand.TabStop = false;
            GrpCurrentCommand.Text = "Current Command";
            // 
            // LblCurrCommandStatusData
            // 
            LblCurrCommandStatusData.AutoSize = true;
            LblCurrCommandStatusData.Location = new Point(102, 55);
            LblCurrCommandStatusData.Name = "LblCurrCommandStatusData";
            LblCurrCommandStatusData.Size = new Size(46, 15);
            LblCurrCommandStatusData.TabIndex = 5;
            LblCurrCommandStatusData.Text = "[status]";
            // 
            // LblCurrSubCommandData
            // 
            LblCurrSubCommandData.AutoSize = true;
            LblCurrSubCommandData.Location = new Point(102, 37);
            LblCurrSubCommandData.Name = "LblCurrSubCommandData";
            LblCurrSubCommandData.Size = new Size(89, 15);
            LblCurrSubCommandData.TabIndex = 4;
            LblCurrSubCommandData.Text = "[subcommand]";
            // 
            // LblCurrCommandData
            // 
            LblCurrCommandData.AutoSize = true;
            LblCurrCommandData.Location = new Point(102, 19);
            LblCurrCommandData.Name = "LblCurrCommandData";
            LblCurrCommandData.Size = new Size(70, 15);
            LblCurrCommandData.TabIndex = 3;
            LblCurrCommandData.Text = "[command]";
            // 
            // LblCommandStatus
            // 
            LblCommandStatus.AutoSize = true;
            LblCommandStatus.Location = new Point(56, 55);
            LblCommandStatus.Name = "LblCommandStatus";
            LblCommandStatus.Size = new Size(42, 15);
            LblCommandStatus.TabIndex = 2;
            LblCommandStatus.Text = "Status:";
            // 
            // LblSubCommand
            // 
            LblSubCommand.AutoSize = true;
            LblSubCommand.Location = new Point(11, 37);
            LblSubCommand.Name = "LblSubCommand";
            LblSubCommand.Size = new Size(87, 15);
            LblSubCommand.TabIndex = 1;
            LblSubCommand.Text = "SubCommand:";
            // 
            // LblCurrCommand
            // 
            LblCurrCommand.AutoSize = true;
            LblCurrCommand.Location = new Point(31, 19);
            LblCurrCommand.Name = "LblCurrCommand";
            LblCurrCommand.Size = new Size(67, 15);
            LblCurrCommand.TabIndex = 0;
            LblCurrCommand.Text = "Command:";
            // 
            // GrpPosition
            // 
            GrpPosition.Controls.Add(LblHomeStatusData);
            GrpPosition.Controls.Add(LblLiftStatusData);
            GrpPosition.Controls.Add(LblHorizontalPositionData);
            GrpPosition.Controls.Add(LblVerticalPositionData);
            GrpPosition.Controls.Add(LblHomeStatus);
            GrpPosition.Controls.Add(LblLiftStatus);
            GrpPosition.Controls.Add(LblHorizontalPosition);
            GrpPosition.Controls.Add(LblVerticalPosition);
            GrpPosition.Location = new Point(553, 6);
            GrpPosition.Name = "GrpPosition";
            GrpPosition.Size = new Size(200, 93);
            GrpPosition.TabIndex = 4;
            GrpPosition.TabStop = false;
            GrpPosition.Text = "Position";
            // 
            // LblHomeStatusData
            // 
            LblHomeStatusData.AutoSize = true;
            LblHomeStatusData.Location = new Point(77, 74);
            LblHomeStatusData.Name = "LblHomeStatusData";
            LblHomeStatusData.Size = new Size(80, 15);
            LblHomeStatusData.TabIndex = 7;
            LblHomeStatusData.Text = "[home status]";
            // 
            // LblLiftStatusData
            // 
            LblLiftStatusData.AutoSize = true;
            LblLiftStatusData.Location = new Point(77, 55);
            LblLiftStatusData.Name = "LblLiftStatusData";
            LblLiftStatusData.Size = new Size(63, 15);
            LblLiftStatusData.TabIndex = 6;
            LblLiftStatusData.Text = "[lift status]";
            // 
            // LblHorizontalPositionData
            // 
            LblHorizontalPositionData.AutoSize = true;
            LblHorizontalPositionData.Location = new Point(77, 37);
            LblHorizontalPositionData.Name = "LblHorizontalPositionData";
            LblHorizontalPositionData.Size = new Size(114, 15);
            LblHorizontalPositionData.TabIndex = 5;
            LblHorizontalPositionData.Text = "[horizontal position]";
            // 
            // LblVerticalPositionData
            // 
            LblVerticalPositionData.AutoSize = true;
            LblVerticalPositionData.Location = new Point(77, 18);
            LblVerticalPositionData.Name = "LblVerticalPositionData";
            LblVerticalPositionData.Size = new Size(99, 15);
            LblVerticalPositionData.TabIndex = 4;
            LblVerticalPositionData.Text = "[vertical position]";
            // 
            // LblHomeStatus
            // 
            LblHomeStatus.AutoSize = true;
            LblHomeStatus.Location = new Point(28, 74);
            LblHomeStatus.Name = "LblHomeStatus";
            LblHomeStatus.Size = new Size(43, 15);
            LblHomeStatus.TabIndex = 3;
            LblHomeStatus.Text = "Home:";
            // 
            // LblLiftStatus
            // 
            LblLiftStatus.AutoSize = true;
            LblLiftStatus.Location = new Point(44, 55);
            LblLiftStatus.Name = "LblLiftStatus";
            LblLiftStatus.Size = new Size(27, 15);
            LblLiftStatus.TabIndex = 2;
            LblLiftStatus.Text = "Lift:";
            // 
            // LblHorizontalPosition
            // 
            LblHorizontalPosition.AutoSize = true;
            LblHorizontalPosition.Location = new Point(6, 37);
            LblHorizontalPosition.Name = "LblHorizontalPosition";
            LblHorizontalPosition.Size = new Size(65, 15);
            LblHorizontalPosition.TabIndex = 1;
            LblHorizontalPosition.Text = "Horizontal:";
            // 
            // LblVerticalPosition
            // 
            LblVerticalPosition.AutoSize = true;
            LblVerticalPosition.Location = new Point(23, 18);
            LblVerticalPosition.Name = "LblVerticalPosition";
            LblVerticalPosition.Size = new Size(48, 15);
            LblVerticalPosition.TabIndex = 0;
            LblVerticalPosition.Text = "Vertical:";
            // 
            // GrpStatistics
            // 
            GrpStatistics.Controls.Add(LblUpTimeData);
            GrpStatistics.Controls.Add(LblUpTime);
            GrpStatistics.Location = new Point(553, 192);
            GrpStatistics.Name = "GrpStatistics";
            GrpStatistics.Size = new Size(200, 271);
            GrpStatistics.TabIndex = 3;
            GrpStatistics.TabStop = false;
            GrpStatistics.Text = "Statistics";
            // 
            // LblUpTimeData
            // 
            LblUpTimeData.AutoSize = true;
            LblUpTimeData.Location = new Point(66, 18);
            LblUpTimeData.Name = "LblUpTimeData";
            LblUpTimeData.Size = new Size(56, 15);
            LblUpTimeData.TabIndex = 1;
            LblUpTimeData.Text = "[up time]";
            // 
            // LblUpTime
            // 
            LblUpTime.AutoSize = true;
            LblUpTime.Location = new Point(6, 18);
            LblUpTime.Name = "LblUpTime";
            LblUpTime.Size = new Size(55, 15);
            LblUpTime.TabIndex = 0;
            LblUpTime.Text = "Up Time:";
            // 
            // GrpSimpleCommands
            // 
            GrpSimpleCommands.Controls.Add(BtnRotateSpeed);
            GrpSimpleCommands.Controls.Add(btnRotateSize);
            GrpSimpleCommands.Controls.Add(BtnPause);
            GrpSimpleCommands.Controls.Add(BtnPlay);
            GrpSimpleCommands.Location = new Point(6, 6);
            GrpSimpleCommands.Name = "GrpSimpleCommands";
            GrpSimpleCommands.Size = new Size(202, 126);
            GrpSimpleCommands.TabIndex = 2;
            GrpSimpleCommands.TabStop = false;
            GrpSimpleCommands.Text = "Simple Commands";
            // 
            // BtnRotateSpeed
            // 
            BtnRotateSpeed.Location = new Point(103, 19);
            BtnRotateSpeed.Name = "BtnRotateSpeed";
            BtnRotateSpeed.Size = new Size(93, 47);
            BtnRotateSpeed.TabIndex = 3;
            BtnRotateSpeed.Text = "Rotate Speed";
            BtnRotateSpeed.UseVisualStyleBackColor = true;
            BtnRotateSpeed.Click += BtnRotateSpeed_Click;
            // 
            // btnRotateSize
            // 
            btnRotateSize.Location = new Point(103, 73);
            btnRotateSize.Name = "btnRotateSize";
            btnRotateSize.Size = new Size(93, 47);
            btnRotateSize.TabIndex = 2;
            btnRotateSize.Text = "Rotate Size";
            btnRotateSize.UseVisualStyleBackColor = true;
            btnRotateSize.Click += btnRotateSize_Click;
            // 
            // BtnPause
            // 
            BtnPause.Location = new Point(6, 72);
            BtnPause.Name = "BtnPause";
            BtnPause.Size = new Size(93, 48);
            BtnPause.TabIndex = 1;
            BtnPause.Text = "Pause";
            BtnPause.UseVisualStyleBackColor = true;
            BtnPause.Click += BtnPause_Click;
            // 
            // BtnPlay
            // 
            BtnPlay.Location = new Point(6, 18);
            BtnPlay.Name = "BtnPlay";
            BtnPlay.Size = new Size(93, 48);
            BtnPlay.TabIndex = 0;
            BtnPlay.Text = "Play";
            BtnPlay.UseVisualStyleBackColor = true;
            BtnPlay.Click += BtnPlay_Click;
            // 
            // GrpSizeGroup
            // 
            GrpSizeGroup.Controls.Add(RadSizeAuto);
            GrpSizeGroup.Controls.Add(RadSize12In);
            GrpSizeGroup.Controls.Add(RadSize10In);
            GrpSizeGroup.Controls.Add(RadSize7In);
            GrpSizeGroup.Location = new Point(214, 6);
            GrpSizeGroup.Name = "GrpSizeGroup";
            GrpSizeGroup.Size = new Size(125, 126);
            GrpSizeGroup.TabIndex = 1;
            GrpSizeGroup.TabStop = false;
            GrpSizeGroup.Text = "Size";
            // 
            // RadSizeAuto
            // 
            RadSizeAuto.AutoSize = true;
            RadSizeAuto.Location = new Point(11, 97);
            RadSizeAuto.Name = "RadSizeAuto";
            RadSizeAuto.Size = new Size(81, 19);
            RadSizeAuto.TabIndex = 3;
            RadSizeAuto.TabStop = true;
            RadSizeAuto.Text = "Automatic";
            RadSizeAuto.UseVisualStyleBackColor = true;
            RadSizeAuto.CheckedChanged += RadSizeAuto_CheckedChanged;
            // 
            // RadSize12In
            // 
            RadSize12In.AutoSize = true;
            RadSize12In.Location = new Point(11, 72);
            RadSize12In.Name = "RadSize12In";
            RadSize12In.Size = new Size(42, 19);
            RadSize12In.TabIndex = 2;
            RadSize12In.TabStop = true;
            RadSize12In.Text = "12\"";
            RadSize12In.UseVisualStyleBackColor = true;
            RadSize12In.CheckedChanged += RadSize12In_CheckedChanged;
            // 
            // RadSize10In
            // 
            RadSize10In.AutoSize = true;
            RadSize10In.Location = new Point(11, 47);
            RadSize10In.Name = "RadSize10In";
            RadSize10In.Size = new Size(42, 19);
            RadSize10In.TabIndex = 1;
            RadSize10In.TabStop = true;
            RadSize10In.Text = "10\"";
            RadSize10In.UseVisualStyleBackColor = true;
            RadSize10In.CheckedChanged += RadSize10In_CheckedChanged;
            // 
            // RadSize7In
            // 
            RadSize7In.AutoSize = true;
            RadSize7In.Location = new Point(11, 22);
            RadSize7In.Name = "RadSize7In";
            RadSize7In.Size = new Size(36, 19);
            RadSize7In.TabIndex = 0;
            RadSize7In.TabStop = true;
            RadSize7In.Text = "7\"";
            RadSize7In.UseVisualStyleBackColor = true;
            RadSize7In.CheckedChanged += RadSize7In_CheckedChanged;
            // 
            // GrpSpeedGroup
            // 
            GrpSpeedGroup.Controls.Add(NumSpeed);
            GrpSpeedGroup.Controls.Add(LblActualSpeedData);
            GrpSpeedGroup.Controls.Add(LblTargetSpeedData);
            GrpSpeedGroup.Controls.Add(LblSpeedSettingData);
            GrpSpeedGroup.Controls.Add(BtnSubmitSpeed);
            GrpSpeedGroup.Controls.Add(LblNewSpeed);
            GrpSpeedGroup.Controls.Add(LblActualSpeed);
            GrpSpeedGroup.Controls.Add(LblTargetSpeed);
            GrpSpeedGroup.Controls.Add(LblSpeedSetting);
            GrpSpeedGroup.Location = new Point(345, 6);
            GrpSpeedGroup.Name = "GrpSpeedGroup";
            GrpSpeedGroup.Size = new Size(202, 126);
            GrpSpeedGroup.TabIndex = 0;
            GrpSpeedGroup.TabStop = false;
            GrpSpeedGroup.Text = "Speed";
            // 
            // LblActualSpeedData
            // 
            LblActualSpeedData.AutoSize = true;
            LblActualSpeedData.Location = new Point(92, 55);
            LblActualSpeedData.Name = "LblActualSpeedData";
            LblActualSpeedData.Size = new Size(81, 15);
            LblActualSpeedData.TabIndex = 2;
            LblActualSpeedData.Text = "[actual speed]";
            // 
            // LblTargetSpeedData
            // 
            LblTargetSpeedData.AutoSize = true;
            LblTargetSpeedData.Location = new Point(92, 37);
            LblTargetSpeedData.Name = "LblTargetSpeedData";
            LblTargetSpeedData.Size = new Size(80, 15);
            LblTargetSpeedData.TabIndex = 7;
            LblTargetSpeedData.Text = "[target speed]";
            // 
            // LblSpeedSettingData
            // 
            LblSpeedSettingData.AutoSize = true;
            LblSpeedSettingData.Location = new Point(92, 19);
            LblSpeedSettingData.Name = "LblSpeedSettingData";
            LblSpeedSettingData.Size = new Size(85, 15);
            LblSpeedSettingData.TabIndex = 6;
            LblSpeedSettingData.Text = "[speed setting]";
            // 
            // BtnSubmitSpeed
            // 
            BtnSubmitSpeed.Location = new Point(69, 97);
            BtnSubmitSpeed.Name = "BtnSubmitSpeed";
            BtnSubmitSpeed.Size = new Size(75, 23);
            BtnSubmitSpeed.TabIndex = 5;
            BtnSubmitSpeed.Text = "Save";
            BtnSubmitSpeed.UseVisualStyleBackColor = true;
            BtnSubmitSpeed.Click += BtnSubmitSpeed_Click;
            // 
            // LblNewSpeed
            // 
            LblNewSpeed.AutoSize = true;
            LblNewSpeed.Location = new Point(24, 76);
            LblNewSpeed.Name = "LblNewSpeed";
            LblNewSpeed.Size = new Size(69, 15);
            LblNewSpeed.TabIndex = 3;
            LblNewSpeed.Text = "New Speed:";
            // 
            // LblActualSpeed
            // 
            LblActualSpeed.AutoSize = true;
            LblActualSpeed.Location = new Point(14, 55);
            LblActualSpeed.Name = "LblActualSpeed";
            LblActualSpeed.Size = new Size(79, 15);
            LblActualSpeed.TabIndex = 2;
            LblActualSpeed.Text = "Actual Speed:";
            // 
            // LblTargetSpeed
            // 
            LblTargetSpeed.AutoSize = true;
            LblTargetSpeed.Location = new Point(15, 37);
            LblTargetSpeed.Name = "LblTargetSpeed";
            LblTargetSpeed.Size = new Size(78, 15);
            LblTargetSpeed.TabIndex = 1;
            LblTargetSpeed.Text = "Target Speed:";
            // 
            // LblSpeedSetting
            // 
            LblSpeedSetting.AutoSize = true;
            LblSpeedSetting.Location = new Point(11, 19);
            LblSpeedSetting.Name = "LblSpeedSetting";
            LblSpeedSetting.Size = new Size(82, 15);
            LblSpeedSetting.TabIndex = 0;
            LblSpeedSetting.Text = "Speed Setting:";
            // 
            // tabGraphical
            // 
            tabGraphical.Controls.Add(LblTodo2);
            tabGraphical.Location = new Point(4, 24);
            tabGraphical.Name = "tabGraphical";
            tabGraphical.Size = new Size(761, 469);
            tabGraphical.TabIndex = 2;
            tabGraphical.Text = "Graphical";
            tabGraphical.UseVisualStyleBackColor = true;
            // 
            // LblTodo2
            // 
            LblTodo2.AutoSize = true;
            LblTodo2.Location = new Point(305, 223);
            LblTodo2.Name = "LblTodo2";
            LblTodo2.Size = new Size(123, 15);
            LblTodo2.TabIndex = 0;
            LblTodo2.Text = "Not yet implemented!";
            // 
            // CboSerialOptions
            // 
            CboSerialOptions.DropDownStyle = ComboBoxStyle.DropDownList;
            CboSerialOptions.FormattingEnabled = true;
            CboSerialOptions.Location = new Point(81, 6);
            CboSerialOptions.Name = "CboSerialOptions";
            CboSerialOptions.Size = new Size(209, 23);
            CboSerialOptions.TabIndex = 0;
            // 
            // LblSerialOptions
            // 
            LblSerialOptions.AutoSize = true;
            LblSerialOptions.Location = new Point(12, 9);
            LblSerialOptions.Name = "LblSerialOptions";
            LblSerialOptions.Size = new Size(63, 15);
            LblSerialOptions.TabIndex = 1;
            LblSerialOptions.Text = "Serial Port:";
            // 
            // LblConnectionStatus
            // 
            LblConnectionStatus.AutoSize = true;
            LblConnectionStatus.Location = new Point(603, 9);
            LblConnectionStatus.Name = "LblConnectionStatus";
            LblConnectionStatus.Size = new Size(88, 15);
            LblConnectionStatus.TabIndex = 2;
            LblConnectionStatus.Text = "Not Connected";
            LblConnectionStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // BtnConnect
            // 
            BtnConnect.Location = new Point(697, 6);
            BtnConnect.Name = "BtnConnect";
            BtnConnect.Size = new Size(84, 23);
            BtnConnect.TabIndex = 1;
            BtnConnect.Text = "Connect";
            BtnConnect.UseVisualStyleBackColor = true;
            BtnConnect.Click += BtnConnect_Click;
            // 
            // BtnRefreshSerialPorts
            // 
            BtnRefreshSerialPorts.Location = new Point(296, 6);
            BtnRefreshSerialPorts.Name = "BtnRefreshSerialPorts";
            BtnRefreshSerialPorts.Size = new Size(59, 23);
            BtnRefreshSerialPorts.TabIndex = 10;
            BtnRefreshSerialPorts.Text = "Refresh";
            BtnRefreshSerialPorts.UseVisualStyleBackColor = true;
            BtnRefreshSerialPorts.Click += BtnRefreshSerialPorts_Click;
            // 
            // NumSpeed
            // 
            NumSpeed.DecimalPlaces = 4;
            NumSpeed.Location = new Point(92, 73);
            NumSpeed.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumSpeed.Name = "NumSpeed";
            NumSpeed.Size = new Size(104, 23);
            NumSpeed.TabIndex = 8;
            NumSpeed.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // FrmMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(793, 544);
            Controls.Add(BtnRefreshSerialPorts);
            Controls.Add(BtnConnect);
            Controls.Add(TabMain);
            Controls.Add(LblConnectionStatus);
            Controls.Add(LblSerialOptions);
            Controls.Add(CboSerialOptions);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMainForm";
            Text = "Statimatic STM Testing Suite";
            TabMain.ResumeLayout(false);
            TabSimple.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvSimpleLog).EndInit();
            GrpSimpleInput.ResumeLayout(false);
            GrpSimpleInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumSimpleCommandInput).EndInit();
            tabAdvanced.ResumeLayout(false);
            GrpAdvancedMovement.ResumeLayout(false);
            GrpAdvancedMovement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TrkAdvMovementSpeed).EndInit();
            GrpManualMovement.ResumeLayout(false);
            GrpCurrentCommand.ResumeLayout(false);
            GrpCurrentCommand.PerformLayout();
            GrpPosition.ResumeLayout(false);
            GrpPosition.PerformLayout();
            GrpStatistics.ResumeLayout(false);
            GrpStatistics.PerformLayout();
            GrpSimpleCommands.ResumeLayout(false);
            GrpSizeGroup.ResumeLayout(false);
            GrpSizeGroup.PerformLayout();
            GrpSpeedGroup.ResumeLayout(false);
            GrpSpeedGroup.PerformLayout();
            tabGraphical.ResumeLayout(false);
            tabGraphical.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumSpeed).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabMain;
        private TabPage TabSimple;
        private TabPage tabAdvanced;
        private ComboBox CboSerialOptions;
        private Label LblSerialOptions;
        private Label LblConnectionStatus;
        private TabPage tabGraphical;
        private Label LblTodo2;
        private GroupBox GrpSimpleInput;
        private TextBox TxtSimpleCommandInput;
        private Label LblSimpleExtraData;
        private ComboBox CboSimpleCommandGroupOptions;
        private Label LblSimpleCommand;
        private Button BtnSimpleSendCommand;
        private DataGridView DgvSimpleLog;
        private Button BtnSimpleClearLog;
        private Button BtnConnect;
        private ComboBox CboSimpleCommandOptions;
        private NumericUpDown NumSimpleCommandInput;
        private ComboBox CboSimpleCommandInput;
        private Button BtnRefreshSerialPorts;
        private DataGridViewTextBoxColumn cmnSimpleTime;
        private DataGridViewTextBoxColumn cmnSimpleSent;
        private DataGridViewTextBoxColumn cmnSimpleReceived;
        private Button BtnCancelCommand;
        private GroupBox GrpSpeedGroup;
        private GroupBox GrpSizeGroup;
        private RadioButton RadSizeAuto;
        private RadioButton RadSize12In;
        private RadioButton RadSize10In;
        private RadioButton RadSize7In;
        private Label LblActualSpeed;
        private Label LblTargetSpeed;
        private Label LblSpeedSetting;
        private Label LblNewSpeed;
        private Button BtnSubmitSpeed;
        private Label LblActualSpeedData;
        private Label LblTargetSpeedData;
        private Label LblSpeedSettingData;
        private GroupBox GrpSimpleCommands;
        private Button BtnRotateSpeed;
        private Button btnRotateSize;
        private Button BtnPause;
        private Button BtnPlay;
        private GroupBox GrpStatistics;
        private Label LblUpTimeData;
        private Label LblUpTime;
        private GroupBox GrpPosition;
        private Label LblVerticalPosition;
        private Label LblHomeStatus;
        private Label LblLiftStatus;
        private Label LblHorizontalPosition;
        private Label LblHomeStatusData;
        private Label LblLiftStatusData;
        private Label LblHorizontalPositionData;
        private Label LblVerticalPositionData;
        private GroupBox GrpCurrentCommand;
        private Label LblCommandStatus;
        private Label LblSubCommand;
        private Label LblCurrCommand;
        private Label LblCurrCommandStatus;
        private Label LblCurrSubCommand;
        private Label LblCurrCommandData;
        private GroupBox GrpManualMovement;
        private Button BtnStepCounterClockwise;
        private Button BtnStepClockwise;
        private Button BtnToggleClutch;
        private GroupBox GrpAdvancedMovement;
        private Label LblAdvSpeedData;
        private Label LblAdvSpeed;
        private TrackBar TrkAdvMovementSpeed;
        private Label LblMoveToPosition;
        private Label LblMoveNSteps;
        private Button BtnMoveToPositionSend;
        private Button BtnMoveNStepsSend;
        private TextBox textBox2;
        private TextBox textBox1;
        private TabControl TabMain;
        private Label LblCurrSubCommandData;
        private Label LblCurrCommandStatusData;
        private NumericUpDown NumSpeed;
    }
}
