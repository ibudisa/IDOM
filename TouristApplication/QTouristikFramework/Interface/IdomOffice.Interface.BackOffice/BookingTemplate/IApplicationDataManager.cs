using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdomOffice.Interface.BackOffice.BookingTemplate;
using IdomOffice.Interface.BackOffice.Booking;

namespace IdomOffice.Interface.BackOffice.BookingTemplate
{
    public interface IApplicationDataManager
    {
        void AddApplicationData(StatusDataDocument document);
        List<StatusDataDocument> GetStatusDocuments();
        List<StatusDataDocument> GetStatusDocumentsByStatus(DocumentProcessStatus status);
        StatusDataDocument GetStatusDocumentsById(string id);
    }
}
