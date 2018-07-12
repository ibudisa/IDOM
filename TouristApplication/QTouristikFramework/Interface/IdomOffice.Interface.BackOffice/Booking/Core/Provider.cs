using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdomOffice.Interface.BackOffice.Booking.Core
{
    public class Provider
    {
        public string Id { get; set; }
        public int ProviderId { get; set; }
        public string PersonalIdentificationNumber { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Bank { get; set; }
        public string IBAN { get; set; }
        public List<ProviderContact> Contacts { get; set; } = new List<ProviderContact>();
        public List<Note> Notes { get; set; } = new List<Note>();
        public string BookingEmail { get; set; }
        public string Title { get; set; }
        public List<CancellationCost> Cancellations { get; set; } = new List<CancellationCost>();
    }
}
