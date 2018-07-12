using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.MasterData.Models;
using V50_IDOMBackOffice.AspxArea.MasterData.Repositorys;
using IdomOffice.Interface.BackOffice.MasterData;

namespace V50_IDOMBackOffice.AspxArea.MasterData.Controllers
{
    public class RegionViewController
    {
        public List<RegionViewModel> Init()
        {
            return MasterDataRepository.GetRegionViewModel();
        }

        public void AddRegion(RegionViewModel model)
        {
            MasterDataRepository.AddMasterData(model);
        }

        public void UpdateRegion(RegionViewModel model)
        {
            MasterDataRepository.UpdateMasterData(model);
        }

        public void DeleteRegion(string id)
        {
            MasterDataRepository.DeleteRegion(id);
        }
        public List<Data> GetCountryIds()
        {
            return MasterDataRepository.GetCountrySource();
        }
    }
}