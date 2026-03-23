using StmTestingSuite.Model.Key;

namespace StmTestingSuite.Model.Com
{
    internal class ComOption(string comName, ModelKey key, string version)
    {
        public string ComName { get; } = comName;

        public ModelKey Key { get; } = key;

        public string Version { get; } = version;

        private string KeyName
        {
            get
            {
                return Key switch
                {
                    ModelKey.STM_01 => "STM-01",
                    _ => ""
                };
            }
        }

        public string Name 
        { 
            get
            {
                if(Key == ModelKey.NONE) return ComName;
                else
                {
                    return ComName + " - " + KeyName + " (v" + Version + ")";
                }
            }
        }

        public ComOption(string comName) : this(comName, ModelKey.NONE, "") {}
    }
}
