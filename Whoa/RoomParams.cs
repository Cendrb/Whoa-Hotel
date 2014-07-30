using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whoa
{
    class RoomParams
    {
        public int? NumberOfRestrooms { get; set; }
        public int NumberOfBeds { get; set; }

        public List<BedParams> Beds { get; private set; }

        public RoomParams()
        {
            Beds = new List<BedParams>();
        }

        public int GetDifferences(Room room)
        {
            int differences = 0;
            if (NumberOfBeds != null && room.NumberOfBeds < NumberOfBeds)
                return 5000;

            if (NumberOfRestrooms != null && room.NumberOfRestrooms < NumberOfRestrooms)
                    differences++;

            Beds.Sort();
            List<Bed> usedBeds = new List<Bed>();
            foreach (BedParams param in Beds)
            {
                bool satisfies = false;
                foreach(Bed bed in room)
                {
                    if (!usedBeds.Contains(bed) && param.Satisfies(bed))
                    {
                        usedBeds.Add(bed);
                        satisfies = true;
                        break;
                    }
                }
                if (!satisfies)
                    differences++;
            }
            return differences;
        }
    }
}
