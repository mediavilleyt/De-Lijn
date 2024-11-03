using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De_Lijn.Models
{
    internal class RGB
    {
        public string rood { get; set; }
        public string groen { get; set; }
        public string blauw { get; set; }

        public RGB(string rood, string groen, string blauw)
        {
            this.rood = rood;
            this.groen = groen;
            this.blauw = blauw;
        }
    }
}
