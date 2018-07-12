using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTouristik.Interface.Sync;


namespace IdomOffice.PlugIn.BackOffice.Sync
{
    public class SyncBackOfficeManager : IBackOfficeSync
    {
        public SyncOfferInfo GetOfferInfo(string tourOperatorId, string siteCode, string offerCode)
        {
            var offer = BackOfficeUtility.GetOfferInfo(tourOperatorId, siteCode, offerCode);
            return offer;
        }

        public List<SyncOfferInfo> GetOfferInfos(string tourOperatorId)
        {
            var offers = BackOfficeUtility.GetOfferInfos(tourOperatorId);
            return offers;
        }

        public List<SyncOfferInfo> GetOfferInfos(string tourOperatorId, string siteCode)
        {
            var offers = BackOfficeUtility.GetOfferInfos(tourOperatorId, siteCode);
            return offers;
        }

        public DateTime LastOfferInfoChange(string tourOperatorId, string siteCode, string offerCode)
        {
            var date = BackOfficeUtility.LastOfferInfoChange(tourOperatorId, siteCode, offerCode);
            return date;
        }

        public DateTime LastPriceChange(string tourOperatorId, string siteCode, string offerCode)
        {
            var date = BackOfficeUtility.LastPriceChange(tourOperatorId, siteCode, offerCode);
            return date;
        }

        public DateTime LastStopBookingChange(string tourOperatorId, string siteCode, string offerCode)
        {
            var date = BackOfficeUtility.LastStopBookingChange(tourOperatorId, siteCode, offerCode);
            return date;
        }
    }
}
