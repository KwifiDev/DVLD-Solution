using DVLD_DA;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DVLD_BL
{
    public class ClsBL_License
    {
        enum EnMode { Add, Update }
        EnMode enMode;

        public enum EnIssueReason { FirstTime = 1, Renew = 2, ReplacementLost = 3, ReplacementDamaged = 4 }

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public bool IsActive { get; set; }
        public EnIssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; set; }
        public ClsBL_Driver DriverInfo { get; private set; }
        public ClsBL_LicenseClass LicenseClassInfo { get; private set; }
        public ClsBL_DetainedLicense DetainedInfo { get; private set; }

        public ClsBL_License()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = string.Empty;
            PaidFees = 0;
            IsActive = true;
            IssueReason = 0;
            CreatedByUserID = -1;

            enMode = EnMode.Add;
        }

        private ClsBL_License(int licenseID, int applicationID, int driverID, int licenseClassID, DateTime issueDate,
                                        DateTime expirationDate, string notes, float paidFees,
                                        bool isActive, EnIssueReason issueReason, int createdByUserID)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseClassID = licenseClassID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;

            enMode = EnMode.Update;
        }

        private static async Task<ClsBL_License> CreateAsync(int licenseID, int applicationID, int driverID, int licenseClassID, DateTime issueDate,
                                        DateTime expirationDate, string notes, float paidFees,
                                        bool isActive, EnIssueReason issueReason, int createdByUserID)
        {
            ClsBL_License license = new ClsBL_License(licenseID, applicationID, driverID, licenseClassID, issueDate,
                expirationDate, notes, paidFees, isActive, issueReason, createdByUserID)
            {
                DriverInfo = await ClsBL_Driver.Find(driverID).ConfigureAwait(false),
                LicenseClassInfo = await ClsBL_LicenseClass.Find(licenseClassID).ConfigureAwait(false),
                DetainedInfo = await ClsBL_DetainedLicense.FindByLicenseID(licenseID).ConfigureAwait(false)
            };

            return license;
        }


        public static async Task<ClsBL_License> Find(int licenseID)
        {
            ClsDA_Licenses.Data data = await ClsDA_Licenses.GetLicenseByID(licenseID);

            if (data != null && data.IsFound)
            {
                return await CreateAsync(licenseID, data.ApplicationID, data.DriverID, data.LicenseClassID, data.IssueDate,
                    data.ExpirationDate, data.Notes, data.PaidFees, data.IsActive, (EnIssueReason)data.IssueReason,
                    data.CreatedByUserID).ConfigureAwait(false);
            }
            else return null;
        }

        public static async Task<DataTable> Load()
        {
            return await ClsDA_Licenses.GetAllLicenses();
        }

        public static async Task<bool> IsExist(int licenseID)
        {
            return await ClsDA_Licenses.IsLicenseExist(licenseID);
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
            return await ClsDA_Licenses.UpdateLicense(LicenseID, IsActive);
        }

        private async Task<bool> _Add()
        {
            LicenseID = await ClsDA_Licenses.AddNewLicense(ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate,
                                                     Notes, PaidFees, IsActive, (byte)IssueReason, CreatedByUserID);
            return (LicenseID > 0);
        }

        public string GetIssueReasonText()
        {
            switch (IssueReason)
            {
                case EnIssueReason.FirstTime: return "First Time";
                case EnIssueReason.Renew: return "Renew";
                case EnIssueReason.ReplacementDamaged: return "Replacement for Damaged";
                case EnIssueReason.ReplacementLost: return "Replacement for Lost";
                default: return "Unknown";
            }
        }

        public string GetLicenseStatus()
        {
            return IsActive ? "Active" : "Not Active";
        }

        public string GetNotes()
        {
            return string.IsNullOrEmpty(Notes) ? "No Notes" : Notes;
        }

        public async Task<bool> IsDetained()
        {
            return await ClsBL_DetainedLicense.IsDetained(LicenseID);
        }

        public async Task<string> GetIsDetainedText()
        {
            return await IsDetained() ? "Yes" : "No";
        }

        public bool IsExpird()
        {
            return ExpirationDate < DateTime.Now;
        }

        public static async Task<bool> DeactivateLicenseByID(int licenseID)
        {
            return await ClsDA_Licenses.DeactivateLicenseByID(licenseID);
        }

        private async Task<bool> DeactivateCurrentLicense()
        {
            return await DeactivateLicenseByID(LicenseID);
        }

        public static async Task<int> FindPersonIDByID(int licenseID)
        {
            return await ClsDA_Licenses.GetPersonIDByID(licenseID);
        }

        public static async Task<int> GetActiveLicenseIDByPersonIDAndLicenseClassID(int applicantPersonID, int licenseClassID)
        {
            return await ClsDA_Licenses.GetActiveLicenseIDByPersonIDAndLicenseClassID(applicantPersonID, licenseClassID);
        }

        public async Task<ClsBL_License> Renew(string notes, int createdByUserID)
        {
            // First We Create Renew Application To Pay Fees Of Renew License Application
            ClsBL_Application renewApp = new ClsBL_Application
            {
                ApplicantPersonID = DriverInfo.PersonID,
                ApplicationStatus = ClsBL_Application.EnStatus.Completed,
                ApplicationTypeID = (int)ClsBL_ApplicationType.EnType.RenewDrivingLicense,
                CreatedByUserID = createdByUserID
            };

            if (!await renewApp.Save())
            {
                return null;
            }

            // Secound We Create New Licnese After Creating Rnew Application
            ClsBL_License newLicense = new ClsBL_License
            {
                ApplicationID = renewApp.ApplicationID,
                DriverID = DriverID,
                LicenseClassID = LicenseClassID,
                IssueDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears((await ClsBL_LicenseClass.Find(LicenseClassID)).DefaultValidityLength),
                Notes = notes,
                PaidFees = PaidFees,
                CreatedByUserID = createdByUserID,
                IssueReason = EnIssueReason.Renew
            };

            if (!await newLicense.Save())
            {
                return null;
            }

            await DeactivateCurrentLicense();

            return newLicense;
        }

        public async Task<ClsBL_License> Replace(ClsBL_ApplicationType.EnType replacementFor, int createdByUserID)
        {
            // First We Create Replacement Application To Pay Fees Of Replacement License
            ClsBL_Application replaceApp = new ClsBL_Application
            {
                ApplicantPersonID = DriverInfo.PersonID,
                ApplicationStatus = ClsBL_Application.EnStatus.Completed,
                ApplicationTypeID = (int)replacementFor,
                CreatedByUserID = createdByUserID
            };

            if (!await replaceApp.Save())
            {
                return null;
            }

            // Secound We Create New Licnese After Creating Replacement Application
            ClsBL_License newLicense = new ClsBL_License
            {
                ApplicationID = replaceApp.ApplicationID,
                DriverID = DriverID,
                LicenseClassID = LicenseClassID,
                IssueDate = DateTime.Now,
                ExpirationDate = ExpirationDate, // Old expiration Date because it's a replacement.
                Notes = Notes,
                PaidFees = 0, // No fees for the license because it's a replacement.
                CreatedByUserID = createdByUserID,
                IssueReason = GetIssueReason(replacementFor)
            };

            if (!await newLicense.Save())
            {
                return null;
            }

            await DeactivateCurrentLicense();

            return newLicense;
        }

        private EnIssueReason GetIssueReason(ClsBL_ApplicationType.EnType applicationType)
        {
            switch (applicationType)
            {
                case ClsBL_ApplicationType.EnType.ReplacementDamagedLicense:
                    return EnIssueReason.ReplacementDamaged;

                case ClsBL_ApplicationType.EnType.ReplacementLostLicense:
                    return EnIssueReason.ReplacementLost;

                default: return EnIssueReason.ReplacementLost;
            }
        }

        public async Task<bool> Release(int createdByUserID)
        {
            if (DetainedInfo == null || DetainedInfo.IsReleased) return false;

            // First We Create Release Application To Pay Fees Of Released License
            ClsBL_Application releaseApp = new ClsBL_Application
            {
                ApplicantPersonID = DriverInfo.PersonID,
                ApplicationStatus = ClsBL_Application.EnStatus.Completed,
                ApplicationTypeID = (int)ClsBL_ApplicationType.EnType.ReleaseDetainedLicsense,
                CreatedByUserID = createdByUserID
            };

            if (!await releaseApp.Save())
            {
                return false;
            }

            return await DetainedInfo.ReleaseLicense(createdByUserID, releaseApp.ApplicationID);
        }

        public async Task<bool> Detain(float fineFees, int createdByUserID)
        {
            ClsBL_DetainedLicense detainedLicense = new ClsBL_DetainedLicense
            {
                LicenseID = LicenseID,
                FineFees = fineFees,
                CreatedByUserID = createdByUserID
            };

            if (!await detainedLicense.Save())
            {
                return false;
            }

            DetainedInfo = detainedLicense;
            return true;
        }

        public bool IsClassOrdinary()
        {
            return LicenseClassID == (int)ClsBL_LicenseClass.EnType.Ordinary;
        }

        public static async Task<bool> IsPersonHaveActiveLicenseInSpecificClass(int personID, int licenseClassID)
        {
            return await ClsDA_Licenses.IsPersonHaveActiveLicenseInSpecificClass(personID, licenseClassID);
        }

        public static async Task<DataTable> FindLocalLicensesByID(int driverID)
        {
            return await ClsDA_Drivers.GetLicensesByID(driverID);
        }

        public async Task<DataTable> FindLocalLicenses()
        {
            return await FindLocalLicensesByID(DriverID);
        }
    }
}
