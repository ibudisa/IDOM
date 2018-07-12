using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdomOffice.Interface.BackOffice.Booking;
using IdomOffice.Interface.BackOffice.Booking.Core;

namespace V50_IDOMBackOffice.AspxArea.Booking.Models
{
    public class CustomerViewModel
    {
        public string id { get; set; }
        public int CustomerNr { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }
        public string Place { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string EMail { get; set; }
        public List<Note> Notes { get; set; } = new List<Note>();
        public List<CustomerBookingProcessInfo> BookingInfo { get; set; } = new List<CustomerBookingProcessInfo>();
        public List<CustomerContact> Contacts { get; set; } = new List<CustomerContact>();
    }
}