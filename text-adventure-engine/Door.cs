using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_engine
{
    class Door : Thing, ILockable
    {
        protected Room[] linkedRooms = new Room[2];
        public Lock AttachedLock { get; protected set; }
        public bool IsLocked
        {
            get
            {
                if ((bool)AttachedLock?.IsLocked)
                {
                    return true;
                }
                else return false;
            }
        }

        public Door (string name, Room firstRoom, Room secondRoom, string direction, Lock inLock = null) : base(name)
        {
            linkedRooms[0] = firstRoom;
            linkedRooms[1] = secondRoom;
            AttachedLock = inLock;

            IsMovable = false;
            IsTakeable = false;

            firstRoom.exits.Add(direction, this);
            secondRoom.exits.Add(Room.Opposites[direction], this);
        }

        public void ChangeLock (Lock newLock)
        {
            AttachedLock = newLock;
        }

        public void ChangeRooms (Room leftRoom, Room rightRoom)
        {
            linkedRooms[0] = leftRoom;
            linkedRooms[1] = rightRoom;
        }
        
        public void Lock()
        {
            AttachedLock.ForceLock();
        }
        public void Lock(Thing key)
        {
            AttachedLock.LockWithKey(key);
        }

        // Returns the side that isn't passed in.
        public Room OtherSide(Room thisSide)
        {
            if (linkedRooms[0] == thisSide)
            {
                return linkedRooms[1];
            }
            else return linkedRooms[0];
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
