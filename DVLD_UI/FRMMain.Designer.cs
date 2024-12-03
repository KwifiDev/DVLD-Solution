namespace DVLD_UI
{
    partial class FRMMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMMain));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.btnApplicationsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDrivingLicensesServicesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNewDrivingLicensesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLocalLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInternationalLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRenewDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReplacementFor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRetakeTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnManageApplicationsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLocalDrivingLicenseApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInternationalLicesneApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDetainLicensesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnManageDetainLicenses = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDetainLicesne = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReleaseDetainedLicnese = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnManageApplicationTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.btnManageTestTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPeople = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDrivers = new System.Windows.Forms.ToolStripMenuItem();
            this.pnMain = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.ucLoginAccountHeader = new DVLD_UI.UCLoginAccountHeader();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnMain)).BeginInit();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.Red;
            this.msMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("msMain.BackgroundImage")));
            this.msMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.msMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnApplicationsMenu,
            this.btnPeople,
            this.btnUsers,
            this.btnDrivers});
            this.msMain.Location = new System.Drawing.Point(0, 392);
            this.msMain.Name = "msMain";
            this.msMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.msMain.Size = new System.Drawing.Size(800, 58);
            this.msMain.TabIndex = 0;
            this.msMain.TabStop = true;
            this.msMain.Text = "MainMenu";
            // 
            // btnApplicationsMenu
            // 
            this.btnApplicationsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDrivingLicensesServicesMenu,
            this.toolStripSeparator2,
            this.btnManageApplicationsMenu,
            this.btnDetainLicensesMenu,
            this.toolStripSeparator3,
            this.btnManageApplicationTypes,
            this.btnManageTestTypes});
            this.btnApplicationsMenu.Font = new System.Drawing.Font("League Spartan", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplicationsMenu.ForeColor = System.Drawing.Color.Black;
            this.btnApplicationsMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnApplicationsMenu.Image")));
            this.btnApplicationsMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnApplicationsMenu.Name = "btnApplicationsMenu";
            this.btnApplicationsMenu.Size = new System.Drawing.Size(153, 54);
            this.btnApplicationsMenu.Text = "Applications";
            // 
            // btnDrivingLicensesServicesMenu
            // 
            this.btnDrivingLicensesServicesMenu.BackColor = System.Drawing.Color.White;
            this.btnDrivingLicensesServicesMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewDrivingLicensesMenu,
            this.btnRenewDrivingLicense,
            this.toolStripSeparator1,
            this.btnReplacementFor,
            this.btnRetakeTest,
            this.toolStripSeparator4,
            this.btnPersonLicenseHistory});
            this.btnDrivingLicensesServicesMenu.Font = new System.Drawing.Font("Bahnschrift", 9.75F);
            this.btnDrivingLicensesServicesMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnDrivingLicensesServicesMenu.Image")));
            this.btnDrivingLicensesServicesMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDrivingLicensesServicesMenu.Name = "btnDrivingLicensesServicesMenu";
            this.btnDrivingLicensesServicesMenu.Size = new System.Drawing.Size(258, 56);
            this.btnDrivingLicensesServicesMenu.Text = "Driving Licenses Services";
            // 
            // btnNewDrivingLicensesMenu
            // 
            this.btnNewDrivingLicensesMenu.BackColor = System.Drawing.Color.White;
            this.btnNewDrivingLicensesMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLocalLicense,
            this.btnInternationalLicense});
            this.btnNewDrivingLicensesMenu.Font = new System.Drawing.Font("Bahnschrift", 9.75F);
            this.btnNewDrivingLicensesMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnNewDrivingLicensesMenu.Image")));
            this.btnNewDrivingLicensesMenu.Name = "btnNewDrivingLicensesMenu";
            this.btnNewDrivingLicensesMenu.Size = new System.Drawing.Size(274, 22);
            this.btnNewDrivingLicensesMenu.Text = "New Driving License";
            // 
            // btnLocalLicense
            // 
            this.btnLocalLicense.BackColor = System.Drawing.Color.White;
            this.btnLocalLicense.Image = ((System.Drawing.Image)(resources.GetObject("btnLocalLicense.Image")));
            this.btnLocalLicense.Name = "btnLocalLicense";
            this.btnLocalLicense.Size = new System.Drawing.Size(195, 22);
            this.btnLocalLicense.Text = "Local License";
            this.btnLocalLicense.Click += new System.EventHandler(this.LocalLicenseToolStripMenuItem_Click);
            // 
            // btnInternationalLicense
            // 
            this.btnInternationalLicense.Image = ((System.Drawing.Image)(resources.GetObject("btnInternationalLicense.Image")));
            this.btnInternationalLicense.Name = "btnInternationalLicense";
            this.btnInternationalLicense.Size = new System.Drawing.Size(195, 22);
            this.btnInternationalLicense.Text = "International License";
            this.btnInternationalLicense.Click += new System.EventHandler(this.InternationalLicenseToolStripMenuItem_Click);
            // 
            // btnRenewDrivingLicense
            // 
            this.btnRenewDrivingLicense.BackColor = System.Drawing.Color.White;
            this.btnRenewDrivingLicense.Font = new System.Drawing.Font("Bahnschrift", 9.75F);
            this.btnRenewDrivingLicense.Image = ((System.Drawing.Image)(resources.GetObject("btnRenewDrivingLicense.Image")));
            this.btnRenewDrivingLicense.Name = "btnRenewDrivingLicense";
            this.btnRenewDrivingLicense.Size = new System.Drawing.Size(274, 22);
            this.btnRenewDrivingLicense.Text = "Renew Driving License";
            this.btnRenewDrivingLicense.Click += new System.EventHandler(this.RenewDrivingLicenseToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.White;
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(271, 6);
            // 
            // btnReplacementFor
            // 
            this.btnReplacementFor.BackColor = System.Drawing.Color.White;
            this.btnReplacementFor.Font = new System.Drawing.Font("Bahnschrift", 9.75F);
            this.btnReplacementFor.Image = ((System.Drawing.Image)(resources.GetObject("btnReplacementFor.Image")));
            this.btnReplacementFor.Name = "btnReplacementFor";
            this.btnReplacementFor.Size = new System.Drawing.Size(274, 22);
            this.btnReplacementFor.Text = "Replacement For Lost or Damaged";
            this.btnReplacementFor.Click += new System.EventHandler(this.ReplacementForToolStripMenuItem_Click);
            // 
            // btnRetakeTest
            // 
            this.btnRetakeTest.BackColor = System.Drawing.Color.White;
            this.btnRetakeTest.Font = new System.Drawing.Font("Bahnschrift", 9.75F);
            this.btnRetakeTest.Image = ((System.Drawing.Image)(resources.GetObject("btnRetakeTest.Image")));
            this.btnRetakeTest.Name = "btnRetakeTest";
            this.btnRetakeTest.Size = new System.Drawing.Size(274, 22);
            this.btnRetakeTest.Text = "Retake Test";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(271, 6);
            // 
            // btnPersonLicenseHistory
            // 
            this.btnPersonLicenseHistory.BackColor = System.Drawing.Color.White;
            this.btnPersonLicenseHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnPersonLicenseHistory.Image")));
            this.btnPersonLicenseHistory.Name = "btnPersonLicenseHistory";
            this.btnPersonLicenseHistory.Size = new System.Drawing.Size(274, 22);
            this.btnPersonLicenseHistory.Text = "Person License History";
            this.btnPersonLicenseHistory.Click += new System.EventHandler(this.BtnPersonLicenseHistory_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.Color.White;
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(255, 6);
            // 
            // btnManageApplicationsMenu
            // 
            this.btnManageApplicationsMenu.BackColor = System.Drawing.Color.White;
            this.btnManageApplicationsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLocalDrivingLicenseApplications,
            this.btnInternationalLicesneApplications});
            this.btnManageApplicationsMenu.Font = new System.Drawing.Font("Bahnschrift", 9.75F);
            this.btnManageApplicationsMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnManageApplicationsMenu.Image")));
            this.btnManageApplicationsMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnManageApplicationsMenu.Name = "btnManageApplicationsMenu";
            this.btnManageApplicationsMenu.Size = new System.Drawing.Size(258, 56);
            this.btnManageApplicationsMenu.Text = "Manage Applications";
            // 
            // btnLocalDrivingLicenseApplications
            // 
            this.btnLocalDrivingLicenseApplications.BackColor = System.Drawing.Color.White;
            this.btnLocalDrivingLicenseApplications.Font = new System.Drawing.Font("Bahnschrift", 9.75F);
            this.btnLocalDrivingLicenseApplications.Image = ((System.Drawing.Image)(resources.GetObject("btnLocalDrivingLicenseApplications.Image")));
            this.btnLocalDrivingLicenseApplications.Name = "btnLocalDrivingLicenseApplications";
            this.btnLocalDrivingLicenseApplications.Size = new System.Drawing.Size(270, 22);
            this.btnLocalDrivingLicenseApplications.Text = "Local Driving License Applications";
            this.btnLocalDrivingLicenseApplications.Click += new System.EventHandler(this.LocalDrivingLicenseApplicationToolStripMenuItem_Click);
            // 
            // btnInternationalLicesneApplications
            // 
            this.btnInternationalLicesneApplications.BackColor = System.Drawing.Color.White;
            this.btnInternationalLicesneApplications.Font = new System.Drawing.Font("Bahnschrift", 9.75F);
            this.btnInternationalLicesneApplications.Image = ((System.Drawing.Image)(resources.GetObject("btnInternationalLicesneApplications.Image")));
            this.btnInternationalLicesneApplications.Name = "btnInternationalLicesneApplications";
            this.btnInternationalLicesneApplications.Size = new System.Drawing.Size(270, 22);
            this.btnInternationalLicesneApplications.Text = "International Licesne Applications";
            this.btnInternationalLicesneApplications.Click += new System.EventHandler(this.InternationalLicesneApplicationsToolStripMenuItem_Click);
            // 
            // btnDetainLicensesMenu
            // 
            this.btnDetainLicensesMenu.BackColor = System.Drawing.Color.White;
            this.btnDetainLicensesMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnManageDetainLicenses,
            this.btnDetainLicesne,
            this.btnReleaseDetainedLicnese});
            this.btnDetainLicensesMenu.Font = new System.Drawing.Font("Bahnschrift", 9.75F);
            this.btnDetainLicensesMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnDetainLicensesMenu.Image")));
            this.btnDetainLicensesMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDetainLicensesMenu.Name = "btnDetainLicensesMenu";
            this.btnDetainLicensesMenu.Size = new System.Drawing.Size(258, 56);
            this.btnDetainLicensesMenu.Text = "Detain Licenses";
            // 
            // btnManageDetainLicenses
            // 
            this.btnManageDetainLicenses.BackColor = System.Drawing.Color.White;
            this.btnManageDetainLicenses.Image = ((System.Drawing.Image)(resources.GetObject("btnManageDetainLicenses.Image")));
            this.btnManageDetainLicenses.Name = "btnManageDetainLicenses";
            this.btnManageDetainLicenses.Size = new System.Drawing.Size(222, 22);
            this.btnManageDetainLicenses.Text = "Manage Detain License";
            this.btnManageDetainLicenses.Click += new System.EventHandler(this.ManageDetainLicensesToolStripMenuItem_Click);
            // 
            // btnDetainLicesne
            // 
            this.btnDetainLicesne.BackColor = System.Drawing.Color.White;
            this.btnDetainLicesne.Image = ((System.Drawing.Image)(resources.GetObject("btnDetainLicesne.Image")));
            this.btnDetainLicesne.Name = "btnDetainLicesne";
            this.btnDetainLicesne.Size = new System.Drawing.Size(222, 22);
            this.btnDetainLicesne.Text = "Detain Licesne";
            this.btnDetainLicesne.Click += new System.EventHandler(this.ReleaseDetainLicesneToolStripMenuItem_Click);
            // 
            // btnReleaseDetainedLicnese
            // 
            this.btnReleaseDetainedLicnese.BackColor = System.Drawing.Color.White;
            this.btnReleaseDetainedLicnese.Image = ((System.Drawing.Image)(resources.GetObject("btnReleaseDetainedLicnese.Image")));
            this.btnReleaseDetainedLicnese.Name = "btnReleaseDetainedLicnese";
            this.btnReleaseDetainedLicnese.Size = new System.Drawing.Size(222, 22);
            this.btnReleaseDetainedLicnese.Text = "Release Detained Licnese";
            this.btnReleaseDetainedLicnese.Click += new System.EventHandler(this.ReleaseDetainLicneseToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.BackColor = System.Drawing.Color.White;
            this.toolStripSeparator3.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(255, 6);
            // 
            // btnManageApplicationTypes
            // 
            this.btnManageApplicationTypes.BackColor = System.Drawing.Color.White;
            this.btnManageApplicationTypes.Font = new System.Drawing.Font("Bahnschrift", 9.75F);
            this.btnManageApplicationTypes.Image = ((System.Drawing.Image)(resources.GetObject("btnManageApplicationTypes.Image")));
            this.btnManageApplicationTypes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnManageApplicationTypes.Name = "btnManageApplicationTypes";
            this.btnManageApplicationTypes.Size = new System.Drawing.Size(258, 56);
            this.btnManageApplicationTypes.Text = "Manage Application Types";
            this.btnManageApplicationTypes.Click += new System.EventHandler(this.ManageApplicationTypesToolStripMenuItem_Click);
            // 
            // btnManageTestTypes
            // 
            this.btnManageTestTypes.BackColor = System.Drawing.Color.White;
            this.btnManageTestTypes.Font = new System.Drawing.Font("Bahnschrift", 9.75F);
            this.btnManageTestTypes.Image = ((System.Drawing.Image)(resources.GetObject("btnManageTestTypes.Image")));
            this.btnManageTestTypes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnManageTestTypes.Name = "btnManageTestTypes";
            this.btnManageTestTypes.Size = new System.Drawing.Size(258, 56);
            this.btnManageTestTypes.Text = "Manage Test Types";
            this.btnManageTestTypes.Click += new System.EventHandler(this.ManageTestTypesToolStripMenuItem_Click);
            // 
            // btnPeople
            // 
            this.btnPeople.Font = new System.Drawing.Font("League Spartan", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnPeople.ForeColor = System.Drawing.Color.Black;
            this.btnPeople.Image = ((System.Drawing.Image)(resources.GetObject("btnPeople.Image")));
            this.btnPeople.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPeople.Name = "btnPeople";
            this.btnPeople.Size = new System.Drawing.Size(116, 54);
            this.btnPeople.Text = "People";
            this.btnPeople.Click += new System.EventHandler(this.BtnPeople_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Font = new System.Drawing.Font("League Spartan", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnUsers.ForeColor = System.Drawing.Color.Black;
            this.btnUsers.Image = ((System.Drawing.Image)(resources.GetObject("btnUsers.Image")));
            this.btnUsers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(105, 54);
            this.btnUsers.Text = "Users";
            this.btnUsers.Click += new System.EventHandler(this.BtnUsers_Click);
            // 
            // btnDrivers
            // 
            this.btnDrivers.Font = new System.Drawing.Font("League Spartan", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDrivers.ForeColor = System.Drawing.Color.Black;
            this.btnDrivers.Image = ((System.Drawing.Image)(resources.GetObject("btnDrivers.Image")));
            this.btnDrivers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDrivers.Name = "btnDrivers";
            this.btnDrivers.Size = new System.Drawing.Size(117, 54);
            this.btnDrivers.Text = "Drivers";
            this.btnDrivers.Click += new System.EventHandler(this.BtnDrivers_Click);
            // 
            // pnMain
            // 
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 71);
            this.pnMain.Name = "pnMain";
            this.pnMain.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.pnMain.Size = new System.Drawing.Size(800, 321);
            this.pnMain.TabIndex = 3;
            // 
            // ucLoginAccountHeader
            // 
            this.ucLoginAccountHeader.BackColor = System.Drawing.Color.White;
            this.ucLoginAccountHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucLoginAccountHeader.BackgroundImage")));
            this.ucLoginAccountHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucLoginAccountHeader.Location = new System.Drawing.Point(0, 0);
            this.ucLoginAccountHeader.Name = "ucLoginAccountHeader";
            this.ucLoginAccountHeader.Size = new System.Drawing.Size(800, 71);
            this.ucLoginAccountHeader.TabIndex = 1;
            this.ucLoginAccountHeader.OnLogout += new System.Action(this.UcLoginAccountHeader_OnLogout);
            // 
            // FRMMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.ucLoginAccountHeader);
            this.Controls.Add(this.msMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msMain;
            this.Name = "FRMMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.StateCommon.Border.Color1 = System.Drawing.Color.Red;
            this.StateCommon.Border.Color2 = System.Drawing.Color.Red;
            this.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Header.Back.Color1 = System.Drawing.Color.Red;
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.Firebrick;
            this.StateCommon.Header.Border.Color1 = System.Drawing.Color.White;
            this.StateCommon.Header.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Header.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Font = new System.Drawing.Font("Liberation Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem btnPeople;
        private System.Windows.Forms.ToolStripMenuItem btnUsers;
        private System.Windows.Forms.ToolStripMenuItem btnDrivers;
        private System.Windows.Forms.ToolStripMenuItem btnApplicationsMenu;
        private UCLoginAccountHeader ucLoginAccountHeader;
        private System.Windows.Forms.ToolStripMenuItem btnDrivingLicensesServicesMenu;
        private System.Windows.Forms.ToolStripMenuItem btnNewDrivingLicensesMenu;
        private System.Windows.Forms.ToolStripMenuItem btnRenewDrivingLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnReplacementFor;
        private System.Windows.Forms.ToolStripMenuItem btnRetakeTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnDetainLicensesMenu;
        private System.Windows.Forms.ToolStripMenuItem btnManageApplicationsMenu;
        private System.Windows.Forms.ToolStripMenuItem btnManageApplicationTypes;
        private System.Windows.Forms.ToolStripMenuItem btnManageTestTypes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem btnLocalDrivingLicenseApplications;
        private System.Windows.Forms.ToolStripMenuItem btnInternationalLicesneApplications;
        private System.Windows.Forms.ToolStripMenuItem btnManageDetainLicenses;
        private System.Windows.Forms.ToolStripMenuItem btnDetainLicesne;
        private System.Windows.Forms.ToolStripMenuItem btnReleaseDetainedLicnese;
        private System.Windows.Forms.ToolStripMenuItem btnLocalLicense;
        private System.Windows.Forms.ToolStripMenuItem btnInternationalLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem btnPersonLicenseHistory;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel pnMain;
    }
}