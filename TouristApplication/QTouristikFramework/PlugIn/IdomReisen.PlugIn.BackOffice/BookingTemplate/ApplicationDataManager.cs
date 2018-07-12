using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdomOffice.Interface.BackOffice.BookingTemplate;
using MongoDB.Driver;
using IdomOffice.Interface.BackOffice.Booking;


namespace IdomOffice.PlugIn.BackOffice.BookingTemplate
{
    public class ApplicationDataManager:IApplicationDataManager
    {
        private IMongoDatabase mongoDatabase;

        private IMongoDatabase Db()
        {
           
            if (mongoDatabase != null)
                return mongoDatabase;

            var url = BackOfficePlugInConfig.MongoUrl;
            var client = new MongoClient(url);
            var database = BackOfficePlugInConfig.MongoDB;
            mongoDatabase = client.GetDatabase(database);
            return mongoDatabase;
        }

        private IMongoCollection<StatusDataDocument> collectionStatusDocument { get { return Db().GetCollection<StatusDataDocument>("ApplicationCollection"); } }

        public void AddApplicationData(StatusDataDocument document)
        {
            if (document.Id == string.Empty || document.Id==null)
                document.Id = Guid.NewGuid().ToString();

            collectionStatusDocument.InsertOne(document);
        }

        public List<StatusDataDocument> GetStatusDocuments()
        {
           
            return collectionStatusDocument.Find(m => m.docType == "StatusDataDocument").ToList();
            
        }

        public List<StatusDataDocument> GetStatusDocumentsByStatus(DocumentProcessStatus status)
        {
            return collectionStatusDocument.Find(m => m.Status == status).ToList();
        }

        public StatusDataDocument GetStatusDocumentsById(string id)
        {
            return collectionStatusDocument.Find(m => m.Id == id).FirstOrDefault();
        }
    }
}
