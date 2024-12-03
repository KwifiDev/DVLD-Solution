using System;
using System.Data;
using System.Data.SqlClient;
using static DVLD_DA.ClsDA_LogManager;
using System.Diagnostics;
using static DVLD_DA.ClsDA_Settings;

namespace DVLD_DA
{
    public class ClsDA_InternationalLicenses
    {
        public static int AddNewInternationalLicense(int applicationID, int driverID, int issuedUsingLocalLicenseID, DateTime issueDate,
                                        DateTime expirationDate, bool isActive, int createdByUserID)
        {
            int licenseID = -1;

            string query = @"Update InternationalLicenses 
                             SET IsActive = 0
                             WHERE DriverID = @DriverID
                             AND IsActive = 1;

                             INSERT INTO InternationalLicenses VALUES
                            (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate,
                            @ExpirationDate, @IsActive, @CreatedByUserID);
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationID;
                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;
                command.Parameters.Add("@IssuedUsingLocalLicenseID", SqlDbType.Int).Value = issuedUsingLocalLicenseID;
                command.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = issueDate;
                command.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value = expirationDate;
                command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = isActive;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;

                try
                {
                    connection.Open();
                    object id = command.ExecuteScalar();
                    if (id != null && int.TryParse(id.ToString(), out int result))
                    {
                        licenseID = result;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }
            }

            return licenseID;
        }

        public static bool UpdateInternationalLicense(int internationalLicenseID, bool isActive)
        {
            bool isUpdated = false;

            string query = @"UPDATE InternationalLicenses SET IsActive = @IsActive 
                            WHERE InternationalLicenseID = @InternationalLicenseID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@InternationalLicenseID", SqlDbType.Int).Value = internationalLicenseID;
                command.Parameters.Add("@IsActive", SqlDbType.Int).Value = isActive;

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

        public static bool GetInternationalLicenseByID(int internationalLicenseID, ref int applicationID, ref int driverID, ref int issuedUsingLocalLicenseID,
                                        ref DateTime issueDate, ref DateTime expirationDate, ref bool isActive, ref int createdByUserID)
        {
            bool isFound = false;

            string query = @"SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@InternationalLicenseID", SqlDbType.Int).Value = internationalLicenseID;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            applicationID = (int)reader["ApplicationID"];
                            driverID = (int)reader["DriverID"];
                            issuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                            issueDate = (DateTime)reader["IssueDate"];
                            expirationDate = (DateTime)reader["ExpirationDate"];
                            isActive = (bool)reader["IsActive"];
                            createdByUserID = (int)reader["CreatedByUserID"];
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

        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dt_InternationalLicenses = new DataTable();

            string query = @"SELECT * FROM InternationalLicenses";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) dt_InternationalLicenses.Load(reader);
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return dt_InternationalLicenses;
            }
        }

        public static bool IsInternationalLicenseExist(int internationalLicenseID)
        {
            bool isExist = false;

            string query = @"SELECT COUNT(1) FROM InternationalLicenses 
                            WHERE InternationalLicenseID = @InternationalLicenseID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@InternationalLicenseID", SqlDbType.Int).Value = internationalLicenseID;

                try
                {
                    connection.Open();

                    isExist = Convert.ToInt32(command.ExecuteScalar()) > 0;

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return isExist;
            }
        }
    }
}
