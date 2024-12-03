using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using DVLD_UI.Shared_Classes;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI
{
    public partial class FRMLogin : KryptonForm
    {
        public FRMLogin()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            try
            {
                ClsBL_User user = await AuthenticateUser(username, password);

                if (user == null)
                {
                    ShowErrorMessage("Username and password are incorrect.");
                    return;
                }

                if (!user.IsActive)
                {
                    ShowErrorMessage("User is not active. Contact your admin.");
                    return;
                }

                ShareLoginInfoOnSystem(user);

                StoreUserDataOnRegistry(username, password);

                OpenMainForm();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"An error occurred: {ex.Message}");
            }
        }

        private async Task<ClsBL_User> AuthenticateUser(string username, string password)
        {
            // Encrypt Password Before Send It
            password = ClsUtility.ComputeHash(password);

            return await ClsBL_User.FindByUsernameAndPassword(username, password);
        }

        private void ShareLoginInfoOnSystem(ClsBL_User user)
        {
            ClsGlobal.LoginUser = user;
        }

        private void StoreUserDataOnRegistry(string username, string password)
        {
            ClsGlobal.StoreUserData(isRemember: cbRememberMe.Checked, username, password);
        }

        private void OpenMainForm()
        {
            FRMMain mainfrom = new FRMMain(this);
            mainfrom.Show();
            Hide();
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FRMLogin_Load(object sender, EventArgs e)
        {
            if (ClsGlobal.IsRememberMe())
            {
                txtUsername.Text = ClsGlobal.GetUsernameValue();
                txtPassword.Text = ClsGlobal.GetPasswordValue();
                cbRememberMe.Checked = true;
                btnLogin.Focus();
            }
        }


    }
}
