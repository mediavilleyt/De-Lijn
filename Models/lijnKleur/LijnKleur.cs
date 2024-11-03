using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De_Lijn.Models.lijnKleur
{
    internal class LijnKleur
    {
        public string code { get; set; }
        public List<Link> links { get; set; }

        public LijnKleur(string code, List<Link> links)
        {
            this.code = code;
            this.links = links;
        }
    }
}
