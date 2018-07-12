using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTouristik.Interface.Sync
{
    public class PriceArg
    {
        public string TourOperatorCode { get; set; }
        public string TouristSiteCode { get; set; }
        public string OfferCode { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public List<DateTime> Birthdays { get; set; } = new List<DateTime>();

        public List<int> Pets { get; set; } = new List<int>();

        public int PaymentOfferType { get; set; }
    }
}
