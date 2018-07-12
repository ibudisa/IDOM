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
    public partial class RegionView : System.Web.UI.Page
    {
        RegionViewController controller = new RegionViewController();
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        

        private void Bind()
        {
            GridRegionView.DataSource = controller.Init();
            GridRegionView.DataBind();
        }

        protected void GridRegionView_RowDeleting1(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string id = e.Keys[0].ToString();
 
            controller.DeleteRegion(id);

            e.Cancel = true;
            GridRegionView.CancelEdit();

            Bind();
        }

        protected void GridRegionView_RowInserting1(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            RegionViewModel model = new RegionViewModel();
            model.RegionId = e.NewValues["RegionId"] == null ? 0 : (int)e.NewValues["RegionId"];
            model.RegionName = e.NewValues["RegionName"].ToString();
            model.CountryId = e.NewValues["CountryId"] == null ? 0 : (int)e.NewValues["CountryId"];
            model.ImageGalleryPath = (e.NewValues["ImageGalleryPath"] == null) ? string.Empty : e.NewValues["ImageGalleryPath"].ToString();
            model.ImageThumbnailsPath = (e.NewValues["ImageThumbnailsPath"] == null) ? string.Empty : e.NewValues["ImageThumbnailsPath"].ToString();

            controller.AddRegion(model);

            e.Cancel = true;
            GridRegionView.CancelEdit();

            Bind();
        }

        protected void GridRegionView_RowUpdating1(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var listSaP = (List<RegionViewModel>)GridRegionView.DataSource;
            RegionViewModel model = listSaP.Find(m => m.Id == e.Keys[0].ToString());
            model.RegionId = e.NewValues["RegionId"] == null ? 0 : (int)e.NewValues["RegionId"];
            model.RegionName = e.NewValues["RegionName"].ToString();
            model.CountryId = e.NewValues["CountryId"] == null ? 0 : (int)e.NewValues["CountryId"];
            model.ImageGalleryPath = (e.NewValues["ImageGalleryPath"] == null) ? string.Empty : e.NewValues["ImageGalleryPath"].ToString();
            model.ImageThumbnailsPath = (e.NewValues["ImageThumbnailsPath"] == null) ? string.Empty : e.NewValues["ImageThumbnailsPath"].ToString();


            controller.UpdateRegion(model);

            e.Cancel = true;
            GridRegionView.CancelEdit();

            Bind();
        }

        protected void GridRegionView_DataBinding(object sender, EventArgs e)
        {
            GridRegionView.ForceDataRowType(typeof(RegionViewModel));

        }

        protected void GridRegionView_Init(object sender, EventArgs e)
        {
            GridRegionView.Columns["Id"].Visible = false;
            GridRegionView.Columns["ImageGalleryPath"].Visible = false;
            GridRegionView.Columns["ImageThumbnailsPath"].Visible = false;
        }

        protected void GridRegionView_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (GridRegionView.IsNewRowEditing)
                GridRegionView.DoRowValidation();
        }

        protected void GridRegionView_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

            GridValidation.ValidateInt("CountryId", sender, e);
            GridValidation.ValidateInt("RegionId", sender, e);
            GridValidation.ValidateLength("RegionName",2, sender, e);
            GridValidation.ValidateLength("ImageThumbnailsPath",2, sender, e);
            GridValidation.ValidateLength("ImageGalleryPath",2, sender, e);


        }

        protected void GridRegionView_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "CountryId")
            {
                ASPxComboBox combo = (ASPxComboBox)e.Editor;
                combo.DataSource = controller.GetCountryIds();
                combo.DataBind();
            }
        }
    }
}