using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdomOffice.Core.Config
{
    public class ConfigDateInfo:ConfigInfo
    {
        public DateTime GetValue(string key)
        {
            DateTime data = DateTime.Now;
            var item = LoadJson().Find(m => m.Key == key);
            string itemtype = item.KeyType;
            string itemvalue = item.Value;
            data = DateTime.Parse(itemvalue);

            return data;
        }
    }
}
