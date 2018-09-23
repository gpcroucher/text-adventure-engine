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


        public bool Contains (string thingName)
        {
            return invContents.ContainsKey(thingName);
        }
        public bool Contains<T>(T thingReference) where T : Thing
        {
            return invContents.ContainsValue(thingReference);
        }

        public dynamic GetItemReference (string thingName)
        {
            if (Contains(thingName))
            {
                return invContents[thingName];
            }
            else return null;
        }

        public List<string> GetListOfContents()
        {
            var output = invContents.Keys.ToList();
            output.Sort();
            return output;
        }

        public T Insert<T> (T insertee) where T : Thing
        {
            invContents.Add(insertee.Name, insertee);
            return insertee;
        }
        public T Insert<T> (string alternateName, T insertee) where T : Thing
        {
            invContents.Add(alternateName, insertee);
            return insertee;
        }

        public dynamic Remove (string thingName)
        {
            dynamic removedThing = invContents[thingName];
            invContents.Remove(thingName);
            return removedThing;
        }
        public T Remove<T> (T thingReference) where T : Thing
        {
            invContents.Remove(thingReference.Name);
            return thingReference;
        }
    }
}
