using ComponentFactory.Krypton.Toolkit;
using System;

namespace DVLD_UI.Froms
{
    public partial class FRMIssueDrivingLicneseFirstTime : KryptonForm
    {
        int _ldlApplicationID;

        public FRMIssueDrivingLicneseFirstTime(int ldlApplicationID)
        {
            InitializeComponent();
            _ldlApplicationID = ldlApplicationID;
        }

        private async void FRMIssueDrivingLicneseFirstTime_Load(object sender, EventArgs e)
        {
            await ucIssueDrivingLicense1.LoadData(_ldlApplicationID);
        }
    }
}
