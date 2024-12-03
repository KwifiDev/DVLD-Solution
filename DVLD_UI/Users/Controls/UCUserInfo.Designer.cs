namespace DVLD_UI
{
    partial class UCUserInfo
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
            this.ucPersonInfo1 = new DVLD_UI.UCPersonInfo();
            this.lblIsActive = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblPassword = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblUsername = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblUserID = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel12 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.gbUserInfo = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gbUserInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbUserInfo.Panel)).BeginInit();
            this.gbUserInfo.Panel.SuspendLayout();
            this.gbUserInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucPersonInfo1
            // 
            this.ucPersonInfo1.Location = new System.Drawing.Point(0, 2);
            this.ucPersonInfo1.Name = "ucPersonInfo1";
            this.ucPersonInfo1.Size = new System.Drawing.Size(700, 200);
            this.ucPersonInfo1.TabIndex = 0;
            // 
            // lblIsActive
            // 
            this.lblIsActive.Location = new System.Drawing.Point(331, 7);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(29, 21);
            this.lblIsActive.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsActive.TabIndex = 23;
            this.lblIsActive.Values.Text = "???";
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(332, 34);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(70, 21);
            this.lblPassword.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.TabIndex = 15;
            this.lblPassword.Values.Text = "Encrypted";
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(138, 34);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(29, 21);
            this.lblUsername.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.TabIndex = 14;
            this.lblUsername.Values.Text = "???";
            // 
            // lblUserID
            // 
            this.lblUserID.Location = new System.Drawing.Point(138, 7);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(29, 21);
            this.lblUserID.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.TabIndex = 13;
            this.lblUserID.Values.Text = "???";
            // 
            // kryptonLabel12
            // 
            this.kryptonLabel12.Location = new System.Drawing.Point(284, 7);
            this.kryptonLabel12.Name = "kryptonLabel12";
            this.kryptonLabel12.Size = new System.Drawing.Size(54, 21);
            this.kryptonLabel12.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel12.TabIndex = 11;
            this.kryptonLabel12.Values.Text = "Status :";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(263, 34);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(73, 21);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 2;
            this.kryptonLabel3.Values.Text = "Password :";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(65, 34);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(77, 21);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Username :";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(112, 7);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(30, 21);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "ID :";
            // 
            // gbUserInfo
            // 
            this.gbUserInfo.CaptionEdge = ComponentFactory.Krypton.Toolkit.VisualOrientation.Bottom;
            this.gbUserInfo.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ToolTip;
            this.gbUserInfo.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonStandalone;
            this.gbUserInfo.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.FormMain;
            this.gbUserInfo.Location = new System.Drawing.Point(0, 212);
            this.gbUserInfo.Name = "gbUserInfo";
            this.gbUserInfo.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            // 
            // gbUserInfo.Panel
            // 
            this.gbUserInfo.Panel.Controls.Add(this.lblIsActive);
            this.gbUserInfo.Panel.Controls.Add(this.lblPassword);
            this.gbUserInfo.Panel.Controls.Add(this.lblUsername);
            this.gbUserInfo.Panel.Controls.Add(this.lblUserID);
            this.gbUserInfo.Panel.Controls.Add(this.kryptonLabel12);
            this.gbUserInfo.Panel.Controls.Add(this.kryptonLabel3);
            this.gbUserInfo.Panel.Controls.Add(this.kryptonLabel2);
            this.gbUserInfo.Panel.Controls.Add(this.kryptonLabel1);
            this.gbUserInfo.Size = new System.Drawing.Size(700, 88);
            this.gbUserInfo.StateCommon.Back.Color1 = System.Drawing.Color.AliceBlue;
            this.gbUserInfo.TabIndex = 1;
            this.gbUserInfo.Values.Heading = "User Information";
            // 
            // UCUserInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.gbUserInfo);
            this.Controls.Add(this.ucPersonInfo1);
            this.Name = "UCUserInfo";
            this.Size = new System.Drawing.Size(700, 302);
            ((System.ComponentModel.ISupportInitialize)(this.gbUserInfo.Panel)).EndInit();
            this.gbUserInfo.Panel.ResumeLayout(false);
            this.gbUserInfo.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbUserInfo)).EndInit();
            this.gbUserInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UCPersonInfo ucPersonInfo1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblIsActive;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblPassword;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblUsername;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblUserID;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel12;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox gbUserInfo;
    }
}
