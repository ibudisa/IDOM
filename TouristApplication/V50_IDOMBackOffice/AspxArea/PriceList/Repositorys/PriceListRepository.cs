using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdomOffice.Interface.BackOffice.MasterData;
using IdomOffice.Interface.BackOffice.PriceLists;
using V50_IDOMBackOffice.PlugIn.Controller;
using V50_IDOMBackOffice.AspxArea.PriceList.Models;

namespace V50_IDOMBackOffice.AspxArea.PriceList.Repositorys
{
    public class PriceListRepository
    {
        public static PriceListModel GetModel(string tourOperatorCode, string siteCode, string offerCode, PriceListType priceTyp)
        {
            PriceListModel model = new PriceListModel();
          
                var manager = PlugInManager.GetPriceListManager();
                var priceList = manager.GetPriceList(tourOperatorCode, siteCode, offerCode, priceTyp);
               
                if (priceList == null)
                {
                    priceList = new IdomOffice.Interface.BackOffice.PriceLists.PriceList();
                    priceList.id = Guid.NewGuid().ToString();
                    priceList.TourOperatorCode = tourOperatorCode;
                    priceList.SiteCode = siteCode;
                    priceList.OfferCode = offerCode;
                    priceList.PriceListType = priceTyp;
                    manager.AddPriceList(priceList);
                }

                // sada kreiramo model 
                model = new PriceListModel();
                model.id = priceList.id;
                model.SiteCode = priceList.SiteCode;
                model.OfferCode = priceList.OfferCode;
          //      model.UnitCode = priceList.UnitCode;
                model.PriceListType = priceList.PriceListType;
                model.TourOperatorCode = priceList.TourOperatorCode;
                model.SeasonPriceList = priceList.SeasonPriceList;
                model.ActionsList = priceList.ActionsList;
                model.AvailabilityList = priceList.AvailabilityList;
                model.ConditionsList = priceList.ConditionsList;
                model.PaymentModeList = priceList.PaymentModeList;
                model.ServicesList = priceList.ServicesList;
                model.SpecialPricesList = priceList.SpecialPricesList;

                var masterDataManager = PlugInManager.GetMasterDataManager();
                var offer = masterDataManager.GetUnitOffer(tourOperatorCode, siteCode, offerCode);
                var unit = masterDataManager.GetTouristUnit(siteCode, offer.UnitCode);
                model.SiteName = unit.SiteName;
                model.UnitName = unit.UnitTitel;
                int counter = 0;
                foreach (var item in model.SeasonPriceList)
                    item.Id = (++counter).ToString();
                List<SeasonAndPrice> season = model.SeasonPriceList;
                season = season.OrderBy(m => m.FromDate).ToList();
                model.SeasonPriceList = season;
                counter = 0;
                foreach (var item in model.SpecialPricesList)
                    item.Id = (++counter).ToString();
                counter = 0;
                foreach (var item in model.ActionsList)
                    item.Id = (++counter).ToString();
                counter = 0;
                foreach (var item in model.AvailabilityList)
                    item.Id = (++counter).ToString();
                counter = 0;
                foreach (var item in model.ConditionsList)
                    item.Id = (++counter).ToString();
                counter = 0;
                foreach (var item in model.PaymentModeList)
                    item.Id = (++counter).ToString();
                counter = 0;
                foreach (var item in model.ServicesList)
                    item.Id = (++counter).ToString();
            

            return model;
        }

        public static IdomOffice.Interface.BackOffice.PriceLists.PriceList GetPriceList(string id)
        {
            var manager = PlugInManager.GetPriceListManager();
            return   manager.GetPriceList(id);
        }

        public static IdomOffice.Interface.BackOffice.PriceLists.PriceList GetPriceList(string tourOperatorCode, string siteCode, string offerCode, PriceListType priceTyp)
        {
            var manager = PlugInManager.GetPriceListManager();
            return manager.GetPriceList(tourOperatorCode,siteCode, offerCode, priceTyp);
        }

        public static void ReplacePriceList(IdomOffice.Interface.BackOffice.PriceLists.PriceList priceList, string targetPriceListId, decimal factor)
        {
            var manager = PlugInManager.GetPriceListManager();
            var targetPriceList = manager.GetPriceList(targetPriceListId);
            targetPriceList.ActionsList = priceList.ActionsList;
            targetPriceList.AvailabilityList = priceList.AvailabilityList;
            targetPriceList.ConditionsList = priceList.ConditionsList;
            targetPriceList.PaymentModeList = priceList.PaymentModeList;
            targetPriceList.ServicesList = priceList.ServicesList;
            targetPriceList.SeasonPriceList = priceList.SeasonPriceList;

            if (factor > 0)
            {
                foreach (var pr in targetPriceList.SeasonPriceList)
                    pr.Eur = pr.Eur * factor;

            }
            manager.UpdatePriceList(targetPriceList);

        } 

