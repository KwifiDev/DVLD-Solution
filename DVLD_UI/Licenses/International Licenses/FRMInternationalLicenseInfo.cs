using ComponentFactory.Krypton.Toolkit;
using System;

namespace DVLD_UI.Froms
{
    public partial class FRMInternationalLicenseInfo : KryptonForm
    {
        private int _internationalLicenseID;

        public FRMInternationalLicenseInfo(int internationalLicenseID)
        {
            InitializeComponent();
            _internationalLicenseID = internationalLicenseID;
        }

        private async void FRMInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            await ucInternationalLicenseInfo1.LoadData(_internationalLicenseID);
        }
    }
}
