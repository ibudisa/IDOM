using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdomOffice.Interface.BackOffice.Booking;
using MongoDB.Driver;
using IdomOffice.Interface.BackOffice.Booking.Core;
using IdomOffice.Interface.BackOffice;
using IdomOffice.Interface.BackOffice.Booking.Documents;




namespace IdomOffice.PlugIn.BackOffice.Booking
{
    public class BookingDataManager : IBookingDataManager
    {
        private IMongoDatabase mongoDatabase;

        private IMongoDatabase Db()
        {
             
            if (mongoDatabase != null)
                return mongoDatabase;
            //  ConfigStringInfo info = new ConfigStringInfo();
            var url = BackOfficePlugInConfig.MongoUrl;
            var client = new MongoClient(url);
            var database = BackOfficePlugInConfig.MongoDB;
            mongoDatabase = client.GetDatabase(database);
            return mongoDatabase;
        }

        private IMongoCollection<Customer> collectionCustomer { get { return Db().GetCollection<Customer>("Customer"); } }
        private IMongoCollection<Provider> collectionProvider { get { return Db().GetCollection<Provider>("Provider"); } }
        private IMongoCollection<BookingConfirmation> collectionBookingConfirmation { get { return Db().GetCollection<BookingConfirmation>("BookingDocument"); } }
        private IMongoCollection<BookingInquiry> collectionBookingInquiry { get { return Db().GetCollection<BookingInquiry>("BookingDocument"); } }
        private IMongoCollection<BookingInvoice> collectionBookingInvoice { get { return Db().GetCollection<BookingInvoice>("BookingDocument"); } }
        private IMongoCollection<CustomerVoucher> collectionCustomerVoucher { get { return Db().GetCollection<CustomerVoucher>("BookingDocument"); } }
        private IMongoCollection<BookingProcess> collectionBookingProcess { get { return Db().GetCollection<BookingProcess>("BookingDocument"); } }
        private IMongoCollection<BookingProcessItem> collectionBookingProcessItem { get { return Db().GetCollection<BookingProcessItem>("BookingDocument"); } }
        private IMongoCollection<B2BCustomer> collectionB2BCustomer { get { return Db().GetCollection<B2BCustomer>("B2BCustomer"); } }
        private IMongoCollection<Email> collectionEmail { get { return Db().GetCollection<Email>("BookingDocument"); } }
        private IMongoCollection<TextInfo> collectionTextInfo { get { return Db().GetCollection<TextInfo>("BookingDocument"); } }
        private IMongoCollection<TravelApplicantPaymentData> collectionTravelApplicantPayment { get { return Db().GetCollection<TravelApplicantPaymentData>("BookingDocument"); } }
        private IMongoCollection<ProviderPaymentData> collectionProviderPayment { get { return Db().GetCollection<ProviderPaymentData>("BookingDocument"); } }
        private IMongoCollection<ApplicationKey> collectionApplicationKey { get { return Db().GetCollection<ApplicationKey>("BookingDocument"); } }
        private IMongoCollection<ProviderAnnouncement> collectionProviderAnnouncement { get { return Db().GetCollection<ProviderAnnouncement>("BookingDocument"); } }
        private IMongoCollection<ProviderConfirmation> collectionProviderConfirmation { get { return Db().GetCollection<ProviderConfirmation>("BookingDocument"); } }

        private IMongoCollection<Template> collectionTemplate { get { return Db().GetCollection<Template>("Template"); } }

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

        public void AddMasterData(BookingProcessItem document)
        {
            if (String.IsNullOrEmpty(document.DocumentId))
                document.DocumentId = Guid.NewGuid().ToString();

            collectionBookingProcessItem.InsertOne(document);
        }

