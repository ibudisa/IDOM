using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTouristik.Interface.Sync
{
    public class Price
    {
        public string CountryName { get; set; }
        public string RegionName { get; set; }
        public string PlaceName { get; set; }
        public string SiteCode { get; set; }
        public string FacilityName { get; set; }
        public string OfferCode { get; set; }
        public string OfferName { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public int FromPersons { get; set; }
        public int ToPersons { get; set; }
        public decimal ValueListPriceByBooking { get; set; }
        public decimal ValueByBooking { get; set; }
        public decimal ValueByArrival { get; set; }

        /// <summary>
        /// TODO: currency as type
        /// </summary>
        public string Currency { get; set; }
        public List<ServicePriceItem> BookingServiceList { get; set; } = new List<ServicePriceItem>();
        public List<ServicePriceItem> ArrivalServiceList { get; set; } = new List<ServicePriceItem>();
        public List<PaymentInfo> PaymentInfoList { get; set; } = new List<PaymentInfo>();
        public string ProviderNotice { get; set; }
        public SyncErrorCode PriceErrorCode { get; set; }
        public string PriceErrorMessage { get; set; }

        public List<PaymentOfferOptions> PaymentOfferList { get; set; } = new List<PaymentOfferOptions>();

    }
}
