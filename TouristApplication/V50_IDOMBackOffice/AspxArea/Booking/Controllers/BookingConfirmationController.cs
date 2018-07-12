using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using V50_IDOMBackOffice.AspxArea.Booking.Repositorys;

namespace V50_IDOMBackOffice.AspxArea.Booking.Controllers
{
    public class BookingConfirmationController
    {
        public List<BookingConfirmationViewModel> Init()
        {
            return BookingDataRepository.GetBookingConfirmationViewModel();
        }

        public void AddMasterData(BookingConfirmationViewModel model)
        {
            BookingDataRepository.AddMasterData(model);
        }

        public void UpdateMasterData(BookingConfirmationViewModel model)
        {
            BookingDataRepository.UpdateMasterData(model);
        }

        public BookingConfirmationViewModel GetBookingConfirmation(string id)
        {
           return BookingDataRepository.GetBookingConfirmationViewModelById(id);
        }

        public BookingConfirmationViewModel GetBookingConfirmationByBookingId(string id)
        {
            return BookingDataRepository.GetBookingConfirmationViewModelByBookingId(id);
        }

        public BookingConfirmationViewModel CreateBookingConfirmation(string bookingid)
        {
            return BookingDataRepository.CreateBookingConfirmation(bookingid);
        }
    }
}