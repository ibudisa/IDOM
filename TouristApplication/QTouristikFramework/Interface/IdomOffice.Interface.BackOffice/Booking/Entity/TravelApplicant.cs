using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdomOffice.Interface.BackOffice.Booking.Entity;

namespace IdomOffice.Interface.BackOffice.Booking
{
    public class TravelApplicant : QTouristik.Data.TravelApplicant
    {
        public List<TravelApplicantContact> Emails { get; set; } = new List<TravelApplicantContact>();
    }
}
