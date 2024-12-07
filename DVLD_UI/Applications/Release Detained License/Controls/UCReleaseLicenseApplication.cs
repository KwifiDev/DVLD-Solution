using DVLD_BL;
using DVLD_UI.Froms;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.UserControls
{
    public partial class UCReleaseLicenseApplication : UserControl
    {
        ClsBL_License _selectedLicense;

        public event Action OnLicenseReleased;

        protected virtual void LicenseReleased()
        {
            OnLicenseReleased?.Invoke();
        }

        public UCReleaseLicenseApplication()
        {
            InitializeComponent();
        }

        public void LoadDefaultData()
        {
            LoadDefaultDataToControls();
        }

        private void LoadDefaultDataToControls()
        {
            lblApplicationFees.Text = ClsBL_ApplicationType.FindApplicationFeesByID((int)ClsBL_ApplicationType.EnType.ReleaseDetainedLicsense).ToString();
        }

        public async Task LoadDetainedLicense(ClsBL_License selectedLicense)
        {
            _selectedLicense = selectedLicense;

            if (_selectedLicense == null) return;

            await LoadDetainedLicenseDataToControls();

            EnableControls(isEnabled: true);
        }

        private async Task LoadDetainedLicenseDataToControls()
        {
            lblLicenseID.Text = _selectedLicense.DetainedInfo.LicenseID.ToString();
            lblDetainID.Text = _selectedLicense.DetainedInfo.DetainID.ToString();
            lblDetainDate.Text = _selectedLicense.DetainedInfo.DetainDate.ToShortDateString();
            lblFineFees.Text = _selectedLicense.DetainedInfo.FineFees.ToString();
            lblTotalFees.Text = (_selectedLicense.DetainedInfo.FineFees + await ClsBL_ApplicationType.FindApplicationFeesByID((int)ClsBL_ApplicationType.EnType.ReleaseDetainedLicsense)).ToString();
            lblCreatedByUser.Text = _selectedLicense.DetainedInfo.CreatedByUserInfo.UserName;
        }

        public void EnableControls(bool isEnabled)
        {
            lLblLicenseHistory.Enabled = isEnabled;
            btnReleaseLicense.Enabled = isEnabled;
        }

        private async void BtnReleaseLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            bool isReleased = await _selectedLicense.Release(ClsGlobal.LoginUser.UserID);

            if (!isReleased)
            {
                ShowMessage("Faild to Release the Detain License", "Error");
                return;
            }

            LicenseReleased();
            CompleteReleasedLicenseSteps();
        }

        private void CompleteReleasedLicenseSteps()
        {
            ShowMessage($"License Released Successfully", "Info");
            lblApplicationID.Text = _selectedLicense.DetainedInfo.ReleaseApplicationID.ToString();

            btnReleaseLicense.Enabled = false;
            lLblLicenseInfo.Enabled = true;
        }

        private void LLblLicenseHistory_LinkClicked(object sender, EventArgs e)
        {
            FRMPersonLicenseHistory personLicenseHistory = new FRMPersonLicenseHistory(_selectedLicense.PersonID);
            personLicenseHistory.ShowDialog();
        }

        internal void ResetControls()
        {
            EmptyControls();
            EnableControls(false);
        }

        private void EmptyControls()
        {
            lblLicenseID.Text = "???";
            lblDetainID.Text = "???";
            lblDetainDate.Text = "???";
            lblCreatedByUser.Text = "???";
            lblFineFees.Text = "???";
            lblTotalFees.Text = "???";
        }

        private void LLblLicenseInfo_LinkClicked(object sender, EventArgs e)
        {
            FRMLicenseInfo licenseInfo = new FRMLicenseInfo(_selectedLicense.LicenseID);
            licenseInfo.ShowDialog();
        }

        private void ShowMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
