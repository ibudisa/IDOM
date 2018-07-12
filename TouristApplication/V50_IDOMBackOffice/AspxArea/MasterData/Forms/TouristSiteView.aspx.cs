using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using V50_IDOMBackOffice.AspxArea.MasterData.Models;
using V50_IDOMBackOffice.AspxArea.MasterData.Controllers;
using V50_IDOMBackOffice.AspxArea.Helper;
using DevExpress.Web;

namespace V50_IDOMBackOffice.AspxArea.MasterData.Forms
{
    public partial class TouristSiteView : System.Web.UI.Page
    {
        TouristSiteController controller = new TouristSiteController();

        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        protected void GridTouristSiteView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            TouristSiteViewModel model = new TouristSiteViewModel();
            model.CountryId = e.NewValues["CountryId"]==null? 0:(int)e.NewValues["CountryId"];
            model.Description = e.NewValues["Description"].ToString()?? string.Empty;
            model.PlaceId = e.NewValues["PlaceId"] == null ? 0 : (int)e.NewValues["PlaceId"]; 
            model.RegionId = e.NewValues["RegionId"] == null ? 0 : (int)e.NewValues["RegionId"];
            model.SiteCode = e.NewValues["SiteCode"].ToString()??string.Empty;
            model.SiteName = e.NewValues["SiteName"].ToString()??string.Empty;
            model.Stars = e.NewValues["Stars"] == null ? 0 : (int)e.NewValues["Stars"];
            //model.ImageGalleryPath = e.NewValues["ImageGalleryPath"].ToString()?? string.Empty;
            //model.ImageThumbnailsPath = e.NewValues["ImageThumbnailsPath"].ToString()?? string.Empty;

            controller.AddTouristSite(model);
            e.Cancel = true;
            GridTouristSiteView.CancelEdit();

            Bind();

        }

        protected void GridTouristSiteView_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var listSaP = (List<TouristSiteViewModel>)GridTouristSiteView.DataSource;
            TouristSiteViewModel model = listSaP.Find(m => m.id == e.Keys[0].ToString());
            model.CountryId = e.NewValues["CountryId"] == null ? 0 : (int)e.NewValues["CountryId"];
            model.Description = e.NewValues["Description"].ToString()?? string.Empty;
            model.PlaceId = e.NewValues["PlaceId"] == null ? 0 : (int)e.NewValues["PlaceId"];
            model.RegionId = e.NewValues["RegionId"] == null ? 0 : (int)e.NewValues["RegionId"];
            model.SiteCode = e.NewValues["SiteCode"].ToString() ?? string.Empty;
            model.SiteName = e.NewValues["SiteName"].ToString() ?? string.Empty;
            model.Stars = e.NewValues["Stars"] == null ? 0 : (int)e.NewValues["Stars"];
            //model.ImageGalleryPath = e.NewValues["ImageGalleryPath"].ToString() ?? string.Empty;
            //model.ImageThumbnailsPath = e.NewValues["ImageThumbnailsPath"].ToString() ?? string.Empty;

            controller.UpdateTouristSite(model);
            e.Cancel = true;
            GridTouristSiteView.CancelEdit();

            Bind();
        }

        protected void GridTouristSiteView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string id = e.Keys[0].ToString();
           
            controller.DeleteTouristSite(id);
            e.Cancel = true;
            GridTouristSiteView.CancelEdit();

            Bind();
        }

        private void Bind()
        {
            GridTouristSiteView.DataSource = controller.Init();
            GridTouristSiteView.DataBind();
        }

        protected void GridTouristSiteView_DataBinding(object sender, EventArgs e)
        {
            GridTouristSiteView.ForceDataRowType(typeof(TouristSiteViewModel));
        }

        protected void GridTouristSiteView_Init(object sender, EventArgs e)
        {
            GridTouristSiteView.Columns["id"].Visible = false;
            GridTouristSiteView.Columns["ImageGalleryPath"].Visible = false;
            GridTouristSiteView.Columns["ImageThumbnailsPath"].Visible = false;
        }

        protected void GridTouristSiteView_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (GridTouristSiteView.IsNewRowEditing)
                GridTouristSiteView.DoRowValidation();
        }

        protected void GridTouristSiteView_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

            GridValidation.ValidateInt("CountryId", sender, e);
            GridValidation.ValidateInt("RegionId", sender, e);
            GridValidation.ValidateInt("Stars", sender, e);
            GridValidation.ValidateLength("Description",2, sender, e);
            GridValidation.ValidateLength("SiteCode",6, sender, e);
            //GridValidation.ValidateLength("SiteName",2, sender, e);
            //GridValidation.ValidateLength("ImageThumbnailsPath",2, sender, e);
            //GridValidation.ValidateLength("ImageGalleryPath",2, sender, e);

           
        }

        protected void GridTouristSiteView_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            int index = e.VisibleIndex;

            if (e.ButtonID == "SiteGallery")
            {
               
                string sitecode = grid.GetRowValues(index, "SiteCode").ToString();
             
                ASPxWebControl.RedirectOnCallback(VirtualPathUtility.ToAbsolute("~/AspxArea/MasterData/Forms/SiteGalleryView.aspx?sc=" + sitecode ));
            }
        }

        protected void GridTouristSiteView_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "RegionId")
            {
                ASPxComboBox combo = (ASPxComboBox)e.Editor;
                combo.DataSource = controller.GetRegionIds();
                combo.DataBind();
            }
            else if(e.Column.FieldName=="CountryId")
            {
                ASPxComboBox combo = (ASPxComboBox)e.Editor;
                combo.DataSource = controller.GetCountryIds();
                combo.DataBind();
            }
            else if(e.Column.FieldName=="PlaceId")
            {
                ASPxComboBox combo = (ASPxComboBox)e.Editor;
                combo.DataSource = controller.GetPlaceIds();
                combo.DataBind();
            }
        }
    }
}