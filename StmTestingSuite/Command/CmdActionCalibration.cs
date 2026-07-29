using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace StmTestingSuite.Command
{
    internal class CmdActionCalibration(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.ACTION;
        public override ExternalCommand ExternalCommandType => ExternalCommand.ACTION_PAUSE_UNPAUSE;
        public override string Name => "Calibrate";
    }
}
