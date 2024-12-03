using ComponentFactory.Krypton.Toolkit;
using System;

namespace DVLD_UI.Froms
{
    public partial class FRMLDLApplictionInfo : KryptonForm
    {
        private int _localDrivingLicenseApplication;

        public FRMLDLApplictionInfo(int localDrivingLicenseApplication)
        {
            InitializeComponent();
            _localDrivingLicenseApplication = localDrivingLicenseApplication;
        }

        private async void FRMLDLApplictionInfo_Load(object sender, EventArgs e)
        {
            await ucldlApplicationInfo1.LoadDataByLDLApplicationID(_localDrivingLicenseApplication);
        }
    }
}
