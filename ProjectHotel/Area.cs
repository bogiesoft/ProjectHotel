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
    abstract class Area
    {
        public string AreaType { get; set; }
        public Point Position { get; set; }
        public Point Dimension { get; set; }
        public List<Area> Buren;

        protected Instellingen Instellingen = new Instellingen();

        public Area()
        {
            Instellingen = JsonConvert.DeserializeObject<Instellingen>(File.ReadAllText(@"..\..\..\config.json"));
            Buren = new List<Area>();

        }
    }
}
