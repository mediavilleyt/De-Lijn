using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De_Lijn.Models.haltes
{
    internal class Halte
    {
        public string type { get; set; }
        public string id { get; set; }
        public string naam { get; set; }
        public string aftand { get; set; }
        public GeoCoordinaat geoCoordinaat { get; set; }
        public List<Link> links { get; set; }

        public Halte(string type, string id, string naam, string aftand, GeoCoordinaat geoCoordinaat, List<Link> links)
        {
            this.type = type;
            this.id = id;
            this.naam = naam;
            this.aftand = aftand;
            this.geoCoordinaat = geoCoordinaat;
            this.links = links;
        }
    }
}
