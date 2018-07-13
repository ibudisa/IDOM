using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DocumentDataStatus
    {
        public bool BookingConfirmationFromProvider { get; set; }
        public bool BookingConfirmationToCustomer { get; set; }
        public bool BookingPartialPayment { get; set; }
        public bool BookingCompletePayment { get; set; }
        public bool VoucherSent { get; set; }
    }
}
