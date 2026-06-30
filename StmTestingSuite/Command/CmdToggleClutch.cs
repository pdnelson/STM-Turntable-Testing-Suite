using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace StmTestingSuite.Command
{
    internal class CmdToggleClutch(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.ACTION;
        public override ExternalCommand ExternalCommandType => ExternalCommand.ACTION_TOGGLE_CLUTCH;
        public override string Name => "Toggle Clutch";
    }
}
