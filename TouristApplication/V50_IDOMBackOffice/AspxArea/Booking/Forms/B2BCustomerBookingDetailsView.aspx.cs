using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdomOffice.Interface.BackOffice.Booking.Core;
using V50_IDOMBackOffice.PlugIn.Controller;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using V50_IDOMBackOffice.AspxArea.Booking.Controllers;
using V50_IDOMBackOffice.AspxArea.Helper;
using DevExpress.Web;

namespace V50_IDOMBackOffice.AspxArea.Booking.Forms
{
    public partial class B2BCustomerBookingDetailsView : System.Web.UI.Page
    {

        ICoreController controller = new B2BCustomerController();
        string ModelId = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            Uri u = HttpContext.Current.Request.Url;
            ModelId = HttpUtility.ParseQueryString(u.Query).Get("id");

            var customerb2bmodel = controller.GetData(ModelId);

            var layoutmodel = controller.GetCoreLayoutData(customerb2bmodel);
            LayoutB2BCustomer.DataSource = layoutmodel;
            LayoutB2BCustomer.DataBind();

            var modelbookingprocess = controller.GetDataByProviderId(customerb2bmodel.ProviderId);
            GridBookingProcessView.DataSource = modelbookingprocess;
            GridBookingProcessView.DataBind();

            var model = controller.GetData(ModelId);
            GridNoteView.DataSource = model.Notes;
            GridNoteView.DataBind();

            GridProviderContactView.DataSource = model.Contacts;
            GridProviderContactView.DataBind();
        }

        protected void GridBookingProcessView_Init(object sender, EventArgs e)
        {
            GridBookingProcessView.Columns["Id"].Visible = false;
        }

