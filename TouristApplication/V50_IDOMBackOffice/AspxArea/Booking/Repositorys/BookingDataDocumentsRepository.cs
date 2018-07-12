using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using V50_IDOMBackOffice.PlugIn.Controller;
using IdomOffice.Interface.BackOffice.Booking;
using IdomOffice.Interface.BackOffice.Booking.Documents;
using IdomOffice.Interface.BackOffice.Booking.Core;
using IdomOffice.Interface.BackOffice.BookingTemplate;
using System.Text.RegularExpressions;


namespace V50_IDOMBackOffice.AspxArea.Booking.Repositorys
{
    public class BookingDataDocumentsRepository
    {
        //Dohvati sve booking procese iz baze i mapiraj u view objekte i vrati listu
        public static List<BookingProcessViewModel> GetBookingProcessViewModel()
        {
            var model = new List<BookingProcessViewModel>();
            var manager = PlugInManager.GetBookingDataManager();

            var bookingprocesses = manager.GetBookingProcesses();

            foreach (var bookingprocess in bookingprocesses)
            {
                var m = new BookingProcessViewModel();
                m.Id = bookingprocess.Id;
                m.Status = bookingprocess.Status;
                m.Country = bookingprocess.OfferInfo.Country;
                m.PlaceName = bookingprocess.OfferInfo.PlaceName;
                m.SiteName = bookingprocess.OfferInfo.SiteName;
                m.TourOperatorCode = bookingprocess.OfferInfo.TourOperatorCode;
                m.CheckIn = bookingprocess.OfferInfo.CheckIn;
                m.CheckOut = bookingprocess.OfferInfo.CheckOut;
                m.FirstName = bookingprocess.TravelApplicant.FirstName;
                m.LastName = bookingprocess.TravelApplicant.LastName;
                m.TravelerCountry = bookingprocess.TravelApplicant.Contry;
                m.Address = bookingprocess.TravelApplicant.Adress;
                m.BookingProcessItemList = bookingprocess.BookingProcessItemList;
                m.TravelApplicantId = bookingprocess.TravelApplicantId;
                m.PartnerId = bookingprocess.SellingPartner;
                m.ProviderId = bookingprocess.AccProvider;
                m.Season = bookingprocess.Season;
                m.OfferName = bookingprocess.OfferInfo.OfferName;
                m.MobilePhone = bookingprocess.TravelApplicant.MobilePhone;
                m.Phone = bookingprocess.TravelApplicant.Phone;
                m.ZipCode = bookingprocess.TravelApplicant.ZipCode;
                m.TravelerPlace = bookingprocess.TravelApplicant.Place;
                m.Days = bookingprocess.OfferInfo.Days;
                m.PaymentsForProvider = bookingprocess.PaymentsForProvider;
                m.Payments = bookingprocess.Payments;
                m.BookingNumber = bookingprocess.BookingNumber;
                model.Add(m);
            }

            return model;
        }

        // Dohvati View od BookingProcessa na osnovi id parametra
        public static BookingProcessViewModel GetBookingProcess(string id)
        {
            var m = GetBookingProcessViewModel().Find(f => f.Id == id);
            return m;
        }

        public static List<BookingInquiryViewModel> GetBookingInquiryViewModel()
        {
            var model = new List<BookingInquiryViewModel>();
            var manager = PlugInManager.GetBookingDataManager();

            var bookinginquires = manager.GetBookingInquires();

            foreach (var bookinginquiry in bookinginquires)
            {
                var m = new BookingInquiryViewModel();
                m.id = bookinginquiry.Id;
                m.BookingProcessId = bookinginquiry.BookingProcessId;
                m.Country = bookinginquiry.OfferInfo.Country;
                m.PlaceName = bookinginquiry.OfferInfo.PlaceName;
                m.SiteName = bookinginquiry.OfferInfo.SiteName;
                m.TourOperatorCode = bookinginquiry.OfferInfo.TourOperatorCode;
                m.CheckIn = bookinginquiry.OfferInfo.CheckIn;
                m.CheckOut = bookinginquiry.OfferInfo.CheckOut;
                m.FirstName = bookinginquiry.TravelApplicant.FirstName;
                m.LastName = bookinginquiry.TravelApplicant.LastName;
                m.TravelerCountry = bookinginquiry.TravelApplicant.Contry;
                m.Address = bookinginquiry.TravelApplicant.Adress;
                m.OfferName = bookinginquiry.OfferInfo.OfferName;
                m.MobilePhone = bookinginquiry.TravelApplicant.MobilePhone;
                m.Phone = bookinginquiry.TravelApplicant.Phone;
                m.ZipCode = bookinginquiry.TravelApplicant.ZipCode;
                m.TravelerPlace = bookinginquiry.TravelApplicant.Place;
                m.HtmlDocumentView = bookinginquiry.HtmlDocumentView;
                model.Add(m);
            }

            return model;
        }

