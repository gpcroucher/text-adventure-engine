using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_engine
{
    public class Parser
    {
        private Dictionary<string, Dictionary<int, Command>> commandList = new Dictionary<string, Dictionary<int, Command>>();
        public Dictionary<string, Dictionary<int, Command>> CommandList
        {
            get
            {
                return commandList;
            }
        }

        public Command currentCommand;

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
            */

        public void AddCommand (Command newCommand)
        {
            // If commandList already contains an entry of the same name...
            if (commandList.ContainsKey(newCommand.commandName))
            {
                // ...then add an entry therein with the key as expectedArgs.
                commandList[newCommand.commandName].Add(newCommand.expectedArgs, newCommand);
            }
            else
            {
                // Else, add the command to commandList, noting name and expectedArgs.
                var newEntry = new Dictionary<int, Command>
                {
                    { newCommand.expectedArgs, newCommand }
                };
                commandList.Add(newCommand.commandName, newEntry);
            }
        }

        public void GetInput()
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            Console.WriteLine(ParseInput(input));
            GetInput();
        }

        // TODO: add support for manipulating multiple objects, eg "drop clock, box, spoon"
        public string ParseInput (string inputText)
        {
            List<string> inputList = inputText.Split(' ').ToList();
            // Remove all instances of prepositions, conjunctions etc.
            // TODO replace the inline list here with a static member in Parser.
            inputList.RemoveAll(r => new List<string>() { "as", "with", "on", "to" }.Contains(r));
            string commandName = inputList[0];
            string objectName = null;
            string auxiliaryName = null;
            if (inputList.Count >= 3)
            {
                objectName = inputList[1];
                auxiliaryName = inputList[2];
            }
            else if (inputList.Count >= 2)
            {
                objectName = inputList[1];
            }
            var argsCount = inputList.Count - 1;
            Dictionary<int, Command> matchingCommands;
            Command matchedCommand;

            if (commandList.ContainsKey(commandName))
            {
                matchingCommands = commandList[commandName];
            }
            else
            {
                return "I don't know that command.";
            }

            if (matchingCommands.ContainsKey(argsCount))
            {
                matchedCommand = matchingCommands[argsCount];
            }
            else
            {
                return "That command didn't have the right number of arguments.";
            }

            // Depending on the number of arguments given, execute the function given with the arguments given.
            switch (argsCount)
            {
                case 0:
                    typeof(Pawn).GetMethod(matchedCommand.methodName, new Type[0])
                        .Invoke(Pawn.playerPawn, null);
                    break;
                case 1:
                    typeof(Pawn).GetMethod(matchedCommand.methodName, new Type[] { typeof(string) })
                        .Invoke(Pawn.playerPawn, new[] { objectName });
                    break;
                case 2:
                    typeof(Pawn).GetMethod(matchedCommand.methodName, new Type[] { typeof(string), typeof(string) })
                        .Invoke(Pawn.playerPawn, new[] { objectName, auxiliaryName });
                    break;
                default:
                    return "That command had too many arguments.";
            }

            return "";

        }
    }

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
