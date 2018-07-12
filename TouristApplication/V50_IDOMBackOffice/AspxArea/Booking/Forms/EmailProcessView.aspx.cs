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
using V50_IDOMBackOffice.AspxArea.BookingTemplate.Controllers;

using V50_IDOMBackOffice.AspxArea.MasterData.Controllers;
using IdomOffice.Interface.BackOffice.Booking;
using System.IO;
using DevExpress.Web.ASPxHtmlEditor;

namespace V50_IDOMBackOffice.AspxArea.Booking.Forms
{
    public partial class EmailProcessView : System.Web.UI.Page
    {
        EmailProcessControler controller = new EmailProcessControler();
        BookingProcessController bookingcontroller = new BookingProcessController();
        TemplateController templatecontroller = new TemplateController();
        BackOfficeContactController contactcontroller = new BackOfficeContactController();
        ProviderController providercontroller = new ProviderController();
        CustomerController customercontroller = new CustomerController();
        StatusDataDocumentController statuscontroller = new StatusDataDocumentController();
        ApplicationKeyController keycontroller = new ApplicationKeyController();
        BookingInquiryController inquirycontroller = new BookingInquiryController();
        ProviderAnnouncementController announcementcontroller = new ProviderAnnouncementController();
        BookingConfirmationController confirmationcontroller = new BookingConfirmationController();
        BookingProcessViewModel bookingmodel;
        EmailProcessViewModel model;
        CoreViewModel providermodel;
        CustomerViewModel customermodel;
        bool tabchanged = false;
        string id;
        string value;
        string statusname;
        string parameter;
        
        Dictionary<string, object> bookingdata = new Dictionary<string, object>();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            Uri u = HttpContext.Current.Request.Url;
            // id iz booking procesa
            id = HttpUtility.ParseQueryString(u.Query).Get("id");
            statusname= HttpUtility.ParseQueryString(u.Query).Get("name");
            lblStatusName.Text = statusname;
            // value iz comboboxa za select 
            bookingmodel = bookingcontroller.GetBookingProcess(id);

            bookingdata = templatecontroller.GetValues(bookingmodel);
            value = HttpUtility.ParseQueryString(u.Query).Get("statusid");
            parameter = HttpUtility.ParseQueryString(u.Query).Get("valueid");

            if (!IsPostBack)
            {
                PageControlTemplate.ActiveTabIndex = 0;
                BindTemplates();
                SetTemplate();
            }
                int receiver = controller.GetReceiver(id, value);
                if (receiver == 1)
                {
                    customermodel = customercontroller.GetCustomerById(id);
                    comboboxTo.DataSource = customermodel.Contacts;
                    comboboxTo.DataBind();
                }
                else if (receiver == 2)
                {
                    providermodel = providercontroller.GetCoreDataById(id);
                    comboboxTo.DataSource = providermodel.Contacts;
                    comboboxTo.DataBind();
                }
                btnSave.Enabled = false;
            
                /*
                comboboxTo.DataSource = model;
                comboboxTo.DataBind();*/
                BindTemplates();
                BindContactsFrom();
            
        }

        private void BindTemplates()
        {
            var template = templatecontroller.GetTemplatesByStatusId(value);
            comboboxTemplate.DataSource = template;
            comboboxTemplate.DataBind();
        }

        private void BindContactsFrom()
        {
            var contacts = contactcontroller.Init();
            comboboxFrom.DataSource = contacts;
            comboboxFrom.DataBind();
        }

        private void SetTemplate()
        {
            List<TemplateViewModel> data = (List<TemplateViewModel>)comboboxTemplate.DataSource;

            if (data.Count > 0)
            {
                comboboxTemplate.SelectedIndex = 0;
                string value = comboboxTemplate.SelectedItem.Value.ToString();

                var model = data.Find(m => m.Id == value);
                string text = model.Text;
                string subject = model.Title;
                subject = templatecontroller.GetData(subject, bookingdata);

                text = templatecontroller.GetData(text, bookingdata);

                txtSubject.Text = subject;
                HtmlEditorContent.Html = text;
            }
        }

