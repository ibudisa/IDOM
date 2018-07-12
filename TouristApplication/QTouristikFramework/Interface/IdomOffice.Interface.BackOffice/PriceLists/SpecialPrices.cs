using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdomOffice.Interface.BackOffice.PriceLists
{
    public class SpecialPrices
    {
        public string Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int FromPersons { get; set; }
        public int ToPersons { get; set; }
        public decimal Eur { get; set; }
    }
}
