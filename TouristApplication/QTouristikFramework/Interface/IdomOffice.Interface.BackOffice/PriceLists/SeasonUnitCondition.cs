using System;
using System.Collections.Generic;

namespace IdomOffice.Interface.BackOffice.PriceLists
{
    public class SeasonUnitCondition
    {
        public string Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public List<string> Arrival { get; set; } = new List<string>();
        public List<string> Departure { get; set; } = new List<string>();
        public string ArrivalActual { get; set; } 
        public string DepartureActual { get; set; }
        public int MinStay { get; set; }
        public int ReleaseDays { get; set; }
    }
}
