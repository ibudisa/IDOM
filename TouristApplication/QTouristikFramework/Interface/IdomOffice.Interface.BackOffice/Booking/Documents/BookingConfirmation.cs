using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdomOffice.Interface.BackOffice.Booking.Documents;

namespace IdomOffice.Interface.BackOffice.Booking
{
    public class BookingConfirmation:BookingDocumentBase
    {
        public string BookingInquiryNummer { get; set; }
        public string BookingConfirmationNummer { get; set; }
        public OfferInfo OfferInfo { get; set; } = new OfferInfo();
        public TravelApplicant TravelApplicant { get; set; } = new TravelApplicant();
        public List<TravelerEntity> Traveler { get; set; } = new List<TravelerEntity>();
    }
}
