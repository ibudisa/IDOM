using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdomOffice.Interface.BackOffice.PriceLists
{
    public class PaymentMode
    {
        public string Id { get; set; }
        //Max 15 znakova
        public string PaymentModeTitel { get; set; }
        //HTML Code
        public string PaymentModeDescription { get; set; }

        public DateTime BookingFromDate { get; set; }
        public DateTime BookingToDate { get; set; }

        public DateTime CheckInFromDate { get; set; }
        public DateTime CheckInToDate { get; set; }

        public int MinDayToArrival { get; set; }
        public int MaxDayToArrival { get; set; }

        public int PriceDownPaymentPercent { get; set; }
        public int PriceDownPaymentEur { get; set; }
        public int PriceDownPaymentAfterDays { get; set; }

        public int PriceRemainingBeforDays { get; set; }

        public int CancellationFeesToDays { get; set; }
        public int CancellationFeesPercent { get; set; }

        public int PricePercentDiscount { get; set; }
       

    }
}
