using DVLD_DA;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace DVLD_BL
{
    public class ClsBL_Person
    {
        enum EnMode { Add, Update };
        EnMode enMode;


        public int PersonID { get; private set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {SecondName} {ThirdName} {LastName}"; } }
        public DateTime DateOfBirth { get; set; }
        public byte Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte NationalityCountryID { get; set; }
        public string ImagePath
        {
            get { return _serverImagePath; }
            set
            {
                _clientImagePath = value;
                if (_serverImagePath == null) _serverImagePath = value;
            }
        }

        private string _clientImagePath;
        private string _serverImagePath;

        public ClsBL_Country CountryInfo { get; private set; }

        public ClsBL_Person()
        {
            enMode = EnMode.Add;
            PersonID = -1;
            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.Now;
            Gendor = 2;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            NationalityCountryID = 0;
            ImagePath = string.Empty;
        }

        private ClsBL_Person(int personID, string nationalNo, string firstName, string secondName, string thirdName, string lastName,
                                       DateTime dateOfBirth, byte gendor, string address, string phone, string email,
                                       byte nationalityCountryID, string imagePath)
        {
            PersonID = personID;
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gendor = gendor;
            Address = address;
            Phone = phone;
            Email = email;
            NationalityCountryID = nationalityCountryID;
            ImagePath = imagePath;
            //CountryInfo = ClsBL_Country.Find(NationalityCountryID);
            enMode = EnMode.Update;
        }

        public static async Task<ClsBL_Person> CreateAsync(int personID, string nationalNo, string firstName, string secondName, string thirdName, string lastName,
                                       DateTime dateOfBirth, byte gendor, string address, string phone, string email,
                                       byte nationalityCountryID, string imagePath)
        {
            ClsBL_Person person = new ClsBL_Person(personID, nationalNo, firstName, secondName, thirdName, lastName,
                dateOfBirth, gendor, address, phone, email, nationalityCountryID, imagePath)
            {
                CountryInfo = await ClsBL_Country.Find(nationalityCountryID)
            };

            return person;
        }

        public static async Task<ClsBL_Person> Find(int personID)
        {
            ClsDA_People.Data data = await ClsDA_People.GetPersonByID(personID).ConfigureAwait(false);

            if (data != null && data.IsFound)
            {
                return await CreateAsync(personID, data.NationalNo, data.FirstName, data.SecondName, data.ThirdName, data.LastName,
                                         data.DateOfBirth, data.Gendor, data.Address, data.Phone, data.Email,
                                         data.NationalityCountryID, data.ImagePath).ConfigureAwait(false);
            }
            else return null;
        }

        public static async Task<ClsBL_Person> Find(string nationalNo)
        {
            ClsDA_People.Data data = await ClsDA_People.GetPersonByNationalNo(nationalNo).ConfigureAwait(false);

            if (data != null && data.IsFound)
            {
                return await CreateAsync(data.PersonID, nationalNo, data.FirstName, data.SecondName, data.ThirdName, data.LastName,
                                         data.DateOfBirth, data.Gendor, data.Address, data.Phone, data.Email,
                                         data.NationalityCountryID, data.ImagePath).ConfigureAwait(false);
            }
            else return null;
        }

        public static async Task<bool> IsExist(int personID)
        {
            return await ClsDA_People.IsPersonExist(personID);
        }

        public static Task<bool> IsExist(string nationalNo)
        {
            return ClsDA_People.IsPersonExist(nationalNo);
        }

        public static async Task<DataTable> Load()
        {
            return await ClsDA_People.GetAllPeople();
        }

        private async Task<bool> _Add()
        {
            _serverImagePath = GenerateImagePath(_clientImagePath);

            PersonID = await ClsDA_People.AddNewPerson(NationalNo, FirstName, SecondName, ThirdName, LastName,
                                    DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);

            if (PersonID != -1) DownloadImageOnServer(_clientImagePath, ImagePath);
            return (PersonID != -1);
        }

        private async Task<bool> _Update()
        {
            _serverImagePath = await UpdateImagePath(_clientImagePath);

            bool IsUpdated = await ClsDA_People.UpdatePerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                                    DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);

            if (IsUpdated) DownloadImageOnServer(_clientImagePath, ImagePath);

            return IsUpdated;
        }

        public Task<bool> Delete()
        {
            return ClsDA_People.DeletePerson(PersonID);
        }

        public static async Task<bool> Delete(int personID)
        {
            string imagePath = await ClsDA_People.GetPersonImagePathByID(personID);

            if (await ClsDA_People.DeletePerson(personID))
            {
                DeletePersonImage(imagePath);
                return true;
            }
            return false;
        }

        private static void DeletePersonImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath)) return;

            File.Delete(imagePath);
        }

        public async Task<bool> Save()
        {
            switch (enMode)
            {
                case EnMode.Add:
                    {
                        if (await _Add())
                        {
                            enMode = EnMode.Update;
                            return true;
                        }
                        return false;
                    }

                case EnMode.Update:
                    {
                        return await _Update();
                    }
            }

            return false;
        }

        private async Task<string> UpdateImagePath(string clientImagePath)
        {
            if (clientImagePath != null)
            {
                // Saw If There Old Image To Save The New Image With The Same Path Or Generete a New Path
                return await ClsDA_People.GetPersonImagePathByID(PersonID) ?? GenerateImagePath(clientImagePath);
            }
            else
            {
                DeletePersonImage(await ClsDA_People.GetPersonImagePathByID(PersonID));
                return null;
            }
        }

        private string GenerateImagePath(string clientImagePath)
        {
            if (string.IsNullOrEmpty(clientImagePath)) return null;

            string extension = Path.GetExtension(clientImagePath);

            return Path.Combine("C:\\DVLD-People-Images", $"{Guid.NewGuid()}{extension}");
        }

        private void DownloadImageOnServer(string clientImagePath, string generatedServerImagePath)
        {
            if (string.IsNullOrEmpty(clientImagePath) || clientImagePath == generatedServerImagePath) return;

            File.Copy(clientImagePath, generatedServerImagePath, true); // Download Image From Client To Server
        }

        public string GetGendorText()
        {
            return Gendor == 0 ? "Male" : "Female";
        }

        public static async Task<int> MakePersonBecomeDriver(int personID, int createdByUserID)
        {
            int driverID = -1;

            // Assign Driver To Person If is Not Exist
            if (await ClsBL_Driver.IsExistByPersonID(personID))
            {
                ClsBL_Driver driver = await ClsBL_Driver.FindByPersonID(personID);
                driverID = driver.DriverID;
            }
            else
            {
                ClsBL_Driver driver = new ClsBL_Driver
                {
                    PersonID = personID,
                    CreatedByUserID = createdByUserID
                };

                if (await driver.Save()) driverID = driver.DriverID;
            }

            return driverID;
        }
    }
}
