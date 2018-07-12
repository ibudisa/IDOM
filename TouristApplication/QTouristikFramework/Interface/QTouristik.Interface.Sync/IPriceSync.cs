using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTouristik.Interface.Sync
{
    public interface IPriceSync
    {
        Price GetPrice(PriceArg arg);
        IEnumerable<UnitPriceBulkCopyItem> GetUnitPriceSearchList(string tourOperatorId, string facilityCode, string unitCode, string offerCode);
    }
}
