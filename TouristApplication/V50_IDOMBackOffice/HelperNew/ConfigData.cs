using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleCrypto;
using Newtonsoft.Json;
using System.IO;
using System.Configuration;

namespace V50_IDOMBackOffice.HelperNew
{
    public class ConfigData
    {
        private static string filepath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "\\Configdata.json";
        //private static string filepath = Path.GetFullPath(ConfigurationManager.AppSettings["FilePath"].ToString());

        

        public static void SaveToConfig(string firstname,string lastname,string email,string username,string password,string ipaddress, string season)
        {
            User u = new User();
            u.Id = Guid.NewGuid().ToString();
            u.FirstName = firstname;
            u.LastName = lastname;
            u.UserName = username;
            u.Email = email;
            u.IPAddressDatabase = ipaddress;
            u.Season = season;
            EncryptPassword(ref u, password);
            SaveJson(u);
        }

        private static void EncryptPassword(ref User user, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            var encrypPass = crypto.Compute(password);
            user.Password = encrypPass;
            user.PasswordSalt = crypto.Salt;
        }

        private static void SaveJson(User user)
        {
            string content = File.ReadAllText(filepath);

            if (content.Length > 0)
            {
                var list = JsonConvert.DeserializeObject<List<User>>(content);
                list.Add(user);
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
                    List<User> list = new List<User>();
                    list.Add(user);
                    var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                    writer.Write(convertedJson);
                }
            }
        }

        public static List<User> LoadJson()
        {
            List<User> items = new List<User>();
            using (StreamReader r = new StreamReader(filepath))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<User>>(json);
            }
            return items;
        }

        public static string GetUrl(string email)
        {
            string url = string.Empty;

            var user = LoadJson().Find(m => m.Email == email);

            string password = user.Password;
            string passwordsalt = user.PasswordSalt;

            string actualpassword = GetPassword(password, passwordsalt);
            string username = user.UserName;
            string ipaddress = user.IPAddressDatabase;

            url = "mongodb://" + username + ":" + actualpassword + "@" + ipaddress;

            return url;
        }

        public static string GetPassword(string password,string passwordsalt)
        {
            string data = string.Empty;
            var crypto = new SimpleCrypto.PBKDF2();
            data = crypto.Compute(password, passwordsalt);
            return data;
        }

    }
}