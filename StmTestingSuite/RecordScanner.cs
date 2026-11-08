using StmTestingSuite.Command;
using StmTestingSuite.Model.StmEnum;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace StmTestingSuite
{
    internal class RecordScanner(
        Form mainForm, 
        StmConnector conn, 
        ConnectionMonitor connMonitor,
        StmLogger logger,
        Chart crtRawProfile,
        Button btnScan,
        Button btnClear,
        Button btnExport,
        ProgressBar prgScan
        )
    {
        Form Form { get; } = mainForm;
        StmConnector Conn { get; } = conn;
        ConnectionMonitor ConnMonitor { get; } = connMonitor;
        StmLogger Logger { get; } = logger;
        Chart CrtRawProfile { get; } = crtRawProfile;
        Button BtnScan { get; } = btnScan;
        Button BtnClear { get; } = btnClear;
        Button BtnExport { get; } = btnExport;
        ProgressBar PrgScan { get; } = prgScan;
        public bool Running { get; set; } = false;
        public ushort[] Profile { get; set; } = [];
        public ushort LowerBound { get; set; } = 0;
        public ushort UpperBound { get; set; } = 0;

        public void Scan()
        {
            Clear();
            BtnScan.Enabled = false;
            BtnClear.Enabled = false;

            Utilities.CommandWrapper(ConnMonitor, async () =>
            {
                // Get the upper/lower bounds
                var nullBounds = await new CmdGetRecordProfileBounds(Conn, Logger).ExecuteWithResult();

                if(nullBounds != null)
                {
                    CmdGetRecordProfileBounds.Response bounds = (CmdGetRecordProfileBounds.Response)nullBounds;

                    LowerBound = bounds.Lower;
                    UpperBound = bounds.Upper;

                    // Scan the record
                    await new CmdActionScanRecord(Conn, Logger).Execute();

                    Utilities.WriteToUiFromThread(Form, () =>
                    {
                        PrgScan.Minimum = bounds.Lower;
                        PrgScan.Maximum = bounds.Upper;
                    });

                    await Task.Delay(100);

                    Running = true;

                    CommandId? lastCommand = CommandId.SCAN_RECORD;

                    // Monitor record scanning
                    while (lastCommand == CommandId.SCAN_RECORD && Running)
                    {
                        await Task.Delay(100);

                        lastCommand = await new CmdGetCurrentCommand(Conn, null).ExecuteWithResult();
                    }

                    if(lastCommand == CommandId.ERROR)
                    {
                        MessageBox.Show("Failed to scan the record.", "Scan Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    } else
                    {
                        // Grab the record profile and populate data
                        Profile = await new CmdGetRecordProfile(Conn, Logger).ExecuteWithResult();
                        PopulateChart();

                        Utilities.WriteToUiFromThread(Form, () =>
                        {
                            BtnExport.Enabled = true;
                        });

                        // Clear the record profile
                        await new CmdSetClearProfile(Conn, Logger).Execute();

                        // Return the tonearm home
                        await new CmdActionPlayOrReturn(Conn, Logger).Execute();
                    }
                } 
                else
                {
                    MessageBox.Show("Failed to acquire the record profile's upper and lower bounds.", "Scan Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                Utilities.WriteToUiFromThread(Form, () =>
                {
                    BtnScan.Enabled = true;
                    BtnClear.Enabled = true;
                });
                Running = false;
            });
        }

        public void Cancel()
        {
            Running = false;
        }

        public void Clear()
        {
            Profile = [];
            LowerBound = 0;
            UpperBound = 0;
            BtnExport.Enabled = false;
            CrtRawProfile.Series[0].Points.Clear();
        }

        private void PopulateChart()
        {
            Utilities.WriteToUiFromThread(Form, () =>
            {
                CrtRawProfile.ChartAreas[0].Axes[0].Minimum = LowerBound;
                CrtRawProfile.ChartAreas[0].Axes[0].Maximum = UpperBound;

                for (ushort i = 0; i < Profile.Length; i++)
                {
                    CrtRawProfile.Series[0].Points.AddXY(LowerBound + i, Profile[i]);
                }
            });
        }

        public void Export()
        {
            StringBuilder csvString = new StringBuilder();

            for (ushort i = 0; i < Profile.Length; i++)
            {
                csvString.Append($"{LowerBound + i},{Profile[i]}\n");
            }

            Utilities.SaveStringBuilderToFile(csvString, Constants.CsvFileExtension);
        }
    }
}
