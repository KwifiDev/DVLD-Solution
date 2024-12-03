using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using DVLD_UI.Shared_Classes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Froms
{
    public partial class FRMAddEditUser : KryptonForm
    {

        enum EnMode { Add, Edit }
        EnMode enMode;

        private int _userID = -1;

        ClsBL_User _user;

        public FRMAddEditUser()
        {
            InitializeComponent();
            enMode = EnMode.Add;
        }

        public FRMAddEditUser(int userID)
        {
            InitializeComponent();
            enMode = EnMode.Edit;
            _userID = userID;
        }

        private async void FRMAddEditUser_Load(object sender, EventArgs e)
        {
            if (enMode == EnMode.Add)
                _user = new ClsBL_User();
            else
                await LoadUserData();
        }

        private async Task LoadUserData()
        {
            if (_userID == -1) return;

            _user = await ClsBL_User.Find(_userID);

            if (_user == null)
            {
                MessageBox.Show("No User with ID = " + _userID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            //the following code will not be executed if the person was not found
            ucFindPerson1.Filter_Enabled = false;
            ucFindPerson1.SelectPerson(_user.PersonID);
            FillUserData();
            SetEditMode();

        }

        private void FillUserData()
        {
            lblUserID.Text = _user.UserID.ToString();
            txtUsername.Text = _user.UserName;
            txtPassword.Text = _user.Password;
            txtConfirmPassword.Text = _user.Password;
            cbIsActive.Checked = _user.IsActive;
            cbFullControl.Checked = _user.Permissions == ClsBL_User.EnPermissions.FullControl;
            ucAddEditUserPermissions1.LoadPermissions(_user.Permissions);
        }

        private void SetEditMode()
        {
            if (enMode == EnMode.Edit)
            {
                panelMode.BackColor = Color.DarkOrange;
                lblPersonMode.Text = "Edit User";
                btnCreateUser.Text = "Update";
                tabControl.Pages[1].Text = "Update User";
            }
        }

        private async void BtnCreateUser_Click(object sender, EventArgs e)
        {
            if (!await FieldsIsValid())
            {
                MessageBox.Show("Some Fields Not Valid Check the Error", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LoadDataToObject();

            if (await _user.Save())
            {
                MessageBox.Show("User Saved Successfuly", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblUserID.Text = _user.UserID.ToString();
                enMode = EnMode.Edit;
                ucFindPerson1.Filter_Enabled = false;
                SetEditMode();
            }
            else
            {
                MessageBox.Show("Faild To Save User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> FieldsIsValid()
        {
            return await ValidateTextBoxs(txtUsername) && await ValidateTextBoxs(txtPassword) && await ValidateTextBoxs(txtConfirmPassword);
        }

        private void LoadDataToObject()
        {
            _user.PersonID = ucFindPerson1.PersonID;
            _user.UserName = txtUsername.Text.Trim();
            _user.Password = (txtPassword.Text.Length != 64) ? ClsUtility.ComputeHash(txtPassword.Text.Trim()) : _user.Password;
            _user.Permissions = (cbFullControl.Checked) ? ClsBL_User.EnPermissions.FullControl : ucAddEditUserPermissions1.GetSelectedUserPermissions();
            _user.IsActive = cbIsActive.Checked;
        }

        private async void AllTextBoxs_Validating(object sender, CancelEventArgs e)
        {
            await ValidateTextBoxs((KryptonTextBox)sender);
        }

        private async Task<bool> ValidateTextBoxs(KryptonTextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                ShowError(textBox, $"Please Set {textBox.Name}");
                return false;
            }

            if (textBox == txtUsername && await ClsBL_User.IsUsernameExist(txtUsername.Text.Trim()) && _user.UserName != txtUsername.Text)
            {
                ShowError(textBox, $"This Username [{textBox.Text}] Is Used By Anthor User ");
                return false;
            }

            if (textBox == txtConfirmPassword && txtPassword.Text != txtConfirmPassword.Text)
            {
                ShowError(textBox, $"Check Your Password,It is Not Matched");
                return false;
            }

            if (textBox == txtPassword && (txtPassword.Text.Length < 4 || txtPassword.Text.Length > 16) && txtPassword.Text.Length != 64)
            {
                ShowError(textBox, $"Your Password Must Be Between [4 - 16] Of Length");
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

        private async void BtnNextStep_Click(object sender, EventArgs e)
        {
            if (await ClsBL_User.IsExistByPersonID(ucFindPerson1.PersonID) && enMode == EnMode.Add)
            {
                MessageBox.Show("This Person Has A User Account", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ucFindPerson1.PersonID != -1)
            {
                tabControl.AllowTabSelect = true;

                tabControl.Pages[1].Visible = true;
                tabControl.SelectedIndex = 1;

                tabControl.AllowTabSelect = false;
            }
        }

        private void BtnBackPrev_Click(object sender, EventArgs e)
        {
            tabControl.AllowTabSelect = true;

            tabControl.SelectedIndex = 0;
            tabControl.Pages[1].Visible = false;

            tabControl.AllowTabSelect = false;
        }

        private void UcFindPerson1_OnPersonFound(bool isPersonFound)
        {
            btnNextStep.Enabled = isPersonFound;
        }

        private void CbFullControl_CheckedChanged(object sender, EventArgs e)
        {
            ucAddEditUserPermissions1.Enabled = !cbFullControl.Checked;
        }
    }
}
