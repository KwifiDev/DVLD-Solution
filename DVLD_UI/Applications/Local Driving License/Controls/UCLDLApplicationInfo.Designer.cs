namespace DVLD_UI.UserControls
{
    partial class UCLDLApplicationInfo
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
            this.gbApplicationInfo = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.lLblViewLicenseInfo = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.lblPassedTests = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblAppliedLicense = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblLDLApplicationID = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.ucApplicationInfo1 = new DVLD_UI.UserControls.UCApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.gbApplicationInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbApplicationInfo.Panel)).BeginInit();
            this.gbApplicationInfo.Panel.SuspendLayout();
            this.gbApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbApplicationInfo
            // 
            this.gbApplicationInfo.Location = new System.Drawing.Point(0, 0);
            this.gbApplicationInfo.Name = "gbApplicationInfo";
            this.gbApplicationInfo.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            // 
            // gbApplicationInfo.Panel
            // 
            this.gbApplicationInfo.Panel.Controls.Add(this.lLblViewLicenseInfo);
            this.gbApplicationInfo.Panel.Controls.Add(this.lblPassedTests);
            this.gbApplicationInfo.Panel.Controls.Add(this.lblAppliedLicense);
            this.gbApplicationInfo.Panel.Controls.Add(this.lblLDLApplicationID);
            this.gbApplicationInfo.Panel.Controls.Add(this.kryptonLabel6);
            this.gbApplicationInfo.Panel.Controls.Add(this.kryptonLabel5);
            this.gbApplicationInfo.Panel.Controls.Add(this.kryptonLabel1);
            this.gbApplicationInfo.Size = new System.Drawing.Size(487, 95);
            this.gbApplicationInfo.TabIndex = 1;
            this.gbApplicationInfo.Values.Heading = "Local Driving License Application Info";
            // 
            // lLblViewLicenseInfo
            // 
            this.lLblViewLicenseInfo.Enabled = false;
            this.lLblViewLicenseInfo.Location = new System.Drawing.Point(372, 3);
            this.lLblViewLicenseInfo.Name = "lLblViewLicenseInfo";
            this.lLblViewLicenseInfo.Size = new System.Drawing.Size(108, 20);
            this.lLblViewLicenseInfo.TabIndex = 23;
            this.lLblViewLicenseInfo.Values.Text = "Show License Info";
            this.lLblViewLicenseInfo.LinkClicked += new System.EventHandler(this.LLblViewLicenseInfo_LinkClicked);
            // 
            // lblPassedTests
            // 
            this.lblPassedTests.Location = new System.Drawing.Point(262, 14);
            this.lblPassedTests.Name = "lblPassedTests";
            this.lblPassedTests.Size = new System.Drawing.Size(27, 20);
            this.lblPassedTests.TabIndex = 22;
            this.lblPassedTests.Values.Text = "???";
            // 
            // lblAppliedLicense
            // 
            this.lblAppliedLicense.Location = new System.Drawing.Point(119, 40);
            this.lblAppliedLicense.Name = "lblAppliedLicense";
            this.lblAppliedLicense.Size = new System.Drawing.Size(27, 20);
            this.lblAppliedLicense.TabIndex = 21;
            this.lblAppliedLicense.Values.Text = "???";
            // 
            // lblLDLApplicationID
            // 
            this.lblLDLApplicationID.Location = new System.Drawing.Point(120, 14);
            this.lblLDLApplicationID.Name = "lblLDLApplicationID";
            this.lblLDLApplicationID.Size = new System.Drawing.Size(27, 20);
            this.lblLDLApplicationID.TabIndex = 19;
            this.lblLDLApplicationID.Values.Text = "???";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(187, 14);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(85, 20);
            this.kryptonLabel6.TabIndex = 18;
            this.kryptonLabel6.Values.Text = "Passed Tests :";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(6, 40);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(123, 20);
            this.kryptonLabel5.TabIndex = 17;
            this.kryptonLabel5.Values.Text = "Applied For License :";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(15, 14);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(114, 20);
            this.kryptonLabel1.TabIndex = 15;
            this.kryptonLabel1.Values.Text = "LDL ApplicationID :";
            // 
            // ucApplicationInfo1
            // 
            this.ucApplicationInfo1.Location = new System.Drawing.Point(0, 101);
            this.ucApplicationInfo1.Name = "ucApplicationInfo1";
            this.ucApplicationInfo1.Size = new System.Drawing.Size(487, 173);
            this.ucApplicationInfo1.TabIndex = 2;
            // 
            // UCLDLApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucApplicationInfo1);
            this.Controls.Add(this.gbApplicationInfo);
            this.Name = "UCLDLApplicationInfo";
            this.Size = new System.Drawing.Size(487, 275);
            ((System.ComponentModel.ISupportInitialize)(this.gbApplicationInfo.Panel)).EndInit();
            this.gbApplicationInfo.Panel.ResumeLayout(false);
            this.gbApplicationInfo.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbApplicationInfo)).EndInit();
            this.gbApplicationInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox gbApplicationInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblPassedTests;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblAppliedLicense;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblLDLApplicationID;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel lLblViewLicenseInfo;
        private UCApplicationInfo ucApplicationInfo1;
    }
}
