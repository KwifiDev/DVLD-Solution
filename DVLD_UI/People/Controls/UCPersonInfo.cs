using DVLD_BL;
using DVLD_UI.Properties;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_BL.ClsBL_User;
using static DVLD_UI.ClsGlobal;

namespace DVLD_UI
{
    public partial class UCPersonInfo : UserControl
    {
        private int _personID = -1;

        public int PersonID
        {
            get { return _personID; }
        }


        ClsBL_Person _person;

        public UCPersonInfo()
        {
            InitializeComponent();
        }

        public async Task<bool> LoadPersonData(int personID)
        {
            _person = await ClsBL_Person.Find(personID);
            return LoadPersonData();
        }

        public async Task<bool> LoadPersonData(string nationalNo)
        {
            _person = await ClsBL_Person.Find(nationalNo);
            return LoadPersonData();
        }

        private bool LoadPersonData()
        {
            if (_person != null)
            {
                _personID = _person.PersonID;
                LoadPersonInfo();
                return true;
            }
            else
            {
                _personID = -1;
                ResetControls();
                MessageBox.Show("Person Not Found", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private void ResetControls()
        {
            lblPersonID.Text = "???";
            lblNationalNo.Text = "???";
            lblFirstName.Text = "???";
            lblSecondName.Text = "???";
            lblThirdName.Text = "???";
            lblLastName.Text = "???";
            lblAddress.Text = "???";
            lblDateOfBirth.Text = "???";
            lblGendor.Text = "???";
            lblPhone.Text = "???";
            lblEmail.Text = "???";
            lblCountryName.Text = "???";
            pbPersonalPhoto.ImageLocation = default;
            llEditPersonInfo.Enabled = false;
        }

        private void LoadPersonInfo()
        {
            lblPersonID.Text = _person.PersonID.ToString();
            lblNationalNo.Text = _person.NationalNo.ToString();
            lblFirstName.Text = _person.FirstName;
            lblSecondName.Text = _person.SecondName;
            lblThirdName.Text = _person.ThirdName;
            lblLastName.Text = _person.LastName;
            lblAddress.Text = _person.Address;
            lblDateOfBirth.Text = _person.DateOfBirth.ToShortDateString();
            lblGendor.Text = _person.Gendor == 0 ? "Male" : "Female";
            lblPhone.Text = _person.Phone;
            lblEmail.Text = _person.Email;
            lblCountryName.Text = _person.CountryInfo.CountryName;
            pbPersonalPhoto.ImageLocation = string.IsNullOrEmpty(_person.ImagePath) ? _GetDefaultImage() : _LoadPersonImage();
            llEditPersonInfo.Enabled = IsUserCanAccessTo[EnPermissions.EditPerson];
        }

        private string _LoadPersonImage()
        {
            if (File.Exists(_person.ImagePath))
            {
                return _person.ImagePath;
            }
            else
            {
                MessageBox.Show("Could not find this image: = " + _person.ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return _GetDefaultImage();
            }
        }

        private string _GetDefaultImage()
        {
            pbPersonalPhoto.Image = _person.Gendor == 0 ? Resources.UnknownMale : Resources.UnknownFemale;

            return null;
        }

        private async void LlEditPersonInfo_LinkClicked(object sender, EventArgs e)
        {
            FRMAddEditPerson addEditPerson = await FRMAddEditPerson.CreateAsync(_person.PersonID);
            addEditPerson.ShowDialog();
            await LoadPersonData(_person.PersonID);
        }
    }
}
