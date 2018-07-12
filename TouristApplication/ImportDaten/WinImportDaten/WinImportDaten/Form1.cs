using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QTouristik.PlugIn.OVH_V3.IDOM_BackOffice;
using QTouristik.PlugIn.BackOffice.Booking;
using QTouristik.Interface.BackOffice.Booking;
using QTouristik.Interface.BackOffice.Booking.Core;

namespace WinImportDaten
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mdm = new QTouristik.PlugIn.BackOffice.Booking.BookingDataManager();
            mdm.AddMasterData(new Provider { Id = Guid.NewGuid().ToString(), Name = "Adriatic Kamp", ProviderId = 70206, City = "Pula", BookingEmail = "Adriatic.Kamp@idom-reisen.de" });
            mdm.AddMasterData(new Provider { Id = Guid.NewGuid().ToString(), Name = "Adria More", ProviderId = 70201, City = "Pakostane", BookingEmail = "adria.more@idom-reisen.de" });
            mdm.AddMasterData(new Provider { Id = Guid.NewGuid().ToString(), Name = "Igor Cuic", ProviderId = 70001, City = "Neuburg", BookingEmail = "igor.cuic@idom-reisen.de" });
            mdm.AddMasterData(new Provider { Id = Guid.NewGuid().ToString(), Name = "Ilirija d.o.o", ProviderId = 70203, City = "Biograd na moru", BookingEmail = "ilirija@idom-reisen.de" });
            mdm.AddMasterData(new Provider { Id = Guid.NewGuid().ToString(), Name = "Camping Solaris", ProviderId = 70204, City = "Solaris Sibenik", BookingEmail = "solaris@idom-reisen.de" });

            var aa = new QTouristik.PlugIn.OVH_V3.IDOM_BackOffice.BookingManager().GetBookingInquirys();
            int custommerNr = 1000;
            foreach (var item in aa)
            {
                if (item.BookingData.OfferCode == null)
                    continue;

                if (item.BookingData.SiteCode == null)
                    continue;

                var bdm = new QTouristik.PlugIn.BackOffice.Booking.BookingDataManager();
                Customer cs = new Customer();
                cs.id = Guid.NewGuid().ToString();
                cs.CustomerNr = custommerNr++;
                cs.Salutation = item.BookingData.TravelApplicant.Salutation;
                cs.FirstName = item.BookingData.TravelApplicant.FirstName;
                cs.LastName = item.BookingData.TravelApplicant.LastName;
                cs.ZipCode = item.BookingData.TravelApplicant.ZipCode;
                cs.Adress = item.BookingData.TravelApplicant.Adress;
                cs.Contry = item.BookingData.TravelApplicant.Contry;
                cs.Place = item.BookingData.TravelApplicant.Place;
                cs.EMail = cs.FirstName.Trim() + "." + cs.LastName.Trim() + "@idom-reisen.de";
                
                CustomerBookingProcessInfo cbp = new CustomerBookingProcessInfo();

                cbp.BookingProcessId = Guid.NewGuid().ToString();
                cbp.CheckIn = item.BookingData.CheckIn;
                cbp.CheckOut = item.BookingData.CheckOut;
                cbp.SiteName = item.BookingData.SiteName;
                cbp.OfferName = item.BookingData.OfferName;
                cs.BookingInfo.Add(cbp);

                bdm.AddMasterData(cs);
                AddBookingProcess(cbp, item, cs.CustomerNr);
            }

        }

        private void AddBookingProcess(CustomerBookingProcessInfo cbpi, QTouristik.Interface.Booking.BookingInquiry bi, int travelApplicantId)
        {
            var bdm = new QTouristik.PlugIn.BackOffice.Booking.BookingDataManager();
            BookingProcess bp = new BookingProcess();
            bp.Id = Guid.NewGuid().ToString();
            bp.Status = DocumentProcessStatus.New;
            bp.OfferInfo.SiteCode = bi.BookingData.SiteCode;
            bp.OfferInfo.UnitCode = bi.BookingData.UnitCode;
            bp.OfferInfo.PlaceName = bi.BookingData.PlaceName;
            bp.OfferInfo.Adults = bi.BookingData.Adults;
            bp.OfferInfo.CheckIn = bi.BookingData.CheckIn;
            bp.OfferInfo.CheckOut = bi.BookingData.CheckOut;
            bp.OfferInfo.Children = bi.BookingData.Children;
            bp.OfferInfo.Country = bi.BookingData.Country;
            bp.OfferInfo.OfferCode = bi.BookingData.OfferCode;
            bp.OfferInfo.OfferName = bi.BookingData.OfferName;
            bp.OfferInfo.SiteName = bi.BookingData.SiteName;
            bp.OfferInfo.TourOperator = bi.BookingData.TourOperator;
            bp.OfferInfo.YoungAdults = bi.BookingData.YoungAdults;
            bp.PartnerId = 0;

            bp.TravelApplicant.Salutation = bi.BookingData.TravelApplicant.Salutation;
            bp.TravelApplicant.FirstName = bi.BookingData.TravelApplicant.FirstName;
            bp.TravelApplicant.LastName = bi.BookingData.TravelApplicant.LastName;
            bp.TravelApplicant.Place = bi.BookingData.TravelApplicant.Place;
            bp.TravelApplicant.Adress = bi.BookingData.TravelApplicant.Adress;
            bp.TravelApplicant.ZipCode = bi.BookingData.TravelApplicant.ZipCode;
            bp.TravelApplicant.Contry = bi.BookingData.TravelApplicant.Contry;
            bp.ProviderId = GetProviderId(bp.OfferInfo);
            bp.TravelApplicantId = travelApplicantId;
            bp.Season = bi.BookingData.CheckIn.Year.ToString();

            BookingProcessItem bpi = new BookingProcessItem();
            bpi.BookingProcessTyp = BookingProcessItemTyp.BookingInquiry;
            bpi.Author = "Igor Cuic";
            bpi.DocumentNr = bi.InquiryCode;
            bpi.CreateDate = DateTime.Now;
            bpi.LastChange = DateTime.Now;
            bpi.DocumentStatus = DocumentStatus.Active;
            bpi.DocumentTitel = "Anmeldebestätigung " + bi.InquiryCode;
            AddBookingInquiry(bp.Id, bpi, bi);
            bp.BookingProcessItemList.Add(bpi);
            bdm.AddMasterData(bp);
        }
        private int GetProviderId(OfferInfo oi)
        {
            if (oi.OfferName == "ARIA" || oi.OfferName == "BAHAMAS")
                return 70206;

            if (oi.OfferName == "850" || oi.OfferName == "811" || oi.OfferName == "XLINE")
                return 70201;

            return 70001;
        }
        private void AddBookingInquiry(string bookingProcessId, BookingProcessItem bpi, QTouristik.Interface.Booking.BookingInquiry bi)
        {
            QTouristik.Interface.BackOffice.Booking.BookingInquiry newBi = new BookingInquiry();
            var bdm = new QTouristik.PlugIn.BackOffice.Booking.BookingDataManager();
            newBi.BookingInquiryNummer = Guid.NewGuid().ToString();
            newBi.BookingProcessId = bookingProcessId;
            newBi.id = Guid.NewGuid().ToString();
            bpi.DocumentId = newBi.BookingInquiryNummer;
            newBi.BookingInquiryNummer = bi.InquiryCode;
            newBi.OfferInfo.SiteCode = bi.BookingData.SiteCode;
            newBi.OfferInfo.UnitCode = bi.BookingData.UnitCode;
            newBi.OfferInfo.PlaceName = bi.BookingData.PlaceName;
            newBi.OfferInfo.Adults = bi.BookingData.Adults;
            newBi.OfferInfo.CheckIn = bi.BookingData.CheckIn;
            newBi.OfferInfo.CheckOut = bi.BookingData.CheckOut;
            newBi.OfferInfo.Children = bi.BookingData.Children;
            newBi.OfferInfo.Country = bi.BookingData.Country;
            newBi.OfferInfo.OfferCode = bi.BookingData.OfferCode;
            newBi.OfferInfo.OfferName = bi.BookingData.OfferName;
            newBi.OfferInfo.SiteName = bi.BookingData.SiteName;
            newBi.OfferInfo.TourOperator = bi.BookingData.TourOperator;
            newBi.OfferInfo.YoungAdults = bi.BookingData.YoungAdults;

            bdm.AddMasterData(newBi);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var bdm = new QTouristik.PlugIn.BackOffice.Booking.BookingDataManager();
            var inq = bdm.GetBookingInquires();
        }
    }
}
