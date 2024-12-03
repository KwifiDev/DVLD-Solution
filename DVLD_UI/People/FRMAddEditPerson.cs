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
    public partial class FRMAddEditPerson : KryptonForm
    {
        public delegate void BackDataPersonIDHandle(int personID);
        public event BackDataPersonIDHandle BackPersonID;

        private FRMAddEditPerson()
        {
            InitializeComponent();
        }
        
        private async Task InitializeAsync(int personID)
        {
            await ucAddEditPerson1.LoadData(personID);
        }

        public static async Task<FRMAddEditPerson> CreateAsync(int personID = -1)
        {
            FRMAddEditPerson frm = new FRMAddEditPerson();
            await frm.InitializeAsync(personID);
            return frm;
        }

        private void UcAddEditPerson1_OnSaveSuccess()
        {
            panelMode.BackColor = Color.DarkOrange;
            lblPersonMode.Text = "Edit Person";
            BackPersonID?.Invoke(ucAddEditPerson1.PersonID);
        }
    }

}
