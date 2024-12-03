namespace DVLD_UI.Froms
{
    partial class FRMTakeTest
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
            this.ucScheduleTestInfo1 = new DVLD_UI.UserControls.UCScheduleTestInfo();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.rbPassTest = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbFailTest = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtTestNotes = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblUserMassage = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.SuspendLayout();
            // 
            // ucScheduleTestInfo1
            // 
            this.ucScheduleTestInfo1.BackColor = System.Drawing.Color.White;
            this.ucScheduleTestInfo1.Location = new System.Drawing.Point(12, 0);
            this.ucScheduleTestInfo1.Name = "ucScheduleTestInfo1";
            this.ucScheduleTestInfo1.Size = new System.Drawing.Size(350, 377);
            this.ucScheduleTestInfo1.TabIndex = 0;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(24, 382);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(50, 20);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Result :";
            // 
            // rbPassTest
            // 
            this.rbPassTest.Checked = true;
            this.rbPassTest.Location = new System.Drawing.Point(71, 382);
            this.rbPassTest.Name = "rbPassTest";
            this.rbPassTest.Size = new System.Drawing.Size(46, 20);
            this.rbPassTest.TabIndex = 2;
            this.rbPassTest.Values.Text = "Pass";
            // 
            // rbFailTest
            // 
            this.rbFailTest.Location = new System.Drawing.Point(123, 382);
            this.rbFailTest.Name = "rbFailTest";
            this.rbFailTest.Size = new System.Drawing.Size(41, 20);
            this.rbFailTest.TabIndex = 3;
            this.rbFailTest.Values.Text = "Fail";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(24, 408);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(49, 20);
            this.kryptonLabel2.TabIndex = 4;
            this.kryptonLabel2.Values.Text = "Notes :";
            // 
            // txtTestNotes
            // 
            this.txtTestNotes.Location = new System.Drawing.Point(71, 407);
            this.txtTestNotes.Multiline = true;
            this.txtTestNotes.Name = "txtTestNotes";
            this.txtTestNotes.Size = new System.Drawing.Size(291, 42);
            this.txtTestNotes.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(272, 465);
            this.btnSave.Name = "btnSave";
            this.btnSave.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnSave.Size = new System.Drawing.Size(90, 25);
            this.btnSave.TabIndex = 6;
            this.btnSave.Values.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblUserMassage
            // 
            this.lblUserMassage.Location = new System.Drawing.Point(256, 382);
            this.lblUserMassage.Name = "lblUserMassage";
            this.lblUserMassage.Size = new System.Drawing.Size(106, 16);
            this.lblUserMassage.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUserMassage.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserMassage.TabIndex = 7;
            this.lblUserMassage.Values.Text = "This Test Is Taken";
            this.lblUserMassage.Visible = false;
            // 
            // FRMTakeTest
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 491);
            this.Controls.Add(this.lblUserMassage);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtTestNotes);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.rbFailTest);
            this.Controls.Add(this.rbPassTest);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.ucScheduleTestInfo1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRMTakeTest";
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
            this.Text = "Take Test";
            this.Load += new System.EventHandler(this.FRMTakeTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.UCScheduleTestInfo ucScheduleTestInfo1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbPassTest;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbFailTest;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTestNotes;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblUserMassage;
    }
}