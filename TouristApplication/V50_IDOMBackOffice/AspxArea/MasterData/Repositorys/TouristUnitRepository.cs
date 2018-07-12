using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdomOffice.Interface.BackOffice.MasterData;
using V50_IDOMBackOffice.PlugIn.Controller;
using V50_IDOMBackOffice.AspxArea.MasterData.Models;

namespace V50_IDOMBackOffice.AspxArea.MasterData.Repositorys
{
    public class TouristUnitRepository
    {
        // nadji tuurist Unit za odredjenog Site i UnitCode
        public static TouristUnit GetTouristUnit(string siteCode, string unitCode)
        {
            var manager = PlugInManager.GetMasterDataManager();
            return manager.GetTouristUnit(siteCode, unitCode);
        }
        public static List<string> GetOfferCodes()
        {
            List<string> offers = new List<string>();

            List<UnitOfferViewModel> list = GetUnitOfferViewModel();

            offers = list.Where(m => m.OfferCode != null).Select(m => m.OfferCode).Distinct().ToList();

            return offers;
        }

        public static List<UnitOfferViewModel> GetUnitOfferByCode(string sitecode, string unitcode)
        {
            var offers = GetUnitOfferViewModel().FindAll(m => m.SiteCode == sitecode && m.UnitCode == unitcode);
            return offers;
        }

        public static List<Data> GetDataOfferCodes()
        {
            var list = GetOfferCodes();
            List<Data> offersdata = new List<Data>();
            int number = 0;

            foreach (var item in list)
            {
                Data code = new Data(number.ToString(), item);
                number++;
                offersdata.Add(code);
            }
            return offersdata;
        }

        public static bool TouristUnitContainsCode(string unitcode)
        {
            var manager = PlugInManager.GetMasterDataManager();
            var touristunit = manager.GetTouristUnitByUnitCode(unitcode);
            if (touristunit != null)
                return true;

            return false;
        }