        public static void SavePartialPriceListModel(string id, List<SeasonAndPrice> partModelList)
        {
            var manager = PlugInManager.GetPriceListManager();
            var pricelist = manager.GetPriceList(id);
            pricelist.SeasonPriceList = partModelList;
            manager.UpdatePriceList(pricelist);
        }
        public static void SavePartialPriceListModel(string id, List<SeasonUnitAction> partModelList)
        {
            var manager = PlugInManager.GetPriceListManager();
            var pricelist = manager.GetPriceList(id);
            pricelist.ActionsList = partModelList;
            manager.UpdatePriceList(pricelist);
        }
        public static void SavePartialPriceListModel(string id, List<SeasonUnitAvailability> partModelList)
        {
            var manager = PlugInManager.GetPriceListManager();
            var pricelist = manager.GetPriceList(id);
            pricelist.AvailabilityList = partModelList;
            manager.UpdatePriceList(pricelist);
        }

        public static void SavePartialPriceListModel(string id, List<SeasonUnitService> partModelList)
        {
            var manager = PlugInManager.GetPriceListManager();
            var pricelist = manager.GetPriceList(id);
            pricelist.ServicesList = partModelList;
            manager.UpdatePriceList(pricelist);
        }

        public static void SavePartialPriceListModel(string id, List<SeasonUnitCondition> partModelList)
        {
            var manager = PlugInManager.GetPriceListManager();
            var pricelist = manager.GetPriceList(id);
            pricelist.ConditionsList = partModelList;
            manager.UpdatePriceList(pricelist);
        }

        public static void SavePartialPriceListModel(string id, List<PaymentMode> partModelList)
        {
            var manager = PlugInManager.GetPriceListManager();
            var pricelist = manager.GetPriceList(id);
            pricelist.PaymentModeList = partModelList;
            manager.UpdatePriceList(pricelist);
        }

        public static void SavePartialPriceListModel(string id, List<SpecialPrices> partModelList)
        {
            var manager = PlugInManager.GetPriceListManager();
            var pricelist = manager.GetPriceList(id);
            pricelist.SpecialPricesList = partModelList;
            manager.UpdatePriceList(pricelist);
        }

        public static List<PriceListModel> GetAll()
        {
            var manager = PlugInManager.GetPriceListManager();

            List<IdomOffice.Interface.BackOffice.PriceLists.PriceList> list = new List<IdomOffice.Interface.BackOffice.PriceLists.PriceList>();

            List<PriceListModel> pricelist = new List<PriceListModel>();

            list = manager.GetPriceLists();

            foreach (var priceList in list)
            {
                PriceListModel model = new PriceListModel();
                model.id = priceList.id;
                model.SiteCode = priceList.SiteCode;
                model.OfferCode = priceList.OfferCode;
      //          model.UnitCode = priceList.UnitCode;
                model.PriceListType = priceList.PriceListType;
                model.TourOperatorCode = priceList.TourOperatorCode;
                model.SeasonPriceList = priceList.SeasonPriceList;
                model.ActionsList = priceList.ActionsList;
                model.AvailabilityList = priceList.AvailabilityList;
                model.ConditionsList = priceList.ConditionsList;
                model.PaymentModeList = priceList.PaymentModeList;
                model.ServicesList = priceList.ServicesList;
                model.SpecialPricesList = priceList.SpecialPricesList;

                var masterDataManager = PlugInManager.GetMasterDataManager();
                var offer = masterDataManager.GetUnitOffer(priceList.TourOperatorCode, priceList.SiteCode, priceList.OfferCode);
                var unit = masterDataManager.GetTouristUnit(priceList.SiteCode, offer.UnitCode);
                if (unit != null)
                {
                    model.SiteName = unit.SiteName;
                    model.UnitName = unit.UnitTitel;
                }
                int counter = 0;
                foreach (var item in model.SeasonPriceList)
                    item.Id = (++counter).ToString();
                counter = 0;
                foreach (var item in model.SpecialPricesList)
                    item.Id = (++counter).ToString();
                counter = 0;
                foreach (var item in model.ActionsList)
                    item.Id = (++counter).ToString();
                counter = 0;
                foreach (var item in model.AvailabilityList)
                    item.Id = (++counter).ToString();
                counter = 0;
                foreach (var item in model.ConditionsList)
                    item.Id = (++counter).ToString();
                counter = 0;
                foreach (var item in model.PaymentModeList)
                    item.Id = (++counter).ToString();
                counter = 0;
                foreach (var item in model.ServicesList)
                    item.Id = (++counter).ToString();

                pricelist.Add(model);

               
            }
            return pricelist;
        }

