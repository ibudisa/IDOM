using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TravelApplicant
    {
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }
        public string Place { get; set; }
        public string Contry { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string EMail { get; set; }
        public List<TravelApplicantContact> Emails { get; set; } = new List<TravelApplicantContact>();
    }
}
