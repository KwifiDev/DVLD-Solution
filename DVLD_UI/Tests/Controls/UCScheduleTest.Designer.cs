namespace DVLD_UI.UserControls
{
    partial class UCScheduleTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCScheduleTest));
            this.gbTestAppointmentInfo = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.gbRetakeTestInfo = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.lblRetakeApplicationID = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblTotalFees = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblRetakeApplicationFees = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pbTestType = new System.Windows.Forms.PictureBox();
            this.lblTestType = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtpAppointmentDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblPaidFees = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel12 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel10 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblTestTrials = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblFullName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblClassType = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblLDLApplicationID = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblUserMessage = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gbTestAppointmentInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbTestAppointmentInfo.Panel)).BeginInit();
            this.gbTestAppointmentInfo.Panel.SuspendLayout();
            this.gbTestAppointmentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbRetakeTestInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbRetakeTestInfo.Panel)).BeginInit();
            this.gbRetakeTestInfo.Panel.SuspendLayout();
            this.gbRetakeTestInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTestAppointmentInfo
            // 
            this.gbTestAppointmentInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTestAppointmentInfo.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonAlternate;
            this.gbTestAppointmentInfo.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ButtonFormClose;
            this.gbTestAppointmentInfo.Location = new System.Drawing.Point(0, 0);
            this.gbTestAppointmentInfo.Name = "gbTestAppointmentInfo";
            this.gbTestAppointmentInfo.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            // 
            // gbTestAppointmentInfo.Panel
            // 
            this.gbTestAppointmentInfo.Panel.Controls.Add(this.lblUserMessage);
            this.gbTestAppointmentInfo.Panel.Controls.Add(this.gbRetakeTestInfo);
            this.gbTestAppointmentInfo.Panel.Controls.Add(this.pbTestType);
            this.gbTestAppointmentInfo.Panel.Controls.Add(this.lblTestType);
            this.gbTestAppointmentInfo.Panel.Controls.Add(this.dtpAppointmentDate);
            this.gbTestAppointmentInfo.Panel.Controls.Add(this.btnSave);
            this.gbTestAppointmentInfo.Panel.Controls.Add(this.lblPaidFees);
            this.gbTestAppointmentInfo.Panel.Controls.Add(this.kryptonLabel12);
            this.gbTestAppointmentInfo.Panel.Controls.Add(this.kryptonLabel10);
            this.gbTestAppointmentInfo.Panel.Controls.Add(this.lblTestTrials);
            this.gbTestAppointmentInfo.Panel.Controls.Add(this.kryptonLabel8);
            this.gbTestAppointmentInfo.Panel.Controls.Add(this.lblFullName);
            this.gbTestAppointmentInfo.Panel.Controls.Add(this.kryptonLabel6);
            this.gbTestAppointmentInfo.Panel.Controls.Add(this.lblClassType);
            this.gbTestAppointmentInfo.Panel.Controls.Add(this.kryptonLabel4);
            this.gbTestAppointmentInfo.Panel.Controls.Add(this.lblLDLApplicationID);
            this.gbTestAppointmentInfo.Panel.Controls.Add(this.kryptonLabel1);
            this.gbTestAppointmentInfo.Size = new System.Drawing.Size(350, 500);
            this.gbTestAppointmentInfo.TabIndex = 0;
            this.gbTestAppointmentInfo.Values.Heading = "Schedule Test";
            // 
            // gbRetakeTestInfo
            // 
            this.gbRetakeTestInfo.Enabled = false;
            this.gbRetakeTestInfo.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonStandalone;
            this.gbRetakeTestInfo.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ButtonStandalone;
            this.gbRetakeTestInfo.Location = new System.Drawing.Point(1, 317);
            this.gbRetakeTestInfo.Name = "gbRetakeTestInfo";
            this.gbRetakeTestInfo.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            // 
            // gbRetakeTestInfo.Panel
            // 
            this.gbRetakeTestInfo.Panel.Controls.Add(this.lblRetakeApplicationID);
            this.gbRetakeTestInfo.Panel.Controls.Add(this.kryptonLabel2);
            this.gbRetakeTestInfo.Panel.Controls.Add(this.lblTotalFees);
            this.gbRetakeTestInfo.Panel.Controls.Add(this.kryptonLabel3);
            this.gbRetakeTestInfo.Panel.Controls.Add(this.lblRetakeApplicationFees);
            this.gbRetakeTestInfo.Panel.Controls.Add(this.kryptonLabel5);
            this.gbRetakeTestInfo.Size = new System.Drawing.Size(346, 103);
            this.gbRetakeTestInfo.TabIndex = 16;
            this.gbRetakeTestInfo.Values.Heading = "Retake Test Info";
            // 
            // lblRetakeApplicationID
            // 
            this.lblRetakeApplicationID.Location = new System.Drawing.Point(146, 52);
            this.lblRetakeApplicationID.Name = "lblRetakeApplicationID";
            this.lblRetakeApplicationID.Size = new System.Drawing.Size(33, 20);
            this.lblRetakeApplicationID.TabIndex = 11;
            this.lblRetakeApplicationID.Values.Text = "N/A";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(5, 52);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(150, 20);
            this.kryptonLabel2.TabIndex = 10;
            this.kryptonLabel2.Values.Text = "RetakeTestApplicationID :";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.Location = new System.Drawing.Point(280, 15);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(17, 20);
            this.lblTotalFees.TabIndex = 9;
            this.lblTotalFees.Values.Text = "0";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(215, 15);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(71, 20);
            this.kryptonLabel3.TabIndex = 8;
            this.kryptonLabel3.Values.Text = "Total Fees :";
            // 
            // lblRetakeApplicationFees
            // 
            this.lblRetakeApplicationFees.Location = new System.Drawing.Point(146, 15);
            this.lblRetakeApplicationFees.Name = "lblRetakeApplicationFees";
            this.lblRetakeApplicationFees.Size = new System.Drawing.Size(17, 20);
            this.lblRetakeApplicationFees.TabIndex = 7;
            this.lblRetakeApplicationFees.Values.Text = "0";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(45, 15);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(106, 20);
            this.kryptonLabel5.TabIndex = 6;
            this.kryptonLabel5.Values.Text = "Application Fees :";
            // 
            // pbTestType
            // 
            this.pbTestType.Image = ((System.Drawing.Image)(resources.GetObject("pbTestType.Image")));
            this.pbTestType.Location = new System.Drawing.Point(28, 9);
            this.pbTestType.Name = "pbTestType";
            this.pbTestType.Size = new System.Drawing.Size(90, 79);
            this.pbTestType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestType.TabIndex = 14;
            this.pbTestType.TabStop = false;
            // 
            // lblTestType
            // 
            this.lblTestType.Location = new System.Drawing.Point(124, 28);
            this.lblTestType.Name = "lblTestType";
            this.lblTestType.Size = new System.Drawing.Size(157, 42);
            this.lblTestType.StateCommon.ShortText.Color1 = System.Drawing.Color.Firebrick;
            this.lblTestType.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Uighur", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestType.StateCommon.ShortText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.lblTestType.TabIndex = 15;
            this.lblTestType.Values.Text = "Schedule Test";
            // 
            // dtpAppointmentDate
            // 
            this.dtpAppointmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAppointmentDate.Location = new System.Drawing.Point(139, 256);
            this.dtpAppointmentDate.Name = "dtpAppointmentDate";
            this.dtpAppointmentDate.Size = new System.Drawing.Size(89, 21);
            this.dtpAppointmentDate.TabIndex = 13;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(246, 440);
            this.btnSave.Name = "btnSave";
            this.btnSave.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnSave.Size = new System.Drawing.Size(90, 25);
            this.btnSave.TabIndex = 12;
            this.btnSave.Values.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblPaidFees
            // 
            this.lblPaidFees.Location = new System.Drawing.Point(137, 291);
            this.lblPaidFees.Name = "lblPaidFees";
            this.lblPaidFees.Size = new System.Drawing.Size(17, 20);
            this.lblPaidFees.TabIndex = 11;
            this.lblPaidFees.Values.Text = "0";
            // 
            // kryptonLabel12
            // 
            this.kryptonLabel12.Location = new System.Drawing.Point(99, 291);
            this.kryptonLabel12.Name = "kryptonLabel12";
            this.kryptonLabel12.Size = new System.Drawing.Size(41, 20);
            this.kryptonLabel12.TabIndex = 10;
            this.kryptonLabel12.Values.Text = "Fees :";
            // 
            // kryptonLabel10
            // 
            this.kryptonLabel10.Location = new System.Drawing.Point(98, 257);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.Size = new System.Drawing.Size(42, 20);
            this.kryptonLabel10.TabIndex = 8;
            this.kryptonLabel10.Values.Text = "Date :";
            // 
            // lblTestTrials
            // 
            this.lblTestTrials.Location = new System.Drawing.Point(137, 223);
            this.lblTestTrials.Name = "lblTestTrials";
            this.lblTestTrials.Size = new System.Drawing.Size(17, 20);
            this.lblTestTrials.TabIndex = 7;
            this.lblTestTrials.Values.Text = "0";
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(95, 223);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(45, 20);
            this.kryptonLabel8.TabIndex = 6;
            this.kryptonLabel8.Values.Text = "Trials :";
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(137, 189);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(27, 20);
            this.lblFullName.TabIndex = 5;
            this.lblFullName.Values.Text = "???";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(68, 189);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(72, 20);
            this.kryptonLabel6.TabIndex = 4;
            this.kryptonLabel6.Values.Text = "Full Name :";
            // 
            // lblClassType
            // 
            this.lblClassType.Location = new System.Drawing.Point(137, 155);
            this.lblClassType.Name = "lblClassType";
            this.lblClassType.Size = new System.Drawing.Size(27, 20);
            this.lblClassType.TabIndex = 3;
            this.lblClassType.Values.Text = "???";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(53, 155);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(87, 20);
            this.kryptonLabel4.TabIndex = 2;
            this.kryptonLabel4.Values.Text = "License Class :";
            // 
            // lblLDLApplicationID
            // 
            this.lblLDLApplicationID.Location = new System.Drawing.Point(137, 121);
            this.lblLDLApplicationID.Name = "lblLDLApplicationID";
            this.lblLDLApplicationID.Size = new System.Drawing.Size(27, 20);
            this.lblLDLApplicationID.TabIndex = 1;
            this.lblLDLApplicationID.Values.Text = "???";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(29, 121);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(111, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "LDLApplicationID :";
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.AutoSize = false;
            this.lblUserMessage.Location = new System.Drawing.Point(3, 92);
            this.lblUserMessage.Name = "lblUserMessage";
            this.lblUserMessage.Size = new System.Drawing.Size(343, 25);
            this.lblUserMessage.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUserMessage.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUserMessage.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.lblUserMessage.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.lblUserMessage.TabIndex = 17;
            this.lblUserMessage.Values.Text = "_____________________________________________________________";
            this.lblUserMessage.Visible = false;
            // 
            // UCScheduleTest
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbTestAppointmentInfo);
            this.Name = "UCScheduleTest";
            this.Size = new System.Drawing.Size(350, 500);
            ((System.ComponentModel.ISupportInitialize)(this.gbTestAppointmentInfo.Panel)).EndInit();
            this.gbTestAppointmentInfo.Panel.ResumeLayout(false);
            this.gbTestAppointmentInfo.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbTestAppointmentInfo)).EndInit();
            this.gbTestAppointmentInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbRetakeTestInfo.Panel)).EndInit();
            this.gbRetakeTestInfo.Panel.ResumeLayout(false);
            this.gbRetakeTestInfo.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbRetakeTestInfo)).EndInit();
            this.gbRetakeTestInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblPaidFees;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel12;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel10;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTestTrials;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblFullName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblClassType;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblLDLApplicationID;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpAppointmentDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTestType;
        internal System.Windows.Forms.PictureBox pbTestType;
        internal ComponentFactory.Krypton.Toolkit.KryptonGroupBox gbTestAppointmentInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox gbRetakeTestInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblRetakeApplicationID;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTotalFees;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblRetakeApplicationFees;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblUserMessage;
    }
}
