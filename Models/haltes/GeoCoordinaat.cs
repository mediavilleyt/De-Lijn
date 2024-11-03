using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De_Lijn.Models.haltes
{
    internal class GeoCoordinaat
    {
        public string latitude { get; set; }
        public string longitude { get; set; }

        public GeoCoordinaat(string latitude, string longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}
