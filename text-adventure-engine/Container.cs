using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_engine
{
    class Container : Thing
    {
        private Inventory contents;
        public Inventory Contents
        {
            get
            {
                return contents;
            }
        }
        public Lock containerLock;

        protected bool isOpen;
        public bool IsOpen
        {
            get
            {
                return IsOpen;
            }
        }

        public Container (string inputName, bool newIsMoveable, bool newIsOpen) : base(inputName)
        {
            isMoveable = newIsMoveable;
            isOpen = newIsOpen;
            contents = new Inventory();
        }

        public Lock AddLock (Thing key, bool isLocked, string name = "lock")
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

        public bool Close ()
        {
            if (isOpen == false)
            {
                Console.WriteLine("That is already closed.");
                return false;
            }
            isOpen = false;
            return true;
        }

        public bool Contains (string thing)
        {
            return contents.Contains(thing);
        }
        public bool Contains (Thing thing)
        {
            return contents.Contains(thing);
        }

        public bool Lock (Thing key)
        {

            return containerLock.LockWithKey(key);
        }

        public bool Open ()
        {
            // add lock functionality
            if (isOpen == true)
            {
                Console.WriteLine("That is already open.");
                return false;
            }
            else if (containerLock.IsLocked)
            {
                Console.WriteLine("That is locked.");
                return false;
            }
            isOpen = true;
            return true;
        }

        public void PutIn (Thing thing)
        {
            if (isOpen && !containerLock.IsLocked)
            {
                contents.Insert(thing);
            }
        }
        /*
        public Thing TakeFrom(string thingName)
        {
            if (isOpen && !containerLock.IsLocked)
            {
                Thing thingTaken = contents.GetThingReference(thingName);
                Pawn.playerPawn.Take(thingName);
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
        */
        public bool Unlock(Thing key)
        {
            return containerLock.UnlockWithKey(key);
        }

    }
}
