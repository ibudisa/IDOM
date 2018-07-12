using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.MasterData.Models;
using V50_IDOMBackOffice.AspxArea.MasterData.Repositorys;
using IdomOffice.Interface.BackOffice.MasterData;

namespace V50_IDOMBackOffice.AspxArea.MasterData.Controllers
{
    public class PlaceViewController
    {
        public List<PlaceViewModel> Init()
        {
            return MasterDataRepository.GetPlaceViewModel();
        }

        public void AddPlace(PlaceViewModel model)
        {
            MasterDataRepository.AddMasterData(model);
        }

        public void UpdatePlace(PlaceViewModel model)
        {
            MasterDataRepository.UpdateMasterData(model);
        }

        public void DeletePlace(string id)
        {
            MasterDataRepository.DeletePlace(id);
        }

        public List<Data> GetRegionIds()
        {
            return MasterDataRepository.GetRegionSource();
        }
    }
}