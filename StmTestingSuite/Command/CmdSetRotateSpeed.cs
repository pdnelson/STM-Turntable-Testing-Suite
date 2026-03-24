using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdSetRotateSpeed(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.SET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.SET_ROTATE_SPEED;

        public override string Name => "Rotate Speed";
    }
}
