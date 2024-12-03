using DVLD_BL;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI
{
    public partial class UCUserInfo : UserControl
    {
        ClsBL_User _user;
        public UCUserInfo()
        {
            InitializeComponent();
        }

        public async Task LoadUserData(int userID)
        {
            _user = await ClsBL_User.Find(userID);

            if (_user != null)
            {
                await LoadData();
            }
            else
            {
                MessageBox.Show("Error While Finding User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadData()
        {
            await LoadPersonInfo();
            LoadUserInfo();
        }

        private async Task LoadPersonInfo()
        {
            await ucPersonInfo1.LoadPersonData(_user.PersonID);
        }

        private void LoadUserInfo()
        {
            lblUserID.Text = _user.UserID.ToString();
            lblUsername.Text = _user.UserName;
            lblIsActive.Text = _user.IsActive ? "Active" : "Not Active";
        }
    }
}
