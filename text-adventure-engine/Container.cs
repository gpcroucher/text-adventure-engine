using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_engine
{
    class Container : Thing
    {
        public Inventory contents;
        public Lock containerLock;

        public new bool isMoveable = false;
        public bool isOpen = false;

        public Container(string inputName, bool newIsMoveable, bool newIsOpen) : base(inputName)
        {
            isMoveable = newIsMoveable;
            isOpen = newIsOpen;
        }

        public Lock AddLock(Thing key, bool isLocked, string name = "lock")
        {
            if (containerLock == null)
            {
                containerLock = new Lock(name, key, isLocked);
                return containerLock;
            }
            else
            {
                return null;
            }
        }

        public bool Lock(Thing key)
        {
            return containerLock.LockWithKey(key);
        }

        public void Open()
        {
            // add lock functionality
            if (isOpen == true)
            {
                Console.WriteLine("That is already open.");
            }
            isOpen = true;
        }

        public void PutIn(Thing thing)
        {
            if (isOpen && !containerLock.IsLocked)
            {
                contents.Insert(thing);
            }
        }

        public Thing TakeFrom(string thingName)
        {
            if (isOpen && !containerLock.IsLocked)
            {
                Thing thingTaken = contents.GetThingReference(thingName);
                contents.Take(thingName);
                return thingTaken;
            }
            else return null;
        }
        public Thing TakeFrom(Thing thing)
        {
            if (isOpen && !containerLock.IsLocked)
            {
                contents.Take(thing.name);
                return thing;
            }
            else return null;
        }

        public bool Unlock(Thing key)
        {
            return containerLock.UnlockWithKey(key);
        }

    }
}
