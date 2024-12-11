using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.UserControls
{
    public partial class UCEditTestType : UserControl
    {
        private ClsBL_TestType _testType;

        public UCEditTestType()
        {
            InitializeComponent();
        }

        public async Task LoadTestTypeByID(ClsBL_TestType.EnType testType)
        {
            _testType = await ClsBL_TestType.Find(testType);

            if (_testType == null)
            {
                MessageBox.Show("Cant Find TestType", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FillTestTypeToVisualControl();

        }

        private void FillTestTypeToVisualControl()
        {
            lblTestTypeID.Text = _testType.TestType.ToString();
            txtTestTypeTitle.Text = _testType.TestTypeTitle;
            txtTestTypeDescription.Text = _testType.TestTypeDescription;
            nudTestTypeFees.Value = (decimal)_testType.TestTypeFees;
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (!FieldsIsValid())
            {
                MessageBox.Show("Some Fields Not Valid Check the Erorr", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LoadDataToObject();

            if (await _testType.Save())
            {
                MessageBox.Show("Test Type Saved Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed To Save Test Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataToObject()
        {
            _testType.TestTypeTitle = txtTestTypeTitle.Text;
            _testType.TestTypeDescription = txtTestTypeDescription.Text;
            _testType.TestTypeFees = (float)nudTestTypeFees.Value;
        }

        private bool FieldsIsValid()
        {
            return ValidateTextBoxs(txtTestTypeTitle) && ValidateTextBoxs(txtTestTypeDescription);
        }

        private bool ValidateTextBoxs(KryptonTextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                ShowErrorAndFocus(textBox, $"Please Set {textBox.Name}");
                return false;
            }

            ClearError(textBox);
            return true;
        }

        private void ShowErrorAndFocus(KryptonTextBox textBox, string errorMessage)
        {
            errorProvider.SetError(textBox, errorMessage);
        }

        private void ClearError(KryptonTextBox textBox)
        {
            errorProvider.SetError(textBox, "");
        }
    }
}
