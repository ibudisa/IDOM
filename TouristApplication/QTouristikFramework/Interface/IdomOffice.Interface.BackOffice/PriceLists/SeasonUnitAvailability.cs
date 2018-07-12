using System;

namespace IdomOffice.Interface.BackOffice.PriceLists
{
    public class SeasonUnitAvailability
    {
        public string Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool IsAutoStopBooking { get; set; }
        public int UnitCount { get; set; }
    }
}
