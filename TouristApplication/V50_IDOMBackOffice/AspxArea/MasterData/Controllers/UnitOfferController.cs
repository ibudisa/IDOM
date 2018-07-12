using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.MasterData.Models;
using V50_IDOMBackOffice.AspxArea.MasterData.Repositorys;

namespace V50_IDOMBackOffice.AspxArea.MasterData.Controllers
{
    public class UnitOfferController
    {
        public List<UnitOfferViewModel> Init()
        {
            return TouristUnitRepository.GetUnitOfferViewModel();
        }

        public void AddUnitOffer(UnitOfferViewModel model)
        {
            MasterDataRepository.AddMasterData(model);
        }
        public void UpdateUnitOffer(UnitOfferViewModel model)
        {
            MasterDataRepository.UpdateMasterData(model);
        }

        public void DeleteUnitOffer(string id)
        {
            MasterDataRepository.DeleteUnitOffer(id);
        }

        public bool ContainsOfferCode(string offercode)
        {
           return MasterDataRepository.UnitOfferContainsCode(offercode);
        }

        public List<string> GetUnitCodes()
        {
            return TouristUnitRepository.GetUnitCodes();
        }

        public string GetSiteCode(string unitcode)
        {
            return TouristUnitRepository.GetSiteCodeFromUnit(unitcode);
        }

        public  List<UnitOfferViewModel> GetUnitOfferByCode(string sitecode,string unitcode)
        {
            return TouristUnitRepository.GetUnitOfferByCode(sitecode, unitcode);
        }
    }
}