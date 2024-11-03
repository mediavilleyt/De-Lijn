using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De_Lijn.Models
{
    internal class LijnKleurCode
    {
        public string code { get; set; }
        public string omschrijving { get; set; }
        public RGB rgb { get; set; }
        public string hex { get; set; }
        public List<Link> links { get; set; }
    }
}
