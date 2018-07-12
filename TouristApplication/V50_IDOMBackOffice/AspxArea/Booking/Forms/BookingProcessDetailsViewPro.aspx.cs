using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using V50_IDOMBackOffice.AspxArea.Booking.Controllers;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using QTouristik.Interface.BackOffice.BookingTemplate;
using QTouristik.Interface.BackOffice.Booking;
using DevExpress.Web;

namespace V50_IDOMBackOffice.AspxArea.Booking.Forms
{
    public partial class BookingProcessDetailsView : System.Web.UI.Page
    {
        BookingProcessDetailsController controller = new BookingProcessDetailsController();
        BookingProcessController bookingcontroller = new BookingProcessController();
        ApplicationKeyController keycontroller = new ApplicationKeyController();
        ProviderAnnouncementController announcementcontroller = new ProviderAnnouncementController();
        BookingConfirmationController confirmationcontroller = new BookingConfirmationController();
        BookingInquiryController inquirycontroller = new BookingInquiryController();
        public BookingProcessDetailsViewModel model = null;
        string id = String.Empty;
        int number = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Uri u = HttpContext.Current.Request.Url;
                id = HttpUtility.ParseQueryString(u.Query).Get("id");
                DocumentProcessStatus status = CheckProviderStatus(id);
                bool isconfirmed=false;
                bool newstatus=false;
                if (status == DocumentProcessStatus.New)
                {
                    newstatus = true;
                }
                else if(status==DocumentProcessStatus.ProviderConfirmed)
                {
                    isconfirmed = true;
                }
                else
                {

                }

                ViewState["newstatus"] = newstatus;
                CheckApplicantPaymentStatus(id);

                model = controller.GetModel(id);
                GridBookingProcessItemView.DataSource = model.BookingProcessItemList;
                GridBookingProcessItemView.DataBind();


                if (isconfirmed)
                {
                    var list = controller.GetStatusesProviderConfirmedBefore();
                    ASPxComboBoxStatus.DataSource = list;
                    ASPxComboBoxStatus.DataBind();
                    //ViewState["list"] = list;
                }
                else
                {

                    ASPxComboBoxStatus.DataSource = controller.GetStatuses(id);
                    ASPxComboBoxStatus.DataBind();
                }

