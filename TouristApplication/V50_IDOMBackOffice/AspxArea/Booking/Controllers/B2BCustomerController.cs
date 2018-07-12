using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using V50_IDOMBackOffice.AspxArea.Booking.Repositorys;

namespace V50_IDOMBackOffice.AspxArea.Booking.Controllers
{
    public class B2BCustomerController : ICoreController
    {
        public List<CoreViewModel> Init()
        {
            var list = BookingDataCoreRepository.GetB2BCustomerViewModel();
            return list;
        }
        public void Add(CoreViewModel model)
        {
            BookingDataCoreRepository.AddMasterDataB2BCustomer(model);
        }
        public void Update(CoreViewModel model)
        {
            BookingDataCoreRepository.UpdateMasterDataB2BCustomer(model);
        }

        public void Delete(string id)
        {
            BookingDataCoreRepository.DeleteMasterDataB2BCustomer(id);
        }

        public CoreViewModel GetData(string id)
        {
            var b2bcustomermodel = BookingDataCoreRepository.GetB2BCustomer(id);
            return b2bcustomermodel;
        }

        public LayoutFormViewModel GetLayoutData(CoreViewModel model)
        {
            var layoutmodel = BookingDataCoreRepository.GetLayoutFormViewModel(model);
            return layoutmodel;
        }

        public List<BookingProcessViewModel> GetDataByProviderId(int providerid)
        {
            return BookingDataCoreRepository.GetBookingProcessesByPartnerId(providerid);
        }

        public LayoutCoreViewModel GetCoreLayoutData(CoreViewModel model)
        {
            return BookingDataCoreRepository.GetLayoutViewModel(model);
        }

        public CoreViewModel GetCoreDataById(string id)
        {
            throw new NotImplementedException();
        }

        public void CheckEmail(string id, string email)
        {
            throw new NotImplementedException();
        }
    }
}