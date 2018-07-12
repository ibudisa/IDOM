using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTouristik.Data.Booking
{
    public enum BookingProcessPartTyp : int
    {
        BookingInquiry = 1,
        BookingConfirmation = 2,
        BookingInvoice = 3,
        Payments = 4,
        Notes = 5,
        Email = 6

    }
}
