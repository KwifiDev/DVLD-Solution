using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI
{
    public partial class FRMPersonDetails : KryptonForm
    {
        private readonly int _personID = -1;
        private readonly string _nationalNo = null;

        public FRMPersonDetails(int personID)
        {
            InitializeComponent();
            _personID = personID;
        }

        public FRMPersonDetails(string nationalNo)
        {
            InitializeComponent();
            _nationalNo = nationalNo;
        }

        private async void PersonDetailsForm_Load(object sender, EventArgs e)
        {
            if (_personID != -1)
            {
                await ucPersonInfo1.LoadPersonData(_personID);
                return;
            }

            if (_nationalNo != null)
            {
                await ucPersonInfo1.LoadPersonData(_nationalNo);
                return;
            }

            // If Person Not Found
            MessageBox.Show("Person Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }
    }
}
