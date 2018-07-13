using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using QTouristik.Data;

namespace BLL
{
    public class DBData
    {
        private static DataManager manager = new DataManager();
        private static Repository datarepository = new Repository();
        public static int counter = 0;

        public static void SaveTouristUnits()
        {
            var units = datarepository.GetAllUnits();

            foreach(var unit in units)
            {
              TouristUnit t =  MapUnit(unit);
              UnitOffer unitOffer = CreateOffer(t);
              manager.AddMasterData(t);
              manager.AddMasterData(unitOffer);
            }
        }

        private static TouristUnit MapUnit(SEH_UnitInfo unitinfo)
        {
            string region;
            string place;

            TouristUnit unit = new TouristUnit();
            unit.ShortDescription = unitinfo.suKurzBeschreibung != null ? unitinfo.suKurzBeschreibung.Trim() : "";
            unit.Description = unitinfo.suLangBeschreibung != null ? unitinfo.suLangBeschreibung.Trim() : "";
            unit.SiteCode = unitinfo.SiteCode != null ? unitinfo.SiteCode.Trim() : "";
            unit.UnitCode = unitinfo.UnitOfferCode != null ? unitinfo.UnitOfferCode.Trim() : "";
            unit.ImageGalleryPath = unitinfo.suImageLocation != null ? unitinfo.suImageLocation.Trim() : "";
            unit.Bedrooms = unitinfo.suSchlafzimmer;
            unit.MobilehomeSize = unitinfo.suMHGroße;
            unit.MaxPersons = unitinfo.suMaxBelegung;
            unit.MaxAdults = unitinfo.suMaxErwachsener;
            unit.Pets = unitinfo.suHund;
            unit.TourOperatorCode = unitinfo.suTourOperator.ToString();
            unit.OpenDate = unitinfo.suAngebotVon;
            unit.CloseDate = unitinfo.suAngebotBis;
            unit.BedWashing = unitinfo.suBettwaesche == "y" ? true : false;
            unit.UnitType = unitinfo.suRouteObjektTyp != null ? unitinfo.suRouteObjektTyp.Trim() : "";
            unit.UnitTitel = unitinfo.suKurzBeschreibung != null ? unitinfo.suKurzBeschreibung.Trim() : "";
            unit.MobilhomeArea = unitinfo.suMHGroße;
            unit.SiteName = unitinfo.suKurzBeschreibung != null ? unitinfo.suKurzBeschreibung.Trim() : "";
            unit.TourOperatorCode = "IDOM";
            unit.CountryName = "Kroatien";

            SEH_SiteInfo site = unitinfo.SEH_SiteInfo;
            region = GetRegion(site);
            place = GetPlace(site);

            unit.PlaceName = place;
            unit.RegionName = region;

            return unit;
        }

        private static UnitOffer CreateOffer(TouristUnit unit)
        {
            UnitOffer unitOffer = new UnitOffer();
            unitOffer.OfferCode = unit.UnitCode;
            unitOffer.UnitCode = unit.UnitCode;
            unitOffer.TourOperatorCode = unit.TourOperatorCode;
            unitOffer.SiteCode = unit.SiteCode;
            unitOffer.OfferTitel = unit.UnitTitel;
            unitOffer.OfferDescription = unit.Description;
            unitOffer.OfferCount = 1;

            return unitOffer;
        }

        public static void SaveTouristSites()
        {
            var sites = datarepository.GetAllSites();

            foreach(var item in sites)
            {
                TouristSite st = MapSite(item);
                manager.AddMasterData(st);
            }
        }

        private static TouristSite MapSite(SEH_SiteInfo siteinfo)
        {
            TouristSite site = new TouristSite();
            site.CountryId = 1;
            site.PlaceId = siteinfo.soOrtId;
            site.RegionId = siteinfo.soRegion;
            site.SiteCode = siteinfo.SiteCode != null ? siteinfo.SiteCode.Trim() : "";
            site.SiteName = siteinfo.soKurzBeschreibung != null ? siteinfo.soKurzBeschreibung.Trim() : "";
            site.Description = siteinfo.soLangBeschreibung != null ? siteinfo.soLangBeschreibung.Trim() : "";
            site.ImageGalleryPath = siteinfo.soImageLocation != null ? siteinfo.soImageLocation.Trim() : "";
            site.Pool = siteinfo.Pool == "y" ? true : false;

            return site;
        }

