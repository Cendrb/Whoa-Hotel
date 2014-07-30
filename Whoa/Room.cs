using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whoa
{
    class Room : IEnumerable<Bed>
    {
        List<Bed> beds;
        public int NumberOfBeds { get; private set; }
        public int FreeBeds
        {
            get
            {
                int free = 0;
                foreach(Bed bed in beds)
                {
                    if (!bed.Occupied)
                        free++;
                }
                return free;
            }
        }
        public int OccupiedBeds
        {
            get
            {
                int occupied = 0;
                foreach (Bed bed in beds)
                {
                    if (bed.Occupied)
                        occupied++;
                }
                return occupied;
            }
        }

        public int NumberOfRestrooms { get; set; }
        public int Id { get; private set; }
        public string Description { get; set; }
        public double Surcharge { get; set; }

        public Room(int id)
        {
            NumberOfRestrooms = 1;
            NumberOfBeds = 0;
            Surcharge = 0;
            Id = id;
            beds = new List<Bed>();
        }

        public void AddBed(Bed bed)
        {
            NumberOfBeds++;
            beds.Add(bed);
        }

        public void RemoveBed(Bed bed)
        {
            NumberOfBeds--;
            beds.Remove(bed);
        }

        public override string ToString()
        {
            return String.Format("Room with {0} bed/s and {1} restroom/s ({2})", NumberOfBeds, NumberOfRestrooms, Id);
        }

        public IEnumerator<Bed> GetEnumerator()
        {
            return beds.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return beds.GetEnumerator();
        }
    }
}
