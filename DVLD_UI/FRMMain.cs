using ComponentFactory.Krypton.Toolkit;
using DVLD_UI.Froms;
using System;
using System.Windows.Forms;
using AdvancedControls;
using DVLD_BL;
using static DVLD_BL.ClsBL_User;
using static DVLD_UI.ClsGlobal;

namespace DVLD_UI
{
    public partial class FRMMain : KryptonForm
    {
        private bool _suppressFormClosedEvent = false;

        private readonly FRMLogin _loginForm;

        public FRMMain(FRMLogin loginForm)
        {
            InitializeComponent();
            _loginForm = loginForm;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_suppressFormClosedEvent)
            {
                _suppressFormClosedEvent = false; // Reset the flag
                return; // Skip the rest of the event handler
            }

            Application.Exit();
        }

        private void UcLoginAccountHeader_OnLogout()
        {
            _suppressFormClosedEvent = true; // Set the flag to suppress the FormClosed event
            ClsGlobal.LoginUser = null;
            _loginForm.Show();
            Close();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await ucLoginAccountHeader.LoadData(LoginUser.PersonID);
            InitializeFRMMainControlsDependingOnPermissions();
        }

        private void InitializeFRMMainControlsDependingOnPermissions()
        {
            btnApplicationsMenu.Visible = IsUserCanAccessTo[EnPermissions.ApplicationsMenu];

            btnDrivingLicensesServicesMenu.Visible = IsUserCanAccessTo[EnPermissions.DrivingLicensesServicesMenu];
            
            btnNewDrivingLicensesMenu.Visible = IsUserCanAccessTo[EnPermissions.NewDrivingLicense];
            
            btnLocalLicense.Visible = IsUserCanAccessTo[EnPermissions.AddNewLocalLicenseApplication];
            
            btnInternationalLicense.Visible = IsUserCanAccessTo[EnPermissions.IssueInternationalLicense];
           
            btnRenewDrivingLicense.Visible = IsUserCanAccessTo[EnPermissions.RenewLocalLicense];
           
            btnReplacementFor.Visible = IsUserCanAccessTo[EnPermissions.ReplacementLicense];
           
            btnRetakeTest.Visible = IsUserCanAccessTo[EnPermissions.RetakeTest];
          
            btnPersonLicenseHistory.Visible = IsUserCanAccessTo[EnPermissions.PersonLicenseHistory];
          
            btnManageApplicationsMenu.Visible = IsUserCanAccessTo[EnPermissions.ManageApplicationsMenu];
          
            btnLocalDrivingLicenseApplications.Visible = IsUserCanAccessTo[EnPermissions.ManageLocalDrivingLicenseApplications];
         
            btnInternationalLicesneApplications.Visible = IsUserCanAccessTo[EnPermissions.ManageInternationalLicense];
         
            btnDetainLicensesMenu.Visible = IsUserCanAccessTo[EnPermissions.DetainLicensesMenu];
         
            btnManageDetainLicenses.Visible = IsUserCanAccessTo[EnPermissions.ManageDetainLicenses];
         
            btnDetainLicesne.Visible = IsUserCanAccessTo[EnPermissions.DetainLicense];
           
            btnReleaseDetainedLicnese.Visible = IsUserCanAccessTo[EnPermissions.ReleaseDetainedLicense];
           
            btnManageApplicationTypes.Visible = IsUserCanAccessTo[EnPermissions.ManageApplicationTypes];
          
            btnManageTestTypes.Visible = IsUserCanAccessTo[EnPermissions.ManageTestTypes];
          
            btnPeople.Visible = IsUserCanAccessTo[EnPermissions.PeopleMenu];
         
            btnUsers.Visible = IsUserCanAccessTo[EnPermissions.UsersMenu];
         
            btnDrivers.Visible = IsUserCanAccessTo[EnPermissions.ManageDrivers];
        }

        private void BtnPeople_Click(object sender, EventArgs e)
        {
            FRMManagePeople managePeople = new FRMManagePeople();
            managePeople.ShowDialog();
            AdvancedControls.AdvancedTreeView advancedTreeView = new AdvancedControls.AdvancedTreeView();

        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            FRMManageUsers manageUsers = new FRMManageUsers();
            manageUsers.ShowDialog();
        }

        private void ManageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMManageApplicationTypes manageApplicationTypes = new FRMManageApplicationTypes();
            manageApplicationTypes.ShowDialog();
        }

        private void ManageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMManageTestTypes manageTestTypes = new FRMManageTestTypes();
            manageTestTypes.ShowDialog();
        }

        private void LocalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMNewLocalDrivingLicenseApplication newLDLApplication = new FRMNewLocalDrivingLicenseApplication();
            newLDLApplication.ShowDialog();
        }

        private void LocalDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMManageLDLApplications manageLDLApplications = new FRMManageLDLApplications();
            manageLDLApplications.ShowDialog();
        }

        private void BtnDrivers_Click(object sender, EventArgs e)
        {
            FRMManageDrivers manageDrivers = new FRMManageDrivers();
            manageDrivers.ShowDialog();
        }

        private void InternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMNewInternationalLicenseApplication newInternationalLicense = new FRMNewInternationalLicenseApplication();
            newInternationalLicense.ShowDialog();
        }

        private void RenewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMRenewLocalLicenseApplication renewLocalLicenseApplication = new FRMRenewLocalLicenseApplication();
            renewLocalLicenseApplication.ShowDialog();
        }

        private void ReplacementForToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMReplacementLicenseApplication replacementLicenseApplication = new FRMReplacementLicenseApplication();
            replacementLicenseApplication.ShowDialog();
        }

        private void ReleaseDetainLicesneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMDetainLicense detainLicense = new FRMDetainLicense();
            detainLicense.ShowDialog();
        }

        private void ReleaseDetainLicneseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMReleaseLicenseApplication releaseLicenseApplication = new FRMReleaseLicenseApplication();
            releaseLicenseApplication.ShowDialog();
        }

        private void ManageDetainLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMManageDetainedLicenses manageDetainedLicenses = new FRMManageDetainedLicenses();
            manageDetainedLicenses.ShowDialog();
        }

        private void BtnPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            FRMPersonLicenseHistory personLicenseHistory = new FRMPersonLicenseHistory();
            personLicenseHistory.ShowDialog();
        }

        private void InternationalLicesneApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Has not Been Implemented Yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
