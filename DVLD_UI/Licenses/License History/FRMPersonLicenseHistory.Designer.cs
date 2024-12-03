namespace DVLD_UI.Froms
{
    partial class FRMPersonLicenseHistory
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
            this.ucDriverLicenses1 = new DVLD_UI.UserControls.UCDriverLicenses();
            this.ucFindPerson1 = new DVLD_UI.UserControls.UCFindPerson();
            this.SuspendLayout();
            // 
            // ucDriverLicenses1
            // 
            this.ucDriverLicenses1.BackColor = System.Drawing.Color.White;
            this.ucDriverLicenses1.Location = new System.Drawing.Point(2, 280);
            this.ucDriverLicenses1.Name = "ucDriverLicenses1";
            this.ucDriverLicenses1.Size = new System.Drawing.Size(781, 270);
            this.ucDriverLicenses1.TabIndex = 1;
            // 
            // ucFindPerson1
            // 
            this.ucFindPerson1.Location = new System.Drawing.Point(2, 1);
            this.ucFindPerson1.Name = "ucFindPerson1";
            this.ucFindPerson1.Size = new System.Drawing.Size(781, 270);
            this.ucFindPerson1.TabIndex = 0;
            this.ucFindPerson1.OnPersonFound += new System.Action<bool>(this.UcFindPerson1_OnPersonFound);
            // 
            // FRMPersonLicenseHistory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 553);
            this.Controls.Add(this.ucDriverLicenses1);
            this.Controls.Add(this.ucFindPerson1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRMPersonLicenseHistory";
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
            this.Text = "Person License History";
            this.Load += new System.EventHandler(this.FRMPersonLicenseHistory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UCFindPerson ucFindPerson1;
        private UserControls.UCDriverLicenses ucDriverLicenses1;
    }
}