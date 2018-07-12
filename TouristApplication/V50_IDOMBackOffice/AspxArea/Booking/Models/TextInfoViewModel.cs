using IdomOffice.Interface.BackOffice.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace V50_IDOMBackOffice.AspxArea.Booking.Models
{
    public class TextInfoViewModel
    {
        public string Id { get; set; }
        public string BookingId { get; set; }
        public DocumentProcessStatus Status { get; set; }
        public string docType { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
    }
}