using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IdomOffice.Interface.BackOffice.Booking.Core;
using V50_IDOMBackOffice.PlugIn.Controller;
using V50_IDOMBackOffice.AspxArea.Booking.Models;
using V50_IDOMBackOffice.AspxArea.Booking.Controllers;

namespace V50_IDOMBackOffice.AspxArea.Booking.Forms
{
    public partial class ProviderDetailsView : System.Web.UI.Page
    {
        ICoreController controller = new ProviderController();
        string modelid = String.Empty;
        protected void Page_Init(object sender, EventArgs e)
        {
            ProviderEditControl1.InitController += new EventHandler(ProviderEditControl_InitController);
        }
        private void ProviderEditControl_InitController(object sender, EventArgs e)
        {
            Uri u = HttpContext.Current.Request.Url;
            modelid = HttpUtility.ParseQueryString(u.Query).Get("id");

            var pec = (Controls.ProviderEditControl)sender;
            pec.Controller = controller;
            pec.ModelId = modelid;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Uri u = HttpContext.Current.Request.Url;
            //modelid = HttpUtility.ParseQueryString(u.Query).Get("id");


            //// Get a reference to the ContentPlaceHolder
            //MasterPage master = Page.Master;
            //ContentPlaceHolder mainContent = master.FindControl("MainContent") as ContentPlaceHolder;

            
            //var providerEditControl = (Booking.Controls.ProviderEditControl)mainContent.FindControl("ProviderEditControl1") ;
          
            //providerEditControl.Controller = controller;
            //providerEditControl.ModelId = modelid;
        }
    }
}