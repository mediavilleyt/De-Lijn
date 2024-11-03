using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De_Lijn.Models.haltes
{
    internal class Haltes
    {
        public List<Halte> haltes { get; set; }

        public Haltes() { }

        public Haltes(List<Halte> haltes)
        {
            this.haltes = haltes;
        }
    }
}
