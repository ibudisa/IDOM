using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTouristik.Interface.Sync
{
    public class OfferInfo
    {
        public string SiteCode { get; set; }
        public string OfferCode { get; set; }
        public string OfferTitle { get; set; }
        public Dictionary<string, string> OfferTitleTranslate { get; set; }
        public string OfferDescriptionHtml { get; set; }
        public Dictionary<string, string> OfferDescriptionHtmlTranslate { get; set; }
        public int OfferCount { get; set; }
        public int MobilhomeArea { get; set; }
        public int TerraceArea { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public string Beds { get; set; }
        public int ExtraBeds { get; set; }
        public bool Dishwasher { get; set; }
        public bool AirConditioning { get; set; }
        public int MaxPersons { get; set; }
        public int MaxAdults { get; set; }
        public bool AllowedPets { get; set; }
        public string ProviderNotice { get; set; }
    }
}
