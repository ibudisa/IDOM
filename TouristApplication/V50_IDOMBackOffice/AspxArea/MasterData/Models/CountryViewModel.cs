using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace V50_IDOMBackOffice.AspxArea.MasterData.Models
{
    public class CountryViewModel
    {
        public string Id { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public Dictionary<string, string> CountryNameTranslate { get; set; }
        public string ImageGalleryPath { get; set; }
        public string ImageThumbnailsPath { get; set; }
    }
}