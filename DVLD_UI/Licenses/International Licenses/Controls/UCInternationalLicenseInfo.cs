using DVLD_BL;
using DVLD_UI.Properties;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.UserControls
{
    public partial class UCInternationalLicenseInfo : UserControl
    {
        ClsBL_InternationalLicense _internationalLicense;

        public UCInternationalLicenseInfo()
        {
            InitializeComponent();
        }


        public async Task<bool> LoadData(int internationalLicenseID)
        {
            _internationalLicense = await ClsBL_InternationalLicense.Find(internationalLicenseID);

            if (_internationalLicense == null)
            {
                MessageBox.Show("International License ID Is Not Vaild,\nPlease Inter Other One", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetDataControls();
                return false;
            }
            
            LoadDataToControls();

            return true;
        }

        private void LoadDataToControls()
        {
            lblInternationalLicenseID.Text = _internationalLicense.InternationalLicenseID.ToString();
            lblFullName.Text = _internationalLicense.DriverInfo.PersonInfo.FullName;
            lblLicenseID.Text = _internationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblNationalNo.Text = _internationalLicense.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = _internationalLicense.DriverInfo.PersonInfo.GetGendorText();
            lblLicenseIssueDate.Text = _internationalLicense.IssueDate.ToShortDateString();
            lblInternationalApplicationID.Text = _internationalLicense.ApplicationID.ToString();
            lblLicenseIsActive.Text = _internationalLicense.GetLicenseStatus();
            lblDateOfBrith.Text = _internationalLicense.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _internationalLicense.DriverInfo.DriverID.ToString();
            lblLicenseExpirationDate.Text = _internationalLicense.ExpirationDate.ToShortDateString();
            pbPersonImage.ImageLocation = _internationalLicense.DriverInfo.PersonInfo.ImagePath == null ? _GetDefaultImage() : _internationalLicense.DriverInfo.PersonInfo.ImagePath;
        }

        private void ResetDataControls()
        {
            lblInternationalLicenseID.Text = "???";
            lblFullName.Text = "???";
            lblLicenseID.Text = "???";
            lblNationalNo.Text = "???";
            lblGendor.Text = "???";
            lblLicenseIssueDate.Text = "???";
            lblInternationalApplicationID.Text = "???";
            lblLicenseIsActive.Text = "???";
            lblDateOfBrith.Text = "???";
            lblDriverID.Text = "???";
            lblLicenseExpirationDate.Text = "???";
            pbPersonImage.ImageLocation = null;
        }

        private string _GetDefaultImage()
        {
            pbPersonImage.Image = _internationalLicense.DriverInfo.PersonInfo.Gendor == 0 ? Resources.UnknownMale : Resources.UnknownFemale;

            return null;
        }
    }
}
