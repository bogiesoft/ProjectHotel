using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotel
{
    class Kamer
    {
        public int MaxKamer { get; set; }
        public bool Ingebruik { get; set; }
        public bool Schoonmaken { get; set; }
        public Kamer()
        {
            MaxKamer = 60;
        }
    }
}
