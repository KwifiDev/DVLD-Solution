using System;
using System.Data;
using System.Data.SqlClient;
using static DVLD_DA.ClsDA_LogManager;
using System.Diagnostics;
using static DVLD_DA.ClsDA_Settings;
using System.Threading.Tasks;

namespace DVLD_DA
{
    public class ClsDA_TestTypes
    {
        public class Data
        {
            public bool IsFound { get; set; }
            public int TestTypeID { get; set; }
            public string TestTypeTitle { get; set; }
            public string TestTypeDescription { get; set; }
            public float TestTypeFees { get; set; }
        }

        public static async Task<Data> GetTestTypeByID(int testTypeID)
        {
            Data testType = null;

            string query = @"SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = testTypeID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.Read())
                        {
                            testType = new Data
                            {
                                IsFound = true,
                                TestTypeID = testTypeID,
                                TestTypeTitle = reader["TestTypeTitle"] as string,
                                TestTypeDescription = reader["TestTypeDescription"] as string,
                                TestTypeFees = Convert.ToSingle(reader["TestTypeFees"])
                            };
                        }
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return testType;
            }
        }

        public static async Task<bool> UpdateTestType(int testTypeID, string testTypeTitle, string testTypeDescription, float testTypeFees)
        {
            bool isUpdated = false;

            string query = @"UPDATE TestTypes SET
                            TestTypeTitle = @TestTypeTitle,
                            TestTypeDescription = @TestTypeDescription,
                            TestTypeFees = @TestTypeFees
                            WHERE TestTypeID = @TestTypeID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = testTypeID;
                command.Parameters.Add("@TestTypeTitle", SqlDbType.NVarChar, 100).Value = testTypeTitle;
                command.Parameters.Add("@TestTypeDescription", SqlDbType.NVarChar, 500).Value = testTypeDescription;
                command.Parameters.Add("@TestTypeFees", SqlDbType.SmallMoney).Value = testTypeFees;


                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    int affectedRows = await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                    isUpdated = (affectedRows > 0);
                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return isUpdated;
            }
        }

        public static async Task<DataTable> GetAllTestTypes()
        {
            DataTable dt_TestTypes = new DataTable();

            string query = @"SELECT TestTypeID, TestTypeTitle, TestTypeFees FROM TestTypes";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.HasRows) dt_TestTypes.Load(reader);
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return dt_TestTypes;
            }
        }

        public static async Task<float> GetTestFees(int testTypeID)
        {
            float paidFees = 0;

            string query = @"SELECT TestTypeFees FROM TestTypes
                             WHERE TestTypeID = @TestTypeID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = testTypeID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    object fees = await command.ExecuteScalarAsync().ConfigureAwait(false);
                    if (fees != null && float.TryParse(fees.ToString(), out float result))
                    {
                        paidFees = result;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return paidFees;
            }
        }
    }
}
