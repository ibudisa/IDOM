using IdomOffice.Interface.BackOffice.Booking;
using IdomOffice.Interface.BackOffice.BookingTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace V50_IDOMBackOffice.AspxArea.Booking.Models
{
    public class BookingProcessDetailsViewModel
    {
        public string Id { get; set; }
        public string TravelApplicant_Name { get; set; }
        public string TravelApplicant_Adress { get; set; }
        public string TravelApplicant_Email { get; set; }
        public string TravelApplicant_Phone { get; set; }
        public string TravelApplicant_MobilePhone { get; set; }

        public string Offer_SiteName { get; set; }
        public string Offer_OfferName { get; set; }
        public string Offer_CheckIn { get; set; }
        public string Offer_CheckOut { get; set; }
        public DocumentProcessStatus Status { get; set; }
        public string StatusText { get; set; }

        public List<BookingProcessItem> BookingProcessItemList { get; set; } = new List<BookingProcessItem>();
        public List<StatusDataDocument> ActionList { get; set; } = new List<StatusDataDocument>();
    }
}