        private void SetModel()
        {
            EmailProcessViewModel emailmodel = controller.GetEmailProcessViewModelByBookingIdLast(id);
            BookingProcessViewModel bookingmodel = new BookingProcessViewModel();
            ApplicationKeyViewModel keymodel = keycontroller.GetApplicationKeyByName("BookingNumber");
            int number = keymodel.Value;
            int n = int.Parse(parameter);
            bookingmodel = bookingcontroller.GetBookingProcess(id);
            var status = bookingmodel.Status;
            BookingProcessItem item = new BookingProcessItem();
            if (status == DocumentProcessStatus.WaitingProviderConfirmation && n == 1)
            {
                var annoucement = announcementcontroller.GetProviderAnnouncementByBookingId(id);
                item.DocumentId = annoucement.Id;
                item.DocumentNr = "Id" + number.ToString();
                item.CreateDate = DateTime.Now;
                item.LastChange = DateTime.Now;
                item.Author = "Ivan Budisa";
                item.DocumentTitel = "Provider announcement" + annoucement.SiteName;
                item.DocumentStatus = DocumentStatus.Active;
                item.BookingProcessTyp = BookingProcessItemTyp.ProviderAnnouncement;
            }
            else if (status == DocumentProcessStatus.CustomerConfirmationSent)
            {
                var bookingconfirmation = confirmationcontroller.GetBookingConfirmationByBookingId(id);
                item.DocumentId = bookingconfirmation.id;
                item.DocumentNr = bookingconfirmation.BookingConfirmationNummer;
                item.CreateDate = DateTime.Now;
                item.LastChange = DateTime.Now;
                item.Author = "Ivan Budisa";
                item.DocumentTitel = "Booking Confirmation" + bookingconfirmation.SiteName;
                item.DocumentStatus = DocumentStatus.Active;
                item.BookingProcessTyp = BookingProcessItemTyp.BookingConfirmation;
               
            }
            else
            {
                 
                item.DocumentId = emailmodel.Id;
                item.DocumentNr = new Random().Next(1000, 2000).ToString();
                item.CreateDate = DateTime.Now;
                item.LastChange = DateTime.Now;
                item.Author = "Ivan Budisa";
                item.DocumentTitel = emailmodel.Title;
                item.DocumentStatus = DocumentStatus.Active;
                //item.BookingProcessTyp = BookingProcessItemTyp.BookingConfirmation;
            }

            bookingmodel.BookingProcessItemList.Add(item);
            bookingcontroller.UpdateBookingProcess(bookingmodel);
        }

        private void SaveBookingInquiry(BookingProcessViewModel model,string number)
        {
            inquirycontroller.AddMasterDataFromBookingProcess(model, number);
        }

       

        protected void btnNew_Click(object sender, EventArgs e)
        {
            TemplateViewModel model = new TemplateViewModel();
            model.Name = "New Template";
            model.Title = "Enter the subject";
            model.Text = String.Empty;
            model.StatusId = value;

            templatecontroller.AddTemplate(model);

            TemplateViewModel modeldata = templatecontroller.GetTemplateByStatusIdLast(value);
            txtEdit.Text = modeldata.Name;
            txtSubject.Text = modeldata.Title;
            btnSave.Enabled = true;
            btnNew.Enabled = false;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            tabchanged = (bool)ViewState["tabchanged"];
            if(tabchanged)
            {
                string id;

                if(comboboxTemplate.SelectedItem==null)
                {
                    TemplateViewModel model = templatecontroller.GetTemplateByStatusIdLast(value);
                    model.Name = txtEdit.Text;
                    model.Title = txtSubject.Text;
                    model.Text = HtmlEditorContent.Html;

                    templatecontroller.UpdateTemplate(model);
                }
                else 
                {
                    id = comboboxTemplate.SelectedItem.Value.ToString();
                    var template = templatecontroller.GetTemplate(id);
                    template.Name = txtEdit.Text;
                    template.Title = txtSubject.Text;
                    //HtmlEditorContent.Html += templatecontroller.GetCustomerTable();
                    template.Text = HtmlEditorContent.Html;


                    templatecontroller.UpdateTemplate(template);
                }
            }
            if(!String.IsNullOrEmpty(txtEdit.Text)&& !(tabchanged))
            {
                TemplateViewModel model = templatecontroller.GetTemplateByStatusIdLast(value);
                model.Name = txtEdit.Text;
                model.StatusId = value;
                model.Title = txtSubject.Text;
   
                model.Text = HtmlEditorContent.Html;

                templatecontroller.UpdateTemplate(model);
            }
           
            BindTemplates();
        }

