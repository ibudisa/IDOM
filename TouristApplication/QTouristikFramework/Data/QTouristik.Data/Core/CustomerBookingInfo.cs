using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTouristik.Data.Core
{
    public class CustomerBookingInfo
    {
        public string SiteName { get; set; }
        public string OfferName  { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string BookingProcessId { get; set; }
    }
}
