namespace StmTestingSuite.Model.StmEnum
{
    abstract class BaseCommandResponse
    {
        public ExternalCommand Type { get; }

        public BaseCommandResponse(ExternalCommand type)
        {
            Type = type;
        }
    }
}
