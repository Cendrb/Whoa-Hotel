using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whoa
{
    class OrderParams
    {
        public List<RoomParams> Rooms { get; private set; }

        public OrderParams()
        {
            Rooms = new List<RoomParams>();
        }

        public int RequiredBeds
        {
            get
            {
                int beds = 0;
                foreach (RoomParams room in Rooms)
                    beds += room.NumberOfBeds;
                return beds;
            }
        }
    }
}
