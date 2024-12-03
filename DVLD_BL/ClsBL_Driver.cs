using DVLD_DA;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DVLD_BL
{
    public class ClsBL_Driver
    {
        enum EnMode { Add, Update }
        EnMode enMode;
        public int DriverID { get; private set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public ClsBL_Person PersonInfo { get; private set; }

        public ClsBL_Driver()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;
            enMode = EnMode.Add;
        }

        private ClsBL_Driver(int driverID, int personID, int createdByUserID, DateTime createdDate)
        {
            DriverID = driverID;
            PersonID = personID;
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;

            //PersonInfo = ClsBL_Person.Find(PersonID).Result;
            enMode = EnMode.Update;
        }

        public static async Task<ClsBL_Driver> CreateAsync(int driverID, int personID, int createdByUserID, DateTime createdDate)
        {
            ClsBL_Driver driver = new ClsBL_Driver(driverID, personID, createdByUserID, createdDate)
            {
                PersonInfo = await ClsBL_Person.Find(personID)
            };

            return driver;
        }

        public static async Task<ClsBL_Driver> Find(int driverID)
        {
            ClsDA_Drivers.Data data = await ClsDA_Drivers.GetDriverByID(driverID);

            if (data != null && data.IsFound)
            {
                return await CreateAsync(driverID, data.PersonID, data.CreatedByUserID, data.CreatedDate).ConfigureAwait(false);
            }
            else return null;
        }

        public static async Task<DataTable> Load()
        {
            return await ClsDA_Drivers.GetAllDrivers();
        }

        public static async Task<bool> IsExist(int driverID)
        {
            return await ClsDA_Drivers.IsDriverExist(driverID);
        }

        public async Task<bool> Save()
        {
            switch (enMode)
            {
                case EnMode.Add:
                    if (await _Add())
                    {
                        enMode = EnMode.Update;
                        return true;
                    }
                    else return false;

                case EnMode.Update:
                    return false;
            }
            return false;
        }

        private async Task<bool> _Add()
        {
            DriverID = await ClsDA_Drivers.AddNewDriver(PersonID, CreatedByUserID, CreatedDate);
            return (DriverID > 0);
        }

        public static async Task<bool> IsExistByPersonID(int personID)
        {
            return await ClsDA_Drivers.IsDriverExistByPersonID(personID);
        }

        public static async Task<ClsBL_Driver> FindByPersonID(int personID)
        {
            ClsDA_Drivers.Data data = await ClsDA_Drivers.GetDriverByPersonID(personID);

            if (data != null && data.IsFound)
            {
                return await CreateAsync(data.DriverID, personID, data.CreatedByUserID, data.CreatedDate).ConfigureAwait(false);
            }
            else return null;
        }

        public static async Task<DataTable> LoadView()
        {
            return await ClsDA_Drivers.GetAllDrivers_View();
        }

        public static async Task<int> GetActiveInternationalLicenseIDByID(int driverID)
        {
            return await ClsDA_Drivers.GetActiveInternationalLicenseIDByID(driverID);
        }

        public async Task<int> GetActiveInternationalLicenseID()
        {
            return await GetActiveInternationalLicenseIDByID(DriverID);
        }

        public static async Task<bool> IsDriverHaveActiveInternationalLicense(int driverID)
        {
            return await ClsDA_Drivers.GetActiveInternationalLicenseIDByID(driverID) > 0;
        }

        public async Task<bool> IsDriverHaveActiveInternationalLicense()
        {
            return await IsDriverHaveActiveInternationalLicense(DriverID);
        }

        public static async Task<int> FindLicenseIDThatHaveActiveOrdinaryLicenseByID(int driverID)
        {
            return await ClsDA_Drivers.GetLicenseIDThatHaveActiveOrdinaryLicenseByID(driverID);
        }

        public static async Task<DataTable> FindLocalLicensesByID(int driverID)
        {
            return await ClsDA_Drivers.GetLicensesByID(driverID);
        }

        public async Task<DataTable> FindLocalLicenses()
        {
            return await FindLocalLicensesByID(DriverID);
        }

        public static async Task<DataTable> FindInternationalLicensesByID(int driverID)
        {
            return await ClsDA_Drivers.GetInternationalLicensesByID(driverID);
        }

        public async Task<DataTable> FindInternationalLicenses()
        {
            return await FindInternationalLicensesByID(DriverID);
        }
    }
}
