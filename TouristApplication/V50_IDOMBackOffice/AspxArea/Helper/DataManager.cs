using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdomOffice.Interface.BackOffice.MasterData;
using IdomOffice.Interface.BackOffice.PriceLists;

namespace V50_IDOMBackOffice.AspxArea.Helper
{
    public class DataManager
    {

        public static List<Data> GetPets()
        {
            List<Data> pets = new List<Data>();
            Data pet1 = new Data("0", "nicht erlaubt");
            Data pet2 = new Data("6", "erlaubt bis 6 KG");
            Data pet3 = new Data("30", "erlaubt bis 30 KG");
            Data pet4 = new Data("99", "erlaubt");
            pets.Add(pet1);
            pets.Add(pet2);
            pets.Add(pet3);
            pets.Add(pet4);

            return pets;
        }

        public static List<Data> GetTerraceTypes()
        {
            List<Data> types = new List<Data>();
            Data data1 = new Data("1", "Typ 1");
            Data data2 = new Data("2", "Typ 2");

            types.Add(data1);
            types.Add(data2);

            return types;
        }

        public static List<Data> GetPositions()
        {
            List<Data> positions = new List<Data>();
            Data position1 = new Data("1", "Standort 1");
            Data position2 = new Data("2", "Standort 2");

            positions.Add(position1);
            positions.Add(position2);

            return positions;

        }

        public static List<Data> GetDistances()
        {
            List<Data> distances = new List<Data>();
            Data distance1 = new Data("1", "Lage 1");
            Data distance2 = new Data("2", "Lage 2");

            distances.Add(distance1);
            distances.Add(distance2);

            return distances;
        }

        public static List<Data> GetLanguages()
        {
            List<Data> languages = new List<Data>();
            Data language1 = new Data("1", "deutsch");
            Data language2 = new Data("2", "englisch");

            languages.Add(language1);
            languages.Add(language2);

            return languages;
        }

        public static List<Data> GetRetailPrices()
        {
            List<Data> prices = new List<Data>();
            Data price1 = new Data(Convert.ToInt32(PriceListType.RetailPrice).ToString(), "RetailPriceForEndUser");
            Data price2 = new Data(Convert.ToInt32(PriceListType.WholesalePrices).ToString(), "RetailPriceForPartner");

            prices.Add(price1);
            prices.Add(price2);

            return prices;
        }

        public static List<Data> GetReceiverTypes()
        {
            List<Data> types = new List<Data>();
            Data type1 = new Data("1", "TravelApplicantPayment");
            Data type2 = new Data("2", "ProviderPayment");

            types.Add(type1);
            types.Add(type2);

            return types;
        }

        public static List<Data> GetPaymentTypes()
        {
            List<Data> payments = new List<Data>();
            Data payment1 = new Data("1", "Bank1");
            Data payment2 = new Data("2", "Bank2");
            Data payment3 = new Data("3", "CreditCard");

            payments.Add(payment1);
            payments.Add(payment2);
            payments.Add(payment3);

            return payments;
        }

        public static object GetCheckBoxIndex(string name)
        {
            int index = -1;
            List<int> indexes = new List<int>();

            if (name == "Monday")
                index = 0;
            else if (name == "Tuesday")
                index = 1;
            else if (name == "Wednesday")
                index = 2;
            else if (name == "Thursday")
                index = 3;
            else if (name == "Friday")
                index = 4;
            else if (name == "Saturday")
                index = 5;
            else if (name == "Sunday")
                index = 6;
            else
            {
                indexes.AddRange(new int[] { 0, 1, 2, 3, 4, 5, 6 });
            }

            if (index == -1)
                return indexes;
            else
                return index;

        }
      
    }
}


