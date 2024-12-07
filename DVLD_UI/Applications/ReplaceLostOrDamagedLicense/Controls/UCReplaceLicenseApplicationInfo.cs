using DVLD_BL;
using DVLD_UI.Froms;
using System;
using System.Windows.Forms;

namespace DVLD_UI.UserControls
{
    public partial class UCReplaceLicenseApplicationInfo : UserControl
    {
        ClsBL_License _newLicense;
        ClsBL_License _replacementLicense;

        public event Action OnLicenseIssued;

        protected virtual void LicenseIssued()
        {
            OnLicenseIssued?.Invoke();
        }

        public UCReplaceLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadDefaultData()
        {
            LoadDefaultDataToControls();
        }

        private ClsBL_ApplicationType.EnType GetReplacementFor()
        {
            return rbReplacementForDamage.Checked ?
                ClsBL_ApplicationType.EnType.ReplacementDamagedLicense :
                ClsBL_ApplicationType.EnType.ReplacementLostLicense;
        }

        private void LoadDefaultDataToControls()
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUser.Text = ClsGlobal.LoginUser.UserName;
            lblApplicationFees.Text = ClsBL_ApplicationType.FindApplicationFeesByID((int)GetReplacementFor()).ToString();
        }

        public void LoadReplacementLicense(ClsBL_License replacementLicense)
        {
            _replacementLicense = replacementLicense;

            lblOldLicenseID.Text = _replacementLicense.LicenseID.ToString();
            lblOldLicenseID.Tag = _replacementLicense.LicenseID;

            EnableControls(_replacementLicense != null);
        }

        public void EnableControls(bool isEnabled)
        {
            lLblLicenseHistory.Enabled = isEnabled;
            btnReplacementLicense.Enabled = isEnabled;
            gbReplacementLicenseMode.Enabled = isEnabled;
        }

        private async void BtnReplacementLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            _newLicense = await _replacementLicense.Replace(GetReplacementFor(), ClsGlobal.LoginUser.UserID);

            if (_newLicense == null) return;

            LicenseIssued();
            CompleteLicenseSteps();
        }

        private void CompleteLicenseSteps()
        {
            ShowMessage($"New License Created With ID {_newLicense.LicenseID}", "Info");
            lblRLApplicationID.Text = _newLicense.ApplicationID.ToString();
            lblNewLicenseID.Text = _newLicense.LicenseID.ToString();

            btnReplacementLicense.Enabled = false;
            lLblNewLicenseInfo.Enabled = true;
            gbReplacementLicenseMode.Enabled = false;
        }

        private void LLblLicenseHistory_LinkClicked(object sender, EventArgs e)
        {
            var personLicenseHistory = new FRMPersonLicenseHistory(_replacementLicense.PersonID);
            personLicenseHistory.ShowDialog();
        }

        internal void ResetControls()
        {
            lblOldLicenseID.Text = "???";
            EnableControls(false);
        }

        private void LLblNewLicenseInfo_LinkClicked(object sender, EventArgs e)
        {
            FRMLicenseInfo licenseInfo = new FRMLicenseInfo(_newLicense.LicenseID);
            licenseInfo.ShowDialog();
        }

        private void ShowMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RbReplacementFor_CheckedChanged(object sender, EventArgs e)
        {
            lblApplicationFees.Text = ClsBL_ApplicationType.FindApplicationFeesByID((int)GetReplacementFor()).ToString();
        }
    }
}
