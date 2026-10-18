using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdSetAddProfileToPlaylist(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.SET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.SET_ADD_PROFILE_TO_PLAYLIST;

        public override string Name => "Add Profile To Playlist";
    }
}
