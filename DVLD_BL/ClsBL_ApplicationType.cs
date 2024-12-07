using DVLD_DA;
using System.Data;
using System.Threading.Tasks;

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

        //public static async Task<ClsBL_ApplicationType> CreateAsync(int applicationTypeID, string applicationTypeTitle, float applicationFees)
        //{
        //    ClsBL_ApplicationType applicationType = new ClsBL_ApplicationType((int)applicationTypeID, applicationTypeTitle, applicationFees)
        //    {
        //        // Async Code Here
        //    };

        //    return applicationType;
        //}

        public static async Task<ClsBL_ApplicationType> Find(int applicationTypeID)
        {
            ClsDA_ApplicationTypes.Data data = await ClsDA_ApplicationTypes.GetApplicationTypeByID(applicationTypeID);

            if (data != null && data.IsFound)
            {
                return new ClsBL_ApplicationType((int)applicationTypeID, data.ApplicationTypeTitle, data.ApplicationFees);
            }
            else return null;
        }

        public static async Task<DataTable> Load()
        {
            return await ClsDA_ApplicationTypes.GetAllApplicationTypes();
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
            return await ClsDA_ApplicationTypes.UpdateApplicationType(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
        }

        public static async Task<float> FindApplicationFeesByID(int applicationTypeID)
        {
            return await ClsDA_ApplicationTypes.GetApplcationFeesByID(applicationTypeID);
        }
    }
}
