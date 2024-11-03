using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De_Lijn.Models
{
    internal class Link
    {
        public string rel { get; set; }
        public string url { get; set; }

        public Link(string rel, string url)
        {
            this.rel = rel;
            this.url = url;
        }
    }
}
