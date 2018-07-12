using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using V50_IDOMBackOffice.AspxArea.MasterData.Models;
using V50_IDOMBackOffice.AspxArea.MasterData.Controllers;
using IdomOffice.Interface.BackOffice.MasterData;
using V50_IDOMBackOffice.AspxArea.Helper;
using DevExpress.Web;

namespace V50_IDOMBackOffice.AspxArea.MasterData.Forms
{
    public partial class TouristUnitView : System.Web.UI.Page
    {

        TouristUnitController controller = new TouristUnitController();
        protected void Page_Load(object sender, EventArgs e)
        {
          
                Bind();
            
        }

        protected void GridTouristUnitView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            //TODO: Zasto ovdje pravis model i punis sa podacima kada kada ti je potreban samo id ????


            string id = e.Keys[0].ToString();
        

            controller.DeleteTouristUnit(id);
            e.Cancel = true;
            GridTouristUnitView.CancelEdit();

            Bind();
        }

        protected void GridTouristUnitView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            TouristUnitViewModel model = new TouristUnitViewModel();

            model.Bathrooms = e.NewValues["Bathrooms"] == null ? 0 : (int)e.NewValues["Bathrooms"];
            model.Bedroom = e.NewValues["Bedroom"]==null? 0:(int)e.NewValues["Bedroom"];
            model.SiteCode = e.NewValues["SiteCode"].ToString()?? string.Empty;
            //model.SiteName = e.NewValues["SiteName"].ToString()?? string.Empty;
            //model.Beds = e.NewValues["Beds"] == null ? 0 : (int)e.NewValues["Beds"];
            //model.ImageGalleryPath = e.NewValues["ImageGalleryPath"].ToString()?? string.Empty;
           // model.ImageThumbnailsPath = e.NewValues["ImageThumbnailsPath"].ToString()?? string.Empty;
            model.CloseDate = e.NewValues["CloseDate"] == null ? DateTime.Now : (DateTime)e.NewValues["CloseDate"];
            //model.CountryName = e.NewValues["CountryName"].ToString()?? string.Empty;
            model.MaxAdults = e.NewValues["MaxAdults"] == null ? 0 : (int)e.NewValues["MaxAdults"];
            model.MaxPersons = e.NewValues["MaxPersons"] == null ? 0 : (int)e.NewValues["MaxPersons"];
            model.Description = e.NewValues["Description"] == null ? string.Empty : e.NewValues["Description"].ToString();
            model.MobilhomeArea = e.NewValues["MobilhomeArea"] == null ? 0 : (int)e.NewValues["MobilhomeArea"];
            model.OpenDate = e.NewValues["OpenDate"] == null ? DateTime.Now : (DateTime)e.NewValues["OpenDate"];
            //model.PlaceName = e.NewValues["PlaceName"].ToString()?? string.Empty;
            //model.PurchasePriceListId = e.NewValues["PurchasePriceListId"].ToString()?? string.Empty;
            //model.RegionName = e.NewValues["RegionName"].ToString()?? string.Empty;
            model.TerraceArea = e.NewValues["TerraceArea"] == null ? 0 : (int)e.NewValues["TerraceArea"];
            model.TourOperatorCode = e.NewValues["TourOperatorCode"].ToString()?? string.Empty;
            model.TravelServiceProvider = e.NewValues["TravelServiceProvider"].ToString()?? string.Empty;
            model.UnitCode = e.NewValues["UnitCode"].ToString()?? string.Empty;
            //model.UnitOfferInfoList = (List<UnitOfferInfo>)e.NewValues["SiteName"];
            model.UnitTitel = e.NewValues["UnitTitel"].ToString()?? string.Empty;

            bool contains = controller.ContainsUnitCode(model.UnitCode);


            TouristUnitViewModel touristunit = new TouristUnitViewModel();

            if (model.SiteCode!=null)
            { //TODO: Ove podatke ne treba ovdje puniti nego u Repositoriju
              // prebaciti model u Repository i dodati property koje fale
              //Ili pozvati jednu funkciju koja vraca jedan objekt sa svim GEO informacijama
                touristunit = controller.GetTouristUnit(model);

            }

            if (!contains)
            {
                controller.AddTouristUnit(touristunit);
            }
            e.Cancel = true;
            GridTouristUnitView.CancelEdit();

