using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdomOffice.Interface.BackOffice.Booking;
using IdomOffice.Interface.BackOffice.Booking.Entity;

namespace V50_IDOMBackOffice.AspxArea.Booking.Models
{
    public class BookingProcessViewModel
    {
        public string Id { get; set; }
        public string Country { get; set; }
        public string PlaceName { get; set; }
        public string SiteName { get; set; }
        public string TourOperatorCode { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DocumentProcessStatus Status { get; set; }
        public List<BookingProcessItem> BookingProcessItemList { get; set; } = new List<BookingProcessItem>();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TravelerCountry { get; set; }
        public int Adults { get; set; }

        public string Address { get; set; }
        public string OfferName { get; set; }
        public int TravelApplicantId { get; set; }
        public int PartnerId { get; set; }
        public int ProviderId { get; set; }
        public string Season { get; set; }

        
        public string ZipCode { get; set; }
        public string TravelerPlace { get; set; }
       
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string EMail { get; set; }
        public int Days { get; set; }

        public List<TravelApplicantPayment> Payments { get; set; } = new List<TravelApplicantPayment>();
        public List<ProviderPayment> PaymentsForProvider { get; set; } = new List<ProviderPayment>();

        public string BookingNumber { get; set; }


    }
}