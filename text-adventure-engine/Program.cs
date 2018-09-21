using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace text_adventure_engine
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();

            var report0 = new Command("report", 0, "Report");
            parser.AddCommand(report0);

            var report1 = new Command("report", 1, "Report");
            parser.AddCommand(report1);

            // Define commands here and add to parser.commandList.

            /*
            StreamReader file = new StreamReader("./commands.txt");
            string[] currentLine;
            while (!file.EndOfStream)
            {
                currentLine = file.ReadLine().Split(',');
                parser.AddCommand(currentLine[0],  currentLine[1]);
            }

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");


            // read csv file of commands into a list of Commands
            // parser.AddCommand(command)
            */

            Pawn.playerPawn = new Pawn("player");
            Pawn.playerPawn.personalInventory.Insert(new Container("box", false, false));

            Floormap level = new Floormap();

            Room testroom = level.AddRoom(new Room("testroom"));
            Container box = testroom.contents.Insert(new Container("box", false, false));
            box.PutIn(new Thing("ball"));

            Pawn.playerPawn.location = testroom;

            Room westroom = level.AddRoom(new Room("westroom"));
            westroom.verboseDescription = "west room reached";

            new Door(testroom, westroom, "west");

            Console.WriteLine(testroom.briefDescription);
            Console.WriteLine(testroom.verboseDescription);
            Console.ReadLine();

            Pawn.playerPawn.Go("west");
            Console.WriteLine(Pawn.playerPawn.location.verboseDescription);
            Console.WriteLine(Pawn.playerPawn.location.briefDescription);
            Console.WriteLine(Pawn.playerPawn.location);
            Console.ReadLine();

            parser.GetInput();

            Console.ReadLine();
        }
    }
}
