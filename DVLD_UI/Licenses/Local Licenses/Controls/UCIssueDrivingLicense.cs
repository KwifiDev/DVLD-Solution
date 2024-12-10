using DVLD_BL;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.UserControls
{
    public partial class UCIssueDrivingLicense : UserControl
    {
        ClsBL_LocalDrivingLicenseApplication _ldlApplication;

        public UCIssueDrivingLicense()
        {
            InitializeComponent();
        }

        public async void LoadData(int ldlApplicationID)
        {
            if (!await ucldlApplicationInfo1.LoadDataByLDLApplicationID(ldlApplicationID)) return;

            _ldlApplication = ucldlApplicationInfo1.LDLApplication;

            if (!IsPersonPassedAllTests())
            {
                MessageBox.Show("This Person Not Passed All Tests\nCant Issue License", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableControls(false);
                return;
            }

            if (await IsPersonHaveActiveLicense())
            {
                MessageBox.Show("This Person Have Active Licnese\nCant Issue License", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableControls(false);
                return;
            }
        }

        private async void BtnIssueLicense_Click(object sender, EventArgs e)
        {
            int licenseID = await _ldlApplication.IssueLicenseFirstTime(txtLicenseNotes.Text.Trim(), ClsGlobal.LoginUser.UserID);

            if (licenseID != -1)
            {
                MessageBox.Show("License Created Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableControls(false);

                await ucldlApplicationInfo1.LoadDataByLDLApplicationID(_ldlApplication.LocalDrivingLicenseApplicationID);
            }
            else
            {
                MessageBox.Show("Cant Make Licnese To This Person\nContact Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool IsPersonPassedAllTests()
        {
            return _ldlApplication.IsPassedAllTests();
        }

        private async Task<bool> IsPersonHaveActiveLicense()
        {
            return await _ldlApplication.IsPersonHaveActiveLicense();
        }

        private void EnableControls(bool isEnabled)
        {
            btnIssueLicense.Enabled = isEnabled;
            txtLicenseNotes.Enabled = isEnabled;
        }

    }
}