        public static TouristUnitViewModel GetTouristUnitById(string id)
        {
            var touristunit = GetTouristUnitViewModel().Find(m => m.id == id);
            return touristunit;
        }
        public static List<TouristUnitViewModel> GetTouristUnitViewModel()
        {

            var model = new List<TouristUnitViewModel>();
            var manager = PlugInManager.GetMasterDataManager();

            var data = manager.GetTouristUnits();

            foreach (var TouristUnit in data)
            {
                var m = new TouristUnitViewModel();
                m.id = TouristUnit.id;
                m.Bathrooms = TouristUnit.Bathrooms;
                m.Bedroom = TouristUnit.Bedroom;
                m.SiteCode = TouristUnit.SiteCode;
                m.SiteName = TouristUnit.SiteName;
                //m.Beds = TouristUnit.Beds;
                m.ImageGalleryPath = TouristUnit.ImageGalleryPath;
                m.ImageThumbnailsPath = TouristUnit.ImageThumbnailsPath;
                m.CloseDate = TouristUnit.CloseDate;
                m.CountryName = TouristUnit.CountryName;
                m.MaxAdults = TouristUnit.MaxAdults;
                m.MaxPersons = TouristUnit.MaxPersons;
                m.MobilhomeArea = TouristUnit.MobilhomeArea;
                m.OpenDate = TouristUnit.OpenDate;
                m.PlaceName = TouristUnit.PlaceName;
                m.PurchasePriceListId = TouristUnit.PurchasePriceListId;
                m.RegionName = TouristUnit.RegionName;
                m.TerraceArea = TouristUnit.TerraceArea;
                m.TourOperatorCode = TouristUnit.TourOperatorCode;
                m.TravelServiceProvider = TouristUnit.TravelServiceProvider;
                m.UnitCode = TouristUnit.UnitCode;
                m.UnitOfferInfoList = TouristUnit.UnitOfferInfoList;
                m.UnitTitel = TouristUnit.UnitTitel;
                m.Kettle = TouristUnit.Kettle;
                m.LocationSea = TouristUnit.LocationSea;
                m.LocationSite = TouristUnit.LocationSite;
                m.MobilehomeSize = TouristUnit.MobilehomeSize;
                m.OtherFeatures = TouristUnit.OtherFeatures;
                m.ParcelSize = TouristUnit.ParcelSize;
                m.Pets = TouristUnit.Pets;
                m.PriceInclusive = TouristUnit.PriceInclusive;
                m.ShortDescription = TouristUnit.ShortDescription;
                m.SingleBeds = TouristUnit.SingleBeds;
                m.SolarShower = TouristUnit.SolarShower;
                m.Sunloungers = TouristUnit.Sunloungers;
                m.Sunshade = TouristUnit.Sunshade;
                m.TerraceSize = TouristUnit.TerraceSize;
                m.TerraceType = TouristUnit.TerraceType;
                m.TourOperatorId = TouristUnit.TourOperatorId;
                m.TravelServiceProvider = TouristUnit.TravelServiceProvider;
                m.UnitType = TouristUnit.UnitType;
                m.WC = TouristUnit.WC;
                m.WoodenFurniture = TouristUnit.WoodenFurniture;
                m.AirConditioning = TouristUnit.AirConditioning;
                m.BeachDistanceFrom = TouristUnit.BeachDistanceFrom;
                m.BeachDistanceTo = TouristUnit.BeachDistanceTo;
                m.Bedrooms = TouristUnit.Bedrooms;
                m.BunkBeds = TouristUnit.BunkBeds;
                m.Disabled = TouristUnit.Disabled;
                m.DoubleBeds = TouristUnit.DoubleBeds;
                m.ExtraBeds = TouristUnit.ExtraBeds;
                m.ExtraEquipment = TouristUnit.ExtraEquipment;
                m.Description = TouristUnit.Description;
                m.Coffeemachine = TouristUnit.Coffeemachine;
                m.Fridge = TouristUnit.Fridge;
                m.Childbed = TouristUnit.Childbed;
                m.DVDPlayer = TouristUnit.DVDPlayer;
                m.Towel = TouristUnit.Towel;
                m.BedWashing = TouristUnit.BedWashing;
                m.Parkinglot = TouristUnit.Parkinglot;
                m.FinishCleaning = TouristUnit.FinishCleaning;
                m.WiFiInternetPriceFree = TouristUnit.WiFiInternetPriceFree;
                m.WiFiInternet = TouristUnit.WiFiInternet;
                m.Pool = TouristUnit.Pool;
                m.UnitStopBooking = TouristUnit.UnitStopBooking;
                m.LastChange = TouristUnit.LastChange;

                model.Add(m);
            }


            return model;
        }
        public static string GetSiteCodeFromUnit(string unitcode)
        {
            var list = GetTouristUnitViewModel();
            var touristunit = list.Find(m => m.UnitCode == unitcode);
            string sitecode = touristunit.SiteCode;

            return sitecode;
        }
        public static List<string> GetUnitCodes()
        {
            List<string> units = new List<string>();

            List<TouristUnitViewModel> list = GetTouristUnitViewModel();

            units = list.Where(m => m.UnitCode != null).Select(m => m.UnitCode).Distinct().ToList();

            return units;
        }
        public static List<Data> GetDataUnitCodes()
        {
            var list = GetUnitCodes();
            List<Data> unitsdata = new List<Data>();
            int number = 0;

            foreach (var item in list)
            {
                Data code = new Data(number.ToString(), item);
                number++;
                unitsdata.Add(code);
            }
            return unitsdata;
        }
        public static List<UnitOfferViewModel> GetUnitOfferViewModel()
        {

            var model = new List<UnitOfferViewModel>();
            var manager = PlugInManager.GetMasterDataManager();

            var data = manager.GetUnitOffers();

            foreach (var UnitOffer in data)
            {
                var m = new UnitOfferViewModel();
                m.id = UnitOffer.id;
                m.IsAutoStopBooking = UnitOffer.IsAutoStopBooking;
                m.OfferCode = UnitOffer.OfferCode;
                m.SiteCode = UnitOffer.SiteCode;
                m.OfferCount = UnitOffer.OfferCount;
                m.OfferDescription = UnitOffer.OfferDescription;
                m.OfferDescriptionTranslate = UnitOffer.OfferDescriptionTranslate;
                m.OfferTitel = UnitOffer.OfferTitel;
                m.OfferTitelTranslate = UnitOffer.OfferTitelTranslate;
                m.ProviderNotice = UnitOffer.ProviderNotice;
                m.TourOperatorCode = UnitOffer.TourOperatorCode;
                m.UnitCode = UnitOffer.UnitCode;

                model.Add(m);
            }


            return model;
        }
    }
}