        public static List<string> GetTouristOperators()
        {
            List<string> operators = new List<string>();

            var pricelist = GetAll();

            operators= (from a in pricelist
                        where a.PriceListType==PriceListType.RetailPrice
                        group a by a.TourOperatorCode into touroperator
                        select touroperator.Key).ToList();

            operators = operators.Distinct().ToList();

            return operators;
        }

        public static List<string> GetSiteCodes(string touroperator)
        {
            List<string> sitecodes = new List<string>();

            var pricelist = GetAll();

            sitecodes = (from a in pricelist
                         where a.TourOperatorCode==touroperator && a.PriceListType==PriceListType.RetailPrice
                         group a by a.SiteCode into site
                         select site.Key).ToList();

            var sites = sitecodes.Distinct().ToList();

            return sites;
                       
        }

        public static List<Data> GetDataTouristOperators()
        {
            List<Data> list = new List<Data>();
            var operators = GetTouristOperators();
            int number = 0;

            foreach (var item in operators)
            {
                Data dt = new Data(number.ToString(), item);
                number++;
                list.Add(dt);
            }

            return list;
        }

        public static List<Data> GetDataSiteCodes(string touroperator)
        {
            List<Data> list = new List<Data>();
            var sites = GetSiteCodes(touroperator);
            int number = 0;

            foreach(var site in sites)
            {
                Data dt = new Data(number.ToString(), site);
                number++;
                list.Add(dt);
            }

            return list;
        }

        public static List<string> GetUnitCodes(string sitecode)
        {
            List<string> units = new List<string>();

            var pricelist = GetAll();

            units = (from a in pricelist
                     where a.SiteCode == sitecode
                     group a by a.UnitCode into unit
                     select unit.Key).ToList();

            var unitcodes = units.Distinct().ToList();

            return unitcodes;
        }

        public static List<string> GetOfferCodes(string sitecode)
        {
            List<string> offers = new List<string>();

            var pricelist = GetAll();

            offers = (from a in pricelist
                     where a.SiteCode == sitecode && a.PriceListType==PriceListType.RetailPrice
                     group a by a.OfferCode into offer
                     select offer.Key).ToList();

            var offercodes = offers.Distinct().ToList();

            return offercodes;
        }

        public static List<string> GetPriceListTypes(string sitecode,string offercode)
        {
            List<PriceListType> pricetypes = new List<PriceListType>();

            List<string> prices = new List<string>();

            var pricelist = GetAll();

            pricetypes = (from a in pricelist
                      where a.SiteCode == sitecode && a.OfferCode==offercode
                      select a.PriceListType).ToList();

            foreach(var item in pricetypes)
            {
                prices.Add(item.ToString());
            }

            return prices;
        }


        public static List<Data> GetDataUnitCodes(string sitecode)
        {
            List<Data> list = new List<Data>();
            int number = 0;

            var unitcodes = GetUnitCodes(sitecode);

            foreach (var unit in unitcodes)
            {
                Data dt = new Data(number.ToString(), unit);
                number++;
                list.Add(dt);
            }
            return list;
        }

        public static List<Data> GetDataOfferCodes(string sitecode)
        {
            List<Data> list = new List<Data>();
            int number = 0;

            var offercodes = GetOfferCodes(sitecode);

            foreach(var offer in offercodes)
            {
                Data dt = new Data(number.ToString(), offer);
                number++;
                list.Add(dt);

            }

            return list;


        }

        public static List<Data> GetDataPriceListTypes(string sitecode,string offercode)
        {
            List<Data> list = new List<Data>();
            int number = 0;

            var pricelisttypes = GetPriceListTypes(sitecode, offercode);

            foreach(var type in pricelisttypes)
            {
                Data dt = new Data(number.ToString(), type);
                number++;
                list.Add(dt);
            }

            return list;
        }
    }
}