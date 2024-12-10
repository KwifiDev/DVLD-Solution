using System;
using System.Data;
using System.Data.SqlClient;
using static DVLD_DA.ClsDA_LogManager;
using System.Diagnostics;
using static DVLD_DA.ClsDA_Settings;
using System.Threading.Tasks;

namespace DVLD_DA
{
    public class ClsDA_InternationalLicenses
    {
        public class Data
        {
            public bool IsFound { get; set; }
            public int ApplicationID { get; set; }
            public int DriverID { get; set; }
            public int IssuedUsingLocalLicenseID { get; set; }
            public DateTime IssueDate { get; set; }
            public DateTime ExpirationDate { get; set; }
            public bool IsActive { get; set; }
            public int CreatedByUserID { get; set; }
        }
        public static async Task<int> AddNewInternationalLicense(int applicationID, int driverID, int issuedUsingLocalLicenseID, DateTime issueDate,
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
                    await connection.OpenAsync().ConfigureAwait(false);
                    object id = await command.ExecuteScalarAsync().ConfigureAwait(false);
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

        public static async Task<bool> UpdateInternationalLicense(int internationalLicenseID, bool isActive)
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

        public static async Task<Data> GetInternationalLicenseByID(int internationalLicenseID)
        {
            Data internationalLicense = null;

            string query = @"SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@InternationalLicenseID", SqlDbType.Int).Value = internationalLicenseID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.Read())
                        {
                            internationalLicense = new Data
                            {
                                IsFound = true,
                                ApplicationID = (int)reader["ApplicationID"],
                                DriverID = (int)reader["DriverID"],
                                IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"],
                                IssueDate = (DateTime)reader["IssueDate"],
                                ExpirationDate = (DateTime)reader["ExpirationDate"],
                                IsActive = (bool)reader["IsActive"],
                                CreatedByUserID = (int)reader["CreatedByUserID"]
                            };
                        }
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return internationalLicense;
            }
        }

        public static async Task<DataTable> GetAllInternationalLicenses()
        {
            DataTable dt_InternationalLicenses = new DataTable();

            string query = @"SELECT * FROM InternationalLicenses";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
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

        public static async Task<bool> IsInternationalLicenseExist(int internationalLicenseID)
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
    }
}
