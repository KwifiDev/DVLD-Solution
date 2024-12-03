namespace DVLD_UI.UserControls
{
    partial class UCIssueDrivingLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCIssueDrivingLicense));
            this.txtLicenseNotes = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnIssueLicense = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ucldlApplicationInfo1 = new DVLD_UI.UserControls.UCLDLApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLicenseNotes
            // 
            this.txtLicenseNotes.Location = new System.Drawing.Point(16, 332);
            this.txtLicenseNotes.Multiline = true;
            this.txtLicenseNotes.Name = "txtLicenseNotes";
            this.txtLicenseNotes.Size = new System.Drawing.Size(487, 61);
            this.txtLicenseNotes.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(16, 306);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(49, 20);
            this.kryptonLabel1.TabIndex = 2;
            this.kryptonLabel1.Values.Text = "Notes :";
            // 
            // btnIssueLicense
            // 
            this.btnIssueLicense.Location = new System.Drawing.Point(509, 332);
            this.btnIssueLicense.Name = "btnIssueLicense";
            this.btnIssueLicense.Size = new System.Drawing.Size(203, 61);
            this.btnIssueLicense.StateCommon.Back.Color1 = System.Drawing.Color.Firebrick;
            this.btnIssueLicense.StateCommon.Back.Color2 = System.Drawing.Color.Red;
            this.btnIssueLicense.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnIssueLicense.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnIssueLicense.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueLicense.TabIndex = 3;
            this.btnIssueLicense.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonButton1.Values.Image")));
            this.btnIssueLicense.Values.Text = "Issue Driving License";
            this.btnIssueLicense.Click += new System.EventHandler(this.BtnIssueLicense_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(506, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // ucldlApplicationInfo1
            // 
            this.ucldlApplicationInfo1.Location = new System.Drawing.Point(16, 16);
            this.ucldlApplicationInfo1.Name = "ucldlApplicationInfo1";
            this.ucldlApplicationInfo1.Size = new System.Drawing.Size(487, 275);
            this.ucldlApplicationInfo1.TabIndex = 0;
            // 
            // UCIssueDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnIssueLicense);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.txtLicenseNotes);
            this.Controls.Add(this.ucldlApplicationInfo1);
            this.Name = "UCIssueDrivingLicense";
            this.Size = new System.Drawing.Size(715, 415);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UCLDLApplicationInfo ucldlApplicationInfo1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLicenseNotes;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnIssueLicense;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
