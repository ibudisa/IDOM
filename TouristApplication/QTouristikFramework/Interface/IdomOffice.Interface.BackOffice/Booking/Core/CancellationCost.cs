using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdomOffice.Interface.BackOffice.Booking.Core
{
    public class CancellationCost
    {
        public string Id { get; set; }
        public DateTime FromDay { get; set; }
        public DateTime ToDay { get; set; }
        public decimal Percent { get; set; }
    }
}
