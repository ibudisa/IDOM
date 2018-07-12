using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.PriceList.Repositorys;
using IdomOffice.Interface.BackOffice.MasterData;

namespace V50_IDOMBackOffice.AspxArea.PriceList.Controllers
{
    public class RetailPriceController
    {
        public  List<Data> GetTouristCodes()
        {
            return PriceListRepository.GetDataTouristOperators();
        }

        public  List<Data> GetTouristSites(string touroperator)
        {
            return PriceListRepository.GetDataSiteCodes(touroperator);
        }

        public  List<Data> GetUnitOffers(string sitecode)
        {
            return PriceListRepository.GetDataOfferCodes(sitecode);
        }
    }
}