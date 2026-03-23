using StmTestingSuite.Model.Key;

namespace StmTestingSuite.Model.Com
{
    internal class ComOption(string comName, ModelKey key, string version)
    {
        public string ComName { get; } = comName;

        public ModelKey Key { get; } = key;

        public string Version { get; } = version;

        public string Name 
        { 
            get
            {
                if(Key == ModelKey.NONE) return ComName;
                else
                {
                    return ComName + " - " + KeyName(key) + " (v" + version + ")";
                }
            }
        }

        private static string KeyName(ModelKey key)
        {
            return key switch
            {
                ModelKey.STM_01 => "STM-01",
                _ => ""
            };
        }

        public ComOption(string comName) : this(comName, ModelKey.NONE, "") {}
    }
}
