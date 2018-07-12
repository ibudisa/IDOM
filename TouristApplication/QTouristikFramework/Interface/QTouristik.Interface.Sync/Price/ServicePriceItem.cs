using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTouristik.Interface.Sync
{
    public class ServicePriceItem
    {
        public string Id { get; set; }
        public ServiceType ServiceType { get; set; }
        public string Description { get; set; }
        public decimal Eur { get; set; }
    }
}
