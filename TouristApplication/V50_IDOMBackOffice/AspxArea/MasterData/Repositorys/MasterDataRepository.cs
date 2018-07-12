using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.MasterData.Models;
using V50_IDOMBackOffice.PlugIn.Controller;
using IdomOffice.Interface.BackOffice.MasterData;

namespace V50_IDOMBackOffice.AspxArea.MasterData.Repositorys
{
    public class MasterDataRepository
    {
        public static List<RegionViewModel> GetRegionViewModel()
        {
           // var data = new List<Region>();
            var model = new List<RegionViewModel>();

            var manager = PlugInManager.GetMasterDataManager();

            var data = manager.GetRegions();

            foreach (var region in data)
            {
                RegionViewModel m = new RegionViewModel();
                m.Id = region.Id;
                m.CountryId = region.CountryId;
                m.RegionId = region.RegionId;
                m.RegionName = region.RegionName;
                m.ImageGalleryPath = region.ImageGalleryPath;
                m.ImageThumbnailsPath = region.ImageThumbnailsPath;

                model.Add(m);
            }

            return model;
        }

        public static void AddMasterData(TouristSiteViewModel model)
        {
            var manager = PlugInManager.GetMasterDataManager();
            TouristSite touristsite = new TouristSite();
            touristsite.id = Guid.NewGuid().ToString();
            touristsite.CountryId = model.CountryId;
            touristsite.PlaceId = model.PlaceId;
            touristsite.RegionId = model.RegionId;
            touristsite.SiteCode = model.SiteCode;
            touristsite.SiteName = model.SiteName;
            touristsite.Stars = model.Stars;
            touristsite.Description = model.Description;
            touristsite.ImageGalleryPath = model.ImageGalleryPath;
            touristsite.ImageThumbnailsPath = model.ImageThumbnailsPath;
            touristsite.Latitude = model.Latitude;
            touristsite.Longitude = model.Longitude;

            manager.AddMasterData(touristsite);
        }

        public static List<CountryViewModel> GetCountryViewModel()
        {
            var data = new List<Country>();
            var model = new List<CountryViewModel>();

            var manager = PlugInManager.GetMasterDataManager();

            data = manager.GetCountries();

            foreach (var country in data)
            {
                var m = new CountryViewModel();
                m.Id = country.Id;
                m.CountryId = country.CountryId;
                m.CountryName = country.CountryName;
                m.ImageGalleryPath = country.ImageGalleryPath;
                m.ImageThumbnailsPath = country.ImageThumbnailsPath;

                model.Add(m);
            }


            return model;
        }

        public static List<PlaceViewModel> GetPlaceViewModel()
        {
            var data = new List<Place>();
            var model = new List<PlaceViewModel>();

            var manager = PlugInManager.GetMasterDataManager();

            data = manager.GetPlaces();

            foreach(var place in data)
            {
                PlaceViewModel m = new PlaceViewModel();
                m.Id = place.Id;
                m.PlaceId = place.PlaceId;
                m.RegionId = place.RegionId;
                m.PlaceName = place.PlaceName;
                m.ImageGalleryPath = place.ImageGalleryPath;
                m.ImageThumbnailsPath = place.ImageThumbnailsPath;

                model.Add(m);
            }
           
            return model;
        }

        public static List<TouristSiteViewModel> GetTouristSiteViewModel()
        {
            var data = new List<TouristSite>();
            var model = new List<TouristSiteViewModel>();
            var manager = PlugInManager.GetMasterDataManager();

            data = manager.GetTouristSites();

            foreach(var TouristSite in data)
            {
                var m = new TouristSiteViewModel();
                m.id = TouristSite.id;
                m.CountryId = TouristSite.CountryId;
                m.PlaceId = TouristSite.PlaceId;
                m.RegionId = TouristSite.RegionId;
                m.SiteCode = TouristSite.SiteCode;
                m.SiteName = TouristSite.SiteName;
                m.Stars = TouristSite.Stars;
                m.ImageGalleryPath = TouristSite.ImageGalleryPath;
                m.ImageThumbnailsPath = TouristSite.ImageThumbnailsPath;
                m.Description = TouristSite.Description;
                m.Longitude = TouristSite.Longitude;
                m.Latitude = TouristSite.Latitude;
                model.Add(m);
            }

 
            return model;
        }

      

        

