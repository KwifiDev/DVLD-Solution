using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using System;
using System.Windows.Forms;

namespace DVLD_UI.Froms
{
    public partial class FRMNewInternationalLicenseApplication : KryptonForm
    {
        private readonly int _internationalLicenseID;

        public FRMNewInternationalLicenseApplication(int internationalLicenseID = -1)
        {
            InitializeComponent();
            _internationalLicenseID = internationalLicenseID;
        }

        private async void FRMNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            await ucInterNationalApplicationInfo1.LoadDefaultData();

            if (_internationalLicenseID != -1) ucFindLicense1.SelectLicense(_internationalLicenseID);
        }

        private void UcFindLicense1_OnLicenseFoundAndActive(ClsBL_License license)
        {
            if (license.IsExpird())
            {
                MessageBox.Show("Your License Is Expired\nPlease Renew It", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ucInterNationalApplicationInfo1.ResetControls();
                return;
            }

            if (!license.IsClassOrdinary())
            {
                MessageBox.Show("You Can Only Create An International License For Ordinary Local License Class [3]", "Info",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                ucInterNationalApplicationInfo1.ResetControls();
                return;
            }

            ucInterNationalApplicationInfo1.LoadDataAfterFindValidLicense(license.LicenseID, license.DriverInfo.PersonID, license.DriverID);
        }

        private void UcFindLicense1_OnInvalidLicense()
        {
            ucInterNationalApplicationInfo1.ResetControls();
        }

        private void UcInterNationalApplicationInfo1_OnLicenseIssued()
        {
            ucFindLicense1.EnableControls(isEnabled: false);
        }


    }

}
