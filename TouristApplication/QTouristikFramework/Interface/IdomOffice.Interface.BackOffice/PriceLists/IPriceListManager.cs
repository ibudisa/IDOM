using System.Collections.Generic;

namespace IdomOffice.Interface.BackOffice.PriceLists
{
    public interface IPriceListManager
    {
        /// <summary>
        /// Get by id
        /// </summary>
        PriceList GetPriceList(string id);

        // siteCode + offerCode -> UnitType
    
       
        PriceList GetPriceList(string TourOperatorCode, string SiteCode, string OfferCode, PriceListType priceListType);


        List<PriceList> GetPriceLists();
        List<PriceList> GetPriceLists(string SiteCode);
        
        List<PriceList> GetPriceLists(string TourOperatorCode, string SiteCode, string OfferCode);

        void AddPriceList(PriceList document);

        void UpdatePriceList(PriceList document);

        void DeletePriceList(string id);

       
    }
}
