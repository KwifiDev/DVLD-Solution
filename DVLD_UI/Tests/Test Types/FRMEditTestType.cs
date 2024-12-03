using ComponentFactory.Krypton.Toolkit;
using DVLD_BL;
using System;

namespace DVLD_UI.Froms
{
    public partial class FRMEditTestType : KryptonForm
    {
        private ClsBL_TestType.EnType _testType;

        public FRMEditTestType(ClsBL_TestType.EnType testType)
        {
            InitializeComponent();
            _testType = testType;
        }

        private void FRMEditTestType_Load(object sender, EventArgs e)
        {
            ucEditTestType1.LoadTestTypeByID(_testType);
        }
    }
}
