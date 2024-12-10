namespace DVLD_UI.UserControls
{
    partial class UCDriverLicenses
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCDriverLicenses));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbDriverLicenses = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.tabControl = new ComponentFactory.Krypton.Docking.KryptonDockableNavigator();
            this.tabLocalLicense = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.dgvLocalLicenses = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.LicenseID = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.ApplicationID = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.ClassName = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.IssueDate = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.ExpirationDate = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.IsActive = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnShowLicenseInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tabInternationalLicense = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.dgvInternationalLicenses = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.InternationalLicenseID = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Int_ApplicationID = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.IssuedUsingLocalLicenseID = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Int_IssueDate = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Int_ExpirationDate = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Int_IsActive = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gbDriverLicenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbDriverLicenses.Panel)).BeginInit();
            this.gbDriverLicenses.Panel.SuspendLayout();
            this.gbDriverLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabLocalLicense)).BeginInit();
            this.tabLocalLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabInternationalLicense)).BeginInit();
            this.tabInternationalLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDriverLicenses
            // 
            this.gbDriverLicenses.CaptionOverlap = 0.1D;
            this.gbDriverLicenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDriverLicenses.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonFormClose;
            this.gbDriverLicenses.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ButtonStandalone;
            this.gbDriverLicenses.Location = new System.Drawing.Point(0, 0);
            this.gbDriverLicenses.Name = "gbDriverLicenses";
            this.gbDriverLicenses.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            // 
            // gbDriverLicenses.Panel
            // 
            this.gbDriverLicenses.Panel.Controls.Add(this.tabControl);
            this.gbDriverLicenses.Size = new System.Drawing.Size(781, 270);
            this.gbDriverLicenses.TabIndex = 0;
            this.gbDriverLicenses.Values.Heading = "Driver Licenses";
            // 
            // tabControl
            // 
            this.tabControl.AllowPageReorder = false;
            this.tabControl.AllowTabFocus = false;
            this.tabControl.Bar.ItemSizing = ComponentFactory.Krypton.Navigator.BarItemSizing.Individual;
            this.tabControl.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.None;
            this.tabControl.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.None;
            this.tabControl.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Group.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonGallery;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.tabLocalLicense,
            this.tabInternationalLicense});
            this.tabControl.SelectedIndex = 1;
            this.tabControl.Size = new System.Drawing.Size(779, 247);
            this.tabControl.StateCommon.Panel.Color1 = System.Drawing.Color.White;
            this.tabControl.StateCommon.Tab.Back.Color1 = System.Drawing.Color.Red;
            this.tabControl.StateCommon.Tab.Back.Color2 = System.Drawing.Color.Firebrick;
            this.tabControl.StateCommon.Tab.Border.Color1 = System.Drawing.Color.Black;
            this.tabControl.StateCommon.Tab.Border.Color2 = System.Drawing.Color.Black;
            this.tabControl.StateCommon.Tab.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.tabControl.StateCommon.Tab.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.tabControl.StateCommon.Tab.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.tabControl.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.TabIndex = 16;
            this.tabControl.Text = "kryptonDockableNavigator1";
            // 
            // tabLocalLicense
            // 
            this.tabLocalLicense.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabLocalLicense.Controls.Add(this.dgvLocalLicenses);
            this.tabLocalLicense.Flags = 65534;
            this.tabLocalLicense.LastVisibleSet = true;
            this.tabLocalLicense.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabLocalLicense.Name = "tabLocalLicense";
            this.tabLocalLicense.Size = new System.Drawing.Size(777, 220);
            this.tabLocalLicense.Text = "Local License";
            this.tabLocalLicense.ToolTipTitle = "Page ToolTip";
            this.tabLocalLicense.UniqueName = "A69CFA91C3B5422819B6B0D72681C59C";
            // 
            // dgvLocalLicenses
            // 
            this.dgvLocalLicenses.AllowUserToAddRows = false;
            this.dgvLocalLicenses.AllowUserToDeleteRows = false;
            this.dgvLocalLicenses.AllowUserToResizeColumns = false;
            this.dgvLocalLicenses.AllowUserToResizeRows = false;
            this.dgvLocalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalLicenses.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvLocalLicenses.ColumnHeadersHeight = 30;
            this.dgvLocalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLocalLicenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LicenseID,
            this.ApplicationID,
            this.ClassName,
            this.IssueDate,
            this.ExpirationDate,
            this.IsActive});
            this.dgvLocalLicenses.ContextMenuStrip = this.contextMenu;
            this.dgvLocalLicenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLocalLicenses.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.dgvLocalLicenses.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.dgvLocalLicenses.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvLocalLicenses.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvLocalLicenses.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvLocalLicenses.Location = new System.Drawing.Point(0, 0);
            this.dgvLocalLicenses.MultiSelect = false;
            this.dgvLocalLicenses.Name = "dgvLocalLicenses";
            this.dgvLocalLicenses.ReadOnly = true;
            this.dgvLocalLicenses.RowHeadersVisible = false;
            this.dgvLocalLicenses.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvLocalLicenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalLicenses.ShowCellErrors = false;
            this.dgvLocalLicenses.ShowCellToolTips = false;
            this.dgvLocalLicenses.ShowEditingIcon = false;
            this.dgvLocalLicenses.ShowRowErrors = false;
            this.dgvLocalLicenses.Size = new System.Drawing.Size(777, 220);
            this.dgvLocalLicenses.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvLocalLicenses.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgvLocalLicenses.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.dgvLocalLicenses.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.Transparent;
            this.dgvLocalLicenses.StateCommon.DataCell.Back.Color2 = System.Drawing.Color.Transparent;
            this.dgvLocalLicenses.StateCommon.DataCell.Border.Color1 = System.Drawing.Color.White;
            this.dgvLocalLicenses.StateCommon.DataCell.Border.Color2 = System.Drawing.Color.White;
            this.dgvLocalLicenses.StateCommon.DataCell.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgvLocalLicenses.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.IndianRed;
            this.dgvLocalLicenses.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.Firebrick;
            this.dgvLocalLicenses.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgvLocalLicenses.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.White;
            this.dgvLocalLicenses.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Bahnschrift SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLocalLicenses.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvLocalLicenses.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgvLocalLicenses.TabIndex = 4;
            this.dgvLocalLicenses.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgvLicenses_MouseDown);
            // 
            // LicenseID
            // 
            this.LicenseID.DataPropertyName = "LicenseID";
            this.LicenseID.FillWeight = 50F;
            this.LicenseID.HeaderText = "LicenseID";
            this.LicenseID.Name = "LicenseID";
            this.LicenseID.ReadOnly = true;
            this.LicenseID.Width = 84;
            // 
            // ApplicationID
            // 
            this.ApplicationID.DataPropertyName = "ApplicationID";
            this.ApplicationID.FillWeight = 50F;
            this.ApplicationID.HeaderText = "ApplicationID";
            this.ApplicationID.Name = "ApplicationID";
            this.ApplicationID.ReadOnly = true;
            this.ApplicationID.Width = 85;
            // 
            // ClassName
            // 
            this.ClassName.DataPropertyName = "ClassName";
            this.ClassName.FillWeight = 150F;
            this.ClassName.HeaderText = "ClassName";
            this.ClassName.Name = "ClassName";
            this.ClassName.ReadOnly = true;
            this.ClassName.Width = 253;
            // 
            // IssueDate
            // 
            this.IssueDate.DataPropertyName = "IssueDate";
            this.IssueDate.FillWeight = 80F;
            this.IssueDate.HeaderText = "IssueDate";
            this.IssueDate.Name = "IssueDate";
            this.IssueDate.ReadOnly = true;
            this.IssueDate.Width = 135;
            // 
            // ExpirationDate
            // 
            this.ExpirationDate.DataPropertyName = "ExpirationDate";
            this.ExpirationDate.FillWeight = 80F;
            this.ExpirationDate.HeaderText = "ExpirationDate";
            this.ExpirationDate.Name = "ExpirationDate";
            this.ExpirationDate.ReadOnly = true;
            this.ExpirationDate.Width = 135;
            // 
            // IsActive
            // 
            this.IsActive.DataPropertyName = "IsActive";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = false;
            this.IsActive.DefaultCellStyle = dataGridViewCellStyle1;
            this.IsActive.FalseValue = null;
            this.IsActive.FillWeight = 50F;
            this.IsActive.HeaderText = "IsActive";
            this.IsActive.IndeterminateValue = null;
            this.IsActive.Name = "IsActive";
            this.IsActive.ReadOnly = true;
            this.IsActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsActive.TrueValue = null;
            // 
            // contextMenu
            // 
            this.contextMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowLicenseInfo});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(179, 36);
            // 
            // btnShowLicenseInfo
            // 
            this.btnShowLicenseInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnShowLicenseInfo.Image")));
            this.btnShowLicenseInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowLicenseInfo.Name = "btnShowLicenseInfo";
            this.btnShowLicenseInfo.Size = new System.Drawing.Size(178, 32);
            this.btnShowLicenseInfo.Text = "Show License Info";
            this.btnShowLicenseInfo.Click += new System.EventHandler(this.BtnShowLicenseInfo_Click);
            // 
            // tabInternationalLicense
            // 
            this.tabInternationalLicense.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabInternationalLicense.Controls.Add(this.dgvInternationalLicenses);
            this.tabInternationalLicense.Flags = 65534;
            this.tabInternationalLicense.LastVisibleSet = true;
            this.tabInternationalLicense.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabInternationalLicense.Name = "tabInternationalLicense";
            this.tabInternationalLicense.Size = new System.Drawing.Size(777, 220);
            this.tabInternationalLicense.Text = "International License";
            this.tabInternationalLicense.ToolTipTitle = "Page ToolTip";
            this.tabInternationalLicense.UniqueName = "E06031D33C19486683979FD4E9AFFA93";
            // 
            // dgvInternationalLicenses
            // 
            this.dgvInternationalLicenses.AllowUserToAddRows = false;
            this.dgvInternationalLicenses.AllowUserToDeleteRows = false;
            this.dgvInternationalLicenses.AllowUserToResizeColumns = false;
            this.dgvInternationalLicenses.AllowUserToResizeRows = false;
            this.dgvInternationalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInternationalLicenses.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvInternationalLicenses.ColumnHeadersHeight = 30;
            this.dgvInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInternationalLicenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InternationalLicenseID,
            this.Int_ApplicationID,
            this.IssuedUsingLocalLicenseID,
            this.Int_IssueDate,
            this.Int_ExpirationDate,
            this.Int_IsActive});
            this.dgvInternationalLicenses.ContextMenuStrip = this.contextMenu;
            this.dgvInternationalLicenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInternationalLicenses.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.dgvInternationalLicenses.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.dgvInternationalLicenses.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvInternationalLicenses.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvInternationalLicenses.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvInternationalLicenses.Location = new System.Drawing.Point(0, 0);
            this.dgvInternationalLicenses.MultiSelect = false;
            this.dgvInternationalLicenses.Name = "dgvInternationalLicenses";
            this.dgvInternationalLicenses.ReadOnly = true;
            this.dgvInternationalLicenses.RowHeadersVisible = false;
            this.dgvInternationalLicenses.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvInternationalLicenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInternationalLicenses.ShowCellErrors = false;
            this.dgvInternationalLicenses.ShowCellToolTips = false;
            this.dgvInternationalLicenses.ShowEditingIcon = false;
            this.dgvInternationalLicenses.ShowRowErrors = false;
            this.dgvInternationalLicenses.Size = new System.Drawing.Size(777, 220);
            this.dgvInternationalLicenses.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvInternationalLicenses.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgvInternationalLicenses.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.dgvInternationalLicenses.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.Transparent;
            this.dgvInternationalLicenses.StateCommon.DataCell.Back.Color2 = System.Drawing.Color.Transparent;
            this.dgvInternationalLicenses.StateCommon.DataCell.Border.Color1 = System.Drawing.Color.White;
            this.dgvInternationalLicenses.StateCommon.DataCell.Border.Color2 = System.Drawing.Color.White;
            this.dgvInternationalLicenses.StateCommon.DataCell.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgvInternationalLicenses.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.IndianRed;
            this.dgvInternationalLicenses.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.Firebrick;
            this.dgvInternationalLicenses.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgvInternationalLicenses.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.White;
            this.dgvInternationalLicenses.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Bahnschrift SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvInternationalLicenses.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvInternationalLicenses.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgvInternationalLicenses.TabIndex = 5;
            this.dgvInternationalLicenses.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgvLicenses_MouseDown);
            // 
            // InternationalLicenseID
            // 
            this.InternationalLicenseID.DataPropertyName = "InternationalLicenseID";
            this.InternationalLicenseID.FillWeight = 50F;
            this.InternationalLicenseID.HeaderText = "INT-LicenseID";
            this.InternationalLicenseID.Name = "InternationalLicenseID";
            this.InternationalLicenseID.ReadOnly = true;
            this.InternationalLicenseID.Width = 97;
            // 
            // Int_ApplicationID
            // 
            this.Int_ApplicationID.DataPropertyName = "ApplicationID";
            this.Int_ApplicationID.FillWeight = 50F;
            this.Int_ApplicationID.HeaderText = "App-ID";
            this.Int_ApplicationID.Name = "Int_ApplicationID";
            this.Int_ApplicationID.ReadOnly = true;
            this.Int_ApplicationID.Width = 97;
            // 
            // IssuedUsingLocalLicenseID
            // 
            this.IssuedUsingLocalLicenseID.DataPropertyName = "IssuedUsingLocalLicenseID";
            this.IssuedUsingLocalLicenseID.FillWeight = 50F;
            this.IssuedUsingLocalLicenseID.HeaderText = "L-LicenseID";
            this.IssuedUsingLocalLicenseID.Name = "IssuedUsingLocalLicenseID";
            this.IssuedUsingLocalLicenseID.ReadOnly = true;
            this.IssuedUsingLocalLicenseID.Width = 97;
            // 
            // Int_IssueDate
            // 
            this.Int_IssueDate.DataPropertyName = "IssueDate";
            this.Int_IssueDate.HeaderText = "IssueDate";
            this.Int_IssueDate.Name = "Int_IssueDate";
            this.Int_IssueDate.ReadOnly = true;
            this.Int_IssueDate.Width = 194;
            // 
            // Int_ExpirationDate
            // 
            this.Int_ExpirationDate.DataPropertyName = "ExpirationDate";
            this.Int_ExpirationDate.HeaderText = "ExpirationDate";
            this.Int_ExpirationDate.Name = "Int_ExpirationDate";
            this.Int_ExpirationDate.ReadOnly = true;
            this.Int_ExpirationDate.Width = 194;
            // 
            // Int_IsActive
            // 
            this.Int_IsActive.DataPropertyName = "IsActive";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = false;
            this.Int_IsActive.DefaultCellStyle = dataGridViewCellStyle2;
            this.Int_IsActive.FalseValue = null;
            this.Int_IsActive.FillWeight = 50F;
            this.Int_IsActive.HeaderText = "IsActive";
            this.Int_IsActive.IndeterminateValue = null;
            this.Int_IsActive.Name = "Int_IsActive";
            this.Int_IsActive.ReadOnly = true;
            this.Int_IsActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Int_IsActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Int_IsActive.TrueValue = null;
            // 
            // UCDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbDriverLicenses);
            this.Name = "UCDriverLicenses";
            this.Size = new System.Drawing.Size(781, 270);
            ((System.ComponentModel.ISupportInitialize)(this.gbDriverLicenses.Panel)).EndInit();
            this.gbDriverLicenses.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbDriverLicenses)).EndInit();
            this.gbDriverLicenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabLocalLicense)).EndInit();
            this.tabLocalLicense.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabInternationalLicense)).EndInit();
            this.tabInternationalLicense.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox gbDriverLicenses;
        private ComponentFactory.Krypton.Docking.KryptonDockableNavigator tabControl;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabLocalLicense;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabInternationalLicense;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvLocalLicenses;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvInternationalLicenses;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn LicenseID;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn ApplicationID;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn ClassName;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn IssueDate;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn ExpirationDate;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn IsActive;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn InternationalLicenseID;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Int_ApplicationID;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn IssuedUsingLocalLicenseID;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Int_IssueDate;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Int_ExpirationDate;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn Int_IsActive;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem btnShowLicenseInfo;
    }
}
