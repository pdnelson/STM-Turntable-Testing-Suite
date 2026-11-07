using StmTestingSuite.Command;
using StmTestingSuite.Model.StmEnum;
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
        ProgressBar PrgScan { get; } = prgScan;
        public bool Running { get; set; } = false;
        public ushort[] Profile { get; set; } = [];

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

                    // Scan the record
                    await new CmdActionScanRecord(Conn, Logger).Execute();

                    Utilities.WriteToUiFromThread(Form, () =>
                    {
                        PrgScan.Minimum = bounds.Lower;
                        PrgScan.Maximum = bounds.Upper;
                    });

                    await Task.Delay(100);

                    Running = true;

                    // Monitor record scanning
                    while (await new CmdGetCurrentCommand(Conn, null).ExecuteWithResult() != CommandId.NONE && Running)
                    {
                        await Task.Delay(500);
                    }

                    // Grab the record profile and populate data
                    Profile = await new CmdGetRecordProfile(Conn, Logger).ExecuteWithResult();
                    PopulateChart(bounds.Lower, bounds.Upper);

                    // Clear the record profile
                    await new CmdSetClearProfile(Conn, Logger).Execute();

                    // Return the tonearm home
                    await new CmdActionPlayOrReturn(Conn, Logger).Execute();
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
            CrtRawProfile.Series[0].Points.Clear();
        }

        private void PopulateChart(ushort lowerBound, ushort upperBound)
        {
            Utilities.WriteToUiFromThread(Form, () =>
            {
                CrtRawProfile.ChartAreas[0].Axes[0].Minimum = lowerBound;
                CrtRawProfile.ChartAreas[0].Axes[0].Maximum = upperBound;

                for (ushort i = 0; i < Profile.Length; i++)
                {
                    CrtRawProfile.Series[0].Points.AddXY(lowerBound + i, Profile[i]);
                }
            });
        }
    }
}
