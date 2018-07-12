using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V50_IDOMBackOffice.AspxArea.BookingTemplate.Models;
using V50_IDOMBackOffice.PlugIn.Controller;
using IdomOffice.Interface.BackOffice.BookingTemplate;


namespace V50_IDOMBackOffice.AspxArea.BookingTemplate.Repositorys
{
    public class BookingTemplateDataRepository
    {
        public static List<StatusDataDocumentViewModel> GetStatusDataDocumentViewModel()
        {
            var model = new List<StatusDataDocumentViewModel>();
            var manager = PlugInManager.GetApplicationDataManager();

            var statusdocuments = manager.GetStatusDocuments();

            foreach (var status in statusdocuments)
            {
                var m = new StatusDataDocumentViewModel();
                m.Id = status.Id;
                m.Receiver = status.Receiver;
                m.Status = status.Status;
                m.Text = status.Text;
                m.ValueId = status.ValueId;
                m.NewStatus = status.NewStatus;
                m.FormCode = status.FormCode;

                model.Add(m);
            }

            return model;
        }

        public static void AddMasterData(StatusDataDocumentViewModel model)
        {
            var manager = PlugInManager.GetApplicationDataManager();
            var status = new StatusDataDocument();
            status.Id = Guid.NewGuid().ToString();
            status.Receiver = model.Receiver;
            status.Status = model.Status;
            status.Text = model.Text;
            status.ValueId = model.ValueId;
            status.NewStatus = model.NewStatus;
            status.FormCode = model.FormCode;

            manager.AddApplicationData(status);
        }

        public static StatusDataDocumentViewModel GetStatusDataDocument(string id)
        {
            return GetStatusDataDocumentViewModel().Find(m => m.Id == id);
        }
    }
}