using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace V50_IDOMBackOffice.AspxArea.Booking.Models
{
    public class BookingConfirmationViewModel
    {
        public string id { get; set; }
        public string docType { get; set; } = "BookingConfirmation";
        public string BookingProcessId { get; set; }
        public string BookingInquiryNummer { get; set; }
        public string BookingConfirmationNummer { get; set; }
        public string Country { get; set; }
        public string PlaceName { get; set; }
        public string SiteName { get; set; }
        public string TourOperatorCode { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TravelerCountry { get; set; }
        public string Address { get; set; }

        public string OfferName { get; set; }
        public string MobilePhone { get; set; }
        public string Phone { get; set; }
        public string ZipCode { get; set; }
        public string TravelerPlace { get; set; }
        public string HtmlDocumentView { get; set; }
    }
}