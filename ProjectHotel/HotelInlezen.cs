﻿using Newtonsoft.Json;
using ProjectHotel.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotel
{
    class HotelInlezen
    {
        public List<Kamer> Kamers { get; set; }
        Hoteloverzicht Overzicht = new Hoteloverzicht();
        public HotelInlezen()
        {
            Kamers = new List<Kamer>();
            Inlezen();
        }
        private List<Node> Inlezen()
        {
            List<Node> Faciliteiten = new List<Node>();
            try
            {
                List<Hoteloverzicht> Overzicht = JsonConvert.DeserializeObject<List<Hoteloverzicht>>(File.ReadAllText(@"..\..\..\Hotel.layout"));
                foreach (var item in Overzicht)
                {
                    switch (item.AreaType)
                    {
                        case "Room":
                            Kamers.Add(new Kamer(Kamers.Count));
                            Kamers[Kamers.Count - 1].Classification = item.Classification;
                            Kamers[Kamers.Count - 1].Dimension = item.Dimension;
                            Kamers[Kamers.Count - 1].Position = item.Position;
                            Faciliteiten.Add(Kamers[Kamers.Count - 1]);
                            break;
                        case "Cinema":
                            Bioscoop bioscoop = new Bioscoop();
                            bioscoop.Position = item.Position;
                            bioscoop.Dimension = item.Dimension;
                            Faciliteiten.Add(bioscoop);
                            break;
                        case "Restaurant":
                            Restaurant restaurant = new Restaurant();
                            restaurant.Position = item.Position;
                            restaurant.Dimension = item.Dimension;
                            restaurant.Capacity = item.Capacity;
                            Faciliteiten.Add(restaurant);
                            break;
                        case "Fitness":
                            Fitness fitness = new Fitness();
                            fitness.Position = item.Position;
                            fitness.Dimension = item.Dimension;
                            Faciliteiten.Add(fitness);
                            break;
                    }
                }
                Receptie receptie = new Receptie(Kamers);
                receptie.Position = new Point(1, 1);
                receptie.Dimension = new Point(8, 6);
                Faciliteiten.Add(receptie);
            }
            catch (Exception e)
            {
                Console.WriteLine("Bestand niet gevonden:");
                Console.WriteLine(e.Message);
            }
            return Faciliteiten;
        }
    }
}
