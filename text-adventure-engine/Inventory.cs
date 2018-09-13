using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_engine
{
    class Inventory
    {
        private Dictionary<string, Thing> invContents;

        public Thing GetThingReference (string thingName)
        {
            return invContents[thingName];
        }

        public void Insert (Thing insertee)
        {
            invContents.Add(insertee.name, insertee);
        }
        public void Insert (string alternateName, Thing insertee)
        {
            invContents.Add(alternateName, insertee);
        }

        public void Take (string thingName)
        {
            Pawn.playerPawn.personalInventory.Insert(Remove(thingName));
        }
        public void Take(Thing thingReference)
        {
            Pawn.playerPawn.personalInventory.Insert(Remove(thingReference));
        }

        public Thing Remove (string thingName)
        {
            Thing removedThing = invContents[thingName];
            invContents.Remove(thingName);
            return removedThing;
        }
        public Thing Remove (Thing thingReference)
        {
            invContents.Remove(thingReference.name);
            return thingReference;
        }
    }
}
