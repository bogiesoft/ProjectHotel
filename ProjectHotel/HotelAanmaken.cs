﻿using ProjectHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotel
{
    class HotelAanmaken
    {
        List<HotelLayout> HotelOverzicht = new List<HotelLayout>();
        List<Kamer> KamerLijst = new List<Kamer>();
        HotelInlezen Inlezen = new HotelInlezen();
        public HotelAanmaken()
        {
            HotelOverzicht = Inlezen.Inlezen();
        }
        public List<Area> HotelMaken()
        {
            List<Area> Area = new List<Area>();
            foreach (var item in HotelOverzicht)
            {
                switch (item.AreaType)
                {
                    case "Room":
                        Kamer SoortKamer = new Kamer(item.Classification, item.Position, item.Dimension);
                        Area.Add(SoortKamer);
                        KamerLijst.Add(SoortKamer);
                        break;
                    case "Restaurant":
                        Restaurant Restaurant = new Restaurant(item.Capacity, item.Position, item.Dimension);
                        Area.Add(Restaurant);
                        break;
                    case "Bioscoop":
                        Bioscoop Bioscoop = new Bioscoop(item.Position, item.Dimension);
                        Area.Add(Bioscoop);
                        break;
                    case "Fitness":
                        Fitness Fitness = new Fitness(item.Position, item.Dimension);
                        Area.Add(Fitness);
                        break;
                    default:
                        Console.WriteLine("De kamer " + item.AreaType + " Komt niet voor.");
                        break;
                }
            }
            return Area;
        }
    }
}
