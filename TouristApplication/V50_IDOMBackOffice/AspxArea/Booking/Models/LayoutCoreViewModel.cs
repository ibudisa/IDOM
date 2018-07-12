using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace V50_IDOMBackOffice.AspxArea.Booking.Models
{
    public class LayoutCoreViewModel
    {
        public string PersonalIdentificationNumber { get; set; }
        public int ProviderId { get; set; }
        public string Name { get; set; }
        public string Bank { get; set; }
        public string IBAN { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string BookingEmail { get; set; }
        public string Title { get; set; }
    }
}