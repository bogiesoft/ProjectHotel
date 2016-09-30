using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotel
{
    class Receptie : Area
    {
        public List<Kamer> kamers; //Lijst met kamers van het hotel
        public List<Gast> wachtrij; //Rij met gasten voor de receptie
        public Gast current; //Geeft de huidige gast bij de receptie aan
        public Receptie()
        {

        }
    }
}
