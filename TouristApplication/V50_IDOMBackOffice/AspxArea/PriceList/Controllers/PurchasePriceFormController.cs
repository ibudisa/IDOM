using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdomOffice.Interface.BackOffice.PriceLists;
using V50_IDOMBackOffice.AspxArea.PriceList.Models;
using V50_IDOMBackOffice.AspxArea.PriceList.Repositorys;
using V50_IDOMBackOffice.AspxArea.MasterData.Repositorys;

namespace V50_IDOMBackOffice.AspxArea.PriceList.Controllers
{
    public class PurchasePriceFormController : IPricelistController
    {
        public PriceListModel GetModel(string tourOperatorCode, string siteCode, string offerCode, PriceListType pType)
        {
            return PriceListRepository.GetModel(tourOperatorCode, siteCode, offerCode, pType);
        }

        public void  CopyPriceList(string touroperator, string sourceSiteCode, string sourceOfferCode, PriceListType sourcePriceListType,
            string targetSiteCode, string targetUitCode, string targetOfferCode, PriceListType targetPriceListType, 
            decimal factor)
        {
            //uzmi cijene koje treba da budu kopirane
            var sourcePriceList = PriceListRepository.GetPriceList(touroperator,sourceSiteCode, sourceOfferCode, sourcePriceListType);
            //uzmi id od cjenovnika u koji treba da bude kopirano
            string targetId = PriceListRepository.GetPriceList(touroperator, targetSiteCode, targetOfferCode, targetPriceListType).id;
            //kopiraj cjene u aktuelni cjenovnik
            PriceListRepository.ReplacePriceList(sourcePriceList, targetId, factor);
        }

        public string GetPriceListId(string touroperator, string siteCode, string offerCode, PriceListType pType)
        {
            return PriceListRepository.GetModel(touroperator, siteCode, offerCode, pType).id;
        }


        

        public void SavePartialModelPaymentMode(string id, List<PaymentMode> partModelList)
        {
            PriceListRepository.SavePartialPriceListModel(id, partModelList);
        }

        public void SavePartialModelSeasonAndPrice(string id, List<SeasonAndPrice> partModelList)
        {
            PriceListRepository.SavePartialPriceListModel(id, partModelList);
        }

        public void SavePartialModelSeasonUnitAction(string id, List<SeasonUnitAction> partModelList)
        {
            PriceListRepository.SavePartialPriceListModel(id, partModelList);
        }

        public void SavePartialModelSeasonUnitAvailability(string id, List<SeasonUnitAvailability> partModelList)
        {
            PriceListRepository.SavePartialPriceListModel(id, partModelList);
        }

        public void SavePartialModelSeasonUnitCondition(string id, List<SeasonUnitCondition> partModelList)
        {
            PriceListRepository.SavePartialPriceListModel(id, partModelList);
        }

        public void SavePartialModelSeasonUnitService(string id, List<SeasonUnitService> partModelList)
        {
            PriceListRepository.SavePartialPriceListModel(id, partModelList);
        }

        public void SavePartialModelSpecialPrices(string id, List<SpecialPrices> partModelList)
        {
            PriceListRepository.SavePartialPriceListModel(id, partModelList);
        }

        public void SavePartialPriceListModel(string id, List<SeasonAndPrice> partModelList)
        {
            throw new NotImplementedException();
        }

