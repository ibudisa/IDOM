using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using V50_IDOMBackOffice.AspxArea.Booking.Controllers;
using IdomOffice.Interface.BackOffice.Booking;
using V50_IDOMBackOffice.AspxArea.Helper;
using DevExpress.Web;

namespace V50_IDOMBackOffice.AspxArea.Booking.Forms
{
    public partial class B2BCustomerView : System.Web.UI.Page
    {
        ICoreController controller = new B2BCustomerController();

        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        private void Bind()
        {
            GridB2BCustomerView.DataSource = controller.Init();
            GridB2BCustomerView.DataBind();
        }

        protected void GridB2BCustomerView_Init(object sender, EventArgs e)
        {
            GridB2BCustomerView.Columns["Id"].Visible = false;
        }

        protected void GridB2BCustomerView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string id = e.Keys[0].ToString();
          
            controller.Delete(id);

            e.Cancel = true;
            GridB2BCustomerView.CancelEdit();

            Bind();
        }

        protected void GridB2BCustomerView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            CoreViewModel model = new CoreViewModel();
            model.Address = e.NewValues["Address"].ToString();
            model.Bank = e.NewValues["Bank"].ToString();
            model.City = e.NewValues["City"].ToString();
            model.Country = e.NewValues["Country"].ToString();
            model.IBAN = e.NewValues["IBAN"].ToString();
            model.Name = e.NewValues["Name"].ToString();
            model.PersonalIdentificationNumber = e.NewValues["PersonalIdentificationNumber"].ToString();
            model.ProviderId = (int)e.NewValues["ProviderId"];
            controller.Add(model);

            e.Cancel = true;
            GridB2BCustomerView.CancelEdit();

            Bind();
        }

        protected void GridB2BCustomerView_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var list = (List<CoreViewModel>)GridB2BCustomerView.DataSource;
            CoreViewModel model = list.Find(m => m.Id == e.Keys[0].ToString());
            model.Address = e.NewValues["Address"].ToString();
            model.Bank = e.NewValues["Bank"].ToString();
            model.City = e.NewValues["City"].ToString();
            model.Country = e.NewValues["Country"].ToString();
            model.IBAN = e.NewValues["IBAN"].ToString();
            model.Name = e.NewValues["Name"].ToString();
            model.PersonalIdentificationNumber = e.NewValues["PersonalIdentificationNumber"].ToString();
            model.ProviderId = (int)e.NewValues["ProviderId"];
            controller.Update(model);

            e.Cancel = true;
            GridB2BCustomerView.CancelEdit();

            Bind();
        }

        protected void GridB2BCustomerView_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            int index = e.VisibleIndex;
            string id = grid.GetRowValues(index, "Id").ToString();

            if (e.ButtonID=="ButtonContacts")
            {
                ASPxWebControl.RedirectOnCallback(VirtualPathUtility.ToAbsolute("~/AspxArea/Booking/Forms/B2BCustomerDetailsView.aspx?id=" + id));
            }
            if (e.ButtonID == "ButtonBookingProcess")
            {
                ASPxWebControl.RedirectOnCallback(VirtualPathUtility.ToAbsolute("~/AspxArea/Booking/Forms/B2BCustomerBookingDetailsView.aspx?id=" + id));
            }
        }

        protected void GridB2BCustomerView_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (GridB2BCustomerView.IsNewRowEditing)
                GridB2BCustomerView.DoRowValidation();
        }

        protected void GridB2BCustomerView_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            GridValidation.ValidateLength("Address",2, sender, e);
            GridValidation.ValidateLength("Bank",2, sender, e);
            GridValidation.ValidateLength("City",2, sender, e);
            GridValidation.ValidateLength("Country",2, sender, e);
            GridValidation.ValidateLength("IBAN",2, sender, e);
            GridValidation.ValidateLength("Name",2, sender, e);
        }
    }
}