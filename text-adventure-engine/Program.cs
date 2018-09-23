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

            parser.AddCommand(new Command("report", 2, "Report"));

            parser.AddCommand(new Command("go", 1, "Go"));
            parser.AddCommand(new Command("look", 0, "Look"));

            Pawn.playerPawn = new Pawn("player");
            Pawn.playerPawn.AddToInventory(new Container("box", false, false));

            Floormap level = new Floormap();

            Room testroom = level.AddRoom(new Room("testroom"));
            Container box = testroom.contents.Insert(new Container("box", false, false));
            box.PutIn(new Thing("ball"));

            Pawn.playerPawn.Move(testroom);

            Room westroom = level.AddRoom(new Room("westroom"));
            westroom.verboseDescription = "west room reached";

            new Door("west door", testroom, westroom, "west");

            Pawn.playerPawn.Look();

            parser.GetInput();


            Console.ReadLine();
        }
    }
}
