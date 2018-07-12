using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdomOffice.Interface.BackOffice.MasterData;
using IdomOffice.Interface.BackOffice.PriceLists;
using IdomOffice.Interface.BackOffice.Booking;
using IdomOffice.Interface.BackOffice.BookingTemplate;
using IdomOffice.Interface.BackOffice.Users;

namespace V50_IDOMBackOffice.PlugIn.Controller
{
    public class PlugInManager
    {
        public static IMasterDataManager GetMasterDataManager()
        {
            
            return new IdomOffice.PlugIn.BackOffice.MasterData.MasterDataManager();
        }

        public static IPriceListManager GetPriceListManager()
        {
            
            return new IdomOffice.PlugIn.BackOffice.PriceLists.PriceListManager();
        }

        public static IBookingDataManager GetBookingDataManager()
        {
            
            return new IdomOffice.PlugIn.BackOffice.Booking.BookingDataManager();
        }
        public static IApplicationDataManager GetApplicationDataManager()
        {
            
            return new IdomOffice.PlugIn.BackOffice.BookingTemplate.ApplicationDataManager();
        }

        public static IUserManager GetUserManager()
        {
           
            return new IdomOffice.PlugIn.BackOffice.Users.UserManager();
        }

    }
}