        private static string GetRegion(SEH_SiteInfo siteinfo)
        {
            var locations = datarepository.GetAllLocations();
            int regionid = siteinfo.soRegion;
            string regionname = locations.Where(n => n.geoParent == 0 && n.geoID == regionid).SingleOrDefault().geoName;

            return regionname;
        }

        private static string GetPlace(SEH_SiteInfo siteInfo)
        {
            var locations = datarepository.GetAllLocations();
            int regionid = siteInfo.soRegion;
            int placeid = siteInfo.soOrtId;

            List<dbGeoLocation> data = locations.FindAll(f => f.geoParent == regionid);

            dbGeoLocation geoLocation = data.Where(r => r.geoID == placeid).SingleOrDefault();

            string placename = geoLocation.geoName;

            return placename;



        }

        public static void SaveCustomers()
        {
            int aaa;
            var bookingdata = datarepository.GetAllBookings();

            List<Customer> list = new List<Customer>();

            foreach (var item in bookingdata)
            {
              Customer c=  CreateCustomer(item);
                list.Add(c);
            }

            foreach(var item in list)
            {
                if (item.EMail == "elrama03@tele2.de")
                     aaa = 1;

                var email = item.EMail.ToLower();
                    if (!CheckCustomer(email))
                {
                    
                    //List<int> values = new List<int>();
                    int number = GetMaxCustomerNr();
                    number++;
                    //values.Add(number);
                    item.CustomerNr = number;
                    //item.BookKeepingNumber = values;

                    manager.AddMasterData(item);
                }
            }
        }

        private static Customer CreateCustomer(dbBuchungen bookinginfo)
        {
            Customer customer = new Customer();
            customer.Adress = bookinginfo.buchStrasse != null ? bookinginfo.buchStrasse.Trim() : "";
            customer.Contry = bookinginfo.buchLand != null ? bookinginfo.buchLand.Trim() : "";
            customer.EMail = bookinginfo.buchEmail != null ? bookinginfo.buchEmail.Trim() : "";
            customer.FirstName = bookinginfo.buchVornahme != null ? bookinginfo.buchVornahme.Trim() : "";
            customer.LastName = bookinginfo.buchNachname != null ? bookinginfo.buchNachname.Trim() : "";
            customer.Salutation = bookinginfo.buchAnrede != null ? bookinginfo.buchAnrede.Trim() : "";
            customer.Phone = bookinginfo.buchTelefonNr != null ? bookinginfo.buchTelefonNr.Trim() : "";
            customer.MobilePhone = bookinginfo.buchHandyNr != null ? bookinginfo.buchHandyNr.Trim() : "";
            customer.Place = bookinginfo.buchPlzOrt != null ? bookinginfo.buchPlzOrt.Trim() : "";

            return customer;
        }


        private static bool CheckCustomer(string email)
        {
            bool b = false;
            DataManager manager = new DataManager();
            Customer cust = manager.GetCustomerByEmail(email);
            if (cust != null)
            {
                b = true;
            }

            return b;

        }

        private static int GetMaxCustomerNr()
        {
            var customers = manager.GetCustomers();
            int maxId = customers.Max(u => u.CustomerNr);

            return maxId;
        }

