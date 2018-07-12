using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;

namespace IdomOffice.Core.Config
{
    public class ConfigInfo
    {
        private static string filepath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "\\ConfigFile1.json";

        //public static List<ObjectInfo> list { get; set; } = new List<ObjectInfo>();

        static ConfigInfo()
        {
            //SetFilePath();
            bool dataexists = false;
            dataexists = DataExists();
            if (!dataexists)
            {
                AddJson("MongoUrl", "mongodb://ivan:ivan+2017@94.23.164.152:27017/IDOM_BackOffice_Test", "System.String");
                AddJson("MongoDB", "IDOM_BackOffice_Test", "System.String");
                AddJson("Season", "2018", "System.Int");
                AddJson("Date", "12.05.2018", "System.DateTime");
            }
        }

        protected static void SetFilePath()
        {
            filepath = ConfigurationManager.AppSettings["ConfigFilePath"].ToString();
            filepath= Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filepath);

        }

        protected static void AddJson(string Key, string Value, string KeyType)
        {
            ObjectInfo data = new ObjectInfo();
            data.Key = Key;
            data.Value = Value;
            data.KeyType = KeyType;

            SaveJsonToFile(data);
        }

        protected static void SaveJsonToFile(ObjectInfo info)
        {
            string content = File.ReadAllText(filepath);

            if (content.Length > 0)
            {
               var list = JsonConvert.DeserializeObject<List<ObjectInfo>>(content);
                list.Add(info);
                var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                using (StreamWriter writer = new StreamWriter(filepath))
                {
                    writer.Write(convertedJson);
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(filepath))
                {
                    var list = new List<ObjectInfo>();
                    list.Add(info);
                    var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                    writer.Write(convertedJson);
                }
            }
        }

        protected static bool DataExists()
        {
            bool exists = false;
            string content = File.ReadAllText(filepath);
            if(content.Length>0)
            {
                exists = true;
            }

            return exists;
        }

        protected static List<ObjectInfo> LoadJson()
        {
            List<ObjectInfo> items = new List<ObjectInfo>();
            using (StreamReader r = new StreamReader(filepath))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<ObjectInfo>>(json);
            }
            return items;
        }

        public  string GetKeyType(string key)
        {
            var item = LoadJson().Find(m => m.Key == key);
            string itemtype = item.KeyType;

            return itemtype;
        }
        /*
                private static string GetStringValue(string value)
                {
                    string data = value;
                    return data;
                }

                private static int GetIntValue(string value)
                {
                    int data = 0;
                    data = int.Parse(value);
                    return data;

                }

                private static DateTime GetDateValue(string value)
                {
                    DateTime datevalue = DateTime.Now;
                    datevalue = DateTime.Parse(value);
                    return datevalue;
                }

                public static object DetermineData(Type t,string value)
                {
                    string name = t.Name;
                    object returndata = new object();

                    if(name=="String")
                    {
                        returndata = GetStringValue(value);
                    }
                    else if(name=="Int")
                    {
                        returndata = GetIntValue(value);
                    }
                    else if(name=="DateTime")
                    {
                        returndata = GetDateValue(value);
                    }

                    return returndata;
                }

            */

    }
}
