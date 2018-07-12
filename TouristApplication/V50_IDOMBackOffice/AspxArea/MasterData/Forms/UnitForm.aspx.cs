using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using V50_IDOMBackOffice.AspxArea.MasterData.Models;
using V50_IDOMBackOffice.AspxArea.MasterData.Controllers;
using V50_IDOMBackOffice.AspxArea.PriceList.Controllers;
using V50_IDOMBackOffice.AspxArea.PriceList.Controls;
using IdomOffice.Interface.BackOffice.PriceLists;
using IdomOffice.Interface.BackOffice.MasterData;
using V50_IDOMBackOffice.AspxArea.Helper;
using DevExpress.Web;
using System.IO;
using DevExpress.Web.ASPxHtmlEditor;
using QTouristik.Data;


namespace V50_IDOMBackOffice.AspxArea.MasterData.Forms
{
    public partial class UnitForm : System.Web.UI.Page
    {
        TouristUnitController controller = new TouristUnitController();
        UnitOfferController offercontroller = new UnitOfferController();
        TouristUnitViewModel model;
        string id;
        string sitecode;
        string unitcode;
        string folder;
        bool firstload;

        IPricelistController pricecontroller = new PurchasePriceFormController();


        protected void Page_Init(object sender, EventArgs e)
        {
            PriceListControl1.InitController += new EventHandler(PriceListControl_InitController);
        }
        private void PriceListControl_InitController(object sender, EventArgs e)
        {
            Uri u = HttpContext.Current.Request.Url;
            string sc = HttpUtility.ParseQueryString(u.Query).Get("sc");
            string uc = HttpUtility.ParseQueryString(u.Query).Get("uc");
            string oc = HttpUtility.ParseQueryString(u.Query).Get("oc");
            string plt = HttpUtility.ParseQueryString(u.Query).Get("plt");
            string to = HttpUtility.ParseQueryString(u.Query).Get("to");
            var pec = (PriceListControl)sender;
            pec.Controller = pricecontroller;


            // ukoliko nema url parametara uzmi test podatke
            pec.SiteCode = sc == null ? "ERROR" : sc;
            pec.TourOperatorCode = to == null ? "ERROR" : to;
            pec.OfferCode = oc == null ? uc : oc;
            pec.PriceListType = plt == null ? PriceListType.PurchasePrice : (PriceListType)int.Parse(plt);
            string id = pricecontroller.GetPriceListId(pec.TourOperatorCode, pec.SiteCode,pec.OfferCode, pec.PriceListType);
            // kreiraj link za pop up dijalog
            PopupControlData.ContentUrl = "~/AspxArea/MasterData/Forms/UnitPopUp.aspx?sc=" + pec.SiteCode +  "&oc=" + pec.OfferCode + "&plt=" + (int) pec.PriceListType;
//Test
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageUnitControl.ActiveTabIndex = 0;
                Uri u = HttpContext.Current.Request.Url;
                id = HttpUtility.ParseQueryString(u.Query).Get("id");
                sitecode = HttpUtility.ParseQueryString(u.Query).Get("sc");
                unitcode = HttpUtility.ParseQueryString(u.Query).Get("uc");
                ViewState["id"] = id;
                ViewState["sitecode"] = sitecode;
                ViewState["unitcode"] = unitcode;
                model = controller.GetTouristUnit(id);
                firstload = true;
                Bind();

                folder= CreateFolder(sitecode, unitcode);
                ViewState["folder"] = folder;
               
            }
            else
            {
                id = (string)ViewState["id"];
                sitecode = (string)ViewState["sitecode"];
                unitcode = (string)ViewState["unitcode"];
                folder = (string)ViewState["folder"];
                model = controller.GetTouristUnit(id);
                var offers = offercontroller.GetUnitOfferByCode(sitecode, unitcode);
                GridUnitOfferView.DataSource = offers;
                GridUnitOfferView.DataBind();

            }
        }

        

