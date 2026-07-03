using StmTestingSuite.Command;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.StmEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace StmTestingSuite
{
    internal class AdvancedTabMonitor(
        Form mainForm,
        StmConnector conn,

        // Size
        RadioButton rad7In,
        RadioButton rad10In,
        RadioButton rad12In,
        RadioButton radSizeAuto,

        // Speed
        Label lblSpeedSetting,
        Label lblTargetSpeed,
        Label lblActualSpeed,

        // Positioning
        Label lblVerticalPos,
        Label lblHorizontalPos,
        Label lblLiftStatus,
        Label lblHomeStatus,

        // Current Command
        Label lblCurrCommand,
        Label lblCurrSubCommand,
        Label lblCommandStatus,

        // Statistics
        Label lblUpTime)
    {
        Form Form { get; } = mainForm;
        StmConnector Conn { get; } = conn;

        // Size
        RadioButton Rad7In { get; } = rad7In;
        RadioButton Rad10In { get; } = rad10In;
        RadioButton Rad12In { get; } = rad12In;
        RadioButton RadSizeAuto { get; } = radSizeAuto;

        // Speed
        Label LblSpeedSetting { get; } = lblSpeedSetting;
        Label LblTargetSpeed { get; } = lblTargetSpeed;
        Label LblActualSpeed { get; } = lblActualSpeed;

        // Positioning
        Label LblVerticalPos { get; } = lblVerticalPos;
        Label LblHorizontalPos { get; } = lblHorizontalPos;
        Label LblLiftStatus { get; } = lblLiftStatus;
        Label LblHomeStatus { get; } = lblHomeStatus;

        // Current Command
        Label LblCurrCommand { get; } = lblCurrCommand;
        Label LblCurrSubCommand { get; } = lblCurrSubCommand;
        Label LblCommandStatus { get; } = lblCommandStatus;

        // Statistics
        Label LblUpTime { get; } = lblUpTime;

        private bool Running { get; set; } = false;

        public void Start()
        {
            var dataCommand = new CmdGetAdvancedSuiteData(Conn, null);
            Running = true;

            Task monitoringTask = new(async () =>
            {
                while(Running)
                {
                    CmdGetAdvancedSuiteData.Response? data = await dataCommand.ExecuteWithResult();

                    if(data != null)
                    {
                        UpdateUserInterface((CmdGetAdvancedSuiteData.Response)data);
                    }

                    await Task.Delay(Constants.AdvancedTabDataPollMs);
                }
            });

            monitoringTask.Start();
        }

        public void Stop()
        {
            Running = false;
        }

        private void UpdateUserInterface(CmdGetAdvancedSuiteData.Response data)
        {
            Utilities.WriteToUiFromThread(Form, () =>
            {
                // Size
                Rad7In.Checked = data.SizeSetting == SizeOption.IN_7;
                Rad10In.Checked = data.SizeSetting == SizeOption.IN_10;
                Rad12In.Checked = data.SizeSetting == SizeOption.IN_12;
                RadSizeAuto.Checked = data.SizeSetting == SizeOption.AUTO;

                // Speed
                LblSpeedSetting.Text = data.SpeedSetting.GetString();
                LblTargetSpeed.Text = data.SpeedTarget + " RPM";
                LblActualSpeed.Text = "0.0 RPM";

                // Positioning
                LblVerticalPos.Text = data.VerticalPosition.ToString();
                LblHorizontalPos.Text = data.HorizontalPosition.ToString();
                LblLiftStatus.Text = data.LiftStatus.GetString();
                LblHomeStatus.Text = data.HomeStatus.GetString();

                // Current Command
                LblCurrCommand.Text = data.CommandId.GetString();
                LblCurrSubCommand.Text = data.SubCommandId.GetString();
                LblCommandStatus.Text = data.CommandStatus.GetString();

                // Statistics
                LblUpTime.Text = Utilities.secondsToTimeString(data.UpTimeSeconds);
            });
        }
    }
}
