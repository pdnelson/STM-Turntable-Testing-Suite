using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdSetClearProfile(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.SET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.SET_CLEAR_PROFILE;

        public override string Name => "Clear Profile";
    }
}
