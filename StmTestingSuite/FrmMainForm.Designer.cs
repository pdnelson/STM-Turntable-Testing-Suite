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
            tabMain = new TabControl();
            tabSimple = new TabPage();
            btnSimpleClearLog = new Button();
            dgvSimpleLog = new DataGridView();
            cmnSimpleTime = new DataGridViewTextBoxColumn();
            cmnSimpleSent = new DataGridViewTextBoxColumn();
            cmnSimpleReceived = new DataGridViewTextBoxColumn();
            grpSimpleInput = new GroupBox();
            cboSimpleCommandInput = new ComboBox();
            numSimpleCommandInput = new NumericUpDown();
            cboSimpleCommandOptions = new ComboBox();
            btnSimpleSendCommand = new Button();
            txtSimpleCommandInput = new TextBox();
            lblSimpleExtraData = new Label();
            cboSimpleCommandGroupOptions = new ComboBox();
            lblSimpleCommand = new Label();
            tabAdvanced = new TabPage();
            lblTodo1 = new Label();
            tabGraphical = new TabPage();
            lblTodo2 = new Label();
            cboSerialOptions = new ComboBox();
            lblSerialOptions = new Label();
            lblConnectionStatus = new Label();
            btnConnect = new Button();
            BtnRefreshSerialPorts = new Button();
            tabMain.SuspendLayout();
            tabSimple.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSimpleLog).BeginInit();
            grpSimpleInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSimpleCommandInput).BeginInit();
            tabAdvanced.SuspendLayout();
            tabGraphical.SuspendLayout();
            SuspendLayout();
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabSimple);
            tabMain.Controls.Add(tabAdvanced);
            tabMain.Controls.Add(tabGraphical);
            tabMain.Location = new Point(12, 35);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(769, 497);
            tabMain.TabIndex = 4;
            // 
            // tabSimple
            // 
            tabSimple.Controls.Add(btnSimpleClearLog);
            tabSimple.Controls.Add(dgvSimpleLog);
            tabSimple.Controls.Add(grpSimpleInput);
            tabSimple.Location = new Point(4, 24);
            tabSimple.Name = "tabSimple";
            tabSimple.Padding = new Padding(3);
            tabSimple.Size = new Size(761, 469);
            tabSimple.TabIndex = 0;
            tabSimple.Text = "Simple";
            tabSimple.UseVisualStyleBackColor = true;
            // 
            // btnSimpleClearLog
            // 
            btnSimpleClearLog.Location = new Point(640, 62);
            btnSimpleClearLog.Name = "btnSimpleClearLog";
            btnSimpleClearLog.Size = new Size(115, 23);
            btnSimpleClearLog.TabIndex = 8;
            btnSimpleClearLog.Text = "Clear Log";
            btnSimpleClearLog.UseVisualStyleBackColor = true;
            btnSimpleClearLog.Click += btnSimpleClearLog_Click;
            // 
            // dgvSimpleLog
            // 
            dgvSimpleLog.AllowUserToAddRows = false;
            dgvSimpleLog.AllowUserToDeleteRows = false;
            dgvSimpleLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSimpleLog.Columns.AddRange(new DataGridViewColumn[] { cmnSimpleTime, cmnSimpleSent, cmnSimpleReceived });
            dgvSimpleLog.Location = new Point(6, 91);
            dgvSimpleLog.Name = "dgvSimpleLog";
            dgvSimpleLog.ReadOnly = true;
            dgvSimpleLog.Size = new Size(749, 372);
            dgvSimpleLog.TabIndex = 9;
            // 
            // cmnSimpleTime
            // 
            cmnSimpleTime.HeaderText = "Time";
            cmnSimpleTime.Name = "cmnSimpleTime";
            cmnSimpleTime.ReadOnly = true;
            // 
            // cmnSimpleSent
            // 
            cmnSimpleSent.HeaderText = "Sent";
            cmnSimpleSent.Name = "cmnSimpleSent";
            cmnSimpleSent.ReadOnly = true;
            cmnSimpleSent.Width = 200;
            // 
            // cmnSimpleReceived
            // 
            cmnSimpleReceived.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            cmnSimpleReceived.HeaderText = "Received";
            cmnSimpleReceived.Name = "cmnSimpleReceived";
            cmnSimpleReceived.ReadOnly = true;
            // 
            // grpSimpleInput
            // 
            grpSimpleInput.Controls.Add(cboSimpleCommandOptions);
            grpSimpleInput.Controls.Add(btnSimpleSendCommand);
            grpSimpleInput.Controls.Add(lblSimpleExtraData);
            grpSimpleInput.Controls.Add(cboSimpleCommandGroupOptions);
            grpSimpleInput.Controls.Add(lblSimpleCommand);
            grpSimpleInput.Controls.Add(numSimpleCommandInput);
            grpSimpleInput.Controls.Add(txtSimpleCommandInput);
            grpSimpleInput.Controls.Add(cboSimpleCommandInput);
            grpSimpleInput.Location = new Point(6, 6);
            grpSimpleInput.Name = "grpSimpleInput";
            grpSimpleInput.Size = new Size(483, 79);
            grpSimpleInput.TabIndex = 8;
            grpSimpleInput.TabStop = false;
            grpSimpleInput.Text = "Input Data";
            // 
            // cboSimpleCommandInput
            // 
            cboSimpleCommandInput.FormattingEnabled = true;
            cboSimpleCommandInput.Location = new Point(106, 45);
            cboSimpleCommandInput.Name = "cboSimpleCommandInput";
            cboSimpleCommandInput.Size = new Size(227, 23);
            cboSimpleCommandInput.TabIndex = 4;
            cboSimpleCommandInput.SelectedIndexChanged += cboSimpleCommandInput_SelectedIndexChanged;
            // 
            // numSimpleCommandInput
            // 
            numSimpleCommandInput.Location = new Point(106, 45);
            numSimpleCommandInput.Name = "numSimpleCommandInput";
            numSimpleCommandInput.Size = new Size(227, 23);
            numSimpleCommandInput.TabIndex = 5;
            numSimpleCommandInput.ValueChanged += numSimpleCommandInput_ValueChanged;
            // 
            // cboSimpleCommandOptions
            // 
            cboSimpleCommandOptions.FormattingEnabled = true;
            cboSimpleCommandOptions.Location = new Point(203, 16);
            cboSimpleCommandOptions.Name = "cboSimpleCommandOptions";
            cboSimpleCommandOptions.Size = new Size(248, 23);
            cboSimpleCommandOptions.TabIndex = 3;
            cboSimpleCommandOptions.SelectedIndexChanged += cboSimpleCommandOptions_SelectedIndexChanged;
            // 
            // btnSimpleSendCommand
            // 
            btnSimpleSendCommand.Location = new Point(339, 45);
            btnSimpleSendCommand.Name = "btnSimpleSendCommand";
            btnSimpleSendCommand.Size = new Size(112, 23);
            btnSimpleSendCommand.TabIndex = 7;
            btnSimpleSendCommand.Text = "Send Command";
            btnSimpleSendCommand.UseVisualStyleBackColor = true;
            btnSimpleSendCommand.Click += btnSimpleSendCommand_Click;
            // 
            // txtSimpleCommandInput
            // 
            txtSimpleCommandInput.Location = new Point(106, 45);
            txtSimpleCommandInput.Name = "txtSimpleCommandInput";
            txtSimpleCommandInput.Size = new Size(227, 23);
            txtSimpleCommandInput.TabIndex = 6;
            // 
            // lblSimpleExtraData
            // 
            lblSimpleExtraData.AutoSize = true;
            lblSimpleExtraData.Location = new Point(6, 48);
            lblSimpleExtraData.Name = "lblSimpleExtraData";
            lblSimpleExtraData.Size = new Size(94, 15);
            lblSimpleExtraData.TabIndex = 10;
            lblSimpleExtraData.Text = "Command Data:";
            lblSimpleExtraData.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboSimpleCommandGroupOptions
            // 
            cboSimpleCommandGroupOptions.FormattingEnabled = true;
            cboSimpleCommandGroupOptions.Location = new Point(106, 16);
            cboSimpleCommandGroupOptions.Name = "cboSimpleCommandGroupOptions";
            cboSimpleCommandGroupOptions.Size = new Size(91, 23);
            cboSimpleCommandGroupOptions.TabIndex = 2;
            cboSimpleCommandGroupOptions.SelectedIndexChanged += cboSimpleCommandGroupOptions_SelectedIndexChanged;
            // 
            // lblSimpleCommand
            // 
            lblSimpleCommand.AutoSize = true;
            lblSimpleCommand.Location = new Point(33, 19);
            lblSimpleCommand.Name = "lblSimpleCommand";
            lblSimpleCommand.Size = new Size(67, 15);
            lblSimpleCommand.TabIndex = 9;
            lblSimpleCommand.Text = "Command:";
            // 
            // tabAdvanced
            // 
            tabAdvanced.Controls.Add(lblTodo1);
            tabAdvanced.Location = new Point(4, 24);
            tabAdvanced.Name = "tabAdvanced";
            tabAdvanced.Padding = new Padding(3);
            tabAdvanced.Size = new Size(761, 469);
            tabAdvanced.TabIndex = 1;
            tabAdvanced.Text = "Advanced";
            tabAdvanced.UseVisualStyleBackColor = true;
            // 
            // lblTodo1
            // 
            lblTodo1.AutoSize = true;
            lblTodo1.Location = new Point(311, 231);
            lblTodo1.Name = "lblTodo1";
            lblTodo1.Size = new Size(123, 15);
            lblTodo1.TabIndex = 0;
            lblTodo1.Text = "Not yet implemented!";
            // 
            // tabGraphical
            // 
            tabGraphical.Controls.Add(lblTodo2);
            tabGraphical.Location = new Point(4, 24);
            tabGraphical.Name = "tabGraphical";
            tabGraphical.Size = new Size(761, 469);
            tabGraphical.TabIndex = 2;
            tabGraphical.Text = "Graphical";
            tabGraphical.UseVisualStyleBackColor = true;
            // 
            // lblTodo2
            // 
            lblTodo2.AutoSize = true;
            lblTodo2.Location = new Point(305, 223);
            lblTodo2.Name = "lblTodo2";
            lblTodo2.Size = new Size(123, 15);
            lblTodo2.TabIndex = 0;
            lblTodo2.Text = "Not yet implemented!";
            // 
            // cboSerialOptions
            // 
            cboSerialOptions.FormattingEnabled = true;
            cboSerialOptions.Location = new Point(81, 6);
            cboSerialOptions.Name = "cboSerialOptions";
            cboSerialOptions.Size = new Size(121, 23);
            cboSerialOptions.TabIndex = 0;
            // 
            // lblSerialOptions
            // 
            lblSerialOptions.AutoSize = true;
            lblSerialOptions.Location = new Point(12, 9);
            lblSerialOptions.Name = "lblSerialOptions";
            lblSerialOptions.Size = new Size(63, 15);
            lblSerialOptions.TabIndex = 1;
            lblSerialOptions.Text = "Serial Port:";
            // 
            // lblConnectionStatus
            // 
            lblConnectionStatus.AutoSize = true;
            lblConnectionStatus.Location = new Point(603, 9);
            lblConnectionStatus.Name = "lblConnectionStatus";
            lblConnectionStatus.Size = new Size(88, 15);
            lblConnectionStatus.TabIndex = 2;
            lblConnectionStatus.Text = "Not Connected";
            lblConnectionStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(697, 6);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(84, 23);
            btnConnect.TabIndex = 1;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // BtnRefreshSerialPorts
            // 
            BtnRefreshSerialPorts.Location = new Point(208, 6);
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
            Controls.Add(btnConnect);
            Controls.Add(tabMain);
            Controls.Add(lblConnectionStatus);
            Controls.Add(lblSerialOptions);
            Controls.Add(cboSerialOptions);
            Name = "FrmMainForm";
            Text = "Statimatic STM Testing Suite";
            tabMain.ResumeLayout(false);
            tabSimple.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSimpleLog).EndInit();
            grpSimpleInput.ResumeLayout(false);
            grpSimpleInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSimpleCommandInput).EndInit();
            tabAdvanced.ResumeLayout(false);
            tabAdvanced.PerformLayout();
            tabGraphical.ResumeLayout(false);
            tabGraphical.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabMain;
        private TabPage tabSimple;
        private TabPage tabAdvanced;
        private ComboBox cboSerialOptions;
        private Label lblSerialOptions;
        private Label lblConnectionStatus;
        private TabPage tabGraphical;
        private Label lblTodo1;
        private Label lblTodo2;
        private GroupBox grpSimpleInput;
        private TextBox txtSimpleCommandInput;
        private Label lblSimpleExtraData;
        private ComboBox cboSimpleCommandGroupOptions;
        private Label lblSimpleCommand;
        private Button btnSimpleSendCommand;
        private DataGridView dgvSimpleLog;
        private Button btnSimpleClearLog;
        private DataGridViewTextBoxColumn cmnSimpleTime;
        private DataGridViewTextBoxColumn cmnSimpleSent;
        private DataGridViewTextBoxColumn cmnSimpleReceived;
        private Button btnConnect;
        private ComboBox cboSimpleCommandOptions;
        private NumericUpDown numSimpleCommandInput;
        private ComboBox cboSimpleCommandInput;
        private Button BtnRefreshSerialPorts;
    }
}
