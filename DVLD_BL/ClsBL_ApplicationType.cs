using DVLD_DA;
using System;
using System.Data;

namespace DVLD_BL
{
    public class ClsBL_ApplicationType
    {
        enum EnMode { Add, Update }
        public enum EnType
        {
            NewLocalDrivingLicense = 1, RenewDrivingLicense = 2, ReplacementLostLicense = 3,
            ReplacementDamagedLicense = 4, ReleaseDetainedLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        }


        EnMode enMode;

        public int ApplicationTypeID { get; }
        public string ApplicationTypeTitle { get; set; }
        public float ApplicationFees { get; set; }


        private ClsBL_ApplicationType(int applicationTypeID, string applicationTypeTitle, float applicationFees)
        {
            enMode = EnMode.Update;

            ApplicationTypeID = applicationTypeID;
            ApplicationTypeTitle = applicationTypeTitle;
            ApplicationFees = applicationFees;
        }

        public static ClsBL_ApplicationType Find(int applicationTypeID)
        {
            string applicationTypeTitle = "";
            float applicationFees = 0.0f;

            if (ClsDA_ApplicationTypes.GetApplicationTypeByID(applicationTypeID, ref applicationTypeTitle, ref applicationFees))
            {
                return new ClsBL_ApplicationType((int)applicationTypeID, applicationTypeTitle, applicationFees);
            }
            else return null;
        }

        public static DataTable Load()
        {
            return ClsDA_ApplicationTypes.GetAllApplicationTypes();
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
            return ClsDA_ApplicationTypes.UpdateApplicationType(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
        }

        public static float FindApplicationFeesByID(int applicationTypeID)
        {
            return ClsDA_ApplicationTypes.GetApplcationFeesByID(applicationTypeID);
        }
    }
}
