using DVLD.DataAccess;
using System;
using System.Data;


namespace DVLD.Business
{
    public class Country
    {
        public int CountryID { get; set; }

        public string CountryName { get; set; }

        public Country()
        {
            CountryID = -1;
            CountryName = string.Empty;
        }


        public Country(int countryID, string countryName)
        {
            CountryID = countryID;
            CountryName = countryName;
        }

        public static Country Find(int CountryID)
        {
            string CountryName = string.Empty;

            if (CountryData.GetCountryInfoByID(CountryID, ref CountryName))
                return new Country(CountryID, CountryName);

            return null;
        }

        public static Country Find(string CountryName)
        {
            int CountryID = -1;

            if (CountryData.GetCountryInfoByName(CountryName, ref CountryID))
                return new Country(CountryID, CountryName);

            return null;
        }

        public static DataTable GetAllCountries()
        {
            return CountryData.GetAllCountries();

        }
    }
}
