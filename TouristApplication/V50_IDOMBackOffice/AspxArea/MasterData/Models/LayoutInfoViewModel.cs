using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace V50_IDOMBackOffice.AspxArea.MasterData.Models
{
    public class LayoutInfoViewModel
    {
       
        
        public int Bathrooms { get; set; }
        
        
        /// <summary>
        /// TO to which the tourist unit belongs
        /// </summary>
       

        public string UnitType { get; set; }



        public bool Disabled { get; set; }



        #region Interior area (Innenbereich)

        public int MobilehomeSize { get; set; } = 0;

        public int Bedrooms { get; set; } = 0;



        public int BunkBeds { get; set; } = 0;
        public int SingleBeds { get; set; } = 0;
        public int DoubleBeds { get; set; } = 0;
        public int ExtraBeds { get; set; } = 0;

        public int WC { get; set; } = 0;



        public bool AirConditioning { get; set; }

        public List<string> ExtraEquipment { get; set; }
        //public List<object> ExtraEquipment { get; set; }

        public bool Coffeemachine { get; set; }
        public bool Fridge { get; set; }
        public bool Childbed { get; set; }
        public bool DVDPlayer { get; set; }

        #endregion Interior area (Innenbereich)

        #region Exterior area

        // unused


        public string TerraceType { get; set; }
        public int TerraceSize { get; set; } = 0;
        public int ParcelSize { get; set; } = 0;
        public bool Sunloungers { get; set; }
        public bool Sunshade { get; set; }
        public bool WoodenFurniture { get; set; }
        public bool SolarShower { get; set; }
        public bool Kettle { get; set; }

        #endregion Exterior area

        #region Occupancy (Belegung)


        

        #endregion Occupancy


        public List<string> PriceInclusive { get; set; }

        public List<string> OtherFeatures { get; set; }

        public bool Towel { get; set; }
        public bool BedWashing { get; set; }
        public bool Parkinglot { get; set; }
        public bool FinishCleaning { get; set; }

        public bool WiFiInternetPriceFree { get; set; }
        public bool WiFiInternet { get; set; }
        public bool Pool { get; set; }

        #region Location

        public int BeachDistanceFrom { get; set; } = 0;
        public int BeachDistanceTo { get; set; } = 0;
        public string LocationSite { get; set; }
        public string LocationSea { get; set; }

        #endregion Location



    }
}