using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotel
{
    public abstract class Node
    {
        public Dictionary<Node, int> buren; //Dictionary met de Buren en de Tijd die het kost om daar naartoe te gaan.

        public Node()
        {
            buren = new Dictionary<Node, int>();
        }
    }

}
