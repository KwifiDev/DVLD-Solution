using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_BL.ClsBL_User;
using static DVLD_UI.ClsGlobal;


namespace DVLD_UI
{
    public partial class FRMManagePeople : KryptonForm
    {

        private static DataTable _fullPeopleTB;

        private DataTable _peopleTB;

        public FRMManagePeople()
        {
            InitializeComponent();
            dgvPerson.MouseDown += DgvPerson_MouseDown;
            
        }

        private async void LoadPeopleDataToGridView()
        {
            _fullPeopleTB = await ClsBL_Person.Load();

            _peopleTB = _fullPeopleTB.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                          "FirstName", "LastName", "Gendor", "DateOfBirth", "Phone");
            dgvPerson.DataSource = _peopleTB;
            ucFilter1.LinkFilterWithDataTable(ref _peopleTB);
        }

        private void ManagePeopleForm_Load(object sender, EventArgs e)
        {
            LoadPeopleDataToGridView();
            InitializePermissions();
        }

        private void InitializePermissions()
        {
            btn2AddPerson.Enabled = IsUserCanAccessTo[EnPermissions.AddPerson];
            btnAddPerson.Enabled = IsUserCanAccessTo[EnPermissions.AddPerson];
            btnEditPerson.Enabled = IsUserCanAccessTo[EnPermissions.EditPerson];
            btnDeletePerson.Enabled = IsUserCanAccessTo[EnPermissions.DeletePerson];
        }

        private void DgvPerson_MouseDown(object sender, MouseEventArgs e)
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

        private void ShowPersonDetails()
        {
            int personID = (int)dgvPerson.CurrentRow.Cells[0].Value;
            FRMPersonDetails personDetails = new FRMPersonDetails(personID);
            personDetails.ShowDialog();
            LoadPeopleDataToGridView();

        }

        private async Task AddEditPerson(bool isEdit)
        {
            int personID = isEdit ? (int)dgvPerson.CurrentRow.Cells[0].Value : -1;
            FRMAddEditPerson addEditPerson = await FRMAddEditPerson.CreateAsync(personID);
            addEditPerson.ShowDialog();
            LoadPeopleDataToGridView();
        }

        private void BtnShowPersonDetails_Click(object sender, EventArgs e)
        {
            ShowPersonDetails();
        }

        private async void Btn2AddPerson_Click(object sender, EventArgs e)
        {
            await AddEditPerson(isEdit: false);
        }

        private async void BtnEditPerson_Click(object sender, EventArgs e)
        {
            await AddEditPerson(isEdit: true);
        }

        private async void BtnDeletePerson_Click(object sender, EventArgs e)
        {
            int personID = (int)dgvPerson.CurrentRow.Cells[0].Value;

            if (!await ClsBL_Person.IsExist(personID))
            {
                MessageBox.Show("Person Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are You Sure Do You Want To Delete This Record", "Confrim", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            if (await ClsBL_Person.Delete(personID))
            {
                MessageBox.Show("Person Deleted Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPeopleDataToGridView();
            }
            else
            {
                MessageBox.Show("Failed To Delete Person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnAddPerson_Click(object sender, EventArgs e)
        {
            await AddEditPerson(isEdit: false);
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadPeopleDataToGridView();
        }

    }
}
