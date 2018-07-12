using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using V50_IDOMBackOffice.AspxArea.BookingTemplate.Models;
using V50_IDOMBackOffice.AspxArea.BookingTemplate.Controllers;
using V50_IDOMBackOffice.PlugIn.Controller;
using IdomOffice.Interface.BackOffice.BookingTemplate;
using IdomOffice.Interface.BackOffice.Booking;

namespace V50_IDOMBackOffice.SupportForms
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        StatusDataDocumentController controller = new StatusDataDocumentController();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Add()
        {
            //StatusDataDocumentViewModel m1 = new StatusDataDocumentViewModel();
            
            //m1.Status = DocumentProcessStatus.New;
            //m1.ValueId = "01";
            //m1.Text = "Mail wasn't sent to Travel Applicant";
            //m1.Receiver = 1;

            //StatusDataDocumentViewModel m2 = new StatusDataDocumentViewModel();
           
            //m2.Status = = DocumentProcessStatus.New;
            //m2.ValueId = "02";
            //m2.Text = "Mail was sent to Travel Applicant";
            //m2.Receiver = 1;

            //StatusDataDocumentViewModel m3 = new StatusDataDocumentViewModel();
            
            //m3.Status = = DocumentProcessStatus.New;
            //m3.ValueId = "01";
            //m3.Text = "Mail wasn't sent to Provider";
            //m3.Receiver = 2;

            //StatusDataDocumentViewModel m4 = new StatusDataDocumentViewModel();
            
            //m4.Status = DocumentProcessStatus.New;
            //m4.ValueId = "02";
            //m4.Text = "Mail was sent to Travel Applicant";
            //m4.Receiver = 2;

            //StatusDataDocumentViewModel m5 = new StatusDataDocumentViewModel();
           
            //m5.Status = DocumentProcessStatus.New;
            //m5.ValueId = "01";
            //m5.Text = "Mail wasn't sent to B2BCustomer";
            //m5.Receiver = 3;

            //StatusDataDocumentViewModel m6 = new StatusDataDocumentViewModel();
            
            //m6.Status = DocumentProcessStatus.New;
            //m6.ValueId = "02";
            //m6.Text = "Mail was sent to B2BCustomer";
            //m6.Receiver = 3;

            //StatusDataDocumentViewModel m7 = new StatusDataDocumentViewModel();

            //m7.Status = DocumentProcessStatus.WaitingProviderConfirmation;
            //m7.ValueId = "01";
            //m7.Text = "Travel Applicant didn't send email";
            //m7.Receiver = 1;

            //StatusDataDocumentViewModel m8 = new StatusDataDocumentViewModel();
            //m8.Status = DocumentProcessStatus.WaitingProviderConfirmation;
            //m8.ValueId = "02";
            //m8.Text = "Travel Applicant sent email";
            //m8.Receiver = 1;

            //StatusDataDocumentViewModel m9 = new StatusDataDocumentViewModel();
            //m9.Status = DocumentProcessStatus.WaitingProviderConfirmation;
            //m9.ValueId = "01";
            //m9.Text = "Provider didn't send email";
            //m9.Receiver = 2;

            //StatusDataDocumentViewModel m10 = new StatusDataDocumentViewModel();
            //m10.Status = DocumentProcessStatus.WaitingProviderConfirmation;
            //m10.ValueId = "02";
            //m10.Text = "Provider sent email";
            //m10.Receiver = 2;

            //StatusDataDocumentViewModel m11 = new StatusDataDocumentViewModel();
            //m11.Status = DocumentProcessStatus.WaitingProviderConfirmation;
            //m11.ValueId = "01";
            //m11.Text = "B2BCustomer didn't send mail";
            //m11.Receiver = 3;

            //StatusDataDocumentViewModel m12 = new StatusDataDocumentViewModel();
            //m12.Status = DocumentProcessStatus.WaitingProviderConfirmation;
            //m12.ValueId = "02";
            //m12.Text = "B2BCustomer sent mail";
            //m12.Receiver = 3;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var manager = PlugInManager.GetApplicationDataManager();
            
            manager.AddApplicationData(new StatusDataDocument() { Id = Guid.NewGuid().ToString(), Status = DocumentProcessStatus.New, ValueId = 1, Receiver = 2, Text = "Najava za rezervaciju kod provajdera", NewStatus = DocumentProcessStatus.WaitingProviderConfirmation, FormCode = "EMAIL" });
            manager.AddApplicationData(new StatusDataDocument() { Id = Guid.NewGuid().ToString(), Status = DocumentProcessStatus.New, ValueId = 2, Receiver = 1, Text = "Potvrda storna", NewStatus = DocumentProcessStatus.Cancellation, FormCode = "EMAIL" });
            AddDocumentForAlle(DocumentProcessStatus.New);

            manager.AddApplicationData(new StatusDataDocument() { Id = Guid.NewGuid().ToString(), Status = DocumentProcessStatus.WaitingProviderConfirmation, ValueId = 1, Receiver = 2, Text = "Potvrda Rezervacije od provajdera", NewStatus = DocumentProcessStatus.ProviderConfirmed, FormCode = "TEXT" });
            manager.AddApplicationData(new StatusDataDocument() { Id = Guid.NewGuid().ToString(), Status = DocumentProcessStatus.New, ValueId = 12, Receiver = 2, Text = "Odbijanje rezervacije od provajdera", NewStatus = DocumentProcessStatus.Cancellation, FormCode = "TEXT" });
            AddDocumentForAlle(DocumentProcessStatus.WaitingProviderConfirmation);

            manager.AddApplicationData(new StatusDataDocument() { Id = Guid.NewGuid().ToString(), Status = DocumentProcessStatus.New, ValueId = 21, Receiver = 1, Text = "Potvrda rezervacije za gosta", NewStatus = DocumentProcessStatus.WaitingProviderConfirmation, FormCode = "EMAIL" });
            manager.AddApplicationData(new StatusDataDocument() { Id = Guid.NewGuid().ToString(), Status = DocumentProcessStatus.New, ValueId = 22, Receiver = 2, Text = "Storno od gosta za provajdera", NewStatus = DocumentProcessStatus.WaitingProviderConfirmation, FormCode = "EMAIL" });
            AddDocumentForAlle(DocumentProcessStatus.ProviderConfirmed);

            AddDocumentForAlle(DocumentProcessStatus.CustomerConfirmationSent);

            manager.AddApplicationData(new StatusDataDocument() { Id = Guid.NewGuid().ToString(), Status = DocumentProcessStatus.WaitToCustomerPayment, ValueId = 31, Receiver = 1, Text = "Knjizenje Uplate", NewStatus = DocumentProcessStatus.WaitToCustomerPayment, FormCode = "PAYMENT" });
            manager.AddApplicationData(new StatusDataDocument() { Id = Guid.NewGuid().ToString(), Status = DocumentProcessStatus.WaitToCustomerPayment, ValueId = 32, Receiver = 1, Text = "Potvrda uplate dijela iznosa", NewStatus = DocumentProcessStatus.WaitToCustomerPayment, FormCode = "EMAIL" });
            manager.AddApplicationData(new StatusDataDocument() { Id = Guid.NewGuid().ToString(), Status = DocumentProcessStatus.WaitToCustomerPayment, ValueId = 33, Receiver = 1, Text = "Potvrda uplate cijelog iznosa", NewStatus = DocumentProcessStatus.PricePaid, FormCode = "EMAIL" });
            AddDocumentForAlle(DocumentProcessStatus.WaitToCustomerPayment);

            manager.AddApplicationData(new StatusDataDocument() { Id = Guid.NewGuid().ToString(), Status = DocumentProcessStatus.PaymentIsDelayed, ValueId = 41, Receiver = 1, Text = "Opomena zbog prekoracenje roka placanja", NewStatus = DocumentProcessStatus.PaymentIsDelayed, FormCode = "EMAIL" });
            manager.AddApplicationData(new StatusDataDocument() { Id = Guid.NewGuid().ToString(), Status = DocumentProcessStatus.PaymentIsDelayed, ValueId = 42, Receiver = 1, Text = "Storno zbog prekoracenje roka placanja", NewStatus = DocumentProcessStatus.Cancellation, FormCode = "EMAIL" });
            AddDocumentForAlle(DocumentProcessStatus.PaymentIsDelayed);

            manager.AddApplicationData(new StatusDataDocument() { Id = Guid.NewGuid().ToString(), Status = DocumentProcessStatus.PricePaid, ValueId = 51, Receiver = 1, Text = "Slanje Voucera gostu", NewStatus = DocumentProcessStatus.VoucerSent, FormCode = "EMAIL" });
            AddDocumentForAlle(DocumentProcessStatus.PricePaid);

            AddDocumentForAlle(DocumentProcessStatus.VoucerSent);
            AddDocumentForAlle(DocumentProcessStatus.CustomerOnVacation);

            manager.AddApplicationData(new StatusDataDocument() { Id = Guid.NewGuid().ToString(), Status = DocumentProcessStatus.New, ValueId = 81, Receiver = 1, Text = "Storno za gosta", NewStatus = DocumentProcessStatus.Cancellation, FormCode = "EMAIL" });
            manager.AddApplicationData(new StatusDataDocument() { Id = Guid.NewGuid().ToString(), Status = DocumentProcessStatus.New, ValueId = 82, Receiver = 1, Text = "Storno za Provajdera", NewStatus = DocumentProcessStatus.Cancellation, FormCode = "EMAIL" });
            AddDocumentForAlle(DocumentProcessStatus.Cancellation);
        }

        private void AddDocumentForAlle(DocumentProcessStatus status)
        {
            var manager = PlugInManager.GetApplicationDataManager();
            manager.AddApplicationData(new StatusDataDocument() { Id = Guid.NewGuid().ToString(), Status = status, ValueId = 99, Receiver = 2, Text = "Email to Provider", NewStatus = status, FormCode = "EMAIL" });
            manager.AddApplicationData(new StatusDataDocument() { Id = Guid.NewGuid().ToString(), Status = status, ValueId = 98, Receiver = 1, Text = "Email to  Travel Applicant", NewStatus = status, FormCode = "EMAIL" });
            manager.AddApplicationData(new StatusDataDocument() { Id = Guid.NewGuid().ToString(), Status = status, ValueId = 97, Receiver = 2, Text = "Email from Provider", NewStatus = status, FormCode = "TEXT" });
            manager.AddApplicationData(new StatusDataDocument() { Id = Guid.NewGuid().ToString(), Status = status, ValueId = 96, Receiver = 1, Text = "Email from Travel Applicant", NewStatus = status, FormCode = "TEXT" });

        }
    }
}