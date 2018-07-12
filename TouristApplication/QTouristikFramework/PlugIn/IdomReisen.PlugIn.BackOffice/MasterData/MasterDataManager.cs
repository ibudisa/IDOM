using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdomOffice.Interface.BackOffice.MasterData;
using MongoDB.Driver;


namespace IdomOffice.PlugIn.BackOffice.MasterData
{
    public class MasterDataManager : IMasterDataManager
    {
        public string Databaseurl { get; set; }
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

        private IMongoCollection<Country> collectionCountry { get { return Db().GetCollection<Country>("Country"); } }
        private IMongoCollection<Region> collectionRegion { get { return Db().GetCollection<Region>("Region"); } }
        private IMongoCollection<Place> collectionPlace { get { return Db().GetCollection<Place>("Place"); } }
        private IMongoCollection<TouristSite> collectionTouristSite { get { return Db().GetCollection<TouristSite>("TouristSite"); } }
        private IMongoCollection<TouristUnit> collectionTouristUnit { get { return Db().GetCollection<TouristUnit>("TouristUnit"); } }
        private IMongoCollection<UnitOffer> collectionUnitOffer { get { return Db().GetCollection<UnitOffer>("UnitOffer"); } }
        private IMongoCollection<BackOfficeContact> collectionBackOfficeContact { get { return Db().GetCollection<BackOfficeContact>("BackOfficeContact"); } }

        public void AddMasterData(Region document)
        {
            if (document.Id == string.Empty)

                document.Id = Guid.NewGuid().ToString();

            collectionRegion.InsertOne(document);
        }

        public void AddMasterData(TouristUnit document)
        {
            if (document.id == string.Empty)

                document.id = Guid.NewGuid().ToString();

            collectionTouristUnit.InsertOne(document);
        }

        public void AddMasterData(TouristSite document)
        {
            if (document.id == string.Empty)
                document.id = Guid.NewGuid().ToString();

            collectionTouristSite.InsertOne(document);
        }

        public void AddMasterData(Place document)
        {
            if (document.Id == string.Empty)
                document.Id = Guid.NewGuid().ToString();

            collectionPlace.InsertOne(document);
        }

        public void AddMasterData(UnitOffer document)
        {
            if (document.id == string.Empty)

                document.id = Guid.NewGuid().ToString();

            document.LastChange = DateTime.Now;

            collectionUnitOffer.InsertOne(document);
        }

        public void AddMasterData(Country document)
        {
            if (document.Id == string.Empty)
                document.Id = Guid.NewGuid().ToString();

            collectionCountry.InsertOne(document);
        }

        public void DeleteTouristUnit(string id)
        {
            var filter = Builders<TouristUnit>.Filter.Eq(s => s.id, id);
            collectionTouristUnit.DeleteOne(filter);
        }

        public List<Country> GetCountries()
        {
            //ToDo: naci pravu funkciju za vracanje svih recorda
            return collectionCountry.Find(m => m.Id != string.Empty).ToList();
        }

        public Country GetCountry(string id)
        {
            return collectionCountry.Find(m => m.Id == id).FirstOrDefault();
        }

        public Country GetCountry(int countryId)
        {
            return collectionCountry.Find(m => m.CountryId == countryId).FirstOrDefault();
        }

        public Place GetPlace(int id)
        {
            return collectionPlace.Find(m => m.PlaceId == id).FirstOrDefault();
        }


        public List<Place> GetPlaces(int region)
        {
            return collectionPlace.Find(m => m.RegionId == region).ToList();
        }

        public Region GetRegion(string id)
        {
            return collectionRegion.Find(m => m.Id == id).FirstOrDefault();
        }

        public List<Region> GetRegions(int country)
        {
            return collectionRegion.Find(m => m.CountryId == country).ToList();
        }

        public TouristSite GetTouristSite(string id)
        {
            return collectionTouristSite.Find(m => m.id == id).FirstOrDefault();
        }

        public TouristSite GetTouristSiteForCode(string code)
        {
            return collectionTouristSite.Find(m => m.SiteCode == code).FirstOrDefault();
        }

        public List<TouristSite> GetTouristSites()
        {
            return collectionTouristSite.Find(m => m.id != string.Empty).ToList();
        }

