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

        public void Start()
        {

        }

        public void Stop()
        {

        }
    }
}
