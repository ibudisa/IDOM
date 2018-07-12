using IdomOffice.Interface.BackOffice.PriceLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using V50_IDOMBackOffice.AspxArea.PriceList.Controllers;

namespace V50_IDOMBackOffice.AspxArea.PriceList.Forms
{
    public partial class DirectRetailPriceForm : System.Web.UI.Page
    {

        RetailPriceController controller = new RetailPriceController();
        IPricelistController pricecontroller = new PurchasePriceFormController();

        protected void Page_Init(object sender, EventArgs e)
        {
            PriceListControl1.InitController += new EventHandler(PriceListControl_InitController);
        }
        private void PriceListControl_InitController(object sender, EventArgs e)
        {
            // Citaj parametee iz Url-a
            //Uri u = HttpContext.Current.Request.Url;
            string to=null;
            string sc=null;
            string uc=null;
            string oc=null;
            string plt=null;


            var pec = (Controls.PriceListControl)sender;
            pec.Controller = pricecontroller;

            if ((comboboxTourOperator.SelectedItem != null) && (comboboxSite.SelectedItem != null) && (comboboxOffer.SelectedItem != null))
            {
                to = comboboxTourOperator.SelectedItem.Text;
                sc = comboboxSite.SelectedItem.Text;
                oc = comboboxOffer.SelectedItem.Text;

                pec.IsReady = true;
                pec.SiteCode = sc == null ? "soline" : sc;
                pec.TourOperatorCode = to == null ? "IDOM" : to;
                pec.OfferCode = oc == null ? "luna" : oc;
                pec.PriceListType = plt == null ? PriceListType.RetailPrice : (PriceListType)int.Parse(plt);
            }
            else
            {
                pec.IsReady = false;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        private void Bind()
        {
            comboboxTourOperator.DataSource = controller.GetTouristCodes();
            comboboxTourOperator.DataBind();
        }

        protected void comboboxTourOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            string touroperator = comboboxTourOperator.SelectedItem.Text;
            comboboxSite.DataSource = controller.GetTouristSites(touroperator);
            comboboxSite.DataBind();
        }

        protected void comboboxSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            string site = comboboxSite.SelectedItem.Text;
            comboboxOffer.DataSource = controller.GetUnitOffers(site);
            comboboxOffer.DataBind();
        }
    }
}