        private string GetText()
        {
            string plainText = String.Empty;

            using (MemoryStream mStream = new MemoryStream())
            {
                HtmlEditorContent.Export(HtmlEditorExportFormat.Txt, mStream);
                plainText = System.Text.Encoding.UTF8.GetString(mStream.ToArray());             
            }

            return plainText;
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            List<TemplateViewModel> list = (List<TemplateViewModel>)comboboxTemplate.DataSource;
            string id = comboboxTemplate.SelectedItem.Value.ToString();
            var item = list.Find(m => m.Id == id);
            string text = item.Text;
            string subject = item.Title;
            subject = templatecontroller.GetData(subject, bookingdata);

            text = templatecontroller.GetData(text, bookingdata);

            txtSubject.Text =subject;
            HtmlEditorContent.Html = text;

        }

        private List<int> GetValues(string text)
        {
            List<int> list = new List<int>();
            char[] textarray = text.ToCharArray();
            
            for (int i = 0; i < text.Length; i++)
            {
              if (textarray[i].Equals('['))
               {
                    list.Add(i + 1);
               }

            }
            return list;
        }

        

        protected void PageControlTemplate_ActiveTabChanged(object source, DevExpress.Web.TabControlEventArgs e)
        {
            btnNew.Enabled = true;
            btnSave.Enabled = true;
            string id;
            if (comboboxTemplate.SelectedItem != null)
            {
                id = comboboxTemplate.SelectedItem.Value.ToString();
                var template = templatecontroller.GetTemplate(id);
                txtSubject.Text = template.Title;
                txtEdit.Text = template.Name;
                HtmlEditorContent.Html = template.Text;
            }
            tabchanged = true;
            ViewState["tabchanged"] = tabchanged;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string email = comboboxTo.Text;
            int receiver = controller.GetReceiver(id, value);
            if (receiver == 1)
            {
                customercontroller.CheckCustomerEmail(id, email);
                customermodel = customercontroller.GetCustomerById(id);
                comboboxTo.DataSource = customermodel.Contacts;
                comboboxTo.DataBind();
            }
            else if (receiver == 2)
            {
                providercontroller.CheckEmail(id, email);
                providermodel = providercontroller.GetCoreDataById(id);
                comboboxTo.DataSource = providermodel.Contacts;
                comboboxTo.DataBind();
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            model = new EmailProcessViewModel();
            model.Sender = comboboxFrom.SelectedItem == null ? string.Empty : comboboxFrom.SelectedItem.Value.ToString();
            model.Receipent = comboboxTo.SelectedItem == null ? string.Empty : comboboxTo.SelectedItem.Value.ToString();
            model.Title = txtSubject.Text;
            model.Content = GetText();
            model.BookingId = id;
            model.docType = "Email";
            model.Status = statuscontroller.GetStatusDataDocument(value).NewStatus;
            bookingmodel.Status = model.Status;

            bookingcontroller.UpdateBookingProcess(bookingmodel);
            controller.AddMasterData(model);
            SetModel();
        }
    }
}