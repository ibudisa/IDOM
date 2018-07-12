using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using V50_IDOMBackOffice.AspxArea.MasterData.Models;
using V50_IDOMBackOffice.AspxArea.MasterData.Controllers;
using V50_IDOMBackOffice.AspxArea.Helper;
using DevExpress.Web;

namespace V50_IDOMBackOffice.AspxArea.MasterData.Forms
{
    public partial class BackOfficeContactView : System.Web.UI.Page
    {
        BackOfficeContactController controller = new BackOfficeContactController();

        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        private void Bind()
        {
            GridBackOfficeContactView.DataSource = controller.Init();
            GridBackOfficeContactView.DataBind();
        }

        protected void GridBackOfficeContactView_Init(object sender, EventArgs e)
        {
            GridBackOfficeContactView.Columns["Id"].Visible = false;
        }

        protected void GridBackOfficeContactView_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (GridBackOfficeContactView.IsNewRowEditing)
                GridBackOfficeContactView.DoRowValidation();
        }

        protected void GridBackOfficeContactView_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            GridValidation.ValidateLength("Address",2, sender, e);
            GridValidation.ValidateLength("City",2, sender, e);
            GridValidation.ValidateLength("CompanyName",2, sender, e);
            GridValidation.ValidateLength("Country",2, sender, e);
            GridValidation.ValidateLength("Email",2, sender, e);
            GridValidation.ValidateLength("FirstName",2, sender, e);
            GridValidation.ValidateLength("LastName",2, sender, e);
        }

        protected void GridBackOfficeContactView_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            List<BackOfficeContactViewModel> list = (List<BackOfficeContactViewModel>)GridBackOfficeContactView.DataSource;
            var model = list.Find(m => m.Id == e.Keys[0].ToString());
            model.Address = e.NewValues["Address"].ToString() ?? string.Empty;
            model.City = e.NewValues["City"].ToString() ?? string.Empty;
            model.CompanyName = e.NewValues["CompanyName"].ToString() ?? string.Empty;
            model.Country = e.NewValues["Country"].ToString() ?? string.Empty;
            model.Email = e.NewValues["Email"].ToString() ?? string.Empty;
            model.FirstName = e.NewValues["FirstName"].ToString() ?? string.Empty;
            model.LastName = e.NewValues["LastName"].ToString() ?? string.Empty;

            controller.UpdateBackOfficeContact(model);

            e.Cancel = true;
            GridBackOfficeContactView.CancelEdit();

            Bind();
        }

        protected void GridBackOfficeContactView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            BackOfficeContactViewModel model = new BackOfficeContactViewModel();
            model.Address = e.NewValues["Address"].ToString() ?? string.Empty;
            model.City = e.NewValues["City"].ToString() ?? string.Empty;
            model.CompanyName = e.NewValues["CompanyName"].ToString() ?? string.Empty;
            model.Country = e.NewValues["Country"].ToString() ?? string.Empty;
            model.Email = e.NewValues["Email"].ToString() ?? string.Empty;
            model.FirstName = e.NewValues["FirstName"].ToString() ?? string.Empty;
            model.LastName = e.NewValues["LastName"].ToString() ?? string.Empty;

            controller.AddBackOfficeContact(model);

            e.Cancel = true;
            GridBackOfficeContactView.CancelEdit();

            Bind();
        }

        protected void GridBackOfficeContactView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string id = e.Keys[0].ToString();
           
            controller.DeleteBackOfficeContact(id);

            e.Cancel = true;
            GridBackOfficeContactView.CancelEdit();

            Bind();
        }
    }
}