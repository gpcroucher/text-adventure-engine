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

        public Thing Drop (Thing thing)
        {
            // remove the thing from pawn inventory and add it to room contents
            location.contents.Insert(personalInventory.Remove(thing));
            thing.location = location;
            return thing;
        }

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
            personalInventory.Insert(location.contents.GetContainerReference(containerName).contents.Remove(thingName));
        }
        public void TakeFrom(Thing thingReference, Container containerReference)
        {
            personalInventory.Insert(containerReference.contents.Remove(thingReference));
        }
        
    }
}