        protected void GridBookingProcessView_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "ButtonBookingDetails")
            {
                ASPxGridView grid = sender as ASPxGridView;
                int index = e.VisibleIndex;
                string id = grid.GetRowValues(index, "Id").ToString();

                ASPxWebControl.RedirectOnCallback(VirtualPathUtility.ToAbsolute("~/AspxArea/Booking/Forms/BookingProcessDetailsProView.aspx?id=" + id));
            }
        }

        protected void GridNoteView_Init(object sender, EventArgs e)
        {
            GridNoteView.Columns["Id"].Visible = false;
        }

        protected void GridNoteView_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (GridNoteView.IsNewRowEditing)
                GridNoteView.DoRowValidation();
        }

        protected void GridNoteView_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            GridValidation.ValidateLength("Text",2, sender, e);
            GridValidation.ValidateLength("Title",2, sender, e);
        }

        protected void GridNoteView_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            List<Note> notes = (List<Note>)GridNoteView.DataSource;
            string id = e.Keys[0].ToString();
            Note note = notes.Find(m => m.Id == id);
            var newValue = e.NewValues;
             note.Date = newValue["Date"] == null ? DateTime.Now : (DateTime)newValue["Date"];
            note.Text = newValue["Text"].ToString() ?? string.Empty;
            note.Title = newValue["Title"].ToString() ?? string.Empty;

 
            var model = controller.GetData(ModelId);
            model.Notes = notes;
            controller.Update(model);

            e.Cancel = true;
            GridNoteView.CancelEdit();

            GridNoteView.DataSource = notes;
            GridNoteView.DataBind();
        }

        protected void GridNoteView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            List<Note> notes = (List<Note>)GridNoteView.DataSource;

            Note note = new Note();
            var newValue = e.NewValues;

            note.Date = newValue["Date"] == null ? DateTime.Now : (DateTime)newValue["Date"];
            note.Text = newValue["Text"].ToString() ?? string.Empty;
            note.Title = newValue["Title"].ToString() ?? string.Empty;

            notes.Add(note);

            var model = controller.GetData(ModelId);
            model.Notes = notes;
            controller.Update(model);


            var Model = controller.GetData(ModelId);

            e.Cancel = true;
            GridNoteView.CancelEdit();

            GridNoteView.DataSource = Model.Notes;
            GridNoteView.DataBind();
        }

        protected void GridNoteView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            List<Note> notes = (List<Note>)GridNoteView.DataSource;
            string id = e.Keys[0].ToString();
            Note note = notes.Find(m => m.Id == id);

            notes.Remove(note);

            var model = controller.GetData(ModelId);
            model.Notes = notes;
            controller.Update(model);

            e.Cancel = true;
            GridNoteView.CancelEdit();

            GridNoteView.DataSource = notes;
            GridNoteView.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string PersonaliIdentificationNumber = LayoutB2BCustomer.GetNestedControlValueByFieldName("PersonalIdentificationNumber") == null ? string.Empty : LayoutB2BCustomer.GetNestedControlValueByFieldName("PersonalIdentificationNumber").ToString();
            string Name = LayoutB2BCustomer.GetNestedControlValueByFieldName("Name") == null ? string.Empty : LayoutB2BCustomer.GetNestedControlValueByFieldName("Name").ToString();
            string Bank = LayoutB2BCustomer.GetNestedControlValueByFieldName("Bank") == null ? string.Empty : LayoutB2BCustomer.GetNestedControlValueByFieldName("Bank").ToString();
            string IBAN = LayoutB2BCustomer.GetNestedControlValueByFieldName("IBAN") == null ? string.Empty : LayoutB2BCustomer.GetNestedControlValueByFieldName("IBAN").ToString();
            string Country = LayoutB2BCustomer.GetNestedControlValueByFieldName("Country") == null ? string.Empty : LayoutB2BCustomer.GetNestedControlValueByFieldName("Country").ToString();
            string City = LayoutB2BCustomer.GetNestedControlValueByFieldName("City") == null ? string.Empty : LayoutB2BCustomer.GetNestedControlValueByFieldName("City").ToString();
            string Address = LayoutB2BCustomer.GetNestedControlValueByFieldName("Address") == null ? string.Empty : LayoutB2BCustomer.GetNestedControlValueByFieldName("Address").ToString();
            int ProviderId = LayoutB2BCustomer.GetNestedControlValueByFieldName("ProviderId") == null ? 0 : (int)LayoutB2BCustomer.GetNestedControlValueByFieldName("ProviderId");
            string BookingEmail = LayoutB2BCustomer.GetNestedControlValueByFieldName("BookingEmail") == null ? string.Empty : LayoutB2BCustomer.GetNestedControlValueByFieldName("BookingEmail").ToString();
            string Title = LayoutB2BCustomer.GetNestedControlValueByFieldName("Title") == null ? string.Empty : LayoutB2BCustomer.GetNestedControlValueByFieldName("Title").ToString();

            var model = controller.GetData(ModelId);
            model.IBAN = IBAN;
            model.Name = Name;
            model.Bank = Bank;
            model.PersonalIdentificationNumber = PersonaliIdentificationNumber;
            model.Country = Country;
            model.City = City;
            model.Address = Address;
            model.Title = Title;
            model.ProviderId = ProviderId;
            model.BookingEmail = BookingEmail;

            controller.Update(model);
        }

        protected void GridProviderContactView_Init(object sender, EventArgs e)
        {
            GridProviderContactView.Columns["Id"].Visible = false;
        }

        protected void GridProviderContactView_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (GridProviderContactView.IsNewRowEditing)
                GridProviderContactView.DoRowValidation();
        }

        protected void GridProviderContactView_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            GridValidation.ValidateLength("Department",2, sender, e);
            GridValidation.ValidateLength("Email",2, sender, e);
            GridValidation.ValidateLength("FirstName",2, sender, e);
            GridValidation.ValidateLength("LastName",2, sender, e);
            GridValidation.ValidateLength("Phone",2, sender, e);
            GridValidation.ValidateLength("MobilePhone",2, sender, e);
        }

        protected void GridProviderContactView_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            List<ProviderContact> providercontacts = (List<ProviderContact>)GridProviderContactView.DataSource;
            string id = e.Keys[0].ToString();
            ProviderContact providercontact = providercontacts.Find(m => m.Id == id);
            var newValue = e.NewValues;
            providercontact.Department = newValue["Department"].ToString() ?? string.Empty;
            providercontact.Email = newValue["Email"].ToString() ?? string.Empty;
            providercontact.FirstName = newValue["FirstName"].ToString() ?? string.Empty;
            providercontact.LastName = newValue["LastName"].ToString() ?? string.Empty;
            providercontact.MobilePhone = newValue["MobilePhone"].ToString() ?? string.Empty;
            providercontact.Phone = newValue["Phone"].ToString() ?? string.Empty;

            var model = controller.GetData(ModelId);
            model.Contacts = providercontacts;
            controller.Update(model);

            e.Cancel = true;
            GridProviderContactView.CancelEdit();

            GridProviderContactView.DataSource = providercontacts;
            GridProviderContactView.DataBind();
        }

        protected void GridProviderContactView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            List<ProviderContact> providercontacts = (List<ProviderContact>)GridProviderContactView.DataSource;

            ProviderContact providercontact = new ProviderContact();
            var newValue = e.NewValues;

            providercontact.Department = newValue["Department"].ToString() ?? string.Empty;
            providercontact.Email = newValue["Email"].ToString() ?? string.Empty;
            providercontact.FirstName = newValue["FirstName"].ToString() ?? string.Empty;
            providercontact.LastName = newValue["LastName"].ToString() ?? string.Empty;
            providercontact.MobilePhone = newValue["MobilePhone"].ToString() ?? string.Empty;
            providercontact.Phone = newValue["Phone"].ToString() ?? string.Empty;

            providercontacts.Add(providercontact);

            var model = controller.GetData(ModelId);
            model.Contacts = providercontacts;
            controller.Update(model);

            var Model = controller.GetData(ModelId);

            e.Cancel = true;
            GridProviderContactView.CancelEdit();

            GridProviderContactView.DataSource = Model.Contacts; ;
            GridProviderContactView.DataBind();
        }

        protected void GridProviderContactView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            List<ProviderContact> providercontacts = (List<ProviderContact>)GridProviderContactView.DataSource;
            string id = e.Keys[0].ToString();
            ProviderContact providercontact = providercontacts.Find(m => m.Id == id);

            providercontacts.Remove(providercontact);


            var model = controller.GetData(ModelId);
            model.Contacts = providercontacts;
            controller.Update(model);

            e.Cancel = true;
            GridProviderContactView.CancelEdit();

            GridProviderContactView.DataSource = providercontacts;
            GridProviderContactView.DataBind();
        }
    }
}