namespace IdomOffice.Interface.BackOffice.PriceLists
{
    public class SeasonUnitService
    {
        public string Id { get; set; }
        public ServiceType ServiceType { get; set; }
        public ServiceInterval ServiceInterval { get; set; }
        public ServiceUnit ServiceUnit { get; set; }
        public PaymentPlace PaymentPlace { get; set; }
        public bool IsOptional { get; set; }
        public string Description { get; set; }
        public System.DateTime FromDate { get; set; }
        public System.DateTime ToDate { get; set; }
        public int OfOld { get; set; }
        public int ToOld { get; set; }
        public int OfDay { get; set; }
        public int ToDay { get; set; }
        public decimal Eur { get; set; }
    }
}
