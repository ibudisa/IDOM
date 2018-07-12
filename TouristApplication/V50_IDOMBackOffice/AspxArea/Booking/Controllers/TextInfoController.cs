using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using V50_IDOMBackOffice.AspxArea.Booking.Repositorys;


namespace V50_IDOMBackOffice.AspxArea.Booking.Controllers
{
    public class TextInfoController
    {
        public List<TextInfoViewModel> Init()
        {
            return BookingDataRepository.GetTextInfoViewModel();
        }

        public void AddMasterData(TextInfoViewModel model)
        {
            BookingDataRepository.AddMasterData(model);
        }

        public TextInfoViewModel GetTextInfo(string id)
        {
            return BookingDataRepository.GetTextInfoViewModelById(id);
        }
    }
}