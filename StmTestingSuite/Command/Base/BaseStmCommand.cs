using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command.Base
{
    abstract class BaseStmCommand(StmConnector conn, StmLogger? logger)
    {
        public abstract StmExternalCommandGroupType GroupType { get; }
        public abstract ExternalCommand ExternalCommandType { get; }
        public virtual StmExternalCommandInputType InputType { get; } = StmExternalCommandInputType.NONE;
        public abstract string Name { get; }
        public virtual ushort ResponseSize { get; } = 0;
        public StmConnector Conn { get; } = conn;
        public StmLogger? Logger { get; } = logger;

        public virtual async Task<IStmCommandResult?> Execute() {
            int dataSize = 1; // command
            byte[]? inputData = null;

            // If it's an input command, check the data size there
            if (this is BaseStmInputCommand command)
            {
                inputData = command.InputData;

                if(inputData is not null)
                {
                    dataSize += inputData.Length;
                }
            }

            byte[] dataToSend = new byte[dataSize];

            // Build the command
            dataToSend[0] = (byte)ExternalCommandType;

            if(inputData is not null)
            {
                for (int i = 1; i < dataToSend.Length; i++)
                {
                    dataToSend[i] = inputData[i - 1];
                }
            }

            var rawData = await Conn.SendCommand(dataToSend, ResponseSize);

            IStmCommandResult? response = null;

            if(ResponseSize > 0 && rawData != null)
            {
                response = InterpretResponseData(rawData);
            }

            Logger?.LogCommand(this, response?.ResultString);

            return response;
        }

        public virtual IStmCommandResult InterpretResponseData(byte[] rawData)
        {
            throw new NotImplementedException("Tried to parse response data, but no implementation was present.");
        }
    }
}
