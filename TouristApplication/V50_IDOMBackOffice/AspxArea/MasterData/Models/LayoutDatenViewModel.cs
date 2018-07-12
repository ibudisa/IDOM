using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace V50_IDOMBackOffice.AspxArea.MasterData.Models
{
    public class LayoutDatenViewModel
    {
        public int MaxPersons { get; set; }
        public int MaxAdults { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
    }
}