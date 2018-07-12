using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTouristik.Data.Booking
{
    class CustomerVoucher
    {
        public OfferInfo OfferInfo { get; set; } = new OfferInfo();
        public TravelApplicant TravelApplicant { get; set; } = new TravelApplicant();
    }
}