     /*   public List<TouristOfferViewModel> GetTouristOfferViewModel()
        {

            List<TouristUnitViewModel> tourists = GetTouristUnitViewModel();
            List<TouristOfferViewModel> model = new List<TouristOfferViewModel>();
            foreach (var tourist in tourists)
            {
                var touristoffer = new TouristOfferViewModel();
                List<UnitOfferViewModel> offers = GetUnitOfferViewModel().FindAll(m => m.UnitCode == tourist.UnitCode);
                foreach (var offer in offers)
                {
                    touristoffer.UnitOfferId = offer.id;
                    touristoffer.TourOperatorCode = offer.TourOperatorCode;
                    touristoffer.SiteCode = offer.SiteCode;
                    touristoffer.OfferCode = offer.OfferCode;
                    touristoffer.OfferTitel = offer.OfferTitel;
                    touristoffer.OfferDescription = offer.OfferDescription;
                    touristoffer.OfferCount = offer.OfferCount;
                    touristoffer.UnitCode = offer.UnitCode;
                    touristoffer.IsAutoStopBooking = offer.IsAutoStopBooking;
                    touristoffer.ProviderNotice = offer.ProviderNotice;
                    touristoffer.TouristUnitId = tourist.id;
                    touristoffer.CountryName = tourist.CountryName;
                    touristoffer.RegionName = tourist.RegionName;
                    touristoffer.PlaceName = tourist.PlaceName;
                    touristoffer.UnitTitel = tourist.UnitTitel;
                    touristoffer.TravelServiceProvider = tourist.TravelServiceProvider;
                    touristoffer.SiteName = tourist.SiteName;
                    touristoffer.MobilhomeArea = tourist.MobilhomeArea;
                    touristoffer.TerraceArea = tourist.TerraceArea;
                    touristoffer.Bedroom = tourist.Bedroom;
                    touristoffer.Bathrooms = tourist.Bathrooms;
                    touristoffer.Beds = tourist.Beds;
                    touristoffer.ImageGalleryPath = tourist.ImageGalleryPath;
                    touristoffer.ImageThumbnailsPath = tourist.ImageThumbnailsPath;
                    touristoffer.MaxPersons = tourist.MaxPersons;
                    touristoffer.MaxAdults = tourist.MaxAdults;
                    touristoffer.OpenDate = tourist.OpenDate;
                    touristoffer.CloseDate = tourist.CloseDate;
                    touristoffer.PurchasePriceListId = tourist.PurchasePriceListId;
                }
                model.Add(touristoffer);
            }
            return model;         
        }

        public static void UpdateMasterData(TouristOfferViewModel model)
        {
            TouristUnitViewModel touristmodel = new TouristUnitViewModel();
            touristmodel = GetTouristUnitFromModel(model);
            UnitOfferViewModel offermodel = new UnitOfferViewModel();
            offermodel = GetUnitOfferFromModel(model);

            UpdateMasterData(touristmodel);
            UpdateMasterData(offermodel);
        }

       public static TouristUnitViewModel GetTouristUnitFromModel(TouristOfferViewModel model)
        {
            TouristUnitViewModel data = new TouristUnitViewModel();
            data.id = model.TouristUnitId;
            data.Bathrooms = model.Bathrooms;
            data.Bedroom = model.Bedroom;
            data.Beds = model.Beds;
            data.CloseDate = model.CloseDate;
            data.CountryName = model.CountryName;
            data.ImageGalleryPath = model.ImageGalleryPath;
            data.ImageThumbnailsPath = model.ImageThumbnailsPath;
            data.MaxAdults = model.MaxAdults;
            data.MaxPersons = model.MaxPersons;
            data.MobilhomeArea = model.MobilhomeArea;
            data.OpenDate = model.OpenDate;
            data.PlaceName = model.PlaceName;
            data.PurchasePriceListId = model.PurchasePriceListId;
            data.RegionName = model.RegionName;
            data.SiteCode = model.SiteCode;
            data.SiteName = model.SiteName;
            data.TerraceArea = model.TerraceArea;
            data.TourOperatorCode = model.TourOperatorCode;
            data.TravelServiceProvider = model.TravelServiceProvider;
            data.UnitCode = model.UnitCode;
            data.UnitTitel = model.UnitTitel;

            return data;

        }*/

