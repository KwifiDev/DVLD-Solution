using System;
using System.Data;
using System.Data.SqlClient;
using static DVLD_DA.ClsDA_LogManager;
using System.Diagnostics;
using static DVLD_DA.ClsDA_Settings;

namespace DVLD_DA
{
    public class ClsDA_LocalDrivingLicenseApplications
    {
        public static int AddNewLocalDrivingLicenseApplication(int applicationID, int licenseClassID)
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
                    connection.Open();
                    object id = command.ExecuteScalar();
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

        public static bool UpdateLocalDrivingLicenseApplication(int localDrivingLicenseApplicationID, int licenseClassID)
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

        public static bool DeleteLocalDrivingLicenseApplication(int localDrivingLicenseApplicationID)
        {
            bool isDeleted = false;

            string query = @"DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;

                try
                {
                    connection.Open();

                    int affectedRows = command.ExecuteNonQuery();

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

        public static bool DeleteFullApplication(int localDrivingLicenseApplicationID, int applicationID)
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
                    connection.Open();

                    int affectedRows = command.ExecuteNonQuery();

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

        public static bool GetLocalDrivingLicenseApplicationByID(int localDrivingLicenseApplicationID, ref int applicationID, ref int licenseClassID)
        {
            bool isFound = false;

            string query = @"SELECT * FROM LocalDrivingLicenseApplications 
                            WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            applicationID = (int)reader["ApplicationID"];
                            licenseClassID = (int)reader["LicenseClassID"];
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

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt_LocalDrivingLicenseApplications = new DataTable();

            string query = @"SELECT * FROM LocalDrivingLicenseApplications";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
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

        public static DataTable GetAllLocalDrivingLicenseApplications_View()
        {
            DataTable dt_LocalDrivingLicenseApplications_View = new DataTable();

            string query = @"SELECT * FROM LocalDrivingLicenseApplications_View";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
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

        public static bool IsLocalDrivingLicenseApplicationExist(int localDrivingLicenseApplicationID)
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

        public static int IsPersonHasLocalDrivingLicenseApplicationWithSameClass(int applicantPersonID, int licenseClassID)
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
                    connection.Open();

                    applicationID = Convert.ToInt32(command.ExecuteScalar());

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return applicationID;
            }
        }

        public static bool CancelLDLApplicationByID(int localDrivingLicenseApplicationID)
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
                    connection.Open();
                    int affectedRows = command.ExecuteNonQuery();
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

        public static int GetPassedTestsCount(int localDrivingLicenseApplicationID)
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
                    connection.Open();

                    object count = command.ExecuteScalar();
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

        public static bool GetLocalDrivingLicenseApplicationByLDLApplicationID(ref int localDrivingLicenseApplicationID, int applicationID, ref int licenseClassID)
        {
            bool isFound = false;

            string query = @"SELECT * FROM LocalDrivingLicenseApplications 
                            WHERE ApplicationID = @ApplicationID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationID;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            localDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                            licenseClassID = (int)reader["LicenseClassID"];
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

        public static int GetApplicationIDByID(int localDrivingLicenseApplicationID)
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
                    connection.Open();

                    object count = command.ExecuteScalar();
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

        public static bool IsPersonPassTest(int localDrivingLicenseApplicationID, int testTypeID)
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
                    connection.Open();

                    isPassTest = (Convert.ToInt32(command.ExecuteScalar()) > 0);

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return isPassTest;
            }
        }

        public static string GetFullNameByLDLApplicationID(int localDrivingLicenseApplicationID)
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
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
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

        public static int GetPersonIDByLDLApplicationID(int localDrivingLicenseApplicationID)
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
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
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
