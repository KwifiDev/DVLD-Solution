using System;
using System.Data;
using System.Data.SqlClient;
using static DVLD_DA.ClsDA_LogManager;
using System.Diagnostics;
using static DVLD_DA.ClsDA_Settings;

namespace DVLD_DA
{
    public class ClsDA_Licenses
    {
        public static int AddNewLicense(int applicationID, int driverID, int licenseClassID, DateTime issueDate,
                                        DateTime expirationDate, string notes, float paidFees,
                                        bool isActive, byte issueReason, int createdByUserID)
        {
            int licenseID = -1;

            string query = @"INSERT INTO Licenses VALUES 
                            (@ApplicationID, @DriverID, @LicenseClassID, @IssueDate,
                            @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationID;
                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;
                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = licenseClassID;
                command.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = issueDate;
                command.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value = expirationDate;
                command.Parameters.Add("@Notes", SqlDbType.NVarChar, 500).Value = !string.IsNullOrEmpty(notes) ? (object)notes : DBNull.Value;
                command.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = paidFees;
                command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = isActive;
                command.Parameters.Add("@IssueReason", SqlDbType.TinyInt).Value = issueReason;
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

        public static bool UpdateLicense(int licenseID, bool isActive)
        {
            bool isUpdated = false;

            string query = @"UPDATE Licenses SET IsActive = @IsActive WHERE LicenseID = @LicenseID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = licenseID;
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

        public static bool GetLicenseByID(int licenseID, ref int applicationID, ref int driverID, ref int licenseClassID,
                                        ref DateTime issueDate, ref DateTime expirationDate, ref string notes,
                                        ref float paidFees, ref bool isActive, ref byte issueReason, ref int createdByUserID)
        {
            bool isFound = false;

            string query = @"SELECT * FROM Licenses WHERE LicenseID = @LicenseID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = licenseID;

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
                            licenseClassID = (int)reader["LicenseClass"];
                            issueDate = (DateTime)reader["IssueDate"];
                            expirationDate = (DateTime)reader["ExpirationDate"];
                            notes = reader["Notes"] as string;
                            paidFees = Convert.ToSingle(reader["PaidFees"]);
                            isActive = (bool)reader["IsActive"];
                            issueReason = (byte)reader["IssueReason"];
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

        public static DataTable GetAllLicenses()
        {
            DataTable dt_Licenses = new DataTable();

            string query = @"SELECT * FROM Licenses";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) dt_Licenses.Load(reader);
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return dt_Licenses;
            }
        }

        public static bool IsLicenseExist(int licenseID)
        {
            bool isExist = false;

            string query = @"SELECT COUNT(1) FROM Licenses WHERE LicenseID = @LicenseID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = licenseID;

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

        public static bool DeactivateLicenseByID(int licenseID)
        {
            bool isUpdated = false;

            string query = @"UPDATE Licenses SET IsActive = 0 WHERE LicenseID = @LicenseID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = licenseID;

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

        public static int GetPersonIDByID(int licenseID)
        {
            int personID = -1;

            string query = @"SELECT D.PersonID FROM Licenses L INNER JOIN Drivers D
                             ON L.DriverID = D.DriverID
                             WHERE L.LicenseID = @LicenseID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = licenseID;

                try
                {
                    connection.Open();
                    object id = command.ExecuteScalar();
                    if (id != null && int.TryParse(id.ToString(), out int result))
                    {
                        personID = result;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }
            }

            return personID;
        }

        public static int GetActiveLicenseIDByPersonIDAndLicenseClassID(int applicantPersonID, int licenseClassID)
        {
            int licenseID = -1;

            string query = @"SELECT L.LicenseID FROM Licenses L INNER JOIN Applications A
                             ON L.ApplicationID = A.ApplicationID
                             WHERE A.ApplicantPersonID = @ApplicantPersonID
                             AND L.LicenseClass = @LicenseClass
                             AND L.IsActive = 1;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = applicantPersonID;
                command.Parameters.Add("@LicenseClass", SqlDbType.Int).Value = licenseClassID;

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

        public static bool IsPersonHaveActiveLicenseInSpecificClass(int personID, int licenseClassID)
        {
            bool isExist = false;

            string query = @"SELECT COUNT(*) FROM Licenses L INNER JOIN Drivers D
                            ON L.DriverID = D.DriverID INNER JOIN People P
                            ON P.PersonID = D.PersonID
                            WHERE L.LicenseClass = @LicenseClassID 
                            AND P.PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = personID;
                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = licenseClassID;


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
