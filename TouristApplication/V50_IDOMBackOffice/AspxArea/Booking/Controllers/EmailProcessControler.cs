using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using V50_IDOMBackOffice.AspxArea.Booking.Repositorys;
using IdomOffice.Interface.BackOffice.Booking;

namespace V50_IDOMBackOffice.AspxArea.Booking.Controllers
{
    public class EmailProcessControler
    {
       public int GetReceiver(string id, string comboId)
        {
            return BookingDataRepository.GetReceiver(id,  comboId);
        }
        public List<EmailProcessViewModel> GetEmailProcessViewModel()
        {
            return BookingDataRepository.GetEmailProcessViewModel();
        }
        public EmailProcessViewModel GetEmailProcessViewModelById(string id)
        {
            return BookingDataRepository.GetEmailProcessViewModelById(id);
        }
        public void AddMasterData(EmailProcessViewModel model)
        {
            BookingDataRepository.AddMasterData(model);

        }
        public EmailProcessViewModel GetEmailProcessViewModelByBookingIdLast(string bookingid)
        {
            return BookingDataRepository.GetEmailProcessViewModelByBookingIdLast(bookingid);
        }
    }
}