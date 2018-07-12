using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using V50_IDOMBackOffice.HelperNew;


namespace V50_IDOMBackOffice.SupportForms
{
    public partial class UsersForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string firstname = txtFirstName.Text;
            string lastname = txtLastName.Text;
            string email = txtEmail.Text;
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            string ipaddress = txtIPAddress.Text;
            string season = txtSeason.Text;

            ConfigData.SaveToConfig(firstname, lastname, email, username, password, ipaddress, season);
        }
    }
}