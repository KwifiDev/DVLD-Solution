using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using System;
using System.Windows.Forms;

namespace DVLD_UI.UserControls
{
    public partial class UCEditApplicationType : UserControl
    {
        private ClsBL_ApplicationType _applicationType;
        public UCEditApplicationType()
        {
            InitializeComponent();
        }

        public void LoadApplicationTypeByID(int applicationTypeID)
        {
            _applicationType = ClsBL_ApplicationType.Find(applicationTypeID);

            if (_applicationType == null)
            {
                MessageBox.Show("Cant Find ApplicationType", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FillApplicationTypeToVisualControl();

        }

        private void FillApplicationTypeToVisualControl()
        {
            lblApplicationTypeID.Text = _applicationType.ApplicationTypeID.ToString();
            txtApplicationTypeTitle.Text = _applicationType.ApplicationTypeTitle;
            nudApplicationTypeFees.Value = (decimal)_applicationType.ApplicationFees;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (!FieldsIsValid())
            {
                MessageBox.Show("Some Fields Not Valid Check the Erorr", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _applicationType = LoadDataToObject(_applicationType);

            if (_applicationType.Save())
            {
                MessageBox.Show("Application Type Saved Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed To Save Application Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ClsBL_ApplicationType LoadDataToObject(ClsBL_ApplicationType applicationType)
        {
            applicationType.ApplicationTypeTitle = txtApplicationTypeTitle.Text;
            applicationType.ApplicationFees = (float)nudApplicationTypeFees.Value;

            return applicationType;
        }

        private bool FieldsIsValid()
        {
            return ValidateTextBoxs(txtApplicationTypeTitle);
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
