using System.Collections.Generic;

namespace IdomOffice.Interface.BackOffice.MasterData
{
    public class TouristSite
    {
        public string id { get; set; }
        public string SiteCode { get; set; }
        public int PlaceId { get; set; }
        public int RegionId { get; set; }
        public int CountryId { get; set; }
        public string SiteName { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> DescriptionTranslate { get; set; } = new Dictionary<string, string>();
        public string ImageGalleryPath { get; set; }
        public string ImageThumbnailsPath { get; set; }
        public List<int> Touroperators { get; set; } = new List<int>();
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool Pool { get; set; }
    }
}
