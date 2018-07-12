using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdomOffice.Interface.BackOffice.Booking
{
    public class Email
    {
        public string Id { get; set; }
        public string BookingId { get; set; }
        public DocumentProcessStatus Status { get; set; }
        public string docType { get; set; }
        public string Content { get; set; }
        public string Sender { get; set; }
        public string Receipent { get; set; }
        public string Title { get; set; }
    }
}
