using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using DVLD_UI.Properties;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Froms
{
    public partial class FRMManageTestAppointments : KryptonForm
    {
        private int _ldlApplicationID;
        private ClsBL_TestType.EnType _testType;
        private DataTable _testAppointmentsTB;

        public FRMManageTestAppointments(int ldlApplicationID, ClsBL_TestType.EnType testType)
        {
            InitializeComponent();
            dgvTestAppointments.MouseDown += DgvTestAppointments_MouseDown;
            _ldlApplicationID = ldlApplicationID;
            _testType = testType;
        }

        private async void FRMManageTestAppointments_Load(object sender, EventArgs e)
        {
            SelectTestType();
            await LoadLDLApplicationData();
            LoadTestAppointmentsDataToDataTable();
        }

        private void SelectTestType()
        {
            switch (_testType)
            {
                case ClsBL_TestType.EnType.Vision: // Vision Test
                    LoadTestType("Vision Test Appointments", Resources.Vision);
                    break;

                case ClsBL_TestType.EnType.Written: // Writting Test
                    LoadTestType("Writting Test Appointments", Resources.Writing);
                    break;

                case ClsBL_TestType.EnType.Street: // Street Test
                    LoadTestType("Street Test Appointments", Resources.Street);
                    break;
            }
        }

        private void LoadTestType(string title, Bitmap image)
        {
            lblTestType.Text = title;
            pbTestType.Image = image;
        }

        private void LoadTestAppointmentsDataToDataTable()
        {
            _testAppointmentsTB = ClsBL_LocalDrivingLicenseApplication
                                  .LoadTestAppointmentsPerTestType(_ldlApplicationID, _testType);
            dgvTestAppointments.DataSource = _testAppointmentsTB;
        }

        private async Task LoadLDLApplicationData()
        {
            await ucldlApplicationInfo1.LoadDataByLDLApplicationID(_ldlApplicationID);
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadTestAppointmentsDataToDataTable();
        }

        private void DgvTestAppointments_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView dgv = (DataGridView)sender;
                int rowIndex = dgv.HitTest(e.X, e.Y).RowIndex;
                if (rowIndex >= 0)
                {
                    dgv.ClearSelection();
                    dgv.Rows[rowIndex].Cells[0].Selected = true;
                }
            }
        }

        private void BtnAddTestAppointment_Click(object sender, EventArgs e)
        {
            if (IsPersonHaveActiveAppointment())
            {
                MessageBox.Show("You Have Active Appointment, You Cant Add Other One", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (IsPersonPassedTest())
            {
                MessageBox.Show("You Cant Add New Appointment, Because You Passed This Test", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FRMScheduleTest scheduleTest =
                new FRMScheduleTest(_testType, ucldlApplicationInfo1.LDLApplication.LocalDrivingLicenseApplicationID);
            scheduleTest.ShowDialog();
            LoadTestAppointmentsDataToDataTable();
        }

        private bool IsPersonHaveActiveAppointment()
        {
            return ClsBL_LocalDrivingLicenseApplication
                   .IsPersonHaveActiveAppointment(_ldlApplicationID, _testType);
        }

        private bool IsPersonPassedTest()
        {
            return ClsBL_LocalDrivingLicenseApplication.IsPersonPassTest(_ldlApplicationID, _testType);
        }

        private void BtnEditTestAppointment_Click(object sender, EventArgs e)
        {
            int testAppointmentID = (int)dgvTestAppointments.CurrentRow.Cells[0].Value;

            //if (!AppointmentValid()) return;

            FRMScheduleTest scheduleTest = new FRMScheduleTest
                (_testType, ucldlApplicationInfo1.LDLApplication.LocalDrivingLicenseApplicationID, testAppointmentID);
            scheduleTest.ShowDialog();
            LoadTestAppointmentsDataToDataTable();
        }

        private bool AppointmentValid()
        {
            if (IsAppointmentLocked())
            {
                MessageBox.Show("You Cant Access This Appointment Because Is Locked [Done]", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private bool IsAppointmentLocked()
        {
            return (bool)dgvTestAppointments.CurrentRow.Cells["IsLocked"].Value;
        }

        private async void BtnTakeTest_Click(object sender, EventArgs e)
        {
            int testAppointmentID = (int)dgvTestAppointments.CurrentRow.Cells[0].Value;

            if (!AppointmentValid()) return;

            FRMTakeTest takeTest = new FRMTakeTest(testAppointmentID, _testType);
            takeTest.ShowDialog();
            LoadTestAppointmentsDataToDataTable();
            await LoadLDLApplicationData();
        }
    }
}
