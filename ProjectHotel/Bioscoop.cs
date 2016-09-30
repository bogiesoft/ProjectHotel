using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotel
{
    class Bioscoop : Area
    {
        public bool DraaitFilm;
        public int Tijdsduur;

        public Bioscoop(Point Positie, Point Dimensie)
        {
            Position = Positie;
            Dimension = Dimensie;
            tijdsduur = Instellingen.Bioscoopduur;
            Afbeelding = Image.FromFile(@"..\..\..\ProjectHotel\Resources\cinema.png");
        }
    }
}
