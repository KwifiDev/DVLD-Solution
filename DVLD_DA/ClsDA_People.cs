using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using static DVLD_DA.ClsDA_LogManager;
using static DVLD_DA.ClsDA_Settings;

namespace DVLD_DA
{
    public static class ClsDA_People
    {
        public class Data
        {
            public bool IsFound { get; set; }
            public int PersonID { get; set; }
            public string NationalNo { get; set; }
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public string ThirdName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public byte Gendor { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public byte NationalityCountryID { get; set; }
            public string ImagePath { get; set; }
        }

        public static async Task<int> AddNewPerson(string nationalNo, string firstName, string secondName, string thirdName, string lastName,
                                      DateTime dateOfBirth, byte gendor, string address, string phone, string email,
                                      byte nationalityCountryID, string imagePath)
        {
            int personID = -1;

            string query = @"INSERT INTO People VALUES 
                            (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth,
                            @Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
                            SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@NationalNo", SqlDbType.NVarChar, 20).Value = nationalNo;
                command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 20).Value = firstName;
                command.Parameters.Add("@SecondName", SqlDbType.NVarChar, 20).Value = secondName;
                command.Parameters.Add("@LastName", SqlDbType.NVarChar, 20).Value = lastName;
                command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = dateOfBirth;
                command.Parameters.Add("@Gendor", SqlDbType.TinyInt).Value = gendor;
                command.Parameters.Add("@Address", SqlDbType.NVarChar, 500).Value = address;
                command.Parameters.Add("@Phone", SqlDbType.NVarChar, 20).Value = phone;
                command.Parameters.Add("@NationalityCountryID", SqlDbType.Int).Value = nationalityCountryID;


                // Nullable Parameters
                command.Parameters.Add("@ThirdName", SqlDbType.NVarChar, 20).Value = string.IsNullOrEmpty(thirdName) ? (object)DBNull.Value : thirdName;
                command.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = string.IsNullOrEmpty(email) ? (object)DBNull.Value : email;
                command.Parameters.Add("@ImagePath", SqlDbType.NVarChar, 250).Value = string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    object id = await command.ExecuteScalarAsync().ConfigureAwait(false);
                    if (id != null && int.TryParse(id.ToString(), out int result))
                    {
                        personID = result;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }
            }

            return personID;
        }

        public static async Task<bool> UpdatePerson(int personID, string nationalNo, string firstName, string secondName, string thirdName, string lastName,
                                       DateTime dateOfBirth, byte gendor, string address, string phone, string email,
                                       byte nationalityCountryID, string imagePath)
        {
            bool isUpdated = false;

            string query = @"UPDATE People SET
                            NationalNo = @NationalNo,
                            FirstName = @FirstName,
                            SecondName = @SecondName,
                            ThirdName = @ThirdName,
                            LastName = @LastName,
                            DateOfBirth = @DateOfBirth,
                            Gendor = @Gendor,
                            Address = @Address,
                            Phone = @Phone,
                            Email = @Email,
                            NationalityCountryID = @NationalityCountryID,
                            ImagePath = @ImagePath
                            WHERE PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = personID;
                command.Parameters.Add("@NationalNo", SqlDbType.NVarChar, 20).Value = nationalNo;
                command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 20).Value = firstName;
                command.Parameters.Add("@SecondName", SqlDbType.NVarChar, 20).Value = secondName;
                command.Parameters.Add("@LastName", SqlDbType.NVarChar, 20).Value = lastName;
                command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = dateOfBirth;
                command.Parameters.Add("@Gendor", SqlDbType.TinyInt).Value = gendor;
                command.Parameters.Add("@Address", SqlDbType.NVarChar, 500).Value = address;
                command.Parameters.Add("@Phone", SqlDbType.NVarChar, 20).Value = phone;
                command.Parameters.Add("@NationalityCountryID", SqlDbType.Int).Value = nationalityCountryID;


                // Nullable Parameters
                command.Parameters.Add("@ThirdName", SqlDbType.NVarChar, 20).Value = string.IsNullOrEmpty(thirdName) ? (object)DBNull.Value : thirdName;
                command.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = string.IsNullOrEmpty(email) ? (object)DBNull.Value : email;
                command.Parameters.Add("@ImagePath", SqlDbType.NVarChar, 250).Value = string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath;

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

