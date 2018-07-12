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
    public class BookingDataCoreRepository
    {
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

        // Obriši B2BCustomer iz baze
        public static void DeleteMasterDataB2BCustomer(string id)
        {
            var manager = PlugInManager.GetBookingDataManager();
            manager.DeleteB2BCustomer(id);
        }

        // Dohvati View od B2BCustomera na osnovi id parametra
        public static CoreViewModel GetB2BCustomer(string id)
        {
            var m = GetB2BCustomerViewModel().Find(f => f.Id == id);
            return m;
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
                m.Title = provider.Title;
                m.BookingEmail = provider.BookingEmail;
                m.Cancellations = provider.Cancellations;

                int counter = 0;
                foreach (var item in m.Contacts)
                    item.Id = (++counter).ToString();
                counter = 0;
                foreach (var item in m.Notes)
                    item.Id = (++counter).ToString();

                foreach (var item in m.Cancellations)
                    item.Id = (++counter).ToString();

                model.Add(m);
            }

            return model;
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
            provider.Cancellations = model.Cancellations;

            manager.AddMasterData(provider);
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
            provider.Cancellations = model.Cancellations;

            manager.UpdateMasterData(provider);
        }

        // Obriši Provider iz baze
        public static void DeleteProvider(string id)
        {
            var manager = PlugInManager.GetBookingDataManager();
            manager.DeleteProvider(id);
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
            m.Cancellations = provider.Cancellations;

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
            foreach (var item in m.Cancellations)
                item.Id = (++counter).ToString();

            return m;

        }

        // Dohvati View od Providera na osnovi id parametra
        public static CoreViewModel GetProvider(string id)
        {
            var m = GetProviderViewModel().Find(f => f.Id == id);
            return m;
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

        // Obriši Customera iz baze
        public static void DeleteCustomer(string id)
        {
            var manager = PlugInManager.GetBookingDataManager();
            manager.DeleteCustomer(id);
        }

        // Kreiraj view za FormLayout na osnovu id parametra za prikaz podataka za Customera
        public static LayoutCustomerViewModel GetLayoutCustomerViewModel(string id)
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



        public static void DeleteMasterData(TemplateViewModel model)
        {
            var manager = PlugInManager.GetBookingDataManager();
            manager.DeleteTemplate(model.Id);
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


        // Dohvati listu BookingProcessViewModel objekata na osnovi providerid parametra
        public static List<BookingProcessViewModel> GetBookingProcessesByProviderId(int providerid)
        {
            var m = GetBookingProcessViewModel().FindAll(f => f.ProviderId == providerid);
            return m;
        }
        // Dohvati listu BookingProcessViewModel objekata na osnovi partnerid parametra
        public static List<BookingProcessViewModel> GetBookingProcessesByPartnerId(int partnerid)
        {
            var m = GetBookingProcessViewModel().FindAll(f => f.PartnerId == partnerid);
            return m;
        }

        //Dohvati sve booking procese iz baze i mapiraj u view objekte i vrati listu
        public static List<BookingProcessViewModel> GetBookingProcessViewModel()
        {
            var model = new List<BookingProcessViewModel>();
            var manager = PlugInManager.GetBookingDataManager();
            int i = 0;
            var bookingprocesses = manager.GetBookingProcesses();

            int c = bookingprocesses.Count;

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
                m.TravelApplicantId = bookingprocess.TravelApplicantId;
                model.Add(m);
            }

            return model;
        }

        // Dohvati View od Customera na osnovi id parametra
        public static CustomerViewModel GetCustomer(string id)
        {
            var m = GetCustomerViewModel().Find(f => f.id == id);
            return m;
        }

        // Dohvati listu BookingProcessViewModel objekata na osnovi customerid parametra
        public static List<BookingProcessViewModel> GetBookingProcessessByCustomerId(int customerid)
        {
            List<BookingProcessViewModel> list = GetBookingProcessViewModel().FindAll(f => f.TravelApplicantId == customerid);
            return list;
        }

        public static void CheckCustomerEmail(string id, string email)
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
    }
}