namespace DVLD_UI.Froms
{
    partial class FRMManageTestAppointments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMManageTestAppointments));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAddTestAppointment = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblTestType = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.pbTestType = new System.Windows.Forms.PictureBox();
            this.dgvTestAppointments = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.TestAppointmentID = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.AppointmentDate = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.PaidFees = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.IsLocked = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditTestAppointment = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTakeTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.ucldlApplicationInfo1 = new DVLD_UI.UserControls.UCLDLApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestAppointments)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddTestAppointment
            // 
            this.btnAddTestAppointment.Location = new System.Drawing.Point(803, 5);
            this.btnAddTestAppointment.Name = "btnAddTestAppointment";
            this.btnAddTestAppointment.Size = new System.Drawing.Size(69, 67);
            this.btnAddTestAppointment.StateCommon.Back.Color1 = System.Drawing.Color.AliceBlue;
            this.btnAddTestAppointment.StateCommon.Back.Color2 = System.Drawing.Color.WhiteSmoke;
            this.btnAddTestAppointment.TabIndex = 2;
            this.btnAddTestAppointment.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTestAppointment.Values.Image")));
            this.btnAddTestAppointment.Values.Text = "";
            this.btnAddTestAppointment.Click += new System.EventHandler(this.BtnAddTestAppointment_Click);
            // 
            // lblTestType
            // 
            this.lblTestType.Location = new System.Drawing.Point(108, 18);
            this.lblTestType.Name = "lblTestType";
            this.lblTestType.Size = new System.Drawing.Size(297, 42);
            this.lblTestType.StateCommon.ShortText.Color1 = System.Drawing.Color.Firebrick;
            this.lblTestType.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Uighur", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestType.StateCommon.ShortText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.lblTestType.TabIndex = 1;
            this.lblTestType.Values.Text = "Manage Test Appointments";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.btnAddTestAppointment);
            this.kryptonPanel2.Controls.Add(this.pbTestType);
            this.kryptonPanel2.Controls.Add(this.lblTestType);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(884, 79);
            this.kryptonPanel2.StateCommon.Color1 = System.Drawing.Color.White;
            this.kryptonPanel2.StateCommon.Color2 = System.Drawing.Color.White;
            this.kryptonPanel2.TabIndex = 10;
            // 
            // pbTestType
            // 
            this.pbTestType.Image = ((System.Drawing.Image)(resources.GetObject("pbTestType.Image")));
            this.pbTestType.Location = new System.Drawing.Point(12, 0);
            this.pbTestType.Name = "pbTestType";
            this.pbTestType.Size = new System.Drawing.Size(90, 79);
            this.pbTestType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestType.TabIndex = 0;
            this.pbTestType.TabStop = false;
            // 
            // dgvTestAppointments
            // 
            this.dgvTestAppointments.AllowUserToAddRows = false;
            this.dgvTestAppointments.AllowUserToDeleteRows = false;
            this.dgvTestAppointments.AllowUserToResizeColumns = false;
            this.dgvTestAppointments.AllowUserToResizeRows = false;
            this.dgvTestAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTestAppointments.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvTestAppointments.ColumnHeadersHeight = 30;
            this.dgvTestAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTestAppointments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TestAppointmentID,
            this.AppointmentDate,
            this.PaidFees,
            this.IsLocked});
            this.dgvTestAppointments.ContextMenuStrip = this.contextMenu;
            this.dgvTestAppointments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTestAppointments.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.dgvTestAppointments.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.dgvTestAppointments.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvTestAppointments.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvTestAppointments.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.dgvTestAppointments.Location = new System.Drawing.Point(0, 0);
            this.dgvTestAppointments.MultiSelect = false;
            this.dgvTestAppointments.Name = "dgvTestAppointments";
            this.dgvTestAppointments.ReadOnly = true;
            this.dgvTestAppointments.RowHeadersVisible = false;
            this.dgvTestAppointments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTestAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTestAppointments.ShowCellErrors = false;
            this.dgvTestAppointments.ShowCellToolTips = false;
            this.dgvTestAppointments.ShowEditingIcon = false;
            this.dgvTestAppointments.ShowRowErrors = false;
            this.dgvTestAppointments.Size = new System.Drawing.Size(391, 282);
            this.dgvTestAppointments.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvTestAppointments.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgvTestAppointments.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.dgvTestAppointments.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.Transparent;
            this.dgvTestAppointments.StateCommon.DataCell.Back.Color2 = System.Drawing.Color.Transparent;
            this.dgvTestAppointments.StateCommon.DataCell.Border.Color1 = System.Drawing.Color.White;
            this.dgvTestAppointments.StateCommon.DataCell.Border.Color2 = System.Drawing.Color.White;
            this.dgvTestAppointments.StateCommon.DataCell.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgvTestAppointments.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.IndianRed;
            this.dgvTestAppointments.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.Firebrick;
            this.dgvTestAppointments.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgvTestAppointments.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.White;
            this.dgvTestAppointments.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Bahnschrift SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTestAppointments.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvTestAppointments.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgvTestAppointments.TabIndex = 3;
            this.dgvTestAppointments.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgvTestAppointments_MouseDown);
            // 
            // TestAppointmentID
            // 
            this.TestAppointmentID.DataPropertyName = "TestAppointmentID";
            this.TestAppointmentID.FillWeight = 60F;
            this.TestAppointmentID.HeaderText = "AppointmentID";
            this.TestAppointmentID.Name = "TestAppointmentID";
            this.TestAppointmentID.ReadOnly = true;
            this.TestAppointmentID.Width = 90;
            // 
            // AppointmentDate
            // 
            this.AppointmentDate.DataPropertyName = "AppointmentDate";
            this.AppointmentDate.HeaderText = "AppointmentDate";
            this.AppointmentDate.Name = "AppointmentDate";
            this.AppointmentDate.ReadOnly = true;
            this.AppointmentDate.Width = 150;
            // 
            // PaidFees
            // 
            this.PaidFees.DataPropertyName = "PaidFees";
            this.PaidFees.FillWeight = 50F;
            this.PaidFees.HeaderText = "PaidFees";
            this.PaidFees.Name = "PaidFees";
            this.PaidFees.ReadOnly = true;
            this.PaidFees.Width = 75;
            // 
            // IsLocked
            // 
            this.IsLocked.DataPropertyName = "IsLocked";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = false;
            this.IsLocked.DefaultCellStyle = dataGridViewCellStyle1;
            this.IsLocked.FalseValue = null;
            this.IsLocked.FillWeight = 50F;
            this.IsLocked.HeaderText = "IsLocked";
            this.IsLocked.IndeterminateValue = null;
            this.IsLocked.Name = "IsLocked";
            this.IsLocked.ReadOnly = true;
            this.IsLocked.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsLocked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsLocked.TrueValue = null;
            // 
            // contextMenu
            // 
            this.contextMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btnEditTestAppointment,
            this.btnTakeTest,
            this.toolStripSeparator2,
            this.btnRefresh});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(190, 134);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(186, 6);
            // 
            // btnEditTestAppointment
            // 
            this.btnEditTestAppointment.Image = ((System.Drawing.Image)(resources.GetObject("btnEditTestAppointment.Image")));
            this.btnEditTestAppointment.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditTestAppointment.Name = "btnEditTestAppointment";
            this.btnEditTestAppointment.Size = new System.Drawing.Size(189, 32);
            this.btnEditTestAppointment.Text = "Edit";
            this.btnEditTestAppointment.Click += new System.EventHandler(this.BtnEditTestAppointment_Click);
            // 
            // btnTakeTest
            // 
            this.btnTakeTest.Image = ((System.Drawing.Image)(resources.GetObject("btnTakeTest.Image")));
            this.btnTakeTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnTakeTest.Name = "btnTakeTest";
            this.btnTakeTest.Size = new System.Drawing.Size(189, 32);
            this.btnTakeTest.Text = "Take Test";
            this.btnTakeTest.Click += new System.EventHandler(this.BtnTakeTest_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(186, 6);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(189, 32);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.dgvTestAppointments);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.kryptonPanel1.Location = new System.Drawing.Point(493, 79);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(391, 282);
            this.kryptonPanel1.StateCommon.Color1 = System.Drawing.Color.White;
            this.kryptonPanel1.StateCommon.Color2 = System.Drawing.Color.White;
            this.kryptonPanel1.TabIndex = 11;
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.ucldlApplicationInfo1);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel3.Location = new System.Drawing.Point(0, 79);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.kryptonPanel3.Size = new System.Drawing.Size(493, 282);
            this.kryptonPanel3.TabIndex = 12;
            // 
            // ucldlApplicationInfo1
            // 
            this.ucldlApplicationInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucldlApplicationInfo1.Location = new System.Drawing.Point(0, 0);
            this.ucldlApplicationInfo1.Name = "ucldlApplicationInfo1";
            this.ucldlApplicationInfo1.Size = new System.Drawing.Size(493, 282);
            this.ucldlApplicationInfo1.TabIndex = 0;
            // 
            // FRMManageTestAppointments
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 361);
            this.Controls.Add(this.kryptonPanel3);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.kryptonPanel2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 400);
            this.Name = "FRMManageTestAppointments";
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
            this.Text = "Manage Test Appointments";
            this.Load += new System.EventHandler(this.FRMManageTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestAppointments)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UCLDLApplicationInfo ucldlApplicationInfo1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddTestAppointment;
        private System.Windows.Forms.PictureBox pbTestType;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTestType;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvTestAppointments;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn TestAppointmentID;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn AppointmentDate;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn PaidFees;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn IsLocked;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnEditTestAppointment;
        private System.Windows.Forms.ToolStripMenuItem btnTakeTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnRefresh;
    }
}