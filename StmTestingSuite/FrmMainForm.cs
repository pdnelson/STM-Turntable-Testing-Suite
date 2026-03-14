using StmTestingSuite.Model;
using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using System.Data.Common;
using System.IO.Ports;

namespace StmTestingSuite
{
    public partial class FrmMainForm : Form
    {
        StmCommunicator stm = new StmCommunicator();

        public FrmMainForm()
        {
            InitializeComponent();

            // Populate command group list items
            List<StmExternalCommandGroup> groupOptions = new List<StmExternalCommandGroup>();
            foreach (StmExternalCommandGroupType commandGroup in Enum.GetValues(typeof(StmExternalCommandGroupType)))
            {
                groupOptions.Add(new StmExternalCommandGroup(commandGroup));
            }
            cboSimpleCommandGroupOptions.DataSource = groupOptions;
            cboSimpleCommandGroupOptions.DisplayMember = "Name";
            cboSimpleCommandGroupOptions.DropDownStyle = ComboBoxStyle.DropDownList;

            cboSimpleCommandOptions.Enabled = false;

            cboSimpleCommandOptions.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSimpleCommandInput.DropDownStyle = ComboBoxStyle.DropDownList;
            btnSimpleSendCommand.Enabled = false;

            // Initialize COM ports
            cboSerialOptions.DataSource = SerialPort.GetPortNames().ToList();
            cboSerialOptions.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cboSimpleCommandGroupOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            StmExternalCommandGroup? selectedGroup = (StmExternalCommandGroup?)cboSimpleCommandGroupOptions.SelectedValue;
            if (selectedGroup is null) return;

            if (selectedGroup.Type == StmExternalCommandGroupType.OTHER)
            {
                cboSimpleCommandOptions.Enabled = false;
            }
            else
            {
                cboSimpleCommandOptions.Enabled = true;
            }

            // Populate combo box list items based on group selection
            List<StmExternalCommand> commandOptions = new List<StmExternalCommand>();
            foreach (StmExternalCommandType commandType in Enum.GetValues(typeof(StmExternalCommandType)))
            {
                StmExternalCommand newCommand = new StmExternalCommand(commandType);

                if (newCommand.Group.Type == selectedGroup.Type)
                {
                    commandOptions.Add(newCommand);
                }
            }
            cboSimpleCommandOptions.DataSource = commandOptions.OrderBy(x => x.Name).ToList();
            cboSimpleCommandOptions.DisplayMember = "Name";
        }

        private void cboSimpleCommandOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            StmExternalCommand? selectedCommand = (StmExternalCommand?)cboSimpleCommandOptions.SelectedValue;
            if (selectedCommand is null) return;

            txtSimpleCommandInput.Visible = false;
            cboSimpleCommandInput.Visible = false;
            numSimpleCommandInput.Visible = false;

            if (selectedCommand.Input.Type == StmExternalCommandInputType.NONE)
            {
                lblSimpleExtraData.Visible = false;
            }
            else
            {
                lblSimpleExtraData.Text = selectedCommand.Input.Name + ":";
                lblSimpleExtraData.Visible = true;

                switch (selectedCommand.Input.Type)
                {
                    case StmExternalCommandInputType.NUMERIC_INT:
                        numSimpleCommandInput.Value = 0;
                        numSimpleCommandInput.DecimalPlaces = 0;
                        numSimpleCommandInput.Visible = true;
                        break;
                    case StmExternalCommandInputType.NUMERIC_DEC:
                        numSimpleCommandInput.Value = 0;
                        numSimpleCommandInput.DecimalPlaces = 3;
                        numSimpleCommandInput.Visible = true;
                        break;
                    case StmExternalCommandInputType.DROP_DOWN:
                        cboSimpleCommandInput.DataSource = selectedCommand.Input.Options;
                        cboSimpleCommandInput.DisplayMember = "Name";
                        cboSimpleCommandInput.Visible = true;
                        break;
                }
            }
        }

        private void btnSimpleSendCommand_Click(object sender, EventArgs e)
        {
            StmExternalCommand? selectedCommand = (StmExternalCommand?)cboSimpleCommandOptions.SelectedValue;

            if(selectedCommand is not null)
            {
                switch(selectedCommand.Input.Type)
                {
                    case StmExternalCommandInputType.NONE:
                        stm.sendCommand(selectedCommand);
                        break;

                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(stm.IsOpen)
            {
                if(stm.CloseCommunication())
                {
                    lblConnectionStatus.Text = "Not Connected";
                    btnConnect.Text = "Connect";
                    btnSimpleSendCommand.Enabled = false;
                    cboSerialOptions.Enabled = true;
                }
            }
            else
            {
                string? comPort = (string?)cboSerialOptions.SelectedValue;

                if (comPort is not null && stm.OpenCommunication(comPort))
                {
                    lblConnectionStatus.Text = "Connected";
                    btnConnect.Text = "Disconnect";
                    btnSimpleSendCommand.Enabled = true;
                    cboSerialOptions.Enabled = false;
                }
            }
        }
    }
}
