using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_engine
{
    class Door
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
        }
        private Room[] linkedRooms = new Room[2];
        private Lock doorLock = null;

        public Door (Room firstRoom, Room secondRoom, string direction, Lock inLock = null)
        {
            linkedRooms[0] = firstRoom;
            linkedRooms[1] = secondRoom;
            doorLock = inLock;

            firstRoom.exits.Add(direction, this);
            secondRoom.exits.Add(Room.Opposites[direction], this);
        }

        public void ChangeLock (Lock newLock)
        {
            doorLock = newLock;
        }

        public void ChangeName (string newName)
        {
            name = newName;
        }

        public void ChangeRooms (Room leftRoom, Room rightRoom)
        {
            linkedRooms[0] = leftRoom;
            linkedRooms[1] = rightRoom;
        }

        public bool IsLocked()
        {
            if (doorLock != null && doorLock.IsLocked == true)
            {
                return true;
            }
            else return false;
        }

        // returns the side that isn't passed in
        public Room OtherSide(Room thisSide)
        {
            if (linkedRooms[0] == thisSide)
            {
                return linkedRooms[1];
            }
            else return linkedRooms[0];
        }
    }
}
