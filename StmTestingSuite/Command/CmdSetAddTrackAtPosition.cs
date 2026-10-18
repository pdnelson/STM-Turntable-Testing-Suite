using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdSetAddTrackAtPosition(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.SET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.SET_ADD_TRACK_AT_POSITION;

        public override string Name => "Add Profile Track At Position";
    }
}
