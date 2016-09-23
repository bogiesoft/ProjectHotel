using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotel
{
    public abstract class Node
    {
        Dictionary<Node, int> buren; //Dictionary met de Buren en de Tijd die het kost om daar naartoe te gaan.
        Gang gang; //Uiteindes van de graph hebben alleen een link naar de vorige node == altijd een gang.
        int tijdsduur;

        public Node()
        {
            buren = new Dictionary<Node, int>();
        }
    }

    public class Kamer : Node
    {
        public Gang gang;
        public string naam;
        public int nummer;
        public bool ingebruik;
        public bool schoongemaakt;

        public Kamer(int nummer)
        {
            this.nummer = nummer;
            naam = "Kamer_" + nummer.ToString();
        }
    }

    public class Gang : Node
    {

        public Dictionary<Node, int> buren;

        public Gang()
        {
            buren = new Dictionary<Node, int>();
        }
    }

    public class Receptie : Node
    {
        public List<Kamer> kamers;

        public Dictionary<Node, int> buren;

        public Receptie(List<Kamer> kamers)
        {
            this.kamers = kamers;
            buren = new Dictionary<Node, int>();
        }
    }

    public class Restaurant : Node
    {
        public Gang gang;
        public int maxklanten;
        public int tijdsduur;
        
        
        public Restaurant()
        {
           
        }
    }

    public class Bioscoop : Node
    {
        public Gang gang;
        public bool draaitfilm;
        public int tijdsduur;
        public Bioscoop()
        {
            tijdsduur = 90;
    }
    }


    public class Fitness : Node
    {
        public Gang gang;
        //tijdsduur bepaald de gast.
    }
    public class Lift : Node
    {
        List<Persoon> mensen; //moeten allemaal verplaatsen als de lift dat doey.

    }

    public class Trap : Node
    {
        public Dictionary<Node, int> buren;

        public Trap()
        {
            buren = new Dictionary<Node, int>();
        }

    }

}
