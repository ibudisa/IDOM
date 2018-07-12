using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTouristik.Interface.Sync
{
    public class PaymentInfo
    {
        public DateTime Date { get; set; }
        public int Percent { get; set; }
        public decimal Eur { get; set; }
    }
}
