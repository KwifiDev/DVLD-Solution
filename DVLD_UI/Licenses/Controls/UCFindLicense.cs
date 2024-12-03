using DVLD_BL;
using System;
using System.Windows.Forms;

namespace DVLD_UI.UserControls
{
    public partial class UCFindLicense : UserControl
    {
        public event Action<ClsBL_License> OnLicenseFoundAndActive;
        protected virtual void LicenseFoundAndActive(ClsBL_License license)
        {
            OnLicenseFoundAndActive?.Invoke(license);
        }

        public event Action OnInvalidLicense;
        protected virtual void InvalidLicense()
        {
            OnInvalidLicense?.Invoke();
        }

        public bool Filter_Enabled
        {
            get { return gbFilter.Enabled; }
            set { gbFilter.Enabled = value; }
        }

        public UCFindLicense()
        {
            InitializeComponent();
        }

        public void SelectLicense(int licenseID)
        {
            txtLicenseID.Text = licenseID.ToString();
            BtnFindLicense_Click(null, EventArgs.Empty);
            EnableControls(false);
        }

        public void EnableControls(bool isEnabled)
        {
            txtLicenseID.Enabled = isEnabled;
            btnFindLicense.Enabled = isEnabled;
        }

        private async void BtnFindLicense_Click(object sender, EventArgs e)
        {
            if (!DataIsValid()) return;

            if (!int.TryParse(txtLicenseID.Text, out int licenseID))
            {
                ShowMessage("Invalid License ID");
                InvalidLicense();
                return;
            }

            if (!await ucLicenseInfo1.LoadData(licenseID))
            {
                InvalidLicense();
                return;
            }

            ClsBL_License license = ucLicenseInfo1.License;

            if (!license.IsActive)
            {
                ShowMessage("Your License Is Not Active");
                InvalidLicense();
                return;
            }

            LicenseFoundAndActive(license);
        }

        private bool DataIsValid()
        {
            if (string.IsNullOrEmpty(txtLicenseID.Text))
            {
                ShowMessage("Please Enter License ID");
                return false;
            }
            return true;
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TxtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
                btnFindLicense.PerformClick();
        }
    }

}
