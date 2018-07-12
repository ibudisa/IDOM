using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace V50_IDOMBackOffice.AspxArea.MasterData.Models
{
    public class RegionViewModel
    {
        public string Id { get; set; }
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public Dictionary<string, string> RegionNameTranslate { get; set; }
        public int CountryId { get; set; }
        public string ImageGalleryPath { get; set; }
        public string ImageThumbnailsPath { get; set; }
    }
}