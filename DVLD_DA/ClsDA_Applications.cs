using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using static DVLD_DA.ClsDA_LogManager;
using static DVLD_DA.ClsDA_Settings;

namespace DVLD_DA
{
    public static class ClsDA_Applications
    {
        public class Data
        {
            public bool IsFound {  get; set; }
            public int ApplicationID { get; set; }
            public int ApplicantPersonID { get; set; }
            public DateTime ApplicationDate { get; set; }
            public int ApplicationTypeID { get; set; }
            public byte ApplicationStatus { get; set; }
            public DateTime LastStatusDate { get; set; }
            public float PaidFees { get; set; }
            public int CreatedByUserID { get; set; }
        }
        public static async Task<int> AddNewApplication(int applicantPersonID, DateTime applicationDate, int applicationTypeID, byte applicationStatus,
                                            DateTime lastStatusDate, float paidFees, int createdByUserID)
        {
            int applicationID = -1;

            string query = @"INSERT INTO Applications VALUES 
                            (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus,
                            @LastStatusDate, @PaidFees, @CreatedByUserID);
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = applicantPersonID;
                command.Parameters.Add("@ApplicationDate", SqlDbType.DateTime).Value = applicationDate;
                command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = applicationTypeID;
                command.Parameters.Add("@ApplicationStatus", SqlDbType.TinyInt).Value = applicationStatus;
                command.Parameters.Add("@LastStatusDate", SqlDbType.DateTime).Value = lastStatusDate;
                command.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = paidFees;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;


                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    object id = await command.ExecuteScalarAsync().ConfigureAwait(false);
                    if (id != null && int.TryParse(id.ToString(), out int result))
                    {
                        applicationID = result;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }
            }

            return applicationID;
        }

        public static async Task<bool> UpdateApplicationStatus(int applicationID, byte applicationStatus)
        {
            bool isUpdated = false;

            string query = @"UPDATE Applications SET
                            ApplicationStatus = @ApplicationStatus,
                            LastStatusDate = @LastStatusDate
                            WHERE ApplicationID = @ApplicationID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationID;
                command.Parameters.Add("@ApplicationStatus", SqlDbType.TinyInt).Value = applicationStatus;
                command.Parameters.Add("@LastStatusDate", SqlDbType.DateTime).Value = DateTime.Now;

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

        public static async Task<bool> DeleteApplication(int applicationID)
        {
            bool isDeleted = false;

            string query = @"DELETE FROM Applications WHERE ApplicationID = @ApplicationID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationID;

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

        public static async Task<Data> GetApplicationByID(int applicationID)
        {
            Data application = null;

            string query = @"SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";

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
                            application = new Data
                            {
                                IsFound = true,
                                ApplicantPersonID = (int)reader["ApplicantPersonID"],
                                ApplicationDate = (DateTime)reader["ApplicationDate"],
                                ApplicationTypeID = (int)reader["ApplicationTypeID"],
                                ApplicationStatus = (byte)reader["ApplicationStatus"],
                                LastStatusDate = (DateTime)reader["LastStatusDate"],
                                PaidFees = Convert.ToSingle(reader["PaidFees"]),
                                CreatedByUserID = (int)reader["CreatedByUserID"],
                            };
                        }
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return application;
            }
        }

        public static async Task<DataTable> GetAllApplications()
        {
            DataTable dt_Applications = new DataTable();

            string query = @"SELECT * FROM Applications";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.HasRows) dt_Applications.Load(reader);
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return dt_Applications;
            }
        }

        public static async Task<bool> IsApplicationExist(int applicationID)
        {
            bool isExist = false;

            string query = @"SELECT COUNT(1) FROM Applications WHERE ApplicationID = @ApplicationID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationID;

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

        public static async Task<bool> DoesPersonHaveActiveApplication(int applicantPersonID, int ApplicationTypeID)
        {
            //incase the ActiveApplication ID !=-1 return true.
            return (await GetActiveApplicationID(applicantPersonID, ApplicationTypeID) != -1);
        }

        public static async Task<int> GetActiveApplicationID(int applicantPersonID, int applicationTypeID)
        {
            int applicationID = -1;

            string query = @"SELECT ApplicationID FROM Applications
                             WHERE ApplicantPersonID = @ApplicantPersonID
                             AND ApplicationTypeID = @ApplicationTypeID
                             AND ApplicationStatus = 1;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = applicantPersonID;
                command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = applicationTypeID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    object id = await command.ExecuteScalarAsync().ConfigureAwait(false);
                    if (id != null && int.TryParse(id.ToString(), out int result))
                    {
                        applicationID = result;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }
            }

            return applicationID;
        }

        public static async Task<int> GetActiveApplicationIDForLicenseClass(int applicantPersonID, int applicationTypeID, int licenseClassID)
        {
            int applicationID = -1;

            string query = @"SELECT A.ApplicationID FROM Applications A INNER JOIN LocalDrivingLicenseApplications LDLA
                             ON A.ApplicationID = LDLA.ApplicationID
                             WHERE A.ApplicantPersonID = @ApplicantPersonID 
                             AND A.ApplicationTypeID= @ApplicationTypeID 
                             AND LDLA.LicenseClassID = @LicenseClassID
                             AND ApplicationStatus = 1;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicantPersonID", SqlDbType.Int).Value = applicantPersonID;
                command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = applicationTypeID;
                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = licenseClassID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    object id = await command.ExecuteScalarAsync().ConfigureAwait(false);
                    if (id != null && int.TryParse(id.ToString(), out int result))
                    {
                        applicationID = result;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }
            }

            return applicationID;
        }
    }
}
