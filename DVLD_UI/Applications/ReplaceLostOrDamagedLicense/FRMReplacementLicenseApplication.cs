using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using System;

namespace DVLD_UI.Froms
{
    public partial class FRMReplacementLicenseApplication : KryptonForm
    {
        private readonly int _licenseID;

        public FRMReplacementLicenseApplication(int licenseID = -1)
        {
            InitializeComponent();
            _licenseID = licenseID;
        }

        private async void FRMRenewLocalLicenseApplication_Load(object sender, EventArgs e)
        {
            await ucReplaceLicenseApplicationInfo1.LoadDefaultData();

            if (_licenseID != -1) ucFindLicense1.SelectLicense(_licenseID);
        }

        private void UcFindLicense1_OnIsLicenseFoundAndActive(ClsBL_License license)
        {
            ucReplaceLicenseApplicationInfo1.LoadReplacementLicense(license);
        }

        private void UcFindLicense1_OnInvalidLicense()
        {
            ucReplaceLicenseApplicationInfo1.ResetControls();
        }

        private void UcReplaceLicenseApplicationInfo1_OnLicenseIssued()
        {
            ucFindLicense1.EnableControls(isEnabled: false);
        }

    }

}
