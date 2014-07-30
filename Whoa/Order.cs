using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whoa
{
    class Order
    {
        public Customer Customer { get; set; }

        public List<Bed> Beds { get; private set; }
        public List<Room> Rooms { get; private set; }

        public double CalculateDiscount()
        {
            return 0;
        }

        public Order(List<Room> rooms, List<Bed> beds)
        {
            Beds = beds;
            Rooms = rooms;
        }
    }
}
