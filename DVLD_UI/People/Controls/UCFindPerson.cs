using System;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DVLD_UI.UserControls
{
    public partial class UCFindPerson : UserControl
    {
        public event Action<bool> OnPersonFound;

        protected virtual void PersonFound(bool isPersonFound)
        {
            OnPersonFound?.Invoke(isPersonFound);
        }

        public int PersonID
        {
            get { return ucPersonInfo1.PersonID; }
        }

        public bool BtnAddPerson_Visible
        {
            get { return btnAddPerson.Visible; }
            set { btnAddPerson.Visible = value; }
        }

        public bool Filter_Enabled
        {
            get { return gbFindPerson.Enabled; }
            set 
            {
                gbFindPerson.Enabled = value;
                btnUserSearch.Enabled = value;
                btnAddPerson.Enabled = value;
            }
        }

        public UCFindPerson()
        {
            InitializeComponent();
            cbFindBy.SelectedIndex = 0;
        }

        private async void BtnUserSearch_Click(object sender, EventArgs e)
        {
            if (!DataIsValid()) return;

            if (!this.ValidateChildren())
            {
                MessageBox.Show
                    ("Some fields are not valid! Put the mouse over the red icon(s) to see the error.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await FindPerson();
        }

        private async Task FindPerson()
        {
            string selectedItem = cbFindBy.SelectedItem.ToString();
            string searchText = txtFindPerson.Text;
            bool isPersonFound = false;

            switch (selectedItem)
            {
                case "PersonID":
                    if (int.TryParse(searchText, out int personID))
                        isPersonFound = await ucPersonInfo1.LoadPersonData(personID);
                    break;

                case "NationalNo":
                    isPersonFound = await ucPersonInfo1.LoadPersonData(searchText);
                    break;
            }

            OnPersonFound?.Invoke(isPersonFound);
        }

        private async void BtnAddPerson_Click(object sender, EventArgs e)
        {
            FRMAddEditPerson addPerson = await FRMAddEditPerson.CreateAsync();
            addPerson.BackPersonID += SelectPerson;
            addPerson.ShowDialog();
        }

        internal void SelectPerson(int personID)
        {
            cbFindBy.SelectedIndex = 0;
            txtFindPerson.Text = personID.ToString();
            BtnUserSearch_Click(null, EventArgs.Empty);
            Filter_Enabled = false;
        }

        private void TxtFindPerson_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // 13 : Enter key
                btnUserSearch.PerformClick();

            if (((string)cbFindBy.SelectedItem).EndsWith("ID") && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtFindPerson_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFindPerson.Text.Trim()))
            {
                //e.Cancel = true;
                errorProvider.SetError(txtFindPerson, "This field is required!");
            }
            else
            {
                errorProvider.SetError(txtFindPerson, null);
            }
        }

        private void CbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFindPerson.Text = "";
            txtFindPerson.Focus();
        }

        private bool DataIsValid()
        {
            if (string.IsNullOrEmpty(txtFindPerson.Text.Trim()))
            {
                ShowMessage("Please Enter Person ID / National Number");
                return false;
            }
            return true;
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
