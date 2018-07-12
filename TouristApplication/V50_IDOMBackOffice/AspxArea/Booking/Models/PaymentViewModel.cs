using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace V50_IDOMBackOffice.AspxArea.Booking.Models
{
    public class PaymentViewModel
    {
        public string Id { get; set; }
        public string BookingId { get; set; }
        public string docType { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public string Title { get; set; }
        public string PaymentType { get; set; }

    }
}