        public static UnitOfferViewModel GetUnitOfferFromModel(TouristOfferViewModel model)
        {
            UnitOfferViewModel data = new UnitOfferViewModel();
            data.id = model.UnitOfferId;
            data.IsAutoStopBooking = model.IsAutoStopBooking;
            data.OfferCode = model.OfferCode;
            data.OfferCount = model.OfferCount;
            data.OfferDescription = model.OfferDescription;
            data.OfferTitel = model.OfferTitel;
            data.ProviderNotice = model.ProviderNotice;
            data.SiteCode = model.SiteCode;
            data.TourOperatorCode = model.TourOperatorCode;
            data.UnitCode = model.UnitCode;

            return data;
        }

        public static void AddMasterData(CountryViewModel model)
        {
            var manager = PlugInManager.GetMasterDataManager();
            var country = new IdomOffice.Interface.BackOffice.MasterData.Country();
            country.Id = Guid.NewGuid().ToString();
            country.CountryId = model.CountryId;
            country.ImageGalleryPath = model.ImageGalleryPath;
            country.ImageThumbnailsPath = model.ImageThumbnailsPath;
            country.CountryName = model.CountryName;
            
            manager.AddMasterData(country);
        }

        public static void AddMasterData(TouristUnitViewModel model)
        {
            var manager = PlugInManager.GetMasterDataManager();
            var touristunit = new IdomOffice.Interface.BackOffice.MasterData.TouristUnit();
            touristunit.id = Guid.NewGuid().ToString();
            touristunit.Bathrooms = model.Bathrooms;
            touristunit.Bedroom = model.Bedroom;
            touristunit.SiteCode = model.SiteCode;
            touristunit.SiteName = model.SiteName;
            //touristunit.Beds = model.Beds;
            touristunit.ImageGalleryPath = model.ImageGalleryPath;
            touristunit.ImageThumbnailsPath = model.ImageThumbnailsPath;
            touristunit.CloseDate = model.CloseDate;
            touristunit.CountryName = model.CountryName;
            touristunit.MaxAdults = model.MaxAdults;
            touristunit.MaxPersons = model.MaxPersons;
            touristunit.MobilhomeArea = model.MobilhomeArea;
            touristunit.OpenDate = model.OpenDate;
            touristunit.PlaceName = model.PlaceName;
            touristunit.PurchasePriceListId = model.PurchasePriceListId;
            touristunit.RegionName = model.RegionName;
            touristunit.TerraceArea = model.TerraceArea;
            touristunit.TourOperatorCode = model.TourOperatorCode;
            touristunit.TravelServiceProvider = model.TravelServiceProvider;
            touristunit.UnitCode = model.UnitCode;
            touristunit.UnitOfferInfoList = model.UnitOfferInfoList;
            touristunit.UnitTitel = model.UnitTitel;

            manager.AddMasterData(touristunit);
        }

        public static void AddMasterData(UnitOfferViewModel model)
        {
            var manager = PlugInManager.GetMasterDataManager();
            var unitoffer = new  IdomOffice.Interface.BackOffice.MasterData.UnitOffer();
            unitoffer.id = Guid.NewGuid().ToString();
            unitoffer.IsAutoStopBooking = model.IsAutoStopBooking;
            unitoffer.OfferCode = model.OfferCode;
            unitoffer.SiteCode = model.SiteCode;
            unitoffer.OfferCount = model.OfferCount;
            unitoffer.OfferDescription = model.OfferDescription;
            unitoffer.OfferDescriptionTranslate = model.OfferDescriptionTranslate;
            unitoffer.OfferTitel = model.OfferTitel;
            unitoffer.OfferTitelTranslate = model.OfferTitelTranslate;
            unitoffer.ProviderNotice = model.ProviderNotice;
            unitoffer.TourOperatorCode = model.TourOperatorCode;
            unitoffer.UnitCode = model.UnitCode;

            manager.AddMasterData(unitoffer);
        }


