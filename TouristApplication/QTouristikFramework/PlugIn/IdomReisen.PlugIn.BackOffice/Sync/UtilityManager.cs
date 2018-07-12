using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTouristik.Interface.Sync;
using IdomOffice.Interface.BackOffice.Booking;
using IdomOffice.Interface.BackOffice.Booking.Core;
using IdomOffice.Interface.BackOffice.MasterData;
using QTouristik.Data;
using IdomOffice.PlugIn.BackOffice.MasterData;
using IdomOffice.PlugIn.BackOffice.Booking;
using IdomOffice.Interface.BackOffice.Booking.Entity;

namespace IdomOffice.PlugIn.BackOffice.Sync
{
    public class UtilityManager
    {

        private static BookingDataManager manager = new BookingDataManager();
        private static MasterDataManager mastermanager = new MasterDataManager();

        public static void SaveCustomerAndBooking(SyncBookingInquiry inquiry)
        {
            var booking = inquiry;
            QTouristik.Data.TravelApplicant travelApplicant = booking.BookingData.TravelApplicant;
            string customeremail = travelApplicant.EMail;
            bool exists = CustomerExists(customeremail);
            if(!exists)
            {
                Customer customer = CreateCustomer(travelApplicant);
                manager.AddMasterData(customer);
                BookingProcess bp = CreateBookingProcess(booking,customer);
                manager.AddMasterData(customer);
                manager.AddMasterData(bp);
            }
            else
            {
                var customer = manager.GetCustomerByEmail(customeremail);
                BookingProcess bp = CreateBookingProcess(booking, customer);
                manager.AddMasterData(bp);
            }
        }

        private static bool CustomerExists(string email)
        {
            bool exists = false;
            var customer = manager.GetCustomerByEmail(email);
            if(customer!=null)
            {
                exists = true;
            }
            return exists;

        }

        private static Customer CreateCustomer(QTouristik.Data.TravelApplicant travelApplicant)
        {
            Customer customer = new Customer();
            customer.Adress = travelApplicant.Adress;
            customer.Contry = travelApplicant.Contry;
            customer.EMail = travelApplicant.EMail;
            customer.FirstName = travelApplicant.FirstName;
            customer.LastName = travelApplicant.LastName;
            customer.MobilePhone = travelApplicant.MobilePhone;
            customer.Phone = travelApplicant.Phone;
            customer.Place = travelApplicant.Place;
            customer.Salutation = travelApplicant.Salutation;
            customer.ZipCode = travelApplicant.ZipCode;
            int customernr = GetMaxCustomerNr();
            List<int> list = new List<int>();
            list.Add(customernr);
            customer.CustomerNr = customernr;
            customer.BookKeepingNumber = list;


            return customer;



        }

        private static int GetMaxCustomerNr()
        {
            var customers = manager.GetCustomers();
            int maxId = customers.Max(u => u.CustomerNr);
            maxId++;
            return maxId;
        }

