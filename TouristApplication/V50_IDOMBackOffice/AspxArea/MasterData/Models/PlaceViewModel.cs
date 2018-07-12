using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace V50_IDOMBackOffice.AspxArea.MasterData.Models
{
    public class PlaceViewModel
    {
        public string Id { get; set; }
        public int PlaceId { get; set; }
        public int RegionId { get; set; }
        public string PlaceName { get; set; }
        public string ImageGalleryPath { get; set; }
        public string ImageThumbnailsPath { get; set; }
    }
}