using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTouristik.Interface.Sync;
using IdomOffice.Interface.BackOffice.MasterData;
using IdomOffice.Interface.BackOffice.PriceLists;
using IdomOffice.PlugIn.BackOffice.MasterData;
using IdomOffice.PlugIn.BackOffice.PriceLists;


namespace IdomOffice.PlugIn.BackOffice.Sync
{
    public class BackOfficeUtility
    {
        private static MasterDataManager manager = new MasterDataManager();
        private static PriceListManager datamanager = new PriceListManager();

        public static SyncOfferInfo GetOfferInfo(string tourOperatorId, string siteCode, string offerCode)
        {
            var unitoffer = manager.GetUnitOffer(tourOperatorId, siteCode, offerCode);
            SyncOfferInfo offer = new SyncOfferInfo();
            string unitcode = unitoffer.UnitCode;
            var touristunit = manager.GetTouristUnitByUnitCode(unitcode);
            offer.AirConditioning = touristunit.AirConditioning;
            offer.AllowedPets = true;
            offer.Bathrooms = touristunit.Bathrooms.ToString();
            offer.Bedroom = touristunit.Bedroom;
            offer.ExtraBeds = touristunit.ExtraBeds;
            offer.MaxAdults = touristunit.MaxAdults;
            offer.MaxPersons = touristunit.MaxPersons;
            offer.MobilhomeArea = touristunit.MobilhomeArea;
            offer.TerraceArea = touristunit.TerraceArea;
            offer.OfferCode = unitoffer.OfferCode;
            offer.OfferDescriptionHtml = unitoffer.OfferDescription;
            offer.OfferCount = unitoffer.OfferCount;
            offer.OfferTitel = unitoffer.OfferTitel;
            offer.ProviderNotice = unitoffer.ProviderNotice;
            offer.SiteCode = unitoffer.SiteCode;

            return offer;
            
        }

        public static List<SyncOfferInfo> GetOfferInfos(string tourOperatorId)
        {
            List<SyncOfferInfo> list = new List<SyncOfferInfo>();
            List<UnitOffer> offers = manager.GetUnitOfferByTourOperator(tourOperatorId);

            foreach(var unitoffer in offers)
            {
                SyncOfferInfo offer = new SyncOfferInfo();
                string unitcode = unitoffer.UnitCode;
                var touristunit = manager.GetTouristUnitByUnitCode(unitcode);
                offer.AirConditioning = touristunit.AirConditioning;
                offer.AllowedPets = true;
                offer.Bathrooms = touristunit.Bathrooms.ToString();
                offer.Bedroom = touristunit.Bedroom;
                offer.ExtraBeds = touristunit.ExtraBeds;
                offer.MaxAdults = touristunit.MaxAdults;
                offer.MaxPersons = touristunit.MaxPersons;
                offer.MobilhomeArea = touristunit.MobilhomeArea;
                offer.TerraceArea = touristunit.TerraceArea;
                offer.OfferCode = unitoffer.OfferCode;
                offer.OfferDescriptionHtml = unitoffer.OfferDescription;
                offer.OfferCount = unitoffer.OfferCount;
                offer.OfferTitel = unitoffer.OfferTitel;
                offer.ProviderNotice = unitoffer.ProviderNotice;
                offer.SiteCode = unitoffer.SiteCode;

                list.Add(offer);
            }
            return list;
        }

        public static List<SyncOfferInfo> GetOfferInfos(string tourOperatorId,string siteCode)
        {
            List<SyncOfferInfo> list = new List<SyncOfferInfo>();
            List<UnitOffer> offers = manager.GetUnitOffer(tourOperatorId,siteCode);

            foreach (var unitoffer in offers)
            {
                SyncOfferInfo offer = new SyncOfferInfo();
                string unitcode = unitoffer.UnitCode;
                var touristunit = manager.GetTouristUnitByUnitCode(unitcode);
                offer.AirConditioning = touristunit.AirConditioning;
                offer.AllowedPets = true;
                offer.Bathrooms = touristunit.Bathrooms.ToString();
                offer.Bedroom = touristunit.Bedroom;
                offer.ExtraBeds = touristunit.ExtraBeds;
                offer.MaxAdults = touristunit.MaxAdults;
                offer.MaxPersons = touristunit.MaxPersons;
                offer.MobilhomeArea = touristunit.MobilhomeArea;
                offer.TerraceArea = touristunit.TerraceArea;
                offer.OfferCode = unitoffer.OfferCode;
                offer.OfferDescriptionHtml = unitoffer.OfferDescription;
                offer.OfferCount = unitoffer.OfferCount;
                offer.OfferTitel = unitoffer.OfferTitel;
                offer.ProviderNotice = unitoffer.ProviderNotice;
                offer.SiteCode = unitoffer.SiteCode;

                list.Add(offer);
            }
            return list;
        }

        public static DateTime LastOfferInfoChange(string tourOperatorId, string siteCode, string offerCode)
        {
            var unitoffer = manager.GetUnitOffer(tourOperatorId, siteCode, offerCode);
            DateTime date = unitoffer.LastChange;

            return date;
        }

        public static DateTime LastPriceChange(string tourOperatorId, string siteCode, string offerCode)
        {
            List<PriceList> list = datamanager.GetPriceLists(tourOperatorId, siteCode, offerCode);

            DateTime date = list.Max(m => m.LastChange);

            return date;
        }

        public static DateTime LastStopBookingChange(string tourOperatorId, string siteCode, string offerCode)
        {
            var unit = manager.GetTouristUnit(tourOperatorId, siteCode, offerCode);
            DateTime date = unit.LastChange;

            return date;
        }
    }
}
