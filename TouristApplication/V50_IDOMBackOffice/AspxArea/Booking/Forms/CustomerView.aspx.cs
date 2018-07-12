using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using V50_IDOMBackOffice.AspxArea.Booking.Controllers;
using V50_IDOMBackOffice.AspxArea.Helper;
using DevExpress.Web;

namespace V50_IDOMBackOffice.AspxArea.Booking.Forms
{
    public partial class CustomerView : System.Web.UI.Page
    {
        CustomerController controller = new CustomerController();

        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        public List<CustomerViewModel> Get()
        {
            return new List<CustomerViewModel>();
        }

        private void Bind()
        {
            GridCustomerView.DataSource = controller.Init();
            GridCustomerView.DataBind();
        }

        protected void GridCustomerView_DataBinding(object sender, EventArgs e)
        {

        }

        protected void GridCustomerView_Init(object sender, EventArgs e)
        {
            GridCustomerView.Columns["id"].Visible = false;
        }

        protected void GridCustomerView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string id = e.Keys[0].ToString();
           
            controller.DeleteCustomer(id);

            e.Cancel = true;
            GridCustomerView.CancelEdit();

            Bind();
        }

        protected void GridCustomerView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            CustomerViewModel model = new CustomerViewModel();
            model.Adress = e.NewValues["Adress"].ToString();
            model.Country = e.NewValues["Country"].ToString();
            model.CustomerNr = e.NewValues["CustomerNr"] == null ? 0 : (int)e.NewValues["CustomerNr"];
            model.EMail = e.NewValues["EMail"].ToString();
            model.FirstName = e.NewValues["FirstName"].ToString();
            model.LastName = e.NewValues["LastName"].ToString();
            model.MobilePhone = e.NewValues["MobilePhone"].ToString();
            model.Phone = e.NewValues["Phone"].ToString();
            model.Place = e.NewValues["Place"].ToString();
            model.Salutation = e.NewValues["Salutation"].ToString();
            model.ZipCode = e.NewValues["ZipCode"].ToString();

            controller.AddCustomer(model);

            e.Cancel = true;
            GridCustomerView.CancelEdit();

            Bind();
        }

        protected void GridCustomerView_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var list = (List<CustomerViewModel>)GridCustomerView.DataSource;
            CustomerViewModel model = list.Find(m => m.id == e.Keys[0].ToString());
            model.Adress = e.NewValues["Adress"].ToString();
            model.Country = e.NewValues["Country"].ToString();
            model.CustomerNr = e.NewValues["CustomerNr"] == null ? 0 : (int)e.NewValues["CustomerNr"];
            model.EMail = e.NewValues["EMail"].ToString();
            model.FirstName = e.NewValues["FirstName"].ToString();
            model.LastName = e.NewValues["LastName"].ToString();
            model.MobilePhone = e.NewValues["MobilePhone"].ToString();
            model.Phone = e.NewValues["Phone"].ToString();
            model.Place = e.NewValues["Place"].ToString();
            model.Salutation = e.NewValues["Salutation"].ToString();
            model.ZipCode = e.NewValues["ZipCode"].ToString();

            controller.UpdateCustomer(model);

            e.Cancel = true;
            GridCustomerView.CancelEdit();

            Bind();
        }

        protected void GridCustomerView_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID== "ButtonCustomerDetails")
            {
                ASPxGridView grid = sender as ASPxGridView;
                int index = e.VisibleIndex;
                string id = grid.GetRowValues(index, "id").ToString();

                ASPxWebControl.RedirectOnCallback(VirtualPathUtility.ToAbsolute("~/AspxArea/Booking/Forms/CustomerDetailsView.aspx?id=" + id));
            }
        }

        protected void GridCustomerView_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (GridCustomerView.IsNewRowEditing)
                GridCustomerView.DoRowValidation();
        }

        protected void GridCustomerView_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            GridValidation.ValidateLength("Adress",2, sender, e);
            GridValidation.ValidateLength("Country",2, sender, e);
            GridValidation.ValidateLength("EMail",2, sender, e);
            GridValidation.ValidateLength("FirstName",2, sender, e);
            GridValidation.ValidateLength("LastName",2, sender, e);
            GridValidation.ValidateLength("MobilePhone",2, sender, e);
            GridValidation.ValidateLength("Phone",2, sender, e);
            GridValidation.ValidateLength("Place",2, sender, e);
            GridValidation.ValidateLength("Salutation",2, sender, e);
            GridValidation.ValidateLength("ZipCode",2, sender, e);
        }
    }
}