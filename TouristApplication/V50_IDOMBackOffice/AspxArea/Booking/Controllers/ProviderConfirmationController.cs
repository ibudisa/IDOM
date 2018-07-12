using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using V50_IDOMBackOffice.AspxArea.Booking.Repositorys;

namespace V50_IDOMBackOffice.AspxArea.Booking.Controllers
{
    public class ProviderConfirmationController
    {
        public List<ProviderConfirmationViewModel> Init()
        {
            return BookingDataRepository.GetProviderConfirmationViewModel();
        }

        public void AddMasterData(ProviderConfirmationViewModel model)
        {
            BookingDataRepository.AddMasterData(model);
        }
        public void UpdateMasterData(ProviderConfirmationViewModel model)
        {
            BookingDataRepository.UpdateMasterData(model);
        }
        public ProviderConfirmationViewModel GetProviderConfirmation(string id)
        {
            return BookingDataRepository.GetProviderConfirmationViewModelById(id);
        }
        public ProviderConfirmationViewModel GetProviderConfirmationByBookingId(string id)
        {
            return BookingDataRepository.GetProviderConfirmationViewModelByBookingId(id);
        }
        
    }
}