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

        public static ClsBL_LicenseClass Find(int licenseClassID)
        {
            string className = "", classDescription = "";
            byte minimumAllowedAge = 0, defaultValidityLength = 0;
            float classFees = 0.0f;

            if (ClsDA_LicenseClasses.GetLicenseClassByID(licenseClassID, ref className, ref classDescription, ref minimumAllowedAge, ref defaultValidityLength, ref classFees))
            {
                return new ClsBL_LicenseClass(licenseClassID, className, classDescription, minimumAllowedAge, defaultValidityLength, classFees);
            }
            else return null;
        }

        public static DataTable LoadShort()
        {
            return ClsDA_LicenseClasses.GetAllLicenseClassesShort();
        }

        public static DataTable LoadLong()
        {
            return ClsDA_LicenseClasses.GetAllLicenseClassesLong();
        }

        public bool Save()
        {
            switch (enMode)
            {
                case EnMode.Add:
                    // Code Here
                    return false;
                case EnMode.Update:
                    return _Update();
            }

            return false;
        }

        private bool _Update()
        {
            return ClsDA_LicenseClasses.UpdateLicenseClass(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
        }

        public static float FindClassFeesByID(int licenseClassID)
        {
            return ClsDA_LicenseClasses.GetClassFeesByID(licenseClassID);
        }

        internal static string GetLicenseClassNameByLDLApplicationID(int localDrivingLicenseApplicationID)
        {
            return ClsDA_LicenseClasses.GetLicenseClassNameByLDLApplicationID(localDrivingLicenseApplicationID);
        }
    }
}
