using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whoa
{
    class Bed
    {
        public Room Room { get; private set; }
        public MultiBed ParentMultibed { get; set; }
        public bool Bunk { get; set; }
        public bool Occupied { get; private set; }
        public Order OrderedBy { get; private set; }
        public double Surcharge { get; set; }

        public Bed()
        {
            initialize();
        }

        public Bed(Room room)
        {
            initialize();
            Room = room;
        }

        private void initialize()
        {
            Bunk = false;
            Occupied = false;
        }

        public bool Occupy(Order order)
        {
            if (!Occupied)
            {
                OrderedBy = order;
                Occupied = true;
                return true;
            }
            else
                return false;
        }

        public Order Free()
        {
            if (Occupied)
            {
                Order lastOrderedBy = OrderedBy;
                OrderedBy = null;
                Occupied = false;
                return lastOrderedBy;
            }
            else
                return null;
        }

    }
}
