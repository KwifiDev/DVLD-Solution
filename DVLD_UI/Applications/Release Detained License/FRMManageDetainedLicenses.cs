using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using DVLD_UI.Froms;
using System;
using System.Data;
using System.Windows.Forms;
using static DVLD_UI.ClsGlobal;
using static DVLD_BL.ClsBL_User;


namespace DVLD_UI
{
    public partial class FRMManageDetainedLicenses : KryptonForm
    {
        DataTable _allDetainedLicenseTB;

        public FRMManageDetainedLicenses()
        {
            InitializeComponent();
            dgvDetainedLicenses.MouseDown += DgvDetainedLicenses_MouseDown;
        }

        private void LoadDetainedLicensesDataToGridView()
        {
            _allDetainedLicenseTB = ClsBL_DetainedLicense.LoadView();

            dgvDetainedLicenses.DataSource = _allDetainedLicenseTB;
            ucFilter1.LinkFilterWithDataTable(ref _allDetainedLicenseTB);
        }

        private void FRMManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            LoadDetainedLicensesDataToGridView();
            InitializePermissions();
        }

        private void InitializePermissions()
        {
            btnDetainLicense.Enabled = IsUserCanAccessTo[EnPermissions.DetainLicense];
            btnReleaseDetainedLicense.Enabled = IsUserCanAccessTo[EnPermissions.ReleaseDetainedLicense];
            btnReleaseLicense.Enabled = IsUserCanAccessTo[EnPermissions.ReleaseDetainedLicense];
            btnShowPersonLicenseHistory.Enabled = IsUserCanAccessTo[EnPermissions.PersonLicenseHistory];
        }

        private void DgvDetainedLicenses_MouseDown(object sender, MouseEventArgs e)
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

        private int GetPersonID()
        {
            int licenseID = (int)dgvDetainedLicenses.CurrentRow.Cells["LicenseID"].Value;
            return ClsBL_License.FindPersonIDByID(licenseID);
        }

        private void ShowPersonDetails()
        {
            int personID = GetPersonID();

            FRMPersonDetails personDetails = new FRMPersonDetails(personID);
            personDetails.ShowDialog();
            LoadDetainedLicensesDataToGridView();
        }

        private void BtnShowPersonDetails_Click(object sender, EventArgs e)
        {
            ShowPersonDetails();
        }

        private void BtnReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            int licenseID = (int)dgvDetainedLicenses.CurrentRow.Cells["LicenseID"].Value;

            if (!ClsBL_DetainedLicense.IsDetained(licenseID))
            {
                MessageBox.Show("This License Already Released", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FRMReleaseLicenseApplication releaseLicense = new FRMReleaseLicenseApplication(licenseID);
            releaseLicense.ShowDialog();
            LoadDetainedLicensesDataToGridView();
        }

        private void BtnShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            int personID = GetPersonID();

            FRMPersonLicenseHistory personLicenseHistory = new FRMPersonLicenseHistory(personID);
            personLicenseHistory.ShowDialog();
        }

        private void BtnShowLicenseDetails_Click(object sender, EventArgs e)
        {
            int licenseID = (int)dgvDetainedLicenses.CurrentRow.Cells["LicenseID"].Value;
            FRMLicenseInfo licenseInfo = new FRMLicenseInfo(licenseID);
            licenseInfo.ShowDialog();
        }

        private void BtnDetainLicense_Click(object sender, EventArgs e)
        {
            FRMDetainLicense detainLicense = new FRMDetainLicense();
            detainLicense.ShowDialog();
            LoadDetainedLicensesDataToGridView();
        }

        private void BtnReleaseLicense_Click(object sender, EventArgs e)
        {
            FRMReleaseLicenseApplication releaseLicenseApplication = new FRMReleaseLicenseApplication();
            releaseLicenseApplication.ShowDialog();
            LoadDetainedLicensesDataToGridView();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadDetainedLicensesDataToGridView();
        }

        private void ContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            btnReleaseDetainedLicense.Enabled = !IsSelectedLicenseReleased();
        }

        private bool IsSelectedLicenseReleased()
        {
            return (bool)dgvDetainedLicenses.CurrentRow.Cells["IsReleased"].Value;
        }
    }
}
