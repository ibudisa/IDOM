using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTouristik.Interface.Sync
{
    public class PaymentOfferOptions
    {
        public int id { get; set; }
        public string Titel { get; set; }
        public decimal OptionsPrice { get; set; }
        public string StornoText { get; set; }
        public string PaymentTerms { get; set; }
    }
}
