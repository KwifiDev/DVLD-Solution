using DVLD_DA;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DVLD_BL
{
    public class ClsBL_LocalDrivingLicenseApplication : ClsBL_Application
    {
        new enum EnMode { Add, Update }
        new EnMode enMode;

        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public ClsBL_LicenseClass LicenseClassInfo { get; private set; }

        public ClsBL_LocalDrivingLicenseApplication()
        {
            LocalDrivingLicenseApplicationID = -1;
            LicenseClassID = -1;
            enMode = EnMode.Add;
        }

        private ClsBL_LocalDrivingLicenseApplication(int localDrivingLicenseApplicationID, int applicationID,
            int licenseClassID, int applicantPersonID, DateTime applicationDate, int applicationTypeID,
            EnStatus applicationStatus, DateTime lastStatusDate, float paidFees, int createdByUserID)
            : base(applicationID, applicantPersonID, applicationDate, applicationTypeID,
                    applicationStatus, lastStatusDate, paidFees, createdByUserID)
        {
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            ApplicationID = applicationID;
            LicenseClassID = licenseClassID;
            enMode = EnMode.Update;
        }

        public static async Task<ClsBL_LocalDrivingLicenseApplication> CreateAsync(int localDrivingLicenseApplicationID, int applicationID,
        int licenseClassID, int applicantPersonID, DateTime applicationDate, int applicationTypeID,
        EnStatus applicationStatus, DateTime lastStatusDate, float paidFees, int createdByUserID)
        {
            ClsBL_LocalDrivingLicenseApplication licenseApplication = new ClsBL_LocalDrivingLicenseApplication(localDrivingLicenseApplicationID, applicationID,
                licenseClassID, applicantPersonID, applicationDate, applicationTypeID, applicationStatus,
                lastStatusDate, paidFees, createdByUserID)

            {
                // Initialize Base OBJ
                ApplicantPersonInfo = await ClsBL_Person.Find(applicantPersonID),
                UserInfo = await ClsBL_User.Find(createdByUserID),
                ApplicationTypeInfo = await ClsBL_ApplicationType.Find(applicationTypeID),

                // Initialize Sub OBJ
                LicenseClassInfo = await ClsBL_LicenseClass.Find(licenseClassID)
            };
            
            return licenseApplication;
        }

        public new static async Task<ClsBL_LocalDrivingLicenseApplication> Find(int localDrivingLicenseApplicationID)
        {

            ClsDA_LocalDrivingLicenseApplications.Data data = await ClsDA_LocalDrivingLicenseApplications.
                GetLocalDrivingLicenseApplicationByID(localDrivingLicenseApplicationID);

            if (data != null && data.IsFound)
            {
                ClsBL_Application app = await ClsBL_Application.Find(data.ApplicationID);

                return await CreateAsync(localDrivingLicenseApplicationID, data.ApplicationID, data.LicenseClassID,
                    app.ApplicantPersonID, app.ApplicationDate, app.ApplicationTypeID, app.ApplicationStatus,
                    app.LastStatusDate, app.PaidFees, app.CreatedByUserID).ConfigureAwait(false);
            }
            else return null;
        }

        public static async Task<ClsBL_LocalDrivingLicenseApplication> FindByApplicationID(int applicationID)
        {

            ClsDA_LocalDrivingLicenseApplications.Data data = await ClsDA_LocalDrivingLicenseApplications.
                 GetLocalDrivingLicenseApplicationByLDLApplicationID(applicationID);

            if (data != null && data.IsFound)
            {
                ClsBL_Application app = await ClsBL_Application.Find(applicationID);

                return await CreateAsync(data.LocalDrivingLicenseApplicationID, applicationID, data.LicenseClassID,
                    app.ApplicantPersonID, app.ApplicationDate, app.ApplicationTypeID, app.ApplicationStatus,
                    app.LastStatusDate, app.PaidFees, app.CreatedByUserID).ConfigureAwait(false);
            }
            else return null;
        }

        public new static async Task<DataTable> Load()
        {
            return await ClsDA_LocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications();
        }

        public static async Task<DataTable> LoadView()
        {
            return await ClsDA_LocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications_View();
        }

        public new static async Task<bool> IsExist(int localDrivingLicenseApplicationID)
        {
            return await ClsDA_LocalDrivingLicenseApplications.IsLocalDrivingLicenseApplicationExist(localDrivingLicenseApplicationID);
        }

        public static async Task<int> GetActiveApplicationID(int personID, int licenseClassID)
        {
            return await ClsDA_LocalDrivingLicenseApplications.IsPersonHasLocalDrivingLicenseApplicationWithSameClass
                                                               (personID, licenseClassID);
        }

        public static async Task<bool> IsPersonCanCreateLDLApp(int personID, int licenseClassID)
        {
            return (await GetActiveApplicationID(personID, licenseClassID)) > 0;
        }

        public new async Task<bool> Save()
        {
            //Because of inheritance first we call the save method in the base class,
            //It Will Take care of adding all information to the application table.

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
            return await ClsDA_LocalDrivingLicenseApplications.UpdateLocalDrivingLicenseApplication
                (LocalDrivingLicenseApplicationID, LicenseClassID);
        }

        private async Task<bool> _Add()
        {
            LocalDrivingLicenseApplicationID =  await ClsDA_LocalDrivingLicenseApplications.
                                                AddNewLocalDrivingLicenseApplication(ApplicationID, LicenseClassID);

            return (LocalDrivingLicenseApplicationID != -1);
        }

        public new static async Task<bool> Delete(int localDrivingLicenseApplicationID)
        {
            int applicationID = await FindApplicationIDByID(localDrivingLicenseApplicationID);

            return await ClsDA_LocalDrivingLicenseApplications.
                   DeleteFullApplication(localDrivingLicenseApplicationID, applicationID);
        }

        private new async Task<bool> Delete()
        {
            //First we delete the Local Driving License Application
            bool isLDLApplcationDeleted = await ClsDA_LocalDrivingLicenseApplications.
                                          DeleteLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);

            if (!isLDLApplcationDeleted) return false;

            //Then we delete the base Application
            return await base.Delete();

        }

        public static async Task<bool> CancelApplicationByID(int localDrivingLicenseApplicationID)
        {
            return await ClsDA_LocalDrivingLicenseApplications.CancelLDLApplicationByID(localDrivingLicenseApplicationID);
        }

        public async Task<bool> CancelApplication()
        {
            return await CancelApplicationByID(LocalDrivingLicenseApplicationID);
        }

        public static async Task<int> GetPassedTestsByLDLApplicationID(int localDrivingLicenseApplicationID)
        {
            return await ClsDA_LocalDrivingLicenseApplications.GetPassedTestsCount(localDrivingLicenseApplicationID);
        }

        public async Task<int> GetPassedTests()
        {
            return await GetPassedTestsByLDLApplicationID(LocalDrivingLicenseApplicationID);
        }

        public static async Task<string> GetClassNameByID(int localDrivingLicenseApplicationID)
        {
            return await ClsBL_LicenseClass.GetLicenseClassNameByLDLApplicationID(localDrivingLicenseApplicationID);
        }

        public static async Task<int> GetActiveLicenseIDByLDLApplicationID(int localDrivingLicenseApplicationID)
        {
            return await (await Find(localDrivingLicenseApplicationID)).GetActiveLicenseID();
        }

        public async Task<int> GetActiveLicenseID()
        {
            return await ClsBL_License.GetActiveLicenseIDByPersonIDAndLicenseClassID(ApplicantPersonID, LicenseClassID);
        }

        public static async Task<int> FindApplicationIDByID(int localDrivingLicenseApplicationID)
        {
            return await ClsDA_LocalDrivingLicenseApplications.GetApplicationIDByID(localDrivingLicenseApplicationID);
        }

        public async Task<bool> IsLicenseIssued()
        {
            return (await GetActiveLicenseID() != -1);
        }

        public async Task<bool> IsPersonPassTest(ClsBL_TestType.EnType testType)
        {
            return await ClsDA_LocalDrivingLicenseApplications.IsPersonPassTest(LocalDrivingLicenseApplicationID, (int)testType);
        }

        public static async Task<bool> IsPersonPassTest(int localDrivingLicenseApplicationID, ClsBL_TestType.EnType testType)
        {
            return await ClsDA_LocalDrivingLicenseApplications.IsPersonPassTest(localDrivingLicenseApplicationID, (int)testType);
        }

        public async Task<bool> IsPersonPassPreviousTest(ClsBL_TestType.EnType currentTestType)
        {

            switch (currentTestType)
            {
                case ClsBL_TestType.EnType.Vision:
                    //in this case no required prvious test to pass.
                    return true;

                case ClsBL_TestType.EnType.Written:
                    //Written Test, you cannot sechdule it before person passes the vision test.
                    //we check if pass visiontest 1.

                    return await IsPersonPassTest(ClsBL_TestType.EnType.Vision);


                case ClsBL_TestType.EnType.Street:

                    //Street Test, you cannot sechdule it before person passes the written test.
                    //we check if pass Written 2.
                    return await IsPersonPassTest(ClsBL_TestType.EnType.Written);

                default:
                    return false;
            }
        }

        public byte TotalTrialsPerTest(ClsBL_TestType.EnType testType)
        {
            return TotalTrialsPerTest(LocalDrivingLicenseApplicationID, testType);
        }

        public static byte TotalTrialsPerTest(int localDrivingLicenseApplicationID, ClsBL_TestType.EnType testType)
        {
            return ClsDA_Tests.TotalTrialsPerTest(localDrivingLicenseApplicationID, (int)testType);
        }

        public bool IsPersonHaveActiveAppointment(ClsBL_TestType.EnType testType)
        {
            return ClsDA_TestAppointments.IsPersonHaveActiveAppointment(LocalDrivingLicenseApplicationID, (int)testType);
        }

        public static bool IsPersonHaveActiveAppointment(int localDrivingLicenseApplicationID, ClsBL_TestType.EnType testType)
        {
            return ClsDA_TestAppointments.IsPersonHaveActiveAppointment(localDrivingLicenseApplicationID, (int)testType);
        }

        public static DataTable LoadTestAppointmentsPerTestType(int localDrivingLicenseApplicationID, ClsBL_TestType.EnType testType)
        {
            return ClsDA_TestAppointments.GetTestAppointmentsPerTestType(localDrivingLicenseApplicationID, (int)testType);
        }

        public static async Task<string> GetPersonFullNameByID(int localDrivingLicenseApplicationID)
        {
            return await ClsDA_LocalDrivingLicenseApplications.GetFullNameByLDLApplicationID(localDrivingLicenseApplicationID);
        }

        public async Task<string> GetPersonFullName()
        {
            return await ClsDA_LocalDrivingLicenseApplications.GetFullNameByLDLApplicationID(LocalDrivingLicenseApplicationID);
        }

        public static async Task<int> GetPersonIDByID(int localDrivingLicenseApplicationID)
        {
            return await ClsDA_LocalDrivingLicenseApplications.GetPersonIDByLDLApplicationID(localDrivingLicenseApplicationID);
        }

        public async Task<int> GetPersonID()
        {
            return await ClsDA_LocalDrivingLicenseApplications.GetPersonIDByLDLApplicationID(LocalDrivingLicenseApplicationID);
        }

        public static async Task<bool> IsPersonPassedAllTests(int ldlApplicationID)
        {
            return await IsPersonPassTest(ldlApplicationID, ClsBL_TestType.EnType.Vision) &&
                   await IsPersonPassTest(ldlApplicationID, ClsBL_TestType.EnType.Written) &&
                   await IsPersonPassTest(ldlApplicationID, ClsBL_TestType.EnType.Street);
        }

        public async Task<bool> IsPassedAllTests()
        {
            return (await GetPassedTests()) == 3;
        }

        public async Task<bool> IsPersonHaveActiveLicense()
        {
            return await GetActiveLicenseID() > 0;
        }

        public async Task<int> IssueLicenseFirstTime(string notes, int createdByUserID)
        {
            int driverID = await ClsBL_Person.MakePersonBecomeDriver(ApplicantPersonID, createdByUserID);
            if (driverID == -1) return -1;

            ClsBL_License license = new ClsBL_License
            {
                ApplicationID = ApplicationID,
                DriverID = driverID,
                LicenseClassID = LicenseClassID,
                IssueDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears((await ClsBL_LicenseClass.Find(LicenseClassID)).DefaultValidityLength),
                Notes = notes,
                PaidFees = LicenseClassInfo.ClassFees,
                IssueReason = ClsBL_License.EnIssueReason.FirstTime,
                CreatedByUserID = createdByUserID
            };


            if (await license.Save())
            {
                await SetApplicationComplete();
                return license.LicenseID;
            }

            return -1;
        }

        public async Task<string> GetAppliedLicense()
        {
            return await ClsDA_LicenseClasses.GetLicenseClassNameByID(LicenseClassID);
        }
    }
}