        public static void AddMasterData(BookingInquiryViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var bookinginquiry = new BookingInquiry();
            bookinginquiry.Id = Guid.NewGuid().ToString();
            bookinginquiry.BookingInquiryNummer = model.BookingInquiryNummer;
            bookinginquiry.BookingProcessId = model.BookingProcessId;
            bookinginquiry.docType = model.docType;
            bookinginquiry.OfferInfo.Country = model.Country;
            bookinginquiry.OfferInfo.PlaceName = model.PlaceName;
            bookinginquiry.OfferInfo.SiteName = model.SiteName;
            bookinginquiry.OfferInfo.TourOperatorCode = model.TourOperatorCode;
            bookinginquiry.OfferInfo.CheckIn = model.CheckIn;
            bookinginquiry.OfferInfo.CheckOut = model.CheckOut;
            bookinginquiry.TravelApplicant.FirstName = model.FirstName;
            bookinginquiry.TravelApplicant.LastName = model.LastName;
            bookinginquiry.TravelApplicant.Contry = model.TravelerCountry;
            bookinginquiry.TravelApplicant.Adress = model.Address;
            bookinginquiry.OfferInfo.OfferName = model.OfferName;
            bookinginquiry.TravelApplicant.MobilePhone = model.MobilePhone;
            bookinginquiry.TravelApplicant.Phone = model.Phone;
            bookinginquiry.TravelApplicant.ZipCode = model.ZipCode;
            bookinginquiry.TravelApplicant.Place = model.PlaceName;
            bookinginquiry.HtmlDocumentView = model.HtmlDocumentView;

            manager.AddMasterData(bookinginquiry);
        }

        public static void UpdateMasterData(BookingInquiryViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var bookinginquiry = manager.GetBookingInquiry(model.id);
            bookinginquiry.Id = model.id;
            bookinginquiry.BookingInquiryNummer = model.BookingInquiryNummer;
            bookinginquiry.BookingProcessId = model.BookingProcessId;
            bookinginquiry.docType = model.docType;
            bookinginquiry.OfferInfo.Country = model.Country;
            bookinginquiry.OfferInfo.PlaceName = model.PlaceName;
            bookinginquiry.OfferInfo.SiteName = model.SiteName;
            bookinginquiry.OfferInfo.TourOperatorCode = model.TourOperatorCode;
            bookinginquiry.OfferInfo.CheckIn = model.CheckIn;
            bookinginquiry.OfferInfo.CheckOut = model.CheckOut;
            bookinginquiry.TravelApplicant.FirstName = model.FirstName;
            bookinginquiry.TravelApplicant.LastName = model.LastName;
            bookinginquiry.TravelApplicant.Contry = model.TravelerCountry;
            bookinginquiry.TravelApplicant.Adress = model.Address;
            bookinginquiry.OfferInfo.OfferName = model.OfferName;
            bookinginquiry.TravelApplicant.MobilePhone = model.MobilePhone;
            bookinginquiry.TravelApplicant.Phone = model.Phone;
            bookinginquiry.TravelApplicant.ZipCode = model.ZipCode;
            bookinginquiry.TravelApplicant.Place = model.PlaceName;
            bookinginquiry.HtmlDocumentView = model.HtmlDocumentView;

            manager.UpdateMasterData(bookinginquiry);
        }

        public static BookingInquiryViewModel GetBookingInquiryViewModelById(string id)
        {
            var model = GetBookingInquiryViewModel().Find(m => m.id == id);
            return model;
        }