        public static void SaveBookingData(string id,DateTime CheckIn,DateTime CheckOut,bool change)
        {
            var bookingdata = datarepository.GetAllBookings();

            foreach(var item in bookingdata)
            {
                var email = item.buchEmail != null ? item.buchEmail.Trim() : "";
                email = email.ToLower();
                BookingProcess value = GetBooking(item);

                if (!change)
                {
                    if (!CheckBookingProcess(value.Id))
                    {
                        Customer c = manager.GetCustomerByEmail(email);
                        //if(c.CustomerNr< 10393)
                        //{
                        //    int a = 0;
                        //}
                        BookingProcess bp;

                        BookingProcess bookingvalue;
                        if (c != null)
                        {
                            bp = UpdateBookingWithCustomer(c, value);
                        }
                        else
                        {
                            bp = value;
                        }
                        bookingvalue = UpdateBookingWithUnit(bp);
                        manager.AddMasterData(bookingvalue);
                    }
                }
                else
                {
                    if (value.Id == id)
                    {
                        Customer c = manager.GetCustomerByEmail(email);
                        //if(c.CustomerNr< 10393)
                        //{
                        //    int a = 0;
                        //}
                        BookingProcess bp;

                        BookingProcess bookingvalue;
                        if (c != null)
                        {
                            bp = UpdateBookingWithCustomer(c, value);
                        }
                        else
                        {
                            bp = value;
                        }
                        bookingvalue = UpdateBookingWithUnit(bp);
                        bookingvalue.OfferInfo.CheckIn = CheckIn;
                        bookingvalue.OfferInfo.CheckOut = CheckOut;
                        manager.UpdateMasterData(bookingvalue);
                    }
                }
            }
        }
        private static bool CheckBookingProcess(string id)
        {
            bool exists = false;
            var bookingprocess = manager.GetBookingProcess(id);
            if(bookingprocess!=null)
            {
                exists = true;
            }
            return exists;
        }
        private static BookingProcess GetBooking(dbBuchungen booking)
        {
            BookingProcess bookingprocess = new BookingProcess();

            bookingprocess.Id = booking.buchGuid != null ? booking.buchGuid.Trim() : "";
            //bookingprocess.Status = model.Status;
            bookingprocess.OfferInfo.Country = "Kroatien";
            bookingprocess.OfferInfo.PlaceName = booking.buchCampOrt != null ? booking.buchCampOrt.Trim() : "";
            bookingprocess.OfferInfo.SiteName = booking.buchCampName != null ? booking.buchCampName.Trim() : "";
            bookingprocess.OfferInfo.CheckIn = booking.buchAnreise;
            bookingprocess.OfferInfo.CheckOut = booking.buchAbreise;
            bookingprocess.TravelApplicant.FirstName = booking.buchVornahme != null ? booking.buchVornahme.Trim() : "";
            bookingprocess.TravelApplicant.LastName = booking.buchNachname != null ? booking.buchNachname.Trim() : "";
            bookingprocess.TravelApplicant.Contry = booking.buchLand != null ? booking.buchLand.Trim() : "";
            bookingprocess.TravelApplicant.Adress = booking.buchStrasse != null ? booking.buchStrasse.Trim() : "";
            //bookingprocess.TravelApplicantId = model.TravelApplicantId;
            bookingprocess.AccProvider = booking.buchPartnerID;
            bookingprocess.Season = booking.buchAnreise.Year.ToString();
            //bookingprocess.OfferInfo.OfferName = model.OfferName;
            bookingprocess.TravelApplicant.MobilePhone = booking.buchHandyNr != null ? booking.buchHandyNr.Trim() : "";
            bookingprocess.TravelApplicant.Phone = booking.buchTelefonNr != null ? booking.buchTelefonNr.Trim() : "";
            //bookingprocess.TravelApplicant.ZipCode = model.ZipCode;
            bookingprocess.TravelApplicant.Place = booking.buchPlzOrt != null ? booking.buchPlzOrt.Trim() : "";
            //bookingprocess.PaymentsForProvider = model.PaymentsForProvider;
            //bookingprocess.Payments = model.Payments;
            bookingprocess.BookingNumber = booking.BookingNumber;
            bookingprocess.Status = DocumentProcessStatus.Close;
            bookingprocess.TravelApplicant.EMail = booking.buchEmail != null ? booking.buchEmail.Trim() : "";
            bookingprocess.TravelApplicant.Salutation = booking.buchAnrede != null ? booking.buchAnrede.Trim() : "";
            bookingprocess.OfferInfo.Adults = booking.buchErwaksene;
            bookingprocess.OfferInfo.Children = booking.buchKinder;

            CreateBookingItems(bookingprocess,booking.buchBuchungsDatum);

            return bookingprocess;
        }

