using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.PriceList.Models;
using IdomOffice.Interface.BackOffice.PriceLists;

namespace V50_IDOMBackOffice.AspxArea.PriceList.Controllers
{
    public interface IPricelistController
    {
        PriceListModel GetModel(string tourOperatorCode,string siteCode, string offerCode, PriceListType pType);
        string GetPriceListId(string tourOperatorCode, string siteCode, string offerCode, PriceListType pType);
        void SavePartialModelSeasonAndPrice(string id, List<SeasonAndPrice> partModelList);
        void CopyPriceList(string tourOperatorCode,string sourceSiteCode, string sourceOfferCode, PriceListType sourcePriceListType,
            string targetSiteCode, string targetUitCode, string targetOfferCode, PriceListType targetPriceListType,
            decimal factor);
        void SavePartialModelSeasonUnitAvailability(string id, List<SeasonUnitAvailability> partModelList);
        void SavePartialModelSeasonUnitAction(string id, List<SeasonUnitAction> partModelList);
        void SavePartialModelSeasonUnitCondition(string id, List<SeasonUnitCondition> partModelList);
        void SavePartialModelSeasonUnitService(string id, List<SeasonUnitService> partModelList);
        void SavePartialModelPaymentMode(string id, List<PaymentMode> partModelList);
        void SavePartialModelSpecialPrices(string id, List<SpecialPrices> partModelList);
        List<KeyValuePair<string, object>> GetSeasonAndPriceDefaultValue(PriceListModel model);
        List<KeyValuePair<string, object>> GetServicesListeDefaultValue(PriceListModel model);
        List<KeyValuePair<string, object>> GetActionsListDefaultValue(PriceListModel model);
        List<KeyValuePair<string, object>> GetAvalailabilityListDefaultValue(PriceListModel model);
        List<KeyValuePair<string, object>> GetConditionsListDefaultValue(PriceListModel model);
        List<KeyValuePair<string, object>> GetPaymentModesListDefaultValue(PriceListModel model);
        
    }
}