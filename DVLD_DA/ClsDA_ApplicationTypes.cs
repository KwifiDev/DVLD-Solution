﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using static DVLD_DA.ClsDA_LogManager;
using static DVLD_DA.ClsDA_Settings;

namespace DVLD_DA
{
    public class ClsDA_ApplicationTypes
    {
        public class Data
        {
            public bool IsFound { get; set; }
            public int ApplicationTypeID { get; set; }
            public string ApplicationTypeTitle { get; set; }
            public float ApplicationFees { get; set; }
        }

        public static async Task<Data> GetApplicationTypeByID(int applicationTypeID)
        {
            Data applicationType = null;

            string query = @"SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = applicationTypeID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.Read())
                        {
                            applicationType = new Data
                            {
                                IsFound = true,
                                ApplicationTypeTitle = reader["ApplicationTypeTitle"] as string,
                                ApplicationFees = Convert.ToSingle(reader["ApplicationFees"])
                            };
                        }
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return applicationType;
            }
        }

        public static async Task<bool> UpdateApplicationType(int applicationTypeID, string applicationTypeTitle, float applicationFees)
        {
            bool isUpdated = false;

            string query = @"UPDATE ApplicationTypes SET
                            ApplicationTypeTitle = @ApplicationTypeTitle,
                            ApplicationFees = @ApplicationFees
                            WHERE ApplicationTypeID = @ApplicationTypeID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = applicationTypeID;
                command.Parameters.Add("@ApplicationTypeTitle", SqlDbType.NVarChar, 150).Value = applicationTypeTitle;
                command.Parameters.Add("@ApplicationFees", SqlDbType.SmallMoney).Value = applicationFees;


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

        public static async Task<DataTable> GetAllApplicationTypes()
        {
            DataTable dt_ApplicationTypes = new DataTable();

            string query = @"SELECT * FROM ApplicationTypes";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.HasRows) dt_ApplicationTypes.Load(reader);
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return dt_ApplicationTypes;
            }
        }

        public static async Task<float> GetApplcationFeesByID(int applicationTypeID)
        {
            float applicationfees = 0;

            string query = @"SELECT ApplicationFees FROM ApplicationTypes
                            WHERE ApplicationTypeID = @ApplicationTypeID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@ApplicationTypeID", SqlDbType.Int).Value = applicationTypeID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    object id = await command.ExecuteScalarAsync().ConfigureAwait(false);
                    if (id != null && float.TryParse(id.ToString(), out float result))
                    {
                        applicationfees = result;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }
            }

            return applicationfees;
        }
    }
}
