using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.BookingTemplate.Models;
using V50_IDOMBackOffice.AspxArea.BookingTemplate.Repositorys;


namespace V50_IDOMBackOffice.AspxArea.BookingTemplate.Controllers
{
    public class StatusDataDocumentController
    {
        public List<StatusDataDocumentViewModel> Init()
        {
            return BookingTemplateDataRepository.GetStatusDataDocumentViewModel();

        }
        public void AddStatusDataDocument(StatusDataDocumentViewModel model)
        {
            BookingTemplateDataRepository.AddMasterData(model);
        }

        public StatusDataDocumentViewModel GetStatusDataDocument(string id)
        {
            return BookingTemplateDataRepository.GetStatusDataDocument(id);
        }
    }
}