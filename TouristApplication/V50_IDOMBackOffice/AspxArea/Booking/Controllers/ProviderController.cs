using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using V50_IDOMBackOffice.AspxArea.Booking.Repositorys;


namespace V50_IDOMBackOffice.AspxArea.Booking.Controllers
{
    public class ProviderController:ICoreController
    {
        public List<CoreViewModel> Init()
        {
            var list = BookingDataCoreRepository.GetProviderViewModel();
            return list;
        }
        public void Add(CoreViewModel model)
        {
            BookingDataCoreRepository.AddMasterData(model);
        }
        public void Update(CoreViewModel model)
        {
            BookingDataCoreRepository.UpdateMasterData(model);
        }

        public void Delete(string id)
        {
            BookingDataCoreRepository.DeleteProvider(id);
        }

        public CoreViewModel GetData(string id)
        {
            var providermodel = BookingDataCoreRepository.GetProvider(id);
            return providermodel;
        }

        public LayoutFormViewModel GetLayoutData(CoreViewModel model)
        {
            var layoutmodel = BookingDataCoreRepository.GetLayoutFormViewModel(model);
            return layoutmodel;
        }

        

        public List<BookingProcessViewModel> GetDataByProviderId(int providerid)
        {
            return BookingDataCoreRepository.GetBookingProcessesByProviderId(providerid);
        }

        public LayoutCoreViewModel GetCoreLayoutData(CoreViewModel model)
        {
            return BookingDataCoreRepository.GetLayoutViewModel(model);
        }

        public CoreViewModel GetCoreDataById(string id)
        {
            return BookingDataCoreRepository.GetProviderById(id);
        }

        public void CheckEmail(string id, string email)
        {
            BookingDataCoreRepository.CheckProviderEmail(id, email);
        }
    }
}