using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_engine
{
    public class Parser
    {
        public List<Command> CommandList;
        public Command CurrentCommand;
        /*
        public void AddCommand (string name, string args)
        {
            int x;
            if (!Int32.TryParse(args, out x))
            {
                return;
            }
            else
            {
                AddCommand(name, x);
            }
        }
        public void AddCommand (string name, int args)
        {
            CommandList.Add(new Command(name, args));
        }
        public void AddCommand (Command command)
        {
            CommandList.Add(command);
        }
        */

        /*
        verbdict = [
            { # 0 arguments
            "look":player.look,
            "help":player.help
            },
            { # 1 argument
            "close":player.close,
            "drop":player.drop,
            "equip":player.operate,
            "flick":player.operate,
            "get":player.take,
            "go":player.go,
            "hit":player.operate,
            "lock":player.lock,
            "look":player.look,
            "open":player.open,
            "press":player.operate,
            "pull":player.operate,
            "push":player.operate,
            "put":player.put,
            "take":player.take,
            "teleport":player.teleport, # FOR TESTING
            "use":player.operate,
            "wear":player.operate, # bit of a hack
            "unlock":player.unlock
},
            { # 2 arguments
            "get":player.take,
            "go":player.go,
            "lock":player.lock,
            "look":player.look,
            "put":player.put,
            "take":player.take,
            "unlock":player.unlock
            }
        ]

        try:
            if len(words) > 2:
                print("Your command had too many words.")
                return
            elif len(words) == 0:
                print("Try typing a command. Type 'help' for a list of commands.")
            if len(words) == 1:
                verbdict[0][words[0]]()
            elif len(words) == 2:
                verbdict[1][words[0]](words[1])
        except:
            print("I didn't understand that.")
            return
            */

    }

    public class Command
    {
        string commandName;
        int expectedArgs;

        public Command(string name, int args)
        {
            commandName = name;
            expectedArgs = args;
        }
    }
}
