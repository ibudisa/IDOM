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
    public partial class ProviderView : System.Web.UI.Page
    {
        ICoreController controller = new ProviderController();

        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        private void Bind()
        {
            GridProviderView.DataSource = controller.Init();
            GridProviderView.DataBind();
        }

        protected void GridProviderView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string id = e.Keys[0].ToString();
         
            controller.Delete(id);

            e.Cancel = true;
            GridProviderView.CancelEdit();

            Bind();
        }

        protected void GridProviderView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            CoreViewModel model = new CoreViewModel();
            model.Address = e.NewValues["Address"].ToString();
            model.Bank = e.NewValues["Bank"].ToString();
            model.City = e.NewValues["City"].ToString();
            model.Country = e.NewValues["Country"].ToString();
            model.IBAN = e.NewValues["IBAN"].ToString();
            model.Name = e.NewValues["Name"].ToString();
            model.PersonalIdentificationNumber = e.NewValues["PersonalIdentificationNumber"].ToString();
            model.ProviderId = e.NewValues["ProviderId"] == null ? 0 : (int)e.NewValues["ProviderId"];
            model.Title = e.NewValues["Title"].ToString();
            model.BookingEmail = e.NewValues["BookingEmail"].ToString();

            controller.Add(model);

            e.Cancel = true;
            GridProviderView.CancelEdit();

            Bind();
        }

        protected void GridProviderView_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var list = (List<CoreViewModel>)GridProviderView.DataSource;
            CoreViewModel model = list.Find(m => m.Id == e.Keys[0].ToString());
            model.Address = e.NewValues["Address"].ToString();
            model.Bank = e.NewValues["Bank"].ToString();
            model.City = e.NewValues["City"].ToString();
            model.Country = e.NewValues["Country"].ToString();
            model.IBAN = e.NewValues["IBAN"].ToString();
            model.Name = e.NewValues["Name"].ToString();
            model.PersonalIdentificationNumber = e.NewValues["PersonalIdentificationNumber"].ToString();
            model.ProviderId = e.NewValues["ProviderId"] == null ? 0 : (int)e.NewValues["ProviderId"];
            model.Title = e.NewValues["Title"].ToString();
            model.BookingEmail = e.NewValues["BookingEmail"].ToString();

            controller.Update(model);

            e.Cancel = true;
            GridProviderView.CancelEdit();

            Bind();
        }

        protected void GridProviderView_Init(object sender, EventArgs e)
        {
            GridProviderView.Columns["Id"].Visible = false;
        }

        protected void GridProviderView_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "ButtonProviderContacts")
            {
                ASPxGridView grid = sender as ASPxGridView;
                int index = e.VisibleIndex;
                string id = grid.GetRowValues(index, "Id").ToString();
                
                ASPxWebControl.RedirectOnCallback(VirtualPathUtility.ToAbsolute("~/AspxArea/Booking/Forms/ProviderDetailsView.aspx?id=" + id));
            }
            else if (e.ButtonID == "ButtonProviderBooking")
            {
                ASPxGridView grid = sender as ASPxGridView;
                int index = e.VisibleIndex;
                string id = grid.GetRowValues(index, "Id").ToString();

                ASPxWebControl.RedirectOnCallback(VirtualPathUtility.ToAbsolute("~/AspxArea/Booking/Forms/ProviderBookingDetailsView.aspx?id=" + id));
            }
        }

        protected void GridProviderView_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (GridProviderView.IsNewRowEditing)
                GridProviderView.DoRowValidation();
        }

        protected void GridProviderView_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

            GridValidation.ValidateLength("Address",2, sender, e);
            GridValidation.ValidateLength("Bank",2, sender, e);
            GridValidation.ValidateLength("City",2, sender, e);
            GridValidation.ValidateLength("Country",2, sender, e);
            GridValidation.ValidateLength("IBAN",2, sender, e);
            GridValidation.ValidateLength("PersonalIdentificationNumber",2, sender, e);
            GridValidation.ValidateLength("Title",2, sender, e);
            GridValidation.ValidateLength("BookingEmail",2, sender, e);
           
        }
    }
}