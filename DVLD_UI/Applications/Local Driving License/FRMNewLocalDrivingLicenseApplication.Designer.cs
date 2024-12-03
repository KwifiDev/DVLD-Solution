namespace DVLD_UI.Froms
{
    partial class FRMNewLocalDrivingLicenseApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMNewLocalDrivingLicenseApplication));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMode = new System.Windows.Forms.Panel();
            this.lblTitle = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl = new ComponentFactory.Krypton.Docking.KryptonDockableNavigator();
            this.tabSelectPerson = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.btnNextStep = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ucFindPerson1 = new DVLD_UI.UserControls.UCFindPerson();
            this.tabCreateApplication = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.lblCreatedByUser = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblApplicationFees = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblApplicationDate = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cbLicenseClasses = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lblLDLApplicationID = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel12 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnBackPrev = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCreateLocalLicenseApplication = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel1.SuspendLayout();
            this.panelMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabSelectPerson)).BeginInit();
            this.tabSelectPerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabCreateApplication)).BeginInit();
            this.tabCreateApplication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbLicenseClasses)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelMode);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 98);
            this.panel1.TabIndex = 5;
            // 
            // panelMode
            // 
            this.panelMode.BackColor = System.Drawing.Color.SteelBlue;
            this.panelMode.Controls.Add(this.lblTitle);
            this.panelMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMode.Location = new System.Drawing.Point(0, 0);
            this.panelMode.Name = "panelMode";
            this.panelMode.Size = new System.Drawing.Size(204, 98);
            this.panelMode.TabIndex = 5;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(204, 98);
            this.lblTitle.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.lblTitle.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Uighur", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.StateCommon.ShortText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.lblTitle.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.lblTitle.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Values.Text = "New Local\r\nDriving License";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(204, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(580, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
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
            this.tabControl.Location = new System.Drawing.Point(0, 98);
            this.tabControl.Name = "tabControl";
            this.tabControl.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.tabSelectPerson,
            this.tabCreateApplication});
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(784, 313);
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
            this.tabControl.TabIndex = 15;
            this.tabControl.Text = "kryptonDockableNavigator1";
            // 
            // tabSelectPerson
            // 
            this.tabSelectPerson.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabSelectPerson.Controls.Add(this.btnNextStep);
            this.tabSelectPerson.Controls.Add(this.ucFindPerson1);
            this.tabSelectPerson.Flags = 65534;
            this.tabSelectPerson.LastVisibleSet = true;
            this.tabSelectPerson.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabSelectPerson.Name = "tabSelectPerson";
            this.tabSelectPerson.Size = new System.Drawing.Size(782, 286);
            this.tabSelectPerson.Text = "Select Person";
            this.tabSelectPerson.ToolTipTitle = "Page ToolTip";
            this.tabSelectPerson.UniqueName = "A69CFA91C3B5422819B6B0D72681C59C";
            // 
            // btnNextStep
            // 
            this.btnNextStep.Enabled = false;
            this.btnNextStep.Location = new System.Drawing.Point(711, 198);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(66, 75);
            this.btnNextStep.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextStep.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnNextStep.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnNextStep.TabIndex = 26;
            this.btnNextStep.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnNextStep.Values.Image")));
            this.btnNextStep.Values.Text = "Next";
            this.btnNextStep.Click += new System.EventHandler(this.BtnNextStep_Click);
            // 
            // ucFindPerson1
            // 
            this.ucFindPerson1.BtnAddPerson_Visible = true;
            this.ucFindPerson1.Filter_Enabled = true;
            this.ucFindPerson1.Location = new System.Drawing.Point(1, 8);
            this.ucFindPerson1.Name = "ucFindPerson1";
            this.ucFindPerson1.Size = new System.Drawing.Size(781, 270);
            this.ucFindPerson1.TabIndex = 0;
            this.ucFindPerson1.OnPersonFound += new System.Action<bool>(this.UcFindPerson1_OnIsPersonFound);
            // 
            // tabCreateApplication
            // 
            this.tabCreateApplication.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabCreateApplication.Controls.Add(this.lblCreatedByUser);
            this.tabCreateApplication.Controls.Add(this.lblApplicationFees);
            this.tabCreateApplication.Controls.Add(this.lblApplicationDate);
            this.tabCreateApplication.Controls.Add(this.cbLicenseClasses);
            this.tabCreateApplication.Controls.Add(this.lblLDLApplicationID);
            this.tabCreateApplication.Controls.Add(this.kryptonLabel12);
            this.tabCreateApplication.Controls.Add(this.kryptonLabel5);
            this.tabCreateApplication.Controls.Add(this.kryptonLabel4);
            this.tabCreateApplication.Controls.Add(this.kryptonLabel2);
            this.tabCreateApplication.Controls.Add(this.kryptonLabel1);
            this.tabCreateApplication.Controls.Add(this.btnBackPrev);
            this.tabCreateApplication.Controls.Add(this.btnCreateLocalLicenseApplication);
            this.tabCreateApplication.Flags = 65534;
            this.tabCreateApplication.LastVisibleSet = true;
            this.tabCreateApplication.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabCreateApplication.Name = "tabCreateApplication";
            this.tabCreateApplication.Size = new System.Drawing.Size(782, 286);
            this.tabCreateApplication.Text = "Application Info";
            this.tabCreateApplication.ToolTipTitle = "Page ToolTip";
            this.tabCreateApplication.UniqueName = "E06031D33C19486683979FD4E9AFFA93";
            this.tabCreateApplication.Visible = false;
            // 
            // lblCreatedByUser
            // 
            this.lblCreatedByUser.Location = new System.Drawing.Point(341, 219);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(29, 21);
            this.lblCreatedByUser.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByUser.TabIndex = 60;
            this.lblCreatedByUser.Values.Text = "???";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.Location = new System.Drawing.Point(341, 176);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(29, 21);
            this.lblApplicationFees.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.TabIndex = 59;
            this.lblApplicationFees.Values.Text = "???";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.Location = new System.Drawing.Point(341, 90);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(29, 21);
            this.lblApplicationDate.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.TabIndex = 58;
            this.lblApplicationDate.Values.Text = "???";
            // 
            // cbLicenseClasses
            // 
            this.cbLicenseClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClasses.DropDownWidth = 159;
            this.cbLicenseClasses.Location = new System.Drawing.Point(341, 135);
            this.cbLicenseClasses.Name = "cbLicenseClasses";
            this.cbLicenseClasses.Size = new System.Drawing.Size(241, 21);
            this.cbLicenseClasses.TabIndex = 47;
            this.cbLicenseClasses.SelectedIndexChanged += new System.EventHandler(this.CbLicenseClasses_SelectedIndexChanged);
            // 
            // lblLDLApplicationID
            // 
            this.lblLDLApplicationID.Location = new System.Drawing.Point(341, 47);
            this.lblLDLApplicationID.Name = "lblLDLApplicationID";
            this.lblLDLApplicationID.Size = new System.Drawing.Size(29, 21);
            this.lblLDLApplicationID.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLDLApplicationID.TabIndex = 57;
            this.lblLDLApplicationID.Values.Text = "???";
            // 
            // kryptonLabel12
            // 
            this.kryptonLabel12.Location = new System.Drawing.Point(224, 133);
            this.kryptonLabel12.Name = "kryptonLabel12";
            this.kryptonLabel12.Size = new System.Drawing.Size(94, 21);
            this.kryptonLabel12.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel12.TabIndex = 56;
            this.kryptonLabel12.Values.Text = "License Class :";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(237, 219);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(81, 21);
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.TabIndex = 46;
            this.kryptonLabel5.Values.Text = "Created By :";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(204, 176);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(114, 21);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.TabIndex = 44;
            this.kryptonLabel4.Values.Text = "Application Fees :";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(202, 90);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(116, 21);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 40;
            this.kryptonLabel2.Values.Text = "Application Date :";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(193, 47);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(125, 21);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 38;
            this.kryptonLabel1.Values.Text = "LDL-ApplicationID :";
            // 
            // btnBackPrev
            // 
            this.btnBackPrev.Location = new System.Drawing.Point(13, 193);
            this.btnBackPrev.Name = "btnBackPrev";
            this.btnBackPrev.Size = new System.Drawing.Size(66, 75);
            this.btnBackPrev.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackPrev.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnBackPrev.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnBackPrev.TabIndex = 37;
            this.btnBackPrev.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnBackPrev.Values.Image")));
            this.btnBackPrev.Values.Text = "Back";
            this.btnBackPrev.Click += new System.EventHandler(this.BtnBackPrev_Click);
            // 
            // btnCreateLocalLicenseApplication
            // 
            this.btnCreateLocalLicenseApplication.Location = new System.Drawing.Point(680, 243);
            this.btnCreateLocalLicenseApplication.Name = "btnCreateLocalLicenseApplication";
            this.btnCreateLocalLicenseApplication.Size = new System.Drawing.Size(90, 25);
            this.btnCreateLocalLicenseApplication.TabIndex = 36;
            this.btnCreateLocalLicenseApplication.Values.Text = "Create";
            this.btnCreateLocalLicenseApplication.Click += new System.EventHandler(this.BtnCreateLocalLicenseApplication_Click);
            // 
            // FRMNewLocalDrivingLicenseApplication
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 450);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "FRMNewLocalDrivingLicenseApplication";
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
            this.Text = "New Local Driving License Application";
            this.Load += new System.EventHandler(this.FRMNewLocalDrivingLicenseApplication_Load);
            this.panel1.ResumeLayout(false);
            this.panelMode.ResumeLayout(false);
            this.panelMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabSelectPerson)).EndInit();
            this.tabSelectPerson.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabCreateApplication)).EndInit();
            this.tabCreateApplication.ResumeLayout(false);
            this.tabCreateApplication.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbLicenseClasses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelMode;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ComponentFactory.Krypton.Docking.KryptonDockableNavigator tabControl;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabSelectPerson;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabCreateApplication;
        private UserControls.UCFindPerson ucFindPerson1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnNextStep;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnBackPrev;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCreateLocalLicenseApplication;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbLicenseClasses;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblLDLApplicationID;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel12;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblApplicationDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblCreatedByUser;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblApplicationFees;
    }
}