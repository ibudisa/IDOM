using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace V50_IDOMBackOffice.AspxArea.MasterData.Models
{
    public class TouristOfferViewModel
    {
        public string TouristUnitId { get; set; }
        public string UnitOfferId { get; set; }
        public string TourOperatorCode { get; set; }
        public string SiteCode { get; set; }
        public string OfferCode { get; set; }
        public string OfferTitel { get; set; }
        
        public string OfferDescription { get; set; }
        
        public int OfferCount { get; set; }
        public string UnitCode { get; set; }
        public bool IsAutoStopBooking { get; set; }
        public string ProviderNotice { get; set; }


        public string CountryName { get; set; }
        public string RegionName { get; set; }
        public string PlaceName { get; set; }
        public string UnitTitel { get; set; }
       
        public string TravelServiceProvider { get; set; }
        
       
        public string SiteName { get; set; }
        public int MobilhomeArea { get; set; }
        public int TerraceArea { get; set; }
        public int Bedroom { get; set; }
        public string Bathrooms { get; set; }
        public string Beds { get; set; }
        public string ImageGalleryPath { get; set; }
        public string ImageThumbnailsPath { get; set; }
        public int MaxPersons { get; set; }
        public int MaxAdults { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public string PurchasePriceListId { get; set; }
    }
}