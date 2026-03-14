using System;
using System.Collections.Generic;
using System.Text;

namespace StmTestingSuite.Model.Command.Group
{
    internal class StmExternalCommandGroup
    {
        public StmExternalCommandGroupType Type { get; }
        public string Name { get; }

        public StmExternalCommandGroup(StmExternalCommandGroupType type)
        {
            Type = type;
            Name = "";

            switch(type)
            {
                case StmExternalCommandGroupType.OTHER:
                    Name = "Empty";
                    break;
                case StmExternalCommandGroupType.ACTION:
                    Name = "Action";
                    break;
                case StmExternalCommandGroupType.SET:
                    Name = "Set Value";
                    break;
                case StmExternalCommandGroupType.GET:
                    Name = "Get Value";
                    break;
            }
        }
    }
}
