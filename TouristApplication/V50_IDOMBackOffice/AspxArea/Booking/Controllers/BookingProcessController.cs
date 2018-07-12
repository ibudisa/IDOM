using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using V50_IDOMBackOffice.AspxArea.Booking.Repositorys;

namespace V50_IDOMBackOffice.AspxArea.Booking.Controllers
{
    public class BookingProcessController
    {
        public List<BookingProcessViewModel> Init()
        {
            var list = BookingDataRepository.GetBookingProcessViewModel();
            return list;
        }
        public void AddBookingProcess(BookingProcessViewModel model)
        {
            BookingDataRepository.AddMasterData(model);
        }
        public void UpdateBookingProcess(BookingProcessViewModel model)
        {
            BookingDataRepository.UpdateMasterData(model);
        }

        public void DeleteBookingProcess(string id)
        {
            BookingDataRepository.DeleteBookingProcess(id);
        }

        public BookingProcessViewModel GetBookingProcess(string id)
        {
           return BookingDataRepository.GetBookingProcess(id);
        }

        public bool GetApplicantPaymentStatus(string id)
        {
            return BookingDataRepository.CheckApplicantPaymentStatus(id);
        }
    }
}