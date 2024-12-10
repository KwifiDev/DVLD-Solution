using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using DVLD_UI.Shared_Classes;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Froms
{
    public partial class FRMNewLocalDrivingLicenseApplication : KryptonForm
    {

        enum EnMode { Add, Edit }
        EnMode enMode;

        private int _localDrivingLicenseApplicationID = -1;
        ClsBL_LocalDrivingLicenseApplication _localDrivingLicenseApplication;

        public FRMNewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            enMode = EnMode.Add;
        }

        public FRMNewLocalDrivingLicenseApplication(int localDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _localDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            enMode = EnMode.Edit;
        }

        private async void FRMNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            await LoadLicenseClassesToComboBox();
            await LoadApplicationData();
        }

        private async Task LoadLicenseClassesToComboBox()
        {
            // Put Mode To New To Disable CbLicenseClasses_SelectedIndexChanged While Adding Data
            //enMode = EnMode.Add;

            cbLicenseClasses.DataSource = await ClsBL_LicenseClass.LoadShort();
            cbLicenseClasses.ValueMember = "LicenseClassID";
            cbLicenseClasses.DisplayMember = "ClassName";
            cbLicenseClasses.SelectedValue = 3;

            //enMode = EnMode.Edit;
        }

        private async Task LoadApplicationData()
        {
            if (enMode == EnMode.Add)
            {
                FillDefaultDataApplicationControls();
                return;
            }

            _localDrivingLicenseApplication = await ClsBL_LocalDrivingLicenseApplication.Find(_localDrivingLicenseApplicationID);

            if (_localDrivingLicenseApplication != null)
            {
                ucFindPerson1.SelectPerson(_localDrivingLicenseApplication.ApplicantPersonID);
                FillApplicationControls();
                CbLicenseClasses_SelectedIndexChanged(null, EventArgs.Empty);
                ShowEditMode();
            }
        }

        private async void FillDefaultDataApplicationControls()
        {
            lblApplicationDate.Text = ClsFormat.DateToShort(DateTime.Now);
            lblApplicationFees.Text = (await ClsBL_ApplicationType.Find((int)ClsBL_ApplicationType.EnType.NewLocalDrivingLicense)).ApplicationFees.ToString();
            lblCreatedByUser.Text = ClsGlobal.LoginUser.UserName;
        }

        private void FillApplicationControls()
        {
            lblLDLApplicationID.Text = _localDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = ClsFormat.DateToShort(_localDrivingLicenseApplication.ApplicationDate);
            cbLicenseClasses.SelectedValue = _localDrivingLicenseApplication.LicenseClassID;
            lblApplicationFees.Text = _localDrivingLicenseApplication.PaidFees.ToString();
            lblCreatedByUser.Text = _localDrivingLicenseApplication.UserInfo.UserName;
        }

        private void BtnNextStep_Click(object sender, EventArgs e)
        {
            if (ucFindPerson1.PersonID != -1)
            {
                tabControl.AllowTabSelect = true;

                tabControl.Pages[1].Visible = true;
                tabControl.SelectedIndex = 1;

                tabControl.AllowTabSelect = false;
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnBackPrev_Click(object sender, EventArgs e)
        {
            tabControl.AllowTabSelect = true;

            tabControl.SelectedIndex = 0;
            tabControl.Pages[1].Visible = false;

            tabControl.AllowTabSelect = false;
        }

        private async void BtnCreateLocalLicenseApplication_Click(object sender, EventArgs e)
        {
            if (IsPersonHaveActiveLicense())
            {
                MessageBox.Show("Person Has Already Active Licnese With Same Class License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IsPersonHaveActiveLDLApp())
            {
                MessageBox.Show("You Have Active Application With The Same Class License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadDataToObject();

            if (await _localDrivingLicenseApplication.Save())
            {
                MessageBox.Show("Application Saved Successfuly", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblLDLApplicationID.Text = _localDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                enMode = EnMode.Edit;
                ucFindPerson1.Filter_Enabled = false;
                CbLicenseClasses_SelectedIndexChanged(null, EventArgs.Empty);
                ShowEditMode();
            }
            else
            {
                MessageBox.Show("Faild To Add Application", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool IsPersonHaveActiveLicense()
        {
            int licenseClassID = (int)cbLicenseClasses.SelectedValue;
            return ClsBL_License.IsPersonHaveActiveLicenseInSpecificClass(ucFindPerson1.PersonID, licenseClassID);
        }

        private bool IsPersonHaveActiveLDLApp()
        {
            int licenseClassID = (int)cbLicenseClasses.SelectedValue;
            return ClsBL_LocalDrivingLicenseApplication.IsPersonCanCreateLDLApp(ucFindPerson1.PersonID, licenseClassID);
        }

        private void ShowEditMode()
        {
            if (enMode == EnMode.Edit)
            {
                panelMode.BackColor = Color.DarkOrange;
                lblTitle.Text = "Edit Application";
                btnCreateLocalLicenseApplication.Text = "Update";
                tabControl.Pages[1].Text = "Update Application";
            }
        }

        private void LoadDataToObject()
        {
            if (enMode == EnMode.Add)
            {
                _localDrivingLicenseApplication = new ClsBL_LocalDrivingLicenseApplication();
                _localDrivingLicenseApplication.ApplicantPersonID = ucFindPerson1.PersonID;
                _localDrivingLicenseApplication.ApplicationTypeID = (int)ClsBL_ApplicationType.EnType.NewLocalDrivingLicense;
                _localDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblApplicationFees.Text);
                _localDrivingLicenseApplication.CreatedByUserID = ClsGlobal.LoginUser.UserID;
                _localDrivingLicenseApplication.LicenseClassID = (int)cbLicenseClasses.SelectedValue;
            }
            else
            {
                _localDrivingLicenseApplication.LicenseClassID = (int)cbLicenseClasses.SelectedValue;
            }
        }

        private void UcFindPerson1_OnIsPersonFound(bool isPersonFound)
        {
            btnNextStep.Enabled = isPersonFound;
        }

        private void CbLicenseClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (enMode == EnMode.Edit && _localDrivingLicenseApplication != null)
            {
                btnCreateLocalLicenseApplication.Enabled =
                (int)cbLicenseClasses.SelectedValue != _localDrivingLicenseApplication.LicenseClassID;
            }
        }
    }
}
