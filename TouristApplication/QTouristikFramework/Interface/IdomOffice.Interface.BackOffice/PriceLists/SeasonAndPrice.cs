
namespace IdomOffice.Interface.BackOffice.PriceLists
{
    public class SeasonAndPrice
    {
       
        public string Id { get; set; }
        public int FromPersons { get; set; }
        public int ToPersons { get; set; }
        public System.DateTime FromDate { get; set; }
        public System.DateTime ToDate { get; set; }
        public PriceType PriceType { get; set; }
        public decimal Eur { get; set; }
    }
}
