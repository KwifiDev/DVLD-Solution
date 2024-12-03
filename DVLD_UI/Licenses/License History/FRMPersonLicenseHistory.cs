using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using System;
using System.Threading.Tasks;

namespace DVLD_UI.Froms
{
    public partial class FRMPersonLicenseHistory : KryptonForm
    {
        private int _personID = -1;

        public FRMPersonLicenseHistory()
        {
            InitializeComponent();
        }

        public FRMPersonLicenseHistory(int personID)
        {
            InitializeComponent();
            _personID = personID;
        }

        private void FRMPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            if (_personID == -1) return;

            ucFindPerson1.SelectPerson(_personID);
        }

        private async void UcFindPerson1_OnPersonFound(bool isPersonFound)
        {
            if (isPersonFound)
            {
                ucFindPerson1.Filter_Enabled = false;

                _personID = ucFindPerson1.PersonID;

                await ucDriverLicenses1.LoadDriverLicensesByPersonID(_personID);
            }
        }
    }
}
