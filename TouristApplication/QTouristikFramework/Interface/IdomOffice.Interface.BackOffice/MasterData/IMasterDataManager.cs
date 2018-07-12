using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IdomOffice.Interface.BackOffice.MasterData
{
   

    public interface IMasterDataManager
    {
        void AddMasterData(Country document);
        void AddMasterData(Region document);
        void AddMasterData(Place document);
        void AddMasterData(TouristSite document);
        void AddMasterData(TouristUnit document);
        void AddMasterData(UnitOffer document);
        void AddMasterData(BackOfficeContact document);

        void UpdateMasterData(Country document);
        void UpdateMasterData(Region document);
        void UpdateMasterData(Place document);
        void UpdateMasterData(TouristSite document);
        void UpdateMasterData(TouristUnit document);
        void UpdateMasterData(UnitOffer document);
        void UpdateMasterData(BackOfficeContact document);

        Country GetCountry(int CountryId);
        Country GetCountry(string id);
        List<Country> GetCountries();
  
        Region GetRegion(string id);
        Region GetRegion(int regionid);
        List<Region> GetRegions(int country);
        List<Region> GetRegions();

        Place GetPlace(string id);
        Place GetPlace(int placeid);
        List<Place> GetPlaces(int region);
        List<Place> GetPlaces();
   
        TouristSite GetTouristSite(string id);
        TouristSite GetTouristSiteForCode(string code);
        List<TouristSite> GetTouristSitesForPlace(int place);
        List<TouristSite> GetTouristSitesForRegion(int region);
        List<TouristSite> GetTouristSites();

        TouristUnit GetTouristUnitById(string id);
        TouristUnit GetTouristUnitByUnitCode(string unitcode);
        TouristUnit GetTouristUnit(string siteCode, string unitcode);
        TouristUnit GetTouristUnit(string touroperatorCode, string siteCode, string unitcode);
        List<TouristUnit> GetTouristUnitsBySite(string siteCode);
        List<TouristUnit> GetTouristUnitsByOperator(string operatorId);
        List<TouristUnit> GetTouristUnits();

        UnitOffer GetUnitOffer(string TourOperatorCode, string site, string offerCode);
        UnitOffer GetUnitOffer(string id);
        UnitOffer GetUnitOfferByCode(string offerCode);
        List<UnitOffer> GetUnitOfferByTourOperator(string TourOperatorCode);
        List< UnitOffer> GetUnitOffers(string TourOperatorCode, string site);
        List<UnitOffer> GetUnitOffers(string site);
        List<UnitOffer> GetUnitOffers();

        List<BackOfficeContact> GetBackOfficeContacts();
        BackOfficeContact GetBackOfficeContact(string id);
        List<UnitOffer> GetUnitOffer(string sitecode, string unitcode);
        

        /// <summary>
        /// Delete document
        /// </summary>
        /// <param name="id"></param>
        void DeleteTouristUnit(string id);
        void DeleteCountry(string id);
        void DeleteRegion(string id);
        void DeletePlace(string id);
        void DeleteTouristSite(string id);
        void DeleteUnitOffer(string id);
        void DeleteBackOfficeContact(string id);

        GeoMasterDateInfo GetGeoMasterDateInfo(string TourOperatorCode, string TouristSiteCode, string UnitOfferCode);
    }
}