        private void Bind()
        {
            lblSite.Text = model.SiteName;
            lblUnit.Text = model.UnitTitel;
            lblSiteCode.Text = sitecode;
            lblUnitCode.Text = unitcode;

            if (txtMaxBelegung.Text != null)
            {
                txtMaxBelegung.Text = model.MaxPersons.ToString();
            }
            if (txtErwachsene.Text != null)
            {
                txtErwachsene.Text = model.MaxAdults.ToString();
            }

            comboHaustier.DataSource = DataManager.GetPets();
            comboHaustier.DataBind();
            int index = controller.GetPet(model);
            comboHaustier.SelectedIndex = index;

            comboboxLanguage.DataSource = DataManager.GetLanguages();
            comboboxLanguage.DataBind();
            comboboxLanguage.SelectedIndex = 0;

            comboboxLanguageKurz.DataSource = DataManager.GetLanguages();
            comboboxLanguageKurz.DataBind();
            comboboxLanguageKurz.SelectedIndex = 0;

            HtmlEditorKurzBeschreibung.Html = model.ShortDescription;
            HtmlEditorPageBeschreibung.Html = model.Description;

            lblKurz.Text = GetText().Length.ToString();

            var layoutinfo = controller.GetLayoutInfo(model);

            LayoutObjektInfo.DataSource = layoutinfo;
            LayoutObjektInfo.DataBind();

            ASPxComboBox comboboxType = (ASPxComboBox)LayoutObjektInfo.FindNestedControlByFieldName("TerraceType");
            comboboxType.DataSource = DataManager.GetTerraceTypes();
            comboboxType.DataBind();
            index = controller.GetTerraceType(model);
            comboboxTerasseTyp.SelectedIndex = index;

            ASPxComboBox comboboxSea = (ASPxComboBox)LayoutObjektInfo.FindNestedControlByFieldName("LocationSea");
            comboboxSea.DataSource = DataManager.GetDistances();
            comboboxSea.DataBind();
            index = controller.GetSeaLocation(model);
            comboboxSea.SelectedIndex = index;

            ASPxComboBox comboboxSite = (ASPxComboBox)LayoutObjektInfo.FindNestedControlByFieldName("LocationSite");
            comboboxSite.DataSource = DataManager.GetPositions();
            comboboxSite.DataBind();
            index = controller.GetSiteLocation(model);
            comboboxSite.SelectedIndex = index;

            var layoutdaten = controller.GetLayoutDaten(model);
            LayoutDaten.DataSource = layoutdaten;
            LayoutDaten.DataBind();

            var offers = offercontroller.GetUnitOfferByCode(sitecode, unitcode);
            GridUnitOfferView.DataSource = offers;
            GridUnitOfferView.DataBind();
        }


