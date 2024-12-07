using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Froms
{
    public partial class FRMManageApplicationTypes : KryptonForm
    {
        public FRMManageApplicationTypes()
        {
            InitializeComponent();
        }

        private async void FRMManageApplicationTypes_Load(object sender, EventArgs e)
        {
            await LoadApplicationTypesToGridView();
        }

        private async Task LoadApplicationTypesToGridView()
        {
            dgvApplicationTypes.DataSource = await ClsBL_ApplicationType.Load();
        }

        private async void BtnEditApplicationType_Click(object sender, EventArgs e)
        {
            int applicationTypeID = (int)dgvApplicationTypes.CurrentRow.Cells[0].Value;
            FRMEditApplicationType editApplicationType = new FRMEditApplicationType(applicationTypeID);
            editApplicationType.ShowDialog();
            await LoadApplicationTypesToGridView();
        }

        private async void BtnRefreshData_Click(object sender, EventArgs e)
        {
            await LoadApplicationTypesToGridView();
        }

        private void DgvApplicationTypes_MouseDown(object sender, MouseEventArgs e)
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
