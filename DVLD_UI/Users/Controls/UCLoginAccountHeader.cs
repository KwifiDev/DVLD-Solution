using DVLD_BL;
using DVLD_UI.Froms;
using DVLD_UI.Properties;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI
{
    public partial class UCLoginAccountHeader : UserControl
    {

        public event Action OnLogout;
        private ClsBL_Person _person;

        protected virtual void Logout()
        {
            OnLogout?.Invoke();
        }

        public UCLoginAccountHeader()
        {
            InitializeComponent();
        }

        public async Task LoadData(int personID)
        {
            _person = await ClsBL_Person.Find(personID);

            if (_person != null) _LoadPersonInfo();
            else
                MessageBox.Show("Error While Finding LoginUser Account", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _LoadPersonInfo()
        {
            lblNameOfUser.Text = _person.FullName;
            pbPersonImage.ImageLocation = string.IsNullOrEmpty(_person.ImagePath) ? _GetDefaultImage() : _LoadPersonImage();
        }

        private string _LoadPersonImage()
        {
            if (File.Exists(_person.ImagePath))
            {
                return _person.ImagePath;
            }
            else
            {
                MessageBox.Show("Could not find this image: = " + _person.ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return _GetDefaultImage();
            }
        }

        private string _GetDefaultImage()
        {
            pbPersonImage.Image = _person.Gendor == 0 ? Resources.UnknownMale : Resources.UnknownFemale;

            return null;
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            FRMChangePassword changePasswordForm = new FRMChangePassword(ClsGlobal.LoginUser.UserID);

            changePasswordForm.ShowDialog();
        }

        private void BtnCurrentUserInfo_Click(object sender, EventArgs e)
        {
            FRMUserDetails userDetails = new FRMUserDetails(ClsGlobal.LoginUser.UserID);
            userDetails.ShowDialog();
        }
    }
}
