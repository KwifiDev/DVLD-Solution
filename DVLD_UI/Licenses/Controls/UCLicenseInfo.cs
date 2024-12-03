using DVLD_BL;
using DVLD_UI.Properties;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.UserControls
{
    public partial class UCLicenseInfo : UserControl
    {
        ClsBL_License _license;

        public ClsBL_License License
        {
            get { return _license; }
        }

        public UCLicenseInfo()
        {
            InitializeComponent();
        }

        public async Task<bool> LoadData(int licenseID)
        {
            _license = await ClsBL_License.Find(licenseID);

            if (_license == null)
            {
                ShowMessage("LicenseID is not valid. Please enter another one.");
                ResetControlsToDefault();
                return false;
            }

            FillControlsWithData();
            return true;
        }

        private void FillControlsWithData()
        {
            lblClassName.Text = _license.LicenseClassInfo.ClassName;
            lblFullName.Text = _license.DriverInfo.PersonInfo.FullName;
            lblLicenseID.Text = _license.LicenseID.ToString();
            lblNationalNo.Text = _license.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = _license.DriverInfo.PersonInfo.GetGendorText();
            lblLicenseIssueDate.Text = _license.IssueDate.ToShortDateString();
            lblLicenseIssueReason.Text = _license.GetIssueReasonText();
            lblLicenseNotes.Text = _license.GetNotes();
            lblLicenseIsActive.Text = _license.GetLicenseStatus();
            lblDateOfBrith.Text = _license.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _license.DriverID.ToString();
            lblLicenseExpirationDate.Text = _license.ExpirationDate.ToShortDateString();
            lblLicesneIsDetained.Text = _license.GetIsDetainedText();
            pbPersonImage.ImageLocation = _license.DriverInfo.PersonInfo.ImagePath ?? GetDefaultImage();
        }

        private void ResetControlsToDefault()
        {
            lblClassName.Text = lblFullName.Text = lblLicenseID.Text = lblNationalNo.Text = lblGendor.Text =
            lblLicenseIssueDate.Text = lblLicenseIssueReason.Text = lblLicenseNotes.Text = lblLicenseIsActive.Text =
            lblDateOfBrith.Text = lblDriverID.Text = lblLicenseExpirationDate.Text = lblLicesneIsDetained.Text = "???";
            pbPersonImage.ImageLocation = null;
        }

        private string GetDefaultImage()
        {
            pbPersonImage.Image = _license.DriverInfo.PersonInfo.Gendor == 0 ? Resources.UnknownMale : Resources.UnknownFemale;
            return null;
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}
