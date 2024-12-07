using DVLD_DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BL
{
    public class ClsBL_LicenseClass
    {
        enum EnMode { Add, Update }
        EnMode enMode;

        public enum EnType 
        { 
            SmallMotorcycle = 1, HeavyMotorcycle = 2, Ordinary = 3, Commercial = 4, Agricultural = 5,
            SmallMediumBus = 6, TruckHeavyVehicle = 7
        }

        public int LicenseClassID { get; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }


        private ClsBL_LicenseClass(int licenseClassID, string className, string classDescription,byte minimumAllowedAge,
                                        byte defaultValidityLength, float classFees)
        {
            enMode = EnMode.Update;

            LicenseClassID = licenseClassID;
            ClassName = className;
            ClassDescription = classDescription;
            MinimumAllowedAge = minimumAllowedAge;
            DefaultValidityLength = defaultValidityLength;
            ClassFees = classFees;
        }

        public static async Task<ClsBL_LicenseClass> Find(int licenseClassID)
        {
            ClsDA_LicenseClasses.Data data = await ClsDA_LicenseClasses.GetLicenseClassByID(licenseClassID);

            if (data != null && data.IsFound)
            {
                return new ClsBL_LicenseClass(licenseClassID, data.ClassName, data.ClassDescription,
                    data.MinimumAllowedAge, data.DefaultValidityLength, data.ClassFees);
            }
            else return null;
        }

        //private static async Task<ClsBL_LicenseClass> CreateAsync(int licenseClassID, string className,
        //    string classDescription, byte minimumAllowedAge, byte defaultValidityLength, float classFees)
        //{
        //    ClsBL_LicenseClass licenseClass = new ClsBL_LicenseClass(licenseClassID, className,
        //    classDescription, minimumAllowedAge, defaultValidityLength, classFees)
        //    {
        //        // Async Code Here
        //    };

        //    return licenseClass;
        //}

        public static async Task<DataTable> LoadShort()
        {
            return await ClsDA_LicenseClasses.GetAllLicenseClassesShort();
        }

        public static async Task<DataTable> LoadLong()
        {
            return await ClsDA_LicenseClasses.GetAllLicenseClassesLong();
        }

        public async Task<bool> Save()
        {
            switch (enMode)
            {
                case EnMode.Add:
                    // Code Here
                    return false;
                case EnMode.Update:
                    return await _Update();
            }

            return false;
        }

        private async Task<bool> _Update()
        {
            return await ClsDA_LicenseClasses.UpdateLicenseClass(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
        }

        public static async Task<float> FindClassFeesByID(int licenseClassID)
        {
            return await ClsDA_LicenseClasses.GetClassFeesByID(licenseClassID);
        }

        internal static async Task<string> GetLicenseClassNameByLDLApplicationID(int localDrivingLicenseApplicationID)
        {
            return await ClsDA_LicenseClasses.GetLicenseClassNameByLDLApplicationID(localDrivingLicenseApplicationID);
        }
    }
}
