using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using V50_IDOMBackOffice.AspxArea.Booking.Controllers;

namespace V50_IDOMBackOffice.AspxArea.Booking.Forms
{
    public partial class DocViewPopUpForm : System.Web.UI.Page
    {
        BookingProcessDetailsProController controller = new BookingProcessDetailsProController();
        string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            Uri u = HttpContext.Current.Request.Url;
            id = HttpUtility.ParseQueryString(u.Query).Get("id");
            Bind();
        }

        private void Bind()
        {
            var model = controller.GetBookingProcessItemById(id);
            var content = controller.GetDocumentContent(model.BookingProcessTyp, id);
            HtmlEditorItem.Html = content;
        }
    }
}