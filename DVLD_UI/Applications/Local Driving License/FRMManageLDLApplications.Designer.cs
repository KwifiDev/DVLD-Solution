namespace DVLD_UI.Froms
{
    partial class FRMManageLDLApplications
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMManageLDLApplications));
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnAddApplication = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnShowApplicationDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDeleteApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancelApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.btnScheduleTest = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.btnWrittenTheoryTest = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPracticalStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.btnIssueDrvingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvApplication = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.LocalDrivingLicenseApplicationID = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.ClassName = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.NationalNo = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.FullName = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.ApplicationDate = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.PassedTestCount = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Status = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.ucFilter1 = new DVLD_UI.UCFilter();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.btnAddApplication);
            this.kryptonPanel2.Controls.Add(this.pictureBox1);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(884, 79);
            this.kryptonPanel2.StateCommon.Color1 = System.Drawing.Color.White;
            this.kryptonPanel2.StateCommon.Color2 = System.Drawing.Color.White;
            this.kryptonPanel2.TabIndex = 9;
            // 
            // btnAddApplication
            // 
            this.btnAddApplication.Location = new System.Drawing.Point(803, 5);
            this.btnAddApplication.Name = "btnAddApplication";
            this.btnAddApplication.Size = new System.Drawing.Size(69, 67);
            this.btnAddApplication.StateCommon.Back.Color1 = System.Drawing.Color.AliceBlue;
            this.btnAddApplication.StateCommon.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnAddApplication.TabIndex = 2;
            this.btnAddApplication.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnAddApplication.Values.Image")));
            this.btnAddApplication.Values.Text = "";
            this.btnAddApplication.Click += new System.EventHandler(this.BtnAddApplication_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(126, 17);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(454, 42);
            this.kryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Firebrick;
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Uighur", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.StateCommon.ShortText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Manage Local Driving License Applications";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(248, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(248, 6);
            // 
            // contextMenu
            // 
            this.contextMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowApplicationDetails,
            this.toolStripSeparator1,
            this.btnEditApplication,
            this.btnDeleteApplication,
            this.btnCancelApplication,
            this.toolStripSeparator2,
            this.btnScheduleTest,
            this.btnIssueDrvingLicense,
            this.btnShowLicense,
            this.btnShowPersonLicenseHistory,
            this.btnRefresh});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(252, 304);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenu_Opening);
            // 
            // btnShowApplicationDetails
            // 
            this.btnShowApplicationDetails.Image = ((System.Drawing.Image)(resources.GetObject("btnShowApplicationDetails.Image")));
            this.btnShowApplicationDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowApplicationDetails.Name = "btnShowApplicationDetails";
            this.btnShowApplicationDetails.Size = new System.Drawing.Size(251, 32);
            this.btnShowApplicationDetails.Text = "Show Details";
            this.btnShowApplicationDetails.Click += new System.EventHandler(this.BtnShowApplicationDetails_Click);
            // 
            // btnEditApplication
            // 
            this.btnEditApplication.Image = ((System.Drawing.Image)(resources.GetObject("btnEditApplication.Image")));
            this.btnEditApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditApplication.Name = "btnEditApplication";
            this.btnEditApplication.Size = new System.Drawing.Size(251, 32);
            this.btnEditApplication.Text = "Edit";
            this.btnEditApplication.Click += new System.EventHandler(this.BtnEditApplication_Click);
            // 
            // btnDeleteApplication
            // 
            this.btnDeleteApplication.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteApplication.Image")));
            this.btnDeleteApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDeleteApplication.Name = "btnDeleteApplication";
            this.btnDeleteApplication.Size = new System.Drawing.Size(251, 32);
            this.btnDeleteApplication.Text = "Delete";
            this.btnDeleteApplication.Click += new System.EventHandler(this.BtnDeleteApplication_Click);
            // 
            // btnCancelApplication
            // 
            this.btnCancelApplication.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelApplication.Image")));
            this.btnCancelApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCancelApplication.Name = "btnCancelApplication";
            this.btnCancelApplication.Size = new System.Drawing.Size(251, 32);
            this.btnCancelApplication.Text = "Cancel Application";
            this.btnCancelApplication.Click += new System.EventHandler(this.BtnCancelApplication_Click);
            // 
            // btnScheduleTest
            // 
            this.btnScheduleTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnVisionTest,
            this.btnWrittenTheoryTest,
            this.btnPracticalStreetTest});
            this.btnScheduleTest.Image = ((System.Drawing.Image)(resources.GetObject("btnScheduleTest.Image")));
            this.btnScheduleTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnScheduleTest.Name = "btnScheduleTest";
            this.btnScheduleTest.Size = new System.Drawing.Size(251, 32);
            this.btnScheduleTest.Text = "Schedule Test";
            // 
            // btnVisionTest
            // 
            this.btnVisionTest.Image = ((System.Drawing.Image)(resources.GetObject("btnVisionTest.Image")));
            this.btnVisionTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnVisionTest.Name = "btnVisionTest";
            this.btnVisionTest.Size = new System.Drawing.Size(192, 32);
            this.btnVisionTest.Tag = "1";
            this.btnVisionTest.Text = "Vision Test";
            this.btnVisionTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // btnWrittenTheoryTest
            // 
            this.btnWrittenTheoryTest.Image = ((System.Drawing.Image)(resources.GetObject("btnWrittenTheoryTest.Image")));
            this.btnWrittenTheoryTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnWrittenTheoryTest.Name = "btnWrittenTheoryTest";
            this.btnWrittenTheoryTest.Size = new System.Drawing.Size(192, 32);
            this.btnWrittenTheoryTest.Tag = "2";
            this.btnWrittenTheoryTest.Text = "Written (Theory) Test";
            this.btnWrittenTheoryTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // btnPracticalStreetTest
            // 
            this.btnPracticalStreetTest.Image = ((System.Drawing.Image)(resources.GetObject("btnPracticalStreetTest.Image")));
            this.btnPracticalStreetTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPracticalStreetTest.Name = "btnPracticalStreetTest";
            this.btnPracticalStreetTest.Size = new System.Drawing.Size(192, 32);
            this.btnPracticalStreetTest.Tag = "3";
            this.btnPracticalStreetTest.Text = "Practical (Street) Test";
            this.btnPracticalStreetTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // btnIssueDrvingLicense
            // 
            this.btnIssueDrvingLicense.Image = ((System.Drawing.Image)(resources.GetObject("btnIssueDrvingLicense.Image")));
            this.btnIssueDrvingLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnIssueDrvingLicense.Name = "btnIssueDrvingLicense";
            this.btnIssueDrvingLicense.Size = new System.Drawing.Size(251, 32);
            this.btnIssueDrvingLicense.Text = "Issue Drving License [First Time]";
            this.btnIssueDrvingLicense.Click += new System.EventHandler(this.BtnIssueDrvingLicense_Click);
            // 
            // btnShowLicense
            // 
            this.btnShowLicense.Image = ((System.Drawing.Image)(resources.GetObject("btnShowLicense.Image")));
            this.btnShowLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowLicense.Name = "btnShowLicense";
            this.btnShowLicense.Size = new System.Drawing.Size(251, 32);
            this.btnShowLicense.Text = "Show License";
            this.btnShowLicense.Click += new System.EventHandler(this.BtnShowLicense_Click);
            // 
            // btnShowPersonLicenseHistory
            // 
            this.btnShowPersonLicenseHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnShowPersonLicenseHistory.Image")));
            this.btnShowPersonLicenseHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowPersonLicenseHistory.Name = "btnShowPersonLicenseHistory";
            this.btnShowPersonLicenseHistory.Size = new System.Drawing.Size(251, 32);
            this.btnShowPersonLicenseHistory.Text = "Show Person License History";
            this.btnShowPersonLicenseHistory.Click += new System.EventHandler(this.BtnShowPersonLicenseHistory_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(251, 32);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // dgvApplication
            // 
            this.dgvApplication.AllowUserToAddRows = false;
            this.dgvApplication.AllowUserToDeleteRows = false;
            this.dgvApplication.AllowUserToResizeColumns = false;
            this.dgvApplication.AllowUserToResizeRows = false;
            this.dgvApplication.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApplication.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvApplication.ColumnHeadersHeight = 30;
            this.dgvApplication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvApplication.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LocalDrivingLicenseApplicationID,
            this.ClassName,
            this.NationalNo,
            this.FullName,
            this.ApplicationDate,
            this.PassedTestCount,
            this.Status});
            this.dgvApplication.ContextMenuStrip = this.contextMenu;
            this.dgvApplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvApplication.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.dgvApplication.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.dgvApplication.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvApplication.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvApplication.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvApplication.Location = new System.Drawing.Point(0, 0);
            this.dgvApplication.MultiSelect = false;
            this.dgvApplication.Name = "dgvApplication";
            this.dgvApplication.ReadOnly = true;
            this.dgvApplication.RowHeadersVisible = false;
            this.dgvApplication.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvApplication.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplication.ShowCellErrors = false;
            this.dgvApplication.ShowCellToolTips = false;
            this.dgvApplication.ShowEditingIcon = false;
            this.dgvApplication.ShowRowErrors = false;
            this.dgvApplication.Size = new System.Drawing.Size(884, 289);
            this.dgvApplication.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvApplication.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgvApplication.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.dgvApplication.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.Transparent;
            this.dgvApplication.StateCommon.DataCell.Back.Color2 = System.Drawing.Color.Transparent;
            this.dgvApplication.StateCommon.DataCell.Border.Color1 = System.Drawing.Color.White;
            this.dgvApplication.StateCommon.DataCell.Border.Color2 = System.Drawing.Color.White;
            this.dgvApplication.StateCommon.DataCell.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgvApplication.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.IndianRed;
            this.dgvApplication.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.Firebrick;
            this.dgvApplication.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgvApplication.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.White;
            this.dgvApplication.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Bahnschrift SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvApplication.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvApplication.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgvApplication.TabIndex = 3;
            this.dgvApplication.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgvApplication_MouseDown);
            // 
            // LocalDrivingLicenseApplicationID
            // 
            this.LocalDrivingLicenseApplicationID.DataPropertyName = "LocalDrivingLicenseApplicationID";
            this.LocalDrivingLicenseApplicationID.FillWeight = 40F;
            this.LocalDrivingLicenseApplicationID.HeaderText = "LDLAppID";
            this.LocalDrivingLicenseApplicationID.Name = "LocalDrivingLicenseApplicationID";
            this.LocalDrivingLicenseApplicationID.ReadOnly = true;
            this.LocalDrivingLicenseApplicationID.Width = 63;
            // 
            // ClassName
            // 
            this.ClassName.DataPropertyName = "ClassName";
            this.ClassName.FillWeight = 130F;
            this.ClassName.HeaderText = "ClassName";
            this.ClassName.Name = "ClassName";
            this.ClassName.ReadOnly = true;
            this.ClassName.Width = 205;
            // 
            // NationalNo
            // 
            this.NationalNo.DataPropertyName = "NationalNo";
            this.NationalNo.FillWeight = 60F;
            this.NationalNo.HeaderText = "NationalNo";
            this.NationalNo.Name = "NationalNo";
            this.NationalNo.ReadOnly = true;
            this.NationalNo.Width = 95;
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "FullName";
            this.FullName.FillWeight = 150F;
            this.FullName.HeaderText = "FullName";
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            this.FullName.Width = 236;
            // 
            // ApplicationDate
            // 
            this.ApplicationDate.DataPropertyName = "ApplicationDate";
            this.ApplicationDate.FillWeight = 80F;
            this.ApplicationDate.HeaderText = "ApplicationDate";
            this.ApplicationDate.Name = "ApplicationDate";
            this.ApplicationDate.ReadOnly = true;
            this.ApplicationDate.Width = 126;
            // 
            // PassedTestCount
            // 
            this.PassedTestCount.DataPropertyName = "PassedTestCount";
            this.PassedTestCount.FillWeight = 50F;
            this.PassedTestCount.HeaderText = "PassedTest";
            this.PassedTestCount.Name = "PassedTestCount";
            this.PassedTestCount.ReadOnly = true;
            this.PassedTestCount.Width = 79;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.FillWeight = 50F;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 79;
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.ucFilter1);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel3.Location = new System.Drawing.Point(0, 289);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(884, 43);
            this.kryptonPanel3.StateCommon.Color1 = System.Drawing.Color.White;
            this.kryptonPanel3.StateCommon.Color2 = System.Drawing.Color.White;
            this.kryptonPanel3.TabIndex = 4;
            // 
            // ucFilter1
            // 
            this.ucFilter1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucFilter1.Location = new System.Drawing.Point(8, 5);
            this.ucFilter1.Name = "ucFilter1";
            this.ucFilter1.Size = new System.Drawing.Size(869, 33);
            this.ucFilter1.TabIndex = 0;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.dgvApplication);
            this.kryptonPanel1.Controls.Add(this.kryptonPanel3);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 79);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(884, 332);
            this.kryptonPanel1.StateCommon.Color1 = System.Drawing.Color.White;
            this.kryptonPanel1.StateCommon.Color2 = System.Drawing.Color.White;
            this.kryptonPanel1.TabIndex = 8;
            // 
            // FRMManageLDLApplications
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 411);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.kryptonPanel2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 450);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 450);
            this.Name = "FRMManageLDLApplications";
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
            this.StateCommon.Header.Border.Color1 = System.Drawing.Color.White;
            this.StateCommon.Header.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Header.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Font = new System.Drawing.Font("Liberation Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Text = "Manage Local Driving License Applications";
            this.Load += new System.EventHandler(this.FRMManageApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddApplication;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.ToolStripMenuItem btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnDeleteApplication;
        private System.Windows.Forms.ToolStripMenuItem btnEditApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnShowApplicationDetails;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvApplication;
        private UCFilter ucFilter1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn LocalDrivingLicenseApplicationID;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn ClassName;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn NationalNo;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn FullName;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn ApplicationDate;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn PassedTestCount;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Status;
        private System.Windows.Forms.ToolStripMenuItem btnCancelApplication;
        private System.Windows.Forms.ToolStripMenuItem btnScheduleTest;
        private System.Windows.Forms.ToolStripMenuItem btnIssueDrvingLicense;
        private System.Windows.Forms.ToolStripMenuItem btnShowLicense;
        private System.Windows.Forms.ToolStripMenuItem btnShowPersonLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem btnVisionTest;
        private System.Windows.Forms.ToolStripMenuItem btnWrittenTheoryTest;
        private System.Windows.Forms.ToolStripMenuItem btnPracticalStreetTest;
    }
}