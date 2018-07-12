using DevExpress.Web;
using IdomOffice.Interface.BackOffice.PriceLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using V50_IDOMBackOffice.AspxArea.PriceList.Controllers;
using V50_IDOMBackOffice.AspxArea.Helper;

namespace V50_IDOMBackOffice.AspxArea.PriceList.Controls
{
    public partial class PriceListControl : System.Web.UI.UserControl
    {
        public IPricelistController Controller { get; set; }
        public string SiteCode { get; set; }
        public string TourOperatorCode { get; set; }
        public string OfferCode { get; set; }
        public PriceListType PriceListType { get; set; }
        public bool IsReady { get; set; }
        private string PriceListId { get; set; }
        public event EventHandler InitController;
        
        protected void OnInitController()
        {
            if (InitController != null)
            {
                InitController(this, new EventArgs());
            }
        }

        Models.PriceListModel model;

        protected void Page_Load(object sender, EventArgs e)
        {  
                 OnInitController();
            //if (IsReady)
            //{
                string data = OfferCode;
                model = Controller.GetModel(TourOperatorCode, SiteCode, OfferCode, PriceListType);
                lblSiteName.Text = model.SiteName;
                lblUnitName.Text = model.UnitName;
                PriceListId = model.id;

                PriceListPageControl.ActiveTabIndex = 0;

                GridSeasonAndPriceView.DataSource = model.SeasonPriceList;
                GridSeasonAndPriceView.DataBind();

                GridSeasonUnitActionView.DataSource = model.ActionsList;
                GridSeasonUnitActionView.DataBind();

                GridSeasonUnitAvailabiltyView.DataSource = model.AvailabilityList;
                GridSeasonUnitAvailabiltyView.DataBind();

                GridSeasonUnitServiceView.DataSource = model.ServicesList;
                GridSeasonUnitServiceView.DataBind();

                GridSeasonUnitConditionView.DataSource = model.ConditionsList;
                GridSeasonUnitConditionView.DataBind();

                GridPaymentModeView.DataSource = model.PaymentModeList;
                GridPaymentModeView.DataBind();

                GridSpecialPricesView.DataSource = model.SpecialPricesList;
                GridSpecialPricesView.DataBind();
            //}
    
        }

        protected void GridSeasonAndPriceView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            List<SeasonAndPrice> seasonAndPrice = (List<SeasonAndPrice>)GridSeasonAndPriceView.DataSource;
            var newValue = e.Values;
            string id = e.Keys[0].ToString();
            var newPrice = seasonAndPrice.Where(p => p.Id == id).SingleOrDefault();
            seasonAndPrice.Remove(newPrice);
            
            Controller.SavePartialModelSeasonAndPrice(PriceListId, seasonAndPrice);

            e.Cancel = true;
            GridSeasonAndPriceView.CancelEdit();

            GridSeasonAndPriceView.DataSource = seasonAndPrice;
            GridSeasonAndPriceView.DataBind();
        }

        protected void GridSeasonAndPriceView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            List<SeasonAndPrice> seasonAndPrice = (List<SeasonAndPrice>)GridSeasonAndPriceView.DataSource;
            var newValue = e.NewValues;
            var newPrice = new SeasonAndPrice();
            newPrice.FromPersons = newValue["FromPersons"]==null? 0:(int)newValue["FromPersons"];
            newPrice.Eur = newValue["Eur"] == null ? 0 : (decimal)newValue["Eur"];
            newPrice.FromDate = newValue["FromDate"] == null ? DateTime.Now :GetDate((DateTime)newValue["FromDate"]);
            newPrice.PriceType = newValue["PriceType"]==null? PriceType.UnitPerNight: (PriceType)newValue["PriceType"];
            newPrice.ToDate = newValue["ToDate"] == null ? DateTime.Now :GetDate((DateTime)newValue["ToDate"]);
            newPrice.ToPersons = newValue["ToPersons"] == null ? 0 : (int)newValue["ToPersons"];

            seasonAndPrice.Add(newPrice);
            Controller.SavePartialModelSeasonAndPrice(PriceListId, seasonAndPrice);

            e.Cancel = true;
            GridSeasonAndPriceView.CancelEdit();

            var model = Controller.GetModel(TourOperatorCode, SiteCode, OfferCode, PriceListType);
            PriceListId = model.id;

