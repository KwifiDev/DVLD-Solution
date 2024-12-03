using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using System;
using System.Windows.Forms;

namespace DVLD_UI.Froms
{
    public partial class FRMTakeTest : KryptonForm
    {
        private int _testAppointmentID;
        private ClsBL_TestType.EnType _testType;
        ClsBL_Test _test;

        public FRMTakeTest(int testAppointmentID, ClsBL_TestType.EnType testType)
        {
            InitializeComponent();
            _testAppointmentID = testAppointmentID;
            _testType = testType;
        }

        private void FRMTakeTest_Load(object sender, EventArgs e)
        {
            ucScheduleTestInfo1.LoadData(_testAppointmentID, _testType);

            if (ucScheduleTestInfo1.IsTestTaken)
            {
                _test = ucScheduleTestInfo1.Test;
                FillDataToControls();
                ControlsEnabeld(isEnabeld: false);
            }
            else
            {
                _test = new ClsBL_Test();
            }
        }

        private void FillDataToControls()
        {
            if (_test.TestResult) rbPassTest.Enabled = true; 
            else rbPassTest.Enabled = false;
            txtTestNotes.Text = _test.Notes;
            lblUserMassage.Visible = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            LoadDataToObject();

            if (_test.Save())
            {
                MessageBox.Show("Test Saved Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ucScheduleTestInfo1.lblTestID.Text = _test.TestID.ToString();
                ControlsEnabeld(isEnabeld: false);
            }
            else
            {
                MessageBox.Show("Falid To Save Test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ControlsEnabeld(bool isEnabeld)
        {
            rbPassTest.Enabled = isEnabeld;
            rbFailTest.Enabled = isEnabeld;
            txtTestNotes.Enabled = isEnabeld;
            btnSave.Enabled = isEnabeld;
        }

        private void LoadDataToObject()
        {
            _test.TestAppointmentID = _testAppointmentID;
            _test.TestResult = rbPassTest.Checked;
            _test.Notes = txtTestNotes.Text;
            _test.CreatedByUserID = ClsGlobal.LoginUser.UserID;
        }
    }
}
