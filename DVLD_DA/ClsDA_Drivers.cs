using System;
using System.Data;
using System.Data.SqlClient;
using static DVLD_DA.ClsDA_LogManager;
using System.Diagnostics;
using static DVLD_DA.ClsDA_Settings;
using System.Threading.Tasks;

namespace DVLD_DA
{
    public static class ClsDA_Drivers
    {
        public class Data
        {
            public bool IsFound { get; set; }
            public int DriverID { get; set; }
            public int PersonID { get; set; }
            public int CreatedByUserID { get; set; }
            public DateTime CreatedDate { get; set; }

        }
        public static async Task<int> AddNewDriver(int personID, int createdByUserID, DateTime createdDate)
        {
            int driverID = -1;

            string query = @"INSERT INTO Drivers VALUES 
                            (@PersonID, @CreatedByUserID, @CreatedDate);
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = personID;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;
                command.Parameters.Add("@CreatedDate", SqlDbType.SmallDateTime).Value = createdDate;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    object id = await command.ExecuteScalarAsync().ConfigureAwait(false);
                    if (id != null && int.TryParse(id.ToString(), out int result))
                    {
                        driverID = result;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }
            }

            return driverID;
        }

        public static async Task<bool> DeleteDriver(int driverID)
        {
            bool isDeleted = false;

            string query = @"DELETE FROM Drivers WHERE DriverID = @DriverID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;

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

        public static async Task<Data> GetDriverByID(int driverID)
        {
            Data driver = null;

            string query = @"SELECT * FROM Drivers WHERE DriverID = @DriverID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.Read())
                        {
                            driver = new Data
                            {
                                IsFound = true,
                                PersonID = (int)reader["PersonID"],
                                CreatedByUserID = (int)reader["CreatedByUserID"],
                                CreatedDate = (DateTime)reader["CreatedDate"]
                            };
                        }
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return driver;
            }
        }
        
        public static async Task<Data> GetDriverByPersonID(int personID)
        {
            Data driver = null;

            string query = @"SELECT * FROM Drivers WHERE PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = personID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.Read())
                        {
                            driver = new Data 
                            {
                                IsFound = true,
                                DriverID = (int)reader["DriverID"],
                                CreatedByUserID = (int)reader["CreatedByUserID"],
                                CreatedDate = (DateTime)reader["CreatedDate"]
                            };
                        }
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return driver;
            }
        }

        public static async Task<DataTable> GetAllDrivers()
        {
            DataTable dt_Drivers = new DataTable();

            string query = @"SELECT * FROM Drivers";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.HasRows) dt_Drivers.Load(reader);
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return dt_Drivers;
            }
        }
        
        public static async Task<DataTable> GetAllDrivers_View()
        {
            DataTable dt_DriversView = new DataTable();

            string query = @"SELECT * FROM Drivers_View";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.HasRows) dt_DriversView.Load(reader);
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return dt_DriversView;
            }
        }

        public static async Task<bool> IsDriverExist(int driverID)
        {
            bool isExist = false;

            string query = @"SELECT COUNT(1) FROM People WHERE DriverID = @DriverID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;

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

        public static async Task<bool> IsDriverExistByPersonID(int personID)
        {
            bool isExist = false;

            string query = @"SELECT COUNT(1) FROM Drivers WHERE PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = personID;

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

        public static async Task<int> GetActiveInternationalLicenseIDByID(int driverID)
        {
            int internationalLicenseID = -1;

            string query = @"SELECT IL.InternationalLicenseID FROM Drivers D INNER JOIN InternationalLicenses IL
                             ON D.DriverID = IL.DriverID WHERE D.DriverID = @DriverID AND IL.IsActive = 1;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    internationalLicenseID = Convert.ToInt32(await command.ExecuteScalarAsync().ConfigureAwait(false));

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return internationalLicenseID;
            }
        }

        public static async Task<int> GetLicenseIDThatHaveActiveOrdinaryLicenseByID(int driverID)
        {
            int licenseID = -1;

            string query = @"SELECT LicenseID FROM Licenses
                             WHERE DriverID = @DriverID AND IsActive = 1 AND LicenseClass = 3;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;

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

                return licenseID;
            }
        }

        public static async Task<DataTable> GetLicensesByID(int driverID)
        {
            DataTable dt_Licenses = new DataTable();

            string query = @"SELECT LicenseID, ApplicationID, LC.ClassName, IssueDate, ExpirationDate, IsActive
                            FROM Licenses L INNER JOIN LicenseClasses LC
                            ON L.LicenseClass = LC.LicenseClassID
                            WHERE L.DriverID = @DriverID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
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

        public static async Task<DataTable> GetInternationalLicensesByID(int driverID)
        {
            DataTable dt_InternationalLicenses = new DataTable();

            string query = @"SELECT InternationalLicenseID, ApplicationID, IssuedUsingLocalLicenseID,
                            IssueDate, ExpirationDate, IsActive 
                            FROM InternationalLicenses WHERE DriverID = @DriverID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;

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


    }
}
