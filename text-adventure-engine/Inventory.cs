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

        public void Insert (Thing insertee)
        {
            invContents.Add(insertee.name, insertee);
        }
        public void Insert (string alternateName, Thing insertee)
        {
            invContents.Add(alternateName, insertee);
        }

        public void Remove (string thingName)
        {
            invContents.Remove(thingName);
        }
        public void Remove (Thing thingReference)
        {
            invContents.Remove(thingReference.name);
        }
    }
}
