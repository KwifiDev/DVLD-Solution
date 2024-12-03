namespace DVLD_UI.Users.Controls
{
    partial class UCAddEditUserPermissions
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Add New Local License Application");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Issue New International License");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("New Driving License", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Renew Local License");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Replacement License");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Retake Test Application");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Show Person License History");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Driving Licenses Services Menu", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Edit LDL Application");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Delete LDL Application");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Cancel LDL Application");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Scheduling Tests");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Issue Local License");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Manage Local Driving License Applications", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Manage International License Applications");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Manage Applications Menu", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Manage Detain Licenses");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Detain License");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Release Detained License");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Detain Licenses Menu", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18,
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Manage Application Types");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Manage Test Types");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Applications Menu", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode16,
            treeNode20,
            treeNode21,
            treeNode22});
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Add New Person");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Edit Person");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Delete Person");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("People Menu", new System.Windows.Forms.TreeNode[] {
            treeNode24,
            treeNode25,
            treeNode26});
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Add New User");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Edit User");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Delete User");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Change Passwords");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Users Menu", new System.Windows.Forms.TreeNode[] {
            treeNode28,
            treeNode29,
            treeNode30,
            treeNode31});
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Manage Drivers");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAddEditUserPermissions));
            this.tvPermissions = new AdvancedControls.AdvancedTreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gbUserPermissions = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gbUserPermissions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbUserPermissions.Panel)).BeginInit();
            this.gbUserPermissions.Panel.SuspendLayout();
            this.gbUserPermissions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvPermissions
            // 
            this.tvPermissions.CheckBoxes = true;
            this.tvPermissions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPermissions.ImageIndex = 0;
            this.tvPermissions.ImageList = this.imageList1;
            this.tvPermissions.Location = new System.Drawing.Point(0, 0);
            this.tvPermissions.Name = "tvPermissions";
            treeNode1.Name = "cNodAddNewLocalLicenseApplication";
            treeNode1.Text = "Add New Local License Application";
            treeNode2.Name = "cNodIssueInternationalLicense";
            treeNode2.Text = "Issue New International License";
            treeNode3.Name = "cNodNewDrivingLicense";
            treeNode3.Text = "New Driving License";
            treeNode4.Name = "cNodRenewLocalLicense";
            treeNode4.Text = "Renew Local License";
            treeNode5.Name = "cNodReplacementLicense";
            treeNode5.Text = "Replacement License";
            treeNode6.Name = "cNodRetakeTest";
            treeNode6.Text = "Retake Test Application";
            treeNode7.Name = "cNodPersonLicenseHistory";
            treeNode7.Text = "Show Person License History";
            treeNode8.Name = "cNodDrivingLicensesServicesMenu";
            treeNode8.Text = "Driving Licenses Services Menu";
            treeNode9.Name = "cNodEditLDLApplication";
            treeNode9.Text = "Edit LDL Application";
            treeNode10.Name = "cNodDeleteLDLApplication";
            treeNode10.Text = "Delete LDL Application";
            treeNode11.Name = "cNodCancelLDLApplication";
            treeNode11.Text = "Cancel LDL Application";
            treeNode12.Name = "cNodSchedulingTests";
            treeNode12.Text = "Scheduling Tests";
            treeNode13.Name = "cNodIssueLocalLicense";
            treeNode13.Text = "Issue Local License";
            treeNode14.Name = "cNodLDLApplications";
            treeNode14.Text = "Manage Local Driving License Applications";
            treeNode15.Name = "cNodInternationalLicense";
            treeNode15.Text = "Manage International License Applications";
            treeNode16.Name = "cNodManageApplicationsMenu";
            treeNode16.Text = "Manage Applications Menu";
            treeNode17.Name = "cNodManageDetainLicenses";
            treeNode17.Text = "Manage Detain Licenses";
            treeNode18.Name = "cNodDetainLicense";
            treeNode18.Text = "Detain License";
            treeNode19.Name = "cNodReleaseDetainedLicense";
            treeNode19.Text = "Release Detained License";
            treeNode20.Name = "cNodDetainLicensesMenu";
            treeNode20.Text = "Detain Licenses Menu";
            treeNode21.Name = "cNodManageApplicationTypes";
            treeNode21.Text = "Manage Application Types";
            treeNode22.Name = "cNodManageTestTypes";
            treeNode22.Text = "Manage Test Types";
            treeNode23.Name = "rNodApplicationsMenu";
            treeNode23.Text = "Applications Menu";
            treeNode24.Name = "cNodAddPerson";
            treeNode24.Text = "Add New Person";
            treeNode25.Name = "cNodEditPerson";
            treeNode25.Text = "Edit Person";
            treeNode26.Name = "cNodDeletePerson";
            treeNode26.Text = "Delete Person";
            treeNode27.Name = "rNodPeopleMenu";
            treeNode27.Text = "People Menu";
            treeNode28.Name = "cNodAddUser";
            treeNode28.Text = "Add New User";
            treeNode29.Name = "cNodEditUser";
            treeNode29.Text = "Edit User";
            treeNode30.Name = "cNodDeleteUser";
            treeNode30.Text = "Delete User";
            treeNode31.Name = "cNodChangePasswords";
            treeNode31.Text = "Change Passwords";
            treeNode32.Name = "rNodUsersMenu";
            treeNode32.Text = "Users Menu";
            treeNode33.Name = "rNodDrivers";
            treeNode33.Text = "Manage Drivers";
            this.tvPermissions.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode23,
            treeNode27,
            treeNode32,
            treeNode33});
            this.tvPermissions.SelectedImageIndex = 0;
            this.tvPermissions.Size = new System.Drawing.Size(303, 259);
            this.tvPermissions.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Key8.png");
            // 
            // gbUserPermissions
            // 
            this.gbUserPermissions.CaptionOverlap = 0D;
            this.gbUserPermissions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbUserPermissions.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlRibbon;
            this.gbUserPermissions.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ButtonLowProfile;
            this.gbUserPermissions.Location = new System.Drawing.Point(0, 0);
            this.gbUserPermissions.Name = "gbUserPermissions";
            // 
            // gbUserPermissions.Panel
            // 
            this.gbUserPermissions.Panel.Controls.Add(this.tvPermissions);
            this.gbUserPermissions.Size = new System.Drawing.Size(307, 280);
            this.gbUserPermissions.StateCommon.Back.Color1 = System.Drawing.Color.Firebrick;
            this.gbUserPermissions.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.gbUserPermissions.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.gbUserPermissions.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbUserPermissions.TabIndex = 1;
            this.gbUserPermissions.Values.Heading = "User Permissions";
            // 
            // UCAddEditUserPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbUserPermissions);
            this.Name = "UCAddEditUserPermissions";
            this.Size = new System.Drawing.Size(307, 280);
            ((System.ComponentModel.ISupportInitialize)(this.gbUserPermissions.Panel)).EndInit();
            this.gbUserPermissions.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbUserPermissions)).EndInit();
            this.gbUserPermissions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AdvancedControls.AdvancedTreeView tvPermissions;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox gbUserPermissions;
        private System.Windows.Forms.ImageList imageList1;
    }
}
