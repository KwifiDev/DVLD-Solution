using DVLD_BL;
using DVLD_UI.Froms;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.UserControls
{
    public partial class UCLDLApplicationInfo : UserControl
    {
        ClsBL_LocalDrivingLicenseApplication _ldlApplication;

        public ClsBL_LocalDrivingLicenseApplication LDLApplication
        {
            get { return _ldlApplication; }
        }

        int _licenseID;

        public UCLDLApplicationInfo()
        {
            InitializeComponent();
        }

        public async Task<bool> LoadDataByLDLApplicationID(int ldlApplicationID)
        {
            return await LoadData(ldlApplicationID, isLDLApplicationID: true);
        }

        public async Task<bool> LoadDataByApplicationID(int applicationID)
        {
            return await LoadData(applicationID, isLDLApplicationID: false);
        }

        public async Task<bool> LoadData(int id, bool isLDLApplicationID)
        {
            _ldlApplication = isLDLApplicationID
                ? await ClsBL_LocalDrivingLicenseApplication.Find(id)
                : await ClsBL_LocalDrivingLicenseApplication.FindByApplicationID(id);

            if (_ldlApplication == null)
            {
                MessageBox.Show("Can't Find LDL Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            await FillLocalDrivingLicenseApplicationInfo();
            return true;
        }

        private async Task FillLocalDrivingLicenseApplicationInfo()
        {
            _licenseID = await _ldlApplication.GetActiveLicenseID();

            lLblViewLicenseInfo.Enabled = (_licenseID != -1);

            FillControlsWithData();

            await ucApplicationInfo1.LoadApplicationData(_ldlApplication.ApplicationID);
        }

        private void FillControlsWithData()
        {
            lblLDLApplicationID.Text = _ldlApplication.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedLicense.Text = _ldlApplication.LicenseClassInfo.ClassName;
            lblPassedTests.Text = _ldlApplication.GetPassedTests().ToString() + "/3";
        }

        private void LLblViewLicenseInfo_LinkClicked(object sender, EventArgs e)
        {
            FRMLicenseInfo licenseInfo = new FRMLicenseInfo(_licenseID);
            licenseInfo.ShowDialog();
        }
    }
}
