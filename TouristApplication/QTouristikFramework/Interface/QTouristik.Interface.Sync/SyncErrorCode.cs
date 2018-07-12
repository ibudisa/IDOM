using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTouristik.Interface.Sync
{
    public enum SyncErrorCode : int
    {
        OK = 0,
        ObjectOutbound = 1,
        ServiceDoesNotWork = 2,
        UnknownErrors = 99
    }
}
