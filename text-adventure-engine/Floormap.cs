using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure_engine
{
    class Floormap
    {
        protected List<Room> roomList;

        public Floormap()
        {
            roomList = new List<Room>();
        }
        public Floormap(Floormap floormap)
        {
            roomList = floormap.roomList;
        }

        public Room AddRoom(Room newRoom)
        {
            roomList.Add(newRoom);
            return newRoom;
        }

        public Room RemoveRoom(Room roomToBeRemoved)
        {
            roomList.Remove(roomToBeRemoved);
            return roomToBeRemoved;
        }

        public static class MapGenerator // WIP
        {
            struct MapElement
            {
                public MapElement(int inHeight, int inWidth, string inIcon)
                {
                    height = inHeight;
                    width = inWidth;
                    icon = inIcon;
                }
                public int height;
                public int width;
                public string icon;
            }

            public struct Point
            {
                public Point(int inX, int inY)
                {
                    x = inX;
                    y = inY;
                }
                public int x;
                public int y;
            }

            static MapElement RoomMapElement = new MapElement(1, 5, "|@@@|");
            static MapElement HorConnectorMapElement = new MapElement(1, 1, "-");
            static MapElement VerConnectorMapElement = new MapElement(1, 1, "|");
            static MapElement LeftDiagConnectorMapElement = new MapElement(1, 1, @"\");
            static MapElement RightDiagConnectorMapElement = new MapElement(1, 1, "/");

            static public void GenerateFloorplan(Floormap inMap, Room startingRoom, string path = "map.txt")
            {
                Dictionary<Point, Room> roomMatrix = new Dictionary<Point, Room>();

                if (!File.Exists(path))
                {
                    File.Create(path);
                }
                Floormap map = new Floormap(inMap);
                Room currentNode = startingRoom;
                while (map.roomList.Count != 0)
                {
                    // roomMatrix.Join(Traverse)
                }
            }
/*
1 procedure DFS(G, v):
2     label v as explored
3     for all edges e in G.incidentEdges(v) do
4         if edge e is unexplored then
5             w ← G.adjacentVertex(v, e)
6             if vertex w is unexplored then
7                 label e as a discovered edge
8                 recursively call DFS(G, w)
9             else
10               label e as a back edge
*/
            /*
            public static KeyValuePair<Point, Room> Traverse(Room node)
            {

            }
            */





        }

    }
}
