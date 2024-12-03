using ComponentFactory.Krypton.Toolkit;
using System;

namespace DVLD_UI.Froms
{
    public partial class FRMUserDetails : KryptonForm
    {
        private readonly int _userID;

        public FRMUserDetails(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private async void FRMUserDetails_Load(object sender, EventArgs e)
        {
            await ucUserInfo1.LoadUserData(_userID);
        }
    }
}
