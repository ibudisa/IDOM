using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdomOffice.Interface.BackOffice.PriceLists;
using V50_IDOMBackOffice.AspxArea.PriceList.Controllers;
using V50_IDOMBackOffice.AspxArea.Helper;

namespace V50_IDOMBackOffice.AspxArea.PriceList.Forms
{
    public partial class RetailPriceForm : System.Web.UI.Page
    {
        IPricelistController controller = new PurchasePriceFormController();
 

        PriceListType t;
       
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
            if (comboboxPrice.SelectedItem != null)
                plt = comboboxPrice.SelectedItem.Value.ToString();
            
            // ukoliko nema url parametara uzmi test podatke
            pec.SiteCode = sc == null ? "" : sc;
            pec.TourOperatorCode = to == null ? "" : to;
            pec.OfferCode = oc == null ? "" : oc;
            pec.PriceListType = (PriceListType)int.Parse(plt);

         // kreiraj link za pop up dijalog
            PopupControlData.ContentUrl = "~/AspxArea/MasterData/Forms/UnitPopUp.aspx?sc=" + sc + "&to=" + pec.TourOperatorCode + "&oc=" + pec.OfferCode + "&plt=" + (int)pec.PriceListType;
        }

        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //this.btnSelect.Click += new System.EventHandler(btnSelect_Click);
            //this.btnSelect.Click += new EventHandler(PriceListControl_InitController);
            
            this.Load += new System.EventHandler(this.Page_Load);

        }

        protected void Page_Init(object sender,EventArgs e)
        {
            PriceListControl1.InitController += new EventHandler(PriceListControl_InitController);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
             
            comboboxPrice.DataSource = DataManager.GetRetailPrices();
            comboboxPrice.DataBind();
            if (!IsPostBack)
                comboboxPrice.SelectedIndex = 0;


        }

     

        protected void comboboxPrice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}