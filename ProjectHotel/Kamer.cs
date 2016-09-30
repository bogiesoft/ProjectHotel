using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotel
{
    class Kamer : Area
    {
        public int nummer;
        public bool Ingebruik;
        public bool Schoongemaakt;
        public string Classification { get; set; }
        public Kamer(string SoortKamer, Point Positie, Point Dimensie)
        {
            Classification = SoortKamer;
            Position = Positie;
            Dimension = Dimensie;
        }
    }
}