        protected void btnUpdates_Click(object sender, EventArgs e)
        {
            int MaxPersons = LayoutDaten.GetNestedControlValueByFieldName("MaxPersons") == null ? 0 : int.Parse(LayoutDaten.GetNestedControlValueByFieldName("MaxPersons").ToString());
            int MaxAdults = LayoutDaten.GetNestedControlValueByFieldName("MaxAdults") == null ? 0 : int.Parse(LayoutDaten.GetNestedControlValueByFieldName("MaxAdults").ToString());
            DateTime OpenDate = LayoutDaten.GetNestedControlValueByFieldName("OpenDate") == null ? DateTime.Now : DateTime.Parse(LayoutDaten.GetNestedControlValueByFieldName("OpenDate").ToString());
            DateTime CloseDate = LayoutDaten.GetNestedControlValueByFieldName("CloseDate") == null ? DateTime.Now : DateTime.Parse(LayoutDaten.GetNestedControlValueByFieldName("CloseDate").ToString());

            model.OpenDate = OpenDate;
            model.CloseDate = CloseDate;

            controller.UpdateTouristUnit(model);

            BindDaten();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            int MobilehomeSize = LayoutObjektInfo.GetNestedControlValueByFieldName("MobilehomeSize") == null ? 0 : int.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("MobilehomeSize").ToString());
            int DoubleBeds = LayoutObjektInfo.GetNestedControlValueByFieldName("DoubleBeds") == null ? 0 : int.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("DoubleBeds").ToString());
            int SingleBeds = LayoutObjektInfo.GetNestedControlValueByFieldName("SingleBeds") == null ? 0 : int.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("SingleBeds").ToString());
            bool AirConditioning = Boolean.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("AirConditioning").ToString());
            int Bedrooms = LayoutObjektInfo.GetNestedControlValueByFieldName("Bedrooms") == null ? 0 : int.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("Bedrooms").ToString());
            int BunkBeds = LayoutObjektInfo.GetNestedControlValueByFieldName("BunkBeds") == null ? 0 : int.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("BunkBeds").ToString());
            int ExtraBeds = LayoutObjektInfo.GetNestedControlValueByFieldName("ExtraBeds") == null ? 0 : int.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("ExtraBeds").ToString());
            int Bathrooms = LayoutObjektInfo.GetNestedControlValueByFieldName("Bathrooms") == null ? 0 : int.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("Bathrooms").ToString());
            int WC = LayoutObjektInfo.GetNestedControlValueByFieldName("WC") == null ? 0 : int.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("WC").ToString());
            bool Coffeemachine = Boolean.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("Coffeemachine").ToString());
            bool Fridge =Boolean.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("Fridge").ToString());
            bool Childbed =Boolean.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("Childbed").ToString());
            bool DVDPlayer = Boolean.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("DVDPlayer").ToString());
            ASPxComboBox comboboxType = (ASPxComboBox)LayoutObjektInfo.FindNestedControlByFieldName("TerraceType");
            string TerraceType = comboboxType.SelectedItem == null ? string.Empty : comboboxType.SelectedItem.Text;
            int ParcelSize = LayoutObjektInfo.GetNestedControlValueByFieldName("ParcelSize") == null ? 0 : int.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("ParcelSize").ToString());
            bool Sunshade =Boolean.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("Sunshade").ToString());
            bool SolarShower =Boolean.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("SolarShower").ToString());
            int TerraceSize = LayoutObjektInfo.GetNestedControlValueByFieldName("TerraceSize") == null ? 0 : int.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("TerraceSize").ToString());
            bool Sunloungers =Boolean.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("Sunloungers").ToString());
            bool WoodenFurniture =Boolean.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("WoodenFurniture").ToString());
            bool Kettle =Boolean.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("Kettle").ToString());
            bool Towel =Boolean.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("Towel").ToString());
            bool BedWashing =Boolean.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("Parkinglot").ToString());
            bool Parkinglot = Boolean.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("BedWashing").ToString());
            bool FinishCleaning = Boolean.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("FinishCleaning").ToString());
            bool WiFiInternetPriceFree = Boolean.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("WiFiInternetPriceFree").ToString());
            bool WiFiInternet = Boolean.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("WiFiInternet").ToString());
            bool Pool = Boolean.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("Pool").ToString());
            int BeachDistanceFrom = LayoutObjektInfo.GetNestedControlValueByFieldName("BeachDistanceFrom") == null ? 0 : int.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("BeachDistanceFrom").ToString());
            ASPxComboBox comboboxSite = (ASPxComboBox)LayoutObjektInfo.FindNestedControlByFieldName("LocationSite");
            string LocationSite = comboboxSite.SelectedItem == null ? string.Empty : comboboxSite.SelectedItem.Text;
            int BeachDistanceTo = LayoutObjektInfo.GetNestedControlValueByFieldName("BeachDistanceTo") == null ? 0 : int.Parse(LayoutObjektInfo.GetNestedControlValueByFieldName("BeachDistanceTo").ToString());
            ASPxComboBox comboboxSea = (ASPxComboBox)LayoutObjektInfo.FindNestedControlByFieldName("LocationSea");
            string LocationSea = comboboxSea.SelectedItem == null ? string.Empty : comboboxSea.SelectedItem.Text;


            model.MobilehomeSize = MobilehomeSize;
            model.DoubleBeds = DoubleBeds;
            model.SingleBeds = SingleBeds;
            model.AirConditioning = AirConditioning;
            model.Bedrooms = Bedrooms;
            model.BunkBeds = BunkBeds;
            model.ExtraBeds = ExtraBeds;
            model.Bathrooms = Bathrooms;
            model.WC = WC;
            model.Coffeemachine = Coffeemachine;
            model.Fridge = Fridge;
            model.Childbed = Childbed;
            model.DVDPlayer = DVDPlayer;
            model.TerraceType = TerraceType;
            model.ParcelSize = ParcelSize;
            model.Sunshade = Sunshade;
            model.SolarShower = SolarShower;
            model.TerraceSize = TerraceSize;
            model.Sunloungers = Sunloungers;
            model.WoodenFurniture = WoodenFurniture;
            model.Kettle = Kettle;
            model.Towel = Towel;
            model.BedWashing = BedWashing;
            model.Parkinglot = Parkinglot;
            model.FinishCleaning = FinishCleaning;
            model.WiFiInternetPriceFree = WiFiInternetPriceFree;
            model.WiFiInternet = WiFiInternet;
            model.Pool = Pool;
            model.BeachDistanceFrom = BeachDistanceFrom;
            model.LocationSite = LocationSite;
            model.BeachDistanceTo = BeachDistanceTo;
            model.LocationSea = LocationSea;

            model.MaxPersons = int.Parse(txtMaxBelegung.Text);
            model.MaxAdults = int.Parse(txtErwachsene.Text);
            if (comboHaustier.SelectedItem != null)
            {
                model.Pets = int.Parse(comboHaustier.SelectedItem.Value.ToString());
            }

            controller.UpdateTouristUnit(model);

            BindObjektInfo();
        }

        protected void PageUnitControl_ActiveTabChanged(object source, TabControlEventArgs e)
        {

        }


