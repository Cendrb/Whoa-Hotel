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

        public Bed()
        {

        }

        public Bed(Room room)
        {
            Room = room;
        }
    }
}
