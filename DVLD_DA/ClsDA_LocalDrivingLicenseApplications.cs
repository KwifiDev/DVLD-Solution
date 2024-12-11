using System;
using System.Data;
using System.Data.SqlClient;
using static DVLD_DA.ClsDA_LogManager;
using System.Diagnostics;
using static DVLD_DA.ClsDA_Settings;
using System.Threading.Tasks;

namespace DVLD_DA
{
    public class ClsDA_LocalDrivingLicenseApplications
    {
        public class Data
        {
            public bool IsFound { get; set; }
            public int LocalDrivingLicenseApplicationID { get; set; }
            public int ApplicationID { get; set; }
            public int LicenseClassID { get; set; }
        }

        public static async Task<int> AddNewLocalDrivingLicenseApplication(int applicationID, int licenseClassID)
        {
            int localDrivingLicenseApplicationID = -1;

            string query = @"INSERT INTO LocalDrivingLicenseApplications VALUES 
                            (@ApplicationID, @LicenseClassID);
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationID;
                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = licenseClassID;


                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    object id = await command.ExecuteScalarAsync().ConfigureAwait(false);
                    if (id != null && int.TryParse(id.ToString(), out int result))
                    {
                        localDrivingLicenseApplicationID = result;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }
            }

            return localDrivingLicenseApplicationID;
        }

        public static async Task<bool> UpdateLocalDrivingLicenseApplication(int localDrivingLicenseApplicationID, int licenseClassID)
        {
            bool isUpdated = false;

            string query = @"UPDATE LocalDrivingLicenseApplications SET
                            LicenseClassID = @LicenseClassID
                            WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;
                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = licenseClassID;

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

        public static async Task<bool> DeleteLocalDrivingLicenseApplication(int localDrivingLicenseApplicationID)
        {
            bool isDeleted = false;

            string query = @"DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    int affectedRows = await command.ExecuteNonQueryAsync().ConfigureAwait(false);

                    isDeleted = (affectedRows > 0);

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return isDeleted;
            }
        }

