namespace DVLD_UI
{
    partial class UCLoginAccountHeader
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
            this.btnChangePassword = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnLogout = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblNameOfUser = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.btnCurrentUserInfo = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangePassword.Location = new System.Drawing.Point(553, 38);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(121, 25);
            this.btnChangePassword.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnChangePassword.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnChangePassword.TabIndex = 1;
            this.btnChangePassword.Values.Text = "ChangePassword";
            this.btnChangePassword.Click += new System.EventHandler(this.BtnChangePassword_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Location = new System.Drawing.Point(680, 38);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(121, 25);
            this.btnLogout.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnLogout.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Values.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // lblNameOfUser
            // 
            this.lblNameOfUser.Location = new System.Drawing.Point(82, 26);
            this.lblNameOfUser.Name = "lblNameOfUser";
            this.lblNameOfUser.Size = new System.Drawing.Size(65, 20);
            this.lblNameOfUser.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.lblNameOfUser.StateCommon.ShortText.Color2 = System.Drawing.Color.White;
            this.lblNameOfUser.StateCommon.ShortText.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameOfUser.TabIndex = 0;
            this.lblNameOfUser.Values.Text = "LoginUser";
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPersonImage.Location = new System.Drawing.Point(22, 10);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(54, 50);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPersonImage.TabIndex = 4;
            this.pbPersonImage.TabStop = false;
            // 
            // btnCurrentUserInfo
            // 
            this.btnCurrentUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCurrentUserInfo.Location = new System.Drawing.Point(680, 7);
            this.btnCurrentUserInfo.Name = "btnCurrentUserInfo";
            this.btnCurrentUserInfo.Size = new System.Drawing.Size(121, 25);
            this.btnCurrentUserInfo.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnCurrentUserInfo.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnCurrentUserInfo.TabIndex = 5;
            this.btnCurrentUserInfo.Values.Text = "Show Info";
            this.btnCurrentUserInfo.Click += new System.EventHandler(this.BtnCurrentUserInfo_Click);
            // 
            // UCLoginAccountHeader
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Brown;
            this.Controls.Add(this.btnCurrentUserInfo);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblNameOfUser);
            this.Controls.Add(this.pbPersonImage);
            this.Name = "UCLoginAccountHeader";
            this.Size = new System.Drawing.Size(822, 71);
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton btnChangePassword;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnLogout;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblNameOfUser;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCurrentUserInfo;
    }
}
