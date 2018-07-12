using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntSync  = QTouristik.Interface.Sync;
using IntOffice = IdomOffice.Interface.BackOffice.PriceLists;
using PlugInPriceLists = IdomOffice.PlugIn.BackOffice.PriceLists;
using Utility = QTouristik.Utility;
using QTouristik.Utility.PriceCalculator;
using IdomOffice.PlugIn.BackOffice.MasterData;


namespace IdomOffice.PlugIn.BackOffice.Sync
{
    public class PriceCalculatorManager : IntSync.IPriceSync
    {
        public IntSync.Price GetPrice(IntSync.PriceArg arg)
        {
            IntSync.Price price = new IntSync.Price();
            IntOffice.PriceList pr = new PlugInPriceLists.PriceListManager().GetPriceList("IDOM", arg.TouristSiteCode, arg.OfferCode, IntOffice.PriceListType.RetailPrice);
            return GetPrice(arg,pr);
        }

        public IntSync.Price GetPrice(QTouristik.Interface.Sync.PriceArg arg, IntOffice.PriceList priceList)
        {
            MasterDataManager mda = new MasterDataManager();
            var unit = mda.GetTouristUnit(arg.TouristSiteCode, arg.OfferCode);
            
            var offer = mda.GetUnitOffer(arg.TourOperatorCode, arg.TouristSiteCode, arg.OfferCode);
            Utility.PriceCalculator.CalculatorPriceList cpl = ConvertToCalculatorPriceList(priceList, unit.UnitStopBooking);
            var calcArg = new QTouristik.Utility.PriceCalculator.PriceArg();
            calcArg.CheckIn = arg.CheckIn.Date;
            calcArg.CheckOut = arg.CheckOut.Date;
            calcArg.OfferCode = arg.OfferCode;
            calcArg.Pets = arg.Pets;
            calcArg.TouristSiteId = arg.TouristSiteCode;
            calcArg.TourOperatorCode = arg.TourOperatorCode;
            calcArg.Traveler = arg.Birthdays;
            calcArg.PaymentOfferOptionId = arg.PaymentOfferOptionId;


            var calculatorPrice = new QTouristik.Utility.PriceCalculator.PriceCalculateUtility(cpl).GetPrice(calcArg);
            var price = ConvertToPrice(calculatorPrice);
            price.OfferCode = priceList.OfferCode;
            price.OfferName = offer.OfferTitel;
            price.PlaceName = unit.PlaceName;
            price.RegionName = unit.RegionName;
            price.SiteCode = unit.SiteCode;
            price.FacilityName = unit.SiteName;
            

            return price;
        }

        public IEnumerable<IntSync.UnitPriceBulkCopyItem> GetUnitPriceSearchList(string tourOperatorId, string facilityCode, string unitCode, string offerCode)
        {

            IntOffice.PriceList priceList = new IdomOffice.PlugIn.BackOffice.PriceLists.PriceListManager().GetPriceList(tourOperatorId, facilityCode, offerCode, Interface.BackOffice.PriceLists.PriceListType.RetailPrice);
            MasterDataManager mda = new MasterDataManager();
            var unit = mda.GetTouristUnit(facilityCode, offerCode);

            //var offer = mda.GetUnitOffer(arg.TourOperatorCode, arg.TouristSiteCode, arg.OfferCode);
            CalculatorPriceList cpl = ConvertToCalculatorPriceList(priceList,unit.UnitStopBooking);
            var bulkInfo = new QTouristik.Interface.Sync.BulkUnitInfo();
            bulkInfo.OpenDate = unit.OpenDate.Date;
            bulkInfo.CloseDate = unit.CloseDate.Date;
            bulkInfo.MaxPersons = unit.MaxPersons;
            return new QTouristik.Utility.PriceCalculator.Helper.PriceBulkCopyHelper().GetUnitPriceSearchList(offerCode,bulkInfo, cpl, facilityCode);
        }

