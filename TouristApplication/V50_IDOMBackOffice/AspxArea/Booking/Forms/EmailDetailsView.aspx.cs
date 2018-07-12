using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using V50_IDOMBackOffice.AspxArea.Booking.Controllers;

namespace V50_IDOMBackOffice.AspxArea.Booking.Forms
{
    public partial class EmailDetailsView : System.Web.UI.Page
    {
        EmailProcessControler controller = new EmailProcessControler();
        string id = String.Empty;
        string itemid = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            Uri u = HttpContext.Current.Request.Url;
            id = HttpUtility.ParseQueryString(u.Query).Get("id");
            itemid = HttpUtility.ParseQueryString(u.Query).Get("itemid");
            var model = controller.GetEmailProcessViewModelById(itemid);
            lblSender.Text = model.Sender;
            lblReceiver.Text = model.Receipent;
            lblSubject.Text = model.Title;
            MemoContent.Text = model.Content;
        }
    }
}