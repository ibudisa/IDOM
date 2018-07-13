using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class Repository
    {
        private IgorEntities context = new IgorEntities();

        public List<SEH_UnitInfo> GetAllUnits()
        {
            var units = context.SEH_UnitInfo.ToList();
            return units;
        }
        public List<SEH_SiteInfo> GetAllSites()
        {
            var sites = context.SEH_SiteInfo.ToList();
            return sites;
        }

        public List<dbBuchungen> GetAllBookings()
        {
            var bookings = context.dbBuchungens.ToList();
            return bookings;
        }

        public List<dbGeoLocation> GetAllLocations()
        {
            var locations = context.dbGeoLocations.ToList();
            return locations;
        }
    }
}
