using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whoa
{
    class MultiBed
    {
        Bed mainBed;
        public Bed MainBed
        {
            get
            {
                return mainBed;
            }
            set
            {
                mainBed = value;
                updateFinalBeds();
            }
        }

        int bedCount;
        public int BedCount
        {
            get
            {
                return bedCount;
            }
            set
            {
                bedCount = value;
                updateFinalBeds();
            }
        }

        public List<Bed> FinalBeds { get; private set; }

        public MultiBed(int bedCount, Bed mainBed)
        {
            FinalBeds = new List<Bed>();
            // Will not invoke updateFinalBeds()
            this.bedCount = bedCount;
            // Will invoke updateFinalBeds()
            MainBed = mainBed;
            if (bedCount < 1)
                throw new InvalidOperationException("Number of beds must be greater than 1");
        }

        private void updateFinalBeds()
        {
            FinalBeds.Clear();
            
        }
    }
}
