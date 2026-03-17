using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdPauseUnpause(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.ACTION;
        public override ExternalCommand ExternalCommandType => ExternalCommand.ACTION_PAUSE_UNPAUSE;
        public override StmExternalCommandInputType InputType => StmExternalCommandInputType.NONE;
        public override string Name => "Pause/Unpause";
        public override ushort ResponseSize => 0;
    }
}
