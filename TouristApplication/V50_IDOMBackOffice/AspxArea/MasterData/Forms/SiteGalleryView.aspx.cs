using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace V50_IDOMBackOffice.AspxArea.MasterData.Forms
{
    public partial class SiteGalleryView : System.Web.UI.Page
    {
        string sitecode;
        string folder;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Uri u = HttpContext.Current.Request.Url;
                sitecode = HttpUtility.ParseQueryString(u.Query).Get("sc");
                ViewState["sitecode"] = sitecode;
                folder = CreateFolder(sitecode);
            }
            else
            {
                sitecode = (string)ViewState["sitecode"];
                folder = CreateFolder(sitecode);
            }
        }

        private string CreateFolder(string site)
        {
            string basefolder = MapPath("~/Content/Images/");
            string sitefolder = basefolder + "Site_" + site + "\\";
            if (!Directory.Exists(sitefolder))
            {
                Directory.CreateDirectory(sitefolder);
            }
            

            return sitefolder;
        }

        protected void SiteFileManager_Load(object sender, EventArgs e)
        {
            SiteFileManager.Settings.RootFolder = folder;
            int i = 0;
        }

        protected void SiteFileManager_FileUploading(object source, DevExpress.Web.FileManagerFileUploadEventArgs e)
        {
            string file = e.FileName;
            string fullpath = folder + "\\" + file;
            FileStream fs = new FileStream(fullpath, FileMode.CreateNew, FileAccess.ReadWrite);
            e.InputStream.CopyTo(fs);
            fs.Close(); //close the new file created by the FileStream
            e.Cancel = true; //cancelling the upload, prevents duplicate uploads
            e.ErrorText = "Success"; //shown when the upload is cancelled
            //SiteFileManager.Settings.RootFolder = folder;
        }
    }
}