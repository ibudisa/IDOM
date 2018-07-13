using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using FileHelpers.DataLink;

namespace BLL
{
    public class FileData
    {
      private static  DataManager dataManager = new DataManager();

        public static void GetRecords(string filename)
        {
            //    ExcelNPOIStorage storage = new ExcelNPOIStorage(typeof(CustomerModel), 1, 0);

            //    // Set storage file name -> represents the excel file name we want to read
            //    storage.FileName = filename;

            //    // Read from excel file
            //    CustomerModel[] customers = storage.ExtractRecords() as CustomerModel[];


            var provider = new ExcelStorage(typeof(CustomerModel), filename, 2, 1);
            CustomerModel[] customers = provider.ExtractRecords() as CustomerModel[];

            foreach (var c in customers)
            {
                string email = c.EMail != null ? c.EMail.Trim() : "";
                bool exists = CheckCustomer(email);
                if (!exists)
                {
                    Customer data = MapData(c);
                    dataManager.AddMasterData(data);
                }
                else
                {
                    Customer customer = dataManager.GetCustomerByEmail(email);
                    Customer customerupdated = UpdateValues(c, customer);
                    dataManager.UpdateMasterData(customerupdated);
                }
            }
            
        }

        private static bool CheckCustomer(string email)
        {
            bool b = false;
            DataManager manager = new DataManager();
            Customer cust = manager.GetCustomerByEmail(email);
            if(cust!=null)
            {
                b = true;
            }

            return b;

        }

        private static Customer MapData(CustomerModel model)
        {
            DataManager manager = new DataManager();
            int customernr = manager.GetMaxCustomerNr();

            List<int> list = new List<int>();
            list.Add(model.CustomerNr);
            Customer customer = new Customer();
            customer.Adress = model.Adress != null ? model.Adress.Trim() : "";
            customer.BookKeepingNumber = list;
            customer.Contry = model.Contry != null ? model.Contry.Trim() : "";
            customer.CustomerNr = customernr;
            customer.EMail = model.EMail != null ? model.EMail.Trim() : "";
            customer.FirstName = model.FirstName != null ? model.FirstName.Trim() : "";
            customer.Salutation = model.Salutation != null ? model.Salutation.Trim() : "";
            customer.LastName = model.LastName != null ? model.LastName.Trim() : "";
            customer.MobilePhone = model.MobilePhone != null ? model.MobilePhone.Trim() : "";
            customer.Phone = model.Phone != null ? model.Phone.Trim() : "";
            customer.Place = model.Place != null ? model.Place.Trim() : "";
            customer.ZipCode = model.ZipCode != null ? model.ZipCode.Trim() : "";

            return customer;
        }

        private static Customer UpdateValues(CustomerModel cm,Customer cust)
        {
            List<int> list = new List<int>();
            list = cust.BookKeepingNumber;
            int number = cm.CustomerNr;
            if (!list.Contains(number))
            {
                list.Add(cm.CustomerNr);
            }
            Customer customer = new Customer();
            customer = cust;
            customer.BookKeepingNumber = list;

            return customer;
        }
    }
}
