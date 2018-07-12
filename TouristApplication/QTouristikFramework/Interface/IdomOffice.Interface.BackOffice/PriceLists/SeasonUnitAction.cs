namespace IdomOffice.Interface.BackOffice.PriceLists
{
    public class SeasonUnitAction
    {
        public string Id { get; set; }
        public ActionType ActionType { get; set; }
        public System.DateTime ActionStart { get; set; }
        public System.DateTime ActionEnd { get; set; }
        public System.DateTime FromDate { get; set; }
        public System.DateTime ToDate { get; set; }
        public int MinStayDays { get; set; }
        public int MinPrice { get; set; }
        public int FreeNights { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountEur { get; set; }
        public bool CanBeCombined { get; set; }
    }
}
