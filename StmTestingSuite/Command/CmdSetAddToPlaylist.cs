using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdSetAddToPlaylist(StmConnector comm, StmLogger? logger) : BaseStmInputCommand(comm, logger)
    {
        public override string FieldName => "Profile Index";
        public override string? ReadableInputData { get; set; }
        public override byte[]? InputData { get; set; }
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.SET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.SET_ADD_TO_PLAYLIST;

        public override StmExternalCommandInputType InputType => StmExternalCommandInputType.NUMERIC_INT;

        public override string Name => "Add Profile Index To Playlist";
    }
}