        public static void AddMasterData(RegionViewModel model)
        {
            var manager = PlugInManager.GetMasterDataManager();
            var region = new Region();
            region.Id = Guid.NewGuid().ToString(); ;
            region.CountryId = model.CountryId;
            region.RegionId = model.RegionId;
            region.RegionName = model.RegionName;
            region.ImageGalleryPath = model.ImageGalleryPath;
            region.ImageThumbnailsPath = model.ImageThumbnailsPath;

            manager.AddMasterData(region);
        }

        public static void AddMasterData(PlaceViewModel model)
        {
            var manager = PlugInManager.GetMasterDataManager();
            var place = new Place();
            place.Id = Guid.NewGuid().ToString();
            place.PlaceId = model.PlaceId;
            place.RegionId = model.RegionId;
            place.PlaceName = model.PlaceName;
            place.ImageGalleryPath = model.ImageGalleryPath;
            place.ImageThumbnailsPath = model.ImageThumbnailsPath;

            manager.AddMasterData(place);

        }

        public static void AddMasterData(BackOfficeContactViewModel model)
        {
            var manager = PlugInManager.GetMasterDataManager();
            var contact = new BackOfficeContact();


            contact.Id = Guid.NewGuid().ToString();
            contact.Address = model.Address;
            contact.City = model.City;
            contact.CompanyName = model.CompanyName;
            contact.Country = model.Country;
            contact.Email = model.Email;
            contact.FirstName = model.FirstName;
            contact.LastName = model.LastName;

            manager.AddMasterData(contact);

        }

        public static List<BackOfficeContactViewModel> GetBackOfficeContactViewModel()
        {
            
            var model = new List<BackOfficeContactViewModel>();

            var manager = PlugInManager.GetMasterDataManager();

            var data = manager.GetBackOfficeContacts();

            foreach (var contact in data)
            {
                BackOfficeContactViewModel m = new BackOfficeContactViewModel();
                m.Id = contact.Id;
                m.Address = contact.Address;
                m.City = contact.City;
                m.CompanyName = contact.CompanyName;
                m.Country = contact.Country;
                m.Email = contact.Email;
                m.FirstName = contact.FirstName;
                m.LastName = contact.LastName;

                model.Add(m);
            }

            return model;
        }

        public static void UpdateMasterData(RegionViewModel model)
        {
            var manager = PlugInManager.GetMasterDataManager();
            var region = manager.GetRegion(model.Id);

            region.CountryId = model.CountryId;
            region.RegionId = model.RegionId;
            region.RegionName = model.RegionName;
            region.ImageGalleryPath = model.ImageGalleryPath;
            region.ImageThumbnailsPath = model.ImageThumbnailsPath;

            manager.UpdateMasterData(region);
       
        }

        public static void UpdateMasterData(CountryViewModel model)
        {
            var manager = PlugInManager.GetMasterDataManager();
            var country = manager.GetCountry(model.Id);

            country.CountryId = model.CountryId;
            country.ImageGalleryPath = model.ImageGalleryPath;
            country.ImageThumbnailsPath = model.ImageThumbnailsPath;
            country.CountryName = model.CountryName;

            manager.UpdateMasterData(country);
        }

        public static void UpdateMasterData(PlaceViewModel model)
        {
            var manager = PlugInManager.GetMasterDataManager();
            var place = manager.GetPlace(model.Id);
            
            place.PlaceId = model.PlaceId;
            place.RegionId = model.RegionId;
            place.PlaceName = model.PlaceName;
            place.ImageGalleryPath = model.ImageGalleryPath;
            place.ImageThumbnailsPath = model.ImageThumbnailsPath;

            manager.UpdateMasterData(place);
        }
        public static void UpdateMasterData(TouristSiteViewModel model)
        {
            var manager = PlugInManager.GetMasterDataManager();
            var touristsite = manager.GetTouristSite(model.id);

            touristsite.CountryId = model.CountryId;
            touristsite.PlaceId = model.PlaceId;
            touristsite.RegionId = model.RegionId;
            touristsite.SiteCode = model.SiteCode;
            touristsite.SiteName = model.SiteName;
            touristsite.Stars = model.Stars;
            touristsite.Description = model.Description;
            touristsite.ImageGalleryPath = model.ImageGalleryPath;
            touristsite.ImageThumbnailsPath = model.ImageThumbnailsPath;
            touristsite.Latitude = model.Latitude;
            touristsite.Longitude = model.Longitude;

            manager.UpdateMasterData(touristsite);
             
        }

