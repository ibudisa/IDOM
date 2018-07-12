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
    public class BookingDataRepository
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
                model.Add(m);
            }

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
                model.Add(m);
            }

            return model;
        }
        //Dohvati sve providere iz baze i mapiraj u view objekte i vrati listu
        public static List<CoreViewModel> GetProviderViewModel()
        {
            var model = new List<CoreViewModel>();
            var manager = PlugInManager.GetBookingDataManager();

            var providers = manager.GetProviders();

            foreach (var provider in providers)
            {
                var m = new CoreViewModel();
                m.Id = provider.Id;
                m.Address = provider.Address;
                m.Country = provider.Country;
                m.Bank = provider.Bank;
                m.City = provider.City;
                m.Contacts = provider.Contacts;
                m.IBAN = provider.IBAN;
                m.Name = provider.Name;
                m.PersonalIdentificationNumber = provider.PersonalIdentificationNumber;
                m.Notes = provider.Notes;
                m.ProviderId = provider.ProviderId;
                m.Title=provider.Title;
                m.BookingEmail = provider.BookingEmail;

                int counter = 0;
                foreach (var item in m.Contacts)
                    item.Id = (++counter).ToString();
                counter = 0;
                foreach (var item in m.Notes)
                    item.Id = (++counter).ToString();

                model.Add(m);
            }

            return model;
        }
        //Dohvati sve emailove iz baze i mapiraj u view objekte i vrati listu
        public static List<EmailProcessViewModel> GetEmailProcessViewModel()
        {
            var model = new List<EmailProcessViewModel>();
            var manager = PlugInManager.GetBookingDataManager();

            var emails = manager.GetEmails();

            foreach (var email in emails)
            {
                var m = new EmailProcessViewModel();
                m.Id = email.Id;
                m.Receipent = email.Receipent;
                m.Sender = email.Sender;
                m.Title = email.Title;
                m.docType = email.docType;
                m.BookingId = email.BookingId;
                m.Content = email.Content;
                m.Status = email.Status;

                model.Add(m);
            }

            return model;
        }

        public static List<TextInfoViewModel> GetTextInfoViewModel()
        {
            var model = new List<TextInfoViewModel>();
            var manager = PlugInManager.GetBookingDataManager();

            var textinfos = manager.GetTextInfos();

            foreach (var text in textinfos)
            {
                var m = new TextInfoViewModel();
                m.Id = text.Id;
                m.Title = text.Title;
                m.docType = text.docType;
                m.BookingId = text.BookingId;
                m.Content = text.Content;
                m.Status = text.Status;
                m.Date = text.Date;

                model.Add(m);
            }

            return model;
        }

        public static List<PaymentViewModel> GetApplicantPaymentViewModel()
        {
            var model = new List<PaymentViewModel>();
            var manager = PlugInManager.GetBookingDataManager();

            var applicantpayments = manager.GetApplicantPayments();

            foreach (var payment in applicantpayments)
            {
                var m = new PaymentViewModel();
                m.Id = payment.Id;
                m.docType = payment.docType;
                m.BookingId = payment.BookingId;
                m.Date = payment.Date;
                m.Value = payment.Value;
                m.Title = payment.Title;
                m.PaymentType = payment.PaymentType;

                model.Add(m);
            }

            return model;
        }

        public static List<PaymentViewModel> GetProviderPaymentViewModel()
        {
            var model = new List<PaymentViewModel>();
            var manager = PlugInManager.GetBookingDataManager();

            var providerpayments = manager.GetProviderPayments();

            foreach (var payment in providerpayments)
            {
                var m = new PaymentViewModel();
                m.Id = payment.Id;
                m.docType = payment.docType;
                m.BookingId = payment.BookingId;
                m.Date = payment.Date;
                m.Value = payment.Value;
                m.Title = payment.Title;
                m.PaymentType = payment.PaymentType;

                model.Add(m);
            }

            return model;
        }


        public static List<ApplicationKeyViewModel> GetApplicationKeyViewModel()
        {
            var model = new List<ApplicationKeyViewModel>();
            var manager = PlugInManager.GetBookingDataManager();

            var applicationkeys = manager.GetApplicationKeys();

            foreach (var key in applicationkeys)
            {
                var m = new ApplicationKeyViewModel();
                m.Id = key.Id;
                m.docType = key.docType;
                m.Name = key.Name;
                m.Value = key.Value;
                m.Season = key.Season;

                model.Add(m);
            }

            return model;
        }

        public static List<TemplateViewModel> GetTemplateViewModel()
        {
            var model = new List<TemplateViewModel>();
            var manager = PlugInManager.GetBookingDataManager();

            var templates = manager.GetTemplates();

            foreach (var template in templates)
            {
                var m = new TemplateViewModel();
                m.Id = template.Id;
                m.Name = template.Name;
                m.StatusId = template.StatusId;
                m.Title = template.Title;
                m.Text = template.Text;

                model.Add(m);
            }

            return model;
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

                model.Add(m);
            }

            return model;
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
        //Dohvati sve customere iz baze i mapiraj u view objekte i vrati listu
        public static List<CustomerViewModel> GetCustomerViewModel()
        {
            var model = new List<CustomerViewModel>();
            var manager = PlugInManager.GetBookingDataManager();

            var customers = manager.GetCustomers();

            foreach (var customer in customers)
            {
                var m = new CustomerViewModel();
                m.id = customer.id;
                m.Adress = customer.Adress;
                m.Country = customer.Contry;
                m.CustomerNr = customer.CustomerNr;
                m.EMail = customer.EMail;
                m.FirstName = customer.FirstName;
                m.LastName = customer.LastName;
                m.MobilePhone = customer.MobilePhone;
                m.Phone = customer.Phone;
                m.Place = customer.Place;
                m.Salutation = customer.Salutation;
                m.ZipCode = customer.ZipCode;
                m.Notes = customer.Notes;
                m.Contacts = customer.Contacts;

                int counter = 0;
                foreach (var item in m.Notes)
                    item.Id = (++counter).ToString();
                counter = 0;
                foreach (var item in m.Contacts)
                    item.Id = (++counter).ToString();

                model.Add(m);
            }

            return model;
        }
        //Dohvati sve b2bcustomere iz baze i mapiraj u view objekte i vrati listu
        public static List<CoreViewModel> GetB2BCustomerViewModel()
        {
            var model = new List<CoreViewModel>();
            var manager = PlugInManager.GetBookingDataManager();

            var b2bcustomers = manager.GetB2BCustomers();

            foreach (var b2bcustomer in b2bcustomers)
            {
                var m = new CoreViewModel();
                m.Id = b2bcustomer.Id;
                m.Address = b2bcustomer.Address;
                m.Country = b2bcustomer.Country;
                m.Bank = b2bcustomer.Bank;
                m.City = b2bcustomer.City;
                m.Contacts = b2bcustomer.Contacts;
                m.IBAN = b2bcustomer.IBAN;
                m.Name = b2bcustomer.Name;
                m.PersonalIdentificationNumber = b2bcustomer.PersonalIdentificationNumber;
                m.Notes = b2bcustomer.Notes;
                m.ProviderId = b2bcustomer.PartnerId;
                int counter = 0;
                foreach (var item in m.Contacts)
                    item.Id = (++counter).ToString();
                counter = 0;
                foreach (var item in m.Notes)
                    item.Id = (++counter).ToString();

                model.Add(m);
            }

            return model;
        }
        // Mapiraj view objekt u BookingProcess objekt te ga pohrani u bazu
        public static void AddMasterData(BookingProcessViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var bookingprocess = new BookingProcess();
            bookingprocess.Id = Guid.NewGuid().ToString();
            bookingprocess.Status = model.Status;
            bookingprocess.OfferInfo.Country = model.Country;
            bookingprocess.OfferInfo.PlaceName = model.PlaceName;
            bookingprocess.OfferInfo.SiteName = model.SiteName;
            bookingprocess.OfferInfo.TourOperatorCode = model.TourOperatorCode;
            bookingprocess.OfferInfo.CheckIn = model.CheckIn;
            bookingprocess.OfferInfo.CheckOut = model.CheckOut;
            bookingprocess.TravelApplicant.FirstName = model.FirstName;
            bookingprocess.TravelApplicant.LastName = model.LastName;
            bookingprocess.TravelApplicant.Contry = model.TravelerCountry;
            bookingprocess.TravelApplicant.Adress = model.Address;
            bookingprocess.TravelApplicantId = model.TravelApplicantId;
            bookingprocess.AccProvider = model.PartnerId;
            bookingprocess.Season = model.Season;
            bookingprocess.OfferInfo.OfferName = model.OfferName;
            bookingprocess.TravelApplicant.MobilePhone = model.MobilePhone;
            bookingprocess.TravelApplicant.Phone = model.Phone;
            bookingprocess.TravelApplicant.ZipCode = model.ZipCode;
            bookingprocess.TravelApplicant.Place = model.PlaceName;
            bookingprocess.PaymentsForProvider = model.PaymentsForProvider;
            bookingprocess.Payments = model.Payments;
            bookingprocess.BookingNumber = model.BookingNumber;

            manager.AddMasterData(bookingprocess);
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

            manager.AddMasterData(bookinginquiry);
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

            manager.AddMasterData(bookingconfirmation);
        }

        public static void AddMasterData(BookingProcessViewModel model,string inquirynumber)
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
        // Mapiraj view objekt ,a to je CoreViewModel koji služi za prezentaciju Providera i B2BCustomera u Provider objekt te ga pohrani u bazu
        public static void AddMasterData(CoreViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var provider = new Provider();
            provider.Id = Guid.NewGuid().ToString();
            provider.Address = model.Address;
            provider.Country = model.Country;
            provider.Bank = model.Bank;
            provider.City = model.City;
            provider.Contacts = model.Contacts;
            provider.IBAN = model.IBAN;
            provider.Name = model.Name;
            provider.PersonalIdentificationNumber = model.PersonalIdentificationNumber;
            provider.Notes = model.Notes;
            provider.ProviderId = model.ProviderId;
            provider.Title = model.Title;
            provider.BookingEmail = model.BookingEmail;

            manager.AddMasterData(provider);
        }
        // Mapiraj view objekt ,a to je CoreViewModel koji služi za prezentaciju Providera i B2BCustomera u B2BCustomer objekt te ga pohrani u bazu
        public static void AddMasterDataB2BCustomer(CoreViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var b2bcustomer = new B2BCustomer();
            b2bcustomer.Id = Guid.NewGuid().ToString();
            b2bcustomer.Address = model.Address;
            b2bcustomer.Country = model.Country;
            b2bcustomer.Bank = model.Bank;
            b2bcustomer.City = model.City;
            b2bcustomer.Contacts = model.Contacts;
            b2bcustomer.IBAN = model.IBAN;
            b2bcustomer.Name = model.Name;
            b2bcustomer.PersonalIdentificationNumber = model.PersonalIdentificationNumber;
            b2bcustomer.Notes = model.Notes;
            b2bcustomer.PartnerId = model.ProviderId;

            manager.AddMasterData(b2bcustomer);
        }
        //Mapiraj view objekt u Customer objekt ,te ga pohrani u bazu
        public static void AddMasterData(CustomerViewModel model)
        {
            var customer = new Customer();
            var manager = PlugInManager.GetBookingDataManager();

            customer.id = Guid.NewGuid().ToString();
            customer.Adress = model.Adress;
            customer.Contry = model.Country;
            customer.CustomerNr = model.CustomerNr;
            customer.EMail = model.EMail;
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.MobilePhone = model.MobilePhone;
            customer.Phone = model.Phone;
            customer.Place = model.Place;
            customer.Salutation = model.Salutation;
            customer.ZipCode = model.ZipCode;
            customer.Notes = model.Notes;
            customer.Contacts = model.Contacts;

            manager.AddMasterData(customer);
        }

        public static void AddMasterData(TemplateViewModel model)
        {
            var template = new Template();
            var manager = PlugInManager.GetBookingDataManager();


            template.Id = Guid.NewGuid().ToString();
            template.Name = model.Name;
            template.StatusId = model.StatusId;
            template.Text = model.Text;
            template.Title = model.Title;
           

            manager.AddMasterData(template);
        }
        //Mapiraj view objekt u Email objekt ,te ga pohrani u bazu
        public static void AddMasterData(EmailProcessViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var email = new Email();

            email.Id = Guid.NewGuid().ToString();
            email.Receipent = model.Receipent;
            email.Sender = model.Sender;
            email.Title = model.Title;
            email.docType = model.docType;
            email.BookingId = model.BookingId;
            email.Content = model.Content;
            email.Status = model.Status;

            manager.AddMasterData(email);
        }

        public static void AddMasterData(TextInfoViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var text = new TextInfo();

            text.Id = Guid.NewGuid().ToString();
            text.Date = model.Date;
            text.Title = model.Title;
            text.docType = model.docType;
            text.BookingId = model.BookingId;
            text.Content = model.Content;
            text.Status = model.Status;

            manager.AddMasterData(text);
        }

        public static void AddApplicantPaymentData(PaymentViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var payment = new TravelApplicantPaymentData();

            payment.Id = Guid.NewGuid().ToString();
            payment.Date = model.Date;
            payment.docType = "TravelApplicantPayment";
            payment.BookingId = model.BookingId;
            payment.Value = model.Value;
            payment.Title = model.Title;
            payment.PaymentType = model.PaymentType;

            manager.AddMasterData(payment);
        }

        public static void AddProviderPaymentData(PaymentViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var payment = new ProviderPaymentData();

            payment.Id = Guid.NewGuid().ToString();
            payment.Date = model.Date;
            payment.docType = "ProviderPayment";
            payment.BookingId = model.BookingId;
            payment.Value = model.Value;
            payment.Title = model.Title;
            payment.PaymentType = model.PaymentType;

            manager.AddMasterData(payment);
        }

        public static void AddMasterData(ApplicationKeyViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var applicationkey = new ApplicationKey();

            applicationkey.Id = Guid.NewGuid().ToString();
            applicationkey.Name = model.Name;
            applicationkey.docType = model.docType;
            applicationkey.Value = model.Value;
            applicationkey.Season = model.Season;
           

            manager.AddMasterData(applicationkey);
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


            manager.AddMasterData(announcement);
        }


        //Mapiraj view objekt u BookingProcess objekt ,te napravi update objekta u bazi
        public static void UpdateMasterData(BookingProcessViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var bookingprocess = manager.GetBookingProcess(model.Id);
            bookingprocess.Id = model.Id;
            bookingprocess.Status = model.Status;
            bookingprocess.OfferInfo.Country = model.Country;
            bookingprocess.OfferInfo.PlaceName = model.PlaceName;
            bookingprocess.OfferInfo.SiteName = model.SiteName;
            bookingprocess.OfferInfo.TourOperatorCode = model.TourOperatorCode;
            bookingprocess.OfferInfo.CheckIn = model.CheckIn;
            bookingprocess.OfferInfo.CheckOut = model.CheckOut;
            bookingprocess.TravelApplicant.FirstName = model.FirstName;
            bookingprocess.TravelApplicant.LastName = model.LastName;
            bookingprocess.TravelApplicant.Contry = model.TravelerCountry;
            bookingprocess.TravelApplicant.Adress = model.Address;
            bookingprocess.BookingProcessItemList = model.BookingProcessItemList;
            bookingprocess.TravelApplicantId = model.TravelApplicantId;
            bookingprocess.SellingPartner = model.PartnerId;
            bookingprocess.Season = model.Season;
            bookingprocess.OfferInfo.OfferName = model.OfferName;
            bookingprocess.TravelApplicant.MobilePhone = model.MobilePhone;
            bookingprocess.TravelApplicant.Phone = model.Phone;
            bookingprocess.TravelApplicant.ZipCode = model.ZipCode;
            bookingprocess.TravelApplicant.Place = model.PlaceName;
            bookingprocess.PaymentsForProvider = model.PaymentsForProvider;
            bookingprocess.Payments = model.Payments;
            bookingprocess.BookingNumber = model.BookingNumber;

            manager.UpdateMasterData(bookingprocess);
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

            manager.UpdateMasterData(bookinginquiry);
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

            manager.UpdateMasterData(bookingconfirmation);
        }

        //Mapiraj view objekt CoreViewModel koji se koristi za prezentaciju Provider i B2BCustomer objekta u Provider objekt ,te napravi update objekta u bazi
        public static void UpdateMasterData(CoreViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var provider = new Provider();
            provider.Id = model.Id;
            provider.Address = model.Address;
            provider.Country = model.Country;
            provider.Bank = model.Bank;
            provider.City = model.City;
            provider.Contacts = model.Contacts;

            provider.IBAN = model.IBAN;
            provider.Name = model.Name;
            provider.PersonalIdentificationNumber = model.PersonalIdentificationNumber;
            provider.Notes = model.Notes;
            provider.ProviderId = model.ProviderId;
            provider.Title = model.Title;
            provider.BookingEmail = model.BookingEmail;

            manager.UpdateMasterData(provider);
        }
        //Mapiraj view objekt u Customer objekt ,te napravi update objekta u bazi
        public static void UpdateMasterData(CustomerViewModel model)
        {
            var customer = new Customer();
            var manager = PlugInManager.GetBookingDataManager();

            var customers = manager.GetCustomers();

            customer.id = model.id;
            customer.Adress = model.Adress;
            customer.Contry = model.Country;
            customer.CustomerNr = model.CustomerNr;
            customer.EMail = model.EMail;
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.MobilePhone = model.MobilePhone;
            customer.Phone = model.Phone;
            customer.Place = model.Place;
            customer.Salutation = model.Salutation;
            customer.ZipCode = model.ZipCode;
            customer.Notes = model.Notes;
            customer.Contacts = model.Contacts;

            manager.UpdateMasterData(customer);
        }
        public static void UpdateMasterData(TemplateViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var template = new Template();

            template.Id = model.Id;
            template.Name = model.Name;
            template.StatusId = model.StatusId;
            template.Text = model.Text;
            template.Title = model.Title;


            manager.UpdateMasterData(template);
        }

        public static void UpdateMasterData(ApplicationKeyViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var applicationkey = new ApplicationKey();

            applicationkey.Id = model.Id;
            applicationkey.Name = model.Name;
            applicationkey.docType = model.docType;
            applicationkey.Value = model.Value;
            applicationkey.Season = model.Season;


            manager.UpdateMasterData(applicationkey);
        }
        // Mapiraj view objekt ,a to je CoreViewModel koji služi za prezentaciju Providera i B2BCustomera u B2BCustomer objekt te napravi update objekta u bazi
        public static void UpdateMasterDataB2BCustomer(CoreViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var b2bcustomer = new B2BCustomer();
            b2bcustomer.Id = model.Id;
            b2bcustomer.Address = model.Address;
            b2bcustomer.Country = model.Country;
            b2bcustomer.Bank = model.Bank;
            b2bcustomer.City = model.City;
            b2bcustomer.Contacts = model.Contacts;
            b2bcustomer.IBAN = model.IBAN;
            b2bcustomer.Name = model.Name;
            b2bcustomer.PersonalIdentificationNumber = model.PersonalIdentificationNumber;
            b2bcustomer.Notes = model.Notes;
            b2bcustomer.PartnerId = model.ProviderId;

            manager.UpdateMasterData(b2bcustomer);
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


            manager.UpdateMasterData(announcement);
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
        // Obriši BookingProcess objekt iz baze
        public static void DeleteBookingProcess(string id)
        {
            var manager = PlugInManager.GetBookingDataManager();
            manager.DeleteBookingProcess(id);
        }
        // Obriši Provider iz baze
        public static void DeleteMasterData(CoreViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            manager.DeleteProvider(model.Id);
        }
        // Obriši B2BCustomer iz baze
        public static void DeleteMasterDataB2BCustomer(CoreViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            manager.DeleteB2BCustomer(model.Id);
        }
        // Obriši Customera iz baze
        public static void DeleteMasterData(CustomerViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            manager.DeleteCustomer(model.id);
        }

        public static void DeleteMasterData(TemplateViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            manager.DeleteTemplate(model.Id);
        }
        // Kreiraj view koji se koristi za prikaz podataka na BookingProcessDetailsView formi
        public static BookingProcessDetailsViewModel GetBookingProcessDetailsViewModel(string id)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var bp = manager.GetBookingProcess(id);
            BookingProcessDetailsViewModel model = new BookingProcessDetailsViewModel();
            model.Id = id;
            model.TravelApplicant_Name = bp.TravelApplicant.Salutation + " " + bp.TravelApplicant.FirstName + " " + bp.TravelApplicant.LastName;
            model.TravelApplicant_Phone = bp.TravelApplicant.Phone;
            model.TravelApplicant_MobilePhone = bp.TravelApplicant.MobilePhone;
            model.TravelApplicant_Adress = bp.TravelApplicant.Adress + " " + bp.TravelApplicant.ZipCode + " " + bp.TravelApplicant.Place + " " + bp.TravelApplicant.Contry;
            model.Offer_SiteName = bp.OfferInfo.SiteName;
            model.Offer_OfferName = bp.OfferInfo.OfferName;
            model.Offer_CheckIn = bp.OfferInfo.CheckIn.ToShortDateString();
            model.Offer_CheckOut = bp.OfferInfo.CheckOut.ToShortDateString();
            model.BookingProcessItemList = bp.BookingProcessItemList;
            model.Status = bp.Status;
            model.StatusText = GetStatusText(bp.Status);
            model.ActionList = GetStatuses(bp.Status);

            return model;
        }

        private static string GetStatusText(DocumentProcessStatus status)
        {
            if (status == DocumentProcessStatus.New)
                return "Novi dokument";
            else if (status == DocumentProcessStatus.WaitingProviderConfirmation)
                return "Cakanje na potvrdu provajdera";
            else if (status == DocumentProcessStatus.ProviderConfirmed)
                return "Provider je potrvrdio";
            else if (status == DocumentProcessStatus.CustomerConfirmationSent)
                return "Potvrda za customera je poslana";
            else if (status == DocumentProcessStatus.WaitToCustomerPayment)
                return "Čekanje na plaćanje customera";

            return "nepoznati status";
        }
        // Kreiraj EmailProcessViewModel objekt koji se kreira na osnovu bookingprocess id i comboboxid koji je zapravo statusid,te se taj model koristi
        // EmailProcessView formi
        public static int GetReceiver(string id, string comboId)
        {
            List<object> list = new List<object>();

            var manager = PlugInManager.GetBookingDataManager();
            var bp = manager.GetBookingProcess(id);
           
            var statusmanager = PlugInManager.GetApplicationDataManager();
            var status = statusmanager.GetStatusDocumentsById(comboId);
            int receiver = status.Receiver;

            return receiver;
        }

        public static void CheckCustomerEmail(string id,string email)
        {
            bool valid = IsValidEmail(email);

            if (valid)
            {

                var customer = GetCustomerById(id);
                List<CustomerContact> contacts = customer.Contacts;
                int number = 0;
                foreach (var contact in contacts)
                {
                    if (contact.Email == email)
                    {
                        number++;
                    }
                }
                var customerexisting = GetCustomer(customer.id);
                List<CustomerContact> customercontacts = customerexisting.Contacts;

                if (number == 0)
                {
                    CustomerContact newcontact = new CustomerContact();
                    newcontact.Email = email;
                    customercontacts.Add(newcontact);

                    customerexisting.Contacts = customercontacts;

                    UpdateMasterData(customerexisting);

                }
            }
        }

        public static void CheckProviderEmail(string id, string email)
        {
            bool valid = IsValidEmail(email);

            if (valid)
            {

                var provider = GetProviderById(id);
                List<ProviderContact> contacts = provider.Contacts;
                int number = 0;
                foreach (var contact in contacts)
                {
                    if (contact.Email == email)
                    {
                        number++;
                    }
                }
                var providerexisting = GetProvider(provider.Id);
                List<ProviderContact> providercontacts = providerexisting.Contacts;

                if (number == 0)
                {
                    ProviderContact newcontact = new ProviderContact();
                    newcontact.Email = email;
                    providercontacts.Add(newcontact);

                    providerexisting.Contacts = providercontacts;

                    UpdateMasterData(providerexisting);

                }
            }
        }

        public static bool IsValidEmail(string InputEmail)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(InputEmail);
            if (match.Success)
                return true;
            else
                return false;
        }

        public static CustomerViewModel GetCustomerById(string id)
        {
            

            var manager = PlugInManager.GetBookingDataManager();
            var bp = manager.GetBookingProcess(id);

            int customerNr = bp.TravelApplicantId;

            string travelemail = bp.TravelApplicant.EMail;

            var customer = manager.GetCustomerByCustomerNr(customerNr);

            CustomerViewModel m = new CustomerViewModel();

            m.id = customer.id;
            m.Adress = customer.Adress;
            m.Country = customer.Contry;
            m.CustomerNr = customer.CustomerNr;
            m.EMail = customer.EMail;
            m.FirstName = customer.FirstName;
            m.LastName = customer.LastName;
            m.MobilePhone = customer.MobilePhone;
            m.Phone = customer.Phone;
            m.Place = customer.Place;
            m.Salutation = customer.Salutation;
            m.ZipCode = customer.ZipCode;
            m.Notes = customer.Notes;
            m.Contacts = customer.Contacts;

           
            CustomerContact contact = new CustomerContact();
            contact.Email = customer.EMail;
            CustomerContact contactapplicant = new CustomerContact();
            contactapplicant.Email = travelemail;

            List<CustomerContact> contacts = m.Contacts;

            contacts.Add(contact);
            contacts.Add(contactapplicant);

            m.Contacts = contacts;

            int counter = 0;
            foreach (var item in m.Notes)
                item.Id = (++counter).ToString();


            counter = 0;
            foreach (var item in m.Contacts)
                item.Id = (++counter).ToString();

            return m;
        }

        public static CoreViewModel GetProviderById(string id)
        {
            List<ProviderContact> list = new List<ProviderContact>();

            var manager = PlugInManager.GetBookingDataManager();
            var bp = manager.GetBookingProcess(id);
            int providerid = bp.AccProvider;
            var provider = manager.GetProviderForProviderId(providerid);

            CoreViewModel m = new CoreViewModel();

           
            m.Id = provider.Id;
            m.Address = provider.Address;
            m.Country = provider.Country;
            m.Bank = provider.Bank;
            m.City = provider.City;
            m.Contacts = provider.Contacts;
            m.IBAN = provider.IBAN;
            m.Name = provider.Name;
            m.PersonalIdentificationNumber = provider.PersonalIdentificationNumber;
            m.Notes = provider.Notes;
            m.ProviderId = provider.ProviderId;
            m.Title = provider.Title;
            m.BookingEmail = provider.BookingEmail;

            list = m.Contacts;

            ProviderContact contact = new ProviderContact();
            contact.Email = provider.BookingEmail;

            list.Add(contact);

            m.Contacts = list;

            int counter = 0;
            foreach (var item in m.Contacts)
                item.Id = (++counter).ToString();
            counter = 0;
            foreach (var item in m.Notes)
                item.Id = (++counter).ToString();

            return m;

        }

        // Na osnovi formcode propertya iz StatusDataDocumenta se određeuje ime forme na koju će se napraviti redirect
        public static string GetFormName(string formcode)
        {
            string formname = String.Empty;

            if(formcode=="EMAIL")
            {
                formname = "EmailProcessView.aspx";
            }
            else if (formcode=="TEXT")
            {
                formname = "TextProcessView.aspx";
            }
            else if (formcode=="PAYMENT")
            {
                formname = "PaymentProcessView.aspx";
            }

            return formname;
        }
        // Na osnovu booking process id parametra se dohvaća booking process,te se dobiva njegov status
        // Na osnovu dobivenog statusa se vraća Lista svih StatusDataDocument objekata koji sadrže taj status
        public static List<StatusDataDocument> GetStatuses(DocumentProcessStatus status)
        {
            List<StatusDataDocument> basestatuses = new List<StatusDataDocument>();
            var managerstatus = PlugInManager.GetApplicationDataManager();
            List<StatusDataDocument> list = new List<StatusDataDocument>();
            list = managerstatus.GetStatusDocumentsByStatus(status);
            basestatuses = managerstatus.GetStatusDocumentsByStatus(DocumentProcessStatus.First);
            basestatuses.AddRange(list);
            return basestatuses;

        }

        public static List<StatusDataDocument> GetStatusesProviderConfirmedBefore()
        {
            var managerstatus = PlugInManager.GetApplicationDataManager();

            List<StatusDataDocument> list = new List<StatusDataDocument>();
            DocumentProcessStatus status = DocumentProcessStatus.ProviderConfirmed;
            list = managerstatus.GetStatusDocumentsByStatus(status);

            var item = list.Find(m => m.ValueId == 1);

            list.Remove(item);
            return list;
        }

        public static List<StatusDataDocument> GetStatusesProviderConfirmedAfter()
        {
            var managerstatus = PlugInManager.GetApplicationDataManager();

            List<StatusDataDocument> list = new List<StatusDataDocument>();
            DocumentProcessStatus status = DocumentProcessStatus.ProviderConfirmed;
            list = managerstatus.GetStatusDocumentsByStatus(status);

            var item = list.Find(m => m.ValueId == 2);

            list.Remove(item);
            return list;
        }

        // Dohvati View od Providera na osnovi id parametra
        public static CoreViewModel GetProvider(string id)
        {
            var m = GetProviderViewModel().Find(f => f.Id == id);
            return m;
        }
        // Dohvati listu BookingProcessViewModel objekata na osnovi providerid parametra
        public static List<BookingProcessViewModel> GetBookingProcessesByProviderId(int providerid)
        {
            var m = GetBookingProcessViewModel().FindAll(f =>f.ProviderId == providerid);
            return m;
        }
        // Dohvati listu BookingProcessViewModel objekata na osnovi partnerid parametra
        public static List<BookingProcessViewModel> GetBookingProcessesByPartnerId(int partnerid)
        {
            var m = GetBookingProcessViewModel().FindAll(f => f.PartnerId == partnerid);
            return m;
        }
        // Dohvati View od Customera na osnovi id parametra
        public static CustomerViewModel GetCustomer(string id)
        {
            var m = GetCustomerViewModel().Find(f => f.id == id);
            return m;
        }

        public static TemplateViewModel GetTemplate(string id)
        {
            var m = GetTemplateViewModel().Find(f => f.Id == id);
            return m;
        }

        public static List<TemplateViewModel> GetTemplatesByStatusId(string statusid)
        {
            var m = GetTemplateViewModel().FindAll(f => f.StatusId == statusid);
            return m;
        }

        // Dohvati View od B2BCustomera na osnovi id parametra
        public static CoreViewModel GetB2BCustomer(string id)
        {
            var m = GetB2BCustomerViewModel().Find(f => f.Id == id);
            return m;
        }
        // Dohvati View od BookingProcessa na osnovi id parametra
        public static BookingProcessViewModel GetBookingProcess(string id)
        {
            var m = GetBookingProcessViewModel().Find(f => f.Id == id);
            return m;
        }
        // Dohvati listu BookingProcessViewModel objekata na osnovi customerid parametra
        public static List<BookingProcessViewModel> GetBookingProcessessByCustomerId(int customerid)
        {
            List<BookingProcessViewModel> list = GetBookingProcessViewModel().FindAll(f => f.TravelApplicantId == customerid);
            return list;
        }

       
        // Dohvati Email View na osnovu id parametra
        public static EmailProcessViewModel GetEmailProcessViewModelById(string id)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var email = manager.GetEmail(id);
         
                var m = new EmailProcessViewModel();
                m.Id = email.Id;
                m.Receipent = email.Receipent;
                m.Sender = email.Sender;
                m.Title = email.Title;
                m.docType = email.docType;
                m.BookingId = email.BookingId;
                m.Content = email.Content;

            return m;
            

        }

        public static TextInfoViewModel GetTextInfoViewModelById(string id)
        {
            var model = GetTextInfoViewModel().Find(m => m.Id == id);
            return model;
        }

        public static PaymentViewModel GetApplicationPaymentViewModelById(string id)
        {
            var model = GetApplicantPaymentViewModel().Find(m => m.Id == id);
            return model;
        }

        public static List<PaymentViewModel> GetApplicationPaymentViewModelByBookingId(string id)
        {
            var model = GetApplicantPaymentViewModel().FindAll(m => m.BookingId == id);
            return model;
        }

        public static PaymentViewModel GetProviderPaymentViewModelById(string id)
        {
            var model = GetProviderPaymentViewModel().Find(m => m.Id == id);
            return model;
        }

        public static List<PaymentViewModel> GetProviderPaymentViewModelByBookingId(string id)
        {
            var model = GetProviderPaymentViewModel().FindAll(m => m.BookingId == id);
            return model;
        }

        public static ApplicationKeyViewModel GetApplicantKeyViewModelById(string id)
        {
            var model = GetApplicationKeyViewModel().Find(m => m.Id == id);
            return model;
        }

        public static ApplicationKeyViewModel GetApplicantKeyViewModelByName(string name)
        {
            var model = GetApplicationKeyViewModel().Find(m => m.Name == name);
            return model;
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

        public static ProviderAnnouncementViewModel GetProviderAnnouncementViewModelById(string id)
        {
            var model = GetProviderAnnouncementViewModel().Find(m => m.Id == id);
            return model;
        }

        public static ProviderAnnouncementViewModel GetProviderAnnouncementViewModelByBookingId(string id)
        {
            var model =GetProviderAnnouncementViewModel().Find(m => m.BookingId == id);
            return model;
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

      

        public static bool CheckApplicantPaymentStatus(string bookingid)
        {
            bool ispaid = false;
            var bookingmodel = GetBookingProcess(bookingid);
            var applicantpayments = GetApplicationPaymentViewModelByBookingId(bookingid);
            var payments = bookingmodel.Payments;
            if(applicantpayments.Count==payments.Count)
            {
                for(int i=0;i<payments.Count; i++)
                {
                    for(int j=0;j<applicantpayments.Count;j++)
                    {
                        if(i==j)
                        {
                            if((payments[i].Value==applicantpayments[j].Value)&& (applicantpayments[j].Date <= payments[i].Date))
                            {
                                ispaid = true;
                            }
                            else
                            {
                                ispaid = false;
                            }
                        }
                    }
                }
            }

            return ispaid;
        }

        // Dohvati view za zadnji email kreiran za određeni booking proces
        public static EmailProcessViewModel GetEmailProcessViewModelByBookingIdLast(string bookingid)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var email = manager.GetEmailByBookingIdLast(bookingid);

            var m = new EmailProcessViewModel();
            m.Id = email.Id;
            m.Receipent = email.Receipent;
            m.Sender = email.Sender;
            m.Title = email.Title;
            m.docType = email.docType;
            m.BookingId = email.BookingId;
            m.Content = email.Content;

            return m;


        }

        public static TemplateViewModel GetTemplateByStatusIdLast(string statusid)
        {
            var data = GetTemplatesByStatusId(statusid).FindLast(m => m.StatusId == statusid);
            return data;
        }

        // Kreiraj view za FormLayout na osnovu CoreViewModel objekta koji se koristi za prezentaciju Provider i B2BCustomer objekta
        public static LayoutFormViewModel GetLayoutFormViewModel(CoreViewModel model)
        {
            var layoutdata = new LayoutFormViewModel();
            layoutdata.Bank = model.Bank;
            layoutdata.IBAN = model.IBAN;
            layoutdata.Name = model.Name;
            layoutdata.PersonalIdentificationNumber = model.PersonalIdentificationNumber;
            layoutdata.Country = model.Country;
            layoutdata.City = model.City;
            layoutdata.Address = model.Address;

            return layoutdata;
        }
        // Kreiraj view za FormLayout na osnovu CoreViewModel objekta koji se koristi za prezentaciju Provider i B2BCustomer objekta
        public static LayoutCoreViewModel GetLayoutViewModel(CoreViewModel model)
        {
            var layoutdata = new LayoutCoreViewModel();
            layoutdata.Bank = model.Bank;
            layoutdata.IBAN = model.IBAN;
            layoutdata.Name = model.Name;
            layoutdata.PersonalIdentificationNumber = model.PersonalIdentificationNumber;
            layoutdata.Country = model.Country;
            layoutdata.City = model.City;
            layoutdata.Address = model.Address;
            layoutdata.BookingEmail = model.BookingEmail;
            layoutdata.ProviderId = model.ProviderId;
            layoutdata.Title = model.Title;
            return layoutdata;
        }
        // Kreiraj view za FormLayout na osnovu id parametra za prikaz podataka za Customera
        public static LayoutCustomerViewModel GetLayoutCustomerViewModel(string  id)
        {
            var model = GetCustomer(id);
            var customerlayout = new LayoutCustomerViewModel();
            customerlayout.Adress = model.Adress;
            customerlayout.Country = model.Country;
            customerlayout.CustomerNr = model.CustomerNr;
            customerlayout.EMail = model.EMail;
            customerlayout.FirstName = model.FirstName;
            customerlayout.LastName = model.LastName;
            customerlayout.MobilePhone = model.MobilePhone;
            customerlayout.Phone = model.Phone;
            customerlayout.Place = model.Place;
            customerlayout.ZipCode = model.ZipCode;

            return customerlayout;
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

        public static string GetText(string text,Dictionary<string,object> data)
        {
            string s = text;
            
            foreach(var item in data)
            {
                if(item.Key.ToString()=="[SITE_NAME]")
                {
                    s = s.Replace(item.Key.ToString(), CheckValue(item.Value));
                }
                else if (item.Key.ToString() == "[OFFER_NAME]")
                {
                    s = s.Replace(item.Key.ToString(), CheckValue(item.Value));
                }
                else if (item.Key.ToString() == "[CHECK_IN]")
                {
                    s = s.Replace(item.Key.ToString(), CheckValue(item.Value));
                }
                else if (item.Key.ToString() == "[CHECK_OUT]")
                {
                    s = s.Replace(item.Key.ToString(), CheckValue(item.Value));
                }
                else if (item.Key.ToString() == "[FIRST_NAME]")
                {
                    s = s.Replace(item.Key.ToString(), CheckValue(item.Value));
                }
                else if (item.Key.ToString() == "[LAST_NAME]")
                {
                    s = s.Replace(item.Key.ToString(), CheckValue(item.Value));
                }
                else if (item.Key.ToString() == "[COUNTRY]")
                {
                    s = s.Replace(item.Key.ToString(), CheckValue(item.Value));
                }
                else if (item.Key.ToString() == "[PLACE]")
                {
                    s = s.Replace(item.Key.ToString(), CheckValue(item.Value));
                }
                else if (item.Key.ToString() == "[ADDRESS]")
                {
                    s = s.Replace(item.Key.ToString(), CheckValue(item.Value));
                }
                else if (item.Key.ToString() == "[EMAIL]")
                {
                    s = s.Replace(item.Key.ToString(), CheckValue(item.Value));
                }
                else if (item.Key.ToString() == "[PHONE]")
                {
                    s = s.Replace(item.Key.ToString(), CheckValue(item.Value));
                }
                else if (item.Key.ToString() == "[TRAVELER_COUNTRY]")
                {
                    s = s.Replace(item.Key.ToString(), CheckValue(item.Value));
                }
                else if (item.Key.ToString() == "[TRAVELER_PLACE]")
                {
                    s = s.Replace(item.Key.ToString(), CheckValue(item.Value));

                }
                else if (item.Key.ToString() == "[ZIPCODE]")
                {
                    s = s.Replace(item.Key.ToString(), CheckValue(item.Value));

                }
                else if (item.Key.ToString() == "[DAYS]")
                {
                    s = s.Replace(item.Key.ToString(), item.Value.ToString());
                }
                else if (item.Key.ToString() == "[APPLICANT_PAYMENT]")
                {
                    s = s.Replace(item.Key.ToString(), CheckValue(item.Value));

                }
                else if (item.Key.ToString() == "[APPLICANT_PAYMENTDATE]")
                {
                    s = s.Replace(item.Key.ToString(), CheckValue(item.Value));

                }
                else if (item.Key.ToString() == "[PROVIDER_PAYMENT]")
                {
                    s = s.Replace(item.Key.ToString(), CheckValue(item.Value));

                }
                else if (item.Key.ToString() == "[PROVIDER_PAYMENTDATE]")
                {
                    s = s.Replace(item.Key.ToString(), CheckValue(item.Value));

                }
            }
            return s;
        }
        public static Dictionary<string,object> GenerateData(BookingProcessViewModel bookingmodel)
        {
            Dictionary<string, object> bookingdata = new Dictionary<string, object>();
            string sitename = string.Empty; ;
            string offername=string.Empty;
            DateTime checkin;
            DateTime checkout;
            string firstname = string.Empty;
            string lastname = string.Empty;
            string address = string.Empty;
            string country = string.Empty;
            string place = string.Empty;
            string season = string.Empty;
            string email = string.Empty;
            string phone = string.Empty;
            string travelercountry = string.Empty;
            string travelerplace = string.Empty;
            string zipcode = string.Empty;
            decimal applicantpayment;
            decimal providerpayment;
            DateTime providerpaymentdate;
            DateTime applicantpaymentdate;
            

            sitename = bookingmodel.SiteName;
            offername = bookingmodel.OfferName;
            checkin = bookingmodel.CheckIn;
            checkout = bookingmodel.CheckOut;
            firstname = bookingmodel.FirstName;
            lastname = bookingmodel.LastName;
            country = bookingmodel.Country;
            place = bookingmodel.PlaceName;
            address = bookingmodel.Address;
            email = bookingmodel.EMail;
            phone = bookingmodel.Phone;
            travelercountry = bookingmodel.TravelerCountry;
            travelerplace = bookingmodel.TravelerPlace;
            zipcode = bookingmodel.ZipCode;
            if (bookingmodel.Payments.Count > 0)
            {
                applicantpayment = bookingmodel.Payments[0].Value;
                applicantpaymentdate = bookingmodel.Payments[0].Date;
            }
            else
            {
                applicantpayment = 0;
                applicantpaymentdate = DateTime.Now;
            }
            if (bookingmodel.PaymentsForProvider.Count > 0)
            {
                providerpayment = bookingmodel.PaymentsForProvider[0].Value;
                providerpaymentdate = bookingmodel.PaymentsForProvider[0].Date;
            }
            else
            {
                providerpayment = 0;
                providerpaymentdate = DateTime.Now;
            }

            bookingdata["[SITE_NAME]"] = sitename;
            bookingdata["[OFFER_NAME]"] = offername;
            bookingdata["[CHECK_IN]"] = checkin;
            bookingdata["[CHECK_OUT]"] = checkout;
            bookingdata["[FIRST_NAME]"] = firstname;
            bookingdata["[LAST_NAME]"] = lastname;
            bookingdata["[COUNTRY]"] = country;
            bookingdata["[PLACE]"] = place;
            bookingdata["[ADDRESS]"] = address;
            bookingdata["[EMAIL]"] = email;
            bookingdata["[PHONE]"] = phone;
            bookingdata["[TRAVELER_COUNTRY]"] = travelercountry;
            bookingdata["[TRAVELER_PLACE]"] = travelerplace;
            bookingdata["[ZIPCODE]"] = zipcode;
            bookingdata["[DAYS]"] = bookingmodel.Days;
            bookingdata["[APPLICANT_PAYMENT]"] = applicantpayment;
            bookingdata["[APPLICANT_PAYMENTDATE]"] = applicantpaymentdate;
            bookingdata["[PROVIDER_PAYMENT]"] = providerpayment;
            bookingdata["[PROVIDER_PAYMENTDATE]"] = providerpaymentdate;

            return bookingdata;

        }

        public static string CheckValue(object data)
        {
            string s = string.Empty;
            if(data!=null)
            {
                s = data.ToString();
            }

            return s;
        }

        public static string CreateTable()
        {
            string tb = string.Empty;
            tb += "<table style = \"font-size: 12px; font-family: Arial; border: thin dashed #C0C0C0\" width = \"100%\" >";
            tb += "<tbody>";
            tb += "<tr>";
            tb += " <td> FirstName.</td>";
            tb += " <td> LastName </td>";
            tb += " <td> SiteName </td>";
            tb += "<td> OfferName </td>";
            tb += "<td> CheckIn </td>";
            tb += "<td> CheckOut </td>";
            tb += " </tr>";
           
            tb += " <tr>";
            tb += "<td> [FIRST_NAME] </td>";
            tb += "<td> [LAST_NAME] </td>";
            tb += "<td> [SITE_NAME] </td>";
            tb += "<td> [OFFER_NAME] </td>";
            tb += "<td> [CHECK_IN] </td>";
            tb += "<td> [CHECK_OUT] </td>";
            tb += "</tr>";
            
            tb += " </tbody>";
            tb += "</table>";

            return tb;
        }
        public static string CreateTableCustomer()
        {
            string tb = string.Empty;
            tb += "<table style = \"font-size: 12px; font-family: Arial; border: thin dashed #C0C0C0\" width = \"100%\" >";
            tb += "<tbody>";
            tb += "<tr>";
            tb += " <td> Name:</td>";
            tb += " <td> [FIRST_NAME],[LAST_NAME] </td>";
            tb += " <td>  </td>";
            tb += "<td> </td>";
            tb += " </tr>";

            tb += " <tr>";
            tb += "<td> Ort: </td>";
            tb += "<td> [PLACE] </td>";
            tb += "<td> </td>";
            tb += "<td>  </td>";
            tb += " </tr>";

            tb += " <tr>";
            tb += "<td> Addresse: </td>";
            tb += "<td> [ADDRESS] </td>";
            tb += "<td>Telefon: </td>";
            tb += "<td>  </td>";
            tb += " </tr>";

            tb += " <tr>";
            tb += "<td> Land: </td>";
            tb += "<td> [COUNTRY] </td>";
            tb += "<td>E-mail: </td>";
            tb += "<td>  </td>";
            tb += " </tr>";

            tb += " </tbody>";
            tb += "</table>";

            return tb;
        }

        public static string GetActionUrl(int actionValue, BookingProcessDetailsViewModel model, List<StatusDataDocument> data)
        {
            string url = string.Empty;
            StatusDataDocument document = data.Find(m => m.ValueId == actionValue);
            string statusid = document.Id;
            string formcode = document.FormCode;
            string formname = BookingDataRepository.GetFormName(formcode);
            string name = document.Text;
            string id = model.Id;

            if (formcode != "NONE")
            {
                url = "~/AspxArea/Booking/Forms/" + formname + "?id=" + id + "&statusid" +
                      "=" + statusid + "&name=" + name + "&valueid=" + actionValue.ToString();
            }
            return url;
        }

        public static BookingProcessItem GetItemById(string id)
        {
            var bookinglist = GetBookingProcessViewModel();
            BookingProcessItem value = new BookingProcessItem();

            foreach(var bookingprocess in bookinglist)
            {
                foreach(var item in bookingprocess.BookingProcessItemList)
                {
                    if (item.DocumentId == id)
                        value = item;
                }
            }

            return value;
        }
    }
}