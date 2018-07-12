using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdomOffice.Interface.BackOffice.MasterData
{
    public class Country
    {
        public string Id { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public Dictionary<string, string> CountryNameTranslate { get; set; }
        public string ImageGalleryPath { get; set; }
        public string ImageThumbnailsPath { get; set; }
    }
}
