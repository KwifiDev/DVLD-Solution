using System;
using System.Data;
using System.Data.SqlClient;
using static DVLD_DA.ClsDA_LogManager;
using System.Diagnostics;
using static DVLD_DA.ClsDA_Settings;
using System.Threading.Tasks;

namespace DVLD_DA
{
    public static class ClsDA_Users
    {
        public class Data
        {
            public bool IsFound {  get; set; }
            public int UserID { get; set; }
            public int PersonID { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public int Permissions { get; set; }
            public bool IsActive { get; set; }
        }

        public static async Task<int> AddNewUser(int personID, string userName, string password, int permissions, bool isActive)
        {
            int userID = -1;

            string query = @"INSERT INTO Users VALUES 
                            (@PersonID, @UserName, @Password, @Permissions, @IsActive);
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = personID;
                command.Parameters.Add("@UserName", SqlDbType.NVarChar, 20).Value = userName;
                command.Parameters.Add("@Password", SqlDbType.Char, 64).Value = password;
                command.Parameters.Add("@Permissions", SqlDbType.Int).Value = permissions;
                command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = isActive;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    object id = await command.ExecuteScalarAsync().ConfigureAwait(false);
                    if (id != null && int.TryParse(id.ToString(), out int result))
                    {
                        userID = result;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }
            }

            return userID;
        }

        public static async Task<bool> UpdateUser(int userID, int personID, string userName, string password, int permissions, bool isActive)
        {
            bool isUpdated = false;

            string query = @"UPDATE Users SET
                            PersonID = @PersonID,
                            UserName = @UserName,
                            Password = @Password,
                            Permissions = @Permissions,
                            IsActive = @IsActive
                            WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;
                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = personID;
                command.Parameters.Add("@UserName", SqlDbType.NVarChar, 20).Value = userName;
                command.Parameters.Add("@Password", SqlDbType.Char, 64).Value = password;
                command.Parameters.Add("@Permissions", SqlDbType.Int).Value = permissions;
                command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = isActive;


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

        public static async Task<bool> DeleteUser(int userID)
        {
            bool isDeleted = false;

            string query = @"DELETE FROM Users WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;

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

        public static async Task<Data> GetUserByID(int userID)
        {
            Data user = null;

            string query = @"SELECT * FROM Users WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.Read())
                        {
                            user = new Data()
                            {
                                IsFound = true,
                                UserID = userID,
                                PersonID = (int)reader["PersonID"],
                                UserName = reader["UserName"] as string,
                                Password = reader["Password"] as string,
                                Permissions = (int)reader["Permissions"],
                                IsActive = (bool)reader["IsActive"]
                            };
                        }
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return user;
            }
        }

        public static async Task<DataTable> GetAllUsers()
        {
            DataTable dt_Users = new DataTable();

            string query = @"SELECT U.UserID, U.PersonID, 
                            FullName = FirstName +' '+ SecondName +' '+ ThirdName +' '+ LastName,
                            UserName, IsActive From Users U Inner Join People P
                            ON U.PersonID = P.PersonID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.HasRows) dt_Users.Load(reader);
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return dt_Users;
            }
        }

        public static async Task<bool> IsUserExistByUserID(int userID)
        {
            bool isExist = false;

            string query = @"SELECT COUNT(1) FROM Users WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;

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

        public static async Task<Data> GetUserByUsernameAndPassword(string userName, string password)
        {
            Data user = null;

            string query = @"SELECT * FROM Users WHERE UserName = @UserName and Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@UserName", SqlDbType.NVarChar, 20).Value = userName;
                command.Parameters.Add("@Password", SqlDbType.Char, 64).Value = password;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.Read())
                        {
                            user = new Data()
                            {
                                IsFound = true,
                                UserID = (int)reader["UserID"],
                                PersonID = (int)reader["PersonID"],
                                UserName = userName,
                                Password = password,
                                Permissions = (int)reader["Permissions"],
                                IsActive = (bool)reader["IsActive"]
                            };
                        }
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return user;
            }
        }

        public static async Task<bool> IsUserExistByPersonID(int personID)
        {
            bool isExist = false;

            string query = @"SELECT COUNT(1) FROM Users WHERE PersonID = @PersonID";

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

        public static async Task<int> GetUserIDByUsername(string username)
        {
            int userID = -1;

            string query = @"SELECT UserID FROM Users WHERE UserName = @UserName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@UserName", SqlDbType.NVarChar, 20).Value = username;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    object id = await command.ExecuteScalarAsync().ConfigureAwait(false);
                    if (id != null && int.TryParse(id.ToString(), out int result))
                    {
                        userID = result;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return userID;
            }
        }

        public static async Task<string> GetUsernameByUserID(int userID)
        {
            string username = string.Empty;

            string query = @"SELECT UserName FROM Users WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    object name = await command.ExecuteScalarAsync().ConfigureAwait(false);
                    if (name != null)
                        username = name.ToString();

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return username;
            }
        }

        public static async Task<bool> IsUsernameExist(string username)
        {
            bool isExist = false;

            string query = @"SELECT COUNT(1) FROM Users WHERE UserName = @UserName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@UserName", SqlDbType.NVarChar, 20).Value = username;

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

        public static async Task<Data> GetUserByPersonID(int personID)
        {
            Data user = null;

            string query = @"SELECT * FROM Users WHERE PersonID = @PersonID";

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
                            user = new Data()
                            {
                                IsFound = true,
                                UserID = (int)reader["UserID"],
                                PersonID = personID,
                                UserName = reader["UserName"] as string,
                                Password = reader["Password"] as string,
                                Permissions = (int)reader["Permissions"],
                                IsActive = (bool)reader["IsActive"]
                            };

                        }
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return user;
            }
        }
    }
}
