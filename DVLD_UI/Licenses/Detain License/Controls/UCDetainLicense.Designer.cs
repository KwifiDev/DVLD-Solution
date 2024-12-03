namespace DVLD_UI.UserControls
{
    partial class UCDetainLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCDetainLicense));
            this.gbDetainLicense = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.nudFineFees = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.lblCreatedByUser = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblLicenseID = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblDetainDate = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblDetainID = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lLblLicenseHistory = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.lLblLicenseInfo = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.btnDetainLicense = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.gbDetainLicense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbDetainLicense.Panel)).BeginInit();
            this.gbDetainLicense.Panel.SuspendLayout();
            this.gbDetainLicense.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDetainLicense
            // 
            this.gbDetainLicense.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDetainLicense.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ButtonAlternate;
            this.gbDetainLicense.Location = new System.Drawing.Point(0, 0);
            this.gbDetainLicense.Name = "gbDetainLicense";
            this.gbDetainLicense.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            // 
            // gbDetainLicense.Panel
            // 
            this.gbDetainLicense.Panel.Controls.Add(this.nudFineFees);
            this.gbDetainLicense.Panel.Controls.Add(this.lblCreatedByUser);
            this.gbDetainLicense.Panel.Controls.Add(this.lblLicenseID);
            this.gbDetainLicense.Panel.Controls.Add(this.lblDetainDate);
            this.gbDetainLicense.Panel.Controls.Add(this.lblDetainID);
            this.gbDetainLicense.Panel.Controls.Add(this.kryptonLabel8);
            this.gbDetainLicense.Panel.Controls.Add(this.kryptonLabel5);
            this.gbDetainLicense.Panel.Controls.Add(this.kryptonLabel4);
            this.gbDetainLicense.Panel.Controls.Add(this.kryptonLabel2);
            this.gbDetainLicense.Panel.Controls.Add(this.kryptonLabel1);
            this.gbDetainLicense.Size = new System.Drawing.Size(515, 126);
            this.gbDetainLicense.TabIndex = 0;
            this.gbDetainLicense.Values.Heading = "Detain License";
            // 
            // nudFineFees
            // 
            this.nudFineFees.Enabled = false;
            this.nudFineFees.Location = new System.Drawing.Point(120, 63);
            this.nudFineFees.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudFineFees.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudFineFees.Name = "nudFineFees";
            this.nudFineFees.Size = new System.Drawing.Size(71, 22);
            this.nudFineFees.TabIndex = 16;
            this.nudFineFees.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblCreatedByUser
            // 
            this.lblCreatedByUser.Location = new System.Drawing.Point(375, 63);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(27, 20);
            this.lblCreatedByUser.TabIndex = 15;
            this.lblCreatedByUser.Values.Text = "???";
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.Location = new System.Drawing.Point(375, 11);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(27, 20);
            this.lblLicenseID.TabIndex = 12;
            this.lblLicenseID.Values.Text = "???";
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.Location = new System.Drawing.Point(115, 37);
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.Size = new System.Drawing.Size(27, 20);
            this.lblDetainDate.TabIndex = 9;
            this.lblDetainDate.Values.Text = "???";
            // 
            // lblDetainID
            // 
            this.lblDetainID.Location = new System.Drawing.Point(115, 11);
            this.lblDetainID.Name = "lblDetainID";
            this.lblDetainID.Size = new System.Drawing.Size(27, 20);
            this.lblDetainID.TabIndex = 8;
            this.lblDetainID.Values.Text = "???";
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(309, 63);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(76, 20);
            this.kryptonLabel8.TabIndex = 7;
            this.kryptonLabel8.Values.Text = "Created By :";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(311, 11);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(72, 20);
            this.kryptonLabel5.TabIndex = 4;
            this.kryptonLabel5.Values.Text = "License ID :";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(55, 63);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(67, 20);
            this.kryptonLabel4.TabIndex = 3;
            this.kryptonLabel4.Values.Text = "Fine Fees :";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(42, 37);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(81, 20);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Detain Date :";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(58, 11);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(64, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "DetainID :";
            // 
            // lLblLicenseHistory
            // 
            this.lLblLicenseHistory.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lLblLicenseHistory.Enabled = false;
            this.lLblLicenseHistory.Location = new System.Drawing.Point(13, 135);
            this.lLblLicenseHistory.Name = "lLblLicenseHistory";
            this.lLblLicenseHistory.Size = new System.Drawing.Size(131, 20);
            this.lLblLicenseHistory.TabIndex = 1;
            this.lLblLicenseHistory.Values.Text = "Show Licesnes History";
            this.lLblLicenseHistory.LinkClicked += new System.EventHandler(this.LLblLicenseHistory_LinkClicked);
            // 
            // lLblLicenseInfo
            // 
            this.lLblLicenseInfo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lLblLicenseInfo.Enabled = false;
            this.lLblLicenseInfo.Location = new System.Drawing.Point(150, 135);
            this.lLblLicenseInfo.Name = "lLblLicenseInfo";
            this.lLblLicenseInfo.Size = new System.Drawing.Size(108, 20);
            this.lLblLicenseInfo.TabIndex = 2;
            this.lLblLicenseInfo.Values.Text = "Show Licesne Info";
            this.lLblLicenseInfo.LinkClicked += new System.EventHandler(this.LLblLicenseInfo_LinkClicked);
            // 
            // btnDetainLicense
            // 
            this.btnDetainLicense.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDetainLicense.Enabled = false;
            this.btnDetainLicense.Location = new System.Drawing.Point(428, 132);
            this.btnDetainLicense.Name = "btnDetainLicense";
            this.btnDetainLicense.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnDetainLicense.Size = new System.Drawing.Size(84, 31);
            this.btnDetainLicense.StateCommon.Back.Color1 = System.Drawing.Color.Firebrick;
            this.btnDetainLicense.StateCommon.Back.Color2 = System.Drawing.Color.Red;
            this.btnDetainLicense.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnDetainLicense.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnDetainLicense.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetainLicense.TabIndex = 3;
            this.btnDetainLicense.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnDetainLicense.Values.Image")));
            this.btnDetainLicense.Values.Text = "Detain";
            this.btnDetainLicense.Click += new System.EventHandler(this.BtnDetainLicense_Click);
            // 
            // UCDetainLicense
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbDetainLicense);
            this.Controls.Add(this.btnDetainLicense);
            this.Controls.Add(this.lLblLicenseInfo);
            this.Controls.Add(this.lLblLicenseHistory);
            this.Name = "UCDetainLicense";
            this.Size = new System.Drawing.Size(515, 166);
            ((System.ComponentModel.ISupportInitialize)(this.gbDetainLicense.Panel)).EndInit();
            this.gbDetainLicense.Panel.ResumeLayout(false);
            this.gbDetainLicense.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbDetainLicense)).EndInit();
            this.gbDetainLicense.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox gbDetainLicense;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblCreatedByUser;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblLicenseID;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblDetainDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblDetainID;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel lLblLicenseHistory;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel lLblLicenseInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDetainLicense;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown nudFineFees;
    }
}
