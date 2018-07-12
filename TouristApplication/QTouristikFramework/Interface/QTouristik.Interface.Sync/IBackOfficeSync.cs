using System;
using System.Collections.Generic;

namespace QTouristik.Interface.Sync
{
    public interface IBackOfficeSync
    {
        //OfferInfo GetOfferInfo(string TourOperatorCode, string SiteCode, string OfferCode);
        //List<OfferInfo> GetOfferInfos(string TourOperatorCode);
        //List<OfferInfo> GetOfferInfos(string TourOperatorCode, string SiteCode);
        //DateTime LastPriceChange(string TourOperatorCode, string SiteCode, string OfferCode);
        //DateTime LastOfferInfoChange(string TourOperatorCode, string SiteCode, string OfferCode);
        //DateTime LastStopBookingChange(string TourOperatorCode, string SiteCode, string OfferCode);

        OfferInfo GetOfferInfo(string tourOperatorId, string siteCode, string offerCode);
        List<OfferInfo> GetOfferInfos(string tourOperatorId);
        List<OfferInfo> GetOfferInfos(string tourOperatorId, string siteCode);
        DateTime LastPriceChange(string tourOperatorId, string siteCode, string offerCode);
        DateTime LastOfferInfoChange(string tourOperatorId, string siteCode, string offerCode);
        DateTime LastStopBookingChange(string tourOperatorId, string siteCode, string offerCode);
    }
}