        private static BookingProcess CreateBookingProcess(SyncBookingInquiry inquiry,Customer customer)
        {
            BookingProcess booking = new BookingProcess();
            booking.Id = inquiry.id;


            booking.OfferInfo.Adults = inquiry.BookingData.Adults;
            booking.OfferInfo.Children = inquiry.BookingData.Children;
            booking.OfferInfo.CheckIn = inquiry.BookingData.CheckIn;
            DateTime date = inquiry.BookingData.CheckIn; 
            booking.OfferInfo.CheckOut = inquiry.BookingData.CheckOut;
            booking.OfferInfo.OfferCode = inquiry.BookingData.OfferCode;
            booking.OfferInfo.SiteCode = inquiry.BookingData.SiteCode;
            booking.OfferInfo.TourOperatorCode = inquiry.TourOperatorCode;



            booking.TravelApplicant.Adress = inquiry.BookingData.TravelApplicant.Adress;
            booking.TravelApplicant.Contry = inquiry.BookingData.TravelApplicant.Contry;
            booking.TravelApplicant.EMail = inquiry.BookingData.TravelApplicant.EMail;
            booking.TravelApplicant.FirstName = inquiry.BookingData.TravelApplicant.FirstName;
            booking.TravelApplicant.LastName = inquiry.BookingData.TravelApplicant.LastName;
            booking.TravelApplicant.MobilePhone = inquiry.BookingData.TravelApplicant.MobilePhone;
            booking.TravelApplicant.Phone = inquiry.BookingData.TravelApplicant.Phone;
            booking.TravelApplicant.Place = inquiry.BookingData.TravelApplicant.Place;
            booking.TravelApplicant.Salutation = inquiry.BookingData.TravelApplicant.Salutation;
            booking.TravelApplicant.ZipCode = inquiry.BookingData.TravelApplicant.ZipCode;

            
            

            
            List<TravelApplicantPayment> lis = new List<TravelApplicantPayment>();
            TravelApplicantPayment p1 = new TravelApplicantPayment();
            p1.Date = inquiry.BookingData.CheckIn;
            p1.Value = inquiry.BookingData.PriceValueByArrival;
            TravelApplicantPayment p2 = new TravelApplicantPayment();
            p2.Date = inquiry.BookingData.CheckOut;
            p2.Value = inquiry.BookingData.PriceValueByBooking;
            lis.Add(p1);
            lis.Add(p2);
            //booking.Payments = lis;
            booking.Season = date.Year.ToString();
            booking.Status = DocumentProcessStatus.New;
            booking.TravelApplicantId = customer.CustomerNr;
            CreateBookingInquiry(inquiry);
            string bookinginquirynumber = inquiry.BookingInquiryNummer;
            BookingInquiry inquiryq = manager.GetBookingInquiryByNumber(bookinginquirynumber);
            BookingProcessItem item = new BookingProcessItem();

            item.DocumentId = inquiryq.Id;
            item.DocumentNr = inquiryq.BookingInquiryNummer;
            item.DocumentStatus = DocumentStatus.Active;
            item.DocumentTitel = "AB" + "-"+ inquiryq.BookingInquiryNummer;
            item.CreateDate = DateTime.Now;
            item.BookingProcessTyp = BookingProcessItemTyp.BookingInquiry;
            item.Author = "Igor Cuic";

            List<BookingProcessItem> bookinglist = new List<BookingProcessItem>();
            bookinglist.Add(item);

            booking.BookingProcessItemList = bookinglist;

            return booking;
            
        }

        private static void CreateBookingInquiry(SyncBookingInquiry inquiry)
        {
            BookingInquiry booking = new BookingInquiry();
            booking.BookingInquiryNummer = inquiry.BookingInquiryNummer;
           

            booking.OfferInfo.Adults = inquiry.BookingData.Adults;
            booking.OfferInfo.Children = inquiry.BookingData.Children;
            booking.OfferInfo.CheckIn = inquiry.BookingData.CheckIn;
            DateTime date = inquiry.BookingData.CheckIn;
            booking.OfferInfo.CheckOut = inquiry.BookingData.CheckOut;
           
           
            
            
           
            booking.TravelApplicant.Adress = inquiry.BookingData.TravelApplicant.Adress;
            booking.TravelApplicant.Contry = inquiry.BookingData.TravelApplicant.Contry;
            booking.TravelApplicant.EMail = inquiry.BookingData.TravelApplicant.EMail;
            booking.TravelApplicant.FirstName = inquiry.BookingData.TravelApplicant.FirstName;
            booking.TravelApplicant.LastName = inquiry.BookingData.TravelApplicant.LastName;
            booking.TravelApplicant.MobilePhone = inquiry.BookingData.TravelApplicant.MobilePhone;
            booking.TravelApplicant.Phone = inquiry.BookingData.TravelApplicant.Phone;
            booking.TravelApplicant.Place = inquiry.BookingData.TravelApplicant.Place;
            booking.TravelApplicant.Salutation = inquiry.BookingData.TravelApplicant.Salutation;
            booking.TravelApplicant.ZipCode = inquiry.BookingData.TravelApplicant.ZipCode;
            IdomOffice.Interface.BackOffice.Booking.TravelerEntity travelerEntity = new IdomOffice.Interface.BackOffice.Booking.TravelerEntity();
            travelerEntity.FirstName = inquiry.BookingData.TravelApplicant.FirstName;
            travelerEntity.LastName = inquiry.BookingData.TravelApplicant.LastName;
            travelerEntity.Salutation = inquiry.BookingData.TravelApplicant.Salutation;
            List<IdomOffice.Interface.BackOffice.Booking.TravelerEntity> t = new List<Interface.BackOffice.Booking.TravelerEntity>();
            t.Add(travelerEntity);
            booking.Traveler = t;

            manager.AddMasterData(booking);
        }
    }
}
