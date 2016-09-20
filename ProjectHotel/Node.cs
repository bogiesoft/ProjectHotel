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

        public Node()
        {
            buren = new Dictionary<Node, int>();
        }
    }

    public class Kamer : Node
    {
        public Gang gang;

        public Kamer()
        {
            
        }
    }

    public class Gang : Node
    {
        public Dictionary<Node, int> buren;

        public Gang() : base()
        {

        }
    }

    public class Restaurant : Node
    {
        public Gang gang;
        
        
        public Restaurant()
        {
           
        }
    }

    public class Lift : Node
    {
        List<Persoon> mensen; //moeten allemaal verplaatsen als de lift dat doey.

    }

    public class Trap : Node
    {
        public Dictionary<Node, int> buren;

        public Trap() : base()
        {

        }

    }

}