        public static void UpdateMasterData(TouristUnitViewModel model)
        {
            var manager = PlugInManager.GetMasterDataManager();
            var touristunit = manager.GetTouristUnitById(model.id);

            touristunit.Bathrooms = model.Bathrooms;
            touristunit.Bedroom = model.Bedroom;
            touristunit.SiteCode = model.SiteCode;
            touristunit.SiteName = model.SiteName;
            //touristunit.Beds = model.Beds;
            touristunit.ImageGalleryPath = model.ImageGalleryPath;
            touristunit.ImageThumbnailsPath = model.ImageThumbnailsPath;
            touristunit.CloseDate = model.CloseDate;
            touristunit.CountryName = model.CountryName;
            touristunit.MaxAdults = model.MaxAdults;
            touristunit.MaxPersons = model.MaxPersons;
            touristunit.MobilhomeArea = model.MobilhomeArea;
            touristunit.OpenDate = model.OpenDate;
            touristunit.PlaceName = model.PlaceName;
            touristunit.PurchasePriceListId = model.PurchasePriceListId;
            touristunit.RegionName = model.RegionName;
            touristunit.TerraceArea = model.TerraceArea;
            touristunit.TourOperatorCode = model.TourOperatorCode;
            touristunit.TravelServiceProvider = model.TravelServiceProvider;
            touristunit.UnitCode = model.UnitCode;
            touristunit.UnitOfferInfoList = model.UnitOfferInfoList;
            touristunit.UnitTitel = model.UnitTitel;

            touristunit.Kettle = model.Kettle;
           // touristunit.LocationSea = model.LocationSea;
          //  touristunit.LocationSite = model.LocationSite;
            touristunit.MobilehomeSize = model.MobilehomeSize;
            touristunit.OtherFeatures = model.OtherFeatures;
            touristunit.ParcelSize = model.ParcelSize;
            touristunit.Pets = model.Pets;
            touristunit.PriceInclusive = model.PriceInclusive;
            touristunit.ShortDescription = model.ShortDescription;
            touristunit.SingleBeds = model.SingleBeds;
            touristunit.SolarShower = model.SolarShower;
            touristunit.Sunloungers = model.Sunloungers;
            touristunit.Sunshade = model.Sunshade;
            touristunit.TerraceSize = model.TerraceSize;
            //touristunit.TerraceType = model.TerraceType;
            touristunit.TourOperatorId = model.TourOperatorId;
            touristunit.TravelServiceProvider = model.TravelServiceProvider;
            touristunit.UnitType = model.UnitType;
            touristunit.WC = model.WC;
            touristunit.WoodenFurniture = model.WoodenFurniture;
            touristunit.AirConditioning = model.AirConditioning;
            touristunit.BeachDistanceFrom = model.BeachDistanceFrom;
            touristunit.BeachDistanceTo = model.BeachDistanceTo;
            touristunit.Bedrooms = model.Bedrooms;
            touristunit.BunkBeds = model.BunkBeds;
            touristunit.Disabled = model.Disabled;
            touristunit.DoubleBeds = model.DoubleBeds;
            touristunit.ExtraBeds = model.ExtraBeds;
            touristunit.ExtraEquipment = model.ExtraEquipment;
            touristunit.Description = model.Description;

            touristunit.Coffeemachine = model.Coffeemachine;
            touristunit.Fridge = model.Fridge;
            touristunit.Childbed = model.Childbed;
            touristunit.DVDPlayer = model.DVDPlayer;
            touristunit.Towel = model.Towel;
            touristunit.BedWashing = model.BedWashing;
            touristunit.Parkinglot = model.Parkinglot;
            touristunit.FinishCleaning = model.FinishCleaning;
            touristunit.WiFiInternetPriceFree = model.WiFiInternetPriceFree;
            touristunit.WiFiInternet = model.WiFiInternet;
            touristunit.Pool = model.Pool;
            touristunit.UnitStopBooking = model.UnitStopBooking;
            touristunit.LastChange = model.LastChange;

            manager.UpdateMasterData(touristunit);

        }

