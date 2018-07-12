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
    public partial class CustomerDetailsView : System.Web.UI.Page
    {
        CustomerController controller = new CustomerController();
        string modelid = String.Empty;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            Uri u = HttpContext.Current.Request.Url;
            modelid = HttpUtility.ParseQueryString(u.Query).Get("id");
            var layoutmodel = controller.GetCustomerLayout(modelid);
            FormLayoutCustomer.DataSource = layoutmodel;
            FormLayoutCustomer.DataBind();

            var modelbookingprocess = controller.GetBookingProcessesByCustomerId(layoutmodel.CustomerNr);
            GridBookingProcessView.DataSource = modelbookingprocess;
            GridBookingProcessView.DataBind();

            var model = controller.GetCustomer(modelid);
            GridNoteView.DataSource = model.Notes;
            GridNoteView.DataBind();

            GridCustomerEmailView.DataSource = model.Contacts;
            GridCustomerEmailView.DataBind();

            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string CustomerNr = FormLayoutCustomer.GetNestedControlValueByFieldName("CustomerNr") == null ? string.Empty : FormLayoutCustomer.GetNestedControlValueByFieldName("CustomerNr").ToString();
            string FirstName = FormLayoutCustomer.GetNestedControlValueByFieldName("FirstName") == null ? string.Empty : FormLayoutCustomer.GetNestedControlValueByFieldName("FirstName").ToString();
            string LastName = FormLayoutCustomer.GetNestedControlValueByFieldName("LastName") == null ? string.Empty : FormLayoutCustomer.GetNestedControlValueByFieldName("LastName").ToString();
            string Adress = FormLayoutCustomer.GetNestedControlValueByFieldName("Adress") == null ? string.Empty : FormLayoutCustomer.GetNestedControlValueByFieldName("Adress").ToString();
            string ZipCode = FormLayoutCustomer.GetNestedControlValueByFieldName("ZipCode") == null ? string.Empty : FormLayoutCustomer.GetNestedControlValueByFieldName("ZipCode").ToString();
            string Place = FormLayoutCustomer.GetNestedControlValueByFieldName("Place") == null ? string.Empty : FormLayoutCustomer.GetNestedControlValueByFieldName("Place").ToString();
            string Country = FormLayoutCustomer.GetNestedControlValueByFieldName("Country") == null ? string.Empty : FormLayoutCustomer.GetNestedControlValueByFieldName("Country").ToString();
            string Phone = FormLayoutCustomer.GetNestedControlValueByFieldName("Phone") == null ? string.Empty : FormLayoutCustomer.GetNestedControlValueByFieldName("Phone").ToString();
            string MobilePhone = FormLayoutCustomer.GetNestedControlValueByFieldName("MobilePhone") == null ? string.Empty : FormLayoutCustomer.GetNestedControlValueByFieldName("MobilePhone").ToString();
            string EMail = FormLayoutCustomer.GetNestedControlValueByFieldName("EMail") == null ? string.Empty : FormLayoutCustomer.GetNestedControlValueByFieldName("EMail").ToString();

            var model = controller.GetCustomer(modelid);
            model.Adress = Adress;
            model.Country = Country;
            model.CustomerNr = Int32.Parse(CustomerNr);
            model.EMail = EMail;
            model.FirstName = FirstName;
            model.LastName = LastName;
            model.MobilePhone = MobilePhone;
            model.Phone = Phone;
            model.Place = Place;
            model.ZipCode = ZipCode;

            controller.UpdateCustomer(model);
           
        }

        protected void GridBookingProcessView_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridViewEditorEventArgs e)
        {

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
            notes.Remove(note);
            note.Date = newValue["Date"] == null ? DateTime.Now : (DateTime)newValue["Date"];
            note.Text = newValue["Text"].ToString() ?? string.Empty;
            note.Title = newValue["Title"].ToString() ?? string.Empty;

            notes.Add(note);

            var model = controller.GetCustomer(modelid);
            model.Notes = notes;
            controller.UpdateCustomer(model);

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

            var model = controller.GetCustomer(modelid);
            model.Notes = notes;
            controller.UpdateCustomer(model);


            var Model = controller.GetCustomer(modelid);

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

            var model = controller.GetCustomer(modelid);
            model.Notes = notes;
            controller.UpdateCustomer(model);

            e.Cancel = true;
            GridNoteView.CancelEdit();

            GridNoteView.DataSource = notes;
            GridNoteView.DataBind();
        }

        public List<CustomerContact> Get()
        {
            return new List<CustomerContact>();
        }

        protected void GridCustomerEmailView_Init(object sender, EventArgs e)
        {
            GridCustomerEmailView.Columns["Id"].Visible = false;
        }

        protected void GridCustomerEmailView_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (GridCustomerEmailView.IsNewRowEditing)
                GridCustomerEmailView.DoRowValidation();
        }

        protected void GridCustomerEmailView_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            GridValidation.ValidateLength("Email",2, sender, e);
        }

        protected void GridCustomerEmailView_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            List<CustomerContact> contacts = (List<CustomerContact>)GridCustomerEmailView.DataSource;
            string id = e.Keys[0].ToString();
            CustomerContact contact = contacts.Find(m => m.Id == id);
            var newValue = e.NewValues;
            contacts.Remove(contact);
            contact.Email = newValue["Email"].ToString();

            contacts.Add(contact);

            var model = controller.GetCustomer(modelid);
            model.Contacts = contacts;
            controller.UpdateCustomer(model);

            e.Cancel = true;
            GridCustomerEmailView.CancelEdit();

            GridCustomerEmailView.DataSource = contacts;
            GridCustomerEmailView.DataBind();
        }

        protected void GridCustomerEmailView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            List<CustomerContact> contacts = (List<CustomerContact>)GridCustomerEmailView.DataSource;
            var newValue = e.NewValues;
            CustomerContact contact = new CustomerContact();

            contact.Email = newValue["Email"].ToString();

            contacts.Add(contact);

            var model = controller.GetCustomer(modelid);
            model.Contacts = contacts;
            controller.UpdateCustomer(model);


            var Model = controller.GetCustomer(modelid);
            e.Cancel = true;
            GridCustomerEmailView.CancelEdit();

            GridCustomerEmailView.DataSource = Model.Contacts;
            GridCustomerEmailView.DataBind();
        }

        protected void GridCustomerEmailView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            List<CustomerContact> contacts = (List<CustomerContact>)GridCustomerEmailView.DataSource;
            string id = e.Keys[0].ToString();
            CustomerContact contact = contacts.Find(m => m.Id == id);
            
            contacts.Remove(contact);
          

            var model = controller.GetCustomer(modelid);
            model.Contacts = contacts;
            controller.UpdateCustomer(model);

            e.Cancel = true;
            GridNoteView.CancelEdit();

            GridCustomerEmailView.DataSource = contacts;
            GridCustomerEmailView.DataBind();
        }
    }
}