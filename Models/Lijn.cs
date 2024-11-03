using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De_Lijn.Models
{
    internal class Lijn
    {
        public string entiteitnummer { get; set; }
        public string lijnnummer { get; set; }
        public string lijnnummerPubliek { get; set; }
        public string omschrijving { get; set; }
        public string vervoerRegioCode { get; set; }
        public bool publiek { get; set; }
        public string vervoertype { get; set; }
        public string bedieningstype { get; set; }
        public string lijnGeldigVan { get; set; }
        public string lijnGeldigTot { get; set; }
        public List<Link> links { get; set; }

        public Lijn() { }

        public Lijn(string entiteitnummer, string lijnnummer, string lijnnummerPubliek, string omschrijving, string vervoerRegioCode, bool publiek, string vervoertype, string bedieningstype, string lijnGeldigVan, string lijnGeldigTot, List<Link> links)
        {
            this.entiteitnummer = entiteitnummer;
            this.lijnnummer = lijnnummer;
            this.lijnnummerPubliek = lijnnummerPubliek;
            this.omschrijving = omschrijving;
            this.vervoerRegioCode = vervoerRegioCode;
            this.publiek = publiek;
            this.vervoertype = vervoertype;
            this.bedieningstype = bedieningstype;
            this.lijnGeldigVan = lijnGeldigVan;
            this.lijnGeldigTot = lijnGeldigTot;
            this.links = links;
        }
    }
}
