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
    public partial class ProviderBookingDetailsView : System.Web.UI.Page
    {

        ICoreController controller = new ProviderController();
        string ModelId = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            Uri u = HttpContext.Current.Request.Url;
            ModelId = HttpUtility.ParseQueryString(u.Query).Get("id");

            var providermodel = controller.GetData(ModelId);

            var layoutmodel = controller.GetCoreLayoutData(providermodel);
            LayoutProvider.DataSource = layoutmodel;
            LayoutProvider.DataBind();

            var modelbookingprocess = controller.GetDataByProviderId(providermodel.ProviderId);
            GridBookingProcessView.DataSource = modelbookingprocess;
            GridBookingProcessView.DataBind();

            var model = controller.GetData(ModelId);
            GridNoteView.DataSource = model.Notes;
            GridNoteView.DataBind();

            GridProviderContactView.DataSource = model.Contacts;
            GridProviderContactView.DataBind();

            GridCancellationView.DataSource = model.Cancellations;
            GridCancellationView.DataBind();
        }

        public List<CancellationCost> GetList()
        {
            return new List<CancellationCost>();
        }

      

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string PersonaliIdentificationNumber = LayoutProvider.GetNestedControlValueByFieldName("PersonalIdentificationNumber") == null ? string.Empty : LayoutProvider.GetNestedControlValueByFieldName("PersonalIdentificationNumber").ToString();
            string Name = LayoutProvider.GetNestedControlValueByFieldName("Name") == null ? string.Empty : LayoutProvider.GetNestedControlValueByFieldName("Name").ToString();
            string Bank = LayoutProvider.GetNestedControlValueByFieldName("Bank") == null ? string.Empty : LayoutProvider.GetNestedControlValueByFieldName("Bank").ToString();
            string IBAN = LayoutProvider.GetNestedControlValueByFieldName("IBAN") == null ? string.Empty : LayoutProvider.GetNestedControlValueByFieldName("IBAN").ToString();
            string Country = LayoutProvider.GetNestedControlValueByFieldName("Country") == null ? string.Empty : LayoutProvider.GetNestedControlValueByFieldName("Country").ToString();
            string City = LayoutProvider.GetNestedControlValueByFieldName("City") == null ? string.Empty : LayoutProvider.GetNestedControlValueByFieldName("City").ToString();
            string Address = LayoutProvider.GetNestedControlValueByFieldName("Address") == null ? string.Empty : LayoutProvider.GetNestedControlValueByFieldName("Address").ToString();
            int ProviderId = LayoutProvider.GetNestedControlValueByFieldName("ProviderId") == null ? 0 : (int)LayoutProvider.GetNestedControlValueByFieldName("ProviderId");
            string BookingEmail = LayoutProvider.GetNestedControlValueByFieldName("BookingEmail") == null ? string.Empty : LayoutProvider.GetNestedControlValueByFieldName("BookingEmail").ToString();
            string Title = LayoutProvider.GetNestedControlValueByFieldName("Title") == null ? string.Empty : LayoutProvider.GetNestedControlValueByFieldName("Title").ToString();

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

        protected void GridBookingProcessView_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {

        }

       public List<ProviderContact> GetContacts()
        {
            return new List<ProviderContact>();
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

        protected void GridCancellationView_Init(object sender, EventArgs e)
        {
            GridCancellationView.Columns["Id"].Visible = false;
        }

        protected void GridCancellationView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            List<CancellationCost> providercancelations = (List<CancellationCost>)GridCancellationView.DataSource;
            string id = e.Keys[0].ToString();
            CancellationCost providercontact = providercancelations.Find(m => m.Id == id);

            providercancelations.Remove(providercontact);


            var model = controller.GetData(ModelId);
            model.Cancellations = providercancelations;
            controller.Update(model);

            e.Cancel = true;
            GridCancellationView.CancelEdit();

            GridCancellationView.DataSource = providercancelations;
            GridCancellationView.DataBind();
        }

        protected void GridCancellationView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            List<CancellationCost> providercancellations = (List<CancellationCost>)GridCancellationView.DataSource;

            CancellationCost cancellationCost = new CancellationCost();
            var newValue = e.NewValues;

            cancellationCost.FromDay = newValue["FromDay"] != null ? DateTime.Parse(newValue["FromDay"].ToString()) : DateTime.Now;
            cancellationCost.ToDay = newValue["ToDay"] != null ? DateTime.Parse(newValue["ToDay"].ToString()) : DateTime.Now;
            cancellationCost.Percent = newValue["Percent"] != null ? Decimal.Parse(newValue["Percent"].ToString()) : 0;
          

            providercancellations.Add(cancellationCost);

            var model = controller.GetData(ModelId);
            model.Cancellations = providercancellations;
            controller.Update(model);

            var Model = controller.GetData(ModelId);

            e.Cancel = true;
            GridCancellationView.CancelEdit();

            GridCancellationView.DataSource = Model.Cancellations; 
            GridCancellationView.DataBind();
        }

        protected void GridCancellationView_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            List<CancellationCost> providercancellations = (List<CancellationCost>)GridCancellationView.DataSource;

            CancellationCost cancellationCost = providercancellations.Find(m => m.Id == e.Keys[0].ToString());
            var newValue = e.NewValues;

            cancellationCost.FromDay = newValue["FromDay"] != null ? DateTime.Parse(newValue["FromDay"].ToString()) : DateTime.Now;
            cancellationCost.ToDay = newValue["ToDay"] != null ? DateTime.Parse(newValue["ToDay"].ToString()) : DateTime.Now;
            cancellationCost.Percent = newValue["Percent"] != null ? Decimal.Parse(newValue["Percent"].ToString()) : 0;


            var model = controller.GetData(ModelId);
            model.Cancellations = providercancellations;
            controller.Update(model);

            var Model = controller.GetData(ModelId);

            e.Cancel = true;
            GridCancellationView.CancelEdit();

            GridCancellationView.DataSource = Model.Cancellations; 
            GridCancellationView.DataBind();
        }

        protected void GridCancellationView_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

        }

        protected void GridCancellationView_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (GridCancellationView.IsNewRowEditing)
                GridCancellationView.DoRowValidation();
        }
    }
}