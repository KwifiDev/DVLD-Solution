using ComponentFactory.Krypton.Toolkit;
using System;

namespace DVLD_UI.Froms
{
    public partial class FRMEditApplicationType : KryptonForm
    {
        private int _applicationTypeID;

        public FRMEditApplicationType(int applicationTypeID)
        {
            InitializeComponent();
            _applicationTypeID = applicationTypeID;
        }

        private async void FRMEditApplicationType_Load(object sender, EventArgs e)
        {
            await ucEditApplicationType1.LoadApplicationTypeByID(_applicationTypeID);
        }
    }
}