       public List<KeyValuePair<string, object>> GetSeasonAndPriceDefaultValue(PriceListModel model)
        {
            var unit = TouristUnitRepository.GetTouristUnit(model.SiteCode, model.OfferCode);
            var ret = new List<KeyValuePair<string, object>>();
            ret.Add(new KeyValuePair< string, object>( "FromPersons", 1));
            ret.Add(new KeyValuePair<string, object>("ToPersons", unit.MaxPersons));
            ret.Add(new KeyValuePair<string, object>("PriceType", PriceType.UnitPerNight));

            if (model.SeasonPriceList.Count > 0)
                ret.Add(new KeyValuePair<string, object>("FromDate", model.SeasonPriceList.Max(r => r.ToDate).AddDays(1)));
            else
                ret.Add(new KeyValuePair<string, object>("FromDate", unit.OpenDate));
            return ret;
        }
        public List<KeyValuePair<string, object>> GetServicesListeDefaultValue(PriceListModel model)
        {
            var unit = TouristUnitRepository.GetTouristUnit(model.SiteCode, model.OfferCode);
            var ret = new List<KeyValuePair<string, object>>();
            ret.Add(new KeyValuePair<string, object>("FromDate", unit.OpenDate));
            ret.Add(new KeyValuePair<string, object>("ToDate", unit.CloseDate));
           
            if (model.ServicesList.Count == 0)
            {
                ret.Add(new KeyValuePair<string, object>("ServiceType", ServiceType.RegistrationFee));
                ret.Add(new KeyValuePair<string, object>("ServiceInterval", ServiceInterval.PerStay));
                ret.Add(new KeyValuePair<string, object>("ServiceUnit", ServiceUnit.PerPerson));
                ret.Add(new KeyValuePair<string, object>("PaymentPlace", PaymentPlace.Arrival));
                ret.Add(new KeyValuePair<string, object>("Description", "Anmeldegebühr"));
                ret.Add(new KeyValuePair<string, object>("Eur", 1));
            }
            if (model.ServicesList.Count == 1 || model.ServicesList.Count == 2)
            {
                ret.Add(new KeyValuePair<string, object>("ServiceType", ServiceType.Tax));
                ret.Add(new KeyValuePair<string, object>("ServiceInterval", ServiceInterval.PerDay));
                ret.Add(new KeyValuePair<string, object>("ServiceUnit", ServiceUnit.PerPerson));
                ret.Add(new KeyValuePair<string, object>("PaymentPlace", PaymentPlace.Arrival));
                ret.Add(new KeyValuePair<string, object>("Description", "Kurtaxe"));


                if (model.ServicesList.Count == 1)
                {
                    ret.Add(new KeyValuePair<string, object>("Eur", "0,55"));
                    ret.Add(new KeyValuePair<string, object>("OfOld", 12));
                    ret.Add(new KeyValuePair<string, object>("ToOld", 18));
                }
                if (model.ServicesList.Count == 2)
                {
                    ret.Add(new KeyValuePair<string, object>("Eur", "1,10"));
                    ret.Add(new KeyValuePair<string, object>("OfOld", 18));
                    ret.Add(new KeyValuePair<string, object>("ToOld", 99));
                }
            }
            return ret;
        }

        public List<KeyValuePair<string, object>> GetActionsListDefaultValue(PriceListModel model)
        {
            var unit = TouristUnitRepository.GetTouristUnit(model.SiteCode, model.OfferCode);
            var list = new List<KeyValuePair<string, object>>();
            list.Add(new KeyValuePair<string, object>("ActionStart", "12.09.2017"));
            list.Add(new KeyValuePair<string, object>("ActionEnd", unit.CloseDate));
            list.Add(new KeyValuePair<string, object>("FromDate", unit.OpenDate));

            if(model.ServicesList.Count==0)
            {
                list.Add(new KeyValuePair<string, object>("ActionType", "EarlyBooking"));
                list.Add(new KeyValuePair<string, object>("DiscountPercent", 10));
            }
            return list;
        }

        public List<KeyValuePair<string, object>> GetAvalailabilityListDefaultValue(PriceListModel model)
        {
            var unit = TouristUnitRepository.GetTouristUnit(model.SiteCode, model.OfferCode);
            var list = new List<KeyValuePair<string, object>>();
            list.Add(new KeyValuePair<string, object>("FromDate",unit.OpenDate));
            list.Add(new KeyValuePair<string, object>("ToDate", unit.CloseDate));
            list.Add(new KeyValuePair<string, object>("UnitCount", 99));
            return list;
        }

        public List<KeyValuePair<string, object>> GetConditionsListDefaultValue(PriceListModel model)
        {
            var unit = TouristUnitRepository.GetTouristUnit(model.SiteCode, model.OfferCode);
            var list = new List<KeyValuePair<string, object>>();
            list.Add(new KeyValuePair<string, object>("FromDate", unit.OpenDate));
            list.Add(new KeyValuePair<string, object>("ToDate", unit.CloseDate));
            list.Add(new KeyValuePair<string, object>("MinStay", 7));
            list.Add(new KeyValuePair<string, object>("ReleaseDays", 7));
            list.Add(new KeyValuePair<string, object>("ArrivalActual", 5));
            list.Add(new KeyValuePair<string, object>("DepartureActual", 5));

            return list;
        }

        public List<KeyValuePair<string, object>> GetPaymentModesListDefaultValue(PriceListModel model)
        {
            var unit = TouristUnitRepository.GetTouristUnit(model.SiteCode, model.OfferCode);
            var list = new List<KeyValuePair<string, object>>();
            list.Add(new KeyValuePair<string, object>("BookingFromDate", "12.09.2017"));
            list.Add(new KeyValuePair<string, object>("BookingToDate", unit.CloseDate));
            list.Add(new KeyValuePair<string, object>("CheckInFromDate", unit.OpenDate));
            list.Add(new KeyValuePair<string, object>("CheckInToDate", unit.CloseDate));

            return list;
        }
    }
}