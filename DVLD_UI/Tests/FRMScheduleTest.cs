using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using System;

namespace DVLD_UI.Froms
{
    public partial class FRMScheduleTest : KryptonForm
    {
        ClsBL_TestType.EnType _testType;
        int _testAppointmentID;
        int _ldlApplicationID;

        public FRMScheduleTest(ClsBL_TestType.EnType testType, int ldlApplicationID, int testAppointmentID = -1)
        {
            InitializeComponent();
            _testType = testType;
            _ldlApplicationID = ldlApplicationID;
            _testAppointmentID = testAppointmentID;
        }

        private async void FRMScheduleTest_Load(object sender, EventArgs e)
        {
            await ucScheduleTest1.LoadData(_ldlApplicationID, _testType, _testAppointmentID);
        }
    }
}
