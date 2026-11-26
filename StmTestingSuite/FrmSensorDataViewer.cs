using StmTestingSuite.Model.Command.Group;
using System.Windows.Forms.DataVisualization.Charting;

namespace StmTestingSuite
{
    public partial class FrmSensorDataViewer : Form
    {
        private List<Series> series = [];

        public FrmSensorDataViewer()
        {
            InitializeComponent();
            CboRemove.DataSource = series;
            CboRemove.DisplayMember = "Name";
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (TxtNew.Text != string.Empty)
            {
                var fileContent = Utilities.OpenFile(Constants.CsvFileExtension);

                if (fileContent != string.Empty)
                {
                    var newSeries = new Series
                    {
                        Name = TxtNew.Text
                    };

                    CrtComparison.Series.Add(newSeries);
                    series.Add(newSeries);
                    CboRemove.DataSource = series.ToList();
                    TxtNew.Text = string.Empty;
                    BtnRemove.Enabled = true;
                    BtnClearAll.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("fill in your series name please!!!");
            }
        }

        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            CrtComparison.Series.Clear();
            series.Clear();
            CboRemove.DataSource = series.ToList();
            CboRemove.Text = string.Empty;
            BtnRemove.Enabled = false;
            BtnClearAll.Enabled = false;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            var deleteIndex = CrtComparison.Series.IndexOf(CboRemove.Text);
            series.RemoveAt(deleteIndex);
            CboRemove.DataSource = series.ToList();
            CrtComparison.Series.RemoveAt(deleteIndex);

            if(series.Count == 0)
            {
                BtnRemove.Enabled = false;
                BtnClearAll.Enabled = false;
            }
        }
    }
}
