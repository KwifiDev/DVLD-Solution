using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using DVLD_UI.Properties;
using DVLD_UI.Shared_Classes;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI
{
    public partial class UCAddEditPerson : UserControl
    {
        public event Action OnSaveSuccess;
        protected virtual void SaveSuccess()
        {
            Action action = OnSaveSuccess;
            if (action != null) action();
        }

        enum EnMode { Add, Edit }
        EnMode enMode;

        ClsBL_Person _person;
        public int PersonID { get; private set; }

        public UCAddEditPerson()
        {
            InitializeComponent();
        }

        public async Task LoadData(int personID)
        {
            InitializeDefaultData();

            if (personID == -1)
            {
                enMode = EnMode.Add;
                _person = new ClsBL_Person();
                return;
            }

            _person = await ClsBL_Person.Find(personID);

            if (_person != null)
            {
                enMode = EnMode.Edit;

                FillControlsWithPersonData();

                PersonID = _person.PersonID;

                OnSaveSuccess?.Invoke();

                if (pbPersonalPhoto.ImageLocation != null) llRemove.Enabled = true;
            }
        }

        private void InitializeDefaultData()
        {
            cbCounties.DataSource = ClsBL_Country.Load();
            cbCounties.DisplayMember = "CountryName";
            cbCounties.ValueMember = "CountryID";
            cbCounties.SelectedIndex = cbCounties.FindString("Syria"); // Syria

            //we set the max date to 18 years from today, and set the default value the same.
            dtpDateOfBirth.MaxDate = DateTime.Now.Date.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            //should not allow adding age more than 100 years
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
        }

        private void FillControlsWithPersonData()
        {
            lblPersonID.Text = _person.PersonID.ToString();
            txtNationalNo.Text = _person.NationalNo;
            txtFirstName.Text = _person.FirstName;
            txtSecondName.Text = _person.SecondName;
            txtThirdName.Text = _person.ThirdName;
            txtLastName.Text = _person.LastName;
            cbCounties.SelectedValue = _person.NationalityCountryID;
            dtpDateOfBirth.Value = _person.DateOfBirth;
            txtPhone.Text = _person.Phone;
            txtEmail.Text = _person.Email;
            txtAddress.Text = _person.Address;
            if (_person.Gendor == 0) rbMale.Checked = true;
            else rbFemale.Checked = true;
            pbPersonalPhoto.ImageLocation = string.IsNullOrEmpty(_person.ImagePath) ? null : _person.ImagePath;
        }

        private void LlUpload_LinkClicked(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                Filter = "Image Files|*.png;*.jpg;*.jpeg;*.gif;*.bmp",
                Title = "Choose Your Image"
            };

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                pbPersonalPhoto.ImageLocation = openFile.FileName;
                llRemove.Enabled = true;
            }

        }

        private void LlRemove_LinkClicked(object sender, EventArgs e)
        {
            pbPersonalPhoto.ImageLocation = null;
            pbPersonalPhoto.Image = rbMale.Checked ? Resources.UnknownMale : Resources.UnknownFemale;
            llRemove.Enabled = false;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (!await FieldsIsValid())
            {
                MessageBox.Show("Some Fields Not Valid Check the Erorr", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //if (!_HandlePersonImage()) return;

            LoadDataToObject();


            if (await _person.Save())
            {
                MessageBox.Show("Person Saved Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblPersonID.Text = _person.PersonID.ToString();
                PersonID = _person.PersonID;
                enMode = EnMode.Edit;
                OnSaveSuccess?.Invoke();
            }
            else
            {
                MessageBox.Show("Failed To Save Person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool _HandlePersonImage()
        {
            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.

            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_person.ImagePath != pbPersonalPhoto.ImageLocation)
            {
                if (!string.IsNullOrEmpty(_person.ImagePath))
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_person.ImagePath);
                    }
                    catch
                    {
                        // We Use Here Log Framework
                    }
                }

                if (!string.IsNullOrEmpty(pbPersonalPhoto.ImageLocation))
                {
                    string newSourceImage = pbPersonalPhoto.ImageLocation;

                    if (ClsUtility.CopyImageToProjectImagesFolder(ref newSourceImage))
                    {
                        _person.ImagePath = newSourceImage;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        private async Task<bool> FieldsIsValid()
        {
            return await ValidateTextBoxs(txtNationalNo) && await ValidateTextBoxs(txtFirstName) && await ValidateTextBoxs(txtSecondName)
                && await ValidateTextBoxs(txtThirdName) && await ValidateTextBoxs(txtLastName) && await ValidateTextBoxs(txtEmail)
                && await ValidateTextBoxs(txtAddress) && await ValidateTextBoxs(txtPhone);
        }

        private void LoadDataToObject()
        {
            _person.NationalNo = txtNationalNo.Text;
            _person.FirstName = txtFirstName.Text;
            _person.SecondName = txtSecondName.Text;
            _person.ThirdName = txtThirdName.Text;
            _person.LastName = txtLastName.Text;
            _person.NationalityCountryID = Convert.ToByte(cbCounties.SelectedValue);
            _person.DateOfBirth = dtpDateOfBirth.Value;
            _person.Phone = txtPhone.Text;
            _person.Email = txtEmail.Text;
            _person.Address = txtAddress.Text;
            _person.Gendor = rbMale.Checked ? Convert.ToByte(rbMale.Tag) : Convert.ToByte(rbFemale.Tag);
            _person.ImagePath = pbPersonalPhoto.ImageLocation;
        }

        private async void AllTextBoxs_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await ValidateTextBoxs((KryptonTextBox)sender);
        }

        private async Task<bool> ValidateTextBoxs(KryptonTextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                ShowErrorAndFocus(textBox, $"Please Set {textBox.Name}");
                return false;
            }

            if (textBox == txtNationalNo && await IsUsedNationalNo(textBox.Text))
            {
                ShowErrorAndFocus(textBox, $"National Number is Used, Please Enter Another One");
                return false;
            }

            if (textBox == txtEmail && !ClsValidation.ValidateEmail(textBox.Text))
            {
                ShowErrorAndFocus(textBox, $"Email Form Not Correct");
                return false;
            }

            if (textBox == txtPhone && !ClsValidation.IsValidPhone(textBox.Text))
            {
                ShowErrorAndFocus(textBox, $"Phone Number Not Valid");
                return false;
            }

            ClearError(textBox);
            return true;
        }

        private async Task<bool> IsUsedNationalNo(string nationalNo)
        {
            if (await ClsBL_Person.IsExist(nationalNo))
            {
                if (enMode == EnMode.Add)
                {
                    return true;
                }

                if (enMode == EnMode.Edit && nationalNo.ToLower() != _person.NationalNo.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        private void ShowErrorAndFocus(KryptonTextBox textBox, string errorMessage)
        {
            errorProvider.SetError(textBox, errorMessage);
            //textBox.Focus();
        }

        private void ClearError(KryptonTextBox textBox)
        {
            errorProvider.SetError(textBox, "");
        }

        private void RbGendor_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonalPhoto.ImageLocation == null)
                pbPersonalPhoto.Image =
                    ((KryptonRadioButton)sender).Text == "Male" ? Resources.UnknownMale : Resources.UnknownFemale;
        }
    }
}
