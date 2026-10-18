using StmTestingSuite.Command.Base;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command
{
    internal class CmdSetRemoveFromPlaylist(StmConnector comm, StmLogger? logger) : BaseStmInputCommand(comm, logger)
    {
        public override string FieldName => "Playlist Index";
        public override string? ReadableInputData { get; set; }
        public override byte[]? InputData { get; set; }
        public override StmExternalCommandGroupType GroupType => StmExternalCommandGroupType.SET;

        public override ExternalCommand ExternalCommandType => ExternalCommand.SET_REMOVE_FROM_PLAYLIST;

        public override StmExternalCommandInputType InputType => StmExternalCommandInputType.NUMERIC_INT;

        public override string Name => "Remove Playlist Track By Index";
    }
}
