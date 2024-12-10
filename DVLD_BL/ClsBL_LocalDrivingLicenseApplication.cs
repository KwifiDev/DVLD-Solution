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
            int applicationID = -1, licenseClassID = -1;

            bool isFound = ClsDA_LocalDrivingLicenseApplications.
                GetLocalDrivingLicenseApplicationByID(localDrivingLicenseApplicationID, ref applicationID, ref licenseClassID);

            if (isFound)
            {
                ClsBL_Application app = await ClsBL_Application.Find(applicationID);

                return await CreateAsync
                    (localDrivingLicenseApplicationID, applicationID, licenseClassID, app.ApplicantPersonID,
                    app.ApplicationDate, app.ApplicationTypeID, app.ApplicationStatus, app.LastStatusDate, app.PaidFees, app.CreatedByUserID).ConfigureAwait(false);
            }
            else return null;
        }

        public static async Task<ClsBL_LocalDrivingLicenseApplication> FindByApplicationID(int applicationID)
        {
            int localDrivingLicenseApplicationID = -1, licenseClassID = -1;

            bool isFound = ClsDA_LocalDrivingLicenseApplications.
                GetLocalDrivingLicenseApplicationByLDLApplicationID(ref localDrivingLicenseApplicationID, applicationID, ref licenseClassID);

            if (isFound)
            {
                ClsBL_Application app = await ClsBL_Application.Find(applicationID);

                return new ClsBL_LocalDrivingLicenseApplication
                    (localDrivingLicenseApplicationID, applicationID, licenseClassID, app.ApplicantPersonID,
                    app.ApplicationDate, app.ApplicationTypeID, app.ApplicationStatus, app.LastStatusDate, app.PaidFees, app.CreatedByUserID);
            }
            else return null;
        }

        public new static DataTable Load()
        {
            return ClsDA_LocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications();
        }

        public static DataTable LoadView()
        {
            return ClsDA_LocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications_View();
        }

        public new static bool IsExist(int localDrivingLicenseApplicationID)
        {
            return ClsDA_LocalDrivingLicenseApplications.IsLocalDrivingLicenseApplicationExist(localDrivingLicenseApplicationID);
        }

        public static int GetActiveApplicationID(int personID, int licenseClassID)
        {
            return ClsDA_LocalDrivingLicenseApplications.IsPersonHasLocalDrivingLicenseApplicationWithSameClass
                (personID, licenseClassID);
        }

        public static bool IsPersonCanCreateLDLApp(int personID, int licenseClassID)
        {
            return GetActiveApplicationID(personID, licenseClassID) > 0;
        }

        public new async Task<bool> Save()
        {
            //Because of inheritance first we call the save method in the base class,
            //It Will Take care of adding all information to the application table.

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
            return ClsDA_LocalDrivingLicenseApplications.UpdateLocalDrivingLicenseApplication
                (LocalDrivingLicenseApplicationID, LicenseClassID);
        }

        private bool _Add()
        {
            LocalDrivingLicenseApplicationID = ClsDA_LocalDrivingLicenseApplications.
                                                AddNewLocalDrivingLicenseApplication(ApplicationID, LicenseClassID);

            return (LocalDrivingLicenseApplicationID != -1);
        }

        public new static bool Delete(int localDrivingLicenseApplicationID)
        {
            int applicationID = FindApplicationIDByID(localDrivingLicenseApplicationID);

            return ClsDA_LocalDrivingLicenseApplications.
                   DeleteFullApplication(localDrivingLicenseApplicationID, applicationID);
        }

        private new async Task<bool> Delete()
        {
            //First we delete the Local Driving License Application
            bool isLDLApplcationDeleted = ClsDA_LocalDrivingLicenseApplications.
                                            DeleteLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);

            if (!isLDLApplcationDeleted) return false;

            //Then we delete the base Application
            return await base.Delete();

        }

        public static bool CancelApplicationByID(int localDrivingLicenseApplicationID)
        {
            return ClsDA_LocalDrivingLicenseApplications.CancelLDLApplicationByID(localDrivingLicenseApplicationID);
        }

        public bool CancelApplication()
        {
            return CancelApplicationByID(LocalDrivingLicenseApplicationID);
        }

        public static int GetPassedTestsByLDLApplicationID(int localDrivingLicenseApplicationID)
        {
            return ClsDA_LocalDrivingLicenseApplications.GetPassedTestsCount(localDrivingLicenseApplicationID);
        }

        public int GetPassedTests()
        {
            return GetPassedTestsByLDLApplicationID(LocalDrivingLicenseApplicationID);
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

        public static int FindApplicationIDByID(int localDrivingLicenseApplicationID)
        {
            return ClsDA_LocalDrivingLicenseApplications.GetApplicationIDByID(localDrivingLicenseApplicationID);
        }

        public async Task<bool> IsLicenseIssued()
        {
            return (await GetActiveLicenseID() != -1);
        }

        public bool IsPersonPassTest(ClsBL_TestType.EnType testType)
        {
            return ClsDA_LocalDrivingLicenseApplications.IsPersonPassTest(LocalDrivingLicenseApplicationID, (int)testType);
        }

        public static bool IsPersonPassTest(int localDrivingLicenseApplicationID, ClsBL_TestType.EnType testType)
        {
            return ClsDA_LocalDrivingLicenseApplications.IsPersonPassTest(localDrivingLicenseApplicationID, (int)testType);
        }

        public bool IsPersonPassPreviousTest(ClsBL_TestType.EnType currentTestType)
        {

            switch (currentTestType)
            {
                case ClsBL_TestType.EnType.Vision:
                    //in this case no required prvious test to pass.
                    return true;

                case ClsBL_TestType.EnType.Written:
                    //Written Test, you cannot sechdule it before person passes the vision test.
                    //we check if pass visiontest 1.

                    return IsPersonPassTest(ClsBL_TestType.EnType.Vision);


                case ClsBL_TestType.EnType.Street:

                    //Street Test, you cannot sechdule it before person passes the written test.
                    //we check if pass Written 2.
                    return IsPersonPassTest(ClsBL_TestType.EnType.Written);

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

        public static string GetPersonFullNameByID(int localDrivingLicenseApplicationID)
        {
            return ClsDA_LocalDrivingLicenseApplications.GetFullNameByLDLApplicationID(localDrivingLicenseApplicationID);
        }

        public string GetPersonFullName()
        {
            return ClsDA_LocalDrivingLicenseApplications.GetFullNameByLDLApplicationID(LocalDrivingLicenseApplicationID);
        }

        public static int GetPersonIDByID(int localDrivingLicenseApplicationID)
        {
            return ClsDA_LocalDrivingLicenseApplications.GetPersonIDByLDLApplicationID(localDrivingLicenseApplicationID);
        }

        public int GetPersonID()
        {
            return ClsDA_LocalDrivingLicenseApplications.GetPersonIDByLDLApplicationID(LocalDrivingLicenseApplicationID);
        }

        public static bool IsPersonPassedAllTests(int ldlApplicationID)
        {
            return IsPersonPassTest(ldlApplicationID, ClsBL_TestType.EnType.Vision) &&
                    IsPersonPassTest(ldlApplicationID, ClsBL_TestType.EnType.Written) &&
                    IsPersonPassTest(ldlApplicationID, ClsBL_TestType.EnType.Street);
        }

        public bool IsPassedAllTests()
        {
            return GetPassedTests() == 3;
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