            GridSeasonAndPriceView.DataSource = model.SeasonPriceList;
            GridSeasonAndPriceView.DataBind();
        }

        protected void GridSeasonAndPriceView_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            List<SeasonAndPrice> seasonAndPrice = (List<SeasonAndPrice>)GridSeasonAndPriceView.DataSource;
            var newValue = e.NewValues;
            string id = e.Keys[0].ToString();
            var selectPrice = seasonAndPrice.Where(p => p.Id == id).SingleOrDefault();
            
            selectPrice.FromPersons = newValue["FromPersons"] == null ? 0 : (int)newValue["FromPersons"];
            selectPrice.Eur = newValue["Eur"] == null ? 0 : (decimal)newValue["Eur"];
            selectPrice.FromDate = newValue["FromDate"] == null ? DateTime.Now : (DateTime)newValue["FromDate"];
            selectPrice.PriceType = newValue["PriceType"] == null ? PriceType.UnitPerNight : (PriceType)newValue["PriceType"];
            selectPrice.ToDate = newValue["ToDate"] == null ? DateTime.Now : (DateTime)newValue["ToDate"];
            selectPrice.ToPersons = newValue["ToPersons"] == null ? 0 : (int)newValue["ToPersons"];
        
            Controller.SavePartialModelSeasonAndPrice(PriceListId, seasonAndPrice);

            e.Cancel = true;
            GridSeasonAndPriceView.CancelEdit();

            GridSeasonAndPriceView.DataSource = seasonAndPrice;
            GridSeasonAndPriceView.DataBind();
        }


        protected void GridSeasonUnitActionView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            List<SeasonUnitAction> seasonUnitAction = (List<SeasonUnitAction>)GridSeasonUnitActionView.DataSource;
            var newValue = e.Values;
            string id = e.Keys[0].ToString();
            var newAction = seasonUnitAction.Where(c => c.Id == id).SingleOrDefault();
            seasonUnitAction.Remove(newAction);
            
                  
            Controller.SavePartialModelSeasonUnitAction
                (PriceListId, seasonUnitAction);

            e.Cancel = true;
            GridSeasonUnitActionView.CancelEdit();

            GridSeasonUnitActionView.DataSource = seasonUnitAction;
            GridSeasonUnitActionView.DataBind();
        }

        protected void GridSeasonUnitActionView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            List<SeasonUnitAction> seasonUnitAction = (List<SeasonUnitAction>)GridSeasonUnitActionView.DataSource;
            var newValue = e.NewValues;
            var newAction = new SeasonUnitAction();
            newAction.ActionStart = newValue["ActionStart"]==null? DateTime.Now :GetDate((DateTime)newValue["ActionStart"]);
            newAction.ActionEnd = newValue["ActionEnd"] == null ? DateTime.Now :GetDate((DateTime)newValue["ActionEnd"]);
            newAction.FromDate = newValue["FromDate"] == null ? DateTime.Now : GetDate((DateTime)newValue["FromDate"]);
            newAction.ActionType = newValue["ActionType"] == null ? ActionType.EarlyBooking : (ActionType)newValue["ActionType"];
            newAction.ToDate = newValue["ToDate"] == null ? DateTime.Now : GetDate((DateTime)newValue["ToDate"]);
            newAction.CanBeCombined = newValue["CanBeCombined"]==null? false: (bool)newValue["CanBeCombined"];
            newAction.DiscountEur = newValue["DiscountEur"] == null ? 0 : (decimal)newValue["DiscountEur"];
            newAction.DiscountPercent = newValue["DiscountPercent"] == null ? 0 : (decimal)newValue["DiscountPercent"];
            newAction.FreeNights = newValue["FreeNights"] == null ? 0 : (int)newValue["FreeNights"];
            newAction.MinPrice = newValue["MinPrice"] == null ? 0 : (int)newValue["MinPrice"];
            newAction.MinStayDays = newValue["MinStayDays"] == null ? 0 : (int)newValue["MinStayDays"];


            seasonUnitAction.Add(newAction);
            Controller.SavePartialModelSeasonUnitAction
                (PriceListId, seasonUnitAction);

            e.Cancel = true;
            GridSeasonUnitActionView.CancelEdit();

            var model = Controller.GetModel(TourOperatorCode,SiteCode, OfferCode, PriceListType);
            PriceListId = model.id;

            

            GridSeasonUnitActionView.DataSource = model.ActionsList;
            GridSeasonUnitActionView.DataBind();

            
        }

        protected void GridSeasonUnitActionView_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            List<SeasonUnitAction> seasonUnitAction = (List<SeasonUnitAction>)GridSeasonUnitActionView.DataSource;
            var newValue = e.NewValues;
            string id = e.Keys[0].ToString();
            var newAction = seasonUnitAction.Where(c => c.Id == id).SingleOrDefault();
         
            newAction.ActionStart = newValue["ActionStart"] == null ? DateTime.Now : (DateTime)newValue["ActionStart"];
            newAction.ActionEnd = newValue["ActionEnd"] == null ? DateTime.Now : (DateTime)newValue["ActionEnd"];
            newAction.FromDate = newValue["FromDate"] == null ? DateTime.Now : (DateTime)newValue["FromDate"];
            newAction.ActionType = newValue["ActionType"] == null ? ActionType.EarlyBooking : (ActionType)newValue["ActionType"];
            newAction.ToDate = newValue["ToDate"] == null ? DateTime.Now : (DateTime)newValue["ToDate"];
            newAction.CanBeCombined = newValue["CanBeCombined"]==null? false: (bool)newValue["CanBeCombined"];
            newAction.DiscountEur = newValue["DiscountEur"] == null ? 0 : (decimal)newValue["DiscountEur"];
            newAction.DiscountPercent = newValue["DiscountPercent"] == null ? 0 : (decimal)newValue["DiscountPercent"];
            newAction.FreeNights = newValue["FreeNights"] == null ? 0 : (int)newValue["FreeNights"];
            newAction.MinPrice = newValue["MinPrice"] == null ? 0 : (int)newValue["MinPrice"];
            newAction.MinStayDays = newValue["MinStayDays"] == null ? 0 : (int)newValue["MinStayDays"];

          
            Controller.SavePartialModelSeasonUnitAction
                (PriceListId, seasonUnitAction);

            e.Cancel = true;
            GridSeasonUnitActionView.CancelEdit();

            GridSeasonUnitActionView.DataSource = seasonUnitAction;
            GridSeasonUnitActionView.DataBind();
        }

        protected void GridSeasonUnitConditionView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            List<SeasonUnitCondition> seasonUnitCondition = (List<SeasonUnitCondition>)GridSeasonUnitConditionView.DataSource;
            var newValue = e.Values;
            string id = e.Keys[0].ToString();
            var newCondition = seasonUnitCondition.Where(p => p.Id == id).SingleOrDefault();
            seasonUnitCondition.Remove(newCondition);
            
            Controller.SavePartialModelSeasonUnitCondition
                (PriceListId, seasonUnitCondition);

            e.Cancel = true;
            GridSeasonUnitConditionView.CancelEdit();

            GridSeasonUnitConditionView.DataSource = seasonUnitCondition;
            GridSeasonUnitConditionView.DataBind();

        }

        protected void GridSeasonUnitConditionView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            List<SeasonUnitCondition> seasonUnitCondition = (List<SeasonUnitCondition>)GridSeasonUnitConditionView.DataSource;
            var newValue = e.NewValues;
            var newCondition = new SeasonUnitCondition();
            GridViewDataColumn col1 = GridSeasonUnitConditionView.Columns["ArrivalActual"] as GridViewDataColumn;
            GridViewDataColumn col2 = GridSeasonUnitConditionView.Columns["DepartureActual"] as GridViewDataColumn;
            ASPxCheckBoxList chkListArrival = GridSeasonUnitConditionView.FindEditRowCellTemplateControl(col1, "ASPxCheckBoxListArrival") as ASPxCheckBoxList;
            ASPxCheckBoxList chkListDeparture = GridSeasonUnitConditionView.FindEditRowCellTemplateControl(col2, "ASPxCheckBoxListDeparture") as ASPxCheckBoxList;

            List<string> arrivals = new List<string>();
            List<string> departures = new List<string>();

            if (chkListArrival.SelectedItems.Count < 7 && chkListArrival.SelectedItems.Count>0)
            {

                for (int i = 0; i < chkListArrival.SelectedItems.Count; i++)
                {
                    arrivals.Add(chkListArrival.SelectedItems[i].Text);
                }
            }
            else
            {
                arrivals.Add("Daily");
            }

            if (chkListDeparture.SelectedItems.Count < 7 && chkListDeparture.SelectedItems.Count >0)
            {
                for (int i = 0; i < chkListDeparture.SelectedItems.Count; i++)
                {
                    departures.Add(chkListDeparture.SelectedItems[i].Text);
                }
            }
            else
            {
                departures.Add("Daily");
            }

            int arrivalscount = chkListArrival.SelectedItems.Count;
            int departurescount = chkListDeparture.SelectedItems.Count;
            string arrival = string.Empty;
            string departure = string.Empty;

            if(arrivalscount>0)
            {
                if(arrivalscount==1)
                {
                    arrival = chkListArrival.SelectedItem.Text;
                }
                else if((arrivalscount>1)&&(arrivalscount<7))
                {
                    arrival = chkListArrival.SelectedItems[0].Text;
                }
                else
                {
                    arrival = "Daily";
                }
            }

            if(departurescount>0)
            {
                if (departurescount == 1)
                {
                    departure = chkListDeparture.SelectedItem.Text;
                }
                else if ((departurescount > 1) && (departurescount < 7))
                {
                    departure = chkListDeparture.SelectedItems[0].Text;
                }
                else
                {
                    departure = "Daily";
                }


            }

            newCondition.ArrivalActual = arrival;
            newCondition.DepartureActual = departure;
            newCondition.FromDate = newValue["FromDate"]==null? DateTime.Now :GetDate((DateTime)newValue["FromDate"]);
            newCondition.MinStay = newValue["MinStay"]==null? 0: (int)newValue["MinStay"];
            newCondition.ToDate = newValue["ToDate"] == null ? DateTime.Now : GetDate((DateTime)newValue["ToDate"]);
            newCondition.ReleaseDays = newValue["ReleaseDays"] == null ? 0 : (int)newValue["ReleaseDays"];

            newCondition.Arrival = arrivals;
            newCondition.Departure = departures;

            seasonUnitCondition.Add(newCondition);
            Controller.SavePartialModelSeasonUnitCondition
                (PriceListId, seasonUnitCondition);

            e.Cancel = true;
            GridSeasonUnitConditionView.CancelEdit();

            var model = Controller.GetModel(TourOperatorCode, SiteCode, OfferCode, PriceListType);
            PriceListId = model.id;   

            GridSeasonUnitConditionView.DataSource = model.ConditionsList;
            GridSeasonUnitConditionView.DataBind();

          
        }

        protected void GridSeasonUnitConditionView_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            List<SeasonUnitCondition> seasonUnitCondition = (List<SeasonUnitCondition>)GridSeasonUnitConditionView.DataSource;
            var newValue = e.NewValues;
            string id = e.Keys[0].ToString();
            var newCondition = seasonUnitCondition.Where(p => p.Id == id).SingleOrDefault();
            GridViewDataColumn col1 = GridSeasonUnitConditionView.Columns["ArrivalActual"] as GridViewDataColumn;
            GridViewDataColumn col2 = GridSeasonUnitConditionView.Columns["DepartureActual"] as GridViewDataColumn;
            ASPxCheckBoxList chkListArrival = GridSeasonUnitConditionView.FindEditRowCellTemplateControl(col1, "ASPxCheckBoxListArrival") as ASPxCheckBoxList;
            ASPxCheckBoxList chkListDeparture = GridSeasonUnitConditionView.FindEditRowCellTemplateControl(col2, "ASPxCheckBoxListDeparture") as ASPxCheckBoxList;

            int arrivalscount = chkListArrival.SelectedItems.Count;
            int departurescount = chkListDeparture.SelectedItems.Count;
            string arrival = string.Empty;
            string departure = string.Empty;

            if (arrivalscount > 0)
            {
                if (arrivalscount == 1)
                {
                    arrival = chkListArrival.SelectedItem.Text;
                }
                else if ((arrivalscount > 1) && (arrivalscount < 7))
                {
                    arrival = chkListArrival.SelectedItems[0].Text;
                }
                else
                {
                    arrival = "Daily";
                }
            }

            if (departurescount > 0)
            {
                if (departurescount == 1)
                {
                    departure = chkListDeparture.SelectedItem.Text;
                }
                else if ((departurescount > 1) && (departurescount < 7))
                {
                    departure = chkListDeparture.SelectedItems[0].Text;
                }
                else
                {
                    departure = "Daily";
                }


            }

            newCondition.ArrivalActual = arrival;
            newCondition.DepartureActual = departure;
            newCondition.FromDate = newValue["FromDate"] == null ? DateTime.Now : (DateTime)newValue["FromDate"];
            newCondition.MinStay = newValue["MinStay"] == null ? 0 : (int)newValue["MinStay"];
            newCondition.ToDate = newValue["ToDate"] == null ? DateTime.Now : (DateTime)newValue["ToDate"];
            newCondition.ReleaseDays = newValue["ReleaseDays"] == null ? 0 : (int)newValue["ReleaseDays"];
            
            Controller.SavePartialModelSeasonUnitCondition
                (PriceListId, seasonUnitCondition);

            e.Cancel = true;
            GridSeasonUnitConditionView.CancelEdit();

            GridSeasonUnitConditionView.DataSource = seasonUnitCondition;
            GridSeasonUnitConditionView.DataBind();
        }

        protected void GridSeasonUnitServiceView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            List<SeasonUnitService> seasonUnitService = (List<SeasonUnitService>)GridSeasonUnitServiceView.DataSource;
            var newValue = e.Values;
            string id = e.Keys[0].ToString();
            var newService = seasonUnitService.Where(p => p.Id == id).SingleOrDefault();
            seasonUnitService.Remove(newService);
            
            Controller.SavePartialModelSeasonUnitService
                (PriceListId, seasonUnitService);

            e.Cancel = true;
            GridSeasonUnitServiceView.CancelEdit();

            GridSeasonUnitServiceView.DataSource = seasonUnitService;
            GridSeasonUnitServiceView.DataBind();
        }

        protected void GridSeasonUnitServiceView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            List<SeasonUnitService> seasonUnitService = (List<SeasonUnitService>)GridSeasonUnitServiceView.DataSource;
            var newValue = e.NewValues;
            var newService = new SeasonUnitService();
            newService.Description = newValue["Description"].ToString()?? string.Empty;
            newService.Eur = newValue["Eur"]==null? 0: (decimal)newValue["Eur"];
            newService.FromDate = newValue["FromDate"]==null? DateTime.Now: GetDate((DateTime)newValue["FromDate"]);
            newService.IsOptional = newValue["IsOptional"]==null? false: (bool)newValue["IsOptional"];
            newService.ToDate = newValue["ToDate"] == null ? DateTime.Now :GetDate((DateTime)newValue["ToDate"]);
            newService.OfDay = newValue["OfDay"]==null? 0: (int)newValue["OfDay"];
            newService.OfOld = newValue["OfOld"] == null ? 0 : (int)newValue["OfOld"];
            newService.PaymentPlace = newValue["PaymentPlace"]==null? PaymentPlace.Arrival : (PaymentPlace)newValue["PaymentPlace"];
            newService.ServiceInterval = newValue["ServiceInterval"] == null ? ServiceInterval.PerDay : (ServiceInterval)newValue["ServiceInterval"];
            newService.ServiceType = newValue["ServiceType"] == null ? ServiceType.Bedclothes : (ServiceType)newValue["ServiceType"];
            newService.ServiceUnit = newValue["ServiceUnit"] == null ? ServiceUnit.PerObject : (ServiceUnit)newValue["ServiceUnit"];
            newService.ToDay = newValue["ToDay"] == null ? 0 : (int)newValue["ToDay"];
            newService.ToOld = newValue["ToOld"] == null ? 0 : (int)newValue["ToOld"];



            seasonUnitService.Add(newService);
            Controller.SavePartialModelSeasonUnitService
                (PriceListId, seasonUnitService);

            e.Cancel = true;
            GridSeasonUnitServiceView.CancelEdit();

            var model = Controller.GetModel(TourOperatorCode,SiteCode, OfferCode, PriceListType);
            PriceListId = model.id;
   

            GridSeasonUnitServiceView.DataSource = model.ServicesList;
            GridSeasonUnitServiceView.DataBind();

            
        }

        protected void GridSeasonUnitServiceView_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            List<SeasonUnitService> seasonUnitService = (List<SeasonUnitService>)GridSeasonUnitServiceView.DataSource;
            var newValue = e.NewValues;
            string id = e.Keys[0].ToString();
            var newService = seasonUnitService.Where(p => p.Id == id).SingleOrDefault();

            newService.Description = newValue["Description"].ToString() ?? string.Empty;
            newService.Eur = newValue["Eur"] == null ? 0 : (decimal)newValue["Eur"];
            newService.FromDate = newValue["FromDate"] == null ? DateTime.Now : (DateTime)newValue["FromDate"];
            newService.IsOptional = newValue["IsOptional"]==null? false: (bool)newValue["IsOptional"];
            newService.ToDate = newValue["ToDate"] == null ? DateTime.Now : (DateTime)newValue["ToDate"];
            newService.OfDay = newValue["OfDay"] == null ? 0 : (int)newValue["OfDay"];
            newService.OfOld = newValue["OfOld"] == null ? 0 : (int)newValue["OfOld"];
            newService.PaymentPlace = newValue["PaymentPlace"] == null ? PaymentPlace.Arrival : (PaymentPlace)newValue["PaymentPlace"];
            newService.ServiceInterval = newValue["ServiceInterval"] == null ? ServiceInterval.PerDay : (ServiceInterval)newValue["ServiceInterval"];
            newService.ServiceType = newValue["ServiceType"] == null ? ServiceType.Bedclothes : (ServiceType)newValue["ServiceType"];
            newService.ServiceUnit = newValue["ServiceUnit"] == null ? ServiceUnit.PerObject : (ServiceUnit)newValue["ServiceUnit"];
            newService.ToDay = newValue["ToDay"] == null ? 0 : (int)newValue["ToDay"];
            newService.ToOld = newValue["ToOld"] == null ? 0 : (int)newValue["ToOld"];


            Controller.SavePartialModelSeasonUnitService
                (PriceListId, seasonUnitService);

            e.Cancel = true;
            GridSeasonUnitServiceView.CancelEdit();

            GridSeasonUnitServiceView.DataSource = seasonUnitService;
            GridSeasonUnitServiceView.DataBind();
        }

        protected void GridPaymentModeView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            List<PaymentMode> paymentMode = (List<PaymentMode>)GridPaymentModeView.DataSource;
            var newValue = e.Values;
            string id = e.Keys[0].ToString();
            var newPaymentMode = paymentMode.Where(p => p.Id == id).SingleOrDefault();
            paymentMode.Remove(newPaymentMode);
           
            Controller.SavePartialModelPaymentMode
                (PriceListId, paymentMode);

            e.Cancel = true;
            GridPaymentModeView.CancelEdit();

            GridPaymentModeView.DataSource = paymentMode;
            GridPaymentModeView.DataBind();
        }

        protected void GridPaymentModeView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            List<PaymentMode> paymentMode = (List<PaymentMode>)GridPaymentModeView.DataSource;
            var newValue = e.NewValues;
            var newPaymentMode = new PaymentMode();
            newPaymentMode.PaymentModeTitel = newValue["PaymentModeTitel"] == null ? "" : newValue["PaymentModeTitel"].ToString();
            newPaymentMode.PaymentModeDescription= newValue["PaymentModeDescription"] == null ? "" : newValue["PaymentModeDescription"].ToString();
            newPaymentMode.BookingFromDate = newValue["BookingFromDate"]==null? DateTime.Now: GetDate((DateTime)newValue["BookingFromDate"]);
            newPaymentMode.BookingToDate = newValue["BookingToDate"] == null ? DateTime.Now : GetDate((DateTime)newValue["BookingToDate"]);
            newPaymentMode.CheckInFromDate = newValue["CheckInFromDate"] == null ? DateTime.Now : GetDate((DateTime)newValue["CheckInFromDate"]);
            newPaymentMode.CheckInToDate = newValue["CheckInToDate"] == null ? DateTime.Now : GetDate((DateTime)newValue["CheckInToDate"]);
            newPaymentMode.MinDayToArrival = newValue["MinDayToArrival"] ==null? 0: (int)newValue["MinDayToArrival"];
            newPaymentMode.MaxDayToArrival= newValue["MaxDayToArrival"] == null ? 0 : (int)newValue["MaxDayToArrival"];
            newPaymentMode.PriceDownPaymentAfterDays= newValue["PriceDownPaymentAfterDays"] == null ? 0 : (int)newValue["PriceDownPaymentAfterDays"];
            newPaymentMode.PriceDownPaymentPercent= newValue["PriceDownPaymentPercent"] == null ? 0 : (int)newValue["PriceDownPaymentPercent"];
            newPaymentMode.PricePercentDiscount= newValue["PricePercentDiscount"] == null ? 0 : (int)newValue["PricePercentDiscount"];
            newPaymentMode.PriceRemainingBeforDays= newValue["PriceRemainingBeforDays"] == null ? 0 : (int)newValue["PriceRemainingBeforDays"];
            newPaymentMode.PriceDownPaymentEur = newValue["PriceDownPaymentEur"] == null ? 0 : (int)newValue["PriceDownPaymentEur"];

            newPaymentMode.CancellationFeesPercent = newValue["CancellationFeesPercent"] == null ? 0 : (int)newValue["CancellationFeesPercent"];
            newPaymentMode.CancellationFeesToDays = newValue["CancellationFeesToDays"] == null ? 0 : (int)newValue["CancellationFeesToDays"];



            paymentMode.Add(newPaymentMode);
            Controller.SavePartialModelPaymentMode
                (PriceListId, paymentMode);

            e.Cancel = true;
            GridPaymentModeView.CancelEdit();

            var model = Controller.GetModel(TourOperatorCode, SiteCode, OfferCode, PriceListType);
            PriceListId = model.id;

            GridPaymentModeView.DataSource = model.PaymentModeList;
            GridPaymentModeView.DataBind();

           
        }

        protected void GridPaymentModeView_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            List<PaymentMode> paymentMode = (List<PaymentMode>)GridPaymentModeView.DataSource;
            var newValue = e.NewValues;
            string id = e.Keys[0].ToString();
            var newPaymentMode = paymentMode.Where(p => p.Id == id).SingleOrDefault();

            newPaymentMode.PaymentModeTitel = newValue["PaymentModeTitel"] == null ? "" : newValue["PaymentModeTitel"].ToString();
            newPaymentMode.PaymentModeDescription = newValue["PaymentModeDescription"] == null ? "" : newValue["PaymentModeDescription"].ToString();
            newPaymentMode.BookingFromDate = newValue["BookingFromDate"] == null ? DateTime.Now : GetDate((DateTime)newValue["BookingFromDate"]);
            newPaymentMode.BookingToDate = newValue["BookingToDate"] == null ? DateTime.Now : GetDate((DateTime)newValue["BookingToDate"]);
            newPaymentMode.CheckInFromDate = newValue["CheckInFromDate"] == null ? DateTime.Now : GetDate((DateTime)newValue["CheckInFromDate"]);
            newPaymentMode.CheckInToDate = newValue["CheckInToDate"] == null ? DateTime.Now : GetDate((DateTime)newValue["CheckInToDate"]);
            newPaymentMode.MinDayToArrival = newValue["MinDayToArrival"] == null ? 0 : (int)newValue["MinDayToArrival"];
            newPaymentMode.MaxDayToArrival = newValue["MaxDayToArrival"] == null ? 0 : (int)newValue["MaxDayToArrival"];
            newPaymentMode.PriceDownPaymentAfterDays = newValue["PriceDownPaymentAfterDays"] == null ? 0 : (int)newValue["PriceDownPaymentAfterDays"];
            newPaymentMode.PriceDownPaymentPercent = newValue["PriceDownPaymentPercent"] == null ? 0 : (int)newValue["PriceDownPaymentPercent"];
            newPaymentMode.PricePercentDiscount = newValue["PricePercentDiscount"] == null ? 0 : (int)newValue["PricePercentDiscount"];
            newPaymentMode.PriceRemainingBeforDays = newValue["PriceRemainingBeforDays"] == null ? 0 : (int)newValue["PriceRemainingBeforDays"];
            newPaymentMode.PriceDownPaymentEur = newValue["PriceDownPaymentEur"] == null ? 0 : (int)newValue["PriceDownPaymentEur"];
            newPaymentMode.CancellationFeesPercent= newValue["CancellationFeesPercent"] == null ? 0 : (int)newValue["CancellationFeesPercent"];
            newPaymentMode.CancellationFeesToDays= newValue["CancellationFeesToDays"] == null ? 0 : (int)newValue["CancellationFeesToDays"];

            Controller.SavePartialModelPaymentMode
                (PriceListId, paymentMode);

            e.Cancel = true;
            GridPaymentModeView.CancelEdit();

            GridPaymentModeView.DataSource = paymentMode;
            GridPaymentModeView.DataBind();
        }

        protected void GridSpecialPricesView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            List<SpecialPrices> specialPrices = (List<SpecialPrices>)GridSpecialPricesView.DataSource;
            var newValue = e.Values;
            string id = e.Keys[0].ToString();
            var newSpecialPrice = specialPrices.Where(p => p.Id == id).SingleOrDefault();
            specialPrices.Remove(newSpecialPrice);
           
            Controller.SavePartialModelSpecialPrices
                (PriceListId, specialPrices);


            e.Cancel = true;
            GridSpecialPricesView.CancelEdit();

            GridSpecialPricesView.DataSource = specialPrices;
            GridSpecialPricesView.DataBind();
        }

        protected void GridSpecialPricesView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            List<SpecialPrices> specialPrices = (List<SpecialPrices>)GridSpecialPricesView.DataSource;
            var newValue = e.NewValues;
            var newSpecialPrice = new SpecialPrices();
            newSpecialPrice.CheckIn = newValue["CheckIn"]==null? DateTime.Now : GetDate((DateTime)newValue["CheckIn"]);
            newSpecialPrice.CheckOut = newValue["CheckOut"] == null ? DateTime.Now : GetDate((DateTime)newValue["CheckOut"]); ;
            newSpecialPrice.Eur = newValue["Eur"]==null? 0: (decimal)newValue["Eur"];
            newSpecialPrice.FromPersons = newValue["FromPersons"] == null ? 0 : (int)newValue["FromPersons"];
            newSpecialPrice.ToPersons = newValue["ToPersons"] == null ? 0 : (int)newValue["ToPersons"];




            specialPrices.Add(newSpecialPrice);
            Controller.SavePartialModelSpecialPrices
                (PriceListId, specialPrices);

            e.Cancel = true;
            GridSpecialPricesView.CancelEdit();

            var model = Controller.GetModel(TourOperatorCode, SiteCode, OfferCode, PriceListType);
            PriceListId = model.id;

           

            GridSpecialPricesView.DataSource = model.SpecialPricesList;
            GridSpecialPricesView.DataBind();

        }

        protected void GridSpecialPricesView_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            List<SpecialPrices> specialPrices = (List<SpecialPrices>)GridSpecialPricesView.DataSource;
            var newValue = e.NewValues;
            string id = e.Keys[0].ToString();
            var newSpecialPrice = specialPrices.Where(p => p.Id == id).SingleOrDefault();
            newSpecialPrice.CheckIn = newValue["CheckIn"] == null ? DateTime.Now : (DateTime)newValue["CheckIn"];
            newSpecialPrice.CheckOut = newValue["CheckOut"] == null ? DateTime.Now : (DateTime)newValue["CheckOut"]; ;
            newSpecialPrice.Eur = newValue["Eur"] == null ? 0 : (decimal)newValue["Eur"];
            newSpecialPrice.FromPersons = newValue["FromPersons"] == null ? 0 : (int)newValue["FromPersons"];
            newSpecialPrice.ToPersons = newValue["ToPersons"] == null ? 0 : (int)newValue["ToPersons"];

            Controller.SavePartialModelSpecialPrices
                (PriceListId, specialPrices);

            e.Cancel = true;
            GridSpecialPricesView.CancelEdit();

            GridSpecialPricesView.DataSource = specialPrices;
            GridSpecialPricesView.DataBind();
        }

        protected void GridSeasonUnitAvailabiltyView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            List<SeasonUnitAvailability> availability = (List<SeasonUnitAvailability>)GridSeasonUnitAvailabiltyView.DataSource;
            var newValue = e.Values;
            string id = e.Keys[0].ToString();
            var newAvailability = availability.Where(p => p.Id == id).SingleOrDefault();
            availability.Remove(newAvailability);
           
            Controller.SavePartialModelSeasonUnitAvailability
                (PriceListId, availability);

            e.Cancel = true;
            GridSeasonUnitAvailabiltyView.CancelEdit();

            var model = Controller.GetModel(TourOperatorCode, SiteCode, OfferCode, PriceListType);
            PriceListId = model.id;
 

            GridSeasonUnitAvailabiltyView.DataSource = model.AvailabilityList;
            GridSeasonUnitAvailabiltyView.DataBind();

          
        }

        protected void GridSeasonUnitAvailabiltyView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            List<SeasonUnitAvailability> availability = (List<SeasonUnitAvailability>)GridSeasonUnitAvailabiltyView.DataSource;
            var newValue = e.NewValues;
            var newAvailability = new SeasonUnitAvailability();
            newAvailability.FromDate = newValue["FromDate"]==null? DateTime.Now : GetDate((DateTime)newValue["FromDate"]);
            newAvailability.ToDate = newValue["ToDate"] == null ? DateTime.Now :GetDate((DateTime)newValue["ToDate"]);
            newAvailability.IsAutoStopBooking = newValue["IsAutoStopBooking"] == null ? false : (bool)newValue["IsAutoStopBooking"];
            newAvailability.UnitCount = newValue["UnitCount"] == null ? 0 : (int)newValue["UnitCount"];



            availability.Add(newAvailability);
            Controller.SavePartialModelSeasonUnitAvailability
                (PriceListId, availability);

            e.Cancel = true;
            GridSeasonUnitAvailabiltyView.CancelEdit();

            var model = Controller.GetModel(TourOperatorCode, SiteCode, OfferCode, PriceListType);
            PriceListId = model.id;
            GridSeasonUnitAvailabiltyView.DataSource = model.AvailabilityList;
            GridSeasonUnitAvailabiltyView.DataBind();

        }

        protected void GridSeasonUnitAvailabiltyView_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            List<SeasonUnitAvailability> availability = (List<SeasonUnitAvailability>)GridSeasonUnitAvailabiltyView.DataSource;
            var newValue = e.NewValues;
            string id = e.Keys[0].ToString();
            var newAvailability = availability.Where(p => p.Id == id).SingleOrDefault();              newAvailability.FromDate = newValue["FromDate"]==null? DateTime.Now : (DateTime)newValue["FromDate"];
            newAvailability.ToDate = newValue["ToDate"] == null ? DateTime.Now : (DateTime)newValue["ToDate"];
            newAvailability.IsAutoStopBooking = newValue["IsAutoStopBooking"] == null ? false : (bool)newValue["IsAutoStopBooking"];
            newAvailability.UnitCount = newValue["UnitCount"] == null ? 0 : (int)newValue["UnitCount"];

            Controller.SavePartialModelSeasonUnitAvailability
                (PriceListId, availability);

            e.Cancel = true;
            GridSeasonUnitAvailabiltyView.CancelEdit();

            GridSeasonUnitAvailabiltyView.DataSource = availability;
            GridSeasonUnitAvailabiltyView.DataBind();
        }

        protected void GridSeasonAndPriceView_DataBinding(object sender, EventArgs e)
        {
            GridSeasonAndPriceView.ForceDataRowType(typeof(SeasonAndPrice));
        }

        protected void GridSeasonAndPriceView_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridViewEditorEventArgs e)
        {
          // 
            if (e.Column.FieldName == "PriceType")
            {
                ASPxComboBox combo = (ASPxComboBox)e.Editor;
                combo.DataSource = Enum.GetValues(typeof(PriceType));
                combo.DataBind();
            }
        }

        protected void GridSeasonUnitActionView_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {

            if (e.Column.FieldName == "ActionType")
            {
                ASPxComboBox combo = (ASPxComboBox)e.Editor;
                combo.DataSource = Enum.GetValues(typeof(ActionType));
                combo.DataBind();
            }
        }


        protected void GridSeasonUnitActionView_DataBinding(object sender, EventArgs e)
        {
            GridSeasonUnitActionView.ForceDataRowType(typeof(SeasonUnitAction));

        }

        protected void GridSeasonUnitServiceView_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "ServiceType")
            {
                ASPxComboBox combo = (ASPxComboBox)e.Editor;
                combo.DataSource = Enum.GetValues(typeof(ServiceType));
                combo.DataBind();
            }
            else if (e.Column.FieldName == "ServiceInterval")
            {
                ASPxComboBox combo = (ASPxComboBox)e.Editor;
                combo.DataSource = Enum.GetValues(typeof(ServiceInterval));
                combo.DataBind();
            }
            else if (e.Column.FieldName == "ServiceUnit")
            {
                ASPxComboBox combo = (ASPxComboBox)e.Editor;
                combo.DataSource = Enum.GetValues(typeof(ServiceUnit));
                combo.DataBind();
            }
            else if (e.Column.FieldName == "PaymentPlace")
            {
                ASPxComboBox combo = (ASPxComboBox)e.Editor;
                combo.DataSource = Enum.GetValues(typeof(PaymentPlace));
                combo.DataBind();
            }
        }

        protected void GridSeasonUnitServiceView_DataBinding(object sender, EventArgs e)
        {
            GridSeasonUnitServiceView.ForceDataRowType(typeof(SeasonUnitService));
        }

        protected void GridPaymentModeView_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            //if (e.Column.FieldName == "PaymentType")
            //{
            //    ASPxComboBox combo = (ASPxComboBox)e.Editor;
            //    combo.DataSource = Enum.GetValues(typeof(PaymentType));
            //    combo.DataBind();
            //}
            
            
        }

        protected void GridPaymentModeView_DataBinding(object sender, EventArgs e)
        {
            GridSeasonUnitServiceView.ForceDataRowType(typeof(PaymentMode));
        }

       

        protected void GridSeasonUnitConditionView_DataBinding(object sender, EventArgs e)
        {
            GridSeasonUnitActionView.ForceDataRowType(typeof(List<string>));
        }

        protected void GridSeasonUnitConditionView_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            
             List<SeasonUnitCondition> seasonUnitCondition = (List<SeasonUnitCondition>)GridSeasonUnitConditionView.DataSource;

            if (e.Column.FieldName == "ArrivalActual")
            {
                var chklist = e.Editor as ASPxCheckBoxList;
                int r = 0;
            }


            string id = e.KeyValue.ToString();
            var Condition = seasonUnitCondition.Where(p => p.Id == id).SingleOrDefault();
            string arrival = Condition.ArrivalActual;
            string departure = Condition.DepartureActual;

            ASPxEditBase edd = e.Editor;

            int i = edd.Controls.Count;
            GridViewDataColumn col1 = GridSeasonUnitConditionView.Columns["ArrivalActual"] as GridViewDataColumn;
            GridViewDataColumn col2 = GridSeasonUnitConditionView.Columns["DepartureActual"] as GridViewDataColumn;
            ASPxCheckBoxList chkListArrival = e.Editor.FindControl("ASPxCheckBoxListArrival") as ASPxCheckBoxList;
            ASPxCheckBoxList chkListDeparture = e.Editor.FindControl("ASPxCheckBoxListDeparture") as ASPxCheckBoxList;
            //chkListDeparture.SelectAll();


            //int index;
            //List<int> values = new List<int>();
            //object dataarrival = DataManager.GetCheckBoxIndex(arrival);
            //if (dataarrival is int)
            //{
            //    index = (int)dataarrival;
            //    chkListArrival.SelectedIndex = index;
            //}
            //else
            //{
            //    values = (List<int>)dataarrival;
            //    chkListArrival.SelectAll();
            //}

            //object datadeparture = DataManager.GetCheckBoxIndex(departure);
            //if (datadeparture is int)
            //{
            //    index = (int)datadeparture;
            //    chkListDeparture.SelectedIndex = index;
            //}
            //else
            //{
            //    values = (List<int>)datadeparture;
            //    chkListDeparture.SelectAll();
            //}


        }

        protected void GridSeasonUnitConditionView_HtmlEditFormCreated(object sender, ASPxGridViewEditFormEventArgs e)
        {
            List<string> lista = new List<string>();

            //lista.Add("Daily");
            lista.Add("Monday");
            lista.Add("Tuesday");
            lista.Add("Wednesday");
            lista.Add("Thursday");
            lista.Add("Friday");
            lista.Add("Saturday");
            lista.Add("Sunday");

          
            GridViewDataColumn col1 = GridSeasonUnitConditionView.Columns["ArrivalActual"] as GridViewDataColumn;
            GridViewDataColumn col2 = GridSeasonUnitConditionView.Columns["DepartureActual"] as GridViewDataColumn;
            ASPxCheckBoxList chkListArrival = GridSeasonUnitConditionView.FindEditRowCellTemplateControl(col1, "ASPxCheckBoxListArrival") as ASPxCheckBoxList;
            ASPxCheckBoxList chkListDeparture = GridSeasonUnitConditionView.FindEditRowCellTemplateControl(col2, "ASPxCheckBoxListDeparture") as ASPxCheckBoxList;

            chkListArrival.DataSource = lista;
            chkListArrival.DataBind();

            chkListDeparture.DataSource = lista;
            chkListDeparture.DataBind();

          
            


        }

        protected void GridSeasonAndPriceView_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (GridSeasonAndPriceView.IsNewRowEditing)
                GridSeasonAndPriceView.DoRowValidation();
        }

        protected void GridSeasonAndPriceView_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            GridValidation.ValidateInt("FromPersons", sender, e);
            GridValidation.ValidateInt("ToPersons", sender, e);
            
        }

        protected void GridSeasonAndPriceView_Init(object sender, EventArgs e)
        {
            GridSeasonAndPriceView.Columns["Id"].Visible = false;
        }

        protected void GridSeasonUnitActionView_Init(object sender, EventArgs e)
        {
            GridSeasonUnitActionView.Columns["Id"].Visible = false;
        }

        protected void GridSeasonUnitActionView_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (GridSeasonUnitActionView.IsNewRowEditing)
                GridSeasonUnitActionView.DoRowValidation();
        }

        protected void GridSeasonUnitActionView_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            GridValidation.ValidateInt("MinStayDays", sender, e);
            GridValidation.ValidateInt("MinPrice", sender, e);
            GridValidation.ValidateInt("FreeNights", sender, e);
           


        }

        protected void GridSeasonUnitAvailabiltyView_Init(object sender, EventArgs e)
        {
            GridSeasonUnitAvailabiltyView.Columns["Id"].Visible = false;
        }

        protected void GridSeasonUnitAvailabiltyView_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (GridSeasonUnitAvailabiltyView.IsNewRowEditing)
                GridSeasonUnitAvailabiltyView.DoRowValidation();
        }

        protected void GridSeasonUnitAvailabiltyView_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            GridValidation.ValidateInt("UnitCount", sender, e);
           
        }

        protected void GridSeasonUnitServiceView_Init(object sender, EventArgs e)
        {
            GridSeasonUnitServiceView.Columns["Id"].Visible = false;
        }

        protected void GridSeasonUnitServiceView_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (GridSeasonUnitServiceView.IsNewRowEditing)
                GridSeasonUnitServiceView.DoRowValidation();
        }

        protected void GridSeasonUnitServiceView_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

            GridValidation.ValidateInt("OfOld", sender, e);
            GridValidation.ValidateInt("ToOld", sender, e);
            GridValidation.ValidateInt("OfDay", sender, e);
            GridValidation.ValidateInt("ToDay", sender, e);
           
            GridValidation.ValidateLength("Description",2, sender, e);
           
        }

        protected void GridSeasonUnitConditionView_Init(object sender, EventArgs e)
        {
            GridSeasonUnitConditionView.Columns["Id"].Visible = false;
        }

        protected void GridSeasonUnitConditionView_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (GridSeasonUnitConditionView.IsNewRowEditing)
            {

                GridSeasonUnitConditionView.DoRowValidation();
            }
            List<SeasonUnitCondition> seasonUnitCondition = (List<SeasonUnitCondition>)GridSeasonUnitConditionView.DataSource;
            
            //string id = e.EditingKeyValue.ToString();
            //var Condition = seasonUnitCondition.Where(p => p.Id == id).SingleOrDefault();
            //string arrival = Condition.ArrivalActual;
            //string departure = Condition.DepartureActual;

            //GridViewDataColumn col1 = GridSeasonUnitConditionView.Columns["ArrivalActual"] as GridViewDataColumn;
            //GridViewDataColumn col2 = GridSeasonUnitConditionView.Columns["DepartureActual"] as GridViewDataColumn;
            //ASPxCheckBoxList chkListArrival = GridSeasonUnitConditionView.FindEditRowCellTemplateControl(col1, "ASPxCheckBoxListArrival") as ASPxCheckBoxList;
            //ASPxCheckBoxList chkListDeparture = GridSeasonUnitConditionView.FindEditRowCellTemplateControl(col2, "ASPxCheckBoxListDeparture") as ASPxCheckBoxList;
            //chkListDeparture.SelectAll();




            //int index;
            //List<int> values = new List<int>();
            //object dataarrival = DataManager.GetCheckBoxIndex(arrival);
            //if (dataarrival is int)
            //{
            //    index = (int)dataarrival;
            //    chkListArrival.SelectedIndex = index;
            //}
            //else
            //{
            //    values = (List<int>)dataarrival;
            //    chkListArrival.SelectAll();
            //}

            //object datadeparture = DataManager.GetCheckBoxIndex(departure);
            //if (datadeparture is int)
            //{
            //    index = (int)datadeparture;
            //    chkListDeparture.SelectedIndex = index;
            //}
            //else
            //{
            //    values = (List<int>)datadeparture;
            //    chkListDeparture.SelectAll();
            //}

        }

        protected void GridSeasonUnitConditionView_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

            GridValidation.ValidateInt("MinStay", sender, e);
            GridValidation.ValidateInt("ReleaseDays", sender, e);
            //GridValidation.ValidateLength("ArrivalActual", sender, e);
            //GridValidation.ValidateLength("DepartureActual", sender, e);


        }

        protected void GridPaymentModeView_Init(object sender, EventArgs e)
        {
            GridPaymentModeView.Columns["Id"].Visible = false;
            GridPaymentModeView.Columns["PaymentModeDescription"].Visible = false;
            //GridPaymentModeView.Columns["PriceDownPaymentPercent"].Visible = false;
            GridPaymentModeView.Columns["PriceDownPaymentEur"].Visible = false;
        }

        protected void GridPaymentModeView_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (GridPaymentModeView.IsNewRowEditing)
                GridPaymentModeView.DoRowValidation();
        }

        protected void GridPaymentModeView_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            GridValidation.ValidateInt("MinDayToArrival", sender, e);
            GridValidation.ValidateInt("Percent", sender, e);
          
        }

        protected void GridSpecialPricesView_Init(object sender, EventArgs e)
        {
            GridSpecialPricesView.Columns["Id"].Visible = false;
        }

        protected void GridSpecialPricesView_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (GridSpecialPricesView.IsNewRowEditing)
                GridSpecialPricesView.DoRowValidation();
        }

        protected void GridSpecialPricesView_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

            GridValidation.ValidateInt("FromPersons", sender, e);
            GridValidation.ValidateInt("ToPersons", sender, e);
           
        }

        private DateTime GetDate(DateTime value)
        {
            DateTime date = value.AddHours(8);
            return date;
        }

        protected void GridSeasonAndPriceView_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {           
            var  pairList = Controller.GetSeasonAndPriceDefaultValue(model);
            foreach (var item in pairList)
                e.NewValues.Add(item.Key, item.Value);

        }

        protected void GridSeasonUnitServiceView_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            var pairList = Controller.GetServicesListeDefaultValue(model);
            foreach (var item in pairList)
                e.NewValues.Add(item.Key, item.Value);
        }

        protected void GridSeasonUnitConditionView_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            //if (e.CommandSource.ToString() == "Edit")
            //{

            //    GridViewDataColumn col1 = GridSeasonUnitConditionView.Columns["ArrivalActual"] as GridViewDataColumn;
            //    GridViewDataColumn col2 = GridSeasonUnitConditionView.Columns["DepartureActual"] as GridViewDataColumn;
            //    ASPxCheckBoxList chkListArrival = GridSeasonUnitConditionView.FindEditRowCellTemplateControl(col1, "ASPxCheckBoxListArrival") as ASPxCheckBoxList;
            //    ASPxCheckBoxList chkListDeparture = GridSeasonUnitConditionView.FindEditRowCellTemplateControl(col2, "ASPxCheckBoxListDeparture") as ASPxCheckBoxList;
            //    chkListDeparture.SelectAll();
            //}
        }

        protected void GridSeasonUnitConditionView_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            if(e.DataColumn.Name=="DepartureActual")
            {
               
            }

          
        }

        protected void GridSeasonUnitActionView_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            var pairList = Controller.GetActionsListDefaultValue(model);
            foreach (var item in pairList)
                e.NewValues.Add(item.Key, item.Value);
        }

        protected void GridSeasonUnitAvailabiltyView_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            var pairList = Controller.GetAvalailabilityListDefaultValue(model);
            foreach (var item in pairList)
                e.NewValues.Add(item.Key, item.Value);
        }

        protected void GridSeasonUnitConditionView_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            var pairList = Controller.GetConditionsListDefaultValue(model);
            foreach (var item in pairList)
            {
                if (item.Key != "ArrivalActual" && item.Key != "DepartureActual")
                {
                    e.NewValues.Add(item.Key, item.Value);
                }
                else
                {

                    //if(item.Key=="ArrivalActual")
                    //{
                    //    GridViewDataColumn col1 = GridSeasonUnitConditionView.Columns["ArrivalActual"] as GridViewDataColumn;
                    //    ASPxCheckBoxList chkListArrival = GridSeasonUnitConditionView.FindEditRowCellTemplateControl(col1, "ASPxCheckBoxListArrival") as ASPxCheckBoxList;
                    //    chkListArrival.SelectedIndex = int.Parse(item.Value.ToString());
                    //}
                    //else
                    //{
                    //    GridViewDataColumn col2 = GridSeasonUnitConditionView.Columns["DepartureActual"] as GridViewDataColumn;
                    //    ASPxCheckBoxList chkListDeparture = GridSeasonUnitConditionView.FindEditRowCellTemplateControl(col2, "ASPxCheckBoxListDeparture") as ASPxCheckBoxList;
                    //    chkListDeparture.SelectedIndex = int.Parse(item.Value.ToString());
                    //}
                }
            }
        }

        protected void GridPaymentModeView_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            var pairList = Controller.GetPaymentModesListDefaultValue(model);
            foreach (var item in pairList)
                e.NewValues.Add(item.Key, item.Value);
        }

        protected void GridSeasonUnitConditionView_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType == GridViewRowType.EditForm)
            {
                ASPxGridView gridView = (ASPxGridView)sender;
                GridViewDataColumn col1 = gridView.Columns["ArrivalActual"] as GridViewDataColumn;
                GridViewDataColumn col2 = gridView.Columns["DepartureActual"] as GridViewDataColumn;
                ASPxCheckBoxList chkListArrival = gridView.FindEditRowCellTemplateControl(col1, "ASPxCheckBoxListArrival") as ASPxCheckBoxList;
                ASPxCheckBoxList chkListDeparture = gridView.FindEditRowCellTemplateControl(col2, "ASPxCheckBoxListDeparture") as ASPxCheckBoxList;

            }
        }

        protected void GridSeasonUnitConditionView_AutoFilterCellEditorCreate(object sender, ASPxGridViewEditorCreateEventArgs e)
        {
            if(e.Column.FieldName=="ArrivalActual")
            {
                int r = 0;
            }
        }
    }
}
