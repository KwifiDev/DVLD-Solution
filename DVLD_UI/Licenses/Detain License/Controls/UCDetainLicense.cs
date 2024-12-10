using DVLD_BL;
using DVLD_UI.Froms;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD_UI.UserControls
{
    public partial class UCDetainLicense : UserControl
    {
        ClsBL_License _license;

        public event Action OnLicenseDetained;

        protected virtual void LicenseDetained()
        {
            OnLicenseDetained?.Invoke();
        }

        public UCDetainLicense()
        {
            InitializeComponent();
        }

        public void LoadDefaultData()
        {
            LoadDefaultDataToControls();
        }

        private void LoadDefaultDataToControls()
        {
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUser.Text = ClsGlobal.LoginUser.UserName;
        }

        public void LoadLicenseData(ClsBL_License license)
        {
            _license = license;

            lblLicenseID.Text = _license.LicenseID.ToString();
            EnableControls(isEnabled: true);
        }

        public void EnableControls(bool isEnabled)
        {
            lLblLicenseHistory.Enabled = isEnabled;
            btnDetainLicense.Enabled = isEnabled;
            nudFineFees.Enabled = isEnabled;
        }

        private async void BtnDetainLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            bool isDetained = await _license.Detain((float)nudFineFees.Value, ClsGlobal.LoginUser.UserID);

            if (!isDetained)
            {
                ShowMessage("Can't Detain A License", "Error");
                return;
            }

            LicenseDetained();
            CompleteDetainedLicenseSteps();
        }

        private void CompleteDetainedLicenseSteps()
        {
            ShowMessage($"License Detained With DetainID {_license.DetainedInfo.DetainID}", "Info");
            lblDetainID.Text = _license.DetainedInfo.DetainID.ToString();

            btnDetainLicense.Enabled = false;
            lLblLicenseInfo.Enabled = true;
            nudFineFees.Enabled = false;
        }

        private void LLblLicenseHistory_LinkClicked(object sender, EventArgs e)
        {
            FRMPersonLicenseHistory personLicenseHistory = new FRMPersonLicenseHistory(_license.DriverInfo.PersonID);
            personLicenseHistory.ShowDialog();
        }

        internal void ResetControls()
        {
            lblLicenseID.Text = "???";
            EnableControls(false);
        }

        private void LLblLicenseInfo_LinkClicked(object sender, EventArgs e)
        {
            FRMLicenseInfo licenseInfo = new FRMLicenseInfo(_license.LicenseID);
            licenseInfo.ShowDialog();
        }

        private void ShowMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
