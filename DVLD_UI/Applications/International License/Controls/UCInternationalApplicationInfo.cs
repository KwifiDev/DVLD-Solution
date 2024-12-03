using DVLD_BL;
using DVLD_UI.Froms;
using System;
using System.Windows.Forms;

namespace DVLD_UI.UserControls
{
    public partial class UCInternationalApplicationInfo : UserControl
    {
        ClsBL_InternationalLicense _internationalLicense;

        public event Action OnLicenseIssued;

        protected virtual void LicenseIssued()
        {
            OnLicenseIssued?.Invoke();
        }

        public UCInternationalApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadDefaultData()
        {
            LoadDefaultDataToObject();
            LoadDefaultDataToControls();
        }

        private void LoadDefaultDataToObject()
        {
            _internationalLicense = new ClsBL_InternationalLicense
            {
                ApplicationTypeID = (int)ClsBL_ApplicationType.EnType.NewInternationalLicense,
                PaidFees = ClsBL_ApplicationType.FindApplicationFeesByID((int)ClsBL_ApplicationType.EnType.NewInternationalLicense),
                CreatedByUserID = ClsGlobal.LoginUser.UserID,
                ApplicationStatus = ClsBL_Application.EnStatus.Completed
            };
        }

        private void LoadDefaultDataToControls()
        {
            lblApplicationDate.Text = _internationalLicense.ApplicationDate.ToShortDateString();
            lblInternationalLicenseIssueDate.Text = _internationalLicense.IssueDate.ToShortDateString();
            lblExpirationDate.Text = _internationalLicense.ExpirationDate.ToShortDateString();
            lblCreatedByUser.Text = ClsGlobal.LoginUser.UserName;
            lblApplicationFees.Text = _internationalLicense.PaidFees.ToString();
        }

        public void LoadDataAfterFindValidLicense(int localLicenseID, int personID, int driverID)
        {
            _internationalLicense.IssuedUsingLocalLicenseID = localLicenseID;
            _internationalLicense.DriverID = driverID;
            _internationalLicense.ApplicantPersonID = personID;

            lblLocalLicenseID.Text = localLicenseID.ToString();
            EnableControls(true);
        }

        public void EnableControls(bool isEnabled)
        {
            lLblLicenseHistory.Enabled = isEnabled;
            btnIssueLicense.Enabled = isEnabled;
        }

        private async void BtnIssueLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (await ClsBL_Driver.IsDriverHaveActiveInternationalLicense(_internationalLicense.DriverID))
            {
                ShowMessage("Can't Create International License\nThis Driver Already Have An Active International License", "Info");
                return;
            }

            if (!_internationalLicense.Save())
            {
                ShowMessage("Can't Create International License", "Error");
                return;
            }

            LicenseIssued();
            CompleteLicenseSteps();
        }

        private void CompleteLicenseSteps()
        {
            ShowMessage($"International License Created With ID {_internationalLicense.InternationalLicenseID}", "Info");
            lblILApplicationID.Text = _internationalLicense.ApplicationID.ToString();
            lblInternationalLicenseID.Text = _internationalLicense.InternationalLicenseID.ToString();
            btnIssueLicense.Enabled = false;
            lLblInternationalLicenseInfo.Enabled = true;
        }

        private void LLblLicenseHistory_LinkClicked(object sender, EventArgs e)
        {
            var personLicenseHistory = new FRMPersonLicenseHistory(_internationalLicense.ApplicantPersonID);
            personLicenseHistory.ShowDialog();
        }

        internal void ResetControls()
        {
            lblLocalLicenseID.Text = "???";
            EnableControls(false);
        }

        private void LLblInternationalLicenseInfo_LinkClicked(object sender, EventArgs e)
        {
            var internationalLicenseInfo = new FRMInternationalLicenseInfo(_internationalLicense.InternationalLicenseID);
            internationalLicenseInfo.ShowDialog();
        }

        private void ShowMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
