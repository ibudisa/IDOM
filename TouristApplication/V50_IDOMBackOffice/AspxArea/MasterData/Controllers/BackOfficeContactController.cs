using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.MasterData.Models;
using V50_IDOMBackOffice.AspxArea.MasterData.Repositorys;

namespace V50_IDOMBackOffice.AspxArea.MasterData.Controllers
{
    public class BackOfficeContactController
    {
        public List<BackOfficeContactViewModel> Init()
        {
            return MasterDataRepository.GetBackOfficeContactViewModel();
        }

        public void AddBackOfficeContact(BackOfficeContactViewModel model)
        {
            MasterDataRepository.AddMasterData(model);
        }

        public void UpdateBackOfficeContact(BackOfficeContactViewModel model)
        {
            MasterDataRepository.UpdateMasterData(model);
        }

        public void DeleteBackOfficeContact(string  id)
        {
            MasterDataRepository.DeleteBackOfficeContact(id);
        }

    }
}