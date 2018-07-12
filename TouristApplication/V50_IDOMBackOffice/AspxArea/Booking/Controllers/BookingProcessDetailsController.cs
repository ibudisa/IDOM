using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using V50_IDOMBackOffice.AspxArea.Booking.Repositorys;
using IdomOffice.Interface.BackOffice.Booking;
using IdomOffice.Interface.BackOffice.BookingTemplate;

namespace V50_IDOMBackOffice.AspxArea.Booking.Controllers
{
    public class BookingProcessDetailsController
    {
        public BookingProcessDetailsViewModel GetModel(string id)
        {
            return BookingDataRepository.GetBookingProcessDetailsViewModel(id);
        }
        public List<StatusDataDocument> GetStatuses(DocumentProcessStatus status)
        {
            return BookingDataRepository.GetStatuses(status);
        }

        public List<StatusDataDocument> GetStatusesProviderConfirmedBefore()
        {
            return BookingDataRepository.GetStatusesProviderConfirmedBefore();
        }
        public List<StatusDataDocument> GetStatusesProviderConfirmedAfter()
        {
            return BookingDataRepository.GetStatusesProviderConfirmedAfter();
        }

        public string GetFormName(string formcode)
        {
            return BookingDataRepository.GetFormName(formcode);
        }
    }
}