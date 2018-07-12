using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTouristik.Data.Booking
{
    public class BookingInquiry
    {
        public string id { get; set; }
        public string BookingProcessId { get; set; }
        public string BookingInquiryNummer { get; set; }
        public OfferInfo OfferInfo { get; set; } = new OfferInfo();
        public TravelApplicant TravelApplicant { get; set; } = new TravelApplicant();
    }
}
