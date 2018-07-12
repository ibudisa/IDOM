using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V50_IDOMBackOffice.AspxArea.Booking.Models;

namespace V50_IDOMBackOffice.AspxArea.Booking.Controllers
{
    public interface ICoreController
    {
        List<CoreViewModel> Init();
        void Add(CoreViewModel model);
        void Update(CoreViewModel model);
        void Delete(string id);
        CoreViewModel GetData(string id);
        LayoutFormViewModel GetLayoutData(CoreViewModel model);
        List<BookingProcessViewModel> GetDataByProviderId(int providerid);
        LayoutCoreViewModel GetCoreLayoutData(CoreViewModel model);
        CoreViewModel GetCoreDataById(string id);
        void CheckEmail(string id, string email);
    }
}
