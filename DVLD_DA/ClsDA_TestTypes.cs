using System;
using System.Data;
using System.Data.SqlClient;
using static DVLD_DA.ClsDA_LogManager;
using System.Diagnostics;
using static DVLD_DA.ClsDA_Settings;

namespace DVLD_DA
{
    public class ClsDA_TestTypes
    {

        public static bool GetTestTypeByID(int testTypeID, ref string testTypeTitle, ref string testTypeDescription, ref float testTypeFees)
        {
            bool isFound = false;

            string query = @"SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = testTypeID;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            testTypeTitle = reader["TestTypeTitle"] as string;
                            testTypeDescription = reader["TestTypeDescription"] as string;
                            testTypeFees = Convert.ToSingle(reader["TestTypeFees"]);
                        }
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return isFound;
            }
        }

        public static bool UpdateTestType(int testTypeID, string testTypeTitle, string testTypeDescription, float testTypeFees)
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
                    connection.Open();
                    int affectedRows = command.ExecuteNonQuery();
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

        public static DataTable GetAllTestTypes()
        {
            DataTable dt_TestTypes = new DataTable();

            string query = @"SELECT TestTypeID, TestTypeTitle, TestTypeFees FROM TestTypes";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
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

        public static float GetTestFees(int testTypeID)
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
                    connection.Open();
                    object fees = command.ExecuteScalar();
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
