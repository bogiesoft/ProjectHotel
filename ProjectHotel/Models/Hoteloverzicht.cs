using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotel.Models
{
    public class Hoteloverzicht
    {
        public string Classification { get; set; }
        public string AreaType { get; set; }
        public int Capacity { get; set; }
        public Point Position { get; set; }
        public Point Dimension { get; set; }
    }
}
