using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace De_Lijn.Models.halteDoorkomsten
{
    internal class Doorkomsten
    {
        public string entiteitnummer { get; set; }
        public int lijnnummer { get; set; }
        public string richting { get; set; }
        public string bestemming { get; set; }
        public List<string> vias { get; set; }
        public string dienstregelingTijdstip { get; set; }

        [JsonProperty("real-timeTijdstip")]
        public string realtimeTijdstip { get; set; }

        public string vrtnum { get; set; }

        public List<string> predictionStatussen { get; set; }
        public List<Link> links { get; set; }

        public Doorkomsten(string entiteitnummer, int lijnnummer, string richting, string bestemming, List<string> vias, string dienstregelingTijdstip, string realtimeTijdstip, string vrtnum, List<string> predictionStatussen, List<Link> links)
        {
            this.entiteitnummer = entiteitnummer;
            this.lijnnummer = lijnnummer;
            this.richting = richting;
            this.bestemming = bestemming;
            this.vias = vias;
            this.dienstregelingTijdstip = dienstregelingTijdstip;
            this.realtimeTijdstip = realtimeTijdstip;
            this.vrtnum = vrtnum;
            this.predictionStatussen = predictionStatussen;
            this.links = links;
        }
    }
}
