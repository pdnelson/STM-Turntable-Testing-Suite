using StmTestingSuite.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace StmTestingSuite
{
    internal class RecordSensorTabMonitor(
        Form mainForm,
        StmConnector conn,

        // Record sensor data
        Chart crtRecordSensor,
        Label lblSensorValue,
        Label lblSensorLedStatus
    )
    {

        Form Form { get; } = mainForm;
        StmConnector Conn { get; } = conn;

        // Record Sensor
        Chart CrtRecordSensor { get; } = crtRecordSensor;
        Label LblSensorValue { get; } = lblSensorValue;
        Label LblSensorLedStatus { get; } = lblSensorLedStatus;

        public bool Running { get; set; } = false;

        public bool Paused { get; set; } = false;

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
            });
        }
    }
}
