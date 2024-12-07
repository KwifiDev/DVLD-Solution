using System;
using System.Data;
using System.Data.SqlClient;
using static DVLD_DA.ClsDA_LogManager;
using System.Diagnostics;
using static DVLD_DA.ClsDA_Settings;
using System.Threading.Tasks;

namespace DVLD_DA
{
    public class ClsDA_LicenseClasses
    {
        public class Data
        {
            public bool IsFound { get; set; }
            public int LicenseClassID { get; set; }
            public string ClassName { get; set; }
            public string ClassDescription { get; set; }
            public byte MinimumAllowedAge { get; set; }
            public byte DefaultValidityLength { get; set; }
            public float ClassFees { get; set; }
        }

        public static async Task<Data> GetLicenseClassByID(int licenseClassID)
        {
            Data licenseClass = null;

            string query = @"SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = licenseClassID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.Read())
                        {
                            licenseClass = new Data
                            {
                                IsFound = true,
                                LicenseClassID = licenseClassID,
                                ClassName = reader["ClassName"] as string,
                                ClassDescription = reader["ClassDescription"] as string,
                                MinimumAllowedAge = (byte)reader["MinimumAllowedAge"],
                                DefaultValidityLength = (byte)reader["DefaultValidityLength"],
                                ClassFees = Convert.ToSingle(reader["ClassFees"])
                            };
                           
                        }
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return licenseClass;
            }
        }

        public static async Task<bool> UpdateLicenseClass(int licenseClassID, string className, string classDescription, byte minimumAllowedAge,
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

        public static async Task<DataTable> GetAllLicenseClassesLong()
        {
            DataTable dt_LicenseClasses = new DataTable();

            string query = @"SELECT * FROM LicenseClasses";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
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

        public static async Task<DataTable> GetAllLicenseClassesShort()
        {
            DataTable dt_LicenseClasses = new DataTable();

            string query = @"SELECT LicenseClassID, ClassName FROM LicenseClasses";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
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

        public static async Task<string> GetLicenseClassNameByID(int licenseClassID)
        {
            string className = "";

            string query = @"SELECT ClassName FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = licenseClassID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    object nameClass = await command.ExecuteScalarAsync().ConfigureAwait(false);
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

        public static async Task<string> GetLicenseClassNameByLDLApplicationID(int localDrivingLicenseApplicationID)
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
                    await connection.OpenAsync().ConfigureAwait(false);

                    object nameClass = await command.ExecuteScalarAsync().ConfigureAwait(false);
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

        public static async Task<float> GetClassFeesByID(int licenseClassID)
        {
            float classFees = 0;

            string query = @"SELECT ClassFees FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@LicenseClassID", SqlDbType.Int).Value = licenseClassID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    classFees = Convert.ToSingle(await command.ExecuteScalarAsync().ConfigureAwait(false));

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
