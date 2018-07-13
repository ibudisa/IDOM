using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BookingDocumentBase
    {
        public string Id { get; set; }
        public string docType { get; set; }
        public string BookingProcessId { get; set; }
        public string DocumentId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Author { get; set; }
        public string HtmlDocumentView { get; set; }
    }
}
