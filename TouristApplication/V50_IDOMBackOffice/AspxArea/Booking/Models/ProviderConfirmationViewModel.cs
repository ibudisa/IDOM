using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace V50_IDOMBackOffice.AspxArea.Booking.Models
{
    public class ProviderConfirmationViewModel
    {
        public string Id { get; set; }
        public string BookingId { get; set; }
        public string docType { get; set; } = "ProviderConfirmation";
        public DateTime CreateDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}