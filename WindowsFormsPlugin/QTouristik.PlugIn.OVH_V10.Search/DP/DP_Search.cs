using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTouristik.PlugIn.OVH_V3.Search.LM;

namespace QTouristik.PlugIn.OVH_V10.Search.DP
{
    public class DP_Search
    {
        public static GeneralDataProvider<KeyDatabaseSet> KeyDatabase
        {
            get { return new GeneralDataProvider<KeyDatabaseSet>(); }
        }

        public static GeneralDataProvider<SEH_UnitInfo> SEH_UnitInfo
        {
            get { return new GeneralDataProvider<SEH_UnitInfo>(); }
        }

        public static GeneralDataProvider<SEH_ObjektInfo> SEH_ObjektInfo
        {
            get { return new GeneralDataProvider<SEH_ObjektInfo>(); }
        }

        public static GeneralDataProvider<SEH_FeWoPreiseSet> SEH_FeWoPreise
        {
            get { return new GeneralDataProvider<SEH_FeWoPreiseSet>(); }
        }
    }
}
