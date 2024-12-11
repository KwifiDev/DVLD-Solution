using DVLD_BL;
using DVLD_UI.Properties;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.UserControls
{
    public partial class UCScheduleTestInfo : UserControl
    {
        

        ClsBL_TestAppointment _testAppointment;

        private ClsBL_Test _test;
        public ClsBL_Test Test 
        { 
            get { return _test; }
            set 
            {
                _test = value;
                IsTestTaken = _test != null;
            }
        }

        public bool IsTestTaken { get; private set; }

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

        public UCScheduleTestInfo()
        {
            InitializeComponent();
        }

        public async Task LoadData(int testAppointmentID, ClsBL_TestType.EnType testType)
        {

            _testType = testType;
            _testAppointment = ClsBL_TestAppointment.Find(testAppointmentID);

            if (_testAppointment == null) return;

            Test = ClsBL_Test.Find(testAppointmentID);

            int ldlApplicationID = _testAppointment.LocalDrivingLicenseApplicationID;
            string className = await ClsBL_LocalDrivingLicenseApplication.GetClassNameByID(ldlApplicationID);
            string fullName = await ClsBL_LocalDrivingLicenseApplication.GetPersonFullNameByID(ldlApplicationID);
            int testTrials = ClsBL_LocalDrivingLicenseApplication.TotalTrialsPerTest(ldlApplicationID, testType);
            DateTime appointmentDate = _testAppointment.AppointmentDate;
            float paidFees = _testAppointment.PaidFees;

            FillDataToControls(ldlApplicationID, className, fullName, testTrials, appointmentDate, paidFees);
        }

        private void FillDataToControls(int lDLApplicationID, string classType, string fullName, int testTrials, DateTime appointmentDate, float paidFees)
        {
            lblLDLApplicationID.Text = lDLApplicationID.ToString();
            lblClassType.Text = classType;
            lblFullName.Text = fullName;
            lblTestTrials.Text = testTrials.ToString();
            lblAppointmentDate.Text = appointmentDate.ToShortDateString();
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

    }
}
