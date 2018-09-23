using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_engine
{
    class Pawn : Thing, IHasInventory
    {
        public static Pawn playerPawn;
        public Inventory Contents { get; } = new Inventory();

        public Pawn (string name) : base(name)
        {
            IntendedType = typeof(Pawn);
        }

        // IHasInventory methods

        public void AddToInventory<T>(T item) where T : Thing
        {
            Contents.Insert(item);
        }
        
        public bool Contains(string itemName)
        {
            return Contents.Contains(itemName);
        }
        public bool Contains<T>(T item) where T : Thing
        {
            return Contents.Contains(item);
        }

        public List<string> GetListOfContents()
        {
            return Contents.GetListOfContents();
        }

        public dynamic RemoveFromInventory(string itemName)
        {
            return Contents.Remove(itemName);
        }
        public T RemoveFromInventory<T>(T item) where T : Thing
        {
            return Contents.Remove(item);
        }


        // Commands

        /// <summary>
        /// Remove an object from pawn's inventory and add it to the room contents.
        /// </summary>
        /// <param name="thing">The object to be dropped, passed by reference.</param>
        /// <returns>A reference to the object dropped.</returns>
        public Thing Drop (Thing thing)
        {
            Contents.Remove(thing);
            Location.contents.Insert(thing);
            thing.Move(Location);
            return thing;
        }

        /// <summary>
        /// Attempt to move the pawn in a specified direction. 
        /// Checks the direction exists, there is a door in that direction, the door is unlocked, 
        /// then moves the player to the room on the other side of the door.
        /// </summary>
        /// <param name="direction">The name of the direction to attempt movement in, as a string.</param>
        /// <returns>A string detailing either failure or success.</returns>
        public string Go (string direction)
        {
            if (!Room.Directions.Contains(direction))
            {
                return "That isn't a direction.";
            }
            if (!Location.exits.ContainsKey(direction))
            {
                return "You can't go that way.";
            }
            if (Location.exits[direction].IsLocked)
            {
                return "The door is locked.";
            }
            Location = Location.exits[direction].OtherSide(Location);
            Look();
            return $"You go {direction}.";
        }

        public string Look()
        {
            Console.WriteLine(Location.verboseDescription);
            return Location.verboseDescription;
        }

        public void Report()
        {
            Console.WriteLine("report - 0 args");
        }
        public void Report(string arg1)
        {
            Console.WriteLine("report - 1 arg");
        }
        public void Report(string arg1, string arg2)
        {
            Console.WriteLine("report - 2 args");
        }

        public void Take(string thingName)
        {
            Contents.Insert(Location.contents.Remove(thingName));
        }
        public void Take(Thing thingReference)
        {
            Contents.Insert(Location.contents.Remove(thingReference));
        }
        
        public void TakeFrom(string thingName, string containerName)
        {
            Contents.Insert(Location.contents.GetItemReference(containerName).Contents.Remove(thingName));
        }
        public void TakeFrom<T>(T thingReference, Container containerReference) where T : Thing
        {
            Contents.Insert(containerReference.RemoveFromInventory(thingReference));
        }


    }
}
