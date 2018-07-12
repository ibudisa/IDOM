using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace V50_IDOMBackOffice.AspxArea.Booking.Models
{
    public class ProviderAnnouncementViewModel
    {
        public string Id { get; set; }
        public string BookingId { get; set; }
        public string docType { get; set; } = "ProviderAnnouncement";
        public string Country { get; set; }
        public string PlaceName { get; set; }
        public string SiteName { get; set; }
        public string OfferName { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Adults { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TravelerAdress { get; set; }
        public string TravelerZipCode { get; set; }
        public string TravelerPlace { get; set; }
        public string TravelerCountry { get; set; }
        public string HtmlDocumentView { get; set; }
    }
}