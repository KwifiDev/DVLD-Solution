namespace DVLD_UI
{
    partial class FRMManageDetainedLicenses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMManageDetainedLicenses));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnDetainLicense = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dgvDetainedLicenses = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.DetainID = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.LicenseID = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.DetainDate = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.IsReleased = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn();
            this.FineFees = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.ReleaseDate = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.NationalNo = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.FullName = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.ReleaseApplicationID = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnShowPersonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowLicenseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReleaseDetainedLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.ucFilter1 = new DVLD_UI.UCFilter();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnReleaseLicense = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenses)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(215, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(227, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(285, 42);
            this.kryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Firebrick;
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Uighur", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.StateCommon.ShortText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Manage Detained Licenses";
            // 
            // btnDetainLicense
            // 
            this.btnDetainLicense.Location = new System.Drawing.Point(735, 3);
            this.btnDetainLicense.Name = "btnDetainLicense";
            this.btnDetainLicense.Size = new System.Drawing.Size(69, 66);
            this.btnDetainLicense.StateCommon.Back.Color1 = System.Drawing.Color.AliceBlue;
            this.btnDetainLicense.StateCommon.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnDetainLicense.TabIndex = 2;
            this.btnDetainLicense.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnDetainLicense.Values.Image")));
            this.btnDetainLicense.Values.Text = "";
            this.btnDetainLicense.Click += new System.EventHandler(this.BtnDetainLicense_Click);
            // 
            // dgvDetainedLicenses
            // 
            this.dgvDetainedLicenses.AllowUserToAddRows = false;
            this.dgvDetainedLicenses.AllowUserToDeleteRows = false;
            this.dgvDetainedLicenses.AllowUserToResizeColumns = false;
            this.dgvDetainedLicenses.AllowUserToResizeRows = false;
            this.dgvDetainedLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetainedLicenses.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvDetainedLicenses.ColumnHeadersHeight = 30;
            this.dgvDetainedLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetainedLicenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DetainID,
            this.LicenseID,
            this.DetainDate,
            this.IsReleased,
            this.FineFees,
            this.ReleaseDate,
            this.NationalNo,
            this.FullName,
            this.ReleaseApplicationID});
            this.dgvDetainedLicenses.ContextMenuStrip = this.contextMenu;
            this.dgvDetainedLicenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetainedLicenses.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.dgvDetainedLicenses.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.dgvDetainedLicenses.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvDetainedLicenses.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvDetainedLicenses.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvDetainedLicenses.Location = new System.Drawing.Point(0, 0);
            this.dgvDetainedLicenses.MultiSelect = false;
            this.dgvDetainedLicenses.Name = "dgvDetainedLicenses";
            this.dgvDetainedLicenses.ReadOnly = true;
            this.dgvDetainedLicenses.RowHeadersVisible = false;
            this.dgvDetainedLicenses.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDetainedLicenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetainedLicenses.ShowCellErrors = false;
            this.dgvDetainedLicenses.ShowCellToolTips = false;
            this.dgvDetainedLicenses.ShowEditingIcon = false;
            this.dgvDetainedLicenses.ShowRowErrors = false;
            this.dgvDetainedLicenses.Size = new System.Drawing.Size(884, 246);
            this.dgvDetainedLicenses.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvDetainedLicenses.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgvDetainedLicenses.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.dgvDetainedLicenses.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.Transparent;
            this.dgvDetainedLicenses.StateCommon.DataCell.Back.Color2 = System.Drawing.Color.Transparent;
            this.dgvDetainedLicenses.StateCommon.DataCell.Border.Color1 = System.Drawing.Color.White;
            this.dgvDetainedLicenses.StateCommon.DataCell.Border.Color2 = System.Drawing.Color.White;
            this.dgvDetainedLicenses.StateCommon.DataCell.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgvDetainedLicenses.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.IndianRed;
            this.dgvDetainedLicenses.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.Firebrick;
            this.dgvDetainedLicenses.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgvDetainedLicenses.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.White;
            this.dgvDetainedLicenses.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Bahnschrift SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetainedLicenses.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvDetainedLicenses.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgvDetainedLicenses.TabIndex = 3;
            this.dgvDetainedLicenses.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgvDetainedLicenses_MouseDown);
            // 
            // DetainID
            // 
            this.DetainID.DataPropertyName = "DetainID";
            this.DetainID.FillWeight = 25F;
            this.DetainID.HeaderText = "D-ID";
            this.DetainID.Name = "DetainID";
            this.DetainID.ReadOnly = true;
            this.DetainID.Width = 44;
            // 
            // LicenseID
            // 
            this.LicenseID.DataPropertyName = "LicenseID";
            this.LicenseID.FillWeight = 25F;
            this.LicenseID.HeaderText = "L-ID";
            this.LicenseID.Name = "LicenseID";
            this.LicenseID.ReadOnly = true;
            this.LicenseID.Width = 43;
            // 
            // DetainDate
            // 
            this.DetainDate.DataPropertyName = "DetainDate";
            this.DetainDate.FillWeight = 80F;
            this.DetainDate.HeaderText = "DetainDate";
            this.DetainDate.Name = "DetainDate";
            this.DetainDate.ReadOnly = true;
            this.DetainDate.Width = 139;
            // 
            // IsReleased
            // 
            this.IsReleased.DataPropertyName = "IsReleased";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = false;
            this.IsReleased.DefaultCellStyle = dataGridViewCellStyle1;
            this.IsReleased.FalseValue = null;
            this.IsReleased.FillWeight = 50F;
            this.IsReleased.HeaderText = "Released";
            this.IsReleased.IndeterminateValue = null;
            this.IsReleased.Name = "IsReleased";
            this.IsReleased.ReadOnly = true;
            this.IsReleased.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsReleased.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsReleased.TrueValue = null;
            // 
            // FineFees
            // 
            this.FineFees.DataPropertyName = "FineFees";
            this.FineFees.FillWeight = 40F;
            this.FineFees.HeaderText = "Fine";
            this.FineFees.Name = "FineFees";
            this.FineFees.ReadOnly = true;
            this.FineFees.Width = 70;
            // 
            // ReleaseDate
            // 
            this.ReleaseDate.DataPropertyName = "ReleaseDate";
            this.ReleaseDate.FillWeight = 80F;
            this.ReleaseDate.HeaderText = "ReleaseDate";
            this.ReleaseDate.Name = "ReleaseDate";
            this.ReleaseDate.ReadOnly = true;
            this.ReleaseDate.Width = 140;
            // 
            // NationalNo
            // 
            this.NationalNo.DataPropertyName = "NationalNo";
            this.NationalNo.FillWeight = 60F;
            this.NationalNo.HeaderText = "NationalNo";
            this.NationalNo.Name = "NationalNo";
            this.NationalNo.ReadOnly = true;
            this.NationalNo.Width = 105;
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "FullName";
            this.FullName.FillWeight = 120F;
            this.FullName.HeaderText = "FullName";
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            this.FullName.Width = 210;
            // 
            // ReleaseApplicationID
            // 
            this.ReleaseApplicationID.DataPropertyName = "ReleaseApplicationID";
            this.ReleaseApplicationID.FillWeight = 25F;
            this.ReleaseApplicationID.HeaderText = "RA-ID";
            this.ReleaseApplicationID.Name = "ReleaseApplicationID";
            this.ReleaseApplicationID.ReadOnly = true;
            this.ReleaseApplicationID.Width = 44;
            // 
            // contextMenu
            // 
            this.contextMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowPersonDetails,
            this.btnShowLicenseDetails,
            this.btnShowPersonLicenseHistory,
            this.btnReleaseDetainedLicense,
            this.toolStripSeparator2,
            this.btnRefresh});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(235, 192);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenu_Opening);
            // 
            // btnShowPersonDetails
            // 
            this.btnShowPersonDetails.Image = ((System.Drawing.Image)(resources.GetObject("btnShowPersonDetails.Image")));
            this.btnShowPersonDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowPersonDetails.Name = "btnShowPersonDetails";
            this.btnShowPersonDetails.Size = new System.Drawing.Size(234, 32);
            this.btnShowPersonDetails.Text = "Show Person Details";
            this.btnShowPersonDetails.Click += new System.EventHandler(this.BtnShowPersonDetails_Click);
            // 
            // btnShowLicenseDetails
            // 
            this.btnShowLicenseDetails.Image = ((System.Drawing.Image)(resources.GetObject("btnShowLicenseDetails.Image")));
            this.btnShowLicenseDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowLicenseDetails.Name = "btnShowLicenseDetails";
            this.btnShowLicenseDetails.Size = new System.Drawing.Size(234, 32);
            this.btnShowLicenseDetails.Text = "Show License Details";
            this.btnShowLicenseDetails.Click += new System.EventHandler(this.BtnShowLicenseDetails_Click);
            // 
            // btnShowPersonLicenseHistory
            // 
            this.btnShowPersonLicenseHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnShowPersonLicenseHistory.Image")));
            this.btnShowPersonLicenseHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowPersonLicenseHistory.Name = "btnShowPersonLicenseHistory";
            this.btnShowPersonLicenseHistory.Size = new System.Drawing.Size(234, 32);
            this.btnShowPersonLicenseHistory.Text = "Show Person License History";
            this.btnShowPersonLicenseHistory.Click += new System.EventHandler(this.BtnShowPersonLicenseHistory_Click);
            // 
            // btnReleaseDetainedLicense
            // 
            this.btnReleaseDetainedLicense.Image = ((System.Drawing.Image)(resources.GetObject("btnReleaseDetainedLicense.Image")));
            this.btnReleaseDetainedLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReleaseDetainedLicense.Name = "btnReleaseDetainedLicense";
            this.btnReleaseDetainedLicense.Size = new System.Drawing.Size(234, 32);
            this.btnReleaseDetainedLicense.Text = "Release Detained License";
            this.btnReleaseDetainedLicense.Click += new System.EventHandler(this.BtnReleaseDetainedLicense_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(231, 6);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(234, 32);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.dgvDetainedLicenses);
            this.kryptonPanel1.Controls.Add(this.kryptonPanel3);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 72);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(884, 289);
            this.kryptonPanel1.StateCommon.Color1 = System.Drawing.Color.White;
            this.kryptonPanel1.StateCommon.Color2 = System.Drawing.Color.White;
            this.kryptonPanel1.TabIndex = 4;
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.ucFilter1);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel3.Location = new System.Drawing.Point(0, 246);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(884, 43);
            this.kryptonPanel3.StateCommon.Color1 = System.Drawing.Color.White;
            this.kryptonPanel3.StateCommon.Color2 = System.Drawing.Color.White;
            this.kryptonPanel3.TabIndex = 4;
            // 
            // ucFilter1
            // 
            this.ucFilter1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucFilter1.Location = new System.Drawing.Point(5, 5);
            this.ucFilter1.Name = "ucFilter1";
            this.ucFilter1.Size = new System.Drawing.Size(876, 33);
            this.ucFilter1.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.btnReleaseLicense);
            this.kryptonPanel2.Controls.Add(this.btnDetainLicense);
            this.kryptonPanel2.Controls.Add(this.pictureBox1);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(884, 72);
            this.kryptonPanel2.StateCommon.Color1 = System.Drawing.Color.White;
            this.kryptonPanel2.StateCommon.Color2 = System.Drawing.Color.White;
            this.kryptonPanel2.TabIndex = 5;
            // 
            // btnReleaseLicense
            // 
            this.btnReleaseLicense.Location = new System.Drawing.Point(810, 3);
            this.btnReleaseLicense.Name = "btnReleaseLicense";
            this.btnReleaseLicense.Size = new System.Drawing.Size(69, 66);
            this.btnReleaseLicense.StateCommon.Back.Color1 = System.Drawing.Color.AliceBlue;
            this.btnReleaseLicense.StateCommon.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnReleaseLicense.TabIndex = 3;
            this.btnReleaseLicense.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnReleaseLicense.Values.Image")));
            this.btnReleaseLicense.Values.Text = "";
            this.btnReleaseLicense.Click += new System.EventHandler(this.BtnReleaseLicense_Click);
            // 
            // FRMManageDetainedLicenses
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 361);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.kryptonPanel2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 400);
            this.Name = "FRMManageDetainedLicenses";
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
            this.Text = "Manage Detained Licenses";
            this.Load += new System.EventHandler(this.FRMManageDetainedLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenses)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDetainLicense;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvDetainedLicenses;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem btnShowPersonDetails;
        private System.Windows.Forms.ToolStripMenuItem btnReleaseDetainedLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnRefresh;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private UCFilter ucFilter1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnReleaseLicense;
        private System.Windows.Forms.ToolStripMenuItem btnShowLicenseDetails;
        private System.Windows.Forms.ToolStripMenuItem btnShowPersonLicenseHistory;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn DetainID;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn LicenseID;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn DetainDate;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn IsReleased;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn FineFees;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn ReleaseDate;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn NationalNo;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn FullName;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn ReleaseApplicationID;
    }
}