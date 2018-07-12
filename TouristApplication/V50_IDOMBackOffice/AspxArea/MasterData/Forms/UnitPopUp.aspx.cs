using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using V50_IDOMBackOffice.AspxArea.PriceList.Models;
using V50_IDOMBackOffice.AspxArea.MasterData.Controllers;
using IdomOffice.Interface.BackOffice.PriceLists;
using V50_IDOMBackOffice.AspxArea.PriceList.Controllers;
using V50_IDOMBackOffice.AspxArea.PriceList.Controls;

namespace V50_IDOMBackOffice.AspxArea.MasterData.Forms
{
    public partial class UnitPopUp : System.Web.UI.Page
    {

        UnitPopUpController controller = new UnitPopUpController();
        IPricelistController pricecontroller = new PurchasePriceFormController();

        PriceListModel model;
     
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!IsPostBack)
            {
                Bind();
            }
          
        }

        private void Bind()
        {
            comboboxSiteCode.DataSource = controller.GetSiteCodes();
            comboboxSiteCode.DataBind();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Uri u = HttpContext.Current.Request.Url;
            string to = HttpUtility.ParseQueryString(u.Query).Get("to");
            string sc = HttpUtility.ParseQueryString(u.Query).Get("sc");
            string uc = HttpUtility.ParseQueryString(u.Query).Get("uc");
            string oc = HttpUtility.ParseQueryString(u.Query).Get("oc");
            string plt = HttpUtility.ParseQueryString(u.Query).Get("plt");
            PriceListType targetpricetype = (PriceListType)Enum.Parse(typeof(PriceListType), plt, true);

            string sitecode = comboboxSiteCode.SelectedItem==null ? string.Empty: comboboxSiteCode.SelectedItem.Text;
          //  string unitcode = comboboxUnitCode.SelectedItem==null ? string.Empty: comboboxUnitCode.SelectedItem.Text;
            string offercode = comboboxOfferCode.SelectedIndex < 0 ? null : comboboxOfferCode.SelectedItem.Text;
            string pricelisttype = comboboxPriceListType.SelectedItem == null ? string.Empty : comboboxPriceListType.SelectedItem.Text;
            PriceListType pricetype = (PriceListType)Enum.Parse(typeof(PriceListType), pricelisttype, true);
            string faktor = txtFaktor.Text;
            decimal faktorvalue = Decimal.Parse(txtFaktor.Text);
            pricecontroller.CopyPriceList(to, sitecode, offercode, pricetype, sc, uc, oc, targetpricetype, faktorvalue);
            //model = pricecontroller.GetModel(sitecode, unitcode, offercode, pricetype);
            //string id = model.id;

            //List<SeasonAndPrice> SeasonPrice = new List<SeasonAndPrice>();
            //List<SeasonUnitAvailability> Availability = new List<SeasonUnitAvailability>();
            //List<SeasonUnitAction> Actions= new List<SeasonUnitAction>();
            //List<SeasonUnitCondition> Conditions = new List<SeasonUnitCondition>();
            //List<SeasonUnitService> Services = new List<SeasonUnitService>();
            //List<PaymentMode> PaymentMode = new List<PaymentMode>();
            //List<SpecialPrices> SpecialPrices = new List<SpecialPrices>();

            //var price = model.SeasonPriceList;
            //SeasonPrice = model.SeasonPriceList;
            //Availability = model.AvailabilityList;
            //Actions = model.ActionsList;
            //Conditions = model.ConditionsList;
            //Services = model.ServicesList;
            //PaymentMode = model.PaymentModeList;
            //SpecialPrices = model.SpecialPricesList;

            //if(model.SeasonPriceList.Count>0)
            //{
            //    var prices = GetPrices(price, faktorvalue);
            //    SeasonPrice.AddRange(prices);
            //}
            //if(model.AvailabilityList.Count>0)
            //{
            //    Availability.AddRange(model.AvailabilityList);
            //}
            //if(model.ActionsList.Count>0)
            //{
            //    Actions.AddRange(model.ActionsList);
            //}
            //if(model.ConditionsList.Count>0)
            //{
            //    Conditions.AddRange(model.ConditionsList);
            //}
            //if(model.ServicesList.Count>0)
            //{
            //    Services.AddRange(model.ServicesList);
            //}
            //if(model.PaymentModeList.Count>0)
            //{
            //    PaymentMode.AddRange(model.PaymentModeList);
            //}
            //if(model.SpecialPricesList.Count>0)
            //{
            //    SpecialPrices.AddRange(model.SpecialPricesList);
            //}

            //pricecontroller.SavePartialModelSeasonAndPrice(id, SeasonPrice);
            //pricecontroller.SavePartialModelSeasonUnitAction(id, Actions);
            //pricecontroller.SavePartialModelSeasonUnitAvailability(id, Availability);
            //pricecontroller.SavePartialModelSeasonUnitCondition(id, Conditions);
            //pricecontroller.SavePartialModelSeasonUnitService(id, Services);
            //pricecontroller.SavePartialModelSpecialPrices(id, SpecialPrices);
            //pricecontroller.SavePartialModelPaymentMode(id, PaymentMode);

        }

        protected void comboboxSiteCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sitecode = comboboxSiteCode.SelectedItem.Text;
         //   string unitcode = comboboxUnitCode.SelectedItem.Text;
            comboboxOfferCode.DataSource = controller.GetOfferCodes(sitecode);
            comboboxOfferCode.DataBind();
        }

        protected void comboboxUnitCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void comboboxOfferCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sitecode = comboboxSiteCode.SelectedItem.Text;
         //   string unitcode = comboboxUnitCode.SelectedItem.Text;
            string offercode = comboboxOfferCode.SelectedItem.Text;
            comboboxPriceListType.DataSource = controller.GetPriceListTypes(sitecode, offercode);
            comboboxPriceListType.DataBind();
        }

        private List<SeasonAndPrice> GetPrices(List<SeasonAndPrice> prices,decimal faktor)
        {
            List<SeasonAndPrice> newprices = new List<SeasonAndPrice>();

            foreach(var price in prices)
            {
                SeasonAndPrice seasonandprice = new SeasonAndPrice();
                seasonandprice = price;
                seasonandprice.Eur *= faktor;
                newprices.Add(seasonandprice);
            }
            return newprices;
        }
    }
}