/*
        protected void UploadImageControl_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            try
            {
                string file = e.UploadedFile.FileName;
                string folder = MapPath("~/Content/Images/");
                string path = folder + file;
                e.UploadedFile.SaveAs(path);
                //ImageGallery.SettingsFolder.ImageSourceFolder = folder;


                // ImageGallery.CustomImageProcessing += imageGallery_CustomImageProcessing;
            }
            catch (Exception ec)
            {

            }
        }*/

        //void imageGallery_CustomImageProcessing(object source, DevExpress.Web.ImageGalleryCustomImageProcessingEventArgs e)
        //{
        //    PhotoUtils.DrawWatermarkText(e.Graphics, "ASPxImageGallery", "Arial");
        //}


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            model = controller.GetTouristUnit(id);
            model.ShortDescription = HtmlEditorKurzBeschreibung.Html;
            controller.UpdateTouristUnit(model);
            BindBeschreibungKurz();
        }

        protected void btnSubmita_Click(object sender, EventArgs e)
        {
            model = controller.GetTouristUnit(id);
            model.Description = HtmlEditorPageBeschreibung.Html;
            controller.UpdateTouristUnit(model);
            BindBeschreibung();
        }

        private string GetText()
        {
            string plainText = String.Empty;

            using (MemoryStream mStream = new MemoryStream())
            {
                HtmlEditorKurzBeschreibung.Export(HtmlEditorExportFormat.Txt, mStream);
                plainText = System.Text.Encoding.UTF8.GetString(mStream.ToArray());
            }

            return plainText;
        }

        protected void btnGenerateKurz_Click(object sender, EventArgs e)
        {

        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {

        }

        private void BindObjektInfo()
        {
            model = controller.GetTouristUnit(id);
            if (txtMaxBelegung.Text != null)
            {
                txtMaxBelegung.Text = model.MaxPersons.ToString();
            }
            if (txtErwachsene.Text != null)
            {
                txtErwachsene.Text = model.MaxAdults.ToString();
            }

            comboHaustier.DataSource = DataManager.GetPets();
            comboHaustier.DataBind();
            int index = controller.GetPet(model);
            comboHaustier.SelectedIndex = index;


            var layoutinfo = controller.GetLayoutInfo(model);

            LayoutObjektInfo.DataSource = layoutinfo;
            LayoutObjektInfo.DataBind();

            ASPxComboBox comboboxType = (ASPxComboBox)LayoutObjektInfo.FindNestedControlByFieldName("TerraceType");
            comboboxType.DataSource = DataManager.GetTerraceTypes();
            comboboxType.DataBind();
            index = controller.GetTerraceType(model);
            comboboxTerasseTyp.SelectedIndex = index;

            ASPxComboBox comboboxSea = (ASPxComboBox)LayoutObjektInfo.FindNestedControlByFieldName("LocationSea");
            comboboxSea.DataSource = DataManager.GetDistances();
            comboboxSea.DataBind();
            index = controller.GetSeaLocation(model);
            comboboxSea.SelectedIndex = index;

            ASPxComboBox comboboxSite = (ASPxComboBox)LayoutObjektInfo.FindNestedControlByFieldName("LocationSite");
            comboboxSite.DataSource = DataManager.GetPositions();
            comboboxSite.DataBind();
            index = controller.GetSiteLocation(model);
            comboboxSite.SelectedIndex = index;


        }

        private void BindBeschreibungKurz()
        {
            model = controller.GetTouristUnit(id);
            HtmlEditorKurzBeschreibung.Html = model.ShortDescription;
            lblKurz.Text = GetText().Length.ToString();
        }

        private void BindBeschreibung()
        {
            model = controller.GetTouristUnit(id);
            HtmlEditorPageBeschreibung.Html = model.Description;
           
        }

        private void BindDaten()
        {
            model = controller.GetTouristUnit(id);
            var layoutdaten = controller.GetLayoutDaten(model);
            LayoutDaten.DataSource = layoutdaten;
            LayoutDaten.DataBind();

        }

        protected void btnSetStopBooking_Click(object sender, EventArgs e)
        {
            var selectList = calendarUnit.SelectedDates.ToList();
            model = controller.GetTouristUnit(id);
            var unitstopbooking = GetData(selectList);
            model.UnitStopBooking = unitstopbooking;
            model.LastChange = DateTime.Now;

            controller.UpdateTouristUnit(model);
             
        }

        private List<DateInterval> GetData(List<DateTime> values)
        {
            model = controller.GetTouristUnit(id);
            List<DateInterval> unitstopbooking = model.UnitStopBooking;
            DateTime OpenDate = model.OpenDate.Date;
            DateTime CloseDate = model.CloseDate.Date;
            DateTime FromDate = values[0].Date;
            DateTime ToDate = values[values.Count - 1].Date;
            List<DateTime> alldates = new List<DateTime>();
            List<DateTime> booked = new List<DateTime>();
            List<DateTime> list = new List<DateTime>();
            DateInterval newinterval;

            if(unitstopbooking==null && FromDate>=OpenDate&&ToDate<=CloseDate)
            {
                List<DateInterval> intervals = new List<DateInterval>();
                DateInterval interval= new DateInterval();
                interval.FromDate = FromDate;
                interval.ToDate = ToDate;
                intervals.Add(interval);
                return intervals;
            }

            if (FromDate<OpenDate || ToDate>CloseDate)
            {
                return unitstopbooking;
            }



            booked = GetBooking(unitstopbooking);

            alldates = GetDates(OpenDate, CloseDate);

            List<DateTime> differences = GetDifferences(alldates, booked);

            List<List<DateTime>> lists = GetLists(differences);

            bool isOk = isAvailable(lists, FromDate, ToDate);

            if(isOk)
            {
                newinterval = new DateInterval();
                newinterval.FromDate = FromDate;
                newinterval.ToDate = ToDate;
                unitstopbooking.Add(newinterval);
            }

            return unitstopbooking;
        }

        private List<DateTime> GetBooking(List<DateInterval> listbooking)
        {
            List<DateTime> t = new List<DateTime>();
            foreach (var data in listbooking)
            {
                List<DateTime> Dates = new List<DateTime>();

                Dates = GetDates(data.FromDate, data.ToDate);

                t.AddRange(Dates);
            }

            t = (from a in t
                      orderby a ascending
                      select a).ToList();

            return t;
        }

        private List<DateTime> GetDates(DateTime first,DateTime last)
        {
            List<DateTime> allDates = new List<DateTime>();

            for (DateTime date = first; date <= last; date = date.AddDays(1))
                allDates.Add(date.Date);

            return allDates;
        }

        private List<DateTime> GetDifferences(List<DateTime> alldates,List<DateTime> dates)
        {
            List<DateTime> sublist = new List<DateTime>();

            string c; 

            bool b = false;
            foreach(var item in alldates)
            {
                
                if(dates.Contains(item))
                {
                    sublist.Add(DateTime.MinValue);
                }
                else
                {
                    sublist.Add(item);
                }
              
            }
            return sublist.Distinct().ToList();
              
        }

        private List<List<DateTime>> GetLists(List<DateTime> value)
        {
           
            List<List<DateTime>> main = new List<List<DateTime>>();
            List<DateTime> list = new List<DateTime>();

           // value = value.Distinct().ToList();

            bool b = false;
            bool changed = false;

            foreach (var item in value)
            {
                if (item == DateTime.MinValue)
                {
                    list = new List<DateTime>();
                    main.Add(list);
                }
                list.Add(item);
            }

            return main;
        }

        private bool isAvailable(List<List<DateTime>> listdates,DateTime From,DateTime To)
        {
            bool b = false;

            foreach(var item in listdates)
            {
                b = item.Contains(From) && item.Contains(To);
            }

            return b;
        }

        private DateInterval GetInterval(List<List<DateTime>> listdates, DateTime From, DateTime To)
        {
            bool b = false;
            DateInterval interval = new DateInterval();

            foreach (var item in listdates)
            {
                b = item.Contains(From) && item.Contains(To);
                if(b)
                {
                    interval.FromDate = From;
                    interval.ToDate = To;
                }
            }

            return interval;
        }

        protected void btnResetStopBooking_Click(object sender, EventArgs e)
        {
            model = controller.GetTouristUnit(id);
            List<DateInterval> unitstopbooking = model.UnitStopBooking;
            var sd = Getunitbooking(unitstopbooking);
            unitstopbooking = sd;
            var selectList = calendarUnit.SelectedDates.ToList();
            DateInterval interval = new DateInterval();
            DateTime From = selectList[0].Date;
            DateTime To = selectList[selectList.Count - 1].Date;
            interval.FromDate = From;
            interval.ToDate = To;

            var t = unitstopbooking.Find(m => m.FromDate == interval.FromDate && m.ToDate == interval.ToDate);
            unitstopbooking.Remove(t);
            model.UnitStopBooking = unitstopbooking;
            model.LastChange = DateTime.Now;
            controller.UpdateTouristUnit(model);
            

            int i = 0;
            
            
        }

        private List<DateInterval> Getunitbooking(List<DateInterval> list)
        {
            List<DateInterval> intervals = new List<DateInterval>();

            foreach(var item in list)
            {
                DateInterval data = new DateInterval();
                data.FromDate = item.FromDate.Date;
                data.ToDate = item.ToDate.Date;

                intervals.Add(data);
            }

            return intervals;
        }

        protected void calendarUnit_DayCellPrepared(object sender, CalendarDayCellPreparedEventArgs e)
        {
            //TODO: Predpostavljam da je program spor jer ovdje 300 x  pozivas podatke iz baze podataka
            // jos vece je pitanje zasto pravis update ti nisi nista promjenio u modelu (???)
            //model.UnitStopBooking = null;
            //if (!firstload)
            //{
            //    model = controller.GetTouristUnit(id);
            //    controller.UpdateTouristUnit(model);
            //}
            DateTime OpenDate = model.OpenDate;
            DateTime CloseDate = model.CloseDate;
            List<DateInterval> unitstopbooking = model.UnitStopBooking;

            if (unitstopbooking != null)
            {
                if (e.Date < OpenDate || e.Date > CloseDate)
                    e.Cell.BackColor = System.Drawing.Color.Gray;
                else if (unitstopbooking.Find(m => m.FromDate <= e.Date && m.ToDate >= e.Date) != null)
                    e.Cell.BackColor = System.Drawing.Color.Red;
            }
        }

        protected void UnitFileManager_FileUploading(object source, FileManagerFileUploadEventArgs e)
        {
            if (folder != null)
            {
                string version= System.Environment.Version.ToString();
                string file = e.FileName;
                string fullpath = folder + "\\" + file;
                FileStream fs = new FileStream(fullpath, FileMode.CreateNew, FileAccess.ReadWrite);
                e.InputStream.CopyTo(fs);
                fs.Close(); //close the new file created by the FileStream
                e.Cancel = true; //cancelling the upload, prevents duplicate uploads
                e.ErrorText = "Success"; //shown when the upload is cancelled
                UnitFileManager.Settings.RootFolder = folder;
            }
        }

        protected void UnitFileManager_FilesUploaded(object source, FileManagerFilesUploadedEventArgs e)
        {

            //UnitFileManager.Settings.InitialFolder = folder;
            string file = e.Files[0].FullName;
            
        }

        protected void UnitFileManager_CustomCallback(object sender, CallbackEventArgsBase e)
        {

        }

        protected void UnitFileManager_Init(object sender, EventArgs e)
        {
        
            //UnitFileManager.Settings.RootFolder = folder;
            int i = 0;
        }

        private string CreateFolder(string site,string unit)
        {
            string basefolder = MapPath("~/Content/Images/");
            string sitefolder = basefolder + "Site_" + site + "\\";
            if(!Directory.Exists(sitefolder))
            {
                Directory.CreateDirectory(sitefolder);
            }
            string folder = sitefolder + "Unit_" + unit ;
            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            return folder;
        }

        protected void UnitFileManager_Load(object sender, EventArgs e)
        {
            UnitFileManager.Settings.RootFolder = folder;
        }

        protected void GridUnitOfferView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            UnitOfferViewModel modeloffer = new UnitOfferViewModel();


            modeloffer.IsAutoStopBooking = (bool)e.NewValues["IsAutoStopBooking"];
            modeloffer.OfferCode = e.NewValues["OfferCode"].ToString() ?? string.Empty;
            modeloffer.SiteCode = model.SiteCode;
            modeloffer.OfferCount = e.NewValues["OfferCount"] == null ? 0 : (int)e.NewValues["OfferCount"];
            modeloffer.OfferDescription = e.NewValues["OfferDescription"].ToString() ?? string.Empty;
            // model.OfferDescriptionTranslate = (Dictionary<string,string>) e.NewValues["OfferDescriptionTranslate"];
            modeloffer.OfferTitel = e.NewValues["OfferTitel"].ToString() ?? string.Empty;
            // model.OfferTitelTranslate = (Dictionary<string, string>)e.NewValues["OfferTitelTranslate"];
            modeloffer.ProviderNotice = e.NewValues["ProviderNotice"].ToString() ?? string.Empty;
            modeloffer.TourOperatorCode = e.NewValues["TourOperatorCode"].ToString() ?? string.Empty;
            modeloffer.UnitCode = model.UnitCode;


            if (modeloffer.UnitCode != null)
            {
                modeloffer.SiteCode = offercontroller.GetSiteCode(modeloffer.UnitCode);
            }


            bool contains = offercontroller.ContainsOfferCode(modeloffer.OfferCode);

            if (!contains)
            {
                offercontroller.AddUnitOffer(modeloffer);
            }
            e.Cancel = true;
            GridUnitOfferView.CancelEdit();

            BindDataOffer();
        }

        protected void GridUnitOfferView_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var listSaP = (List<UnitOfferViewModel>)GridUnitOfferView.DataSource;
            UnitOfferViewModel modeloffer = listSaP.Find(m => m.id == e.Keys[0].ToString());
            modeloffer.IsAutoStopBooking = (bool)e.NewValues["IsAutoStopBooking"];
            modeloffer.OfferCode = e.NewValues["OfferCode"].ToString() ?? string.Empty;
            modeloffer.SiteCode = model.SiteCode;
            modeloffer.OfferCount = e.NewValues["OfferCount"] == null ? 0 : (int)e.NewValues["OfferCount"];
            modeloffer.OfferDescription = e.NewValues["OfferDescription"].ToString() ?? string.Empty;
            // model.OfferDescriptionTranslate = (Dictionary<string,string>) e.NewValues["OfferDescriptionTranslate"];
            modeloffer.OfferTitel = e.NewValues["OfferTitel"].ToString() ?? string.Empty;
            // model.OfferTitelTranslate = (Dictionary<string, string>)e.NewValues["OfferTitelTranslate"];
            modeloffer.ProviderNotice = e.NewValues["ProviderNotice"].ToString() ?? string.Empty;
            modeloffer.TourOperatorCode = e.NewValues["TourOperatorCode"].ToString() ?? string.Empty;
            modeloffer.UnitCode = model.UnitCode;

            if (modeloffer.UnitCode != null)
            {
                modeloffer.SiteCode = offercontroller.GetSiteCode(modeloffer.UnitCode);
            }

            //bool contains = controller.ContainsOfferCode(model.OfferCode);

            //if (!contains)
            //{
            offercontroller.UpdateUnitOffer(modeloffer);
            //}
            e.Cancel = true;
            GridUnitOfferView.CancelEdit();

            BindDataOffer();
        }

        protected void GridUnitOfferView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string id =e.Keys[0].ToString();

            offercontroller.DeleteUnitOffer(id);
            e.Cancel = true;
            GridUnitOfferView.CancelEdit();

            BindDataOffer();
        }

        private void BindDataOffer()
        {
            GridUnitOfferView.DataSource = offercontroller.GetUnitOfferByCode(sitecode, unitcode);
            GridUnitOfferView.DataBind();
        }

        protected void GridUnitOfferView_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "ButtonPriceList")
            {
                ASPxGridView grid = sender as ASPxGridView;
                int index = e.VisibleIndex;
                string offercode = grid.GetRowValues(index, "OfferCode").ToString();
                string sitecode = grid.GetRowValues(index, "SiteCode").ToString();
                string unitcode = grid.GetRowValues(index, "UnitCode").ToString();
                string tourOperatorCode = grid.GetRowValues(index, "TourOperatorCode").ToString();
                

                ASPxWebControl.RedirectOnCallback(VirtualPathUtility.ToAbsolute("~/AspxArea/PriceList/Forms/RetailPriceForm.aspx?sc=" + sitecode + "&oc=" + offercode + "&uc=" + unitcode + "&to=" + tourOperatorCode));
            }
        }

        protected void GridUnitOfferView_DataBinding(object sender, EventArgs e)
        {
            GridUnitOfferView.ForceDataRowType(typeof(UnitOfferViewModel));
        }

        protected void GridUnitOfferView_Init(object sender, EventArgs e)
        {
            GridUnitOfferView.Columns["id"].Visible = false;
            GridUnitOfferView.Columns["OfferCount"].Visible = false;
            GridUnitOfferView.Columns["ProviderNotice"].Visible = false;
            GridUnitOfferView.Columns["TourOperatorCode"].Visible = false;
            GridUnitOfferView.Columns["OfferDescription"].Visible = false;
        }

        protected void GridUnitOfferView_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (GridUnitOfferView.IsNewRowEditing)
                GridUnitOfferView.DoRowValidation();
        }

        protected void GridUnitOfferView_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

            GridValidation.ValidateInt("OfferCount", sender, e);
            GridValidation.ValidateLength("OfferCode",3, sender, e);
            // GridValidation.ValidateFixedLength("SiteCode", sender, e);
            GridValidation.ValidateLength("OfferDescription",2, sender, e);
            GridValidation.ValidateLength("OfferTitel",2, sender, e);
            GridValidation.ValidateLength("ProviderNotice",2, sender, e);
            GridValidation.ValidateLength("TourOperatorCode",2, sender, e);
            //GridValidation.ValidateLength("UnitCode",3, sender, e);

        }

        protected void GridUnitOfferView_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
           
        }


        protected void btnOK_Click(object sender,EventArgs e)
        {

        }

        private void Data()
        {

        }

        protected void btnCopy_Click(object sender, EventArgs e)
        {

        }
    }
}