        public List<TouristSite> GetTouristSitesForPlace(int place)
        {
            return collectionTouristSite.Find(m => m.PlaceId == place).ToList();
        }

        public List<TouristSite> GetTouristSitesForRegion(int region)
        {
            return collectionTouristSite.Find(m => m.RegionId == region).ToList();
        }
        // Vraća listu touristunita za određeni sitecode
        public List<TouristUnit> GetTouristUnitsForSite(string sitecode)
        {
            return collectionTouristUnit.Find(m => m.SiteCode == sitecode).ToList();
        }

        public TouristUnit GetTouristUnit(string siteCode, string unitCode)
        {
            return collectionTouristUnit.Find(m => m.SiteCode == siteCode && m.UnitCode == unitCode).FirstOrDefault();
        }

        public TouristUnit GetTouristUnitById(string id)
        {
            return collectionTouristUnit.Find(m => m.id == id).FirstOrDefault();
        }

        public List<TouristUnit> GetTouristUnitsByOperator(string operatorId)
        {
            return collectionTouristUnit.Find(m => m.TourOperatorCode == operatorId).ToList();
        }

        public List<TouristUnit> GetTouristUnitsBySite(string siteCode)
        {
            return collectionTouristUnit.Find(m => m.SiteCode == siteCode).ToList();
        }

        public UnitOffer GetUnitOffer(string id)
        {
            return collectionUnitOffer.Find(m => m.id == id).FirstOrDefault();
        }

        public List<UnitOffer> GetUnitOffer(string sitecode,string unitcode)
        {
            return collectionUnitOffer.Find(m => m.SiteCode == sitecode && m.UnitCode == unitcode).ToList();
        }

        public UnitOffer GetUnitOffer(string TourOperatorCode, string site, string offerCode)
        {
            return collectionUnitOffer.Find(m => m.TourOperatorCode == TourOperatorCode && m.SiteCode == site && m.OfferCode == offerCode).FirstOrDefault();
        }

        public List<UnitOffer> GetUnitOffers(string site)
        {
            return collectionUnitOffer.Find(m => m.SiteCode == site).ToList();
        }

        public List<UnitOffer> GetUnitOffers(string TourOperatorCode, string site)
        {
            return collectionUnitOffer.Find(m => m.TourOperatorCode == TourOperatorCode && m.SiteCode == site).ToList();
        }

        public void UpdateMasterData(TouristUnit document)
        {
            var filter = Builders<TouristUnit>.Filter.Eq(s => s.id, document.id);
            collectionTouristUnit.ReplaceOne(filter, document);
        }

        public void UpdateMasterData(UnitOffer document)
        {
            document.LastChange = DateTime.Now;
            var filter = Builders<UnitOffer>.Filter.Eq(s => s.id, document.id);
            collectionUnitOffer.ReplaceOne(filter, document);
        }

        public void UpdateMasterData(Place document)
        {
            var filter = Builders<Place>.Filter.Eq(s => s.Id, document.Id);
            collectionPlace.ReplaceOne(filter, document);
        }

        public void UpdateMasterData(TouristSite document)
        {
            var filter = Builders<TouristSite>.Filter.Eq(s => s.id, document.id);
            collectionTouristSite.ReplaceOne(filter, document);
        }

        public void UpdateMasterData(Region document)
        {
            var filter = Builders<Region>.Filter.Eq(s => s.Id, document.Id);
            collectionRegion.ReplaceOne(filter, document);
        }

        public void UpdateMasterData(Country document)
        {
            var filter = Builders<Country>.Filter.Eq(s => s.Id, document.Id);
            collectionCountry.ReplaceOne(filter, document);
        }

        public void DeleteCountry(string id)
        {
            var filter = Builders<Country>.Filter.Eq(s => s.Id, id);
            collectionCountry.DeleteOne(filter);
        }


        public List<Region> GetRegions()
        {
            return collectionRegion.Find(m => m.Id != string.Empty).ToList();
        }

        public List<Place> GetPlaces()
        {
            return collectionPlace.Find(m => m.Id != string.Empty).ToList();
        }

