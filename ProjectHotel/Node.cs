﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public int afstand;
        int tijdsduur;
        

        protected Instellingen Instelling = new Instellingen();

        public Node()
        {
            buren = new Dictionary<Node, int>();
            Instelling = JsonConvert.DeserializeObject<Instellingen>(File.ReadAllText(@"..\..\..\config.json"));
        }
    }

    public class DijkstraNode : Node
    {
        public Node bron;
        public DijkstraNode vorige;
        public new Dictionary<DijkstraNode, int> buren;

        public DijkstraNode(Node source)
        {
            bron = source;
            afstand = Int32.MaxValue / 2;
            buren = new Dictionary<DijkstraNode, int>();

            naam = source.naam;

            foreach(KeyValuePair<Node, int> n in source.buren)
            {
                Console.WriteLine(n.Key.naam);
                this.buren.Add(new DijkstraNode(n.Key), n.Value);
            }
        }

        public List<DijkstraNode> open = new List<DijkstraNode>();

        public string Dijkstra(DijkstraNode begin, DijkstraNode eind)
        {
            DijkstraNode deze = begin;

            while (!Bezoek(deze, eind))
            {
                //pak het tot nu toe kortste pad
                deze = open.Aggregate((l, r) => l.afstand < r.afstand ? l : r);
            }

            return maakpad(eind);
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

        bool Bezoek(DijkstraNode deze, DijkstraNode eind)
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
            foreach (KeyValuePair<DijkstraNode, int> x in deze.buren)
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

    public class Kamer : Node
    {
        public Gang gang;
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

        public Gang(int x)
        {
            buren = new Dictionary<Node, int>();
            naam = "Gang_" + x;
        }
    }

    public class Receptie : Node
    {
        public List<Kamer> kamers; //Lijst met kamers van het hotel
        public List<Gast> wachtrij; //Rij met gasten voor de receptie
        public Gast current; //Geeft de huidige gast bij de receptie aan

        /// <summary>
        /// Maakt een nieuwe Receptie aan en geeft een lijst met bestaande kamers.
        /// </summary>
        /// <param name="kamers">Lijst met alle Kamers in het hotel.</param>
        public Receptie(List<Kamer> kamers)
        {
            naam = "Receptie";
            this.kamers = kamers; //Slaat de gekregen kamerlijst op
        }
        
    }

    public class Restaurant : Node
    {
        public Gang gang;
        public int maxklanten;
        public int tijdsduur;
        
        
        public Restaurant(string naam)
        {
            this.naam = naam;
        }
    }

    public class Bioscoop : Node
    {
        public Gang gang;
        public bool draaitfilm;
        public int tijdsduur;

        public Bioscoop()
        {
            tijdsduur = Instelling.Bioscoopduur;
            naam = "Bioscoop";
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
