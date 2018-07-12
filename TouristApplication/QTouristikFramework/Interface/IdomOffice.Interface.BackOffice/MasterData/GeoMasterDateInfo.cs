using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdomOffice.Interface.BackOffice.MasterData
{
    public class GeoMasterDateInfo
    {
        public UnitOffer UnitOffer { get; set; }
        public TouristUnit TouristUnit { get; set; }
        public  TouristSite TouristSite { get; set; }
        public Place Place { get; set; }
        public Region Region { get; set; }
        public Country Country { get; set; }

    }
}
