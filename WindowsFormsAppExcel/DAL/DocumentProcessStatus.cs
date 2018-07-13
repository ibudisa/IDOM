using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Serializable]
    public enum DocumentProcessStatus : int
    {
        First = 0,
        New = 1,
        WaitingProviderConfirmation = 2,
        ProviderConfirmed = 3,
        CustomerConfirmationSent = 4,
        WaitToCustomerPayment = 5,
        PricePaid = 6,
        VoucerSent = 7,
        CustomerOnVacation = 8,
        Close = 9,
        PaymentIsDelayed = 10,
        Cancellation = 11

    }
}
