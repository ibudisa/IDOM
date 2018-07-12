using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdomOffice.Interface.BackOffice.BookingTemplate;
using IdomOffice.Interface.BackOffice.Booking;

namespace V50_IDOMBackOffice.AspxArea.BookingTemplate.Models
{
    public class StatusDataDocumentViewModel
    {
        public string Id { get; set; }
        public string docType { get; set; } = "StatusDataDocument";
        public DocumentProcessStatus Status { get; set; }
        public DocumentProcessStatus NewStatus { get; set; }
        public int ValueId { get; set; }
        public string Text { get; set; }
        public int Receiver { get; set; }
        public string FormCode { get; set; }
    }
}