using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotel
{
    public abstract class Persoon
    {

    }

    public class Gast : Persoon
    {
        public Kamer kamer;
        public int fitnesstijd;

        public Gast()
        {
            
        }
    }

    public class Schoonmaker : Persoon
    {

    }
}
