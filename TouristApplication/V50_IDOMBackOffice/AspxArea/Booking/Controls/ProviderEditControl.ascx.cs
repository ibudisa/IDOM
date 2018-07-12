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

namespace V50_IDOMBackOffice.AspxArea.Booking.Controls
{
    public partial class ProviderEditControl : System.Web.UI.UserControl
    {
        public event EventHandler InitController;
        protected void OnInitController()
        {
            if (InitController != null)
            {
                InitController(this, new EventArgs());
            }
        }
        public ICoreController Controller { get; set; }
        public string ModelId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Izvrsi event za incijalizaciju controllera
            OnInitController();

            var model = Controller.GetData(ModelId);

            GridProviderContactView.DataSource = model.Contacts;
            GridProviderContactView.DataBind();

            GridNoteView.DataSource = model.Notes;
            GridNoteView.DataBind();

            var layoutdata = Controller.GetLayoutData(model);
            FormLayoutProvider.DataSource = layoutdata;
            FormLayoutProvider.DataBind();

        }


        protected void GridProviderContactView_Init(object sender, EventArgs e)
        {
            GridProviderContactView.Columns["Id"].Visible = false;
        }

        protected void GridProviderContactView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            List<ProviderContact> providercontacts = (List<ProviderContact>)GridProviderContactView.DataSource;
            string id = e.Keys[0].ToString();
            ProviderContact providercontact = providercontacts.Find(m => m.Id == id);

            providercontacts.Remove(providercontact);


            var model = Controller.GetData(ModelId);
            model.Contacts = providercontacts;
            Controller.Update(model);

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

            providercontact.Department = newValue["Department"].ToString()?? string.Empty;
            providercontact.Email = newValue["Email"].ToString()?? string.Empty;
            providercontact.FirstName = newValue["FirstName"].ToString()?? string.Empty;
            providercontact.LastName = newValue["LastName"].ToString()?? string.Empty;
            providercontact.MobilePhone = newValue["MobilePhone"].ToString()?? string.Empty;
            providercontact.Phone = newValue["Phone"].ToString()?? string.Empty;

            providercontacts.Add(providercontact);

            var model = Controller.GetData(ModelId);
            model.Contacts = providercontacts;
            Controller.Update(model);

            var Model = Controller.GetData(ModelId);

            e.Cancel = true;
            GridProviderContactView.CancelEdit();

            GridProviderContactView.DataSource = Model.Contacts; ;
            GridProviderContactView.DataBind();
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

            var model = Controller.GetData(ModelId);
            model.Contacts = providercontacts;
            Controller.Update(model);

            e.Cancel = true;
            GridProviderContactView.CancelEdit();

            GridProviderContactView.DataSource = providercontacts;
            GridProviderContactView.DataBind();
        }

        protected void GridNoteView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            List<Note> notes = (List<Note>)GridNoteView.DataSource;
            string id = e.Keys[0].ToString();
            Note note = notes.Find(m => m.Id == id);
           
            notes.Remove(note);         

            var model = Controller.GetData(ModelId);
            model.Notes = notes;
            Controller.Update(model);

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
            
            note.Date = newValue["Date"]==null? DateTime.Now: (DateTime)newValue["Date"];
            note.Text = newValue["Text"].ToString()?? string.Empty;
            note.Title = newValue["Title"].ToString()?? string.Empty;

            notes.Add(note);

            var model = Controller.GetData(ModelId);
            model.Notes = notes;
            Controller.Update(model);

            var Model = Controller.GetData(ModelId);

            e.Cancel = true;
            GridNoteView.CancelEdit();

            GridNoteView.DataSource = Model.Notes;
            GridNoteView.DataBind();
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

 
            var model = Controller.GetData(ModelId);
            model.Notes = notes;
            Controller.Update(model);

            e.Cancel = true;
            GridNoteView.CancelEdit();

            GridNoteView.DataSource = notes;
            GridNoteView.DataBind();
        }

        protected void GridNoteView_Init(object sender, EventArgs e)
        {
            GridNoteView.Columns["Id"].Visible = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            string PersonaliIdentificationNumber = FormLayoutProvider.GetNestedControlValueByFieldName("PersonalIdentificationNumber") == null ? string.Empty : FormLayoutProvider.GetNestedControlValueByFieldName("PersonalIdentificationNumber").ToString();
            string Name = FormLayoutProvider.GetNestedControlValueByFieldName("Name") == null ? string.Empty : FormLayoutProvider.GetNestedControlValueByFieldName("Name").ToString();
            string Bank = FormLayoutProvider.GetNestedControlValueByFieldName("Bank") == null ? string.Empty : FormLayoutProvider.GetNestedControlValueByFieldName("Bank").ToString();
            string IBAN = FormLayoutProvider.GetNestedControlValueByFieldName("IBAN") == null ? string.Empty : FormLayoutProvider.GetNestedControlValueByFieldName("IBAN").ToString();
            string Country = FormLayoutProvider.GetNestedControlValueByFieldName("Country") == null ? string.Empty : FormLayoutProvider.GetNestedControlValueByFieldName("Country").ToString();
            string City = FormLayoutProvider.GetNestedControlValueByFieldName("City") == null ? string.Empty : FormLayoutProvider.GetNestedControlValueByFieldName("City").ToString();
            string Address = FormLayoutProvider.GetNestedControlValueByFieldName("Address") == null ? string.Empty : FormLayoutProvider.GetNestedControlValueByFieldName("Address").ToString();

            var model = Controller.GetData(ModelId);
            model.IBAN = IBAN;
            model.Name = Name;
            model.Bank = Bank;
            model.PersonalIdentificationNumber = PersonaliIdentificationNumber;
            model.Country = Country;
            model.City = City;
            model.Address = Address;

            Controller.Update(model);


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
    }
}