using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTouristik.Data.Booking
{
    public class BookingProcess
    {
        public string id { get; set; }
        public List<BookingProcessPart> BookingProcessInquiryPart { get; set; } = new List<Booking.BookingProcessPart>();
      
    }
}
