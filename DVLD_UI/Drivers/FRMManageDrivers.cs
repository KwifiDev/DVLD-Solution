using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_BL.ClsBL_User;
using static DVLD_UI.ClsGlobal;

namespace DVLD_UI.Froms
{
    public partial class FRMManageDrivers : KryptonForm
    {
        private static DataTable _fullDriversTB;

        public FRMManageDrivers()
        {
            InitializeComponent();
            dgvDrivers.MouseDown += DgvDrivers_MouseDown;

        }

        private async void FRMManageUsers_Load(object sender, EventArgs e)
        {
            await LoadDriversDataToGridView();
            InitializePermissions();
        }

        private void InitializePermissions()
        {
            btnIssueInternationalLicense.Enabled = IsUserCanAccessTo[EnPermissions.IssueInternationalLicense];
            btnPersonLicenseHistory.Enabled = IsUserCanAccessTo[EnPermissions.PersonLicenseHistory];
        }

        private async Task LoadDriversDataToGridView()
        {
            _fullDriversTB = await ClsBL_Driver.LoadView();

            dgvDrivers.DataSource = _fullDriversTB;
            ucFilter1.LinkFilterWithDataTable(ref _fullDriversTB);
        }

        private void DgvDrivers_MouseDown(object sender, MouseEventArgs e)
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

        private async void BtnShowPersonDetails_Click(object sender, EventArgs e)
        {
            await ShowPersonDetails();
        }

        private async Task ShowPersonDetails()
        {
            int personID = (int)dgvDrivers.CurrentRow.Cells[1].Value;
            FRMPersonDetails personDetails = new FRMPersonDetails(personID);
            personDetails.ShowDialog();
            await LoadDriversDataToGridView();
        }

        private void BtnPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            int personID = (int)dgvDrivers.CurrentRow.Cells[1].Value;
            FRMPersonLicenseHistory personLicenseHistory = new FRMPersonLicenseHistory(personID);
            personLicenseHistory.ShowDialog();
        }

        private async void BtnIssueInternationalLicense_Click(object sender, EventArgs e)
        {

            int driverID = (int)dgvDrivers.CurrentRow.Cells[0].Value;

            int licenseID = await ClsBL_Driver.FindLicenseIDThatHaveActiveOrdinaryLicenseByID(driverID);

            if (licenseID == -1)
            {
                MessageBox.Show("This Driver Does Not Have An Active Ordinary License", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (await ClsBL_Driver.IsDriverHaveActiveInternationalLicense(driverID))
            {
                MessageBox.Show("This Driver Already Have An Active International License", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FRMNewInternationalLicenseApplication newInternationalLicense = new FRMNewInternationalLicenseApplication(licenseID);
            newInternationalLicense.ShowDialog();
        }


    }
}
