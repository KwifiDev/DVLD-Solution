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
                PaidFees = ClsBL_ApplicationType.FindApplicationFeesByID(_applicationTypeID);
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
                ApplicationTypeInfo = ClsBL_ApplicationType.Find(applicationTypeID)
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
            int personID = -1, applicationTypeID = -1, createdByUserID = -1;
            float paidFees = 0;
            byte applicationStatus = 0;
            DateTime applicationDate = DateTime.Now, lastStatusDate = DateTime.Now;

            if (ClsDA_Applications.GetApplicationByID(applicationID, ref personID, ref applicationDate, ref applicationTypeID,
                                                ref applicationStatus, ref lastStatusDate, ref paidFees, ref createdByUserID))
            {
                return await CreateAsync(applicationID, personID, applicationDate, applicationTypeID,
                             (EnStatus)applicationStatus, lastStatusDate, paidFees, createdByUserID).ConfigureAwait(false);
            }
            else return null;
        }

        public static DataTable Load()
        {
            return ClsDA_Applications.GetAllApplications();
        }

        public static bool IsExist(int applicationID)
        {
            return ClsDA_Applications.IsApplicationExist(applicationID);
        }

        public bool Save()
        {
            switch (enMode)
            {
                case EnMode.Add:
                    if (_Add())
                    {
                        enMode = EnMode.Update;
                        return true;
                    }
                    else return false;

                case EnMode.Update:
                    return _Update();

            }

            return false;
        }

        private bool _Update()
        {
            return ClsDA_Applications.UpdateApplicationStatus(ApplicationID, (byte)ApplicationStatus);
        }

        private bool _Add()
        {
            ApplicationID = ClsDA_Applications.AddNewApplication(ApplicantPersonID, ApplicationDate, ApplicationTypeID, (byte)ApplicationStatus,
                                                                     LastStatusDate, PaidFees, CreatedByUserID);
            return (ApplicationID > 0);
        }

        public static bool Delete(int applicationID)
        {
            return ClsDA_Applications.DeleteApplication(applicationID);
        }

        public bool Delete()
        {
            return ClsDA_Applications.DeleteApplication(ApplicationID);
        }

        public static bool DoesPersonHaveActiveApplication(int applicantPersonID, int applicationTypeID)
        {
            return ClsDA_Applications.DoesPersonHaveActiveApplication(applicantPersonID, applicationTypeID);
        }

        public bool DoesPersonHaveActiveApplication(int applicationTypeID)
        {
            return DoesPersonHaveActiveApplication(ApplicantPersonID, applicationTypeID);
        }

        public static int GetActiveApplicationID(int applicantPersonID, ClsBL_ApplicationType.EnType applicationTypeID)
        {
            return ClsDA_Applications.GetActiveApplicationID(applicantPersonID, (int)applicationTypeID);
        }

        public int GetActiveApplicationID(ClsBL_ApplicationType.EnType applicationTypeID)
        {
            return GetActiveApplicationID(ApplicantPersonID, applicationTypeID);
        }

        public static int GetActiveApplicationIDForLicenseClass(int applicantPersonID, ClsBL_ApplicationType.EnType applicationTypeID, int licenseClassID)
        {
            return ClsDA_Applications.GetActiveApplicationIDForLicenseClass(applicantPersonID, (int)applicationTypeID, licenseClassID);
        }

        public static bool SetApplicationCompleteByID(int applicationID)
        {
            return ClsDA_Applications.UpdateApplicationStatus(applicationID, (byte)EnStatus.Completed);
        }

        public bool SetApplicationComplete()
        {
            return SetApplicationCompleteByID(ApplicationID);
        }

        public static bool SetApplicationCancelByID(int applicationID)
        {
            return ClsDA_Applications.UpdateApplicationStatus(applicationID, (byte)EnStatus.Cancelled);
        }

        public bool SetApplicationCancel()
        {
            return SetApplicationCancelByID(ApplicationID);
        }
    }
}
