using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTouristik.Data.Booking
{
    public class OfferInfo
    {
        public string Country { get; set; }
        public string PlaceName { get; set; }
        public string SiteCode { get; set; }
        public string SiteName { get; set; }
        public int TourOperator { get; set; }
        public string UnitCode { get; set; }
        public string OfferCode { get; set; }
        public string OfferName { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Days { get { return CheckOut.Subtract(CheckIn).Days; } }
        public int Adults { get; set; }
        public int YoungAdults { get; set; }
        public int Children { get; set; }
    }
}