        public static BookingInquiryViewModel GetBookingInquiryViewModelByBookingId(string id)
        {
            var model = GetBookingInquiryViewModel().Find(m => m.BookingProcessId == id);
            return model;
        }

        public static List<BookingConfirmationViewModel> GetBookingConfirmationViewModel()
        {
            var model = new List<BookingConfirmationViewModel>();
            var manager = PlugInManager.GetBookingDataManager();

            var bookingconfirmations = manager.GetBookingConfirmations();

            foreach (var bookingconfirmation in bookingconfirmations)
            {
                var m = new BookingConfirmationViewModel();
                m.id = bookingconfirmation.Id;
                m.docType = bookingconfirmation.docType;
                m.BookingProcessId = bookingconfirmation.BookingProcessId;
                m.BookingInquiryNummer = bookingconfirmation.BookingInquiryNummer;
                m.BookingConfirmationNummer = bookingconfirmation.BookingConfirmationNummer;
                m.Country = bookingconfirmation.OfferInfo.Country;
                m.PlaceName = bookingconfirmation.OfferInfo.PlaceName;
                m.SiteName = bookingconfirmation.OfferInfo.SiteName;
                m.TourOperatorCode = bookingconfirmation.OfferInfo.TourOperatorCode;
                m.CheckIn = bookingconfirmation.OfferInfo.CheckIn;
                m.CheckOut = bookingconfirmation.OfferInfo.CheckOut;
                m.FirstName = bookingconfirmation.TravelApplicant.FirstName;
                m.LastName = bookingconfirmation.TravelApplicant.LastName;
                m.TravelerCountry = bookingconfirmation.TravelApplicant.Contry;
                m.Address = bookingconfirmation.TravelApplicant.Adress;
                m.OfferName = bookingconfirmation.OfferInfo.OfferName;
                m.MobilePhone = bookingconfirmation.TravelApplicant.MobilePhone;
                m.Phone = bookingconfirmation.TravelApplicant.Phone;
                m.ZipCode = bookingconfirmation.TravelApplicant.ZipCode;
                m.TravelerPlace = bookingconfirmation.TravelApplicant.Place;
                m.HtmlDocumentView = bookingconfirmation.HtmlDocumentView;
                model.Add(m);
            }

            return model;
        }


        public static void AddMasterData(BookingConfirmationViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var bookingconfirmation = new BookingConfirmation();
            bookingconfirmation.Id = Guid.NewGuid().ToString();
            bookingconfirmation.BookingInquiryNummer = model.BookingInquiryNummer;
            bookingconfirmation.BookingConfirmationNummer = model.BookingConfirmationNummer;
            bookingconfirmation.BookingProcessId = model.BookingProcessId;
            bookingconfirmation.docType = model.docType;
            bookingconfirmation.OfferInfo.Country = model.Country;
            bookingconfirmation.OfferInfo.PlaceName = model.PlaceName;
            bookingconfirmation.OfferInfo.SiteName = model.SiteName;
            bookingconfirmation.OfferInfo.TourOperatorCode = model.TourOperatorCode;
            bookingconfirmation.OfferInfo.CheckIn = model.CheckIn;
            bookingconfirmation.OfferInfo.CheckOut = model.CheckOut;
            bookingconfirmation.TravelApplicant.FirstName = model.FirstName;
            bookingconfirmation.TravelApplicant.LastName = model.LastName;
            bookingconfirmation.TravelApplicant.Contry = model.TravelerCountry;
            bookingconfirmation.TravelApplicant.Adress = model.Address;
            bookingconfirmation.OfferInfo.OfferName = model.OfferName;
            bookingconfirmation.TravelApplicant.MobilePhone = model.MobilePhone;
            bookingconfirmation.TravelApplicant.Phone = model.Phone;
            bookingconfirmation.TravelApplicant.ZipCode = model.ZipCode;
            bookingconfirmation.TravelApplicant.Place = model.PlaceName;
            bookingconfirmation.HtmlDocumentView = model.HtmlDocumentView;

            manager.AddMasterData(bookingconfirmation);
        }

