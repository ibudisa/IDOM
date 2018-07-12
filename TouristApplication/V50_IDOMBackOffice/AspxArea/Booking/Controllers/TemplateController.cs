using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using V50_IDOMBackOffice.AspxArea.Booking.Repositorys;

namespace V50_IDOMBackOffice.AspxArea.Booking.Controllers
{
    public class TemplateController
    {
        public List<TemplateViewModel> Init()
        {
            var list = BookingDataRepository.GetTemplateViewModel();
            return list;
        }
        public void AddTemplate(TemplateViewModel model)
        {
            BookingDataRepository.AddMasterData(model);
        }
        public void UpdateTemplate(TemplateViewModel model)
        {
            BookingDataRepository.UpdateMasterData(model);
        }

        public void DeleteTemplate(TemplateViewModel model)
        {
            BookingDataRepository.DeleteMasterData(model);
        }

        public TemplateViewModel GetTemplate(string id)
        {
            var templatemodel = BookingDataRepository.GetTemplate(id);
            return templatemodel;
        }

       

        public List<TemplateViewModel> GetTemplatesByStatusId(string statusid)
        {
            return BookingDataRepository.GetTemplatesByStatusId(statusid);
        }

        public TemplateViewModel GetTemplateByStatusIdLast(string statusid)
        {
            return BookingDataRepository.GetTemplateByStatusIdLast(statusid);
        }

        public Dictionary<string, object> GetValues(BookingProcessViewModel model)
        {
            return BookingDataRepository.GenerateData(model);
        }

        public string GetData(string text,Dictionary<string,object> data)
        {
            return BookingDataRepository.GetText(text, data);
        }

        public string GetTable()
        {
            return BookingDataRepository.CreateTable();
        }

        public string GetCustomerTable()
        {
            return BookingDataRepository.CreateTableCustomer();
        }
    }
}