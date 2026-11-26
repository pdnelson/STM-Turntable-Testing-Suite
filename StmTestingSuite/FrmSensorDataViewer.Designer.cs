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
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSensorDataViewer));
            CrtComparison = new System.Windows.Forms.DataVisualization.Charting.Chart();
            contextMenuStrip1 = new ContextMenuStrip(components);
            LblBounds = new Label();
            contextMenuStrip2 = new ContextMenuStrip(components);
            TxtLowerBound = new TextBox();
            TxtUpperBound = new TextBox();
            BtnAdd = new Button();
            TxtNew = new TextBox();
            CboRemove = new ComboBox();
            BtnRemove = new Button();
            BtnClearAll = new Button();
            ((System.ComponentModel.ISupportInitialize)CrtComparison).BeginInit();
            SuspendLayout();
            // 
            // CrtComparison
            // 
            chartArea2.Name = "ChartArea1";
            CrtComparison.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            CrtComparison.Legends.Add(legend2);
            CrtComparison.Location = new Point(12, 41);
            CrtComparison.Name = "CrtComparison";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            CrtComparison.Series.Add(series2);
            CrtComparison.Size = new Size(776, 397);
            CrtComparison.TabIndex = 0;
            CrtComparison.Text = "Comparison";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // LblBounds
            // 
            LblBounds.AutoSize = true;
            LblBounds.Location = new Point(604, 13);
            LblBounds.Name = "LblBounds";
            LblBounds.Size = new Size(60, 15);
            LblBounds.TabIndex = 3;
            LblBounds.Text = "X Bounds:";
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            // 
            // TxtLowerBound
            // 
            TxtLowerBound.Location = new Point(670, 10);
            TxtLowerBound.Name = "TxtLowerBound";
            TxtLowerBound.Size = new Size(56, 23);
            TxtLowerBound.TabIndex = 5;
            // 
            // TxtUpperBound
            // 
            TxtUpperBound.Location = new Point(732, 11);
            TxtUpperBound.Name = "TxtUpperBound";
            TxtUpperBound.Size = new Size(56, 23);
            TxtUpperBound.TabIndex = 6;
            // 
            // BtnAdd
            // 
            BtnAdd.Location = new Point(131, 12);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(39, 23);
            BtnAdd.TabIndex = 7;
            BtnAdd.Text = "Add";
            BtnAdd.UseVisualStyleBackColor = true;
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
            CboRemove.FormattingEnabled = true;
            CboRemove.Location = new Point(197, 11);
            CboRemove.Name = "CboRemove";
            CboRemove.Size = new Size(121, 23);
            CboRemove.TabIndex = 9;
            // 
            // BtnRemove
            // 
            BtnRemove.Location = new Point(324, 11);
            BtnRemove.Name = "BtnRemove";
            BtnRemove.Size = new Size(61, 23);
            BtnRemove.TabIndex = 10;
            BtnRemove.Text = "Remove";
            BtnRemove.UseVisualStyleBackColor = true;
            // 
            // BtnClearAll
            // 
            BtnClearAll.Location = new Point(391, 10);
            BtnClearAll.Name = "BtnClearAll";
            BtnClearAll.Size = new Size(61, 23);
            BtnClearAll.TabIndex = 11;
            BtnClearAll.Text = "Clear All";
            BtnClearAll.UseVisualStyleBackColor = true;
            // 
            // FrmSensorDataViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnClearAll);
            Controls.Add(BtnRemove);
            Controls.Add(CboRemove);
            Controls.Add(TxtNew);
            Controls.Add(BtnAdd);
            Controls.Add(TxtUpperBound);
            Controls.Add(TxtLowerBound);
            Controls.Add(LblBounds);
            Controls.Add(CrtComparison);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmSensorDataViewer";
            Text = "Sensor Data Viewer";
            SizeChanged += FrmSensorDataViewer_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)CrtComparison).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart CrtComparison;
        private ContextMenuStrip contextMenuStrip1;
        private Label LblBounds;
        private ContextMenuStrip contextMenuStrip2;
        private TextBox TxtLowerBound;
        private TextBox TxtUpperBound;
        private Button BtnAdd;
        private TextBox TxtNew;
        private ComboBox CboRemove;
        private Button BtnRemove;
        private Button BtnClearAll;
    }
}