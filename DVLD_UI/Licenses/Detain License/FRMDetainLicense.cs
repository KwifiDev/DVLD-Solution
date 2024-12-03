using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using System;
using System.Windows.Forms;

namespace DVLD_UI.Froms
{
    public partial class FRMDetainLicense : KryptonForm
    {
        int _licenseID = -1;

        public FRMDetainLicense()
        {
            InitializeComponent();
        }

        public FRMDetainLicense(int licenseID)
        {
            InitializeComponent();
            _licenseID = licenseID;
        }

        private void FRMNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            ucDetainLicense1.LoadDefaultData();

            if (_licenseID != -1) ucFindLicense1.SelectLicense(_licenseID);
        }

        private void UcFindLicense1_OnLicenseFoundAndActive(ClsBL_License license)
        {
            if (license.IsDetained())
            {
                MessageBox.Show("This License Is Already Detained", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucDetainLicense1.ResetControls();
                return;
            }
            
            ucDetainLicense1.LoadLicenseData(license);
        }

        private void UcFindLicense1_OnInvalidLicense()
        {
            ucDetainLicense1.ResetControls();
        }

        private void UcDetainLicense1_OnLicenseDetained()
        {
            ucFindLicense1.EnableControls(isEnabled: false);
        }


    }

}
