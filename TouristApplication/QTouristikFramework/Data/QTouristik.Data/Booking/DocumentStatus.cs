using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTouristik.Data.Booking
{
    public enum DocumentStatus : int
    {
        Open = 1,
        InProcessing = 2,
        Cancellation = 3,
        Close = 4
    }
}
