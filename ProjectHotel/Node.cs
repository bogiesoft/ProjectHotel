using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotel
{
    public abstract class Node
    {
        public string naam;
        public Dictionary<Node, int> buren; //Dictionary met de Buren en de Tijd die het kost om daar naartoe te gaan.
        int tijdsduur;

        public Node()
        {
            
            
        }
    }

    public class DijkstraNode : Node
    {
        public Node bron;
        public DijkstraNode vorige;
        public Dictionary<DijkstraNode, int> dijkstraburen;
        public int afstand;
        public List<DijkstraNode> open;

        public DijkstraNode(Node source)
        {
            bron = source;
            afstand = Int32.MaxValue / 2;
            dijkstraburen = new Dictionary<DijkstraNode, int>();

            open = new List<DijkstraNode>();
            naam = bron.naam;
            this.vorige = null;

            foreach (KeyValuePair<Node, int> n in bron.buren)
            {
                dijkstraburen.Add(new DijkstraNode(n.Key, this, n.Value), n.Value);
                Console.WriteLine(n.Value);
            }

            //Console.WriteLine(dijkstraburen.Count); //Test Print om te controleren of het klopt
        }
        public DijkstraNode(Node source, DijkstraNode vorige, int tijd)
        {
            bron = source;
            afstand = Int32.MaxValue / 2;
            dijkstraburen = new Dictionary<DijkstraNode, int>();

            open = new List<DijkstraNode>();
            naam = bron.naam;
            this.vorige = vorige;

            foreach (KeyValuePair<Node, int> n in bron.buren)
            {
                if (n.Key != vorige.bron)
                {
                    dijkstraburen.Add(new DijkstraNode(n.Key, this, n.Value), n.Value);
                    Console.WriteLine(n.Value);
                }
            }

            dijkstraburen.Add(vorige, tijd);

            //Console.WriteLine(dijkstraburen.Count); //Test Print om te controleren of het klopt
        }


        public string Dijkstra(DijkstraNode begin, Node eind)
        {
            DijkstraNode deze = begin;

            while (!Bezoek(deze, eind))
            {
                //pak het tot nu toe kortste pad
                deze = open.Aggregate((l, r) => l.afstand < r.afstand ? l : r);
            }

            return maakpad(deze);
        }

        string maakpad(DijkstraNode doel)
        {
            DijkstraNode current = doel;
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

        bool Bezoek(DijkstraNode deze, Node eind)
        {
            //Console.WriteLine("Ik bezoek knoop: " + deze.naam);

            //checken op eind
            if (deze.bron == eind)
            {
                return true;
            }

            //niet meer bezoeken
            if (open.Contains(deze))
            {
                open.Remove(deze);
            }


            //buren aflopen
            foreach (KeyValuePair<DijkstraNode, int> x in deze.dijkstraburen)
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

    //public class Kamer : Node
    //{
    //    public int nummer;
    //    public bool ingebruik;
    //    public bool schoongemaakt;
    //    public string Classification { get; set; }

    //    public Kamer(int nummer)
    //    {
    //        this.nummer = nummer;
    //        naam = "Kamer_" + nummer.ToString();
    //        buren = new Dictionary<Node, int>();
    //    }
    //}

    public class Gang : Node
    {

        public Gang(int x)
        {
            buren = new Dictionary<Node, int>();
            naam = "Gang_" + x;
        }
    }

    //public class Receptie : Node
    //{
    //    public List<Kamer> kamers; //Lijst met kamers van het hotel
    //    public List<Gast> wachtrij; //Rij met gasten voor de receptie
    //    public Gast current; //Geeft de huidige gast bij de receptie aan

    //    /// <summary>
    //    /// Maakt een nieuwe Receptie aan en geeft een lijst met bestaande kamers.
    //    /// </summary>
    //    /// <param name="kamers">Lijst met alle Kamers in het hotel.</param>
    //    public Receptie(List<Kamer> kamers)
    //    {
    //        naam = "Receptie";
    //        this.kamers = kamers; //Slaat de gekregen kamerlijst op
    //        buren = new Dictionary<Node, int>();
    //    }
        
    //}

    //public class Restaurant : Node
    //{
    //    public Gang gang;
    //    public int maxklanten;
    //    public int tijdsduur;
    //    public int Capacity { get; set; }


    //    public Restaurant()
    //    {
    //        this.naam = naam;
    //    }
    //}

    //public class Bioscoop : Node
    //{
    //    public bool draaitfilm;
    //    public int tijdsduur;

    //    public Bioscoop()
    //    {
    //        tijdsduur = Instelling.Bioscoopduur;
    //        naam = "Bioscoop";
    //        buren = new Dictionary<Node, int>();
    //    }
    //}


    //public class Fitness : Node
    //{
    //    //tijdsduur bepaald de gast.
    //}

    public class Lift : Node
    {
        List<Persoon> mensen; //moeten allemaal verplaatsen als de lift dat doey.
    }

    public class Trap : Node
    {
        public Trap()
        {
            buren = new Dictionary<Node, int>();
        }

    }

}
