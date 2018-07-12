using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdomOffice.Core.Config
{
    public class ConfigIntegerInfo:ConfigInfo
    {
        public int GetValue(string key)
        {
            int value = 0;
            var item = LoadJson().Find(m => m.Key == key);
            string itemtype = item.KeyType;
            string itemvalue = item.Value;
            value = int.Parse(itemvalue);

            return value;
        }
    }
}
