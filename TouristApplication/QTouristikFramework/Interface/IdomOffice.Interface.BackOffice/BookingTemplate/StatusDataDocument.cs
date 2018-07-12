using IdomOffice.Interface.BackOffice.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdomOffice.Interface.BackOffice.BookingTemplate
{
    public class StatusDataDocument
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
