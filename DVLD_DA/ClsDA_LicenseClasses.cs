using System;
using System.Data;
using System.Data.SqlClient;
using static DVLD_DA.ClsDA_LogManager;
using System.Diagnostics;
using static DVLD_DA.ClsDA_Settings;

namespace DVLD_DA
{
    public class ClsDA_LicenseClasses
    {
        public static bool GetLicenseClassByID(int licenseClassID, ref string className, ref string classDescription,
                                        ref byte minimumAllowedAge, ref byte defaultValidityLength, ref float classFees)
        {
            bool isFound = false;

            string query = @"SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = licenseClassID;

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            className = reader["ClassName"] as string;
                            classDescription = reader["ClassDescription"] as string;
                            minimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                            defaultValidityLength = (byte)reader["DefaultValidityLength"];
                            classFees = Convert.ToSingle(reader["ClassFees"]);
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

        public static bool UpdateLicenseClass(int licenseClassID, string className, string classDescription, byte minimumAllowedAge,
                                                byte defaultValidityLength, float classFees)
        {
            bool isUpdated = false;

            string query = @"UPDATE LicenseClasses SET
                            ClassName = @ClassName,
                            ClassDescription = @ClassDescription,
                            MinimumAllowedAge = @MinimumAllowedAge,
                            DefaultValidityLength = @DefaultValidityLength,
                            ClassFees = @ClassFees
                            WHERE LicenseClassID = @LicenseClassID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = licenseClassID;
                command.Parameters.Add("@ClassName", SqlDbType.NVarChar, 50).Value = className;
                command.Parameters.Add("@ClassDescription", SqlDbType.NVarChar, 500).Value = classDescription;
                command.Parameters.Add("@MinimumAllowedAge", SqlDbType.TinyInt).Value = minimumAllowedAge;
                command.Parameters.Add("@DefaultValidityLength", SqlDbType.TinyInt).Value = defaultValidityLength;
                command.Parameters.Add("@ClassFees", SqlDbType.SmallMoney).Value = classFees;


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

        public static DataTable GetAllLicenseClassesLong()
        {
            DataTable dt_LicenseClasses = new DataTable();

            string query = @"SELECT * FROM LicenseClasses";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) dt_LicenseClasses.Load(reader);
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return dt_LicenseClasses;
            }
        }

        public static DataTable GetAllLicenseClassesShort()
        {
            DataTable dt_LicenseClasses = new DataTable();

            string query = @"SELECT LicenseClassID, ClassName FROM LicenseClasses";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) dt_LicenseClasses.Load(reader);
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return dt_LicenseClasses;
            }
        }

        public static string GetLicenseClassNameByID(int licenseClassID)
        {
            string className = "";

            string query = @"SELECT ClassName FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = licenseClassID;

                try
                {
                    connection.Open();

                    object nameClass = command.ExecuteScalar();
                    className = nameClass != null ? nameClass.ToString() : null;

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return className;
            }
        }

        public static string GetLicenseClassNameByLDLApplicationID(int localDrivingLicenseApplicationID)
        {
            string className = "";

            string query = @"SELECT LC.ClassName FROM LicenseClasses LC
                            INNER JOIN LocalDrivingLicenseApplications LDA
                            ON LC.LicenseClassID = LDA.LicenseClassID
                            WHERE LDA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LocalDrivingLicenseApplicationID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;

                try
                {
                    connection.Open();

                    object nameClass = command.ExecuteScalar();
                    className = nameClass != null ? nameClass.ToString() : null;

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return className;
            }
        }

        public static float GetClassFeesByID(int licenseClassID)
        {
            float classFees = 0;

            string query = @"SELECT ClassFees FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = licenseClassID;

                try
                {
                    connection.Open();

                    classFees = Convert.ToSingle(command.ExecuteScalar());

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return classFees;
            }
        }
    }
}
