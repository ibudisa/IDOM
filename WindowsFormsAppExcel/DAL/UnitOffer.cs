using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOffer
    {
        public string id { get; set; }
        public string TourOperatorCode { get; set; }
        public string SiteCode { get; set; }
        public string OfferCode { get; set; }
        public string OfferTitel { get; set; }
        public Dictionary<string, string> OfferTitelTranslate { get; set; }
        public string OfferDescription { get; set; }
        public Dictionary<string, string> OfferDescriptionTranslate { get; set; }
        public int OfferCount { get; set; }
        public string UnitCode { get; set; }
        public bool IsAutoStopBooking { get; set; }
        public string ProviderNotice { get; set; }
    }
}