        public static void UpdateMasterData(BookingConfirmationViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var bookingconfirmation = manager.GetBookingConfirmation(model.id);
            bookingconfirmation.Id = model.id;
            bookingconfirmation.BookingInquiryNummer = model.BookingInquiryNummer;
            bookingconfirmation.BookingConfirmationNummer = model.BookingConfirmationNummer;
            bookingconfirmation.BookingProcessId = model.BookingProcessId;
            bookingconfirmation.docType = model.docType;
            bookingconfirmation.OfferInfo.Country = model.Country;
            bookingconfirmation.OfferInfo.PlaceName = model.PlaceName;
            bookingconfirmation.OfferInfo.SiteName = model.SiteName;
            bookingconfirmation.OfferInfo.TourOperatorCode = model.TourOperatorCode;
            bookingconfirmation.OfferInfo.CheckIn = model.CheckIn;
            bookingconfirmation.OfferInfo.CheckOut = model.CheckOut;
            bookingconfirmation.TravelApplicant.FirstName = model.FirstName;
            bookingconfirmation.TravelApplicant.LastName = model.LastName;
            bookingconfirmation.TravelApplicant.Contry = model.TravelerCountry;
            bookingconfirmation.TravelApplicant.Adress = model.Address;
            bookingconfirmation.OfferInfo.OfferName = model.OfferName;
            bookingconfirmation.TravelApplicant.MobilePhone = model.MobilePhone;
            bookingconfirmation.TravelApplicant.Phone = model.Phone;
            bookingconfirmation.TravelApplicant.ZipCode = model.ZipCode;
            bookingconfirmation.TravelApplicant.Place = model.PlaceName;
            bookingconfirmation.HtmlDocumentView = model.HtmlDocumentView;

            manager.UpdateMasterData(bookingconfirmation);
        }

        public static BookingConfirmationViewModel GetBookingConfirmationViewModelById(string id)
        {
            var model = GetBookingConfirmationViewModel().Find(m => m.id == id);
            return model;
        }

        public static BookingConfirmationViewModel GetBookingConfirmationViewModelByBookingId(string id)
        {
            var model = GetBookingConfirmationViewModel().Find(m => m.BookingProcessId == id);
            return model;
        }

        public static BookingConfirmationViewModel CreateBookingConfirmation(string bookingid)
        {
            var bookingmodel = GetBookingProcess(bookingid);
            var bookingconfirmation = new BookingConfirmationViewModel();

            bookingconfirmation.Address = bookingmodel.Address;
            bookingconfirmation.BookingProcessId = bookingid;
            bookingconfirmation.CheckIn = bookingmodel.CheckIn;
            bookingconfirmation.CheckOut = bookingmodel.CheckOut;
            bookingconfirmation.Country = bookingmodel.Country;
            bookingconfirmation.FirstName = bookingmodel.FirstName;
            bookingconfirmation.LastName = bookingmodel.LastName;
            bookingconfirmation.MobilePhone = bookingmodel.MobilePhone;
            bookingconfirmation.OfferName = bookingmodel.OfferName;
            bookingconfirmation.Phone = bookingmodel.Phone;
            bookingconfirmation.PlaceName = bookingmodel.PlaceName;
            bookingconfirmation.SiteName = bookingmodel.SiteName;
            bookingconfirmation.TourOperatorCode = bookingmodel.TourOperatorCode;
            bookingconfirmation.TravelerCountry = bookingmodel.TravelerCountry;
            bookingconfirmation.TravelerPlace = bookingmodel.TravelerPlace;
            bookingconfirmation.ZipCode = bookingmodel.ZipCode;

            return bookingconfirmation;
        }
        public static List<ProviderAnnouncementViewModel> GetProviderAnnouncementViewModel()
        {
            var model = new List<ProviderAnnouncementViewModel>();
            var manager = PlugInManager.GetBookingDataManager();

            var provideranouncements = manager.GetProviderAnnouncements();

            foreach (var announcement in provideranouncements)
            {
                var m = new ProviderAnnouncementViewModel();
                m.Id = announcement.Id;
                m.Adults = announcement.Adults;
                m.BookingId = announcement.BookingProcessId;
                m.CheckIn = announcement.CheckIn;
                m.CheckOut = announcement.CheckOut;
                m.Country = announcement.Country;
                m.docType = announcement.docType;
                m.FirstName = announcement.FirstName;
                m.LastName = announcement.LastName;
                m.OfferName = announcement.OfferName;
                m.PlaceName = announcement.PlaceName;
                m.SiteName = announcement.SiteName;
                m.TravelerAdress = announcement.TravelerAdress;
                m.TravelerCountry = announcement.TravelerCountry;
                m.TravelerPlace = announcement.TravelerPlace;
                m.TravelerZipCode = announcement.TravelerZipCode;
                m.HtmlDocumentView = announcement.HtmlDocumentView;

                model.Add(m);
            }

            return model;
        }