        public static async Task<bool> DeleteFullApplication(int localDrivingLicenseApplicationID, int applicationID)
        {
            bool isDeleted = false;

            string query = @"DELETE FROM LocalDrivingLicenseApplications 
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;
                             DELETE FROM Applications
                             WHERE ApplicationID = @ApplicationID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationID;
                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    int affectedRows = await command.ExecuteNonQueryAsync().ConfigureAwait(false);

                    isDeleted = (affectedRows > 0);

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return isDeleted;
            }
        }

        public static async Task<Data> GetLocalDrivingLicenseApplicationByID(int localDrivingLicenseApplicationID)
        {
            Data ldlApplication = null;

            string query = @"SELECT * FROM LocalDrivingLicenseApplications 
                            WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.Read())
                        {
                            ldlApplication = new Data
                            {
                                IsFound = true,
                                LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID,
                                ApplicationID = (int)reader["ApplicationID"],
                                LicenseClassID = (int)reader["LicenseClassID"]
                            };
                        }
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return ldlApplication;
            }
        }

        public static async Task<DataTable> GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt_LocalDrivingLicenseApplications = new DataTable();

            string query = @"SELECT * FROM LocalDrivingLicenseApplications";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.HasRows) dt_LocalDrivingLicenseApplications.Load(reader);
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return dt_LocalDrivingLicenseApplications;
            }
        }

        public static async Task<DataTable> GetAllLocalDrivingLicenseApplications_View()
        {
            DataTable dt_LocalDrivingLicenseApplications_View = new DataTable();

            string query = @"SELECT * FROM LocalDrivingLicenseApplications_View";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.HasRows) dt_LocalDrivingLicenseApplications_View.Load(reader);
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return dt_LocalDrivingLicenseApplications_View;
            }
        }

        public static async Task<bool> IsLocalDrivingLicenseApplicationExist(int localDrivingLicenseApplicationID)
        {
            bool isExist = false;

            string query = @"SELECT COUNT(1) FROM LocalDrivingLicenseApplications 
                            WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    isExist = Convert.ToInt32(await command.ExecuteScalarAsync().ConfigureAwait(false)) > 0;

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return isExist;
            }
        }

        public static async Task<int> IsPersonHasLocalDrivingLicenseApplicationWithSameClass(int applicantPersonID, int licenseClassID)
        {
            int applicationID = -1;

            string query = @"SELECT A.ApplicationID
                             FROM Applications A INNER JOIN LocalDrivingLicenseApplications L 
                             ON A.ApplicationID = L.ApplicationID
                             WHERE A.ApplicantPersonID = @ApplicantPersonID
                             AND A.ApplicationTypeID = 1
                             AND A.ApplicationStatus IN (1,3)
                             AND L.LicenseClassID = @LicenseClassID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = applicantPersonID;
                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = licenseClassID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    applicationID = Convert.ToInt32(await command.ExecuteScalarAsync().ConfigureAwait(false));

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return applicationID;
            }
        }

        public static async Task<bool> CancelLDLApplicationByID(int localDrivingLicenseApplicationID)
        {
            bool IsCanceled = false;

            string query = @"UPDATE Applications SET ApplicationStatus = 2 WHERE ApplicationID IN
                            (SELECT L.ApplicationID FROM LocalDrivingLicenseApplications L
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    int affectedRows = await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                    IsCanceled = (affectedRows > 0);

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return IsCanceled;
            }
        }

        public static async Task<int> GetPassedTestsCount(int localDrivingLicenseApplicationID)
        {
            int passedTests = -1;

            string query = @"SELECT COUNT(TA.TestTypeID)
                         FROM Tests T INNER JOIN TestAppointments TA 
                         ON T.TestAppointmentID = TA.TestAppointmentID INNER JOIN LocalDrivingLicenseApplications LDL 
                         ON TA.LocalDrivingLicenseApplicationID = LDL.LocalDrivingLicenseApplicationID
                         WHERE TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                         AND T.TestResult = 1;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    object count = await command.ExecuteScalarAsync().ConfigureAwait(false);
                    if (count != null && int.TryParse(count.ToString(), out int result))
                    {
                        passedTests = result;
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return passedTests;
            }
        }

        public static async Task<Data> GetLocalDrivingLicenseApplicationByLDLApplicationID(int applicationID)
        {
            Data ldlAppliction = null;

            string query = @"SELECT * FROM LocalDrivingLicenseApplications 
                            WHERE ApplicationID = @ApplicationID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.Read())
                        {
                            ldlAppliction = new Data
                            {
                                IsFound = true,
                                LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"],
                                ApplicationID = applicationID,
                                LicenseClassID = (int)reader["LicenseClassID"]
                            };
                        }
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return ldlAppliction;
            }
        }

        public static async Task<int> GetApplicationIDByID(int localDrivingLicenseApplicationID)
        {
            int applicationID = -1;

            string query = @"SELECT ApplicationID FROM LocalDrivingLicenseApplications
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    object count = await command.ExecuteScalarAsync().ConfigureAwait(false);
                    if (count != null && int.TryParse(count.ToString(), out int result))
                    {
                        applicationID = result;
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return applicationID;
            }
        }

        public static async Task<bool> IsPersonPassTest(int localDrivingLicenseApplicationID, int testTypeID)
        {
            bool isPassTest = false;

            string query = @"SELECT COUNT(1) FROM TestAppointments TA INNER JOIN Tests T
                             ON TA.TestAppointmentID = T.TestAppointmentID
                             WHERE TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                             AND TA.TestTypeID = @TestTypeID
                             AND T.TestResult = 1;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;
                command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = testTypeID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    isPassTest = (Convert.ToInt32(await command.ExecuteScalarAsync().ConfigureAwait(false)) > 0);

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return isPassTest;
            }
        }

        public static async Task<string> GetFullNameByLDLApplicationID(int localDrivingLicenseApplicationID)
        {
            string fullName = string.Empty;

            string query = @"SELECT 
                            FullName = (P.FirstName + ' ' + P.SecondName + ' ' + P.ThirdName + ' ' + P.LastName)
                            FROM LocalDrivingLicenseApplications LDA Inner Join Applications A
                            ON LDA.ApplicationID = A.ApplicationID INNER JOIN People P
                            ON A.ApplicantPersonID = P.PersonID
                            WHERE LDA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.Read())
                        {
                            fullName = reader["FullName"] as string;
                        }
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return fullName;
            }
        }

        public static async Task<int> GetPersonIDByLDLApplicationID(int localDrivingLicenseApplicationID)
        {
            int applicantPersonID = -1;

            string query = @"SELECT A.ApplicantPersonID FROM LocalDrivingLicenseApplications LDA Inner Join Applications A
                            ON LDA.ApplicationID = A.ApplicationID
                            WHERE LDA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.Read())
                        {
                            applicantPersonID = (int)reader["ApplicantPersonID"];
                        }
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return applicantPersonID;
            }
        }
    }
}
