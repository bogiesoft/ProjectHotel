using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotel
{
    public abstract class Persoon
    {
        public Node locatie;

        
    }

    public class Gast : Persoon
    {
        public Kamer kamer;
        public int fitnesstijd;

        public Gast()
        {
            locatie = null;
            kamer = null;
        }

        public void PrintPath()
        {
            DijkstraNode start = new DijkstraNode(locatie);
            start.afstand = 0;
            Console.WriteLine(start.Dijkstra(start, new DijkstraNode(kamer)));
        }
    }

    public class Schoonmaker : Persoon
    {

    }
}
