using System;
using System.Collections.Generic;
using QTouristik.Data;

namespace IdomOffice.Interface.BackOffice.PriceLists
{
    public class PriceList
    {

        public string id { get; set; }
        public string TourOperatorCode { get; set; }
        public string SiteCode { get; set; }
        public string OfferCode { get; set; }
        public PriceListType PriceListType { get; set; }
        public List<SeasonAndPrice> SeasonPriceList { get; set; } = new List<SeasonAndPrice>();
        public List<SeasonUnitAvailability> AvailabilityList { get; set; } = new List<SeasonUnitAvailability>();
        public List<SeasonUnitAction> ActionsList { get; set; } = new List<SeasonUnitAction>();
        public List<SeasonUnitCondition> ConditionsList { get; set; } = new List<SeasonUnitCondition>();
        public List<SeasonUnitService> ServicesList { get; set; } =new  List<SeasonUnitService>();
       // public List<DateInterval> StopBookingList { get; set; } = new List<DateInterval>();
        public List<PaymentMode> PaymentModeList { get; set; } = new List<PaymentMode>();
        public List<SpecialPrices> SpecialPricesList { get; set; } = new List<SpecialPrices>();
        public DateTime LastChange { get; set; }
    }
}
