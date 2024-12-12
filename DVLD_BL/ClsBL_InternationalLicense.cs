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

        private static async Task<ClsBL_InternationalLicense> CreateAsync(int applicationID, int applicantPersonID,
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
                ApplicantPersonInfo = await ClsBL_Person.Find(applicantPersonID).ConfigureAwait(false),
                UserInfo = await ClsBL_User.Find(createdByUserID).ConfigureAwait(false),
                ApplicationTypeInfo = await ClsBL_ApplicationType.Find
                                      ((int)ClsBL_ApplicationType.EnType.NewInternationalLicense).ConfigureAwait(false),
                
                // Initialize Sub OBJ
                DriverInfo = await ClsBL_Driver.Find(driverID).ConfigureAwait(false)
            };


            return internationalLicense;
        }

        public new static async Task<ClsBL_InternationalLicense> Find(int internationalLicenseID)
        {
            ClsDA_InternationalLicenses.Data data = await ClsDA_InternationalLicenses.GetInternationalLicenseByID(internationalLicenseID);

            if (data != null && data.IsFound)
            {
                //Now we find the base application
                ClsBL_Application app = await ClsBL_Application.Find(data.ApplicationID);

                return await CreateAsync(app.ApplicationID, app.ApplicantPersonID, app.ApplicationDate,
                    app.ApplicationStatus, app.LastStatusDate, app.PaidFees, app.CreatedByUserID,
                    internationalLicenseID, data.DriverID, data.IssuedUsingLocalLicenseID,
                    data.IssueDate, data.ExpirationDate, data.IsActive).ConfigureAwait(false);

            }
            else return null;
        }

        public new static async Task<DataTable> Load()
        {
            return await ClsDA_InternationalLicenses.GetAllInternationalLicenses();
        }

        public new static async Task<bool> IsExist(int internationalLicenseID)
        {
            return await ClsDA_InternationalLicenses.IsInternationalLicenseExist(internationalLicenseID);
        }

        public new async Task<bool> Save()
        {
            //Because of inheritance first we call the save method in the base class,
            //it will take care of adding all information to the application table.
            if (!await base.Save()) return false;

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
            return await ClsDA_InternationalLicenses.UpdateInternationalLicense(InternationalLicenseID, IsActive);
        }

        private async Task<bool> _Add()
        {
            InternationalLicenseID = await ClsDA_InternationalLicenses.AddNewInternationalLicense
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
