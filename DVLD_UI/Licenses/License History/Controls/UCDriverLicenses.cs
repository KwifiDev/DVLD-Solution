using DVLD_BL;
using DVLD_UI.Froms;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.UserControls
{
    public partial class UCDriverLicenses : UserControl
    {
        DataTable _driverLocalLicensesTB;
        DataTable _driverInternationalLicensesTB;
        ClsBL_Driver _driver;

        public UCDriverLicenses()
        {
            InitializeComponent();
            dgvLocalLicenses.MouseDown += DgvLicenses_MouseDown;
            dgvInternationalLicenses.MouseDown += DgvLicenses_MouseDown;
        }

        public async Task LoadDriverLicensesByDriverID(int driverID)
        {
            tabControl.SelectedIndex = 0;

            _driver = await ClsBL_Driver.Find(driverID);

            if (_driver == null)
            {
                MessageBox.Show($"No Driver Found With ID : {driverID}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await LoadLocalLicenses();
            await LoadInternationalLicenses();
        }

        public async Task LoadDriverLicensesByPersonID(int personID)
        {
            tabControl.SelectedIndex = 0;

            _driver = await ClsBL_Driver.FindByPersonID(personID);

            if (_driver == null)
            {
                MessageBox.Show($"No Person Found With ID : {personID}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await LoadLocalLicenses();
            await LoadInternationalLicenses();
        }

        private async Task LoadLocalLicenses()
        {
            // Load Local Licenses For Driver
            _driverLocalLicensesTB = await _driver.FindLocalLicenses();
            dgvLocalLicenses.DataSource = _driverLocalLicensesTB;
        }

        private async Task LoadInternationalLicenses()
        {
            // Load International Licenses For Driver
            _driverInternationalLicensesTB = await _driver.FindInternationalLicenses();
            dgvInternationalLicenses.DataSource = _driverInternationalLicensesTB;
        }

        private void BtnShowLicenseInfo_Click(object sender, EventArgs e)
        {

            if (tabControl.Pages[0].ContainsFocus) // Local Licenses Tab
            {
                int licenseID = (int)dgvLocalLicenses.CurrentRow.Cells[0].Value;
                FRMLicenseInfo licenseInfo = new FRMLicenseInfo(licenseID);
                licenseInfo.ShowDialog();
                return;
            }


            if (tabControl.Pages[1].ContainsFocus) // International Licenses Tab
            {
                int internationallicenseID = (int)dgvInternationalLicenses.CurrentRow.Cells[0].Value;
                FRMInternationalLicenseInfo internationalLicenseInfo = new FRMInternationalLicenseInfo(internationallicenseID);
                internationalLicenseInfo.ShowDialog();
                return;
            }
        }

        private void DgvLicenses_MouseDown(object sender, MouseEventArgs e)
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
    }
}
