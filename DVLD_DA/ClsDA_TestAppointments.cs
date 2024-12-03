using System;
using System.Data;
using System.Data.SqlClient;
using static DVLD_DA.ClsDA_LogManager;
using System.Diagnostics;
using static DVLD_DA.ClsDA_Settings;

namespace DVLD_DA
{
    public class ClsDA_TestAppointments
    {
        public static int AddNewTestAppointment(int testTypeID, int localDrivingLicenseApplicationID, DateTime appointmentDate,
                                                float paidFees, int createdByUserID, bool isLocked, int retakeTestApplicationID)
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
                    connection.Open();
                    object id = command.ExecuteScalar();
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

        public static bool UpdateTestAppointment(int testAppointmentID, DateTime appointmentDate)
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

        public static bool GetTestAppointmentByID(int testAppointmentID, ref int testTypeID,
                                                ref int localDrivingLicenseApplicationID, ref DateTime appointmentDate,
                                                ref float paidFees, ref int createdByUserID, ref bool isLocked, ref int retakeTestApplicationID)
        {
            bool isFound = false;

            string query = @"SELECT * FROM TestAppointments 
                            WHERE TestAppointmentID = @TestAppointmentID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@TestAppointmentID", SqlDbType.Int).Value = testAppointmentID;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            testTypeID = (int)reader["TestTypeID"];
                            localDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                            appointmentDate = (DateTime)reader["AppointmentDate"];
                            paidFees = Convert.ToSingle(reader["PaidFees"]);
                            createdByUserID = (int)reader["CreatedByUserID"];
                            isLocked = (bool)reader["IsLocked"];
                            retakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
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

        public static bool GetTestAppointmentViewByID(int testAppointmentID, ref int localDrivingLicenseApplicationID,
                                                ref string testTypeTitle, ref string className, ref DateTime appointmentDate,
                                                ref float paidFees, ref string fullName, ref bool isLocked)
        {
            bool isFound = false;

            string query = @"SELECT * FROM TestAppointments_View 
                            WHERE TestAppointmentID = @TestAppointmentID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@TestAppointmentID", SqlDbType.Int).Value = testAppointmentID;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            localDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                            testTypeTitle = (string)reader["TestTypeTitle"];
                            className = (string)reader["ClassName"];
                            appointmentDate = (DateTime)reader["AppointmentDate"];
                            paidFees = (float)reader["PaidFees"];
                            fullName = (string)reader["FullName"];
                            isLocked = (bool)reader["IsLocked"];
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

        public static DataTable GetAllTestAppointments()
        {
            DataTable dt_TestAppointments = new DataTable();

            string query = @"SELECT TestAppointmentID, AppointmentDate, PaidFees, IsLocked FROM TestAppointments";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
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

        public static DataTable GetAllTestAppointments_View()
        {
            DataTable dt_TestAppointments_View = new DataTable();

            string query = @"SELECT * FROM TestAppointments_View";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
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

        public static bool IsTestAppointmentExist(int testAppointmentID)
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

        public static DataTable GetTestAppointmentsPerTestType(int localDrivingLicenseApplicationID, int testTypeID)
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
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
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

        public static bool LockByTestAppointmentID(int testAppointmentID)
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

        public static bool IsPersonHaveActiveAppointment(int localDrivingLicenseApplicationID, int testTypeID)
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
                    connection.Open();

                    isAnyActiveAppointment = Convert.ToInt32(command.ExecuteScalar()) > 0;

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
