using DVLD_BL;
using DVLD_UI.Froms;
using System;
using System.Windows.Forms;

namespace DVLD_UI.UserControls
{
    public partial class UCRenewLicenseApplicationInfo : UserControl
    {
        ClsBL_License _newLicense;
        ClsBL_License _expirdLicense;

        public event Action OnLicenseIssued;

        protected virtual void LicenseIssued()
        {
            OnLicenseIssued?.Invoke();
        }

        public UCRenewLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadDefaultData()
        {
            LoadDefaultDataToControls();
        }

        private void LoadDefaultDataToControls()
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblNewLicenseIssueDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUser.Text = ClsGlobal.LoginUser.UserName;
            lblApplicationFees.Text = ClsBL_ApplicationType.FindApplicationFeesByID((int)ClsBL_ApplicationType.EnType.RenewDrivingLicense).ToString();
        }

        public void LoadExpirdLicense(ClsBL_License expirdLicense)
        {
            _expirdLicense = expirdLicense;

            LoadOldLicenseDataToControls();

            EnableControls(_expirdLicense != null);
        }
        
        private void LoadOldLicenseDataToControls()
        {
            lblOldLicenseID.Text = _expirdLicense.LicenseID.ToString();
            lblOldLicenseID.Tag = _expirdLicense.LicenseID;
            lblLicenseFees.Text = _expirdLicense.PaidFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + _expirdLicense.PaidFees).ToString();
            txtLicenseNotes.Text = _expirdLicense.Notes;
        }

        public void EnableControls(bool isEnabled)
        {
            lLblLicenseHistory.Enabled = isEnabled;
            btnRenewLicense.Enabled = isEnabled;
            txtLicenseNotes.Enabled = isEnabled;
        }

        private void BtnRenewLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            string notes = txtLicenseNotes.Text;

            _newLicense = _expirdLicense.Renew(notes, ClsGlobal.LoginUser.UserID);

            if (_newLicense == null) return;

            LicenseIssued();
            CompleteLicenseSteps();
        }

        private void CompleteLicenseSteps()
        {
            ShowMessage($"New License Created With ID {_newLicense.LicenseID}", "Info");
            lblRLApplicationID.Text = _newLicense.ApplicationID.ToString();
            lblNewLicenseID.Text = _newLicense.LicenseID.ToString();
            lblNewLicenseExpirationDate.Text = _newLicense.ExpirationDate.ToShortDateString();

            btnRenewLicense.Enabled = false;
            txtLicenseNotes.Enabled = false;
            lLblNewLicenseInfo.Enabled = true;
        }

        private void LLblLicenseHistory_LinkClicked(object sender, EventArgs e)
        {
            FRMPersonLicenseHistory personLicenseHistory = new FRMPersonLicenseHistory(_expirdLicense.PersonID);
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

    }
}
