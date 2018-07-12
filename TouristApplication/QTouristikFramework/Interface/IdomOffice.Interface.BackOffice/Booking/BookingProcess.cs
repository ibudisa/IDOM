using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTouristik.Data;
using IdomOffice.Interface.BackOffice.Booking.Entity;

namespace IdomOffice.Interface.BackOffice.Booking
{
    public class BookingProcess
    {
        public string Id { get; set; }
        public string docType { get; set; } = "BookingProcess";
        public OfferInfo OfferInfo { get; set; } = new OfferInfo();
         public int TravelApplicantId { get; set; }
        public TravelApplicant TravelApplicant { get; set; } = new TravelApplicant();
        public DocumentProcessStatus Status { get; set; }
        public List<BookingProcessItem> BookingProcessItemList { get; set; } = new List<BookingProcessItem>();
        public int SellingPartner { get; set; }

        public int AccProvider { get; set; }
        public string Season { get; set; }
        public List<TravelApplicantPayment> Payments { get; set; } = new List<TravelApplicantPayment>();
        public List<ProviderPayment> PaymentsForProvider { get; set; } = new List<ProviderPayment>(); 
        public string BookingNumber { get; set; }
    }
}
