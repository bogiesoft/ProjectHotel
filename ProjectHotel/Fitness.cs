using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotel
{
    class Fitness : Area
    {
        public Fitness(Point Positie, Point Dimensie)
        {
            Position = Positie;
            Dimension = Dimensie;
            Afbeelding = Image.FromFile(@"..\..\..\ProjectHotel\Resources\fitnesss.png");
        }
    }
}
