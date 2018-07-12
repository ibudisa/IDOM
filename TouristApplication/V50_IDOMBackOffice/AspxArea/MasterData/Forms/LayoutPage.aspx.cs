using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using V50_IDOMBackOffice.AspxArea.MasterData.Models;
using V50_IDOMBackOffice.AspxArea.MasterData.Controllers;

namespace V50_IDOMBackOffice.AspxArea.MasterData.Forms
{
    public partial class LayoutPage : System.Web.UI.Page
    {
        CountryViewController controller = new CountryViewController();

        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        private void Bind()
        {
            Layout.DataSource = controller.Init();
            Layout.DataBind();
        }

    }
}