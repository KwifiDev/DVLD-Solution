namespace DVLD_UI.UserControls
{
    partial class UCFindLicense
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCFindLicense));
            this.ucLicenseInfo1 = new DVLD_UI.UserControls.UCLicenseInfo();
            this.gbFilter = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.btnFindLicense = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtLicenseID = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gbFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbFilter.Panel)).BeginInit();
            this.gbFilter.Panel.SuspendLayout();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucLicenseInfo1
            // 
            this.ucLicenseInfo1.BackColor = System.Drawing.Color.White;
            this.ucLicenseInfo1.Location = new System.Drawing.Point(7, 94);
            this.ucLicenseInfo1.Name = "ucLicenseInfo1";
            this.ucLicenseInfo1.Size = new System.Drawing.Size(500, 300);
            this.ucLicenseInfo1.TabIndex = 0;
            // 
            // gbFilter
            // 
            this.gbFilter.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ButtonAlternate;
            this.gbFilter.Location = new System.Drawing.Point(7, 6);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            // 
            // gbFilter.Panel
            // 
            this.gbFilter.Panel.Controls.Add(this.btnFindLicense);
            this.gbFilter.Panel.Controls.Add(this.txtLicenseID);
            this.gbFilter.Panel.Controls.Add(this.kryptonLabel1);
            this.gbFilter.Size = new System.Drawing.Size(500, 82);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.Values.Heading = "Filter";
            // 
            // btnFindLicense
            // 
            this.btnFindLicense.Location = new System.Drawing.Point(418, 3);
            this.btnFindLicense.Name = "btnFindLicense";
            this.btnFindLicense.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnFindLicense.Size = new System.Drawing.Size(77, 53);
            this.btnFindLicense.StateCommon.Back.Color1 = System.Drawing.Color.Firebrick;
            this.btnFindLicense.StateCommon.Back.Color2 = System.Drawing.Color.Red;
            this.btnFindLicense.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnFindLicense.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnFindLicense.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindLicense.TabIndex = 2;
            this.btnFindLicense.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnFindLicense.Values.Image")));
            this.btnFindLicense.Values.Text = "Find";
            this.btnFindLicense.Click += new System.EventHandler(this.BtnFindLicense_Click);
            // 
            // txtLicenseID
            // 
            this.txtLicenseID.Location = new System.Drawing.Point(91, 19);
            this.txtLicenseID.Name = "txtLicenseID";
            this.txtLicenseID.Size = new System.Drawing.Size(172, 23);
            this.txtLicenseID.TabIndex = 1;
            this.txtLicenseID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtLicenseID_KeyPress);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(13, 19);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(72, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "License ID :";
            // 
            // UCFindLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.ucLicenseInfo1);
            this.Name = "UCFindLicense";
            this.Size = new System.Drawing.Size(515, 400);
            ((System.ComponentModel.ISupportInitialize)(this.gbFilter.Panel)).EndInit();
            this.gbFilter.Panel.ResumeLayout(false);
            this.gbFilter.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbFilter)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox gbFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnFindLicense;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLicenseID;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        internal UCLicenseInfo ucLicenseInfo1;
    }
}
