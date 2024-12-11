using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Froms
{
    public partial class FRMManageTestTypes : KryptonForm
    {
        DataTable _testTypesTB; 

        public FRMManageTestTypes()
        {
            InitializeComponent();
        }

        private async void FRMManageTestTypes_Load(object sender, EventArgs e)
        {
            await LoadTestTypesToGridView();
        }

        private async Task LoadTestTypesToGridView()
        {
            _testTypesTB = await ClsBL_TestType.Load();
            dgvTestTypes.DataSource = _testTypesTB;
        }

        private async void BtnEditTestType_Click(object sender, EventArgs e)
        {
            ClsBL_TestType.EnType testTypeID = (ClsBL_TestType.EnType)dgvTestTypes.CurrentRow.Cells[0].Value;
            FRMEditTestType editTestType = new FRMEditTestType(testTypeID);
            editTestType.ShowDialog();
            await LoadTestTypesToGridView();
        }

        private async void BtnRefreshData_Click(object sender, EventArgs e)
        {
            await LoadTestTypesToGridView();
        }

        private void DgvTestTypes_MouseDown(object sender, MouseEventArgs e)
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
    }
}
