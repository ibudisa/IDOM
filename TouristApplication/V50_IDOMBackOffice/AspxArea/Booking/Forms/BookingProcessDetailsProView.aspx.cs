using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using V50_IDOMBackOffice.AspxArea.Booking.Controllers;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using IdomOffice.Interface.BackOffice.BookingTemplate;
using IdomOffice.Interface.BackOffice.Booking;
using DevExpress.Web;

namespace V50_IDOMBackOffice.AspxArea.Booking.Forms
{
    public partial class BookingProcessDetailsProView : System.Web.UI.Page
    {
        BookingProcessDetailsProController controller = new BookingProcessDetailsProController();
        public BookingProcessDetailsViewModel model = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            Uri u = HttpContext.Current.Request.Url;
            var id = HttpUtility.ParseQueryString(u.Query).Get("id");
            model = controller.GetModel(id);
            GridBookingProcessItemView.DataSource = model.BookingProcessItemList;
            GridBookingProcessItemView.DataBind();
            ASPxComboBoxStatus.DataSource = model.ActionList;
            ASPxComboBoxStatus.DataBind();
        }

      

        protected void ASPxButtonSelect_Click(object sender, EventArgs e)
        {
            List<StatusDataDocument> data = (List<StatusDataDocument>)ASPxComboBoxStatus.DataSource;
            int actionValue = int.Parse(ASPxComboBoxStatus.SelectedItem.Value.ToString());
            string url = controller.GetActionUrl(actionValue, model,data);
            if (url != string.Empty)
            {
                Response.Redirect(url);
            }

        }

        protected void GridBookingProcessItemView_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            //if(e.ButtonID=="ButtonEmail")
            //{
            //    //List<BookingProcessItem> list = (List<BookingProcessItem>)GridBookingProcessItemView.DataSource;
               
            //    ASPxGridView grid = sender as ASPxGridView;
            //    int index = e.VisibleIndex;
            //    //string id = grid.GetRowValues(index, "Id").ToString();
            //    string itemid = grid.GetRowValues(index, "DocumentId").ToString();
            //    string bookingProcessTyp = grid.GetRowValues(index, "BookingProcessTyp").ToString();
            //    //GridBookingProcessItemView.JSProperties["cpKeyValue"] = itemid;
            //    PopupControlData.ContentUrl = "~/AspxArea/Booking/Forms/DocViewPopUpForm.aspx?id=" + itemid;
            //    //      Response.Redirect("~/AspxArea/PriceList/Forms/PurchasePriceForm.aspx?sc=" + sitecode + "&oc=" + unitcode);
            //    //ASPxWebControl.RedirectOnCallback(VirtualPathUtility.ToAbsolute("~/AspxArea/Booking/Forms/DocViewPopUpForm.aspx?id=" + itemid));
            //}
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {

        }


        protected void btnCompare_Click(object sender, EventArgs e)
        {
          
        }

       
    }
}