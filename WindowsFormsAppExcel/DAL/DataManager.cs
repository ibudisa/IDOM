using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DAL
{
    public class DataManager
    {
        private IMongoDatabase mongoDatabase;

        private IMongoDatabase Db()
        {

            if (mongoDatabase != null)
                return mongoDatabase;
            var url = "mongodb://ivan:ivan+2017@94.23.164.152:27017/IDOM_BackOffice_Test";
            var client = new MongoClient(url);

            mongoDatabase = client.GetDatabase("IDOM_BackOffice_Test");
            return mongoDatabase;
        }


        private IMongoCollection<Customer> collectionCustomer { get { return Db().GetCollection<Customer>("Customer"); } }
        private IMongoCollection<TouristSite> collectionTouristSite { get { return Db().GetCollection<TouristSite>("TouristSite"); } }
        private IMongoCollection<TouristUnit> collectionTouristUnit { get { return Db().GetCollection<TouristUnit>("TouristUnit"); } }
        private IMongoCollection<BookingProcess> collectionBookingProcess { get { return Db().GetCollection<BookingProcess>("BookingDocument"); } }
        private IMongoCollection<UnitOffer> collectionUnitOffer { get { return Db().GetCollection<UnitOffer>("UnitOffer"); } }
        private IMongoCollection<Place> collectionPlace { get { return Db().GetCollection<Place>("Place"); } }

        private IMongoCollection<BookingInquiry> collectionBookingInquiry { get { return Db().GetCollection<BookingInquiry>("BookingDocument"); } }
        private IMongoCollection<BookingInvoice> collectionBookingInvoice { get { return Db().GetCollection<BookingInvoice>("BookingDocument"); } }
        private IMongoCollection<CustomerVoucher> collectionCustomerVoucher { get { return Db().GetCollection<CustomerVoucher>("BookingDocument"); } }
        private IMongoCollection<ProviderAnnouncement> collectionProviderAnnouncement { get { return Db().GetCollection<ProviderAnnouncement>("BookingDocument"); } }
        private IMongoCollection<ProviderConfirmation> collectionProviderConfirmation { get { return Db().GetCollection<ProviderConfirmation>("BookingDocument"); } }
        private IMongoCollection<BookingConfirmation> collectionBookingConfirmation { get { return Db().GetCollection<BookingConfirmation>("BookingDocument"); } }



        public void AddMasterData(Customer document)
        {
            if (document.id == null)

                document.id = Guid.NewGuid().ToString();

            collectionCustomer.InsertOne(document);
        }

        public Customer GetCustomer(string id)
        {
            return collectionCustomer.Find(m => m.id == id).FirstOrDefault();
        }

        public List<Customer> GetCustomers()
        {
            return collectionCustomer.Find(m => m.id != String.Empty).ToList();
        }

        public int GetMaxCustomerNr()
        {
            int number = 0;
            int size = collectionCustomer.Find(m => m.id != String.Empty).ToList().Capacity;

            if(size==0)
            {
                number = 1001;
            }
            else
            {
                var list = collectionCustomer.Find(m => m.id != String.Empty).ToList();
                number = list.OrderByDescending(u => u.CustomerNr).FirstOrDefault().CustomerNr + 1;
            }
            return number;
        }

        public Customer GetCustomerByEmail(string email)
        {
            return collectionCustomer.Find(m => m.EMail == email).FirstOrDefault();
        }
        public void UpdateMasterData(Customer document)
        {
            var filter = Builders<Customer>.Filter.Eq(s => s.id, document.id);
            collectionCustomer.ReplaceOne(filter, document);
        }

        public void AddMasterData(TouristUnit document)
        {
            if (document.id == null)

                document.id = Guid.NewGuid().ToString();

            collectionTouristUnit.InsertOne(document);
        }

        public void AddMasterData(TouristSite document)
        {
            if (document.id == null)
                document.id = Guid.NewGuid().ToString();

            collectionTouristSite.InsertOne(document);
        }

        public void AddMasterData(BookingProcess document)
        {
            if (document.Id == null)

                document.Id = Guid.NewGuid().ToString();

            collectionBookingProcess.InsertOne(document);
        }

        public void AddMasterData(UnitOffer document)
        {
            if (document.id == null)

                document.id = Guid.NewGuid().ToString();

            collectionUnitOffer.InsertOne(document);
        }

        public void AddMasterData(Place document)
        {
            if (document.Id == null)
                document.Id = Guid.NewGuid().ToString();

            collectionPlace.InsertOne(document);
        }
        public BookingProcess GetBookingProcess(string id)
        {
            return collectionBookingProcess.Find(m => m.Id == id).FirstOrDefault();
        }
        public List<BookingProcess> GetBookingProcesses()
        {
            var list = collectionBookingProcess.Find(m => m.docType == "BookingProcess").ToList();
            return list;
        }

        public void UpdateMasterData(BookingProcess document)
        {
            var filter = Builders<BookingProcess>.Filter.Eq(s => s.Id, document.Id);
            collectionBookingProcess.ReplaceOne(filter, document);
        }

        public void AddMasterData(BookingInquiry document)
        {
            if (String.IsNullOrEmpty(document.Id))
                document.Id = Guid.NewGuid().ToString();

            collectionBookingInquiry.InsertOne(document);
        }

       
        public void AddMasterData(CustomerVoucher document)
        {
            if (String.IsNullOrEmpty(document.Id))
                document.Id = Guid.NewGuid().ToString();

            collectionCustomerVoucher.InsertOne(document);
        }


        public void AddMasterData(ProviderAnnouncement document)
        {
            if (String.IsNullOrEmpty(document.Id))

                document.Id = Guid.NewGuid().ToString();

            collectionProviderAnnouncement.InsertOne(document);
        }
        public void AddMasterData(BookingInvoice document)
        {
            if (String.IsNullOrEmpty(document.Id))
                document.Id = Guid.NewGuid().ToString();

            collectionBookingInvoice.InsertOne(document);
        }

        public void AddMasterData(BookingConfirmation document)
        {
            if (String.IsNullOrEmpty(document.Id))
                document.Id = Guid.NewGuid().ToString();

            collectionBookingConfirmation.InsertOne(document);
        }

        public void AddMasterData(ProviderConfirmation document)
        {
            if (String.IsNullOrEmpty(document.Id))

                document.Id = Guid.NewGuid().ToString();

            collectionProviderConfirmation.InsertOne(document);
        }
        public BookingConfirmation GetBookingConfirmation(string id)
        {
            return collectionBookingConfirmation.Find(m => m.Id == id).FirstOrDefault();
        }
        public BookingInquiry GetBookingInquiry(string id)
        {
            return collectionBookingInquiry.Find(m => m.Id == id).FirstOrDefault();
        }

        public BookingInvoice GetBookingInvoice(string id)
        {
            return collectionBookingInvoice.Find(m => m.Id == id).FirstOrDefault();
        }
        public CustomerVoucher GetCustomerVoucherById(string id)
        {
            return collectionCustomerVoucher.Find(m => m.Id == id).FirstOrDefault();

        }

        public ProviderAnnouncement GetProviderAnnouncement(string id)
        {
            return collectionProviderAnnouncement.Find(m => m.Id == id).FirstOrDefault();
        }

        public ProviderConfirmation GetProviderConfirmation(string id)
        {
            return collectionProviderConfirmation.Find(m => m.Id == id).FirstOrDefault();
        }

        public ProviderConfirmation GetProviderConfirmationByBookingId(string id)
        {
            return collectionProviderConfirmation.Find(m => m.BookingProcessId == id).FirstOrDefault();
        }
        public ProviderAnnouncement GetProviderAnnouncementByBookingId(string id)
        {
            return collectionProviderAnnouncement.Find(m => m.BookingProcessId == id).FirstOrDefault();
        }

        public CustomerVoucher GetCustomerVoucherByBookingId(string id)
        {
            return collectionCustomerVoucher.Find(m => m.BookingProcessId == id).FirstOrDefault();

        }

        public BookingConfirmation GetBookingConfirmationByBookingId(string id)
        {
            return collectionBookingConfirmation.Find(m => m.BookingProcessId == id).FirstOrDefault();
        }
        public BookingInquiry GetBookingInquiryByBookingId(string id)
        {
            return collectionBookingInquiry.Find(m => m.BookingProcessId == id).FirstOrDefault();
        }

        public BookingInvoice GetBookingInvoiceByBookingId(string id)
        {
            return collectionBookingInvoice.Find(m => m.BookingProcessId == id).FirstOrDefault();
        }
    }
}
