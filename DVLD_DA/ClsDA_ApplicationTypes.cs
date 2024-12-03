using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using static DVLD_DA.ClsDA_LogManager;
using static DVLD_DA.ClsDA_Settings;

namespace DVLD_DA
{
    public class ClsDA_ApplicationTypes
    {
        public static bool GetApplicationTypeByID(int applicationTypeID, ref string applicationTypeTitle, ref float applicationFees)
        {
            bool isFound = false;

            string query = @"SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = applicationTypeID;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            applicationTypeTitle = reader["ApplicationTypeTitle"] as string;
                            applicationFees = Convert.ToSingle(reader["ApplicationFees"]);
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

        public static bool UpdateApplicationType(int applicationTypeID, string applicationTypeTitle, float applicationFees)
        {
            bool isUpdated = false;

            string query = @"UPDATE ApplicationTypes SET
                            ApplicationTypeTitle = @ApplicationTypeTitle,
                            ApplicationFees = @ApplicationFees
                            WHERE ApplicationTypeID = @ApplicationTypeID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = applicationTypeID;
                command.Parameters.Add("@ApplicationTypeTitle", SqlDbType.NVarChar, 150).Value = applicationTypeTitle;
                command.Parameters.Add("@ApplicationFees", SqlDbType.SmallMoney).Value = applicationFees;


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

        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt_ApplicationTypes = new DataTable();

            string query = @"SELECT * FROM ApplicationTypes";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) dt_ApplicationTypes.Load(reader);
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return dt_ApplicationTypes;
            }
        }

        public static float GetApplcationFeesByID(int applicationTypeID)
        {
            float applicationfees = 0;

            string query = @"SELECT ApplicationFees FROM ApplicationTypes
                            WHERE ApplicationTypeID = @ApplicationTypeID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = applicationTypeID;

                try
                {
                    connection.Open();
                    object id = command.ExecuteScalar();
                    if (id != null && float.TryParse(id.ToString(), out float result))
                    {
                        applicationfees = result;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }
            }

            return applicationfees;
        }
    }
}