            Bind();
        }

        protected void GridTouristUnitView_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

            var listSaP = (List<TouristUnitViewModel>)GridTouristUnitView.DataSource;
            TouristUnitViewModel model = listSaP.Find(m => m.id == e.Keys[0].ToString());
            model.Bathrooms = e.NewValues["Bathrooms"] == null ? 0 : (int)e.NewValues["Bathrooms"];
            model.Bedroom = e.NewValues["Bedroom"] == null ? 0 : (int)e.NewValues["Bedroom"];
          //  model.SiteCode = e.NewValues["SiteCode"].ToString() ?? string.Empty;
            //model.SiteName = e.NewValues["SiteName"].ToString() ?? string.Empty;
            //model.Beds = e.NewValues["Beds"] == null ? 0 : (int)e.NewValues["Beds"];
            //model.ImageGalleryPath = e.NewValues["ImageGalleryPath"].ToString() ?? string.Empty;
            //model.ImageThumbnailsPath = e.NewValues["ImageThumbnailsPath"].ToString() ?? string.Empty;
            model.CloseDate = e.NewValues["CloseDate"] == null ? DateTime.Now : (DateTime)e.NewValues["CloseDate"];
            //model.CountryName = e.NewValues["CountryName"].ToString() ?? string.Empty;
            model.MaxAdults = e.NewValues["MaxAdults"] == null ? 0 : (int)e.NewValues["MaxAdults"];
            model.Description = e.NewValues["Description"] == null ? string.Empty : e.NewValues["Description"].ToString();
            model.MaxPersons = e.NewValues["MaxPersons"] == null ? 0 : (int)e.NewValues["MaxPersons"];
            model.MobilhomeArea = e.NewValues["MobilhomeArea"] == null ? 0 : (int)e.NewValues["MobilhomeArea"];
            model.OpenDate = e.NewValues["OpenDate"] == null ? DateTime.Now : (DateTime)e.NewValues["OpenDate"];
            //model.PlaceName = e.NewValues["PlaceName"].ToString() ?? string.Empty;

            
            //model.RegionName = e.NewValues["RegionName"].ToString() ?? string.Empty;
            model.TerraceArea = e.NewValues["TerraceArea"] == null ? 0 : (int)e.NewValues["TerraceArea"];
            model.TourOperatorCode = e.NewValues["TourOperatorCode"].ToString() ?? string.Empty;
            model.TravelServiceProvider = (string) e.NewValues["TravelServiceProvider"] ?? string.Empty;
            model.UnitCode = e.NewValues["UnitCode"].ToString() ?? string.Empty;
            //model.UnitOfferInfoList = (List<UnitOfferInfo>)e.NewValues["SiteName"];
            model.UnitTitel = e.NewValues["UnitTitel"].ToString() ?? string.Empty;

            TouristUnitViewModel touristunit = new TouristUnitViewModel();

            if (model.SiteCode != null)
            {
                //TODO: Ove podatke ne treba ovdje puniti nego u Repositoriju
                // prebaciti model u Repository i dodati property koje fale
                //Ili pozvati jednu funkciju koja vraca jedan objekt sa svim GEO informacijama
                touristunit = controller.GetTouristUnit(model);
            }
            
            //bool contains = controller.ContainsUnitCode(model.UnitCode);

            //if (!contains)
            //{
                controller.UpdateTouristUnit(touristunit);
            //}
             
            e.Cancel = true;
            GridTouristUnitView.CancelEdit();

            Bind();
        }

        private void Bind()
        {
            GridTouristUnitView.DataSource = controller.Init();
            GridTouristUnitView.DataBind();
        }

        protected void GridTouristUnitView_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            int index = e.VisibleIndex;

            if (e.ButtonID== "ButtonPriceList")
            {
                string unitcode = grid.GetRowValues(index, "UnitCode").ToString();
                string sitecode = grid.GetRowValues(index, "SiteCode").ToString();

          //      Response.Redirect("~/AspxArea/PriceList/Forms/PurchasePriceForm.aspx?sc=" + sitecode + "&oc=" + unitcode);
                ASPxWebControl.RedirectOnCallback(VirtualPathUtility.ToAbsolute("~/AspxArea/PriceList/Forms/PurchasePriceForm.aspx?sc=" + sitecode + "&uc=" + unitcode));
            }
            else if(e.ButtonID=="ButtonUnit")
            {
                string unitcode = grid.GetRowValues(index, "UnitCode").ToString();
                string sitecode = grid.GetRowValues(index, "SiteCode").ToString();
                string tourOperatorCode = grid.GetRowValues(index, "TourOperatorCode").ToString();
                string id = grid.GetRowValues(index, "id").ToString();
                
                ASPxWebControl.RedirectOnCallback(VirtualPathUtility.ToAbsolute("~/AspxArea/MasterData/Forms/UnitForm.aspx?id="+ id+"&sc=" + sitecode + "&uc=" + unitcode + "&to=" + tourOperatorCode + "&plt=" + "1"));

              
            }
        }

        protected void GridTouristUnitView_DataBinding(object sender, EventArgs e)
        {
            GridTouristUnitView.ForceDataRowType(typeof(TouristUnitViewModel));
        }

        protected void GridTouristUnitView_Init(object sender, EventArgs e)
        {
            GridTouristUnitView.Columns["id"].Visible = false;
            GridTouristUnitView.Columns["ImageGalleryPath"].Visible = false;
            GridTouristUnitView.Columns["ImageThumbnailsPath"].Visible = false;
            GridTouristUnitView.Columns["Bathrooms"].Visible = false;
            GridTouristUnitView.Columns["Bedroom"].Visible = false;
          //  GridTouristUnitView.Columns["Beds"].Visible = false;
            GridTouristUnitView.Columns["TerraceArea"].Visible = false;
            GridTouristUnitView.Columns["PurchasePriceListId"].Visible = false;
            GridTouristUnitView.Columns["TourOperatorCode"].Visible = false;
            GridTouristUnitView.Columns["TravelServiceProvider"].Visible = false;
            GridTouristUnitView.Columns["Description"].Visible = false;
            GridTouristUnitView.Columns["MobilhomeArea"].Visible = false;
            GridTouristUnitView.Columns["MaxPersons"].Visible = false;
            GridTouristUnitView.Columns["MaxAdults"].Visible = false;

            
        }

        protected void GridTouristUnitView_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (GridTouristUnitView.IsNewRowEditing)
                GridTouristUnitView.DoRowValidation();
        }

        protected void GridTouristUnitView_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            //GridValidation.ValidateInt("Bedroom", sender, e);
            //GridValidation.ValidateInt("MaxAdults", sender, e);
            //GridValidation.ValidateInt("MaxPersons", sender, e);
            //GridValidation.ValidateInt("MobilhomeArea", sender, e);
            //GridValidation.ValidateInt("TerraceArea", sender, e);
            ////GridValidation.ValidateLength("Bathrooms", sender, e);
            //GridValidation.ValidateFixedLength("SiteCode", sender, e);
            //GridValidation.ValidateLength("SiteName", sender, e);
            ////GridValidation.ValidateLength("Beds", sender, e);
            //GridValidation.ValidateLength("ImageGalleryPath", sender, e);
            //GridValidation.ValidateLength("ImageThumbnailsPath", sender, e);
            //GridValidation.ValidateLength("PlaceName", sender, e);
            //GridValidation.ValidateLength("PurchasePriceListId", sender, e);
            //GridValidation.ValidateLength("RegionName", sender, e);
            //GridValidation.ValidateLength("TourOperatorCode", sender, e);
            //GridValidation.ValidateLength("TravelServiceProvider", sender, e);
            //GridValidation.ValidateFixedLength("UnitCode", sender, e);
            //GridValidation.ValidateLength("UnitTitel", sender, e);
        }

        protected void GridTouristUnitView_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "SiteCode")
            {
                ASPxComboBox combo = (ASPxComboBox)e.Editor;
                combo.DataSource = controller.GetSiteCodes();
                combo.DataBind();
                // Combo SiteCode nije moguce mjenjati u edit modu ( mjenjanje je moguce samo kod kreiranja novog recorda)
                combo.Enabled = e.Column.Grid.IsNewRowEditing;
            }

            if(!e.Column.Grid.IsNewRowEditing)
            {
                //Kod editiranja UnitCode nije moguce mjenjati i zato je ReadOnli
                if (e.Column.FieldName == "UnitCode")
                    e.Editor.ReadOnly = true;

                
            }

            
        }
    }
}