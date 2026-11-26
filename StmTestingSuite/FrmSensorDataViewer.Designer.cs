namespace StmTestingSuite
{
    partial class FrmSensorDataViewer
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSensorDataViewer));
            CrtComparison = new System.Windows.Forms.DataVisualization.Charting.Chart();
            LblBounds = new Label();
            BtnAdd = new Button();
            TxtNew = new TextBox();
            CboRemove = new ComboBox();
            BtnRemove = new Button();
            BtnClearAll = new Button();
            NumLower = new NumericUpDown();
            NumUpper = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)CrtComparison).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumLower).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumUpper).BeginInit();
            SuspendLayout();
            // 
            // CrtComparison
            // 
            chartArea1.Name = "ChartArea1";
            CrtComparison.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            CrtComparison.Legends.Add(legend1);
            CrtComparison.Location = new Point(12, 41);
            CrtComparison.Name = "CrtComparison";
            CrtComparison.Size = new Size(776, 397);
            CrtComparison.TabIndex = 0;
            CrtComparison.Text = "Comparison";
            // 
            // LblBounds
            // 
            LblBounds.AutoSize = true;
            LblBounds.Location = new Point(604, 16);
            LblBounds.Name = "LblBounds";
            LblBounds.Size = new Size(60, 15);
            LblBounds.TabIndex = 3;
            LblBounds.Text = "X Bounds:";
            // 
            // BtnAdd
            // 
            BtnAdd.Location = new Point(131, 12);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(39, 23);
            BtnAdd.TabIndex = 7;
            BtnAdd.Text = "Add";
            BtnAdd.UseVisualStyleBackColor = true;
            BtnAdd.Click += BtnAdd_Click;
            // 
            // TxtNew
            // 
            TxtNew.Location = new Point(12, 12);
            TxtNew.Name = "TxtNew";
            TxtNew.Size = new Size(113, 23);
            TxtNew.TabIndex = 8;
            // 
            // CboRemove
            // 
            CboRemove.DropDownStyle = ComboBoxStyle.DropDownList;
            CboRemove.FormattingEnabled = true;
            CboRemove.Location = new Point(197, 11);
            CboRemove.Name = "CboRemove";
            CboRemove.Size = new Size(121, 23);
            CboRemove.TabIndex = 9;
            // 
            // BtnRemove
            // 
            BtnRemove.Enabled = false;
            BtnRemove.Location = new Point(324, 11);
            BtnRemove.Name = "BtnRemove";
            BtnRemove.Size = new Size(61, 23);
            BtnRemove.TabIndex = 10;
            BtnRemove.Text = "Remove";
            BtnRemove.UseVisualStyleBackColor = true;
            BtnRemove.Click += BtnRemove_Click;
            // 
            // BtnClearAll
            // 
            BtnClearAll.Enabled = false;
            BtnClearAll.Location = new Point(391, 10);
            BtnClearAll.Name = "BtnClearAll";
            BtnClearAll.Size = new Size(61, 23);
            BtnClearAll.TabIndex = 11;
            BtnClearAll.Text = "Clear All";
            BtnClearAll.UseVisualStyleBackColor = true;
            BtnClearAll.Click += BtnClearAll_Click;
            // 
            // NumLower
            // 
            NumLower.Location = new Point(670, 13);
            NumLower.Name = "NumLower";
            NumLower.Size = new Size(56, 23);
            NumLower.TabIndex = 12;
            // 
            // NumUpper
            // 
            NumUpper.Location = new Point(732, 13);
            NumUpper.Name = "NumUpper";
            NumUpper.Size = new Size(56, 23);
            NumUpper.TabIndex = 13;
            // 
            // FrmSensorDataViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(NumUpper);
            Controls.Add(NumLower);
            Controls.Add(BtnClearAll);
            Controls.Add(BtnRemove);
            Controls.Add(CboRemove);
            Controls.Add(TxtNew);
            Controls.Add(BtnAdd);
            Controls.Add(LblBounds);
            Controls.Add(CrtComparison);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmSensorDataViewer";
            Text = "Sensor Data Viewer";
            SizeChanged += FrmSensorDataViewer_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)CrtComparison).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumLower).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumUpper).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart CrtComparison;
        private Label LblBounds;
        private Button BtnAdd;
        private TextBox TxtNew;
        private ComboBox CboRemove;
        private Button BtnRemove;
        private Button BtnClearAll;
        private NumericUpDown NumLower;
        private NumericUpDown NumUpper;
    }
}