        public static void UpdateMasterData(UnitOfferViewModel model)
        {
            var manager = PlugInManager.GetMasterDataManager();
            var unitoffer = manager.GetUnitOffer(model.id);

            unitoffer.IsAutoStopBooking = model.IsAutoStopBooking;
            unitoffer.OfferCode = model.OfferCode;
            unitoffer.SiteCode = model.SiteCode;
            unitoffer.OfferCount = model.OfferCount;
            unitoffer.OfferDescription = model.OfferDescription;
            unitoffer.OfferDescriptionTranslate = model.OfferDescriptionTranslate;
            unitoffer.OfferTitel = model.OfferTitel;
            unitoffer.OfferTitelTranslate = model.OfferTitelTranslate;
            unitoffer.ProviderNotice = model.ProviderNotice;
            unitoffer.TourOperatorCode = model.TourOperatorCode;
            unitoffer.UnitCode = model.UnitCode;

            manager.UpdateMasterData(unitoffer);
        }

        public static void UpdateMasterData(BackOfficeContactViewModel model)
        {
            var manager = PlugInManager.GetMasterDataManager();
            var contact = manager.GetBackOfficeContact(model.Id);

            contact.Address = model.Address;
            contact.City = model.City;
            contact.CompanyName = model.CompanyName;
            contact.Country = model.Country;
            contact.Email = model.Email;
            contact.FirstName = model.FirstName;
            contact.LastName = model.LastName;

            manager.UpdateMasterData(contact);

        }

        public static void DeleteRegion(string id)
        {
            var manager = PlugInManager.GetMasterDataManager();
            manager.DeleteRegion(id);
        }

      
        public static void DeleteCountry(string id)
        {
            var manager = PlugInManager.GetMasterDataManager();
            manager.DeleteCountry(id);
        }
        public static void DeletePlace(string id)
        {
            var manager = PlugInManager.GetMasterDataManager();
            manager.DeletePlace(id);
        }
        public static void DeleteTouristSite(string id)
        {
            var manager = PlugInManager.GetMasterDataManager();
            manager.DeleteTouristSite(id);
        }

        public static void DeleteTouristUnit(string id)
        {
            var manager = PlugInManager.GetMasterDataManager();
            manager.DeleteTouristUnit(id);
        }

        public static void DeleteBackOfficeContact(string id)
        {
            var manager = PlugInManager.GetMasterDataManager();
            manager.DeleteBackOfficeContact(id);
        }

        public static void DeleteUnitOffer(string id)
        {
            var manager = PlugInManager.GetMasterDataManager();
            manager.DeleteUnitOffer(id);
        }

 

        public static bool UnitOfferContainsCode(string offercode)
        {
            var manager = PlugInManager.GetMasterDataManager();
            var unitoffer = manager.GetUnitOfferByCode(offercode);
            if (unitoffer != null)
                return true;

            return false;
        }

 

        public static LayoutInfoViewModel GetLayoutInfoModel(TouristUnitViewModel model)
        {
            LayoutInfoViewModel data = new LayoutInfoViewModel();
            data.AirConditioning = model.AirConditioning;
            data.Bathrooms = model.Bathrooms;
            data.BeachDistanceFrom = model.BeachDistanceTo;
            data.Bedrooms = model.Bedrooms;
            data.BunkBeds = model.BunkBeds;
            data.Disabled = model.Disabled;
            data.DoubleBeds = model.DoubleBeds;
            data.ExtraBeds = model.ExtraBeds;
            data.ExtraEquipment = model.ExtraEquipment;
            data.Kettle = model.Kettle;
            data.LocationSea = model.LocationSea;
            data.LocationSite = model.LocationSite;
            data.MobilehomeSize = model.MobilehomeSize;
            data.OtherFeatures = model.OtherFeatures;
            data.ParcelSize = model.ParcelSize;
            data.PriceInclusive = model.PriceInclusive;
            data.SingleBeds = model.SingleBeds;
            data.SolarShower = model.SolarShower;
            data.Sunloungers = model.Sunloungers;
            data.Sunshade = model.Sunshade;
            data.TerraceSize = model.TerraceSize;
            data.TerraceType = model.TerraceType;
            data.UnitType = model.UnitType;
            data.WC = model.WC;
            data.WoodenFurniture = model.WoodenFurniture;


            data.Coffeemachine = model.Coffeemachine;
            data.Fridge = model.Fridge;
            data.Childbed = model.Childbed;
            data.DVDPlayer = model.DVDPlayer;
            data.Towel = model.Towel;
            data.BedWashing = model.BedWashing;
            data.Parkinglot = model.Parkinglot;
            data.FinishCleaning = model.FinishCleaning;
            data.WiFiInternetPriceFree = model.WiFiInternetPriceFree;
            data.WiFiInternet = model.WiFiInternet;
            data.Pool = model.Pool;


            return data;
        }

