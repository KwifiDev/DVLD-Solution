using System;
using System.Data;
using System.Data.SqlClient;
using static DVLD_DA.ClsDA_LogManager;
using System.Diagnostics;
using static DVLD_DA.ClsDA_Settings;
using System.Threading.Tasks;

namespace DVLD_DA
{
    public static class ClsDA_Countries
    {
        public class Data
        {
            public bool IsFound { get; set; }
            public int CountryID { get; set; }
            public string CountryName { get; set; }
        }

        public static async Task<Data> GetCountryByID(int countryID)
        {
            Data data = null;

            string query = @"SELECT * FROM Countries WHERE CountryID = @CountryID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@CountryID", SqlDbType.Int).Value = countryID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.Read())
                        {
                            data = new Data
                            {
                                IsFound = true,
                                CountryID = countryID,
                                CountryName = reader["CountryName"] as string
                            };
                        }
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return data;
            }
        }

        public static async Task<DataTable> GetAllCountries()
        {
            DataTable dt_Countries = new DataTable();

            string query = @"SELECT * FROM Countries";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.HasRows) dt_Countries.Load(reader);
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return dt_Countries;
            }
        }
    }
}
