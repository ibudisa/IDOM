using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace V50_IDOMBackOffice.AspxArea.Booking.Models
{
    public class LayoutCustomerViewModel
    {
        public int CustomerNr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }
        public string Place { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string EMail { get; set; }
    }
}