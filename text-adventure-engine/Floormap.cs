using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_engine
{
    class Floormap
    {
        List<Room> roomList = new List<Room>();

        public void AddRoom(Room newRoom)
        {
            roomList.Add(newRoom);
        }

    }
}
