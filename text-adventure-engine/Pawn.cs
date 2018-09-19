using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_engine
{
    class Pawn
    {
        public static Pawn playerPawn;

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
        }
        public Room location;
        public Inventory personalInventory = new Inventory();

        public Pawn (string Name)
        {
            name = Name;
        }

        /// <summary>
        /// Remove an object from pawn's inventory and add it to the room contents.
        /// </summary>
        /// <param name="thing">The object to be dropped, passed by reference.</param>
        /// <returns>A reference to the object dropped.</returns>
        public Thing Drop (Thing thing)
        {
            location.contents.Insert(personalInventory.Remove(thing));
            thing.location = location;
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
            if (!location.exits.ContainsKey(direction))
            {
                return "You can't go that way.";
            }
            if (location.exits[direction].IsLocked())
            {
                return "The door is locked.";
            }
            location = location.exits[direction].OtherSide(location);
            return $"You go {direction}.";
        }

        public void Take(string thingName)
        {
            personalInventory.Insert(location.contents.Remove(thingName));
        }
        public void Take(Thing thingReference)
        {
            personalInventory.Insert(location.contents.Remove(thingReference));
        }
        
        public void TakeFrom(string thingName, string containerName)
        {
            personalInventory.Insert(location.contents.GetContainerReference(containerName).Contents.Remove(thingName));
        }
        public void TakeFrom(Thing thingReference, Container containerReference)
        {
            personalInventory.Insert(containerReference.Contents.Remove(thingReference));
        }
        
    }
}
