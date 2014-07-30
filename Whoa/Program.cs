using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whoa
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            RoomManager manager = new RoomManager();
            for (int x = 10; x != 0; x--)
            {
                Room room = new Room(x);
                for (int y = random.Next(1, 4); y != 0; y--)
                {
                    Bed bed = new Bed(room);
                    bed.Bunk = (random.Next(5) == 4);
                    room.AddBed(bed);
                }
                manager.AddRoom(room);
            }
            OrderParams parameters = new OrderParams();
            RoomParams first = new RoomParams();
            first.NumberOfBeds = 2;
            first.NumberOfRestrooms = 1;
            parameters.Rooms.Add(first);
            RoomParams second = new RoomParams();
            second.NumberOfBeds = 3;
            BedParams bedpar1 = new BedParams();
            bedpar1.Bunk = true;
            BedParams bedpar2 = new BedParams();
            bedpar2.Bunk = true;
            second.Beds.Add(bedpar1);
            second.Beds.Add(bedpar2);
            parameters.Rooms.Add(second);
            Order order = manager.GetPossibleOrder(parameters, 0);

            Console.WriteLine();
        }
    }
}