        public static void AddMasterData(ProviderAnnouncementViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var announcement = new ProviderAnnouncement();

            announcement.Id = Guid.NewGuid().ToString();
            announcement.Adults = model.Adults;
            announcement.BookingProcessId = model.BookingId;
            announcement.CheckIn = model.CheckIn;
            announcement.CheckOut = model.CheckOut;
            announcement.Country = model.Country;
            announcement.docType = model.docType;
            announcement.FirstName = model.FirstName;
            announcement.LastName = model.LastName;
            announcement.OfferName = model.LastName;
            announcement.PlaceName = model.PlaceName;
            announcement.SiteName = model.SiteName;
            announcement.TravelerAdress = model.TravelerAdress;
            announcement.TravelerCountry = model.TravelerCountry;
            announcement.TravelerPlace = model.TravelerPlace;
            announcement.TravelerZipCode = model.TravelerZipCode;
            announcement.HtmlDocumentView = model.HtmlDocumentView;

            manager.AddMasterData(announcement);
        }

        public static void UpdateMasterData(ProviderAnnouncementViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var announcement = manager.GetProviderAnnouncement(model.Id);

            announcement.Id = model.Id;
            announcement.Adults = model.Adults;
            announcement.BookingProcessId = model.BookingId;
            announcement.CheckIn = model.CheckIn;
            announcement.CheckOut = model.CheckOut;
            announcement.Country = model.Country;
            announcement.docType = model.docType;
            announcement.FirstName = model.FirstName;
            announcement.LastName = model.LastName;
            announcement.OfferName = model.LastName;
            announcement.PlaceName = model.PlaceName;
            announcement.SiteName = model.SiteName;
            announcement.TravelerAdress = model.TravelerAdress;
            announcement.TravelerCountry = model.TravelerCountry;
            announcement.TravelerPlace = model.TravelerPlace;
            announcement.TravelerZipCode = model.TravelerZipCode;
            announcement.HtmlDocumentView = model.HtmlDocumentView;

            manager.UpdateMasterData(announcement);
        }

        public static ProviderAnnouncementViewModel GetProviderAnnouncementViewModelById(string id)
        {
            var model = GetProviderAnnouncementViewModel().Find(m => m.Id == id);
            return model;
        }

        public static ProviderAnnouncementViewModel GetProviderAnnouncementViewModelByBookingId(string id)
        {
            var model = GetProviderAnnouncementViewModel().Find(m => m.BookingId == id);
            return model;
        }

        public static void CreateProviderAnnouncement(string id)
        {
            var model = GetBookingProcess(id);
            var announcement = new ProviderAnnouncementViewModel();


            announcement.BookingId = model.Id;
            announcement.CheckIn = model.CheckIn;
            announcement.CheckOut = model.CheckOut;
            announcement.Country = model.Country;
            announcement.docType = "ProviderAnnouncement";
            announcement.FirstName = model.FirstName;
            announcement.LastName = model.LastName;
            announcement.OfferName = model.LastName;
            announcement.PlaceName = model.PlaceName;
            announcement.SiteName = model.SiteName;
            announcement.TravelerCountry = model.TravelerCountry;
            announcement.TravelerPlace = model.TravelerPlace;

            AddMasterData(announcement);

        }

        public static List<ProviderConfirmationViewModel> GetProviderConfirmationViewModel()
        {
            var model = new List<ProviderConfirmationViewModel>();
            var manager = PlugInManager.GetBookingDataManager();

            var providerconfirmations = manager.GetProviderConfirmations();

            foreach (var confirmation in providerconfirmations)
            {
                var m = new ProviderConfirmationViewModel();
                m.Id = confirmation.Id;
                m.BookingId = confirmation.BookingProcessId;
                m.docType = confirmation.docType;
                m.CreateDate = confirmation.CreateDate;
                m.Title = confirmation.Title;
                m.Content = confirmation.Content;

                model.Add(m);
            }

            return model;
        }

