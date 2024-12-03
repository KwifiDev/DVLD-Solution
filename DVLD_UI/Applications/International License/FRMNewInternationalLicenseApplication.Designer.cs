namespace DVLD_UI.Froms
{
    partial class FRMNewInternationalLicenseApplication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucInterNationalApplicationInfo1 = new DVLD_UI.UserControls.UCInternationalApplicationInfo();
            this.ucFindLicense1 = new DVLD_UI.UserControls.UCFindLicense();
            this.SuspendLayout();
            // 
            // ucInterNationalApplicationInfo1
            // 
            this.ucInterNationalApplicationInfo1.BackColor = System.Drawing.Color.White;
            this.ucInterNationalApplicationInfo1.Location = new System.Drawing.Point(3, 407);
            this.ucInterNationalApplicationInfo1.Name = "ucInterNationalApplicationInfo1";
            this.ucInterNationalApplicationInfo1.Size = new System.Drawing.Size(515, 179);
            this.ucInterNationalApplicationInfo1.TabIndex = 1;
            this.ucInterNationalApplicationInfo1.OnLicenseIssued += new System.Action(this.UcInterNationalApplicationInfo1_OnLicenseIssued);
            // 
            // ucFindLicense1
            // 
            this.ucFindLicense1.BackColor = System.Drawing.Color.White;
            this.ucFindLicense1.Location = new System.Drawing.Point(3, 1);
            this.ucFindLicense1.Name = "ucFindLicense1";
            this.ucFindLicense1.Size = new System.Drawing.Size(515, 400);
            this.ucFindLicense1.TabIndex = 0;
            this.ucFindLicense1.OnLicenseFoundAndActive += new System.Action<DVLD_BL.ClsBL_License>(this.UcFindLicense1_OnLicenseFoundAndActive);
            this.ucFindLicense1.OnInvalidLicense += new System.Action(this.UcFindLicense1_OnInvalidLicense);
            // 
            // FRMNewInternationalLicenseApplication
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(521, 587);
            this.Controls.Add(this.ucInterNationalApplicationInfo1);
            this.Controls.Add(this.ucFindLicense1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRMNewInternationalLicenseApplication";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.StateCommon.Border.Color1 = System.Drawing.Color.Red;
            this.StateCommon.Border.Color2 = System.Drawing.Color.Red;
            this.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Header.Back.Color1 = System.Drawing.Color.Red;
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.Firebrick;
            this.StateCommon.Header.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Font = new System.Drawing.Font("Liberation Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Text = "New International License Application";
            this.Load += new System.EventHandler(this.FRMNewInternationalLicenseApplication_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private UserControls.UCInternationalApplicationInfo ucInterNationalApplicationInfo1;
        internal UserControls.UCFindLicense ucFindLicense1;
    }
}