        public void AddMasterData(BookingProcess document)
        {
            if (String.IsNullOrEmpty(document.Id))
                document.Id = Guid.NewGuid().ToString();

            collectionBookingProcess.InsertOne(document);
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

        public void AddMasterData(Customer document)
        {
            if (String.IsNullOrEmpty(document.id))
                document.id = Guid.NewGuid().ToString();

            collectionCustomer.InsertOne(document);
        }

        public BookingProcessItem BookingProcessItemById(string id)
        {
            throw new NotImplementedException();
        }

        public BookingConfirmation GetBookingConfirmation(string id)
        {
            return collectionBookingConfirmation.Find(m => m.Id == id).FirstOrDefault();
        }

        public List<BookingConfirmation> GetBookingConfirmations()
        {
            return collectionBookingConfirmation.Find(m => m.docType == "BookingConfirmation").ToList();
        }

        public BookingConfirmation GetBookingConfirmationByBookingId(string bookingid)
        {
            return collectionBookingConfirmation.Find(m => m.BookingProcessId == bookingid).FirstOrDefault();
        }

        public List<BookingInquiry> GetBookingInquires()
        {
            return collectionBookingInquiry.Find(m => m.docType == "BookingInquiry").ToList();
        }

        public BookingInquiry GetBookingInquiry(string id)
        {
            return collectionBookingInquiry.Find(m => m.Id == id).FirstOrDefault();
        }

        public BookingInvoice GetBookingInvoice(string id)
        {
            return collectionBookingInvoice.Find(m => m.Id == id).FirstOrDefault();
        }

        public List<BookingInvoice> GetBookingInvoices()
        {
            throw new NotImplementedException();
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

        public List<CustomerVoucher> GetBookingProcessItems()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(string id)
        {
            return collectionCustomer.Find(m => m.id == id).FirstOrDefault();
        }

        public List<Customer> GetCustomers()
        {
            return collectionCustomer.Find(m => m.id != String.Empty).ToList();
        }

        public CustomerVoucher GetCustomerVoucherById(string id)
        {
            return collectionCustomerVoucher.Find(m => m.Id == id).FirstOrDefault();

        }

        public List<CustomerVoucher> GetCustomerVouchers()
        {
            throw new NotImplementedException();
        }

        public void UpdateMasterData(BookingInvoice document)
        {
            throw new NotImplementedException();
        }

        public void UpdateMasterData(BookingProcess document)
        {
            var filter = Builders<BookingProcess>.Filter.Eq(s => s.Id, document.Id);
            collectionBookingProcess.ReplaceOne(filter, document);
        }

        public void UpdateMasterData(BookingProcessItem document)
        {
            throw new NotImplementedException();
        }

        public void UpdateMasterData(CustomerVoucher document)
        {
            throw new NotImplementedException();
        }

        public void UpdateMasterData(BookingInquiry document)
        {
            var filter = Builders<BookingInquiry>.Filter.Eq(s => s.Id, document.Id);
            collectionBookingInquiry.ReplaceOne(filter, document);
        }

        public void UpdateMasterData(BookingConfirmation document)
        {
            var filter = Builders<BookingConfirmation>.Filter.Eq(s => s.Id, document.Id);
            collectionBookingConfirmation.ReplaceOne(filter, document);
        }

        public void UpdateMasterData(Customer document)
        {
            var filter = Builders<Customer>.Filter.Eq(s => s.id, document.id);
            collectionCustomer.ReplaceOne(filter, document);
        }

        public void DeleteBookingProcess(string id)
        {
            var filter = Builders<BookingProcess>.Filter.Eq(s => s.Id, id);
            collectionBookingProcess.DeleteOne(filter);
        }

        public void AddMasterData(Provider document)
        {
            if (document.Id == string.Empty)

                document.Id = Guid.NewGuid().ToString();

            collectionProvider.InsertOne(document);
        }

        public void UpdateMasterData(Provider document)
        {
            var filter = Builders<Provider>.Filter.Eq(s => s.Id, document.Id);
            collectionProvider.ReplaceOne(filter, document);
        }

        public Provider GetProvider(string id)
        {
            return collectionProvider.Find(m => m.Id == id).FirstOrDefault();
        }
        public Provider GetProviderForProviderId(int providerid)
        {
            return collectionProvider.Find(m => m.ProviderId == providerid).FirstOrDefault();
        }

        public Provider GetProviderByName(string name)
        {
            return collectionProvider.Find(m => m.Name == name).FirstOrDefault();

        }

        public List<Provider> GetProviders()
        {
            return collectionProvider.Find(m => m.Id != string.Empty).ToList();
        }

        public void DeleteProvider(string id)
        {
            var filter = Builders<Provider>.Filter.Eq(s => s.Id, id);
            collectionProvider.DeleteOne(filter);
        }

        public void AddMasterData(B2BCustomer document)
        {
            if (document.Id == string.Empty)

                document.Id = Guid.NewGuid().ToString();

            collectionB2BCustomer.InsertOne(document);
        }

        public void UpdateMasterData(B2BCustomer document)
        {
            var filter = Builders<B2BCustomer>.Filter.Eq(s => s.Id, document.Id);
            collectionB2BCustomer.ReplaceOne(filter, document);
        }

        public B2BCustomer GetB2BCustomer(string id)
        {
            return collectionB2BCustomer.Find(m => m.Id == id).FirstOrDefault();
        }

        public List<B2BCustomer> GetB2BCustomers()
        {
            return collectionB2BCustomer.Find(m => m.Id != string.Empty).ToList();
        }

        public void DeleteB2BCustomer(string id)
        {
            var filter = Builders<B2BCustomer>.Filter.Eq(s => s.Id, id);
            collectionB2BCustomer.DeleteOne(filter);
        }

        public void AddMasterData(Email document)
        {
            if (document.Id == string.Empty)

                document.Id = Guid.NewGuid().ToString();

            collectionEmail.InsertOne(document);
        }

        public Email GetEmail(string id)
        {
            return collectionEmail.Find(m => m.Id == id).FirstOrDefault();
        }

        public List<Email> GetEmails()
        {
            return collectionEmail.Find(m => m.docType == "Email").ToList();
        }

        public Email GetEmailByBookingIdLast(string bookingid)
        {
            Email email = GetEmails().FindLast(t => t.BookingId == bookingid);

            return email;
           
        }

        public void DeleteCustomer(string id)
        {
            var filter = Builders<Customer>.Filter.Eq(s => s.id, id);
            collectionCustomer.DeleteOne(filter);
        }

        public List<BookingProcess> GetBookingProcessByCustomerId(int customerid)
        {
            return collectionBookingProcess.Find(m => m.TravelApplicantId == customerid).ToList();
        }

        public List<BookingProcess> GetBookingProcessByPartnerId(int partnerid)
        {
            return collectionBookingProcess.Find(m => m.SellingPartner == partnerid).ToList();
        }

        public List<BookingProcess> GetBookingProcessByProviderId(int providerid)
        {
            return collectionBookingProcess.Find(m => m.AccProvider == providerid).ToList();
        }

        public void AddMasterData(Template document)
        {
            if (document.Id == string.Empty)

                document.Id = Guid.NewGuid().ToString();

            collectionTemplate.InsertOne(document);
        }


        public void UpdateMasterData(Template document)
        {
            var filter = Builders<Template>.Filter.Eq(s => s.Id, document.Id);
            collectionTemplate.ReplaceOne(filter, document);
        }

        public Template GetTemplate(string id)
        {
            return collectionTemplate.Find(m => m.Id == id).FirstOrDefault();
        }

        public List<Template> GetTemplates()
        {
            return collectionTemplate.Find(m => m.Id!=null).ToList();
        }

        public List<Template> GetTemplatesByStatusId(string statusid)
        {
            return collectionTemplate.Find(m => m.StatusId == statusid).ToList();
        }

        public void DeleteTemplate(string id)
        {
            var filter = Builders<Template>.Filter.Eq(s => s.Id, id);
            collectionTemplate.DeleteOne(filter);
        }

        public Customer GetCustomerByCustomerNr(int customerNr)
        {
            return collectionCustomer.Find(m => m.CustomerNr == customerNr).FirstOrDefault();
        }

        public void AddMasterData(TextInfo document)
        {
            if (document.Id == string.Empty)

                document.Id = Guid.NewGuid().ToString();

            collectionTextInfo.InsertOne(document);
        }

        public TextInfo GetTextInfo(string id)
        {
            return collectionTextInfo.Find(m => m.Id == id).FirstOrDefault();
        }

        public List<TextInfo> GetTextInfos()
        {
            return collectionTextInfo.Find(m => m.docType == "Text").ToList();
        }

        public void AddMasterData(TravelApplicantPaymentData document)
        {
            if (document.Id == string.Empty)

                document.Id = Guid.NewGuid().ToString();

            collectionTravelApplicantPayment.InsertOne(document);
        }

        public TravelApplicantPaymentData GetApplicantPayment(string id)
        {
            return collectionTravelApplicantPayment.Find(m => m.Id == id).FirstOrDefault();
        }

        public List<TravelApplicantPaymentData> GetApplicantPayments()
        {
            return collectionTravelApplicantPayment.Find(m => m.docType == "TravelApplicantPayment").ToList();
        }

        public List<TravelApplicantPaymentData> GetApplicantPaymentsByBookingId(string id)
        {
            return collectionTravelApplicantPayment.Find(m => m.BookingId == id).ToList();
        }

        public void AddMasterData(ProviderPaymentData document)
        {
            if (document.Id == string.Empty)

                document.Id = Guid.NewGuid().ToString();

            collectionProviderPayment.InsertOne(document);
        }

        public ProviderPaymentData GetProviderPayment(string id)
        {
            return collectionProviderPayment.Find(m => m.Id == id).FirstOrDefault();
        }

        public List<ProviderPaymentData> GetProviderPayments()
        {
            return collectionProviderPayment.Find(m => m.docType == "ProviderPayment").ToList();
        }

        public List<ProviderPaymentData> GetProviderPaymentsByBookingId(string id)
        {
            return collectionProviderPayment.Find(m => m.BookingId == id).ToList();
        }

        public void AddMasterData(ApplicationKey document)
        {
            if (document.Id == string.Empty)

                document.Id = Guid.NewGuid().ToString();

            collectionApplicationKey.InsertOne(document);
        }

        public void UpdateMasterData(ApplicationKey document)
        {
            var filter = Builders<ApplicationKey>.Filter.Eq(s => s.Id, document.Id);
            collectionApplicationKey.ReplaceOne(filter, document);
        }

        public ApplicationKey GetApplicationKey(string id)
        {
            return collectionApplicationKey.Find(m => m.Id == id).FirstOrDefault();
        }

        public List<ApplicationKey> GetApplicationKeys()
        {
            return collectionApplicationKey.Find(m => m.docType == "ApplicationKey").ToList();
        }

        public ApplicationKey GetApplicationKeyByName(string name)
        {
            return collectionApplicationKey.Find(m => m.Name == name).FirstOrDefault();
        }


        public void AddMasterData(ProviderAnnouncement document)
        {
            if (document.Id == string.Empty)

                document.Id = Guid.NewGuid().ToString();

            collectionProviderAnnouncement.InsertOne(document);
        }

        public void UpdateMasterData(ProviderAnnouncement document)
        {
            var filter = Builders<ProviderAnnouncement>.Filter.Eq(s => s.Id, document.Id);
            collectionProviderAnnouncement.ReplaceOne(filter, document);
        }

        public ProviderAnnouncement GetProviderAnnouncement(string id)
        {
            return collectionProviderAnnouncement.Find(m => m.Id == id).FirstOrDefault();
        }

        public ProviderAnnouncement GetProviderAnnouncementByBookingId(string id)
        {
            return collectionProviderAnnouncement.Find(m => m.BookingProcessId == id).FirstOrDefault();
        }

        public List<ProviderAnnouncement> GetProviderAnnouncements()
        {
            return collectionProviderAnnouncement.Find(m => m.docType == "ProviderAnnouncement").ToList();
        }

        public void AddMasterData(ProviderConfirmation document)
        {
            if (document.Id == string.Empty)

                document.Id = Guid.NewGuid().ToString();

            collectionProviderConfirmation.InsertOne(document);
        }

        public void UpdateMasterData(ProviderConfirmation document)
        {
            var filter = Builders<ProviderConfirmation>.Filter.Eq(s => s.Id, document.Id);
            collectionProviderConfirmation.ReplaceOne(filter, document);
        }

        public ProviderConfirmation GetProviderConfirmation(string id)
        {
            return collectionProviderConfirmation.Find(m => m.Id == id).FirstOrDefault();
        }

        public ProviderConfirmation GetProviderConfirmationByBookingId(string id)
        {
            return collectionProviderConfirmation.Find(m => m.BookingProcessId == id).FirstOrDefault();
        }

        public List<ProviderConfirmation> GetProviderConfirmations()
        {
            return collectionProviderConfirmation.Find(m => m.docType == "ProviderConfirmation").ToList();
        }

        public Customer GetCustomerByEmail(string email)
        {
            return collectionCustomer.Find(m => m.EMail == email).FirstOrDefault();

        }

        public BookingInquiry GetBookingInquiryByNumber(string number)
        {
            return collectionBookingInquiry.Find(m => m.BookingInquiryNummer == number).FirstOrDefault();

        }
    }
}
