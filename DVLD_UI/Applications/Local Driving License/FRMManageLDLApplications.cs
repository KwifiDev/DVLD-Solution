using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static DVLD_UI.ClsGlobal;
using static DVLD_BL.ClsBL_User;
using System.Threading.Tasks;

namespace DVLD_UI.Froms
{
    public partial class FRMManageLDLApplications : KryptonForm
    {
        private static DataTable _fullLDLApplicationTB;

        public FRMManageLDLApplications()
        {
            InitializeComponent();
            dgvApplication.MouseDown += DgvApplication_MouseDown;
        }

        private async void FRMManageApplications_Load(object sender, EventArgs e)
        {
            await LoadApplicationDataToDataTable();
            InitializePermissions();
        }

        private void InitializePermissions()
        {
            btnAddApplication.Enabled = IsUserCanAccessTo[EnPermissions.AddNewLocalLicenseApplication];
            btnShowPersonLicenseHistory.Enabled = IsUserCanAccessTo[EnPermissions.PersonLicenseHistory];
        }

        private async Task LoadApplicationDataToDataTable()
        {
            _fullLDLApplicationTB = await ClsBL_LocalDrivingLicenseApplication.LoadView();

            dgvApplication.DataSource = _fullLDLApplicationTB;
            ucFilter1.LinkFilterWithDataTable(ref _fullLDLApplicationTB);
        }

        private void DgvApplication_MouseDown(object sender, MouseEventArgs e)
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

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await LoadApplicationDataToDataTable();
        }

        private async Task AddEditLDLApp(bool isEdit)
        {
            if (isEdit)
            {
                int ldlApplicationID = (int)dgvApplication.CurrentRow.Cells[0].Value;
                EditLDLApp(ldlApplicationID);
            }
            else
            {
                AddLDLApp();
            }

            await LoadApplicationDataToDataTable();
        }

        private void AddLDLApp()
        {
            FRMNewLocalDrivingLicenseApplication newLocalDrvingLicense = new FRMNewLocalDrivingLicenseApplication();
            newLocalDrvingLicense.ShowDialog();
        }

        private void EditLDLApp(int localDrivingLicenseApplicationID)
        {
            FRMNewLocalDrivingLicenseApplication newLocalDrvingLicense =
            new FRMNewLocalDrivingLicenseApplication(localDrivingLicenseApplicationID);
            newLocalDrvingLicense.ShowDialog();
        }

        private async void BtnAddApplication_Click(object sender, EventArgs e)
        {
            await AddEditLDLApp(isEdit: false);
        }

        private async void BtnEditApplication_Click(object sender, EventArgs e)
        {
            await AddEditLDLApp(isEdit: true);
        }

