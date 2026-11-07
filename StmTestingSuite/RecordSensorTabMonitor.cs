using StmTestingSuite.Command;
using System.Windows.Forms.DataVisualization.Charting;

namespace StmTestingSuite
{
    internal class RecordSensorTabMonitor(
        Form mainForm,
        StmConnector conn,
        RecordScanner scanner,

        // Record sensor data
        Chart crtRecordSensor,
        Label lblSensorValue,
        Label lblSensorLedStatus,

        // Progress
        ProgressBar prgScan
    )
    {

        Form Form { get; } = mainForm;
        StmConnector Conn { get; } = conn;
        RecordScanner Scanner { get; } = scanner;

        // Record Sensor
        Chart CrtRecordSensor { get; } = crtRecordSensor;
        Label LblSensorValue { get; } = lblSensorValue;
        Label LblSensorLedStatus { get; } = lblSensorLedStatus;

        // Progress
        ProgressBar PrgScan { get; } = prgScan;

        public bool Running { get; set; } = false;

        public bool Paused { get; set; } = false;

        public ushort HorizontalPosition { get; set; } = 0;

        public void Start()
        {
            var dataCommand = new CmdGetRecordSensorTabData(Conn, null);
            Running = true;

            Task monitoringTask = new(async () =>
            {
                while (Running)
                {
                    if (!Paused)
                    {
                        CmdGetRecordSensorTabData.Response? data = await dataCommand.ExecuteWithResult();

                        if (data != null)
                        {
                            UpdateUserInterface((CmdGetRecordSensorTabData.Response)data);
                        }
                    }

                    await Task.Delay(Constants.RecordSensorTabDataPollMs);
                }
            });

            monitoringTask.Start();
        }

        public void Stop()
        {
            Running = false;
        }

        private void UpdateUserInterface(CmdGetRecordSensorTabData.Response data)
        {
            HorizontalPosition = data.HorizontalPosition;

            Utilities.WriteToUiFromThread(Form, () =>
            {
                // Record Sensor
                CrtRecordSensor.Series[0].Points.Add(data.PhotoDiodeValue);

                if (CrtRecordSensor.Series[0].Points.Count > 100)
                {
                    CrtRecordSensor.Series[0].Points.RemoveAt(0);
                    CrtRecordSensor.ResetAutoValues();
                }

                LblSensorValue.Text = data.PhotoDiodeValue.ToString();

                if (data.HeadshellLEDStatus)
                {
                    LblSensorLedStatus.Text = "ON";
                }
                else
                {
                    LblSensorLedStatus.Text = "OFF";
                }

                if(Scanner.Running)
                {
                    PrgScan.Value = data.HorizontalPosition;
                } else
                {
                    PrgScan.Value = PrgScan.Minimum;
                }
            });
        }
    }
}
