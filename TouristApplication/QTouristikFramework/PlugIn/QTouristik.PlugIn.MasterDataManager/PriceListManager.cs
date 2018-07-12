using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTouristik.Interface.PriceLists;
using MongoDB.Driver;

namespace QTouristik.PlugIn.MasterDataManager
{
    public class PriceListManager : IPriceListManager
    {
        private IMongoDatabase mongoDatabase;

        private IMongoDatabase Db()
        {
            //TODO: IGOR - Da li da prebacim podatke u config datoteku
            if (mongoDatabase != null)
                return mongoDatabase;
            var url = "mongodb://ivan:ivan+2017@94.23.164.152:27017/IDOM_BackOffice_Test";
            var client = new MongoClient(url);

            mongoDatabase = client.GetDatabase("IDOM_BackOffice_Test");
            return mongoDatabase;
        }
        private IMongoCollection<PriceList> collectionPriceList { get { return Db().GetCollection<PriceList>("PriceList"); } }

        public void AddPriceList(PriceList document)
        {
            if (document.id == string.Empty)
                document.id = Guid.NewGuid().ToString();

            collectionPriceList.InsertOne(document);
        }

        public void DeletePriceList(string id)
        {
            throw new NotImplementedException();
        }

        public PriceList GetPriceList(string id)
        {
            return collectionPriceList.Find(m => m.id == id).FirstOrDefault();
        }

        public PriceList GetPriceList(string TourOperatorCode, string SiteCode, string OfferCode)
        {
            throw new NotImplementedException();
        }

        public List<PriceList> GetPriceLists()
        {
            throw new NotImplementedException();
        }

        public List<PriceList> GetPriceLists(string TourOperatorCode, string SiteCode, string OfferCode)
        {
            throw new NotImplementedException();
        }

        public void UpdatePriceList(PriceList document)
        {
            var filter = Builders<PriceList>.Filter.Eq(s => s.id, document.id);
            collectionPriceList.ReplaceOne(filter, document);
        }

        public PriceList GetPriceList(string SiteCode, string UnitCode, PriceListType priceListType)
        {
            return collectionPriceList.Find(m => m.SiteCode == SiteCode &&
                                                    m.UnitCode == UnitCode).FirstOrDefault();
        }

        public PriceList GetPriceList(string SiteCode, string UnitCode, string OfferCode, PriceListType priceListType)
        {
            if (priceListType == PriceListType.PurchasePrice)
            {
                return collectionPriceList.Find(m => m.SiteCode == SiteCode &&
                                                     m.UnitCode == UnitCode).FirstOrDefault();
            }

            return collectionPriceList.Find(m => m.SiteCode == SiteCode &&
                                                     m.OfferCode == OfferCode &&
                                                     m.UnitCode == UnitCode).FirstOrDefault();

        }
    }
}
