using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.MasterData.Models;
using V50_IDOMBackOffice.AspxArea.MasterData.Repositorys;


namespace V50_IDOMBackOffice.AspxArea.MasterData.Controllers
{
    public class CountryViewController
    {
        public List<CountryViewModel> Init()
        {
            return MasterDataRepository.GetCountryViewModel();
        }

        public void AddCountry(CountryViewModel model)
        {
            MasterDataRepository.AddMasterData(model);
        }
        public void UpdateCountry(CountryViewModel model)
        {
            MasterDataRepository.UpdateMasterData(model);
        }

        public void DeleteCountry(string id)
        {
            MasterDataRepository.DeleteCountry(id);
        }
        
    }
}