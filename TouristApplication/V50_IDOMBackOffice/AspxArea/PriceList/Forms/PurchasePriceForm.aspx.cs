using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdomOffice.Interface.BackOffice.PriceLists;
using V50_IDOMBackOffice.AspxArea.PriceList.Controllers;

namespace V50_IDOMBackOffice.AspxArea.PriceList.Forms
{
    public partial class PurchasePriceForm : System.Web.UI.Page
    {
        IPricelistController controller = new PurchasePriceFormController();
        

        protected void Page_Init(object sender, EventArgs e)
        {
            PriceListControl1.InitController += new EventHandler(PriceListControl_InitController);
        }
        private void PriceListControl_InitController(object sender, EventArgs e)
        {
            // Citaj parametee iz Url-a
            Uri u = HttpContext.Current.Request.Url;
            string to = HttpUtility.ParseQueryString(u.Query).Get("to");
            string sc = HttpUtility.ParseQueryString(u.Query).Get("sc");
            string uc = HttpUtility.ParseQueryString(u.Query).Get("uc");
            string oc = HttpUtility.ParseQueryString(u.Query).Get("oc");
            string plt = HttpUtility.ParseQueryString(u.Query).Get("plt");

            var pec = (Controls.PriceListControl)sender;
            pec.Controller = controller;


            // ukoliko nema url parametara uzmi test podatke
            pec.SiteCode = sc == null ? "soline" : sc;
            pec.TourOperatorCode = to == null ? "IDOM" : uc;
            pec.OfferCode = oc == null ? "luna" : oc;
            pec.PriceListType = plt == null ? PriceListType.RetailPrice : (PriceListType)int.Parse(plt);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public List<SeasonUnitCondition> Get()
        {
            return new List<SeasonUnitCondition>();
        }

    }
}