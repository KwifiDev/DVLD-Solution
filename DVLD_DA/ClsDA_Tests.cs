using System;
using System.Data;
using System.Data.SqlClient;
using static DVLD_DA.ClsDA_LogManager;
using System.Diagnostics;
using static DVLD_DA.ClsDA_Settings;

namespace DVLD_DA
{
    public class ClsDA_Tests
    {
        public static int AddNewTest(int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            int testID = -1;

            string query = @"INSERT INTO Tests VALUES 
                             (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);
                             UPDATE TestAppointments SET IsLocked = 1
                             WHERE TestAppointmentID = @TestAppointmentID;
                             SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@TestAppointmentID", SqlDbType.Int).Value = testAppointmentID;
                command.Parameters.Add("@TestResult", SqlDbType.Bit).Value = testResult;
                command.Parameters.Add("@Notes", SqlDbType.NVarChar, 500).Value = notes;
                command.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;

                try
                {
                    connection.Open();
                    object id = command.ExecuteScalar();
                    if (id != null && int.TryParse(id.ToString(), out int result))
                    {
                        testID = result;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }
            }

            return testID;
        }

        public static bool GetTestByID(int testID, ref int testAppointmentID, ref bool testResult, ref string notes, ref int createdByUserID)
        {
            bool isFound = false;

            string query = @"SELECT * FROM Tests WHERE TestID = @TestID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@TestID", SqlDbType.Int).Value = testID;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            testAppointmentID = (int)reader["TestAppointmentID"];
                            testResult = (bool)reader["TestResult"];
                            notes = (string)reader["Notes"];
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

        public static DataTable GetAllTests()
        {
            DataTable dt_Tests = new DataTable();

            string query = @"SELECT * FROM Tests";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) dt_Tests.Load(reader);
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return dt_Tests;
            }
        }

        public static bool IsTestExist(int testID)
        {
            bool isExist = false;

            string query = @"SELECT COUNT(1) FROM Tests WHERE TestID = @TestID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@TestID", SqlDbType.Int).Value = testID;

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

        public static byte TotalTrialsPerTest(int localDrivingLicenseApplicationID, int testTypeID)
        {
            byte testFailsCount = 0;

            string query = @"SELECT COUNT(*) FROM Tests T INNER JOIN TestAppointments TP
                            ON T.TestAppointmentID = TP.TestAppointmentID
                            WHERE TP.TestTypeID = @TestTypeID And T.TestResult = 0 
                            And TP.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;
                command.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = testTypeID;

                try
                {
                    connection.Open();
                    object id = command.ExecuteScalar();
                    if (id != null && byte.TryParse(id.ToString(), out byte result))
                    {
                        testFailsCount = result;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }
            }

            return testFailsCount;
        }

        public static int GetTestIDByTestAppointmentID(int testAppointmentID)
        {
            int testID = -1;

            string query = @"SELECT TestID FROM Tests
                             WHERE TestAppointmentID = @TestAppointmentID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@TestAppointmentID", SqlDbType.Int).Value = testAppointmentID;

                try
                {
                    connection.Open();
                    object id = command.ExecuteScalar();
                    if (id != null && int.TryParse(id.ToString(), out int result))
                    {
                        testID = result;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }
            }

            return testID;
        }
    }
}
