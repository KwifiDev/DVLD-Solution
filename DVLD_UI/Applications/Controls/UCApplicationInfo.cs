using DVLD_BL;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.UserControls
{
    public partial class UCApplicationInfo : UserControl
    {
        ClsBL_Application application;
        public UCApplicationInfo()
        {
            InitializeComponent();
        }

        public async Task LoadApplicationData(int applicationID)
        {
            application = await ClsBL_Application.Find(applicationID);

            if (application != null)
            {
                FillControlsWithData();
                lLblViewPersonInfo.Enabled = true;
            }
            else
            {
                MessageBox.Show("Cant Find Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillControlsWithData()
        {
            lblApplicationID.Text = application.ApplicationID.ToString();
            lblApplicationStatus.Text = application.GetApplicationStatusText();
            lblApplicationFees.Text = application.PaidFees.ToString();
            lblApplicationType.Text = application.ApplicationTypeInfo.ApplicationTypeTitle;
            lblApplicant.Text = application.ApplicantPersonInfo.FullName;
            lblApplicationDate.Text = application.ApplicationDate.ToShortDateString();
            lblLastStatusDate.Text = application.LastStatusDate.ToShortDateString();
            lblCreatedByUser.Text = application.UserInfo.UserName;
        }

        private void LLblViewPersonInfo_LinkClicked(object sender, EventArgs e)
        {
            if (application == null) return;

            FRMPersonDetails personDetails = new FRMPersonDetails(application.ApplicantPersonID);
            personDetails.ShowDialog();
        }
    }
}
