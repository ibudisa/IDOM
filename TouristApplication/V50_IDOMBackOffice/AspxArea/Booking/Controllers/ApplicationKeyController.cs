using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using V50_IDOMBackOffice.AspxArea.Booking.Repositorys;

namespace V50_IDOMBackOffice.AspxArea.Booking.Controllers
{
    public class ApplicationKeyController
    {
        public List<ApplicationKeyViewModel> Init()
        {
            return BookingDataRepository.GetApplicationKeyViewModel();
        }
        public void AddMasterData(ApplicationKeyViewModel model)
        {
            BookingDataRepository.AddMasterData(model);
        }
        public void UpdateMasterData(ApplicationKeyViewModel model)
        {
            BookingDataRepository.UpdateMasterData(model);
        }

        public ApplicationKeyViewModel GetApplicationKeyById(string id)
        {
            return BookingDataRepository.GetApplicantKeyViewModelById(id);
        }

        public ApplicationKeyViewModel GetApplicationKeyByName(string name)
        {
            return BookingDataRepository.GetApplicantKeyViewModelByName(name);
        }
    }
}