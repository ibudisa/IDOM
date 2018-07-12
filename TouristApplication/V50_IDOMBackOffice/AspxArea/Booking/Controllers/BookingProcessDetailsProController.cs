using IdomOffice.Interface.BackOffice.Booking;
using IdomOffice.Interface.BackOffice.BookingTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using V50_IDOMBackOffice.AspxArea.Booking.Repositorys;

namespace V50_IDOMBackOffice.AspxArea.Booking.Controllers
{
    public class BookingProcessDetailsProController
    {
        public BookingProcessDetailsViewModel GetModel(string id)
        {
            return BookingDataRepository.GetBookingProcessDetailsViewModel(id);
        }

        public string GetActionUrl(int actionValue, BookingProcessDetailsViewModel model, List<StatusDataDocument> data)
        {
            return BookingDataRepository.GetActionUrl(actionValue, model, data);
        }

        private string GetUrlForCreateBookingConfirmation(BookingProcessDetailsViewModel model)
        {
            return string.Empty;
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

        public List<BookingProcessViewModel> GetBookingProcesses()
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

        public List<ApplicationKeyViewModel> GetApplicationKeys()
        {
            return BookingDataRepository.GetApplicationKeyViewModel();
        }
        public void AddMasterData(ApplicationKeyViewModel model)
        {
            BookingDataRepository.AddMasterData(model);
        }
        public void UpdateMasterData(ApplicationKeyViewModel model)
        {
            BookingDataRepository.UpdateMasterData(model);
        }

        public ApplicationKeyViewModel GetApplicationKeyById(string id)
        {
            return BookingDataRepository.GetApplicantKeyViewModelById(id);
        }

        public ApplicationKeyViewModel GetApplicationKeyByName(string name)
        {
            return BookingDataRepository.GetApplicantKeyViewModelByName(name);
        }

        public List<ProviderAnnouncementViewModel> GetProviderAnnouncements()
        {
            return BookingDataDocumentsRepository.GetProviderAnnouncementViewModel();
        }
        public void AddMasterData(ProviderAnnouncementViewModel model)
        {
            BookingDataDocumentsRepository.AddMasterData(model);
        }
        public void UpdateMasterData(ProviderAnnouncementViewModel model)
        {
            BookingDataDocumentsRepository.UpdateMasterData(model);
        }
        public ProviderAnnouncementViewModel GetProviderAnnouncement(string id)
        {
            return BookingDataDocumentsRepository.GetProviderAnnouncementViewModelById(id);
        }
        public ProviderAnnouncementViewModel GetProviderAnnouncementByBookingId(string id)
        {
            return BookingDataDocumentsRepository.GetProviderAnnouncementViewModelByBookingId(id);
        }

        public void CreateProviderAnnouncement(string id)
        {
            BookingDataDocumentsRepository.CreateProviderAnnouncement(id);
        }
        public List<BookingConfirmationViewModel> GetProviderConfirmations()
        {
            return BookingDataDocumentsRepository.GetBookingConfirmationViewModel();
        }

        public void AddMasterData(BookingConfirmationViewModel model)
        {
            BookingDataDocumentsRepository.AddMasterData(model);
        }

        public void UpdateMasterData(BookingConfirmationViewModel model)
        {
            BookingDataDocumentsRepository.UpdateMasterData(model);
        }

        public BookingConfirmationViewModel GetBookingConfirmation(string id)
        {
            return BookingDataDocumentsRepository.GetBookingConfirmationViewModelById(id);
        }

        public BookingConfirmationViewModel GetBookingConfirmationByBookingId(string id)
        {
            return BookingDataDocumentsRepository.GetBookingConfirmationViewModelByBookingId(id);
        }

        public BookingConfirmationViewModel CreateBookingConfirmation(string bookingid)
        {
            return BookingDataDocumentsRepository.CreateBookingConfirmation(bookingid);
        }
        public List<BookingInquiryViewModel> GetBookingInquires()
        {
            return BookingDataDocumentsRepository.GetBookingInquiryViewModel();
        }

        public void AddMasterData(BookingInquiryViewModel model)
        {
            BookingDataDocumentsRepository.AddMasterData(model);
        }

        public void AddMasterDataFromBookingProcess(BookingProcessViewModel model, string inquirynumber)
        {
            BookingDataDocumentsRepository.AddMasterData(model, inquirynumber);
        }

        public void UpdateMasterData(BookingInquiryViewModel model)
        {
            BookingDataDocumentsRepository.UpdateMasterData(model);
        }

        public BookingInquiryViewModel GetBookingInquiry(string id)
        {
            return BookingDataDocumentsRepository.GetBookingInquiryViewModelById(id);
        }

        public BookingInquiryViewModel GetBookingInquiryByBookingId(string id)
        {
            return BookingDataDocumentsRepository.GetBookingInquiryViewModelByBookingId(id);
        }

        public BookingProcessItem GetBookingProcessItemById(string id)
        {
            return BookingDataRepository.GetItemById(id);
        }

        public string GetDocumentContent(BookingProcessItemTyp type,string id)
        {
            return BookingDataDocumentsRepository.GetHtmlFromDocument(type, id);
        }
    }
}