        private async void BtnDeleteApplication_Click(object sender, EventArgs e)
        {
            int localDrivingLicenseApplicationID = (int)dgvApplication.CurrentRow.Cells[0].Value;

            if (!await ClsBL_LocalDrivingLicenseApplication.IsExist(localDrivingLicenseApplicationID))
            {
                MessageBox.Show("LDL Application Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are You Sure Do You Want To Delete This Record", "Confrim", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;


            if (await ClsBL_LocalDrivingLicenseApplication.Delete(localDrivingLicenseApplicationID))
            {
                MessageBox.Show("LDL Application Deleted Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadApplicationDataToDataTable();
            }
            else
            {
                MessageBox.Show("Failed To Delete LDL Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnShowApplicationDetails_Click(object sender, EventArgs e)
        {
            int localDrivingLicenseApplicationID = (int)dgvApplication.CurrentRow.Cells[0].Value;

            FRMLDLApplictionInfo applictionInfo = new FRMLDLApplictionInfo(localDrivingLicenseApplicationID);
            applictionInfo.ShowDialog();
        }

        private async void BtnCancelApplication_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalDrivingLicenseApplicationID = (int)dgvApplication.CurrentRow.Cells[0].Value;

            if (await ClsBL_LocalDrivingLicenseApplication.CancelApplicationByID(LocalDrivingLicenseApplicationID))
            {
                MessageBox.Show("This application canceled Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadApplicationDataToDataTable();
            }
            else
            {
                MessageBox.Show("Cant Canceled This Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ContextMenu_Opening(object sender, CancelEventArgs e)
        {
            ExtractStatusAndTestCount(out string applicationStatus, out int testCount);
            SetButtonsStatesBasedOnStatus(applicationStatus, testCount);
        }

        private void ExtractStatusAndTestCount(out string applicationStatus, out int passedtestCount)
        {
            applicationStatus = (string)dgvApplication.CurrentRow.Cells["Status"].Value;
            passedtestCount = (int)dgvApplication.CurrentRow.Cells["PassedTestCount"].Value;
        }

        private void SetButtonsStatesBasedOnStatus(string applicationStatus, int passedtestCount)
        {
            bool isNew = applicationStatus == "New";
            bool isCompleted = applicationStatus == "Completed";

            // Set Buttons states based on application status
            btnEditApplication.Enabled = isNew && IsUserCanAccessTo[EnPermissions.EditLDLApplication];
            btnDeleteApplication.Enabled = isNew && IsUserCanAccessTo[EnPermissions.DeleteLDLApplication];
            btnCancelApplication.Enabled = isNew && IsUserCanAccessTo[EnPermissions.CancelLDLApplication];
            btnScheduleTest.Enabled = isNew && IsUserCanAccessTo[EnPermissions.SchedulingTests];
            btnShowLicense.Enabled = isCompleted;
            btnIssueDrvingLicense.Enabled = ((isNew && passedtestCount == 3) && IsUserCanAccessTo[EnPermissions.IssueLocalLicense]);

            if (isNew) SetScheduleTestMenuStates(passedtestCount);
        }

        private void SetScheduleTestMenuStates(int passedtestCount)
        {
            bool isUserHavePermission = IsUserCanAccessTo[EnPermissions.SchedulingTests];

            //Enable-Disable Schedule menu and it's sub menue
            if (btnScheduleTest.Enabled = (passedtestCount < 3 && isUserHavePermission))
            {
                btnVisionTest.Enabled = passedtestCount == 0; //Not Passed Vision Test
                btnWrittenTheoryTest.Enabled = passedtestCount == 1; //Passed Writting Test, Not Passed Vision Test
                btnPracticalStreetTest.Enabled = passedtestCount == 2; //Passed Writting, Vision Test, Not Passed Street Test
            }
        }

        private async void BtnTest_Click(object sender, EventArgs e)
        {
            ClsBL_TestType.EnType testType = (ClsBL_TestType.EnType)Convert.ToInt16(((ToolStripMenuItem)sender).Tag);
            int localDrivingLicenseApplicationID = (int)dgvApplication.CurrentRow.Cells[0].Value;

            await ScheduleTestAppointment(localDrivingLicenseApplicationID, testType);
        }

        private async Task ScheduleTestAppointment(int localDrivingLicenseApplicationID, ClsBL_TestType.EnType testType)
        {
            FRMManageTestAppointments manageTestAppointments = new FRMManageTestAppointments(localDrivingLicenseApplicationID, testType);
            manageTestAppointments.ShowDialog();
            await LoadApplicationDataToDataTable();
        }

        private async void BtnIssueDrvingLicense_Click(object sender, EventArgs e)
        {
            int localDrivingLicenseApplicationID = (int)dgvApplication.CurrentRow.Cells[0].Value;

            FRMIssueDrivingLicneseFirstTime issueDrivingLicnese = new FRMIssueDrivingLicneseFirstTime(localDrivingLicenseApplicationID);
            issueDrivingLicnese.ShowDialog();
            await LoadApplicationDataToDataTable();

        }

        private async void BtnShowLicense_Click(object sender, EventArgs e)
        {
            int ldlApplicationID = (int)dgvApplication.CurrentRow.Cells[0].Value;

            int licneseID = await ClsBL_LocalDrivingLicenseApplication.GetActiveLicenseIDByLDLApplicationID(ldlApplicationID);

            if (licneseID != -1)
            {
                FRMLicenseInfo licenseInfo = new FRMLicenseInfo(licneseID);
                licenseInfo.ShowDialog();
            }
            else
            {
                MessageBox.Show("Cant Find The License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            int ldlApplicationID = (int)dgvApplication.CurrentRow.Cells[0].Value;

            int personID = await ClsBL_LocalDrivingLicenseApplication.GetPersonIDByID(ldlApplicationID);

            FRMPersonLicenseHistory personLicenseHistory = new FRMPersonLicenseHistory(personID);

            personLicenseHistory.ShowDialog();
        }


    }
}