        public static async Task<bool> DeletePerson(int personID)
        {
            bool isDeleted = false;

            string query = @"DELETE FROM People WHERE PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = personID;

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

        public static async Task<Data> GetPersonByID(int personID)
        {
            Data personData = null;

            string query = @"SELECT * FROM People WHERE PersonID = @PersonID";

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
                            personData = new Data
                            {
                                IsFound = true,
                                PersonID = personID,
                                NationalNo = reader["NationalNo"] as string,
                                FirstName = reader["FirstName"] as string,
                                SecondName = reader["SecondName"] as string,
                                ThirdName = reader["ThirdName"] != DBNull.Value ? reader["ThirdName"] as string : null,
                                LastName = reader["LastName"] as string,
                                DateOfBirth = (DateTime)reader["DateOfBirth"],
                                Gendor = (byte)reader["Gendor"],
                                Address = reader["Address"] as string,
                                Phone = reader["Phone"] as string,
                                // Nullable Types
                                Email = reader["Email"] != DBNull.Value ? reader["Email"] as string : null,
                                NationalityCountryID = Convert.ToByte((int)reader["NationalityCountryID"]),
                                ImagePath = reader["ImagePath"] != DBNull.Value ? reader["ImagePath"] as string : null
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }
            }

            return personData;
        }

        public static async Task<Data> GetPersonByNationalNo(string nationalNo)
        {
            Data personData = null;

            string query = @"SELECT * FROM People WHERE NationalNo = @NationalNo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@NationalNo", SqlDbType.NVarChar, 20).Value = nationalNo;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.Read())
                        {
                            personData = new Data
                            {
                                IsFound = true,
                                PersonID = (int)reader["PersonID"],
                                NationalNo = nationalNo,
                                FirstName = reader["FirstName"] as string,
                                SecondName = reader["SecondName"] as string,
                                LastName = reader["LastName"] as string,
                                DateOfBirth = (DateTime)reader["DateOfBirth"],
                                Gendor = (byte)reader["Gendor"],
                                Address = reader["Address"] as string,
                                Phone = reader["Phone"] as string,
                                NationalityCountryID = Convert.ToByte((int)reader["NationalityCountryID"]),
                                // Nullable Types
                                ThirdName = reader["ThirdName"] != DBNull.Value ? reader["ThirdName"] as string : null,
                                Email = reader["Email"] != DBNull.Value ? reader["Email"] as string : null,
                                ImagePath = reader["ImagePath"] != DBNull.Value ? reader["ImagePath"] as string : null
                            };
                            

                            
                        }
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return personData;
            }
        }

        public static async Task<DataTable> GetAllPeople()
        {
            DataTable dt_People = new DataTable();

            string query = @"SELECT PersonID, NationalNo, FirstName, LastName, 
                             CASE WHEN Gendor = 0 THEN 'Male' ELSE 'Female' END AS Gendor,
                             DateOfBirth, Phone FROM People";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (reader.HasRows) dt_People.Load(reader);
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return dt_People;
            }
        }

        public static async Task<bool> IsPersonExist(int personID)
        {
            bool isExist = false;

            string query = @"SELECT COUNT(1) FROM People WHERE PersonID = @PersonID";

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

        public static async Task<bool> IsPersonExist(string nationalNo)
        {
            bool isExist = false;

            string query = @"SELECT COUNT(1) FROM People WHERE NationalNo = @NationalNo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@NationalNo", SqlDbType.NVarChar, 20).Value = nationalNo;

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

        public static async  Task<string> GetPersonImagePathByID(int personID)
        {
            string imagePath = "";

            string query = @"SELECT ImagePath FROM People WHERE PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = personID;

                try
                {
                    await connection.OpenAsync().ConfigureAwait(false);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync())
                        {
                            imagePath = reader["ImagePath"] != DBNull.Value ? reader["ImagePath"] as string : null;
                        }
                    }

                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    AssignLog(ex, EventLogEntryType.Error, EnLayer.DataAccessLayer);
                }

                return imagePath;
            }
        }
    }
}