        public static LayoutDatenViewModel GetLayoutDatenModel(TouristUnitViewModel model)
        {
            LayoutDatenViewModel data = new LayoutDatenViewModel();
            data.CloseDate = model.CloseDate;
            data.MaxAdults = model.MaxAdults;
            data.MaxPersons = model.MaxPersons;
            data.OpenDate = model.OpenDate;

            return data;
        }

        public static int GetTerraceType(TouristUnitViewModel model)
        {
            string terracetype = model.TerraceType;
            int index = 0;

            if(terracetype=="Typ 1")
            {
                index = 0;
            }
            else if(terracetype=="Typ 2")
            {
                index = 1;
            }

            return index;
        }

        public static int GetSiteLocation(TouristUnitViewModel model)
        {
            string sitelocation = model.LocationSite;
            int index = 0;

            if(sitelocation=="Standort 1")
            {
                index = 0;
            }
            else if(sitelocation=="Standort 2")
            {
                index = 1;
            }

            return index;
        }

        public static int GetSeaLocation(TouristUnitViewModel model)
        {
            string sealocation = model.LocationSea;
            int index = 0;

            if (sealocation == "Lage 1")
            {
                index = 0;
            }
            else if (sealocation == "Lage 2")
            {
                index = 1;
            }

            return index;
        }

        public static int GetPet(TouristUnitViewModel model)
        {
            int pets = model.Pets;

            int index = 0;

            if (pets == 0)
            {
                index = 0;
            }
            else if (pets == 6)
            {
                index = 1;
            }
            else if(pets==30)
            {
                index = 2;
            }
            else if(pets==99)
            {
                index = 3;
            }

            return index;
        }

     

        public static List<Data> GetRegionSource()
        {
            List<Data> regions = new List<Data>();

            var list = GetRegionViewModel();

            foreach (var item in list)
            {
                Data region = new Data(item.RegionId.ToString(), item.RegionName);
                regions.Add(region);
            }

            regions = regions.Distinct().ToList();

            return regions;
        }

        public static List<Data> GetCountrySource()
        {
            List<Data> countries = new List<Data>();

            var list = GetCountryViewModel();

            foreach(var item in list)
            {
                Data country = new Data(item.CountryId.ToString(), item.CountryName);
                countries.Add(country);
            }

            countries = countries.Distinct().ToList();

            return countries;
        }

        public static List<Data> GetPlaceSource()
        {
            List<Data> places = new List<Data>();

            var list = GetPlaceViewModel();

            foreach (var item in list)
            {
                Data place = new Data(item.PlaceId.ToString(), item.PlaceName);
                places.Add(place);
            }

            places = places.Distinct().ToList();

            return places;
        }

       

        public static List<string> GetSiteCodes()
        {
            List<string> sites = new List<string>();

            List<TouristSiteViewModel> list = GetTouristSiteViewModel();

            sites = list.Where(m => m.SiteCode != null).Select(m => m.SiteCode).Distinct().ToList();

            return sites;
        }

      



        public static string GetCountry(int countryid)
        {
            if (countryid == 0)
                return "Kroatien";
            var countries = GetCountryViewModel();
            var country = countries.Find(m => m.CountryId == countryid);
            string name = country.CountryName;

            return name;
        }

        public static string GetCountryFromSite(string sitecode)
        {
            var sites = GetTouristSiteViewModel();
            var site = sites.Find(m => m.SiteCode == sitecode);
            int countryid = site.CountryId;

            string countryname = GetCountry(countryid);

            return countryname;
            
        }

