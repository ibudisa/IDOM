using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdomOffice.Interface.BackOffice.PriceLists
{
    public enum PaymentType : int
    {
        ImmediatePayment = 1,
        DaysAfterTheBooking = 2,
        Days_BeforeArrival = 3,
        LateMostToDate = 4,
        Deposit_Eur_RestByArival = 5,
        Deposit_Percent_RestByArival = 6,

    }
}
