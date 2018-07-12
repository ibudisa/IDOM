using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTouristik.Interface.Sync;

namespace IdomOffice.PlugIn.BackOffice.Sync
{
    public class SyncBookingManager : QTouristik.Interface.Sync.IBookingManager
    {
        // Dodaje novi BookingInquiry u BackOffice
        public void AddBookingInquiry(SyncBookingInquiry irc)
        {



            // provjereriti da li postoji user sa ovom e-mail adressom
            // ukoliko ne postoji dodati novog usera
            // Useru dodati novi booking proces
            // popuniti sve podatke u booking proces
            // dotati novi dokumernt BookingInquiry;
            // projeniti status dokumenta


            UtilityManager.SaveCustomerAndBooking(irc);
        }

        // vrati listu sa BookingInquiry od jednog providera ( ne za touroeratora)
        public IEnumerable<SyncBookingInquiry> GetBookingInquiriesByProvider(int operatorId)
        {
            throw new NotImplementedException();
        }

        public SyncBookingInquiry GetBookingInquiry(string guid)
        {
            throw new NotImplementedException();
        }

        public List<SyncBookingInquiry> GetBookingInquirys()
        {
            throw new NotImplementedException();
        }

        public List<SyncBookingInquiry> GetBookingInquirys(string providerName)
        {
            throw new NotImplementedException();
        }

        public List<string> GetBookingInquirysIds()
        {
            throw new NotImplementedException();
        }
    }
}
