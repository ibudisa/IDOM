using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTouristik.Data;

namespace DAL
{
    public class BookingProcess
    {
        public string Id { get; set; }
        public string docType { get; set; } = "BookingProcess";
        public OfferInfo OfferInfo { get; set; } = new OfferInfo();
        public int TravelApplicantId { get; set; }
        public TravelApplicant TravelApplicant { get; set; } = new TravelApplicant();
        public List<TravelerEntity> TravelerList { get; set; } = new List<TravelerEntity>();
        public DocumentProcessStatus Status { get; set; }
        public List<BookingProcessItem> BookingProcessItemList { get; set; } = new List<BookingProcessItem>();
        public List<PaymentTerm> PaymentTerms { get; set; } = new List<PaymentTerm>();
        public List<PriceOverview> PriceOverviewByArrival { get; set; } = new List<PriceOverview>();
        public List<PriceOverview> PriceOverviewByBooking { get; set; } = new List<PriceOverview>();
        public decimal PriceValueByArrival { get; set; }
        public decimal PriceValueByBooking { get; set; }
        public int SellingPartner { get; set; }
        public int AccProvider { get; set; }
        public string Season { get; set; }
        public List<TravelApplicantPayment> Payments { get; set; } = new List<TravelApplicantPayment>();
        public DateTime CancellationFeesDeadline { get; set; }
        public int CancellationFeesPercent { get; set; }
        public List<ProviderPayment> PaymentsForProvider { get; set; } = new List<ProviderPayment>();
        public string BookingNumber { get; set; }
        public DocumentDataStatus BookingStatus { get; set; } = new DocumentDataStatus();
        public string CustomerNote { get; set; }
    }
}
