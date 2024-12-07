using DVLD_BL;
using DVLD_UI.Properties;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.UserControls
{
    public partial class UCScheduleTest : UserControl
    {
        public enum EnMode { Add, Edit }
        public enum EnCreationMode { FirstTime, RetakeTest };

        private EnMode enMode;
        private EnCreationMode enCreationMode;

        private int _ldlApplicationID = -1;

        private string _className;
        private string _fullName;
        private byte _testTrials;

        public byte TestTrials
        {
            get { return _testTrials; }
            set
            {
                _testTrials = value;
                enCreationMode = (_testTrials > 0) ? EnCreationMode.RetakeTest : EnCreationMode.FirstTime;
            }
        }

        private ClsBL_TestType.EnType _testType;
        public ClsBL_TestType.EnType TestType
        {
            get { return _testType; }
            set
            {
                _testType = value;
                SelectTestType(_testType);
            }
        }

        private int _testAppointmentID = -1;
        private ClsBL_TestAppointment _testAppointment;

        private ClsBL_Application _retakeTestApplication;

        public UCScheduleTest()
        {
            InitializeComponent();
        }

        public async Task LoadData(int ldlApplicationID, ClsBL_TestType.EnType testType, int testAppointmentID = -1)
        {
            _testAppointmentID = testAppointmentID;
            _ldlApplicationID = ldlApplicationID;
            TestType = testType;

            _className = ClsBL_LocalDrivingLicenseApplication.GetClassNameByID(_ldlApplicationID);
            _fullName = ClsBL_LocalDrivingLicenseApplication.GetPersonFullNameByID(_ldlApplicationID);
            TestTrials = ClsBL_LocalDrivingLicenseApplication.TotalTrialsPerTest(_ldlApplicationID, _testType);


            enMode = (_testAppointmentID == -1) ? EnMode.Add : EnMode.Edit;
            btnSave.Text = (enMode == EnMode.Edit) ? "Update" : btnSave.Text;


            if (enMode == EnMode.Add)
                LoadNewData();
            else
                LoadEditData();

            if (enCreationMode == EnCreationMode.RetakeTest) await PerpareRetakeTestApplication();
        }

        private void LoadNewData()
        {
            _testAppointment = new ClsBL_TestAppointment();

            float testTypeFees = ClsBL_TestType.FindTestTypeFees(_testType);

            SetMinDateToDatePicker(DateTime.Now);

            FillDataToControls(DateTime.Now, testTypeFees);
            LoadDefaultDataToObject(testTypeFees);

            if (!HandleActiveAppointmentConstraint()) return;
            if (!HandlePreviousTestConstraint()) return;
        }

        private void LoadEditData()
        {
            _testAppointment = ClsBL_TestAppointment.Find(_testAppointmentID);

            if (_testAppointment == null) return;

            DateTime appointmentDate = _testAppointment.AppointmentDate;
            float paidFees = _testAppointment.PaidFees;

            SetMinDateToDatePicker
            (DateTime.Compare(DateTime.Now, _testAppointment.AppointmentDate) < 0 ? DateTime.Now : _testAppointment.AppointmentDate);

            FillDataToControls(appointmentDate, paidFees);

            if (!HandleAppointmentLockedConstraint(!_testAppointment.IsLocked)) return;
        }

        private void SetMinDateToDatePicker(DateTime minDate)
        {
            dtpAppointmentDate.MinDate = minDate;
        }

        private async Task PerpareRetakeTestApplication()
        {
            if (enMode == EnMode.Add)
            {
                _retakeTestApplication = new ClsBL_Application();

                int applicantPersonID = ClsBL_LocalDrivingLicenseApplication.GetPersonIDByID(_ldlApplicationID);
                float paidFess = (await ClsBL_ApplicationType.Find((int)ClsBL_ApplicationType.EnType.RetakeTest)).ApplicationFees;

                _retakeTestApplication.ApplicantPersonID = applicantPersonID;
                _retakeTestApplication.ApplicationTypeID = (int)ClsBL_ApplicationType.EnType.RetakeTest;
                _retakeTestApplication.ApplicationStatus = ClsBL_Application.EnStatus.Completed;
                _retakeTestApplication.PaidFees = paidFess;
                _retakeTestApplication.CreatedByUserID = ClsGlobal.LoginUser.UserID;
            }
            else
            {
                _retakeTestApplication = await ClsBL_Application.Find(_testAppointment.RetakeTestApplicationID);
            }

            FillRetakeTestApplicationControls();
        }

        private void FillRetakeTestApplicationControls()
        {
            if (_retakeTestApplication == null) return;

            gbRetakeTestInfo.Enabled = true;
            lblRetakeApplicationID.Text = GetRetakeTestApplicationID();
            lblRetakeApplicationFees.Text = _retakeTestApplication.PaidFees.ToString();
            lblTotalFees.Text = (_retakeTestApplication.PaidFees + _testAppointment.PaidFees).ToString();
        }

        private string GetRetakeTestApplicationID()
        {
            return _retakeTestApplication.ApplicationID != -1 ? _retakeTestApplication.ApplicationID.ToString() : "N/A";
        }

        private void LoadDefaultDataToObject(float testTypeFees)
        {
            _testAppointment.TestType = _testType;
            _testAppointment.LocalDrivingLicenseApplicationID = _ldlApplicationID;
            _testAppointment.CreatedByUserID = ClsGlobal.LoginUser.UserID;

            _testAppointment.PaidFees = testTypeFees;
        }

        private bool HandleActiveAppointmentConstraint()
        {
            if (enMode == EnMode.Edit) return true; // Else Add New Mode

            bool isThereActiveAppointment = ClsBL_LocalDrivingLicenseApplication.IsPersonHaveActiveAppointment(_ldlApplicationID, _testType);
            
            if (isThereActiveAppointment)
            {
                lblUserMessage.Text = "Person Already have an active appointment for this test";
                btnSave.Enabled = false;
                dtpAppointmentDate.Enabled = false;
                return false;
            }
            
            return true;
        }

        private bool HandleAppointmentLockedConstraint(bool isLocked)
        {
            dtpAppointmentDate.Enabled = isLocked;
            btnSave.Enabled = isLocked;
            lblUserMessage.Visible = !isLocked;
            lblUserMessage.Text = "Person Already Set For The Test, Appointment Locked.";
            return !isLocked;
        }

        private bool HandlePreviousTestConstraint()
        {
            if (enMode == EnMode.Edit) return true;

            // Ensure the person passed the previous required test before applying for the new test.
            // Vision test -> Written test -> Street test

            lblUserMessage.Visible = false;
            btnSave.Enabled = true;
            dtpAppointmentDate.Enabled = true;

            bool isTestPassed = true;
            string message = string.Empty;

            switch (_testType)
            {
                case ClsBL_TestType.EnType.Vision:
                    // No previous test required for Vision test.
                    break;

                case ClsBL_TestType.EnType.Written:
                    // Written Test requires passing the Vision test first.
                    isTestPassed = ClsBL_LocalDrivingLicenseApplication.IsPersonPassTest(_ldlApplicationID, ClsBL_TestType.EnType.Vision);
                    message = "Cannot Schedule, Vision Test should be passed first";
                    break;

                case ClsBL_TestType.EnType.Street:
                    // Street Test requires passing the Written test first.
                    isTestPassed = ClsBL_LocalDrivingLicenseApplication.IsPersonPassTest(_ldlApplicationID, ClsBL_TestType.EnType.Written);
                    message = "Cannot Schedule, Written Test should be passed first";
                    break;
            }

            if (!isTestPassed)
            {
                lblUserMessage.Text = message;
                lblUserMessage.Visible = true;
                btnSave.Enabled = false;
                dtpAppointmentDate.Enabled = false;
            }

            return isTestPassed;
        }

        private void FillDataToControls(DateTime appointmentDate, float paidFees)
        {
            lblLDLApplicationID.Text = _ldlApplicationID.ToString();
            lblClassType.Text = _className;
            lblFullName.Text = _fullName;
            lblTestTrials.Text = _testTrials.ToString();

            dtpAppointmentDate.Value = appointmentDate;
            lblPaidFees.Text = paidFees.ToString();
        }

        private void SelectTestType(ClsBL_TestType.EnType testType)
        {
            switch (testType)
            {
                case ClsBL_TestType.EnType.Vision:
                    LoadTestType("Vision Test Appointments", Resources.Vision);

                    break;

                case ClsBL_TestType.EnType.Written:
                    LoadTestType("Writting Test Appointments", Resources.Writing);

                    break;

                case ClsBL_TestType.EnType.Street:
                    LoadTestType("Street Test Appointments", Resources.Street);

                    break;
            }
        }

        private void LoadTestType(string title, Bitmap image)
        {
            gbTestAppointmentInfo.Text = title;
            pbTestType.Image = image;
        }

        private async Task<bool> HandleRetakeTestApplication()
        {
            if (enCreationMode == EnCreationMode.FirstTime) return true; // Else Retake Test

            if (await _retakeTestApplication.Save())
            {
                lblRetakeApplicationID.Text = _retakeTestApplication.ApplicationID.ToString();
                _testAppointment.RetakeTestApplicationID = _retakeTestApplication.ApplicationID;
                return true;
            }
            else
            {
                MessageBox.Show("Failed To Create Retake Test Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            SetNewDateToObject();

            if (!await HandleRetakeTestApplication()) return;

            if (_testAppointment.Save())
            {
                enMode = EnMode.Edit;
                EnabledControls(isEnabled: false);
                MessageBox.Show("Appointment Saved Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed To Save Appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnabledControls(bool isEnabled)
        {
            btnSave.Enabled = false;
            dtpAppointmentDate.Enabled = false;
        }

        private void SetNewDateToObject()
        {
            _testAppointment.AppointmentDate = dtpAppointmentDate.Value;
        }
    }
}