        private static BookingProcess UpdateBookingWithCustomer(Customer customer,BookingProcess booking)
        {
            BookingProcess data = new BookingProcess();
            data = booking;
            data.TravelApplicantId = customer.CustomerNr;

            return data;
        }

        private static void CreateBookingItems(BookingProcess bookingProcess,DateTime? bookingdate)
        {
            List<BookingProcessItem> list = new List<BookingProcessItem>();
            BookingInquiry inquiry = new BookingInquiry();
            inquiry.BookingProcessId = bookingProcess.Id;
            inquiry.CreateDate = bookingdate != null ? (DateTime)bookingdate : DateTime.Now;
            inquiry.DocumentId = bookingProcess.BookingNumber;
            inquiry.docType = "BookingInquiry";
            manager.AddMasterData(inquiry);

            var bin = manager.GetBookingInquiryByBookingId(bookingProcess.Id);


            var bookinginquiry = new BookingProcessItem();
            bookinginquiry.BookingProcessTyp = BookingProcessItemTyp.BookingInquiry;
            bookinginquiry.CreateDate = bookingdate != null ? (DateTime)bookingdate : DateTime.Now;
            bookinginquiry.DocumentId = bin.Id;
            bookinginquiry.LastChange = DateTime.Now;
            bookinginquiry.DocumentNr = bookingProcess.BookingNumber;
            bookinginquiry.DocumentTitel = "Sync";
            bookinginquiry.DocumentStatus = DocumentStatus.Active;

            ProviderAnnouncement pan = new ProviderAnnouncement();
            pan.BookingProcessId = bookingProcess.Id;
            pan.CreateDate = bookingdate != null ? (DateTime)bookingdate : DateTime.Now;
            pan.DocumentId = bookingProcess.BookingNumber;
            pan.docType = "ProviderAnnouncement";
            manager.AddMasterData(pan);

            var p = manager.GetProviderAnnouncementByBookingId(bookingProcess.Id);

            var providerannouncement = new BookingProcessItem();
            providerannouncement.BookingProcessTyp = BookingProcessItemTyp.ProviderAnnouncement;
            providerannouncement.CreateDate = bookingdate != null ? (DateTime)bookingdate : DateTime.Now;
            providerannouncement.DocumentId = p.Id;
            providerannouncement.LastChange = DateTime.Now;
            providerannouncement.DocumentNr = bookingProcess.BookingNumber;
            providerannouncement.DocumentTitel = "Sync";
            providerannouncement.DocumentStatus = DocumentStatus.Active;

            ProviderConfirmation providerconfirmation = new ProviderConfirmation();
            providerconfirmation.BookingProcessId = bookingProcess.Id;
            providerconfirmation.CreateDate = bookingdate != null ? ((DateTime)bookingdate).AddDays(1) : DateTime.Now;
            providerconfirmation.DocumentId = bookingProcess.BookingNumber;
            providerconfirmation.docType = "ProviderConfirmation";
            manager.AddMasterData(providerconfirmation);

            var pconfirmation = manager.GetProviderConfirmationByBookingId(bookingProcess.Id);
            var pconf = new BookingProcessItem();
            pconf.BookingProcessTyp = BookingProcessItemTyp.ProviderConfirmation;
            pconf.CreateDate = bookingdate != null ? ((DateTime)bookingdate).AddDays(1) : DateTime.Now;
            pconf.DocumentId = pconfirmation.Id;
            pconf.LastChange = DateTime.Now;
            pconf.DocumentNr = bookingProcess.BookingNumber;
            pconf.DocumentTitel = "Sync";
            pconf.DocumentStatus = DocumentStatus.Active;


            BookingConfirmation bookingConfirmation = new BookingConfirmation();
            bookingConfirmation.BookingProcessId = bookingProcess.Id;
            bookingConfirmation.CreateDate= bookingdate != null ? ((DateTime)bookingdate).AddDays(1) : DateTime.Now;

            bookingConfirmation.DocumentId = bookingProcess.BookingNumber;
            bookingConfirmation.docType = "BookingConfirmation";
            manager.AddMasterData(bookingConfirmation);

            var bconfirmation = manager.GetBookingConfirmationByBookingId(bookingProcess.Id);

            var bconf = new BookingProcessItem();
            bconf.BookingProcessTyp = BookingProcessItemTyp.BookingConfirmation;
            bconf.CreateDate= bookingdate != null ? ((DateTime)bookingdate).AddDays(1) : DateTime.Now;
            bconf.DocumentId = bconfirmation.Id;
            bconf.LastChange = DateTime.Now;
            bconf.DocumentNr = bookingProcess.BookingNumber;
            bconf.DocumentTitel = "Sync";
            bconf.DocumentStatus = DocumentStatus.Active;

            CustomerVoucher customerVoucher = new CustomerVoucher();
            customerVoucher.BookingProcessId = bookingProcess.Id;
            customerVoucher.CreateDate = bookingProcess.OfferInfo.CheckIn.AddDays(-20);
            customerVoucher.DocumentId = bookingProcess.BookingNumber;
            customerVoucher.docType = "CustomerVoucher";
            manager.AddMasterData(customerVoucher);

            var cvoucher = manager.GetCustomerVoucherByBookingId(bookingProcess.Id);

            var cvouchera = new BookingProcessItem();
            cvouchera.BookingProcessTyp = BookingProcessItemTyp.CustomerVoucher;
            cvouchera.CreateDate = bookingProcess.OfferInfo.CheckIn.AddDays(-20);
            cvouchera.DocumentId = cvoucher.Id;
            cvouchera.LastChange = DateTime.Now;
            cvouchera.DocumentNr = bookingProcess.BookingNumber;
            cvouchera.DocumentTitel = "Sync";
            cvouchera.DocumentStatus = DocumentStatus.Active;


            BookingInvoice bookingInvoice = new BookingInvoice();
            bookingInvoice.BookingProcessId = bookingProcess.Id;
            bookingInvoice.CreateDate= bookingProcess.OfferInfo.CheckIn.AddDays(-20);
            bookingInvoice.DocumentId = bookingProcess.BookingNumber;
            bookingInvoice.docType = "BookingInvoice";
            manager.AddMasterData(bookingInvoice);

            var bookinvoice = manager.GetBookingInvoiceByBookingId(bookingProcess.Id);
            var binvoice = new BookingProcessItem();
            binvoice.BookingProcessTyp = BookingProcessItemTyp.BookingInvoice;
            binvoice.CreateDate = bookingProcess.OfferInfo.CheckIn.AddDays(-20);
            binvoice.DocumentId = bookinvoice.Id;
            binvoice.LastChange = DateTime.Now;
            binvoice.DocumentNr = bookingProcess.BookingNumber;
            binvoice.DocumentTitel = "Sync";
            binvoice.DocumentStatus = DocumentStatus.Active;

            list.AddRange(new BookingProcessItem[] { bookinginquiry, providerannouncement, pconf, bconf, cvouchera, binvoice });

            bookingProcess.BookingProcessItemList = list;
        }

