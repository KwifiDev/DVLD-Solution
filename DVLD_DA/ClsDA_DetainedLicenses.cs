using System;
using System.Data;
using System.Data.SqlClient;
using static DVLD_DA.ClsDA_LogManager;
using System.Diagnostics;
using static DVLD_DA.ClsDA_Settings;

namespace DVLD_DA
{
    public class ClsDA_DetainedLicenses
    {
        public static int AddNewDetainedLicense(int licenseID, DateTime detainDate, float fineFees, int createdByUserID)
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
                    connection.Open();
                    object id = command.ExecuteScalar();
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

        public static bool UpdateDetainedLicense(int detainID, bool isReleased, DateTime? releaseDate,
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

        public static bool GetDetainedLicenseByID(int detainID, ref int licenseID, ref DateTime detainDate,
                                                  ref float fineFees, ref int createdByUserID,
                                                  ref bool isReleased, ref DateTime? releaseDate,
                                                  ref int? releasedByUserID, ref int? releaseApplicationID)
        {
            bool isFound = false;

            string query = @"SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@DetainID", SqlDbType.Int).Value = detainID;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            licenseID = (int)reader["LicenseID"];
                            detainDate = (DateTime)reader["DetainDate"];
                            fineFees = Convert.ToSingle(reader["FineFees"]);
                            createdByUserID = (int)reader["CreatedByUserID"];
                            isReleased = (bool)reader["IsReleased"];
                            releaseDate = (DateTime)reader["ReleaseDate"];
                            releasedByUserID = (int)reader["ReleasedByUserID"];
                            releaseApplicationID = (int)reader["ReleaseApplicationID"];
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
        public static bool GetDetainedLicenseByLicenseID(ref int detainID, int licenseID, ref DateTime detainDate,
                                                        ref float fineFees, ref int createdByUserID,
                                                        ref bool isReleased, ref DateTime? releaseDate,
                                                        ref int? releasedByUserID, ref int? releaseApplicationID)
        {
            bool isFound = false;

            string query = @"SELECT * FROM DetainedLicenses WHERE LicenseID = @LicenseID AND IsReleased = 0";

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
                            detainID = (int)reader["DetainID"];
                            detainDate = (DateTime)reader["DetainDate"];
                            fineFees = Convert.ToSingle(reader["FineFees"]);
                            createdByUserID = (int)reader["CreatedByUserID"];
                            isReleased = (bool)reader["IsReleased"];
                            releaseDate = (DateTime)reader["ReleaseDate"];
                            releasedByUserID = (int)reader["ReleasedByUserID"];
                            releaseApplicationID = (int)reader["ReleaseApplicationID"];
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
        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt_DetainedLicenses = new DataTable();

            string query = @"SELECT * FROM DetainedLicenses";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
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

        public static DataTable GetAllDetainedLicenses_View()
        {
            DataTable dt_DetainedLicenses_View = new DataTable();

            string query = @"SELECT * FROM DetainedLicenses_View";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
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

        public static bool IsDetainedLicenseExist(int detainID)
        {
            bool isExist = false;

            string query = @"SELECT COUNT(1) FROM DetainedLicenses WHERE DetainID = @DetainID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@DetainID", SqlDbType.Int).Value = detainID;

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

        public static bool IsDetained(int licenseID)
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
                    connection.Open();

                    isDetained = Convert.ToInt32(command.ExecuteScalar()) > 0;

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return isDetained;
            }
        }

        public static bool ReleaseDetainedLicense(int detainID,
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
                    connection.Open();
                    int affectedRows = command.ExecuteNonQuery();
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
