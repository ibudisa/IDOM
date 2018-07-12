using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdomOffice.Interface.BackOffice.Booking;

namespace V50_IDOMBackOffice.AspxArea.Booking.Models
{
    public class BookingProcessItemViewModel
    {
        public string DocumentId { get; set; }
        public DateTime CreateDate { get; set; }
        public BookingProcessItemTyp BookingProcessTyp { get; set; }
        public string DocumentNr { get; set; }
        public string DocumentTitel { get; set; }
        public string Author { get; set; }
        public DateTime LastChange { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
    }
}