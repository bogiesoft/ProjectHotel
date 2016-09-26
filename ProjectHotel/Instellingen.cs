using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotel
{
    public class Instellingen
    {
        public int Schoonmaakduur { get; set; }
        public int Bioscoopduur { get; set; }
        public int Trapduur { get; set; }
        public int Doodsduur { get; set; }
        public int Restaurantduur { get; set; }
        public int Schoonnoodduur { get; set; }
        public Instellingen()
        {
            Schoonmaakduur = 5;
            Bioscoopduur = 90;
            Trapduur = 2;
            Doodsduur = 10;
            Restaurantduur = 20;
            Schoonnoodduur = 4;
        }
    }
}
