using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotel
{
    class Restaurant : Area
    {
        public int Capacity { get; set; }

        public Restaurant(int MaxKlanten, Point Positie, Point Dimensie)
        {
            Capacity = MaxKlanten;
            Position = Positie;
            Dimension = Dimensie;
            Tijdsduur = Instellingen.Restaurantduur;
            Afbeelding = Image.FromFile(@"..\..\..\ProjectHotel\Resources\restaurant.png");
        }
    }
}