        public static void AddMasterData(ProviderConfirmationViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var providerconfirmation = new ProviderConfirmation();

            providerconfirmation.Id = Guid.NewGuid().ToString();
            providerconfirmation.BookingProcessId = model.BookingId;
            providerconfirmation.docType = model.docType;
            providerconfirmation.CreateDate = model.CreateDate;
            providerconfirmation.Title = model.Title;
            providerconfirmation.Content = model.Content;

            manager.AddMasterData(providerconfirmation);
        }

        public static void UpdateMasterData(ProviderConfirmationViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var providerconfirmation = manager.GetProviderConfirmation(model.Id);

            providerconfirmation.Id = model.Id;
            providerconfirmation.BookingProcessId = model.BookingId;
            providerconfirmation.docType = model.docType;
            providerconfirmation.CreateDate = model.CreateDate;
            providerconfirmation.Title = model.Title;
            providerconfirmation.Content = model.Content;

            manager.UpdateMasterData(providerconfirmation);
        }

        public static ProviderConfirmationViewModel GetProviderConfirmationViewModelById(string id)
        {
            var model = GetProviderConfirmationViewModel().Find(m => m.Id == id);
            return model;
        }

        public static ProviderConfirmationViewModel GetProviderConfirmationViewModelByBookingId(string id)
        {
            var model = GetProviderConfirmationViewModel().Find(m => m.BookingId == id);
            return model;
        }

        public static void AddMasterData(BookingProcessViewModel model, string inquirynumber)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var bookinginquiry = new BookingInquiry();
            bookinginquiry.Id = Guid.NewGuid().ToString();
            bookinginquiry.BookingInquiryNummer = inquirynumber;
            bookinginquiry.BookingProcessId = model.Id;
            bookinginquiry.OfferInfo.Country = model.Country;
            bookinginquiry.OfferInfo.PlaceName = model.PlaceName;
            bookinginquiry.OfferInfo.SiteName = model.SiteName;
            bookinginquiry.OfferInfo.TourOperatorCode = model.TourOperatorCode;
            bookinginquiry.OfferInfo.CheckIn = model.CheckIn;
            bookinginquiry.OfferInfo.CheckOut = model.CheckOut;
            bookinginquiry.TravelApplicant.FirstName = model.FirstName;
            bookinginquiry.TravelApplicant.LastName = model.LastName;
            bookinginquiry.TravelApplicant.Contry = model.TravelerCountry;
            bookinginquiry.TravelApplicant.Adress = model.Address;
            bookinginquiry.OfferInfo.OfferName = model.OfferName;
            bookinginquiry.TravelApplicant.MobilePhone = model.MobilePhone;
            bookinginquiry.TravelApplicant.Phone = model.Phone;
            bookinginquiry.TravelApplicant.ZipCode = model.ZipCode;
            bookinginquiry.TravelApplicant.Place = model.PlaceName;

            manager.AddMasterData(bookinginquiry);

        }

        public static string GetHtmlFromDocument(BookingProcessItemTyp bookingtype,string id)
        {
            string itemcontent = string.Empty;


            if(bookingtype==BookingProcessItemTyp.BookingConfirmation)
            {
                var bookingconfirmation = GetBookingConfirmationViewModelById(id);
                itemcontent = bookingconfirmation.HtmlDocumentView;
            }
            else if(bookingtype==BookingProcessItemTyp.BookingInquiry)
            {
                var bookinginquiry = GetBookingInquiryViewModelById(id);
                itemcontent = bookinginquiry.HtmlDocumentView;
            }
            else if(bookingtype==BookingProcessItemTyp.ProviderAnnouncement)
            {
                var providerannouncement = GetProviderAnnouncementViewModelById(id);
                itemcontent = providerannouncement.HtmlDocumentView;
            }
            else if(bookingtype==BookingProcessItemTyp.ProviderConfirmation)
            {
                var providerconfirmation = GetProviderConfirmationViewModelById(id);
                itemcontent = providerconfirmation.Content;
            }
            return itemcontent;
        }
    }
}