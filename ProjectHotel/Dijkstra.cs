using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotel
{
    /// <summary>
    /// Een klasse om de dijkstra *TIJDELIJK* neer te zetten en aan te passen aan de situatie van het hotel.
    /// Dit is de Dijkstra van de les, in principe kunnen we die bij de node klasse toevoegen... wel aangepast ofc.
    /// 
    /// Notes:  - Dijkstra gaat alle nodes 1x langs... de afstand wordt op Int32.MaxValue gezet maar dat kan natuurlijk niet in dit geval...
    ///         - Bij het switchen van "deze" bij de Dijkstra, kan je ook een vorige onthouden (vorige = deze; deze = ...) zodat je alle buren van de nieuwe "deze" kan toevoegen
    ///           en dan die vorige van de lijst af kan halen..
    /// </summary>
    class Dijkstra
    {
        //static void Main(string[] args)
        //{
        //    GraphOne();
        //    GraphTwo();
        //    GraphThree();
        //}

        //static void GraphOne()
        //{
        //    Knoop begin = new Knoop("Begin");
        //    Knoop eind = new Knoop("Eind");
        //    Knoop a = new Knoop("A");
        //    Knoop b = new Knoop("B");
        //    Knoop c = new Knoop("C");
        //    Knoop e = new Knoop("E");

        //    begin.afstand = 0;

        //    begin.buren.Add(a, 3);
        //    begin.buren.Add(c, 2);
        //    begin.buren.Add(b, 6);
        //    a.buren.Add(e, 2);
        //    a.buren.Add(eind, 6);
        //    b.buren.Add(eind, 1);
        //    c.buren.Add(e, 4);
        //    e.buren.Add(eind, 3);

        //    string Pad = begin.Dijkstra(begin, eind);
        //    Console.WriteLine(Pad);
        //    Console.WriteLine();
        //    Console.ReadKey();
        //}

        //static void GraphTwo()
        //{
        //    Knoop begin = new Knoop("Begin");
        //    Knoop eind = new Knoop("Eind");
        //    Knoop a = new Knoop("A");
        //    Knoop b = new Knoop("B");
        //    Knoop c = new Knoop("C");
        //    Knoop d = new Knoop("D");
        //    Knoop e = new Knoop("E");
        //    Knoop f = new Knoop("F");
        //    Knoop g = new Knoop("G");

        //    begin.afstand = 0;
        //    begin.buren.Add(a, 1);
        //    begin.buren.Add(b, 4);
        //    begin.buren.Add(c, 5);
        //    a.buren.Add(d, 7);
        //    b.buren.Add(c, 2);
        //    b.buren.Add(d, 5);
        //    c.buren.Add(e, 4);
        //    d.buren.Add(f, 3);
        //    e.buren.Add(eind, 8);
        //    f.buren.Add(g, 2);
        //    g.buren.Add(e, 3);
        //    g.buren.Add(eind, 1);

        //    string Pad = begin.Dijkstra(begin, eind);
        //    Console.WriteLine(Pad);
        //    Console.WriteLine();
        //    Console.ReadKey();
        //}

        //static void GraphThree()
        //{
        //    Knoop begin = new Knoop("Begin");
        //    Knoop eind = new Knoop("Eind");
        //    Knoop a = new Knoop("A");
        //    Knoop b = new Knoop("B");
        //    Knoop c = new Knoop("C");
        //    Knoop d = new Knoop("D");
        //    Knoop e = new Knoop("E");
        //    Knoop f = new Knoop("F");
        //    Knoop g = new Knoop("G");

        //    begin.afstand = 0;
        //    begin.buren.Add(a, 3);
        //    begin.buren.Add(b, 6);
        //    begin.buren.Add(c, 2);
        //    a.buren.Add(d, 3);
        //    a.buren.Add(e, 4);
        //    b.buren.Add(d, 1);
        //    c.buren.Add(e, 6);
        //    d.buren.Add(f, 4);
        //    d.buren.Add(eind, 12);
        //    e.buren.Add(d, 2);
        //    e.buren.Add(g, 9);
        //    f.buren.Add(g, 4);
        //    g.buren.Add(d, 4);
        //    g.buren.Add(eind, 5);

        //    string Pad = begin.Dijkstra(begin, eind);
        //    Console.WriteLine(Pad);
        //    Console.WriteLine();
        //    Console.ReadKey();
        //}
    }

    public class Knoop
    {
        public Dictionary<Knoop, int> buren; //Lijst met buren en de afstand naar die buren.
        public int afstand; //Afstand vanaf <X> naar <this>.
        public Knoop vorige; // ?? Gebruikt bij stappen bijhouden. ??
        public string naam; //Naam van de Knoop.

        //Lijst voor het kortste pad
        //totaal afstand van dit pad. == afstand

        public Knoop(string naam)
        {
            vorige = null;
            afstand = Int32.MaxValue / 2; //afstand is oneindig (max value in dit geval).
            buren = new Dictionary<Knoop, int>();
            this.naam = naam;
        }

        public List<Knoop> open = new List<Knoop>();

        public string Dijkstra(Knoop begin, Knoop eind)
        {
            Knoop deze = begin;

            while (!Bezoek(deze, eind))
            {
                //pak het tot nu toe kortste pad
                deze = open.Aggregate((l, r) => l.afstand < r.afstand ? l : r);
            }

            return maakpad(eind);
        }

        string maakpad(Knoop doel)
        {
            Knoop current = doel;
            List<string> nodes = new List<string>();

            while (current.vorige != null)
            {
                nodes.Add(current.vorige.naam);
                current = current.vorige;
            }

            string pad = "";

            nodes.Reverse();

            foreach (string x in nodes)
            {
                pad = pad + " " + x;
            }

            pad = pad + " " + doel.naam;

            return pad;
        }

        bool Bezoek(Knoop deze, Knoop eind)
        {
            Console.WriteLine("Ik bezoek knoop: " + deze.naam);

            //checken op eind
            if (deze == eind)
            {
                return true;
            }

            //niet meer bezoeken
            if (open.Contains(deze))
            {
                open.Remove(deze);
            }

            //buren aflopen
            foreach (KeyValuePair<Knoop, int> x in deze.buren)
            {
                int nieuweAfstand = deze.afstand + x.Value;
                if (nieuweAfstand < x.Key.afstand)
                {
                    x.Key.afstand = nieuweAfstand; //nieuwe afstand zetten
                    x.Key.vorige = deze; //route van pad onthouden
                    open.Add(x.Key); //nog bezoeken
                }
            }

            return false;
        }

    }

}
