using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DateInterval
    {
        public DateInterval()
        { }

        [global::Newtonsoft.Json.JsonIgnoreAttribute]
        public string Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
