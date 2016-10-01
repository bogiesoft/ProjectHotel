using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotel
{
    class Receptie : Area
    {
        public List<Kamer> Kamers; //Lijst met kamers van het hotel
        public List<Gast> Wachtrij; //Rij met gasten voor de receptie
        public Gast Current; //Geeft de huidige gast bij de receptie aan

        public Receptie(List<Kamer> Kamer, Point Positie, Point Dimensie)
        {
            Kamers = Kamer;
            Position = Positie;
            Dimension = Dimensie;
            Afbeelding = Image.FromFile(@"..\..\..\ProjectHotel\Resources\lobby.png");
        }
    }
}
