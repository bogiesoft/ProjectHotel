using Newtonsoft.Json;
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
        HotelLayout HotelOverzicht = new HotelLayout();
        public List<HotelLayout> Inlezen()
        {
            List<HotelLayout> Faciliteiten = new List<HotelLayout>();
            try
            {
                List<HotelLayout> InlezenBestand = JsonConvert.DeserializeObject<List<HotelLayout>>(File.ReadAllText(@"..\..\..\Hotel.layout"));
                foreach (var item in InlezenBestand)
                {
                    switch (item.AreaType)
                    {
                        case "Room":
                            HotelOverzicht.Classification = item.Classification;
                            HotelOverzicht.Dimension = item.Dimension;
                            HotelOverzicht.Position = item.Position;
                            HotelOverzicht.AreaType = item.AreaType;
                            Faciliteiten.Add(HotelOverzicht);
                            break;
                        case "Cinema":
                            HotelOverzicht.Position = item.Position;
                            HotelOverzicht.Dimension = item.Dimension;
                            HotelOverzicht.AreaType = item.AreaType;
                            Faciliteiten.Add(HotelOverzicht);
                            break;
                        case "Restaurant":
                            HotelOverzicht.Position = item.Position;
                            HotelOverzicht.Dimension = item.Dimension;
                            HotelOverzicht.Capacity = item.Capacity;
                            HotelOverzicht.AreaType = item.AreaType;
                            Faciliteiten.Add(HotelOverzicht);
                            break;
                        case "Fitness":
                            HotelOverzicht.Position = item.Position;
                            HotelOverzicht.Dimension = item.Dimension;
                            HotelOverzicht.AreaType = item.AreaType;
                            Faciliteiten.Add(HotelOverzicht);
                            break;
                        default:
                            break;
                    }
                }
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
