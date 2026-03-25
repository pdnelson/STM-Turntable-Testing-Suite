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
            tabMain = new TabControl();
            TabSimple = new TabPage();
            BtnSimpleClearLog = new Button();
            DgvSimpleLog = new DataGridView();
            cmnSimpleTime = new DataGridViewTextBoxColumn();
            cmnSimpleSent = new DataGridViewTextBoxColumn();
            cmnSimpleReceived = new DataGridViewTextBoxColumn();
            GrpSimpleInput = new GroupBox();
            CboSimpleCommandOptions = new ComboBox();
            BtnSimpleSendCommand = new Button();
            LblSimpleExtraData = new Label();
            CboSimpleCommandGroupOptions = new ComboBox();
            LblSimpleCommand = new Label();
            TxtSimpleCommandInput = new TextBox();
            CboSimpleCommandInput = new ComboBox();
            NumSimpleCommandInput = new NumericUpDown();
            tabAdvanced = new TabPage();
            LblTodo1 = new Label();
            tabGraphical = new TabPage();
            LblTodo2 = new Label();
            CboSerialOptions = new ComboBox();
            LblSerialOptions = new Label();
            LblConnectionStatus = new Label();
            BtnConnect = new Button();
            BtnRefreshSerialPorts = new Button();
            tabMain.SuspendLayout();
            TabSimple.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvSimpleLog).BeginInit();
            GrpSimpleInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumSimpleCommandInput).BeginInit();
            tabAdvanced.SuspendLayout();
            tabGraphical.SuspendLayout();
            SuspendLayout();
            // 
            // tabMain
            // 
            tabMain.Controls.Add(TabSimple);
            tabMain.Controls.Add(tabAdvanced);
            tabMain.Controls.Add(tabGraphical);
            tabMain.Location = new Point(12, 35);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(769, 497);
            tabMain.TabIndex = 4;
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
            GrpSimpleInput.Size = new Size(483, 79);
            GrpSimpleInput.TabIndex = 8;
            GrpSimpleInput.TabStop = false;
            GrpSimpleInput.Text = "Input Data";
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
            tabAdvanced.Controls.Add(LblTodo1);
            tabAdvanced.Location = new Point(4, 24);
            tabAdvanced.Name = "tabAdvanced";
            tabAdvanced.Padding = new Padding(3);
            tabAdvanced.Size = new Size(761, 469);
            tabAdvanced.TabIndex = 1;
            tabAdvanced.Text = "Advanced";
            tabAdvanced.UseVisualStyleBackColor = true;
            // 
            // LblTodo1
            // 
            LblTodo1.AutoSize = true;
            LblTodo1.Location = new Point(311, 231);
            LblTodo1.Name = "LblTodo1";
            LblTodo1.Size = new Size(123, 15);
            LblTodo1.TabIndex = 0;
            LblTodo1.Text = "Not yet implemented!";
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
            // FrmMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(793, 544);
            Controls.Add(BtnRefreshSerialPorts);
            Controls.Add(BtnConnect);
            Controls.Add(tabMain);
            Controls.Add(LblConnectionStatus);
            Controls.Add(LblSerialOptions);
            Controls.Add(CboSerialOptions);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMainForm";
            Text = "Statimatic STM Testing Suite";
            tabMain.ResumeLayout(false);
            TabSimple.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvSimpleLog).EndInit();
            GrpSimpleInput.ResumeLayout(false);
            GrpSimpleInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumSimpleCommandInput).EndInit();
            tabAdvanced.ResumeLayout(false);
            tabAdvanced.PerformLayout();
            tabGraphical.ResumeLayout(false);
            tabGraphical.PerformLayout();
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
        private Label LblTodo1;
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
    }
}
