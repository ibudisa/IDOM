using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdomOffice.Interface.BackOffice.Booking;
using IdomOffice.Interface.BackOffice.Booking.Entity;
using V50_IDOMBackOffice.AspxArea.Booking.Controllers;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using V50_IDOMBackOffice.AspxArea.MasterData.Controllers;
using V50_IDOMBackOffice.PlugIn.Controller;

namespace V50_IDOMBackOffice.SupportForms
{
    public partial class BookingView : System.Web.UI.Page
    {
        string modelid;
        UnitPopUpController controller = new UnitPopUpController();
        //BookingProcessController bookingcontroller = new BookingProcessController();
        CustomerController customercontroller = new CustomerController();
        CustomerViewModel customer;

        protected void Page_Load(object sender, EventArgs e)
        {
            Uri u = HttpContext.Current.Request.Url;
            modelid = HttpUtility.ParseQueryString(u.Query).Get("id");
            customer = customercontroller.GetCustomer(modelid);
            Bind();
        }


        private void Bind()
        {
            comboboxSite.DataSource = controller.GetSiteCodes();
            comboboxSite.DataBind();

        }

        protected void comboboxSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            string data = comboboxSite.SelectedItem.Text;
            comboboxUnit.DataSource = controller.GetUnitCodes(data);
            comboboxUnit.DataBind();
        }

        protected void comboboxUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            string unit = comboboxUnit.SelectedItem.Text;
            string site = comboboxSite.SelectedItem.Text;
            comboboxOffer.DataSource = controller.GetOfferCodes(site,unit);
            comboboxOffer.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var manager = PlugInManager.GetBookingDataManager();
            var bookingprocess = new BookingProcess();
            bookingprocess.Id = Guid.NewGuid().ToString();
            bookingprocess.Status = DocumentProcessStatus.Close;
            bookingprocess.OfferInfo.Country = txtCountry.Text;
            bookingprocess.OfferInfo.PlaceName = txtPlace.Text;
            bookingprocess.OfferInfo.SiteCode=comboboxSite.SelectedItem!=null?comboboxSite.SelectedItem.Text:"";
            string sitecode = bookingprocess.OfferInfo.SiteCode;
            string sitename = controller.GetSiteName(sitecode);
            bookingprocess.OfferInfo.SiteName = sitename;
            bookingprocess.OfferInfo.UnitCode = comboboxUnit.SelectedItem != null ? comboboxUnit.SelectedItem.Text : "";
            bookingprocess.OfferInfo.OfferCode = comboboxOffer.SelectedItem != null ? comboboxOffer.SelectedItem.Text : "";
            string offercode = bookingprocess.OfferInfo.OfferCode;
            string offername = controller.GetOfferName(offercode);
            bookingprocess.OfferInfo.OfferName = offername;
            bookingprocess.OfferInfo.TourOperatorCode = txtTourOperator.Text.Trim();
            bookingprocess.OfferInfo.CheckIn = ASPxDateEditCheckIn.Date;
            bookingprocess.OfferInfo.CheckOut = ASPxDateEditCheckOut.Date;
            bookingprocess.OfferInfo.Adults = int.Parse(txtAdults.Text.Trim());
            bookingprocess.OfferInfo.Children = int.Parse(txtChildren.Text.Trim());
            bookingprocess.TravelApplicant.FirstName = customer.FirstName;
            bookingprocess.TravelApplicant.LastName = customer.LastName;
            bookingprocess.TravelApplicant.Contry = customer.Country;
            bookingprocess.TravelApplicant.Adress = customer.Adress;
            bookingprocess.TravelApplicantId = customer.CustomerNr;
            bookingprocess.SellingPartner = int.Parse(txtPartnerId.Text.Trim());
            bookingprocess.Season = txtSeason.Text;
            bookingprocess.TravelApplicant.MobilePhone = customer.MobilePhone;
            bookingprocess.TravelApplicant.Phone = customer.Phone;
            bookingprocess.TravelApplicant.ZipCode = customer.ZipCode;
            bookingprocess.TravelApplicant.Place = customer.Place;
            bookingprocess.TravelApplicant.Salutation = customer.Salutation;
            bookingprocess.TravelApplicant.EMail = customer.EMail;
            List<TravelApplicantPayment> payments = bookingprocess.Payments;
            TravelApplicantPayment applicantPayment = new TravelApplicantPayment();
            applicantPayment.Date = ASPxDateEditPayment.Date;
            applicantPayment.Value = Decimal.Parse(txtPaymetnValue.Text.Trim());
            payments.Add(applicantPayment);
            bookingprocess.Payments = payments;
            bookingprocess.BookingNumber = txtBookingNumber.Text;

            manager.AddMasterData(bookingprocess);

        }
    }
}