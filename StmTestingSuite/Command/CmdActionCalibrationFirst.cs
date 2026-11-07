using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdActionCalibrationFirst(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.ACTION;
        public override ExternalCommand ExternalCommandType => ExternalCommand.ACTION_CALIBRATE_FIRST;
        public override string Name => "Calibrate (First)";
    }
}
