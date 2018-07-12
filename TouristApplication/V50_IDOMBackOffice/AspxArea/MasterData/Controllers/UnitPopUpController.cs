using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdomOffice.Interface.BackOffice.MasterData;
using V50_IDOMBackOffice.AspxArea.MasterData.Models;
using V50_IDOMBackOffice.AspxArea.MasterData.Repositorys;
using V50_IDOMBackOffice.AspxArea.PriceList.Repositorys;



namespace V50_IDOMBackOffice.AspxArea.MasterData.Controllers
{
    public class UnitPopUpController
    {
        public List<Data> GetSiteCodes()
        {
            return MasterDataRepository.GetDataSiteCodes();
        }

        public List<Data> GetUnitCodes(string sitecode)
        {
            return MasterDataRepository.GetDataUnitCodes(sitecode);
        }

        public List<Data> GetOfferCodes(string sitecode,string unitcode)
        {
            return MasterDataRepository.GetDataOfferCodes(sitecode,unitcode);
        }

        public List<Data> GetOfferCodes(string sitecode)
        {
            return MasterDataRepository.GetDataOfferCodes(sitecode);
        }

        public List<Data> GetPriceListTypes(string sitecode,string offercode)
        {
            return PriceListRepository.GetDataPriceListTypes(sitecode, offercode);
        }

        public string GetSiteName(string sitecode)
        {
            return MasterDataRepository.GetSiteName(sitecode);
        }

        public string GetUnitName(string unitcode)
        {
            return MasterDataRepository.GetUnitName(unitcode);
        }

        public string GetOfferName(string offercode)
        {
            return MasterDataRepository.GetOfferName(offercode);
        }
    }
}