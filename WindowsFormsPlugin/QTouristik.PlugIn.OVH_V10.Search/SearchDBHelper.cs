using QTouristik.PlugIn.OVH_V3.Search.LM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTouristik.PlugIn.OVH_V10.Search
{
    public class SearchDBHelper
    {
        public List<SEH_UnitInfo> GetSEHUnitInfo(int touroperator)
        {
            return DP.DP_Search.SEH_UnitInfo.GetList(m => m.suTourOperator == touroperator);
        }

        public void AddSEH_UnitInfo(SEH_UnitInfo unit)
        {
            DP.DP_Search.SEH_UnitInfo.AddEntity(unit);
        }

        public void UpdateSEH_UnitInfo(SEH_UnitInfo unit)
        {
            DP.DP_Search.SEH_UnitInfo.UpdateEntity(unit);
        }

        
    }
}
