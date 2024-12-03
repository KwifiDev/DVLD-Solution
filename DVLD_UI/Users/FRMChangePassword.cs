using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using DVLD_UI.Shared_Classes;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI
{
    public partial class FRMChangePassword : KryptonForm
    {
        private readonly int _userID;
        ClsBL_User _user;

        public FRMChangePassword(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private async void FRMChangePassword_Load(object sender, EventArgs e)
        {
            _user = await ClsBL_User.Find(_userID);

            if (_user == null)
            {
                MessageBox.Show("User Not Found, Contact Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();

                return;
            }

            await ucUserInfo1.LoadUserData(_user.UserID);

        }

        private async void BtnChangePassword_Click(object sender, EventArgs e)
        {
            if (!FieldsIsValid())
            {
                MessageBox.Show("Some Fields Not Valid Check the Errors", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            await ChangePassword();
        }

        private async Task ChangePassword()
        {
            string encryptedPassword = ClsUtility.ComputeHash(txtNewPassword.Text.Trim());

            _user.Password = encryptedPassword;

            if (await _user.Save())
            {
                MessageBox.Show("New Password Changed Successfuly", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableControls(isEnabled: false);
            }
            else
            {
                MessageBox.Show("Failed To Change The Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnableControls(bool isEnabled)
        {
            txtOldPassword.Enabled = isEnabled;
            txtPasswordConfirm.Enabled = isEnabled;
            txtNewPassword.Enabled = isEnabled;
            btnChangePassword.Enabled = isEnabled;
        }

        private bool FieldsIsValid()
        {
            return ValidateTextBoxs(txtOldPassword) && ValidateTextBoxs(txtNewPassword) && ValidateTextBoxs(txtPasswordConfirm);
        }

        private void ClearFields()
        {
            txtOldPassword.Text = string.Empty;
            txtPasswordConfirm.Text = string.Empty;
            txtNewPassword.Text = string.Empty;
        }

        private void AllTextBoxs_Validating(object sender, CancelEventArgs e)
        {
            ValidateTextBoxs((KryptonTextBox)sender);
        }

        private bool ValidateTextBoxs(KryptonTextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                ShowError(textBox, $"Please Set {textBox.Name}");
                return false;
            }

            if (textBox == txtOldPassword && ClsUtility.ComputeHash(textBox.Text.Trim()) != _user.Password)
            {
                ShowError(textBox, "Old Password Not Correct");
                return false;
            }

            if (textBox.Text.Length < 4)
            {
                ShowError(textBox, $"Password Too Short in {textBox.Name}");
                return false;
            }

            if (textBox == txtPasswordConfirm && txtNewPassword.Text != textBox.Text)
            {
                ShowError(textBox, $"New Password Not Matched {textBox.Name}");
                return false;
            }

            ClearError(textBox);
            return true;
        }

        private void ShowError(KryptonTextBox textBox, string errorMessage)
        {
            errorProvider.SetError(textBox, errorMessage);
        }

        private void ClearError(KryptonTextBox textBox)
        {
            errorProvider.SetError(textBox, "");
        }

    }
}
