using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whoa
{
    class PriceList
    {
        public double BasicBed { get; set; }
        public double MultibedBed { get; set; }
        public double BasicRoom { get; set; }
        public double Restroom { get; set; }

        public double GetPrice(Order order)
        {
            double price = 0;
            foreach (Room room in order.Rooms)
                price += GetPrice(room);
            foreach (Bed bed in order.Beds)
                price += GetPrice(bed);
            price += order.CalculateDiscount();
            return price;
        }

        public double GetPrice(Room room)
        {
            double price = 0;
            foreach (Bed bed in room)
                price += GetPrice(bed);
            for (int remainingRR = room.NumberOfRestrooms; remainingRR > 0; remainingRR--)
                price += Restroom;
            price += room.Surcharge;
            return price;
        }

        public double GetPrice(Bed bed)
        {
            double price = 0;
            if (bed.ParentMultibed != null)
                price += MultibedBed;
            else
                price += BasicBed;
            price += bed.Surcharge;
            return price;
        }
    }
}
