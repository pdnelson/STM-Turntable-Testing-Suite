using StmTestingSuite.Model.Command;
using StmTestingSuite.Model.Command.Group;
using StmTestingSuite.Model.Command.Input;
using StmTestingSuite.Model.StmEnum;

namespace StmTestingSuite.Command.Base
{
    abstract class BaseStmCommand
    {
        public abstract StmExternalCommandGroupType GroupType { get; }
        public abstract ExternalCommand ExternalCommandType { get; }
        public abstract StmExternalCommandInputType InputType { get; }
        public abstract string Name { get; }
        public abstract ushort ResponseSize { get; }
        public StmConnector Conn { get; }

        protected BaseStmCommand(StmConnector conn)
        {
            Conn = conn;
        }

        public virtual async Task<IStmCommandResult?> Execute() {
            int dataSize = 2; // key + command
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
            dataToSend[0] = Constants.CommandKey;
            dataToSend[1] = (byte)ExternalCommandType;

            if(inputData is not null)
            {
                for (int i = 2; i < dataToSend.Length; i++)
                {
                    dataToSend[i] = inputData[i - 2];
                }
            }

            var rawData = await Conn.SendCommand(dataToSend, ResponseSize);

            IStmCommandResult? response = null;

            if(ResponseSize > 0 && rawData != null)
            {
                response = InterpretResponseData(rawData);

            }

            Conn.LogCommand(this, response?.ResultString);

            return response;
        }

        public virtual IStmCommandResult InterpretResponseData(byte[]? rawData)
        {
            throw new NotImplementedException("Tried to parse response data, but no implementation was present.");
        }
    }
}