        private static void AddBookingProcessData(BookingProcess bp,DateTime? date)
        {
            DateTime date1 = bp.OfferInfo.CheckIn;
            if (date != null)
            {
                TimeSpan days = date1.Subtract((DateTime)date);
                int difference = days.Days;
                DateTime bookingdate = (DateTime)date;

                if (difference > 60)
                {
                    List<PaymentTerm> list = new List<PaymentTerm>();
                    PaymentTerm paymentTerm1 = new PaymentTerm();
                    paymentTerm1.Date = bookingdate.AddDays(7);
                    paymentTerm1.Percent = 30;
                    paymentTerm1.Eur = bp.PriceValueByBooking * 30 / 100;

                    PaymentTerm paymentTerm2 = new PaymentTerm();
                    paymentTerm2.Date = bp.OfferInfo.CheckIn.AddDays(-42);
                    paymentTerm2.Percent = 70;
                    paymentTerm2.Eur = bp.PriceValueByBooking * 70 / 100;

                    list.Add(paymentTerm1);
                    list.Add(paymentTerm2);
                    bp.PaymentTerms = list;

                    List<TravelApplicantPayment> travelapplicantpayments = new List<TravelApplicantPayment>();
                    TravelApplicantPayment payment1 = new TravelApplicantPayment();
                    payment1.Date = bookingdate.AddDays(7);
                    payment1.Value = bp.PriceValueByBooking * 30 / 100;

                    TravelApplicantPayment payment2 = new TravelApplicantPayment();
                    payment2.Date = bp.OfferInfo.CheckIn.AddDays(-42);
                    payment2.Value = bp.PriceValueByBooking * 70 / 100;

                    travelapplicantpayments.Add(payment1);
                    travelapplicantpayments.Add(payment2);
                    bp.Payments = travelapplicantpayments;
                }
            }
            List<ProviderPayment> providerpayments = new List<ProviderPayment>();
            ProviderPayment Payment = new ProviderPayment();
            Payment.Date = bp.OfferInfo.CheckIn.AddDays(-30);
            Payment.Value = bp.PriceValueByBooking * 80 / 100;
            providerpayments.Add(Payment);

            bp.PaymentsForProvider = providerpayments;
        }

