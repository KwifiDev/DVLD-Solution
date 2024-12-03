using ComponentFactory.Krypton.Toolkit;
using System;

namespace DVLD_UI.Froms
{
    public partial class FRMLicenseInfo : KryptonForm
    {
        private int _licenseID;

        public FRMLicenseInfo(int licenseID)
        {
            InitializeComponent();
            _licenseID = licenseID;
        }

        private async void FRMLicenseInfo_Load(object sender, EventArgs e)
        {
            await ucLicenseInfo1.LoadData(_licenseID);
        }
    }
}
