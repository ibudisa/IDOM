using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace BLL
{
    [DelimitedRecord("")]
    public class CustomerModel
    {
        [FieldNullValue(typeof(int), "0")]
        public int CustomerNr;
        [FieldNullValue(typeof(string), "")]
        public string FullName;
        [FieldNullValue(typeof(string), "")]
        public string Salutation;
        [FieldNullValue(typeof(string), "")]
        public string FirstName;
        [FieldNullValue(typeof(string), "")]
        public string LastName;
        [FieldNullValue(typeof(string), "")]
        public string EMail;
        [FieldNullValue(typeof(string), "")]
        public string ZipCode;
        [FieldNullValue(typeof(string), "")]
        public string Place;
        [FieldNullValue(typeof(string), "")]
        public string Adress;
        [FieldNullValue(typeof(string), "")]
        public string Contry;
        [FieldNullValue(typeof(string), "")]
        public string Phone;
        [FieldNullValue(typeof(string), "")]
        public string MobilePhone;

    }
}
