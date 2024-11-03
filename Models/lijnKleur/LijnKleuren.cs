using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De_Lijn.Models.lijnKleur
{
    internal class LijnKleuren
    {
        public LijnKleur voorgrond { get; set; }
        public LijnKleur achtergrond { get; set; }
        public LijnKleur voorgrondRand { get; set; }
        public LijnKleur achtergrondRand { get; set; }

        public LijnKleuren() { }

        public LijnKleuren(LijnKleur voorgrond, LijnKleur achtergrond, LijnKleur voorgrondRand, LijnKleur achtergrondRand)
        {
            this.voorgrond = voorgrond;
            this.achtergrond = achtergrond;
            this.voorgrondRand = voorgrondRand;
            this.achtergrondRand = achtergrondRand;
        }
    }
}
