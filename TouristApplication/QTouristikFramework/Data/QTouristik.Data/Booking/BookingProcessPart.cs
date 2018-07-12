using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTouristik.Data.Booking
{
    public class BookingProcessPart
    {
        public string DocumentId { get; set; }
        public DateTime CreateDate { get; set; }
        public BookingProcessPartTyp BookingProcessTyp { get; set; }
        public string DocumentNr { get; set; }
        public string DocumentTitel { get; set; }
        public DocumentStatus Status { get; set; }
}
}
