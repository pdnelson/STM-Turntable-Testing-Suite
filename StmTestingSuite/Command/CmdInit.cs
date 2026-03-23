using StmTestingSuite.Model.Com;
using StmTestingSuite.Model.Key;


namespace StmTestingSuite.Command
{
    /// <summary>
    /// This command is atypical, becuase it isn't allowed to be run like the other commands. This one can only be run
    /// when initializing the connected turntables, and getting all their versions. Once the COM ports have been initialized,
    /// then this cannot be run.
    /// 
    /// </summary>
    /// <param name="conn">The connector instance to connect to a turntable.</param>
    internal class CmdInit(StmConnector conn)
    {
        public StmConnector Conn { get; } = conn;

        public virtual async Task<ComOption?> Execute()
        {
            byte[]? rawData = null;

            try
            {
                rawData = await Conn.SendCommand([], 4);
            } catch(Exception) { /* do nothing */ }

            if (rawData == null) return null;

            short versionMajor = rawData[1];
            short versionMinor = rawData[2];
            short versionPatch = rawData[3];

            string versionString = versionMajor + "." + versionMinor + "." + versionPatch;

            return new ComOption(Conn.PortName, (ModelKey)rawData[0], versionString);
        }
    }
}
