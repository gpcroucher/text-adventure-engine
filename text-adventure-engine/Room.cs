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
        public static List<string> Directions
        {
            get
            {
                return directions;
            }
        }
        private static Dictionary<string, string> opposites = new Dictionary<string, string>
        {
            { "north", "south" },
            { "east", "west" },
            { "south", "north" },
            { "west", "east" }
        };
        public static Dictionary<string, string> Opposites
        {
            get
            {
                return opposites;
            }
        }

        // Defines a new pair of directions to be available for all doors. 
        public static void AddDirection (string directionName, string opposite)
        {
            directions.Add(directionName);
            directions.Add(opposite);
            opposites.Add(directionName, opposite);
            opposites.Add(opposite, directionName);
        }

        private string name = "room";
        public string Name
        {
            get
            {
                return name;
            }
        }
        public Dictionary<string, Door> exits = new Dictionary<string, Door>();
        public Inventory contents = new Inventory();
        public string verboseDescription;
        public string briefDescription;

        public Room (string setName)
        {
            name = setName;

            if (exits.Count == 0)
            {
                briefDescription = $"You are in '{name}'. There are no obvious exits.";
            }
            else
            {
                briefDescription = $"You are in '{name}'. Obvious exits are {string.Join(",", exits.Keys)}.";
            }
            verboseDescription = briefDescription;
        }

        public void ChangeName (string newName)
        {
            name = newName;
        }
    }
}
