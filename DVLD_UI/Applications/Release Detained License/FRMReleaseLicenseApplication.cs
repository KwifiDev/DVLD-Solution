using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using System;
using System.Windows.Forms;

namespace DVLD_UI.Froms
{
    public partial class FRMReleaseLicenseApplication : KryptonForm
    {
        private readonly int _licenseID = -1;

        public FRMReleaseLicenseApplication()
        {
            InitializeComponent();
        }

        public FRMReleaseLicenseApplication(int licenseID)
        {
            InitializeComponent();
            _licenseID = licenseID;
        }

        private void FRMNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            ucReleaseLicenseApplication1.LoadDefaultData();

            if (_licenseID != -1) ucFindLicense1.SelectLicense(_licenseID);
        }

        private async void UcFindLicense1_OnLicenseFoundAndActive(ClsBL_License license)
        {
            if (!license.IsDetained())
            {
                MessageBox.Show("This License Didn't Detain", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucReleaseLicenseApplication1.ResetControls();
                return;
            }

            await ucReleaseLicenseApplication1.LoadDetainedLicense(license);
        }

        private void UcFindLicense1_OnInvalidLicense()
        {
            ucReleaseLicenseApplication1.ResetControls();
        }

        private void UcReleaseLicenseApplication1_OnLicenseReleased()
        {
            ucFindLicense1.EnableControls(isEnabled: false);
        }


    }

}
