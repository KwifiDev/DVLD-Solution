using System;
using System.Data;
using System.Data.SqlClient;
using static DVLD_DA.ClsDA_LogManager;
using System.Diagnostics;
using static DVLD_DA.ClsDA_Settings;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DVLD_DA
{
    public class ClsDA_DetainedLicenses
    {
        public class Data
        {
            public bool IsFound { get; set; }
            public int DetainID { get; set; }
            public int LicenseID { get; set; }
            public DateTime DetainDate { get; set; }
            public float FineFees { get; set; }
            public int CreatedByUserID { get; set; }
            public bool IsReleased { get; set; }
            public DateTime? ReleaseDate { get; set; }
            public int? ReleasedByUserID { get; set; }
            public int? ReleaseApplicationID { get; set; }
        }

        public static async Task<int> AddNewDetainedLicense(int licenseID, DateTime detainDate, float fineFees, int createdByUserID)
        {
            int detainID = -1;

            string query = @"INSERT INTO DetainedLicenses (LicenseID, DetainDate, FineFees, CreatedByUserID)
                            VALUES (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID);
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = licenseID;
                command.Parameters.Add("@DetainDate", SqlDbType.SmallDateTime).Value = detainDate;
                command.Parameters.Add("@FineFees", SqlDbType.SmallMoney).Value = fineFees;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    object id = await command.ExecuteScalarAsync().ConfigureAwait(false);
                    if (id != null && int.TryParse(id.ToString(), out int result))
                    {
                        detainID = result;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }
            }

            return detainID;
        }

        public static async Task<bool> UpdateDetainedLicense(int detainID, bool isReleased, DateTime? releaseDate,
                                                 int? releasedByUserID, int? releaseApplicationID)
        {
            bool isUpdated = false;

            string query = @"UPDATE DetainedLicenses 
                            SET IsReleased = @IsReleased,
                                ReleaseDate = @ReleaseDate,
                                ReleasedByUserID = @ReleasedByUserID,
                                ReleaseApplicationID = @ReleaseApplicationID
                                WHERE DetainID = @DetainID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@DetainID", SqlDbType.Int).Value = detainID;
                command.Parameters.Add("@IsReleased", SqlDbType.Bit).Value = isReleased;
                command.Parameters.Add("@ReleaseDate", SqlDbType.SmallDateTime).Value = releaseDate;
                command.Parameters.Add("@ReleasedByUserID", SqlDbType.Int).Value = releasedByUserID;
                command.Parameters.Add("@ReleaseApplicationID", SqlDbType.Int).Value = releaseApplicationID;

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

        public static async Task<Data> GetDetainedLicenseByID(int detainID)
        {
            Data detainedLicense = null;

            string query = @"SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@DetainID", SqlDbType.Int).Value = detainID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.Read())
                        {
                            detainedLicense = new Data
                            {
                                IsFound = true,
                                DetainID = detainID,
                                LicenseID = (int)reader["LicenseID"],
                                DetainDate = (DateTime)reader["DetainDate"],
                                FineFees = Convert.ToSingle(reader["FineFees"]),
                                CreatedByUserID = (int)reader["CreatedByUserID"],
                                IsReleased = (bool)reader["IsReleased"],
                                ReleaseDate = reader["ReleaseDate"] != DBNull.Value ? (DateTime?)reader["ReleaseDate"] : null,
                                ReleasedByUserID = reader["ReleasedByUserID"] != DBNull.Value ? (int?)reader["ReleasedByUserID"] : null,
                                ReleaseApplicationID = reader["ReleaseApplicationID"] != DBNull.Value ? (int?)reader["ReleaseApplicationID"] : null
                            };

                        }
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return detainedLicense;
            }
        }

        public static async Task<Data> GetDetainedLicenseByLicenseID(int licenseID)
        {
            Data detainedLicense = null;

            string query = @"SELECT * FROM DetainedLicenses WHERE LicenseID = @LicenseID AND IsReleased = 0";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = licenseID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.Read())
                        {
                            detainedLicense = new Data
                            {
                                IsFound = true,
                                LicenseID = licenseID,
                                DetainID = (int)reader["DetainID"],
                                DetainDate = (DateTime)reader["DetainDate"],
                                FineFees = Convert.ToSingle(reader["FineFees"]),
                                CreatedByUserID = (int)reader["CreatedByUserID"],
                                IsReleased = (bool)reader["IsReleased"],
                                ReleaseDate = reader["ReleaseDate"] != DBNull.Value ? (DateTime?)reader["ReleaseDate"] : null,
                                ReleasedByUserID = reader["ReleasedByUserID"] != DBNull.Value ? (int?)reader["ReleasedByUserID"] : null,
                                ReleaseApplicationID = reader["ReleaseApplicationID"] != DBNull.Value ? (int?)reader["ReleaseApplicationID"] : null
                            };
                        }
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return detainedLicense;
            }
        }

        public static async Task<DataTable> GetAllDetainedLicenses()
        {
            DataTable dt_DetainedLicenses = new DataTable();

            string query = @"SELECT * FROM DetainedLicenses";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.HasRows) dt_DetainedLicenses.Load(reader);
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return dt_DetainedLicenses;
            }
        }

        public static async Task<DataTable> GetAllDetainedLicenses_View()
        {
            DataTable dt_DetainedLicenses_View = new DataTable();

            string query = @"SELECT * FROM DetainedLicenses_View";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.HasRows) dt_DetainedLicenses_View.Load(reader);
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return dt_DetainedLicenses_View;
            }
        }

        public static async Task<bool> IsDetainedLicenseExist(int detainID)
        {
            bool isExist = false;

            string query = @"SELECT COUNT(1) FROM DetainedLicenses WHERE DetainID = @DetainID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@DetainID", SqlDbType.Int).Value = detainID;

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

        public static async Task<bool> IsDetained(int licenseID)
        {
            bool isDetained = false;

            string query = @"SELECT COUNT(*) FROM DetainedLicenses
                             WHERE LicenseID = @LicenseID AND IsReleased = 0;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LicenseID", SqlDbType.Int).Value = licenseID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    isDetained = Convert.ToInt32(await command.ExecuteScalarAsync().ConfigureAwait(false)) > 0;

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return isDetained;
            }
        }

        public static async Task<bool> ReleaseDetainedLicense(int detainID,
                 int? releasedByUserID, int? releaseApplicationID)
        {
            bool isReleased = false;

            string query = @"UPDATE DetainedLicenses
                            SET IsReleased = 1,
                            ReleaseDate = @ReleaseDate,
                            ReleasedByUserID = @ReleasedByUserID,
                            ReleaseApplicationID = @ReleaseApplicationID
                            WHERE DetainID = @DetainID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@DetainID", SqlDbType.Int).Value = detainID;
                command.Parameters.Add("@ReleaseDate", SqlDbType.SmallDateTime).Value = DateTime.Now;
                command.Parameters.Add("@ReleasedByUserID", SqlDbType.Int).Value = releasedByUserID;
                command.Parameters.Add("@ReleaseApplicationID", SqlDbType.Int).Value = releaseApplicationID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    int affectedRows = await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                    isReleased = (affectedRows > 0);
                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return isReleased;
            }
        }
    }
}
