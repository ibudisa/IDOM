using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DAL
{
    public class BookingInvoice:BookingDocumentBase
    {
        public string BookingInquiryNummer { get; set; }
        public string BookingConfirmationNummer { get; set; }
        public OfferInfo OfferInfo { get; set; } = new OfferInfo();
       
    }
}
