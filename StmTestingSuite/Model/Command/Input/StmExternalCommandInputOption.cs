namespace StmTestingSuite.Model.Command.Input
{
    internal struct StmExternalCommandInputOption
    {
        public string Name { get; }
        public byte Value { get; }

        public StmExternalCommandInputOption(string name, byte value)
        {
            Name = name;
            Value = value;
        }
    }
}
