namespace StmTestingSuite
{
    partial class FrmEditCalibration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditCalibration));
            BtnCalSave = new Button();
            BtnCalCancel = new Button();
            LblHMotorPolarity = new Label();
            CboHMotorPolarity = new ComboBox();
            CboHPolarity = new ComboBox();
            LblHPolarity = new Label();
            CboVPolarity = new ComboBox();
            LblVPolarity = new Label();
            LblUpperLimit = new Label();
            NumUpperLimit = new NumericUpDown();
            NumLowerLimit = new NumericUpDown();
            LblLowerLimit = new Label();
            NumHome = new NumericUpDown();
            LblHome = new Label();
            Num7In = new NumericUpDown();
            Lbl7In = new Label();
            Num10In = new NumericUpDown();
            Lbl10In = new Label();
            Num12In = new NumericUpDown();
            Lbl12In = new Label();
            LblScanEnd = new Label();
            NumScanEnd = new NumericUpDown();
            GrpPolarity = new GroupBox();
            GrpVertical = new GroupBox();
            GrpHorizontal = new GroupBox();
            GrpHorizontalEncoder = new GroupBox();
            LblOffset = new Label();
            NumOffset = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)NumUpperLimit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumLowerLimit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumHome).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Num7In).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Num10In).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Num12In).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumScanEnd).BeginInit();
            GrpPolarity.SuspendLayout();
            GrpVertical.SuspendLayout();
            GrpHorizontal.SuspendLayout();
            GrpHorizontalEncoder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumOffset).BeginInit();
            SuspendLayout();
            // 
            // BtnCalSave
            // 
            BtnCalSave.Location = new Point(511, 278);
            BtnCalSave.Name = "BtnCalSave";
            BtnCalSave.Size = new Size(75, 23);
            BtnCalSave.TabIndex = 0;
            BtnCalSave.Text = "Save";
            BtnCalSave.UseVisualStyleBackColor = true;
            BtnCalSave.Click += BtnCalSave_Click;
            // 
            // BtnCalCancel
            // 
            BtnCalCancel.Location = new Point(430, 278);
            BtnCalCancel.Name = "BtnCalCancel";
            BtnCalCancel.Size = new Size(75, 23);
            BtnCalCancel.TabIndex = 1;
            BtnCalCancel.Text = "Cancel";
            BtnCalCancel.UseVisualStyleBackColor = true;
            BtnCalCancel.Click += BtnCalCancel_Click;
            // 
            // LblHMotorPolarity
            // 
            LblHMotorPolarity.AutoSize = true;
            LblHMotorPolarity.Location = new Point(6, 19);
            LblHMotorPolarity.Name = "LblHMotorPolarity";
            LblHMotorPolarity.Size = new Size(97, 15);
            LblHMotorPolarity.TabIndex = 2;
            LblHMotorPolarity.Text = "H-Motor Polarity";
            // 
            // CboHMotorPolarity
            // 
            CboHMotorPolarity.DropDownStyle = ComboBoxStyle.DropDownList;
            CboHMotorPolarity.FormattingEnabled = true;
            CboHMotorPolarity.Location = new Point(6, 37);
            CboHMotorPolarity.Name = "CboHMotorPolarity";
            CboHMotorPolarity.Size = new Size(121, 23);
            CboHMotorPolarity.TabIndex = 3;
            // 
            // CboHPolarity
            // 
            CboHPolarity.DropDownStyle = ComboBoxStyle.DropDownList;
            CboHPolarity.FormattingEnabled = true;
            CboHPolarity.Location = new Point(6, 83);
            CboHPolarity.Name = "CboHPolarity";
            CboHPolarity.Size = new Size(121, 23);
            CboHPolarity.TabIndex = 5;
            CboHPolarity.SelectedIndexChanged += CboHPolarity_SelectedIndexChanged;
            // 
            // LblHPolarity
            // 
            LblHPolarity.AutoSize = true;
            LblHPolarity.Location = new Point(6, 65);
            LblHPolarity.Name = "LblHPolarity";
            LblHPolarity.Size = new Size(61, 15);
            LblHPolarity.TabIndex = 4;
            LblHPolarity.Text = "H-Polarity";
            // 
            // CboVPolarity
            // 
            CboVPolarity.DropDownStyle = ComboBoxStyle.DropDownList;
            CboVPolarity.FormattingEnabled = true;
            CboVPolarity.Location = new Point(6, 131);
            CboVPolarity.Name = "CboVPolarity";
            CboVPolarity.Size = new Size(121, 23);
            CboVPolarity.TabIndex = 7;
            // 
            // LblVPolarity
            // 
            LblVPolarity.AutoSize = true;
            LblVPolarity.Location = new Point(6, 113);
            LblVPolarity.Name = "LblVPolarity";
            LblVPolarity.Size = new Size(59, 15);
            LblVPolarity.TabIndex = 6;
            LblVPolarity.Text = "V-Polarity";
            // 
            // LblUpperLimit
            // 
            LblUpperLimit.AutoSize = true;
            LblUpperLimit.Location = new Point(4, 19);
            LblUpperLimit.Name = "LblUpperLimit";
            LblUpperLimit.Size = new Size(69, 15);
            LblUpperLimit.TabIndex = 8;
            LblUpperLimit.Text = "Upper Limit";
            // 
            // NumUpperLimit
            // 
            NumUpperLimit.Location = new Point(6, 37);
            NumUpperLimit.Maximum = new decimal(new int[] { 1023, 0, 0, 0 });
            NumUpperLimit.Name = "NumUpperLimit";
            NumUpperLimit.Size = new Size(120, 23);
            NumUpperLimit.TabIndex = 9;
            // 
            // NumLowerLimit
            // 
            NumLowerLimit.Location = new Point(8, 87);
            NumLowerLimit.Maximum = new decimal(new int[] { 1023, 0, 0, 0 });
            NumLowerLimit.Name = "NumLowerLimit";
            NumLowerLimit.Size = new Size(120, 23);
            NumLowerLimit.TabIndex = 11;
            // 
            // LblLowerLimit
            // 
            LblLowerLimit.AutoSize = true;
            LblLowerLimit.Location = new Point(6, 69);
            LblLowerLimit.Name = "LblLowerLimit";
            LblLowerLimit.Size = new Size(69, 15);
            LblLowerLimit.TabIndex = 10;
            LblLowerLimit.Text = "Lower Limit";
            // 
            // NumHome
            // 
            NumHome.Location = new Point(8, 37);
            NumHome.Maximum = new decimal(new int[] { 16383, 0, 0, 0 });
            NumHome.Name = "NumHome";
            NumHome.Size = new Size(120, 23);
            NumHome.TabIndex = 13;
            // 
            // LblHome
            // 
            LblHome.AutoSize = true;
            LblHome.Location = new Point(6, 19);
            LblHome.Name = "LblHome";
            LblHome.Size = new Size(40, 15);
            LblHome.TabIndex = 12;
            LblHome.Text = "Home";
            // 
            // Num7In
            // 
            Num7In.Location = new Point(8, 83);
            Num7In.Maximum = new decimal(new int[] { 16383, 0, 0, 0 });
            Num7In.Name = "Num7In";
            Num7In.Size = new Size(120, 23);
            Num7In.TabIndex = 15;
            // 
            // Lbl7In
            // 
            Lbl7In.AutoSize = true;
            Lbl7In.Location = new Point(6, 65);
            Lbl7In.Name = "Lbl7In";
            Lbl7In.Size = new Size(18, 15);
            Lbl7In.TabIndex = 14;
            Lbl7In.Text = "7\"";
            // 
            // Num10In
            // 
            Num10In.Location = new Point(8, 131);
            Num10In.Maximum = new decimal(new int[] { 16383, 0, 0, 0 });
            Num10In.Name = "Num10In";
            Num10In.Size = new Size(120, 23);
            Num10In.TabIndex = 17;
            // 
            // Lbl10In
            // 
            Lbl10In.AutoSize = true;
            Lbl10In.Location = new Point(6, 113);
            Lbl10In.Name = "Lbl10In";
            Lbl10In.Size = new Size(24, 15);
            Lbl10In.TabIndex = 16;
            Lbl10In.Text = "10\"";
            // 
            // Num12In
            // 
            Num12In.Location = new Point(8, 178);
            Num12In.Maximum = new decimal(new int[] { 16383, 0, 0, 0 });
            Num12In.Name = "Num12In";
            Num12In.Size = new Size(120, 23);
            Num12In.TabIndex = 19;
            // 
            // Lbl12In
            // 
            Lbl12In.AutoSize = true;
            Lbl12In.Location = new Point(6, 160);
            Lbl12In.Name = "Lbl12In";
            Lbl12In.Size = new Size(24, 15);
            Lbl12In.TabIndex = 18;
            Lbl12In.Text = "12\"";
            // 
            // LblScanEnd
            // 
            LblScanEnd.AutoSize = true;
            LblScanEnd.Location = new Point(8, 206);
            LblScanEnd.Name = "LblScanEnd";
            LblScanEnd.Size = new Size(55, 15);
            LblScanEnd.TabIndex = 20;
            LblScanEnd.Text = "Scan End";
            // 
            // NumScanEnd
            // 
            NumScanEnd.Location = new Point(8, 224);
            NumScanEnd.Maximum = new decimal(new int[] { 16383, 0, 0, 0 });
            NumScanEnd.Name = "NumScanEnd";
            NumScanEnd.Size = new Size(120, 23);
            NumScanEnd.TabIndex = 21;
            // 
            // GrpPolarity
            // 
            GrpPolarity.Controls.Add(LblHMotorPolarity);
            GrpPolarity.Controls.Add(CboHMotorPolarity);
            GrpPolarity.Controls.Add(LblHPolarity);
            GrpPolarity.Controls.Add(CboHPolarity);
            GrpPolarity.Controls.Add(LblVPolarity);
            GrpPolarity.Controls.Add(CboVPolarity);
            GrpPolarity.Location = new Point(12, 12);
            GrpPolarity.Name = "GrpPolarity";
            GrpPolarity.Size = new Size(139, 260);
            GrpPolarity.TabIndex = 22;
            GrpPolarity.TabStop = false;
            GrpPolarity.Text = "Polarity";
            // 
            // GrpVertical
            // 
            GrpVertical.Controls.Add(LblUpperLimit);
            GrpVertical.Controls.Add(NumUpperLimit);
            GrpVertical.Controls.Add(LblLowerLimit);
            GrpVertical.Controls.Add(NumLowerLimit);
            GrpVertical.Location = new Point(157, 12);
            GrpVertical.Name = "GrpVertical";
            GrpVertical.Size = new Size(139, 260);
            GrpVertical.TabIndex = 23;
            GrpVertical.TabStop = false;
            GrpVertical.Text = "Vertical";
            // 
            // GrpHorizontal
            // 
            GrpHorizontal.Controls.Add(LblHome);
            GrpHorizontal.Controls.Add(NumHome);
            GrpHorizontal.Controls.Add(Lbl7In);
            GrpHorizontal.Controls.Add(NumScanEnd);
            GrpHorizontal.Controls.Add(Num7In);
            GrpHorizontal.Controls.Add(LblScanEnd);
            GrpHorizontal.Controls.Add(Lbl10In);
            GrpHorizontal.Controls.Add(Num12In);
            GrpHorizontal.Controls.Add(Num10In);
            GrpHorizontal.Controls.Add(Lbl12In);
            GrpHorizontal.Location = new Point(302, 12);
            GrpHorizontal.Name = "GrpHorizontal";
            GrpHorizontal.Size = new Size(139, 260);
            GrpHorizontal.TabIndex = 24;
            GrpHorizontal.TabStop = false;
            GrpHorizontal.Text = "Horizontal";
            // 
            // GrpHorizontalEncoder
            // 
            GrpHorizontalEncoder.Controls.Add(LblOffset);
            GrpHorizontalEncoder.Controls.Add(NumOffset);
            GrpHorizontalEncoder.Location = new Point(447, 12);
            GrpHorizontalEncoder.Name = "GrpHorizontalEncoder";
            GrpHorizontalEncoder.Size = new Size(139, 260);
            GrpHorizontalEncoder.TabIndex = 25;
            GrpHorizontalEncoder.TabStop = false;
            GrpHorizontalEncoder.Text = "Horizontal Encoder";
            // 
            // LblOffset
            // 
            LblOffset.AutoSize = true;
            LblOffset.Location = new Point(4, 19);
            LblOffset.Name = "LblOffset";
            LblOffset.Size = new Size(39, 15);
            LblOffset.TabIndex = 22;
            LblOffset.Text = "Offset";
            // 
            // NumOffset
            // 
            NumOffset.Location = new Point(6, 37);
            NumOffset.Maximum = new decimal(new int[] { 16383, 0, 0, 0 });
            NumOffset.Name = "NumOffset";
            NumOffset.Size = new Size(120, 23);
            NumOffset.TabIndex = 23;
            // 
            // FrmEditCalibration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(596, 312);
            Controls.Add(GrpHorizontalEncoder);
            Controls.Add(GrpHorizontal);
            Controls.Add(GrpVertical);
            Controls.Add(GrpPolarity);
            Controls.Add(BtnCalCancel);
            Controls.Add(BtnCalSave);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmEditCalibration";
            Text = "Edit Calibration Values";
            ((System.ComponentModel.ISupportInitialize)NumUpperLimit).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumLowerLimit).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumHome).EndInit();
            ((System.ComponentModel.ISupportInitialize)Num7In).EndInit();
            ((System.ComponentModel.ISupportInitialize)Num10In).EndInit();
            ((System.ComponentModel.ISupportInitialize)Num12In).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumScanEnd).EndInit();
            GrpPolarity.ResumeLayout(false);
            GrpPolarity.PerformLayout();
            GrpVertical.ResumeLayout(false);
            GrpVertical.PerformLayout();
            GrpHorizontal.ResumeLayout(false);
            GrpHorizontal.PerformLayout();
            GrpHorizontalEncoder.ResumeLayout(false);
            GrpHorizontalEncoder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumOffset).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button BtnCalSave;
        private Button BtnCalCancel;
        private Label LblHMotorPolarity;
        private ComboBox CboHMotorPolarity;
        private ComboBox CboHPolarity;
        private Label LblHPolarity;
        private ComboBox CboVPolarity;
        private Label LblVPolarity;
        private Label LblUpperLimit;
        private NumericUpDown NumUpperLimit;
        private NumericUpDown NumLowerLimit;
        private Label LblLowerLimit;
        private NumericUpDown NumHome;
        private Label LblHome;
        private NumericUpDown Num7In;
        private Label Lbl7In;
        private NumericUpDown Num10In;
        private Label Lbl10In;
        private NumericUpDown Num12In;
        private Label Lbl12In;
        private Label LblScanEnd;
        private NumericUpDown NumScanEnd;
        private GroupBox GrpPolarity;
        private GroupBox GrpVertical;
        private GroupBox GrpHorizontal;
        private GroupBox GrpHorizontalEncoder;
        private Label LblOffset;
        private NumericUpDown NumOffset;
    }
}