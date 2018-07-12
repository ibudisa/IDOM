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
    public partial class PlaceView : System.Web.UI.Page
    {
        PlaceViewController controller = new PlaceViewController();

        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        private void Bind()
        {
            GridPlaceView.DataSource = controller.Init();
            GridPlaceView.DataBind();
        }

        protected void GridPlaceView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            PlaceViewModel model = new PlaceViewModel();

            model.PlaceId = e.NewValues["PlaceId"]==null? 0:(int)e.NewValues["PlaceId"];
            model.RegionId = e.NewValues["RegionId"] == null ? 0 : (int)e.NewValues["RegionId"];
            model.PlaceName = e.NewValues["PlaceName"].ToString()?? string.Empty;
            model.ImageGalleryPath = e.NewValues["ImageGalleryPath"].ToString()?? string.Empty;
            model.ImageThumbnailsPath = e.NewValues["ImageThumbnailsPath"].ToString()?? string.Empty;

            controller.AddPlace(model);

            e.Cancel = true;
            GridPlaceView.CancelEdit();

            Bind();
        }

        protected void GridPlaceView_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var listSaP = (List<PlaceViewModel>)GridPlaceView.DataSource;
            PlaceViewModel model = listSaP.Find(m => m.Id == e.Keys[0].ToString());
            model.PlaceId = e.NewValues["PlaceId"] == null ? 0 : (int)e.NewValues["PlaceId"];
            model.RegionId = e.NewValues["RegionId"] == null ? 0 : (int)e.NewValues["RegionId"];
            model.PlaceName = e.NewValues["PlaceName"].ToString() ?? string.Empty;
            model.ImageGalleryPath = e.NewValues["ImageGalleryPath"].ToString() ?? string.Empty;
            model.ImageThumbnailsPath = e.NewValues["ImageThumbnailsPath"].ToString() ?? string.Empty;

            controller.UpdatePlace(model);

            e.Cancel = true;
            GridPlaceView.CancelEdit();

            Bind();
        }

        protected void GridPlaceView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string id = e.Keys[0].ToString();
           
            controller.DeletePlace(id);

            e.Cancel = true;
            GridPlaceView.CancelEdit();

            Bind();
        }

        protected void GridPlaceView_DataBinding(object sender, EventArgs e)
        {
            GridPlaceView.ForceDataRowType(typeof(PlaceViewModel));
        }

        protected void GridPlaceView_Init(object sender, EventArgs e)
        {
            GridPlaceView.Columns["Id"].Visible = false;
            GridPlaceView.Columns["ImageGalleryPath"].Visible = false;
            GridPlaceView.Columns["ImageThumbnailsPath"].Visible = false;
        }

        protected void GridPlaceView_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (GridPlaceView.IsNewRowEditing)
                GridPlaceView.DoRowValidation();
        }

        protected void GridPlaceView_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

            GridValidation.ValidateInt("PlaceId", sender, e);
            GridValidation.ValidateInt("RegionId", sender, e);
            GridValidation.ValidateLength("PlaceName",2, sender, e);
            GridValidation.ValidateLength("ImageThumbnailsPath",2, sender, e);
            GridValidation.ValidateLength("ImageGalleryPath",2, sender, e);

        }

        protected void GridPlaceView_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "RegionId")
            {
                ASPxComboBox combo = (ASPxComboBox)e.Editor;
                combo.DataSource = controller.GetRegionIds();
                combo.DataBind();
            }
        }
    }
}