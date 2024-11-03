using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De_Lijn.Models.halteDoorkomsten
{
    internal class HalteDoorkomst
    {
        public string halteNummer { get; set; }

        public List<Doorkomsten> doorkomsten { get; set; }

        public HalteDoorkomst(string halteNummer, List<Doorkomsten> doorkomsten)
        {
            this.halteNummer = halteNummer;
            this.doorkomsten = doorkomsten;
        }
    }
}
