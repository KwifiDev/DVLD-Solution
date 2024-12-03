using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using System;
using System.Windows.Forms;

namespace DVLD_UI.Froms
{
    public partial class FRMRenewLocalLicenseApplication : KryptonForm
    {
        private readonly int _licenseID;

        public FRMRenewLocalLicenseApplication(int licenseID = -1)
        {
            InitializeComponent();
            _licenseID = licenseID;
        }

        private void FRMRenewLocalLicenseApplication_Load(object sender, EventArgs e)
        {
            ucRenewLicenseApplicationInfo1.LoadDefaultData();
             
            if (_licenseID != -1) ucFindLicense1.SelectLicense(_licenseID);
        }

        private void UcFindLicense1_OnLicenseFoundAndActive(ClsBL_License license)
        {
            if (!license.IsExpird())
            {
                MessageBox.Show("Your License Not Expird Yet\nYou Cant Renew Your License", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucRenewLicenseApplicationInfo1.ResetControls();
                return;
            }

            ucRenewLicenseApplicationInfo1.LoadExpirdLicense(license);

        }
        private void UcFindLicense1_OnInvalidLicense()
        {
            ucRenewLicenseApplicationInfo1.ResetControls();
        }

        private void UcRenewLicenseApplicationInfo1_OnLicenseIssued()
        {
            ucFindLicense1.EnableControls(isEnabled: false);
        }

    }

}
