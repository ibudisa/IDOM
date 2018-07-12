using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.MasterData.Models;
using V50_IDOMBackOffice.AspxArea.MasterData.Repositorys;
using IdomOffice.Interface.BackOffice.MasterData;

namespace V50_IDOMBackOffice.AspxArea.MasterData.Controllers
{
    public class TouristSiteController
    {
        public List<TouristSiteViewModel> Init()
        {
            return MasterDataRepository.GetTouristSiteViewModel();
        }

        public void AddTouristSite(TouristSiteViewModel model)
        {
             MasterDataRepository.AddMasterData(model);
        }

        public void UpdateTouristSite(TouristSiteViewModel model)
        {
            MasterDataRepository.UpdateMasterData(model);
        }

        public void DeleteTouristSite(string id)
        {
            MasterDataRepository.DeleteTouristSite(id);
        }

        public List<Data> GetRegionIds()
        {
            return MasterDataRepository.GetRegionSource();
        }

        public List<Data> GetCountryIds()
        {
            return MasterDataRepository.GetCountrySource();
        }

        public List<Data> GetPlaceIds()
        {
            return MasterDataRepository.GetPlaceSource();
        }
      
    }
}