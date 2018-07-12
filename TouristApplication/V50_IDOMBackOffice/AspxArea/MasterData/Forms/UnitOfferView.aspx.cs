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
    public partial class UnitOfferView : System.Web.UI.Page
    {
        UnitOfferController controller = new UnitOfferController();

        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        protected void GridUnitOfferView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            UnitOfferViewModel model = new UnitOfferViewModel();
           

            model.IsAutoStopBooking = (bool)e.NewValues["IsAutoStopBooking"];
            model.OfferCode = e.NewValues["OfferCode"].ToString()?? string.Empty;
            //model.SiteCode = e.NewValues["SiteCode"].ToString()?? string.Empty;
            model.OfferCount = e.NewValues["OfferCount"]==null? 0:(int)e.NewValues["OfferCount"];
            model.OfferDescription = e.NewValues["OfferDescription"].ToString()?? string.Empty;
           // model.OfferDescriptionTranslate = (Dictionary<string,string>) e.NewValues["OfferDescriptionTranslate"];
            model.OfferTitel = e.NewValues["OfferTitel"].ToString()?? string.Empty;
           // model.OfferTitelTranslate = (Dictionary<string, string>)e.NewValues["OfferTitelTranslate"];
            model.ProviderNotice = e.NewValues["ProviderNotice"].ToString()?? string.Empty;
            model.TourOperatorCode = e.NewValues["TourOperatorCode"].ToString()?? string.Empty;
            model.UnitCode = e.NewValues["UnitCode"].ToString() ?? e.NewValues["UnitCode"].ToString();


            if (model.UnitCode != null)
            {
                model.SiteCode = controller.GetSiteCode(model.UnitCode);
            }


            bool contains = controller.ContainsOfferCode(model.OfferCode);

            if (!contains)
            {
                controller.AddUnitOffer(model);
            }
            e.Cancel = true;
            GridUnitOfferView.CancelEdit();

            Bind();
        }

        protected void GridUnitOfferView_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var listSaP = (List<UnitOfferViewModel>)GridUnitOfferView.DataSource;
            UnitOfferViewModel model = listSaP.Find(m => m.id == e.Keys[0].ToString());
            model.IsAutoStopBooking = (bool)e.NewValues["IsAutoStopBooking"];
            model.OfferCode = e.NewValues["OfferCode"].ToString() ?? string.Empty;
            //model.SiteCode = e.NewValues["SiteCode"].ToString() ?? string.Empty;
            model.OfferCount = e.NewValues["OfferCount"] == null ? 0 : (int)e.NewValues["OfferCount"];
            model.OfferDescription = e.NewValues["OfferDescription"].ToString() ?? string.Empty;
            // model.OfferDescriptionTranslate = (Dictionary<string,string>) e.NewValues["OfferDescriptionTranslate"];
            model.OfferTitel = e.NewValues["OfferTitel"].ToString() ?? string.Empty;
            // model.OfferTitelTranslate = (Dictionary<string, string>)e.NewValues["OfferTitelTranslate"];
            model.ProviderNotice = e.NewValues["ProviderNotice"].ToString() ?? string.Empty;
            model.TourOperatorCode = e.NewValues["TourOperatorCode"].ToString() ?? string.Empty;
            model.UnitCode = e.NewValues["UnitCode"].ToString() ?? e.NewValues["UnitCode"].ToString();

            if(model.UnitCode!=null)
            {
                model.SiteCode = controller.GetSiteCode(model.UnitCode);
            }

            //bool contains = controller.ContainsOfferCode(model.OfferCode);

            //if (!contains)
            //{
                controller.UpdateUnitOffer(model);
            //}
            e.Cancel = true;
            GridUnitOfferView.CancelEdit();

            Bind();
        }

        protected void GridUnitOfferView_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string id = e.Keys[0].ToString();
       
            controller.DeleteUnitOffer(id);
            e.Cancel = true;
            GridUnitOfferView.CancelEdit();

            Bind();
        }

        private void Bind()
        {
            GridUnitOfferView.DataSource = controller.Init();
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

                ASPxWebControl.RedirectOnCallback(VirtualPathUtility.ToAbsolute("~/AspxArea/PriceList/Forms/RetailPriceForm.aspx?sc=" + sitecode + "&oc=" + offercode+ "&uc="+ unitcode));
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
            GridValidation.ValidateLength("UnitCode",2, sender, e);
           
        }

        protected void GridUnitOfferView_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "UnitCode")
            {
                ASPxComboBox combo = (ASPxComboBox)e.Editor;
                combo.DataSource = controller.GetUnitCodes();
                combo.DataBind();
            }
        }
    }
}