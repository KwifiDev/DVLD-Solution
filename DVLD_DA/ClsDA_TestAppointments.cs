using System;
using System.Data;
using System.Data.SqlClient;
using static DVLD_DA.ClsDA_LogManager;
using System.Diagnostics;
using static DVLD_DA.ClsDA_Settings;
using System.Threading.Tasks;

namespace DVLD_DA
{
    public class ClsDA_TestAppointments
    {
        public class Data
        {
            public bool IsFound { get; set; }
            public int TestAppointmentID { get; set; }
            public int TestTypeID { get; set; }
            public int LocalDrivingLicenseApplicationID { get; set; }
            public DateTime AppointmentDate { get; set; }
            public float PaidFees { get; set; }
            public int CreatedByUserID { get; set; }
            public bool IsLocked { get; set; }
            public int? RetakeTestApplicationID { get; set; }
        }
        public class DataView : Data
        {
            public string TestTypeTitle { get; set; }
            public string ClassName { get; set; }
            public string FullName { get; set; }
        }

        public static async Task<int> AddNewTestAppointment(int testTypeID, int localDrivingLicenseApplicationID, DateTime appointmentDate,
                                                float paidFees, int createdByUserID, bool isLocked, int? retakeTestApplicationID)
        {
            int testAppointmentID = -1;

            string query = @"INSERT INTO TestAppointments VALUES 
                            (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate,
                             @PaidFees, @CreatedByUserID, @IsLocked, @RetakeTestApplicationID);
                             SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = testTypeID;
                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;
                command.Parameters.Add("@AppointmentDate", SqlDbType.SmallDateTime).Value = appointmentDate;
                command.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = paidFees;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;
                command.Parameters.Add("@IsLocked", SqlDbType.Bit).Value = isLocked;
                command.Parameters.Add("@RetakeTestApplicationID", SqlDbType.Int).Value = retakeTestApplicationID != -1 ? (object)retakeTestApplicationID : DBNull.Value;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    object id = await command.ExecuteScalarAsync().ConfigureAwait(false);
                    if (id != null && int.TryParse(id.ToString(), out int result))
                    {
                        testAppointmentID = result;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }
            }

            return testAppointmentID;
        }

        public static async Task<bool> UpdateTestAppointment(int testAppointmentID, DateTime appointmentDate)
        {
            bool isUpdated = false;

            string query = @"UPDATE TestAppointments SET
                            AppointmentDate = @AppointmentDate
                            WHERE TestAppointmentID = @TestAppointmentID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@TestAppointmentID", SqlDbType.Int).Value = testAppointmentID;
                command.Parameters.Add("@AppointmentDate", SqlDbType.SmallDateTime).Value = appointmentDate;

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

        public static async Task<Data> GetTestAppointmentByID(int testAppointmentID)
        {
            Data testAppointment = null;

            string query = @"SELECT * FROM TestAppointments 
                            WHERE TestAppointmentID = @TestAppointmentID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@TestAppointmentID", SqlDbType.Int).Value = testAppointmentID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.Read())
                        {
                            testAppointment = new Data();
                            //{
                            testAppointment.IsFound = true;
                            testAppointment.TestTypeID = (int)reader["TestTypeID"];
                            testAppointment.TestAppointmentID = testAppointmentID;
                            testAppointment.LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                            testAppointment.AppointmentDate = (DateTime)reader["AppointmentDate"];
                            testAppointment.PaidFees = Convert.ToSingle(reader["PaidFees"]);
                            testAppointment.CreatedByUserID = (int)reader["CreatedByUserID"];
                            testAppointment.IsLocked = (bool)reader["IsLocked"];
                            testAppointment.RetakeTestApplicationID = reader["RetakeTestApplicationID"] != DBNull.Value ? (int?)reader["RetakeTestApplicationID"] : null;
                            //};
                            
                        }
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return testAppointment;
            }
        }

        public static async Task<Data> GetTestAppointmentViewByID(int testAppointmentID)
        {
            DataView testAppointmentView = null;

            string query = @"SELECT * FROM TestAppointments_View 
                            WHERE TestAppointmentID = @TestAppointmentID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@TestAppointmentID", SqlDbType.Int).Value = testAppointmentID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.Read())
                        {
                            testAppointmentView = new DataView
                            {
                                IsFound = true,
                                TestAppointmentID = testAppointmentID,
                                LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"],
                                TestTypeTitle = (string)reader["TestTypeTitle"],
                                ClassName = (string)reader["ClassName"],
                                AppointmentDate = (DateTime)reader["AppointmentDate"],
                                PaidFees = (float)reader["PaidFees"],
                                FullName = (string)reader["FullName"],
                                IsLocked = (bool)reader["IsLocked"]
                            };
                            
                        }
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return testAppointmentView;
            }
        }

        public static async Task<DataTable> GetAllTestAppointments()
        {
            DataTable dt_TestAppointments = new DataTable();

            string query = @"SELECT TestAppointmentID, AppointmentDate, PaidFees, IsLocked FROM TestAppointments";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.HasRows) dt_TestAppointments.Load(reader);
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return dt_TestAppointments;
            }
        }

        public static async Task<DataTable> GetAllTestAppointments_View()
        {
            DataTable dt_TestAppointments_View = new DataTable();

            string query = @"SELECT * FROM TestAppointments_View";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    
                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.HasRows) dt_TestAppointments_View.Load(reader);
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return dt_TestAppointments_View;
            }
        }

        public static async Task<bool> IsTestAppointmentExist(int testAppointmentID)
        {
            bool isExist = false;

            string query = @"SELECT COUNT(1) FROM TestAppointments 
                            WHERE TestAppointmentID = @TestAppointmentID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@TestAppointmentID", SqlDbType.Int).Value = testAppointmentID;

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

        public static async Task<DataTable> GetTestAppointmentsPerTestType(int localDrivingLicenseApplicationID, int testTypeID)
        {
            DataTable dt_TestAppointments = new DataTable();

            string query = @"SELECT TestAppointmentID, AppointmentDate, PaidFees, IsLocked FROM TestAppointments
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND
                             TestTypeID = @testTypeID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;
                command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = testTypeID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.HasRows) dt_TestAppointments.Load(reader);
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return dt_TestAppointments;
            }
        }

        public static async Task<bool> LockByTestAppointmentID(int testAppointmentID)
        {
            bool isUpdated = false;

            string query = @"UPDATE TestAppointments SET IsLocked = 1
                             WHERE TestAppointmentID = @TestAppointmentID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@TestAppointmentID", SqlDbType.Int).Value = testAppointmentID;

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

        public static async Task<bool> IsPersonHaveActiveAppointment(int localDrivingLicenseApplicationID, int testTypeID)
        {
            bool isAnyActiveAppointment = false;

            string query = @"SELECT COUNT(*) FROM TestAppointments
                            WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                            AND TestTypeID = @TestTypeID AND IsLocked = 0"; // Zero Means Active Appointment

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;
                command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = testTypeID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    isAnyActiveAppointment = Convert.ToInt32(await command.ExecuteScalarAsync().ConfigureAwait(false)) > 0;

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return isAnyActiveAppointment;
            }
        }
    }
}
