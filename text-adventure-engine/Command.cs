using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_engine
{
    public class Command
    {
        public string commandName;
        public int expectedArgs;
        public string methodName;

        public Command(string name, int args, string method)
        {
            commandName = name;
            expectedArgs = args;
            methodName = method;
        }
    }
}
