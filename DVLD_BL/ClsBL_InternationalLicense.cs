using DVLD_DA;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DVLD_BL
{
    public class ClsBL_InternationalLicense : ClsBL_Application
    {
        new enum EnMode { Add, Update }
        new EnMode enMode;
        public int InternationalLicenseID { get; private set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public bool IsActive { get; set; }
        public ClsBL_Driver DriverInfo { get; private set; }

        public ClsBL_InternationalLicense()
        {
            ApplicationTypeID = (int)ClsBL_ApplicationType.EnType.NewInternationalLicense;

            InternationalLicenseID = -1;
            DriverID = -1;
            IssuedUsingLocalLicenseID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now.AddYears(1);
            IsActive = true;
            enMode = EnMode.Add;
        }

        private ClsBL_InternationalLicense(int applicationID, int applicantPersonID, DateTime applicationDate,
                                           EnStatus applicationStatus, DateTime lastStatusDate,
                                           float paidFees, int createdByUserID, int internationalLicenseID,
                                           int driverID, int issuedUsingLocalLicenseID, DateTime issueDate,
                                           DateTime expirationDate, bool isActive)
                                           : base (applicationID, applicantPersonID, applicationDate,
                                                  (int)ClsBL_ApplicationType.EnType.NewInternationalLicense,
                                                  applicationStatus, lastStatusDate, paidFees, createdByUserID)
        {
            InternationalLicenseID = internationalLicenseID;
            DriverID = driverID;
            IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            IsActive = isActive;
            //DriverInfo = ClsBL_Driver.Find(DriverID);
            enMode = EnMode.Update;
        }

        public static async Task<ClsBL_InternationalLicense> CreateAsync(int applicationID, int applicantPersonID,
                                   DateTime applicationDate, EnStatus applicationStatus, DateTime lastStatusDate,
                                   float paidFees, int createdByUserID, int internationalLicenseID,
                                   int driverID, int issuedUsingLocalLicenseID, DateTime issueDate,
                                   DateTime expirationDate, bool isActive)
        {
            ClsBL_InternationalLicense internationalLicense = new ClsBL_InternationalLicense(applicationID, applicantPersonID,
                applicationDate, applicationStatus, lastStatusDate, paidFees, createdByUserID, internationalLicenseID,
                driverID, issuedUsingLocalLicenseID, issueDate, expirationDate, isActive)
            {
                // Initialize Base OBJ
                ApplicantPersonInfo = await ClsBL_Person.Find(applicantPersonID),
                UserInfo = await ClsBL_User.Find(createdByUserID),
                ApplicationTypeInfo = ClsBL_ApplicationType.Find((int)ClsBL_ApplicationType.EnType.NewInternationalLicense),
                
                // Initialize Sub OBJ
                DriverInfo = await ClsBL_Driver.Find(driverID)
            };


            return internationalLicense;
        }

        public new static async Task<ClsBL_InternationalLicense> Find(int internationalLicenseID)
        {
            int applicationID = -1, driverID = -1, issuedUsingLocalLicenseID = -1, createdByUserID = -1;
            bool isActive = false;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;

            bool isFound = ClsDA_InternationalLicenses.GetInternationalLicenseByID
                (internationalLicenseID, ref applicationID, ref driverID, ref issuedUsingLocalLicenseID,
                ref issueDate, ref expirationDate, ref isActive, ref createdByUserID);

            if (isFound)
            {
                //Now we find the base application
                ClsBL_Application app = await ClsBL_Application.Find(applicationID);

                return await CreateAsync(app.ApplicationID, app.ApplicantPersonID, app.ApplicationDate,
                    app.ApplicationStatus, app.LastStatusDate, app.PaidFees, app.CreatedByUserID,
                    internationalLicenseID, driverID, issuedUsingLocalLicenseID,
                    issueDate, expirationDate, isActive).ConfigureAwait(false);

            }
            else return null;
        }

        public new static DataTable Load()
        {
            return ClsDA_InternationalLicenses.GetAllInternationalLicenses();
        }

        public new static bool IsExist(int internationalLicenseID)
        {
            return ClsDA_InternationalLicenses.IsInternationalLicenseExist(internationalLicenseID);
        }

        public new async Task<bool> Save()
        {
            //Because of inheritance first we call the save method in the base class,
            //it will take care of adding all information to the application table.
            if (!await base.Save()) return false;

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
            return ClsDA_InternationalLicenses.UpdateInternationalLicense(InternationalLicenseID, IsActive);
        }

        private bool _Add()
        {
            InternationalLicenseID = ClsDA_InternationalLicenses.AddNewInternationalLicense
                (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);

            return (InternationalLicenseID > 0);
        }

        public string GetLicenseStatus()
        {
            return IsActive ? "Active" : "Not Active";
        }

        public static async Task<DataTable> FindInternationalLicensesByDriverID(int driverID)
        {
            return await ClsDA_Drivers.GetInternationalLicensesByID(driverID);
        }

        public async Task<DataTable> FindInternationalLicenses()
        {
            return await FindInternationalLicensesByDriverID(DriverID);
        }

        public static async Task<int> GetActiveInternationalLicenseIDByDriverID(int driverID)
        {
            return await ClsBL_Driver.GetActiveInternationalLicenseIDByID(driverID);
        }
    }
}
