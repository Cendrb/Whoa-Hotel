using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whoa
{
    class RoomManager
    {
        public RoomManager()
        {
            rooms = new List<Room>();
        }

        List<Room> rooms;

        public int FreeBeds
        {
            get
            {
                int freeBeds = 0;
                foreach (Room room in rooms)
                {
                    if (room.FreeBeds > 0)
                        freeBeds += room.FreeBeds;
                }
                return freeBeds;
            }
        }

        public int OccupiedBeds
        {
            get
            {
                int occupiedBeds = 0;
                foreach (Room room in rooms)
                {
                    if (room.FreeBeds > 0)
                        occupiedBeds += room.OccupiedBeds;
                }
                return occupiedBeds;
            }
        }

        public int TotalBeds
        {
            get
            {
                int beds = 0;
                foreach (Room room in rooms)
                {
                    if (room.FreeBeds > 0)
                        beds += room.NumberOfBeds;
                }
                return beds;
            }
        }

        public Order GetPossibleOrder(OrderParams parameters, int tolerance)
        {
            if (parameters.RequiredBeds > FreeBeds)
                return null;

            List<Room> occupiedRooms = new List<Room>();
            List<Room> choosenRooms = new List<Room>();
            foreach (RoomParams param in parameters.Rooms)
            {
                List<KeyValuePair<int, Room>> availableRooms = new List<KeyValuePair<int, Room>>();
                foreach (Room room in rooms)
                {
                    if (!occupiedRooms.Contains(room) && !choosenRooms.Contains(room))
                    {
                        int differences = param.GetDifferences(room);
                        if (differences <= tolerance)
                        {
                            occupiedRooms.Add(room);
                            availableRooms.Add(new KeyValuePair<int, Room>(differences, room));
                        }
                    }
                }
                if (availableRooms.Count > 0)
                {
                    availableRooms.Sort();
                    choosenRooms.Add(availableRooms.First().Value);
                }
            }
            return new Order(choosenRooms, new List<Bed>());
        }

        public void AddRoom(Room room)
        {
            rooms.Add(room);
        }

        public void RemoveRoom(Room room)
        {
            rooms.Remove(room);
        }
    }
}
