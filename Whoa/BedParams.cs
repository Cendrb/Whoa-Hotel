using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whoa
{
    class BedParams : IComparable<BedParams>
    {
        public bool? Multibed { get; set; }
        public bool? Bunk { get; set; }

        public bool Satisfies(Bed bed)
        {
            if (Multibed != null && Multibed != (bed.ParentMultibed != null))
                return false;
            if (Bunk != null && Bunk != bed.Bunk)
                return false;
            return true;
        }

        public int GetDifficulty()
        {
            int difficulty = 0;
            if (Multibed != null)
                difficulty++;
            if (Bunk != null)
                difficulty++;
            return difficulty;
        }

        public int CompareTo(BedParams other)
        {
            return this.GetDifficulty().CompareTo(other.GetDifficulty());
        }
    }
}
