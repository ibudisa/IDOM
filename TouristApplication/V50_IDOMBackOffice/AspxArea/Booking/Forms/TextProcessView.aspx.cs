using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdomOffice.Interface.BackOffice.Booking;
using V50_IDOMBackOffice.PlugIn.Controller;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using V50_IDOMBackOffice.AspxArea.Booking.Controllers;
using V50_IDOMBackOffice.AspxArea.BookingTemplate.Controllers;

namespace V50_IDOMBackOffice.AspxArea.Booking.Forms
{
    public partial class TextProcessView : System.Web.UI.Page
    {
        BookingProcessController bookingcontroller = new BookingProcessController();
        CustomerController customercontroller = new CustomerController();
        StatusDataDocumentController statuscontroller = new StatusDataDocumentController();
        TextInfoController textcontroller = new TextInfoController();
        ProviderConfirmationController confirmationcontroller = new ProviderConfirmationController();
        BookingProcessViewModel bookingmodel;
        string id;
        string value;
        string listvalue;
        int key;

        protected void Page_Load(object sender, EventArgs e)
        {
            Uri u = HttpContext.Current.Request.Url;
            // id iz booking procesa
             id = HttpUtility.ParseQueryString(u.Query).Get("id");
            // value iz comboboxa za select 
             value = HttpUtility.ParseQueryString(u.Query).Get("statusid");

            listvalue = HttpUtility.ParseQueryString(u.Query).Get("valueid");
            key = int.Parse(listvalue);

            //bookingmodel = bookingcontroller.GetBookingProcess(id);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bookingmodel = bookingcontroller.GetBookingProcess(id);
            var status = bookingmodel.Status;
            if(status==DocumentProcessStatus.WaitingProviderConfirmation && key==1)
            {
                var model = confirmationcontroller.GetProviderConfirmationByBookingId(id);
                if(model==null)
                {
                    ProviderConfirmationViewModel pcv = new ProviderConfirmationViewModel();
                    pcv.BookingId = id;
                    pcv.Content = HtmlEditorInfo.Html;
                    pcv.CreateDate = DateEdit.Date;
                    pcv.docType="ProviderConfirmation";
                    pcv.Title = txtTitle.Text;
                    confirmationcontroller.AddMasterData(pcv);
                    SetModelProvider(pcv);
                }
            }

            bookingmodel.Status = statuscontroller.GetStatusDataDocument(value).NewStatus;

            bookingcontroller.UpdateBookingProcess(bookingmodel);

            
            var textinfomodel = new TextInfoViewModel();

            textinfomodel.BookingId = bookingmodel.Id;
            textinfomodel.Status = bookingmodel.Status;
            textinfomodel.docType = "Text";
            textinfomodel.Content = HtmlEditorInfo.Html;
            textinfomodel.Date = DateEdit.Date;
            textinfomodel.Title = txtTitle.Text;

            if ((status == DocumentProcessStatus.WaitingProviderConfirmation && key != 1) || (status != DocumentProcessStatus.WaitingProviderConfirmation))
            {
                textcontroller.AddMasterData(textinfomodel);

                SetModel(textinfomodel);
            }
        }

        private void SetModel(TextInfoViewModel model)
        {
            
            BookingProcessViewModel bookingmodel = new BookingProcessViewModel();
            bookingmodel = bookingcontroller.GetBookingProcess(id);
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

        private void SetModelProvider(ProviderConfirmationViewModel model)
        {

            BookingProcessViewModel bookingmodel = new BookingProcessViewModel();
            bookingmodel = bookingcontroller.GetBookingProcess(id);
            BookingProcessItem item = new BookingProcessItem();
            item.DocumentId = model.Id;
            item.CreateDate = DateTime.Now;
            Random r = new Random();
            item.DocumentNr = r.Next(10000).ToString();
            item.Author = "Ivan Budisa";
            item.BookingProcessTyp = BookingProcessItemTyp.ProviderConfirmation;
            item.LastChange = DateTime.Now;
            item.DocumentTitel = model.Title;
            item.DocumentStatus = DocumentStatus.Active;
            bookingmodel.BookingProcessItemList.Add(item);
            bookingcontroller.UpdateBookingProcess(bookingmodel);
        }
    }
}