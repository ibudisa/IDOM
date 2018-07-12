using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using V50_IDOMBackOffice.AspxArea.Booking.Repositorys;

namespace V50_IDOMBackOffice.AspxArea.Booking.Controllers
{
    public class BookingInquiryController
    {
        public List<BookingInquiryViewModel> Init()
        {
            return BookingDataRepository.GetBookingInquiryViewModel();
        }

        public void AddMasterData(BookingInquiryViewModel model)
        {
            BookingDataRepository.AddMasterData(model);
        }

        public void AddMasterDataFromBookingProcess(BookingProcessViewModel model,string inquirynumber)
        {
            BookingDataRepository.AddMasterData(model, inquirynumber);
        }

        public void UpdateMasterData(BookingInquiryViewModel model)
        {
            BookingDataRepository.UpdateMasterData(model);
        }

        public BookingInquiryViewModel GetBookingInquiry(string id)
        {
            return BookingDataRepository.GetBookingInquiryViewModelById(id);
        }

        public BookingInquiryViewModel GetBookingInquiryByBookingId(string id)
        {
            return BookingDataRepository.GetBookingInquiryViewModelByBookingId(id);
        }
    }
}