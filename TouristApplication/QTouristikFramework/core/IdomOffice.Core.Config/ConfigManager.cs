using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdomOffice.Core.Config
{
    public class ConfigManager
    {
        ConfigInfo info;
        public ConfigInfo infodata { get; set; }
        string key;

        public ConfigManager(string key)
        {
            this.info = new ConfigInfo();
            this.key = key;
            SetDataType();
        }

        private void SetDataType()
        {
            string type = this.info.GetKeyType(key);

            if(type=="System.String")
            {
                infodata = new ConfigStringInfo();
            }
            else if(type=="System.Int")
            {
                infodata = new ConfigIntegerInfo();
            }
            else if(type=="System.DateTime")
            {
                infodata = new ConfigDateInfo();
            }
            else
            {
                infodata = new ConfigStringInfo();
            }
        }
    }
}
