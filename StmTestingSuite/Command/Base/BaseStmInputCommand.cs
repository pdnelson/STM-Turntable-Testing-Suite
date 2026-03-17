namespace StmTestingSuite.Command.Base
{
    abstract class BaseStmInputCommand(StmConnector comm, StmLogger? logger) : BaseStmCommand(comm, logger)
    {
        public abstract string FieldName { get; }
        public abstract string? ReadableInputData { get; set; }
        public abstract byte[]? InputData { get; set; }
        public void UpdateInputData(string readableData, byte[] rawData)
        {
            ReadableInputData = readableData;
            InputData = rawData;
        }

        public void UpdateInputData(UInt16 readableData)
        {
            ReadableInputData = readableData.ToString();
            InputData = BitConverter.GetBytes(readableData);
        }

        public void UpdateInputData(float readableData)
        {
            ReadableInputData = readableData.ToString();
            InputData = BitConverter.GetBytes(readableData);
        }
    }
}
