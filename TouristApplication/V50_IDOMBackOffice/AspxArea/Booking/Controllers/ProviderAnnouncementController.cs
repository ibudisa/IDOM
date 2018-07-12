using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using V50_IDOMBackOffice.AspxArea.Booking.Repositorys;

namespace V50_IDOMBackOffice.AspxArea.Booking.Controllers
{
    public class ProviderAnnouncementController
    {
        public List<ProviderAnnouncementViewModel> Init()
        {
            return BookingDataRepository.GetProviderAnnouncementViewModel();
        }
        public void AddMasterData(ProviderAnnouncementViewModel model)
        {
            BookingDataRepository.AddMasterData(model);
        }
        public void UpdateMasterData(ProviderAnnouncementViewModel model)
        {
            BookingDataRepository.UpdateMasterData(model);
        }
        public ProviderAnnouncementViewModel GetProviderAnnouncement(string id)
        {
            return BookingDataRepository.GetProviderAnnouncementViewModelById(id);
        }
        public ProviderAnnouncementViewModel GetProviderAnnouncementByBookingId(string id)
        {
            return BookingDataRepository.GetProviderAnnouncementViewModelByBookingId(id);
        }

        public void CreateProviderAnnouncement(string id)
        {
            BookingDataRepository.CreateProviderAnnouncement(id);
        }
    }
}