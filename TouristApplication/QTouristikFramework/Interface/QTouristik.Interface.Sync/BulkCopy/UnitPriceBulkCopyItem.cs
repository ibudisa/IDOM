using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTouristik.Interface.Sync
{
    public class UnitPriceBulkCopyItem
    {
        public DateTime Anreise { get; set; }
        public int Reisedauer { get; set; }
        public int MinPersonen { get; set; }
        public int MaxPersonen { get; set; }
        public decimal ListenPreis { get; set; }
        public decimal EndPreis { get; set; }
    }
}
