using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

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

        public void PrintPath(Node bestemming)
        {
            DijkstraNode start = new DijkstraNode(locatie);
            start.afstand = 0;
            Console.WriteLine(start.Dijkstra(start, bestemming));
            locatie = bestemming;
        }

        public void DoStuff()
        {
            Timer aTimer = new Timer(1000 * 10 * 1);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("Timer Test:");
            PrintPath(kamer);
        }
    }

    public class Schoonmaker : Persoon
    {

    }
}