        public void DeleteRegion(string id)
        {
            var filter = Builders<Region>.Filter.Eq(s => s.Id, id);
            collectionRegion.DeleteOne(filter);
        }

        public void DeletePlace(string id)
        {
            var filter = Builders<Place>.Filter.Eq(s => s.Id, id);
            collectionPlace.DeleteOne(filter);
        }

        public void DeleteTouristSite(string id)
        {
            var filter = Builders<TouristSite>.Filter.Eq(s => s.id, id);
            collectionTouristSite.DeleteOne(filter);
        }

        public Place GetPlace(string id)
        {
            return collectionPlace.Find(m => m.Id == id).FirstOrDefault();
        }

        public void DeleteUnitOffer(string id)
        {
            var filter = Builders<UnitOffer>.Filter.Eq(s => s.id, id);
            collectionUnitOffer.DeleteOne(filter);
        }

        public List<TouristUnit> GetTouristUnits()
        {
            return collectionTouristUnit.Find(m => m.id != string.Empty).ToList();
        }

        public List<UnitOffer> GetUnitOffers()
        {
            return collectionUnitOffer.Find(m => m.id != string.Empty).ToList();
        }

        public TouristUnit GetTouristUnitByUnitCode(string unitcode)
        {
            return collectionTouristUnit.Find(m => m.UnitCode==unitcode).FirstOrDefault();
        }

        public UnitOffer GetUnitOfferByCode(string offerCode)
        {
            return collectionUnitOffer.Find(m => m.OfferCode == offerCode).FirstOrDefault();
        }

        public void AddMasterData(BackOfficeContact document)
        {
            if (document.Id == string.Empty)

                document.Id = Guid.NewGuid().ToString();

            collectionBackOfficeContact.InsertOne(document);
        }

        public void UpdateMasterData(BackOfficeContact document)
        {
            var filter = Builders<BackOfficeContact>.Filter.Eq(s => s.Id, document.Id);
            collectionBackOfficeContact.ReplaceOne(filter, document);
        }

        public List<BackOfficeContact> GetBackOfficeContacts()
        {
            return collectionBackOfficeContact.Find(m => m.Id != string.Empty).ToList();
        }

        public BackOfficeContact GetBackOfficeContact(string id)
        {
            return collectionBackOfficeContact.Find(m => m.Id == id).FirstOrDefault();
        }

        public void DeleteBackOfficeContact(string id)
        {
            var filter = Builders<BackOfficeContact>.Filter.Eq(s => s.Id, id);
            collectionBackOfficeContact.DeleteOne(filter);
        }

        public GeoMasterDateInfo GetGeoMasterDateInfo(string TourOperatorCode, string TouristSiteCode, string UnitOfferCode)
        {
            GeoMasterDateInfo data = new GeoMasterDateInfo();
            UnitOffer unitOffer = GetUnitOffer(TourOperatorCode, TouristSiteCode, UnitOfferCode);
            string unitcode = unitOffer.UnitCode;
            TouristUnit touristUnit = GetTouristUnitByUnitCode(unitcode);
            TouristSite touristSite = GetTouristSiteForCode(TouristSiteCode);

            int countryid = touristSite.CountryId;
            int regionid = touristSite.RegionId;
            int placeid = touristSite.PlaceId;
            Country country = GetCountry(countryid);
            Region region = GetRegion(regionid);
            Place place = GetPlace(placeid);
            data.Country = country;
            data.Place = place;
            data.Region = region;
            data.TouristSite = touristSite;
            data.TouristUnit = touristUnit;
            data.UnitOffer = unitOffer;

            return data;
        }

        public Region GetRegion(int regionid)
        {
            return collectionRegion.Find(m => m.RegionId == regionid).FirstOrDefault();
        }

        public List<UnitOffer> GetUnitOfferByTourOperator(string TourOperatorCode)
        {
            return collectionUnitOffer.Find(m => m.TourOperatorCode == TourOperatorCode).ToList();

        }

        public TouristUnit GetTouristUnit(string touroperatorCode, string siteCode, string unitcode)
        {
            return collectionTouristUnit.Find(m => m.UnitCode == unitcode && m.TourOperatorId==touroperatorCode&& m.SiteCode==siteCode).FirstOrDefault();

        }
    }
}
