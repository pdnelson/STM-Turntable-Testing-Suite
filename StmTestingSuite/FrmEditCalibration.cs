using StmTestingSuite.Command;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite
{
    public partial class FrmEditCalibration() : Form
    {
        private StmConnector? Conn;
        private StmLogger? Logger;
        private ConnectionMonitor? ConnMonitor;
        private Action? BeforeClose;

        public FrmEditCalibration(StmConnector conn, StmLogger logger, ConnectionMonitor connMonitor, CmdGetCalibrationValues.Response calibrationValues, Action? beforeClose) : this()
        {
            InitializeComponent();
            Conn = conn;
            Logger = logger;
            ConnMonitor = connMonitor;
            BeforeClose = beforeClose;

            AssignMax(NumUpperLimit, Constants.MaxAnalogValue, calibrationValues.UpperLimit);
            AssignMax(NumLowerLimit, Constants.MaxAnalogValue, calibrationValues.LowerLimit);
            AssignMax(NumHome, Constants.Max14BitEncoderValue, calibrationValues.Home);
            AssignMax(Num7In, Constants.Max14BitEncoderValue, calibrationValues.In7);
            AssignMax(Num10In, Constants.Max14BitEncoderValue, calibrationValues.In10);
            AssignMax(Num12In, Constants.Max14BitEncoderValue, calibrationValues.In12);
            AssignMax(NumScanEnd, Constants.Max14BitEncoderValue, calibrationValues.ScanEnd);
            AssignMax(NumOffset, Constants.Max14BitEncoderValue, calibrationValues.HorizontalOffset);

            List<Polarity> polOptions1 = [Polarity.NORMAL, Polarity.REVERSED];
            List<Polarity> polOptions2 = [Polarity.NORMAL, Polarity.REVERSED];
            List<Polarity> polOptions3 = [Polarity.NORMAL, Polarity.REVERSED];

            CboHMotorPolarity.DataSource = polOptions1;
            CboHPolarity.DataSource = polOptions2;
            CboVPolarity.DataSource = polOptions3;

            CboHMotorPolarity.SelectedItem = calibrationValues.HorizontalMotorPolarity;
            CboHPolarity.SelectedItem = calibrationValues.HorizontalPolarity;
            CboVPolarity.SelectedItem = calibrationValues.VerticalPolarity;
            BeforeClose = beforeClose;
        }

        private void AssignMax(NumericUpDown dest, ushort max, ushort value)
        {
            if (value > max)
            {
                dest.Value = max;
            }
            else
            {
                dest.Value = value;
            }
        }

        private void BtnCalCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCalSave_Click(object sender, EventArgs e)
        {
            if (ConnMonitor == null || Conn == null || Logger == null || BeforeClose == null || CboHMotorPolarity.SelectedItem == null || CboHPolarity.SelectedItem == null || CboVPolarity.SelectedItem == null) return;

            var command = new CmdSetCalibrationValues(Conn, Logger);
            command.UpdateInputData((Polarity)CboHMotorPolarity.SelectedItem, (Polarity)CboHPolarity.SelectedItem, (Polarity)CboVPolarity.SelectedItem, (ushort)NumHome.Value, (ushort)NumUpperLimit.Value, (ushort)NumLowerLimit.Value, (ushort)Num7In.Value, (ushort)Num10In.Value, (ushort)Num12In.Value, (ushort)NumScanEnd.Value, (ushort)NumOffset.Value);

            Utilities.CommandWrapper(ConnMonitor, async () =>
            {
                await command.Execute();

                Utilities.WriteToUiFromThread(this, () =>
                {
                    BeforeClose();
                    Close();
                });
            });
        }
    }
}