        public static string GetRegion(int regionid)
        {
            var regions = GetRegionViewModel();
            var region = regions.Find(m => m.RegionId == regionid);
            string name = region.RegionName;

            return name;
        }

        public static string GetRegionFromSite(string sitecode)
        {
            var sites = GetTouristSiteViewModel();
            var site = sites.Find(m => m.SiteCode == sitecode);
            int regionid = site.RegionId;

            string regionname = GetRegion(regionid);

            return regionname;
        }

        public static string GetPlace(int placeid)
        {
            var places = GetPlaceViewModel();
            var place = places.Find(m => m.PlaceId == placeid);
            if (place == null)
                return String.Empty;

            string name = place.PlaceName;

            return name;
        }


        public static string GetPlaceFromSite(string sitecode)
        {
            var sites = GetTouristSiteViewModel();
            var site = sites.Find(m => m.SiteCode == sitecode);
            int placeid = site.PlaceId;

            string placename = GetPlace(placeid);

            return placename;
        }

        public static string GetSiteNameFromSite(string sitecode)
        {
            var sites = GetTouristSiteViewModel();
            var site = sites.Find(m => m.SiteCode == sitecode);
            string sitename = site.SiteName;

            return sitename;
        }

        public static TouristUnitViewModel GetTouristUnit(TouristUnitViewModel model)
        {
            TouristUnitViewModel unit = new TouristUnitViewModel();
            unit = model;
            string sitecode = model.SiteCode;
            string country = GetCountryFromSite(sitecode);
            string region = GetRegionFromSite(sitecode);
            string place = GetPlaceFromSite(sitecode);
            string sitename = GetSiteNameFromSite(sitecode);

            unit.CountryName = country;
            unit.RegionName = region;
            unit.PlaceName = place;
            unit.SiteName = sitename;

            return unit;
        }

        public static List<Data> GetDataSiteCodes()
        {
            List<Data> list = new List<Data>();
            var manager = PlugInManager.GetMasterDataManager();
            var sites = manager.GetTouristSites();
            int number = 0;

            foreach (var site in sites)
            {
                Data dt = new Data(number.ToString(), site.SiteCode);
                number++;
                list.Add(dt);
            }

            return list;
        }

        public static List<Data> GetDataUnitCodes(string sitecode)
        {
            List<Data> list = new List<Data>();
            int number = 0;
            var manager = PlugInManager.GetMasterDataManager();
            var unitcodes = manager.GetTouristUnitsBySite(sitecode);

            foreach (var unit in unitcodes)
            {
                Data dt = new Data(number.ToString(), unit.UnitCode);
                number++;
                list.Add(dt);
            }
            return list;
        }
        public static List<Data> GetDataOfferCodes(string sitecode,string unitcode)
        {
            List<Data> list = new List<Data>();
            int number = 0;
            var manager = PlugInManager.GetMasterDataManager();
            var offercodes = manager.GetUnitOffer(sitecode,unitcode);

            foreach (var offer in offercodes)
            {
                Data dt = new Data(number.ToString(), offer.OfferCode);
                number++;
                list.Add(dt);
            }
            return list;
        }

        public static List<Data> GetDataOfferCodes(string sitecode)
        {
            List<Data> list = new List<Data>();
            int number = 0;
            var manager = PlugInManager.GetMasterDataManager();
            var offercodes = manager.GetUnitOffers(sitecode);

            foreach (var offer in offercodes)
            {
                Data dt = new Data(number.ToString(), offer.OfferCode);
                number++;
                list.Add(dt);
            }
            return list;
        }

        public static string GetSiteName(string sitecode)
        {
            string name;
            var manager = PlugInManager.GetMasterDataManager();
            var site = manager.GetTouristSiteForCode(sitecode);
            name = site.SiteName;
            return name;
        }

        public static string GetUnitName(string unitcode)
        {
            string name;
            var manager = PlugInManager.GetMasterDataManager();
            var unit = manager.GetTouristUnitByUnitCode(unitcode);
            name = unit.UnitTitel;

            return name;
        }

        public static string GetOfferName(string offercode)
        {
            string name;
            var manager = PlugInManager.GetMasterDataManager();
            var offer = manager.GetUnitOfferByCode(offercode);
            name = offer.OfferTitel;

            return name;
        }

        public static void Method()
        {

        }
    }

}