        private static BookingProcess UpdateBookingWithUnit(BookingProcess booking)
        {
            BookingProcess bookingProcess = booking;

            var list = datarepository.GetAllBookings();
            var item = list.Find(m => m.buchGuid == booking.Id);
            var unitlist = datarepository.GetAllUnits();


            SEH_UnitInfo unit = unitlist.Find(v => v.suUnitId == item.buchUnitId);
            if (unit != null)
            {
                bookingProcess.OfferInfo.SiteCode = unit.SiteCode != null ? unit.SiteCode.Trim() : "";
                bookingProcess.OfferInfo.UnitCode = unit.UnitOfferCode != null ? unit.UnitOfferCode.Trim() : "";
                bookingProcess.OfferInfo.OfferCode = unit.UnitOfferCode != null ? unit.UnitOfferCode.Trim() : "";
                bookingProcess.OfferInfo.SiteName = unit.suKurzBeschreibung != null ? unit.suKurzBeschreibung.Trim() : "";
                bookingProcess.OfferInfo.OfferName = unit.suKurzBeschreibung != null ? unit.suKurzBeschreibung.Trim() : "";
                bookingProcess.OfferInfo.TourOperatorCode = "IDOM";
            }
            return bookingProcess;
        }

        public static void SavePlaces()
        {
            var locations = datarepository.GetAllLocations();
            var places = locations.FindAll(r => r.geoParent >= 1 && r.geoParent <= 6);

            foreach(var item in places)
            {
                Place place = new Place();
                place.PlaceId = item.geoID;
                place.PlaceName = item.geoName;
                place.RegionId = (int)item.geoParent;
                manager.AddMasterData(place);
            }
        }

        public static void UpdateCustomers()
        {
            var customers = manager.GetCustomers();
            var bookingprocesses = manager.GetBookingProcesses();

            foreach(var customer in customers)
            {
                var customerbookings = bookingprocesses.FindAll(p => p.TravelApplicantId == customer.CustomerNr);
                if (customerbookings.Count > 0)
                {
                    AddBookingToCustomer(customer, customerbookings);

                    manager.UpdateMasterData(customer);
                }
            }
        }

        private static void AddBookingToCustomer(Customer c,List<BookingProcess> listbp)
        {
            List<CustomerBookingProcessInfo> data = new List<CustomerBookingProcessInfo>();
            counter++;
            foreach(var bp in listbp)
            {
                CustomerBookingProcessInfo cinfo = new CustomerBookingProcessInfo();
                cinfo.BookingProcessId = bp.Id;
                cinfo.CheckIn = bp.OfferInfo.CheckIn;
                cinfo.CheckOut = bp.OfferInfo.CheckOut;
                cinfo.OfferName = bp.OfferInfo.OfferName;
                cinfo.SiteName = bp.OfferInfo.SiteName;

                data.Add(cinfo);
            }

            c.BookingInfo = data;
        }
    }
}
