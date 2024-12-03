using DVLD_DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLD_BL
{
    public class ClsBL_Country
    {
        public int CountryID { get; }
        public string CountryName { get; }


        private ClsBL_Country(int countryID, string countryName)
        {
            CountryID = countryID;
            CountryName = countryName;
        }

        public static async Task<ClsBL_Country> Find(int countryID)
        {
            ClsDA_Countries.Data data = await ClsDA_Countries.GetCountryByID(countryID);

            if (data.IsFound)
            {
                return new ClsBL_Country(data.CountryID, data.CountryName);
            }
            else return null;
        }

        public static DataTable Load()
        {
            return ClsDA_Countries.GetAllCountries();
        }


    }
}
