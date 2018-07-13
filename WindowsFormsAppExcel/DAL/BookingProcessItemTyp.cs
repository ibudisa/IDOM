using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public enum BookingProcessItemTyp : int
    {
        BookingInquiry = 1,
        ProviderAnnouncement = 2,
        ProviderConfirmation = 3,
        BookingConfirmation = 4,
        CustomerVoucher = 5,
        BookingInvoice = 6,
        CustomerPayments = 7,
        Notes = 8,
        Email = 9
    }
}
