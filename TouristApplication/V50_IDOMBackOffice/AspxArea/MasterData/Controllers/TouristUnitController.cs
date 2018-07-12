using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.MasterData.Models;
using V50_IDOMBackOffice.AspxArea.MasterData.Repositorys;

namespace V50_IDOMBackOffice.AspxArea.MasterData.Controllers
{
    public class TouristUnitController
    {
        public List<TouristUnitViewModel> Init()
        {
            return TouristUnitRepository.GetTouristUnitViewModel();
        }

        public void AddTouristUnit(TouristUnitViewModel model)
        {
            MasterDataRepository.AddMasterData(model);
        }
        public void UpdateTouristUnit(TouristUnitViewModel model)
        {
            MasterDataRepository.UpdateMasterData(model);
        }

        public void DeleteTouristUnit(string  id)
        {
            MasterDataRepository.DeleteTouristUnit(id);
        }

        public bool ContainsUnitCode(string unitcode)
        {
          return TouristUnitRepository.TouristUnitContainsCode(unitcode);
        }

        public TouristUnitViewModel GetTouristUnit(string id)
        {
            return TouristUnitRepository.GetTouristUnitById(id);
        }

        public LayoutInfoViewModel GetLayoutInfo(TouristUnitViewModel model)
        {
            return MasterDataRepository.GetLayoutInfoModel(model);
        }

        public LayoutDatenViewModel GetLayoutDaten(TouristUnitViewModel model)
        {
            return MasterDataRepository.GetLayoutDatenModel(model);
        }

        public int GetTerraceType(TouristUnitViewModel model)
        {
            return MasterDataRepository.GetTerraceType(model);
        }

        public int GetSiteLocation(TouristUnitViewModel model)
        {
            return MasterDataRepository.GetSiteLocation(model);
        }

        public int GetSeaLocation(TouristUnitViewModel model)
        {
            return MasterDataRepository.GetSeaLocation(model);
        }

        public int GetPet(TouristUnitViewModel model)
        {
            return MasterDataRepository.GetPet(model);
        }

        public List<string> GetSiteCodes()
        {
            return MasterDataRepository.GetSiteCodes();
        }

        public string GetCountryFromSite(string sitecode)
        {
            return MasterDataRepository.GetCountryFromSite(sitecode);
        }

        public string GetRegionFromSite(string sitecode)
        {
            return MasterDataRepository.GetRegionFromSite(sitecode);
        }

        public string GetPlaceFromSite(string sitecode)
        {
            return MasterDataRepository.GetPlaceFromSite(sitecode);
        }

        public string GetSiteNameFromSite(string sitecode)
        {
            return MasterDataRepository.GetSiteNameFromSite(sitecode);
        }

        public TouristUnitViewModel GetTouristUnit(TouristUnitViewModel model)
        {
            return MasterDataRepository.GetTouristUnit(model);
        }
    }
}