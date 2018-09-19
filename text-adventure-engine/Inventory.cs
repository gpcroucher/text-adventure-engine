using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_engine
{
    class Inventory
    {
        private Dictionary<string, Thing> invContents = new Dictionary<string, Thing>();

        public Container GetContainerReference(string containerName)
        {
            if (invContents.ContainsKey(containerName) && invContents[containerName].GetType() == typeof(Container))
            {
                return (Container)invContents[containerName];
            }
            else return null;
        }

        public Thing GetThingReference (string thingName)
        {
            if (invContents.ContainsKey(thingName))
            {
                return invContents[thingName];
            }
            else return null;
        }

        public Thing Insert (Thing insertee)
        {
            invContents.Add(insertee.name, insertee);
            return insertee;
        }
        public Container Insert (Container insertee)
        {
            invContents.Add(insertee.name, insertee);
            return insertee;
        }
        public void Insert (string alternateName, Thing insertee)
        {
            invContents.Add(alternateName, insertee);
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
