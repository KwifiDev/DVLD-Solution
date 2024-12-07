using DVLD_DA;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DVLD_BL
{
    public class ClsBL_Application
    {
        internal enum EnMode { Add, Update };
        internal EnMode enMode;

        public enum EnStatus { New = 1, Cancelled = 2, Completed = 3 };

        int _applicationTypeID;

        public int ApplicationID { get; internal set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID
        {
            get { return _applicationTypeID; }
            set
            {
                if (value < 1 || value > 7) return;
                _applicationTypeID = value;
                SetPaidFeesAsync();
            }
        }
        public EnStatus ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        public ClsBL_Person ApplicantPersonInfo { get; internal set; }
        public ClsBL_ApplicationType ApplicationTypeInfo { get; internal set; }
        public ClsBL_User UserInfo { get; internal set; }

        public string GetApplicationStatusText()
        {
            return ApplicationStatus.ToString();
        }

        public async void SetPaidFeesAsync()
        {
            PaidFees = await ClsBL_ApplicationType.FindApplicationFeesByID(_applicationTypeID);
        }

        protected ClsBL_Application(int applicationID, int applicantPersonID, DateTime applicationDate, int applicationTypeID,
                             EnStatus applicationStatus, DateTime lastStatusDate, float paidFees, int createdByUserID)
        {
            ApplicationID = applicationID;
            ApplicantPersonID = applicantPersonID;
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            ApplicationStatus = applicationStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;

            //ApplicantPersonInfo = ClsBL_Person.Find(ApplicantPersonID).Result;
            //UserInfo = ClsBL_User.Find(CreatedByUserID);
            //ApplicationTypeInfo = ClsBL_ApplicationType.Find(ApplicationTypeID);

            enMode = EnMode.Update;
        }

        public static async Task<ClsBL_Application> CreateAsync(int applicationID, int applicantPersonID,
            DateTime applicationDate, int applicationTypeID, EnStatus applicationStatus, DateTime lastStatusDate,
            float paidFees, int createdByUserID)
        {
            ClsBL_Application application = new ClsBL_Application(applicationID, applicantPersonID, applicationDate, applicationTypeID, applicationStatus, lastStatusDate, paidFees, createdByUserID)
            {
                ApplicantPersonInfo = await ClsBL_Person.Find(applicantPersonID),
                UserInfo = await ClsBL_User.Find(createdByUserID),
                ApplicationTypeInfo = await ClsBL_ApplicationType.Find(applicationTypeID)
            };

            return application;
        }

        public ClsBL_Application()
        {
            ApplicationID = -1;
            ApplicantPersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = -1;
            ApplicationStatus = EnStatus.New;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            enMode = EnMode.Add;

        }

        public static async Task<ClsBL_Application> Find(int applicationID)
        {
            ClsDA_Applications.Data data = await ClsDA_Applications.GetApplicationByID(applicationID);

            if (data != null && data.IsFound)
            {
                return await CreateAsync(applicationID, data.ApplicantPersonID, data.ApplicationDate,
                                        data.ApplicationTypeID,(EnStatus)data.ApplicationStatus, data.LastStatusDate,
                                        data.PaidFees, data.CreatedByUserID).ConfigureAwait(false);
            }
            else return null;
        }

        public static async Task<DataTable> Load()
        {
            return await ClsDA_Applications.GetAllApplications();
        }

        public static async Task<bool> IsExist(int applicationID)
        {
            return await ClsDA_Applications.IsApplicationExist(applicationID);
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
                    return await _Update();

            }

            return false;
        }

        private async Task<bool> _Update()
        {
            return await ClsDA_Applications.UpdateApplicationStatus(ApplicationID, (byte)ApplicationStatus);
        }

        private async Task<bool> _Add()
        {
            ApplicationID = await ClsDA_Applications.AddNewApplication(ApplicantPersonID, ApplicationDate, ApplicationTypeID, (byte)ApplicationStatus,
                                                                     LastStatusDate, PaidFees, CreatedByUserID);
            return (ApplicationID > 0);
        }

        public static async Task<bool> Delete(int applicationID)
        {
            return await ClsDA_Applications.DeleteApplication(applicationID);
        }

        public async Task<bool> Delete()
        {
            return await ClsDA_Applications.DeleteApplication(ApplicationID);
        }

        public static async Task<bool> DoesPersonHaveActiveApplication(int applicantPersonID, int applicationTypeID)
        {
            return await ClsDA_Applications.DoesPersonHaveActiveApplication(applicantPersonID, applicationTypeID);
        }

        public async Task<bool> DoesPersonHaveActiveApplication(int applicationTypeID)
        {
            return await DoesPersonHaveActiveApplication(ApplicantPersonID, applicationTypeID);
        }

        public static async Task<int> GetActiveApplicationID(int applicantPersonID, ClsBL_ApplicationType.EnType applicationTypeID)
        {
            return await ClsDA_Applications.GetActiveApplicationID(applicantPersonID, (int)applicationTypeID);
        }

        public async Task<int> GetActiveApplicationID(ClsBL_ApplicationType.EnType applicationTypeID)
        {
            return await GetActiveApplicationID(ApplicantPersonID, applicationTypeID);
        }

        public static async Task<int> GetActiveApplicationIDForLicenseClass(int applicantPersonID, ClsBL_ApplicationType.EnType applicationTypeID, int licenseClassID)
        {
            return await ClsDA_Applications.GetActiveApplicationIDForLicenseClass(applicantPersonID, (int)applicationTypeID, licenseClassID);
        }

        public static async Task<bool> SetApplicationCompleteByID(int applicationID)
        {
            return await ClsDA_Applications.UpdateApplicationStatus(applicationID, (byte)EnStatus.Completed);
        }

        public async Task<bool> SetApplicationComplete()
        {
            return await SetApplicationCompleteByID(ApplicationID);
        }

        public static async Task<bool> SetApplicationCancelByID(int applicationID)
        {
            return await ClsDA_Applications.UpdateApplicationStatus(applicationID, (byte)EnStatus.Cancelled);
        }

        public async Task<bool> SetApplicationCancel()
        {
            return await SetApplicationCancelByID(ApplicationID);
        }
    }
}
