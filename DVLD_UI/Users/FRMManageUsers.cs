using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_BL.ClsBL_User;
using static DVLD_UI.ClsGlobal;

namespace DVLD_UI.Froms
{
    public partial class FRMManageUsers : KryptonForm
    {

        private static DataTable _fullUsersTB;

        public FRMManageUsers()
        {
            InitializeComponent();
            dgvUser.MouseDown += DgvUser_MouseDown;
        }

        private async void FRMManageUsers_Load(object sender, EventArgs e)
        {
            await LoadUsersDataToGridView();
            InitializePermissions();
        }

        private void InitializePermissions()
        {
            btn2AddUser.Enabled = IsUserCanAccessTo[EnPermissions.AddUser];
            btnAddUser.Enabled = IsUserCanAccessTo[EnPermissions.AddUser];
            btnEditUser.Enabled = IsUserCanAccessTo[EnPermissions.EditUser];
            btnDeleteUser.Enabled = IsUserCanAccessTo[EnPermissions.DeleteUser];
            btnChangePassword.Enabled = IsUserCanAccessTo[EnPermissions.ChangePasswords];
        }

        private async Task LoadUsersDataToGridView()
        {
            _fullUsersTB = await ClsBL_User.Load();

            dgvUser.DataSource = _fullUsersTB;
            ucFilter1.LinkFilterWithDataTable(ref _fullUsersTB);
        }

        private void DgvUser_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView dgv = (DataGridView)sender;
                int rowIndex = dgv.HitTest(e.X, e.Y).RowIndex;
                if (rowIndex >= 0)
                {
                    dgv.ClearSelection();
                    dgv.Rows[rowIndex].Cells[0].Selected = true;
                }
            }
        }

        private async void BtnAddUser_Click(object sender, EventArgs e)
        {
            await AddEditUser(isEdit: false);
        }

        private async void BtnShowUserDetails_Click(object sender, EventArgs e)
        {
            await ShowUserDetails();
        }

        private async Task ShowUserDetails()
        {
            int userID = (int)dgvUser.CurrentRow.Cells[0].Value;
            FRMUserDetails userDetails = new FRMUserDetails(userID);
            userDetails.ShowDialog();
            await LoadUsersDataToGridView();
        }

        private void AddUser()
        {
            FRMAddEditUser addEditUser = new FRMAddEditUser();
            addEditUser.ShowDialog();
        }

        private void EditUser(int userID)
        {
            FRMAddEditUser addEditUser = new FRMAddEditUser(userID);
            addEditUser.ShowDialog();
        }

        private async Task AddEditUser(bool isEdit)
        {
            if (isEdit)
                EditUser((int)dgvUser.CurrentRow.Cells[0].Value);
            else
                AddUser();

            await LoadUsersDataToGridView();
        }

        private async void Btn2AddUser_Click(object sender, EventArgs e)
        {
            await AddEditUser(isEdit: false);
        }

        private async void BtnEditUser_Click(object sender, EventArgs e)
        {
            await AddEditUser(isEdit: true);
        }

        private async void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            int userID = (int)dgvUser.CurrentRow.Cells[0].Value;

            if (!await ClsBL_User.IsExistByUserID(userID))
            {
                MessageBox.Show("User Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are You Sure Do You Want To Delete This Record", "Confrim", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            if (await ClsBL_User.Delete(userID))
            {
                MessageBox.Show("User Deleted Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadUsersDataToGridView();
            }
            else
            {
                MessageBox.Show("Failed To Delete User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await LoadUsersDataToGridView();
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            int userID = (int)dgvUser.CurrentRow.Cells[0].Value;
            FRMChangePassword changePassword = new FRMChangePassword(userID);
            changePassword.ShowDialog();
        }
    }
}