        private CalculatorPriceList ConvertToCalculatorPriceList(IntOffice.PriceList priceList, List<QTouristik.Data.DateInterval>  stopbookingList )
        {
            var pl = new CalculatorPriceList();
            foreach (var l1 in priceList.ActionsList)
                pl.ActionsList.Add(new Utility.PriceCalculator.SeasonUnitAction()
                {
                    ActionEnd = l1.ActionEnd.Date,
                    ActionStart = l1.ActionStart.Date,
                    ActionType = (Utility.PriceCalculator.ActionType)l1.ActionType,
                    CanBeCombined = l1.CanBeCombined,
                    DiscountEur = l1.DiscountEur,
                    DiscountPercent = l1.DiscountPercent,
                    FreeNights = l1.FreeNights,
                    FromDate = l1.FromDate.Date,
                    MinPrice = l1.MinPrice,
                    MinStayDays = l1.MinStayDays,
                    ToDate = l1.ToDate.Date
                });

            foreach (var l in priceList.AvailabilityList)
                pl.AvailabilityList.Add(new Utility.PriceCalculator.SeasonUnitAvailability() { FromDate = ConvertTime(l.FromDate), ToDate = ConvertTime(l.ToDate), IsAutoStopBooking = l.IsAutoStopBooking, UnitCount = l.UnitCount });

            foreach (var l in priceList.ConditionsList)
            {
                var itm = new Utility.PriceCalculator.SeasonUnitCondition()
                {
                    Arrival = l.Arrival,
                    Departure = l.Departure,
                    FromDate = l.FromDate.Date,
                    ToDate = l.ToDate.Date,
                    MinStay = l.MinStay,
                    ReleaseDays = l.ReleaseDays
                };
                if (itm.Arrival.Count == 0)
                    itm.Arrival.Add(l.ArrivalActual);
                if (itm.Departure.Count == 0)
                    itm.Departure.Add(l.DepartureActual);
                pl.ConditionsList.Add(itm);
                
            }

            foreach (var l in priceList.PaymentModeList)
                pl.PaymentModeList.Add(new Utility.PriceCalculator.PaymentMode()
                {
                    BookingFromDate = l.BookingFromDate,
                    BookingToDate = l.BookingToDate,
                    CancellationFeesPercent = l.CancellationFeesPercent,
                    CancellationFeesToDays = l.CancellationFeesToDays,
                    CheckInFromDate = l.CheckInFromDate,
                    CheckInToDate = l.CheckInToDate,
                    MaxDayToArrival = l.MaxDayToArrival,
                    MinDayToArrival = l.MinDayToArrival,
                    PaymentModeDescription = l.PaymentModeDescription,
                    PaymentModeTitel = l.PaymentModeTitel,
                    PriceDownPaymentAfterDays = l.PriceDownPaymentAfterDays,
                    PriceDownPaymentEur = l.PriceDownPaymentEur,
                    PriceDownPaymentPercent = l.PriceDownPaymentPercent,
                    PricePercentDiscount = l.PricePercentDiscount,
                    PriceRemainingBeforDays = l.PriceRemainingBeforDays
                });

            foreach (var l in priceList.SeasonPriceList)
                pl.SeasonPriceList.Add(new Utility.PriceCalculator.SeasonAndPrice()
                {
                    Eur = l.Eur,
                    FromDate = l.FromDate.Date,
                    FromPersons = l.FromPersons,
                    PriceType = (Utility.PriceCalculator.PriceType)l.PriceType,
                    ToDate = l.ToDate.Date,
                    ToPersons = l.ToPersons
                });

            foreach (var l in priceList.ServicesList)
                pl.ServicesList.Add(new Utility.PriceCalculator.SeasonUnitService()
                {
                    Description = l.Description,
                    FromDate = l.FromDate.Date,
                    ToDate = l.ToDate.Date,
                    OfDay = l.OfDay,
                    ToDay = l.ToDay,
                    Eur = l.Eur,
                    IsOptional = l.IsOptional,
                    OfOld = l.OfOld,
                    PaymentPlace = (Utility.PriceCalculator.PaymentPlace)l.PaymentPlace,
                    ServiceInterval = (Utility.PriceCalculator.ServiceInterval)l.ServiceInterval,
                    ServiceType = (Utility.PriceCalculator.ServiceType)l.ServiceType,
                    ServiceUnit = (Utility.PriceCalculator.ServiceUnit)l.ServiceUnit,
                    ToOld = l.ToOld
                });

            if (stopbookingList != null)
            {
                foreach (var l in stopbookingList)
                    pl.StopBookingList.Add(new Utility.PriceCalculator.DateInterval()
                    {
                        FromDate = l.FromDate.Date,
                        ToDate = l.ToDate.Date
                    });

            }
            return pl;
        }
        private DateTime ConvertTime( DateTime dt)
        {
            return DateTime.Parse(dt.ToShortDateString());
        }

        private IntSync.Price ConvertToPrice(CalculatorPrice price)
        {
            IntSync.Price pr = new IntSync.Price()
            {
                Adults = price.Adults,
                CheckIn = price.CheckIn,
                CheckOut = price.CheckOut,
                Children = price.Children,
                ValueByArrival = price.ValueByArrival,
                ValueByBooking = price.ValueByBooking,
                Currency = price.Currency,
                ValueListPriceByBooking = price.ValueListPriceByBooking,
                FromPersons = price.FromPersons,
                ToPersons = price.ToPersons,
                PaymentOptionsSelectId = price.PaymentOfferOptionId

                

            };
            foreach (var i in price.ArrivalServiceList)
                pr.ArrivalServiceList.Add(new IntSync.ServicePriceItem() { Description = i.Description, Eur = i.Eur, ServiceType = (IntSync.ServiceType)i.ServiceType });
            foreach (var i in price.BookingServiceList)
                pr.BookingServiceList.Add(new IntSync.ServicePriceItem() { Description = i.Description, Eur = i.Eur, ServiceType = (IntSync.ServiceType)i.ServiceType });
            foreach (var i in price.PaymentInfoList)
                pr.PaymentInfoList.Add(new IntSync.PaymentInfo() { Date = i.Date, Eur = i.Eur, Percent = i.Percent });
            foreach (var i in price.PaymentOfferOptionsList)
                pr.PaymentOfferOptionsList.Add(new IntSync.PaymentOfferOption() { PaymentModeTitel = i.PaymentModeTitel, PaymentModeDescription = i.PaymentModeDescription, PaymentOfferEur = i.PaymentOfferEur, PaymentOfferId = i.PaymentOfferId, CancellationFeesPercent = i.CancellationFeesPercent, CancellationFeesToDays=i.CancellationFeesToDays });
            return pr;
        }
    }
}
