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

        public bool Unlock(Thing key)
        {
            return containerLock.UnlockWithKey(key);
        }

    }
}
