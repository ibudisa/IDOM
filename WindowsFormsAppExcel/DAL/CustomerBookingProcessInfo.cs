using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerBookingProcessInfo
    {
        public string SiteName { get; set; }
        public string OfferName { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string BookingProcessId { get; set; }
    }
}
