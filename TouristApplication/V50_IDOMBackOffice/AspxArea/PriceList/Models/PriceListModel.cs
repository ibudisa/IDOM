using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdomOffice.Interface.BackOffice.PriceLists;

namespace V50_IDOMBackOffice.AspxArea.PriceList.Models
{
    public class PriceListModel
    {
        //public DateTime OpenDate { get; set; }
        //public DateTime CloseDate { get; set; }
        //public List<SeasonAndPrice> SeasonAndPrices = new List<SeasonAndPrice>();
        //public List<SeasonUnitAvailability> UnitAvailability = new List<SeasonUnitAvailability>();
        //public List<SeasonUnitAction> UnitAction = new List<SeasonUnitAction>();

        public string id { get; set; }
        public string TourOperatorCode { get; set; }
        public string SiteCode { get; set; }
        public string UnitCode { get; set; }
        public string OfferCode { get; set; }
        public PriceListType PriceListType { get; set; }

        public List<SeasonAndPrice> SeasonPriceList { get; set; } = new List<SeasonAndPrice>();
        public List<SeasonUnitAvailability> AvailabilityList { get; set; } = new List<SeasonUnitAvailability>();
        public List<SeasonUnitAction> ActionsList { get; set; } = new List<SeasonUnitAction>();
        public List<SeasonUnitCondition> ConditionsList { get; set; } = new List<SeasonUnitCondition>();
        public List<SeasonUnitService> ServicesList { get; set; } = new List<SeasonUnitService>();
        // public List<DateInterval> StopBookingList { get; set; } = new List<DateInterval>();
        public List<PaymentMode> PaymentModeList { get; set; } = new List<PaymentMode>();
        public List<SpecialPrices> SpecialPricesList { get; set; } = new List<SpecialPrices>();

        public string SiteName { get; set; }
        public string UnitName { get; set; }


    }
}