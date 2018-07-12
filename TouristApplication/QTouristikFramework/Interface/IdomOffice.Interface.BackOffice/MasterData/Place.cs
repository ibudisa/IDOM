namespace IdomOffice.Interface.BackOffice.MasterData
{
    public class Place
    {
        public string Id { get; set; }
        public int PlaceId { get; set; }
        public int RegionId { get; set; }
        public string PlaceName { get; set; }
        public string ImageGalleryPath { get; set; }
        public string ImageThumbnailsPath { get; set; }
    }
}
