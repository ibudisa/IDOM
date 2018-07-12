using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using V50_IDOMBackOffice.AspxArea.Booking.Repositorys;

namespace V50_IDOMBackOffice.AspxArea.Booking.Controllers
{
    [Serializable]
    public class ProviderPaymentController : IPaymentController
    {

        public void AddPayment(PaymentViewModel model)
        {
            BookingDataRepository.AddProviderPaymentData(model);
        }

        public PaymentViewModel GetPayment(string id)
        {
            return BookingDataRepository.GetProviderPaymentViewModelById(id);
        }

        public List<PaymentViewModel> GetPaymentByBookingId(string id)
        {
            return BookingDataRepository.GetProviderPaymentViewModelByBookingId(id);
        }

        public List<PaymentViewModel> Init()
        {
            return BookingDataRepository.GetProviderPaymentViewModel();
        }
    }
}