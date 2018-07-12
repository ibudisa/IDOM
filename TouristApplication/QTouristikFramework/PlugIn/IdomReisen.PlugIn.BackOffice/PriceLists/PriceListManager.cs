using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdomOffice.Interface.BackOffice.PriceLists;
using MongoDB.Driver;


namespace IdomOffice.PlugIn.BackOffice.PriceLists
{
    public class PriceListManager : IPriceListManager
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
        private IMongoCollection<PriceList> collectionPriceList { get { return Db().GetCollection<PriceList>("PriceList"); } }

        public void AddPriceList(PriceList document)
        {
            if(String.IsNullOrEmpty(document.TourOperatorCode) )
                    throw new Exception("Touroerator = null");
            if (String.IsNullOrEmpty(document.OfferCode))
                throw new Exception("OfferCode = null");

            var list = GetPriceList(document.TourOperatorCode, document.SiteCode,document.OfferCode, document.PriceListType);
            // provjeriti da li postoji price list sa istim sitecode, unitcode,  offercode i PriceListTyp
             // ukoliko pricelist postoji poslati error 
            if(list!=null)
            {
                throw new Exception("Već postoji pricelista");
            }
            if (document.id == string.Empty)
                document.id = Guid.NewGuid().ToString();

            document.LastChange = DateTime.Now;

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

 

        public PriceList GetPriceList(string TourOperatorCode, string SiteCode, string OfferCode, PriceListType priceListType)
        {
            return collectionPriceList.Find(m => m.TourOperatorCode == TourOperatorCode && m.SiteCode == SiteCode &&
                                                  m.OfferCode == OfferCode && m.PriceListType == priceListType).FirstOrDefault();
        }

        public List<PriceList> GetPriceLists()
        {
            return collectionPriceList.Find(m => m.id != string.Empty).ToList();
        }
        public List<PriceList> GetPriceLists(string siteCode)
        {
            return collectionPriceList.Find(m => m.SiteCode != siteCode).ToList();
        }

   

        public List<PriceList> GetPriceLists(string tourOperatorCode, string siteCode,  string offerCode)
        {
            return collectionPriceList.Find(m => m.SiteCode != siteCode && m.TourOperatorCode == tourOperatorCode && m.OfferCode == offerCode).ToList();
        }


        public void UpdatePriceList(PriceList document)
        {
            document.LastChange = DateTime.Now;
            var filter = Builders<PriceList>.Filter.Eq(s => s.id, document.id);
            collectionPriceList.ReplaceOne(filter, document);
        }

        
    }
}
