namespace StmTestingSuite
{
    public partial class FrmSensorDataViewer : Form
    {
        public FrmSensorDataViewer()
        {
            InitializeComponent();
        }

        private void FrmSensorDataViewer_SizeChanged(object sender, EventArgs e)
        {
            // Position the X bounds based on the window size
            NumUpper.Location = new Point(this.Size.Width - 84, NumUpper.Location.Y);
            NumLower.Location = new Point(this.Size.Width - 146, NumLower.Location.Y);
            LblBounds.Location = new Point(this.Size.Width - 212, LblBounds.Location.Y);

            // Resize the chart based on the window size
            CrtComparison.Size = new Size(this.Size.Width - 40, this.Size.Height - 92);
        }
    }
}
