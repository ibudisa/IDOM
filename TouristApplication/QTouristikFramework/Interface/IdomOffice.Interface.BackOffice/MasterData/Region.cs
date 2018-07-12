using System.Collections.Generic;

namespace IdomOffice.Interface.BackOffice.MasterData
{
    public class Region 
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
