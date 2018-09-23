using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_engine
{
    class Container : Thing, IHasInventory, ILockable
    {
        public Inventory Contents { get; }
        public Lock AttachedLock { get; private set; }

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
            IsMovable = newIsMoveable;
            isOpen = newIsOpen;
            Contents = new Inventory();
            IntendedType = typeof(Container);
            AttachedLock = text_adventure_engine.Lock.EmptyLock();
        }

        public Lock AddLock (Thing key = null, bool isLocked = false, string name = "lock")
        {
            if (AttachedLock == null)
            {
                AttachedLock = new Lock(name, key, isLocked);
                return AttachedLock;
            }
            else
            {
                return null;
            }
        }

        public void AddToInventory<T>(T item) where T : Thing
        {
            Contents.Insert(item);
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
            return Contents.Contains(thing);
        }
        public bool Contains<T>(T item) where T : Thing
        {
            return Contents.Contains(item);
        }

        public List<string> GetListOfContents()
        {
            return Contents.GetListOfContents();
        }

        public void Lock()
        {
            AttachedLock.ForceLock();
        }
        public void Lock (Thing key)
        {
            AttachedLock.LockWithKey(key);
        }

        public bool Open ()
        {
            // add lock functionality
            if (isOpen == true)
            {
                Console.WriteLine("That is already open.");
                return false;
            }
            else if (AttachedLock.IsLocked)
            {
                Console.WriteLine("That is locked.");
                return false;
            }
            isOpen = true;
            return true;
        }

        public void PutIn (Thing thing)
        {
            if (isOpen && !AttachedLock.IsLocked)
            {
                AddToInventory(thing);
            }
        }

        public dynamic RemoveFromInventory(string itemName)
        {
            return Contents.Remove(itemName);
        }
        public T RemoveFromInventory<T>(T item) where T : Thing
        {
            return Contents.Remove(item);
        }

        public void Unlock()
        {
            AttachedLock.ForceUnlock();
        }
        public void Unlock(Thing key)
        {
            AttachedLock.UnlockWithKey(key);
        }

        

        

        
    }
}
