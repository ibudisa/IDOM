using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V50_IDOMBackOffice.AspxArea.Booking.Models;

namespace V50_IDOMBackOffice.AspxArea.Booking.Controllers
{
    public interface IPaymentController
    {
        List<PaymentViewModel> Init();
        void AddPayment(PaymentViewModel model);
        List<PaymentViewModel> GetPaymentByBookingId(string id);
        PaymentViewModel GetPayment(string id);
    }
}
