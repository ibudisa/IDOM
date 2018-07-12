using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using V50_IDOMBackOffice.AspxArea.Booking.Controllers;
using IdomOffice.Interface.BackOffice.Booking;
using DevExpress.Web;

namespace V50_IDOMBackOffice.AspxArea.Booking.Forms
{
    public partial class BookingProcessView : System.Web.UI.Page
    {
        BookingProcessController controller = new BookingProcessController();

        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }
 
        public void Bind()
        {
            GridBookingProcessView.DataSource = controller.Init();
            GridBookingProcessView.DataBind();
        }

        protected void GridBookingProcessView_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "ButtonBookingDetails")
            {
                ASPxGridView grid = sender as ASPxGridView;
                List<BookingProcessViewModel> list = (List<BookingProcessViewModel>)grid.DataSource;
                //Todo: Ivane da li trebas ovaj code ??
                int index = e.VisibleIndex;
                string id = grid.GetRowValues(index, "Id").ToString();
               /* string country = (string) grid.GetRowValues(index, "Country") ?? string.Empty;
                string placename = grid.GetRowValues(index, "PlaceName").ToString();
                string firstname = grid.GetRowValues(index, "FirstName").ToString();
                string lastname = grid.GetRowValues(index, "LastName").ToString();

                var item = list.Find(p => p.Id == id);

                var bookingitems = item.BookingProcessItemList;*/
                 

                //      Response.Redirect("~/AspxArea/PriceList/Forms/PurchasePriceForm.aspx?sc=" + sitecode + "&oc=" + unitcode);
                ASPxWebControl.RedirectOnCallback(VirtualPathUtility.ToAbsolute("~/AspxArea/Booking/Forms/BookingProcessDetailsProView.aspx?id=" + id ));
            }
        }

        protected void GridBookingProcessView_DataBinding(object sender, EventArgs e)
        {
            GridBookingProcessView.ForceDataRowType(typeof(BookingProcessViewModel));
        }

        protected void GridBookingProcessView_Init(object sender, EventArgs e)
        {
            GridBookingProcessView.Columns["Id"].Visible = false;
            GridBookingProcessView.Columns["PlaceName"].Visible = false;
            GridBookingProcessView.Columns["Country"].Visible = false;
            GridBookingProcessView.Columns["Address"].Visible = false;
            GridBookingProcessView.Columns["PartnerId"].Visible = false;
        }

        protected void GridBookingProcessView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string id = e.Keys[0].ToString();


            controller.DeleteBookingProcess(id);

            e.Cancel = true;
            GridBookingProcessView.CancelEdit();

            Bind();
        }

        protected void GridBookingProcessView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            BookingProcessViewModel model = new BookingProcessViewModel();
            
            model.Status = (DocumentProcessStatus) e.NewValues["Status"];
            model.Country = e.NewValues["Country"].ToString();
            model.PlaceName = e.NewValues["PlaceName"].ToString();
            model.SiteName = e.NewValues["SiteName"].ToString();
            model.TourOperatorCode = e.NewValues["TourOperator"].ToString();
            model.CheckIn = (DateTime)e.NewValues["CheckIn"];
            model.CheckOut = (DateTime)e.NewValues["CheckOut"];
            model.FirstName = e.NewValues["FirstName"].ToString();
            model.LastName = e.NewValues["LastName"].ToString();
            model.TravelerCountry = e.NewValues["TravelerCountry"].ToString();
            model.Address = e.NewValues["Address"].ToString();
            model.TravelApplicantId = (int) e.NewValues["TravelApplicantId"];
            model.PartnerId = (int) e.NewValues["PartnerId"];
            model.Season = e.NewValues["Season"].ToString();
            controller.AddBookingProcess(model);

            e.Cancel = true;
            GridBookingProcessView.CancelEdit();

            Bind();
        }

        protected void GridBookingProcessView_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var list = (List<BookingProcessViewModel>)GridBookingProcessView.DataSource;
            BookingProcessViewModel model = list.Find(m => m.Id == e.Keys[0].ToString());

            model.Status = (DocumentProcessStatus)e.NewValues["Status"];
            model.Country = e.NewValues["Country"].ToString();
            model.PlaceName = e.NewValues["PlaceName"].ToString();
            model.SiteName = e.NewValues["SiteName"].ToString();
            model.TourOperatorCode = e.NewValues["TourOperator"].ToString();
            model.CheckIn = (DateTime)e.NewValues["CheckIn"];
            model.CheckOut = (DateTime)e.NewValues["CheckOut"];
            model.FirstName = e.NewValues["FirstName"].ToString();
            model.LastName = e.NewValues["LastName"].ToString();
            model.TravelerCountry = e.NewValues["TravelerCountry"].ToString();
            model.Address = e.NewValues["Address"].ToString();
            model.TravelApplicantId = (int) e.NewValues["TravelApplicantId"];
            model.PartnerId = (int) e.NewValues["PartnerId"];
            model.Season = e.NewValues["Season"].ToString();

            controller.UpdateBookingProcess(model);

            e.Cancel = true;
            GridBookingProcessView.CancelEdit();

            Bind();

        }

        protected void GridBookingProcessView_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "Status")
            {
                ASPxComboBox combo = (ASPxComboBox)e.Editor;
                combo.DataSource = Enum.GetValues(typeof(DocumentProcessStatus));
                combo.DataBind();
            }
        }
    }
}