using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_engine
{
    class Room
    {
        private static List<string> directions = new List<string> { "north", "east", "south", "west" };

        public static void AddDirection (string directionName)
        {
            directions.Add(directionName);
        }

        public string name = "room";
        public Dictionary<string, Door> exits = new Dictionary<string, Door>();
        public List<Thing> contents = new List<Thing>();
        public string verboseDescription;
        public string briefDescription;

        public Room ()
        {
            if (exits.Count == 0)
            {
                briefDescription = $"You are in '{name}'. There are no obvious exits.";
            }
            else
            {
                briefDescription = $"You are in '{name}'. Obvious exits are {string.Join(",", exits.Keys)}.";
            }
            
        }
    }
}
