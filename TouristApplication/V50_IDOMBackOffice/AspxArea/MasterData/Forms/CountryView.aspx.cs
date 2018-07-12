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
    public partial class CountryView : System.Web.UI.Page
    {
        CountryViewController controller = new CountryViewController();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        private void Bind()
        {
            GridCountryView.DataSource = controller.Init();
            GridCountryView.DataBind();
        }

        protected void GridCountryView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            CountryViewModel model = new CountryViewModel();
            model.CountryId = e.NewValues["CountryId"] == null ? 0 : (int)e.NewValues["CountryId"];
            model.CountryName = e.NewValues["CountryName"].ToString() ?? string.Empty;
            model.ImageGalleryPath = e.NewValues["ImageGalleryPath"].ToString()?? string.Empty;
            model.ImageThumbnailsPath = e.NewValues["ImageThumbnailsPath"].ToString()?? string.Empty;
            
            controller.AddCountry(model);

            e.Cancel = true;
            GridCountryView.CancelEdit();

            Bind();
        }

        protected void GridCountryView_Init(object sender, EventArgs e)
        {
            GridCountryView.Columns["ImageGalleryPath"].Visible = false;
            GridCountryView.Columns["ImageThumbnailsPath"].Visible = false;
        }

        protected void GridCountryView_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

            //   CountryViewModel model = new CountryViewModel();

            var listSaP = (List<CountryViewModel>)GridCountryView.DataSource;
            CountryViewModel model = listSaP.Find(m => m.Id == e.Keys[0].ToString());
           
            model.CountryId = e.NewValues["CountryId"]==null? 0: (int)e.NewValues["CountryId"];
            model.CountryName = e.NewValues["CountryName"].ToString() ?? string.Empty;
            model.ImageGalleryPath = (string) e.NewValues["ImageGalleryPath"]  ?? string.Empty;
            model.ImageThumbnailsPath = (string) e.NewValues["ImageThumbnailsPath"] ?? string.Empty;
           
            controller.UpdateCountry(model);

            e.Cancel = true;
            GridCountryView.CancelEdit();

            Bind();
        }

        protected void GridCountryView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string id = e.Keys[0].ToString();
           
            controller.DeleteCountry(id);

            e.Cancel = true;
            GridCountryView.CancelEdit();

            Bind();
        }

        protected void GridCountryView_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {
            var data = (List<CountryViewModel>)GridCountryView.DataSource;
            int i = 0;
        }

        protected void GridCountryView_DataBinding(object sender, EventArgs e)
        {
            // Definirati typ objekta sa kojim grid radi
            GridCountryView.ForceDataRowType(typeof(CountryViewModel));
        }

        protected void GridCountryView_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (GridCountryView.IsNewRowEditing)
                GridCountryView.DoRowValidation();
        }

        protected void GridCountryView_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {

            GridValidation.ValidateInt("CountryId", sender, e);
            GridValidation.ValidateLength("CountryName",2, sender, e);
            GridValidation.ValidateLength("ImageThumbnailsPath",2, sender, e);
            GridValidation.ValidateLength("ImageGalleryPath",2, sender, e);

           
        }

      
    }
}