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
using IdomOffice.Interface.BackOffice.Booking;

namespace V50_IDOMBackOffice.AspxArea.Booking.Forms
{
    public partial class PaymentProcessView : System.Web.UI.Page
    {
        IPaymentController controller;
        BookingProcessController bookingcontroller = new BookingProcessController();
        string id;
        string value;

        protected void Page_Load(object sender, EventArgs e)
        {
            Uri u = HttpContext.Current.Request.Url;
            // id iz booking procesa
            id = HttpUtility.ParseQueryString(u.Query).Get("id");
            // value iz comboboxa za select 
            value = HttpUtility.ParseQueryString(u.Query).Get("statusid");

            Bind();
        }

        private void Bind()
        {
            comboboxtype.DataSource = DataManager.GetReceiverTypes();
            comboboxtype.DataBind();

            comboboxWayOfPayment.DataSource = DataManager.GetPaymentTypes();
            comboboxWayOfPayment.DataBind();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            if(comboboxtype.SelectedItem.Value.ToString()=="1")
            {
                controller = new ApplicantPaymentController();
            }
            else if(comboboxtype.SelectedItem.Value.ToString()=="2")
            {
                controller = new ProviderPaymentController();
            }
            ViewState["controller"] = controller;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            controller = (IPaymentController)ViewState["controller"];
            var payment = new PaymentViewModel();
            payment.Id = Guid.NewGuid().ToString();
            payment.BookingId = id;
            payment.Date = DateEditPayment.Date;
            payment.Value = Decimal.Parse(txtValue.Text);
            payment.Title = comboboxtype.SelectedItem.Text;
            payment.PaymentType = comboboxWayOfPayment.SelectedItem.Text;

            if(controller is ApplicantPaymentController)
            {
                payment.docType = "TravelApplicantPayment";
            }
            else
            {
                payment.docType = "ProviderPayment";
            }
            controller.AddPayment(payment);
            SetModel(payment);
        }

        private void SetModel(PaymentViewModel model)
        {

            BookingProcessViewModel bookingmodel = new BookingProcessViewModel();
            bookingmodel = bookingcontroller.GetBookingProcess(id);
            bookingmodel.Status = DocumentProcessStatus.WaitToCustomerPayment;
            BookingProcessItem item = new BookingProcessItem();
            item.DocumentId = model.Id;
            item.CreateDate = model.Date;
            Random r = new Random();
            item.DocumentNr = r.Next(10000).ToString();
            item.Author = "Ivan Budisa";
            item.BookingProcessTyp = BookingProcessItemTyp.BookingConfirmation;
            item.LastChange = DateTime.Now;
            item.DocumentTitel = model.Title;
            item.DocumentStatus = DocumentStatus.Active;
            bookingmodel.BookingProcessItemList.Add(item);
            bookingcontroller.UpdateBookingProcess(bookingmodel);
        }
    }
}