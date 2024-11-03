using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De_Lijn.Models.halteDoorkomsten
{
    internal class HalteDoorkomsten
    {
        public List<HalteDoorkomst> halteDoorkomsten { get; set; }

        public HalteDoorkomsten() { }

        public HalteDoorkomsten(List<HalteDoorkomst> halteDoorkomsten)
        {
            this.halteDoorkomsten = halteDoorkomsten;
        }
    }
}