                lblStatus.Text = model.Status.ToString();
                ViewState["id"] = id;
                ViewState["isconfirmed"] = isconfirmed;
                
            }
            else
            {
                if (ViewState["number"] == null)
                {
                    number++;

                    ViewState["number"] = number;
                }
                else
                {
                    number = (int)ViewState["number"];
                    number++;
                    ViewState["number"] = number;
                }
                id = (string)ViewState["id"];
                bool isconfirmed = (bool)ViewState["isconfirmed"];

                if (isconfirmed)
                {
                    if (ASPxComboBoxStatus.SelectedItem != null && number == 2)
                    {
                        ViewState["valueid"] = ASPxComboBoxStatus.SelectedItem.Value.ToString();
                    }
                }
                else
                {
                    ViewState["valueid"] = ASPxComboBoxStatus.SelectedItem.Value.ToString();
                }


                CheckApplicantPaymentStatus(id);

                model = controller.GetModel(id);
                GridBookingProcessItemView.DataSource = model.BookingProcessItemList;
                GridBookingProcessItemView.DataBind();


                if (isconfirmed)
                {
                    ASPxComboBoxStatus.DataSource = controller.GetStatusesProviderConfirmedAfter();
                    ASPxComboBoxStatus.DataBind();
                }
                else
                {

                    ASPxComboBoxStatus.DataSource = controller.GetStatuses(id);
                    ASPxComboBoxStatus.DataBind();
                }

                lblStatus.Text = model.Status.ToString();

            }
        }

        public List<BookingProcessItemViewModel> Get()
        {
            return new List<BookingProcessItemViewModel>();
        }

        private void CheckApplicantPaymentStatus(string id)
        {
            var bookingmodel = bookingcontroller.GetBookingProcess(id);
            DocumentProcessStatus status = bookingmodel.Status;
            if (status == DocumentProcessStatus.WaitToCustomerPayment)
            {
                bool paid = bookingcontroller.GetApplicantPaymentStatus(id);
                if (paid)
                {
                    bookingmodel.Status = DocumentProcessStatus.PricePaid;
                }

                bookingcontroller.UpdateBookingProcess(bookingmodel);
            }
        }

        private bool CheckKeyStatus()
        {
            bool b = false;
            var keymodel = keycontroller.GetApplicationKeyByName("BookingNumber");
            if(keymodel!=null)
            {
                b = true;
            }
            
            return b;
        }

        private DocumentProcessStatus CheckProviderStatus(string id)
        {
            var bookingmodel = bookingcontroller.GetBookingProcess(id);
            DocumentProcessStatus status = bookingmodel.Status;
             
            return status;
        }

        private void AddBookingNumber()
        {        
            var keymodel = new ApplicationKeyViewModel();
            keymodel.docType = "ApplicationKey";
            keymodel.Name = "BookingNumber";
            keymodel.Value = 1024;
            keymodel.Season = "2017";

            keycontroller.AddMasterData(keymodel);
            
        }

        private void UpdateBookingNumber()
        {
            int current;

            var model = keycontroller.GetApplicationKeyByName("BookingNumber");
            current = model.Value;
            current++;
            model.Value = current;
            keycontroller.UpdateMasterData(model);

        }

        protected void ASPxButtonSelect_Click(object sender, EventArgs e)
        {

            bool exists;
            bool isconfirmed = false;
            bool newstatus = false;
            int k = 0;
            string id;
            BookingConfirmation confirmation;

            newstatus = (bool)ViewState["newstatus"];
            isconfirmed = (bool)ViewState["isconfirmed"];
            k = (int)ViewState["number"];
            id = (string)ViewState["id"];
            exists = CheckKeyStatus();

            if (isconfirmed)
            {
                if (k == 1)
                {

                    if (!exists)
                    {
                        AddBookingNumber();
                    }
                    else
                    {
                        UpdateBookingNumber();
                    }
                    CreateBookingConfirmation(id);
                }
                else if (k == 2)
                {
                    List<StatusDataDocument> data = (List<StatusDataDocument>)ASPxComboBoxStatus.DataSource;
                    int valueid = int.Parse((string)ViewState["valueid"]);
                    StatusDataDocument document = data.Find(m => m.ValueId == valueid);
                    string statusid = document.Id;
                    string formcode = document.FormCode;
                    string formname = controller.GetFormName(formcode);
                    string name = document.Text;

                    if (formcode != "NONE")
                    {
                        Response.Redirect("~/AspxArea/Booking/Forms/" + formname + "?id=" + id + "&statusid" +
                            "=" + statusid + "&name=" + name+ "&valueid=" + valueid.ToString());
                    }
                }
            }
            else if(newstatus)
            {
                bool isannounced = false;
      
                List<StatusDataDocument> data = (List<StatusDataDocument>)ASPxComboBoxStatus.DataSource;
                int valueid = int.Parse(ASPxComboBoxStatus.SelectedItem.Value.ToString());
                isannounced = isProviderAnnouncement(valueid);
                var model = announcementcontroller.GetProviderAnnouncementByBookingId(id);
                if(isannounced && model==null)
                {
                    CreateProviderAnnouncement(id);
                }
                StatusDataDocument document = data.Find(m => m.ValueId == valueid);
                string statusid = document.Id;
                string formcode = document.FormCode;
                string formname = controller.GetFormName(formcode);
                string name = document.Text;

                if (formcode != "NONE")
                {
                    Response.Redirect("~/AspxArea/Booking/Forms/" + formname + "?id=" + id + "&statusid" +
                        "=" + statusid + "&name=" + name + "&valueid=" + valueid.ToString());
                }
            }
            else
            {
                List<StatusDataDocument> data = (List<StatusDataDocument>)ASPxComboBoxStatus.DataSource;
                int valueid = int.Parse(ASPxComboBoxStatus.SelectedItem.Value.ToString());
                StatusDataDocument document = data.Find(m => m.ValueId == valueid);
                string statusid = document.Id;
                string formcode = document.FormCode;
                string formname = controller.GetFormName(formcode);
                string name = document.Text;

                if (formcode != "NONE")
                {
                    Response.Redirect("~/AspxArea/Booking/Forms/" + formname + "?id=" + id + "&statusid" +
                        "=" + statusid + "&name=" + name + "&valueid=" + valueid.ToString());
                }
            }
         
        }

        protected void GridBookingProcessItemView_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if(e.ButtonID=="ButtonEmail")
            {
                ASPxGridView grid = sender as ASPxGridView;
                int index = e.VisibleIndex;
                string itemid = grid.GetRowValues(index, "DocumentId").ToString();
                string bookingProcessTyp = grid.GetRowValues(index, "BookingProcessTyp").ToString();
                GridBookingProcessItemView.JSProperties["cpKeyValue"] = itemid;
                //ASPxPopup.ContentUrl = "~/AspxArea/Booking/Forms/" + bookingProcessTyp + "View.aspx?itemid=" + itemid + "&id=" + id;
                //      Response.Redirect("~/AspxArea/PriceList/Forms/PurchasePriceForm.aspx?sc=" + sitecode + "&oc=" + unitcode);
               //  ASPxWebControl.RedirectOnCallback(VirtualPathUtility.ToAbsolute("~/AspxArea/Booking/Forms/" + bookingProcessTyp + "View.aspx?itemid=" + itemid + "&id=" + id));
            }
        }

       private bool isProviderAnnouncement(int valueid)
       {
            bool b = false;
           
            if(valueid==1)
            {
                b = true;
            }

            return b;
       }

       private void CreateProviderAnnouncement(string id)
       {
            announcementcontroller.CreateProviderAnnouncement(id);
       }

       private void CreateBookingConfirmation(string id)
       {
            var model = confirmationcontroller.GetBookingConfirmationByBookingId(id);
            if (model == null)
            {
                var confirmationmodel = confirmationcontroller.CreateBookingConfirmation(id);
                var inquirymodel = inquirycontroller.GetBookingInquiryByBookingId(id);
                confirmationmodel.BookingInquiryNummer = inquirymodel.BookingInquiryNummer;
                int number = keycontroller.GetApplicationKeyByName("BookingNumber").Value;
                String sDate = DateTime.Now.ToString();
                DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

                String dy = datevalue.Day.ToString();
                String mn = datevalue.Month.ToString();
                String yy = datevalue.Year.ToString();

                string confirmationnumber = "Id-" + dy + mn + "-" + number.ToString();
                confirmationmodel.BookingConfirmationNummer = confirmationnumber;

                confirmationcontroller.AddMasterData(confirmationmodel);

            }
       }

        protected void btnCompare_Click(object sender, EventArgs e)
        {
           bool isconfirmed = (bool)ViewState["isconfirmed"];
           bool b;
           id = (string)ViewState["id"];
            if (isconfirmed)
            {
                var announcement = announcementcontroller.GetProviderAnnouncementByBookingId(id);
                var bookingconfirmation = confirmationcontroller.GetBookingConfirmationByBookingId(id);
                b = CheckisSame(announcement, bookingconfirmation);
                if(b)
                {
                    lblCompare.Text = "Provider announcement and Booking confirmation are same";
                }
                else
                {
                    lblCompare.Text = "Provider announcement and Booking confirmation are different";
                }
            }
        }

        private bool CheckisSame(ProviderAnnouncementViewModel modela,BookingConfirmationViewModel modelc)
        {
            if((modela.CheckIn==modelc.CheckIn)&&(modela.CheckOut==modelc.CheckOut))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}