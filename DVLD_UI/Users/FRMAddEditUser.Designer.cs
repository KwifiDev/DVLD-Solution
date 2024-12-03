namespace DVLD_UI.Froms
{
    partial class FRMAddEditUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMAddEditUser));
            this.lblPersonMode = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMode = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl = new ComponentFactory.Krypton.Docking.KryptonDockableNavigator();
            this.tabSelectPerson = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.btnNextStep = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tabCreateUser = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.cbFullControl = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.cbIsActive = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.btnBackPrev = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCreateUser = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblUserID = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtConfirmPassword = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtPassword = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtUsername = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ucFindPerson1 = new DVLD_UI.UserControls.UCFindPerson();
            this.ucAddEditUserPermissions1 = new DVLD_UI.Users.Controls.UCAddEditUserPermissions();
            this.panel1.SuspendLayout();
            this.panelMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabSelectPerson)).BeginInit();
            this.tabSelectPerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabCreateUser)).BeginInit();
            this.tabCreateUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPersonMode
            // 
            this.lblPersonMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPersonMode.Location = new System.Drawing.Point(0, 0);
            this.lblPersonMode.Name = "lblPersonMode";
            this.lblPersonMode.Size = new System.Drawing.Size(204, 98);
            this.lblPersonMode.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.lblPersonMode.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Uighur", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonMode.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.lblPersonMode.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.lblPersonMode.TabIndex = 3;
            this.lblPersonMode.Values.Text = "Add New User";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelMode);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 98);
            this.panel1.TabIndex = 6;
            // 
            // panelMode
            // 
            this.panelMode.BackColor = System.Drawing.Color.SteelBlue;
            this.panelMode.Controls.Add(this.lblPersonMode);
            this.panelMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMode.Location = new System.Drawing.Point(0, 0);
            this.panelMode.Name = "panelMode";
            this.panelMode.Size = new System.Drawing.Size(204, 98);
            this.panelMode.TabIndex = 5;
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
            this.tabCreateUser});
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
            this.tabControl.TabIndex = 14;
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
            this.btnNextStep.TabIndex = 25;
            this.btnNextStep.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnNextStep.Values.Image")));
            this.btnNextStep.Values.Text = "Next";
            this.btnNextStep.Click += new System.EventHandler(this.BtnNextStep_Click);
            // 
            // tabCreateUser
            // 
            this.tabCreateUser.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabCreateUser.Controls.Add(this.cbFullControl);
            this.tabCreateUser.Controls.Add(this.ucAddEditUserPermissions1);
            this.tabCreateUser.Controls.Add(this.cbIsActive);
            this.tabCreateUser.Controls.Add(this.btnBackPrev);
            this.tabCreateUser.Controls.Add(this.btnCreateUser);
            this.tabCreateUser.Controls.Add(this.lblUserID);
            this.tabCreateUser.Controls.Add(this.txtConfirmPassword);
            this.tabCreateUser.Controls.Add(this.txtPassword);
            this.tabCreateUser.Controls.Add(this.kryptonLabel7);
            this.tabCreateUser.Controls.Add(this.kryptonLabel6);
            this.tabCreateUser.Controls.Add(this.kryptonLabel5);
            this.tabCreateUser.Controls.Add(this.kryptonLabel2);
            this.tabCreateUser.Controls.Add(this.txtUsername);
            this.tabCreateUser.Flags = 65534;
            this.tabCreateUser.LastVisibleSet = true;
            this.tabCreateUser.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabCreateUser.Name = "tabCreateUser";
            this.tabCreateUser.Size = new System.Drawing.Size(782, 286);
            this.tabCreateUser.Text = "Create User";
            this.tabCreateUser.ToolTipTitle = "Page ToolTip";
            this.tabCreateUser.UniqueName = "E06031D33C19486683979FD4E9AFFA93";
            this.tabCreateUser.Visible = false;
            // 
            // cbFullControl
            // 
            this.cbFullControl.Location = new System.Drawing.Point(208, 251);
            this.cbFullControl.Name = "cbFullControl";
            this.cbFullControl.Size = new System.Drawing.Size(126, 20);
            this.cbFullControl.TabIndex = 38;
            this.cbFullControl.Values.Text = "Full Admin Control";
            this.cbFullControl.CheckedChanged += new System.EventHandler(this.CbFullControl_CheckedChanged);
            // 
            // cbIsActive
            // 
            this.cbIsActive.Location = new System.Drawing.Point(208, 226);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(105, 20);
            this.cbIsActive.TabIndex = 36;
            this.cbIsActive.Values.Text = "Account Status";
            // 
            // btnBackPrev
            // 
            this.btnBackPrev.Location = new System.Drawing.Point(11, 193);
            this.btnBackPrev.Name = "btnBackPrev";
            this.btnBackPrev.Size = new System.Drawing.Size(66, 75);
            this.btnBackPrev.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackPrev.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnBackPrev.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnBackPrev.TabIndex = 35;
            this.btnBackPrev.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnBackPrev.Values.Image")));
            this.btnBackPrev.Values.Text = "Back";
            this.btnBackPrev.Click += new System.EventHandler(this.BtnBackPrev_Click);
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.Location = new System.Drawing.Point(705, 193);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(66, 75);
            this.btnCreateUser.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            this.btnCreateUser.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnCreateUser.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnCreateUser.TabIndex = 34;
            this.btnCreateUser.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateUser.Values.Image")));
            this.btnCreateUser.Values.Text = "Create";
            this.btnCreateUser.Click += new System.EventHandler(this.BtnCreateUser_Click);
            // 
            // lblUserID
            // 
            this.lblUserID.Location = new System.Drawing.Point(208, 19);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(29, 21);
            this.lblUserID.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.TabIndex = 33;
            this.lblUserID.Values.Text = "???";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(208, 194);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '●';
            this.txtConfirmPassword.Size = new System.Drawing.Size(161, 23);
            this.txtConfirmPassword.TabIndex = 32;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.AllTextBoxs_Validating);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(208, 135);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(161, 23);
            this.txtPassword.TabIndex = 31;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.AllTextBoxs_Validating);
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(129, 77);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(77, 21);
            this.kryptonLabel7.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel7.TabIndex = 30;
            this.kryptonLabel7.Values.Text = "Username :";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(133, 136);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(73, 21);
            this.kryptonLabel6.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel6.TabIndex = 29;
            this.kryptonLabel6.Values.Text = "Password :";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(82, 195);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(124, 21);
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.TabIndex = 28;
            this.kryptonLabel5.Values.Text = "Confirm Password :";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(149, 19);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(57, 21);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 27;
            this.kryptonLabel2.Values.Text = "UserID :";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(208, 76);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(161, 23);
            this.txtUsername.TabIndex = 26;
            this.txtUsername.Validating += new System.ComponentModel.CancelEventHandler(this.AllTextBoxs_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ucFindPerson1
            // 
            this.ucFindPerson1.BtnAddPerson_Visible = true;
            this.ucFindPerson1.Filter_Enabled = true;
            this.ucFindPerson1.Location = new System.Drawing.Point(1, 8);
            this.ucFindPerson1.Name = "ucFindPerson1";
            this.ucFindPerson1.Size = new System.Drawing.Size(781, 270);
            this.ucFindPerson1.TabIndex = 26;
            this.ucFindPerson1.OnPersonFound += new System.Action<bool>(this.UcFindPerson1_OnPersonFound);
            // 
            // ucAddEditUserPermissions1
            // 
            this.ucAddEditUserPermissions1.Location = new System.Drawing.Point(389, 6);
            this.ucAddEditUserPermissions1.Name = "ucAddEditUserPermissions1";
            this.ucAddEditUserPermissions1.Size = new System.Drawing.Size(307, 275);
            this.ucAddEditUserPermissions1.TabIndex = 37;
            // 
            // FRMAddEditUser
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
            this.Name = "FRMAddEditUser";
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
            this.Text = "Add / Edit New User";
            this.Load += new System.EventHandler(this.FRMAddEditUser_Load);
            this.panel1.ResumeLayout(false);
            this.panelMode.ResumeLayout(false);
            this.panelMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabSelectPerson)).EndInit();
            this.tabSelectPerson.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabCreateUser)).EndInit();
            this.tabCreateUser.ResumeLayout(false);
            this.tabCreateUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblPersonMode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelMode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ComponentFactory.Krypton.Docking.KryptonDockableNavigator tabControl;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabSelectPerson;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabCreateUser;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox cbIsActive;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnBackPrev;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCreateUser;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblUserID;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtConfirmPassword;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPassword;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUsername;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnNextStep;
        private UserControls.UCFindPerson ucFindPerson1;
        private Users.Controls.UCAddEditUserPermissions ucAddEditUserPermissions1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox cbFullControl;
    }
}