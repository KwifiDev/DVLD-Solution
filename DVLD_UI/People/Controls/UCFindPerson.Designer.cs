namespace DVLD_UI.UserControls
{
    partial class UCFindPerson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCFindPerson));
            this.btnAddPerson = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.gbFindPerson = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.cbFindBy = new System.Windows.Forms.ComboBox();
            this.txtFindPerson = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblFindby = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnUserSearch = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ucPersonInfo1 = new DVLD_UI.UCPersonInfo();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gbFindPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbFindPerson.Panel)).BeginInit();
            this.gbFindPerson.Panel.SuspendLayout();
            this.gbFindPerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Location = new System.Drawing.Point(710, 76);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(66, 75);
            this.btnAddPerson.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            this.btnAddPerson.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnAddPerson.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnAddPerson.TabIndex = 25;
            this.btnAddPerson.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPerson.Values.Image")));
            this.btnAddPerson.Values.Text = "Add";
            this.btnAddPerson.Click += new System.EventHandler(this.BtnAddPerson_Click);
            // 
            // gbFindPerson
            // 
            this.gbFindPerson.CaptionOverlap = 0D;
            this.gbFindPerson.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ToolTip;
            this.gbFindPerson.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonStandalone;
            this.gbFindPerson.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.FormMain;
            this.gbFindPerson.Location = new System.Drawing.Point(4, 4);
            this.gbFindPerson.Name = "gbFindPerson";
            this.gbFindPerson.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            // 
            // gbFindPerson.Panel
            // 
            this.gbFindPerson.Panel.Controls.Add(this.cbFindBy);
            this.gbFindPerson.Panel.Controls.Add(this.txtFindPerson);
            this.gbFindPerson.Panel.Controls.Add(this.lblFindby);
            this.gbFindPerson.Size = new System.Drawing.Size(700, 56);
            this.gbFindPerson.StateCommon.Back.Color2 = System.Drawing.Color.AliceBlue;
            this.gbFindPerson.TabIndex = 23;
            this.gbFindPerson.Values.Heading = "Filter";
            // 
            // cbFindBy
            // 
            this.cbFindBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFindBy.FormattingEnabled = true;
            this.cbFindBy.Items.AddRange(new object[] {
            "PersonID",
            "NationalNo"});
            this.cbFindBy.Location = new System.Drawing.Point(64, 7);
            this.cbFindBy.Name = "cbFindBy";
            this.cbFindBy.Size = new System.Drawing.Size(186, 21);
            this.cbFindBy.TabIndex = 2;
            this.cbFindBy.SelectedIndexChanged += new System.EventHandler(this.CbFindBy_SelectedIndexChanged);
            // 
            // txtFindPerson
            // 
            this.txtFindPerson.Location = new System.Drawing.Point(256, 6);
            this.txtFindPerson.Name = "txtFindPerson";
            this.txtFindPerson.Size = new System.Drawing.Size(186, 23);
            this.txtFindPerson.TabIndex = 0;
            this.txtFindPerson.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFindPerson_KeyPress);
            this.txtFindPerson.Validating += new System.ComponentModel.CancelEventHandler(this.TxtFindPerson_Validating);
            // 
            // lblFindby
            // 
            this.lblFindby.Location = new System.Drawing.Point(4, 8);
            this.lblFindby.Name = "lblFindby";
            this.lblFindby.Size = new System.Drawing.Size(53, 20);
            this.lblFindby.TabIndex = 0;
            this.lblFindby.Values.Text = "Find By:";
            // 
            // btnUserSearch
            // 
            this.btnUserSearch.Location = new System.Drawing.Point(710, 4);
            this.btnUserSearch.Name = "btnUserSearch";
            this.btnUserSearch.Size = new System.Drawing.Size(66, 56);
            this.btnUserSearch.TabIndex = 21;
            this.btnUserSearch.Values.Image = ((System.Drawing.Image)(resources.GetObject("btnUserSearch.Values.Image")));
            this.btnUserSearch.Values.Text = "";
            this.btnUserSearch.Click += new System.EventHandler(this.BtnUserSearch_Click);
            // 
            // ucPersonInfo1
            // 
            this.ucPersonInfo1.Location = new System.Drawing.Point(4, 66);
            this.ucPersonInfo1.Name = "ucPersonInfo1";
            this.ucPersonInfo1.Size = new System.Drawing.Size(700, 200);
            this.ucPersonInfo1.TabIndex = 22;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // UCFindPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.gbFindPerson);
            this.Controls.Add(this.btnUserSearch);
            this.Controls.Add(this.ucPersonInfo1);
            this.Name = "UCFindPerson";
            this.Size = new System.Drawing.Size(781, 270);
            ((System.ComponentModel.ISupportInitialize)(this.gbFindPerson.Panel)).EndInit();
            this.gbFindPerson.Panel.ResumeLayout(false);
            this.gbFindPerson.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbFindPerson)).EndInit();
            this.gbFindPerson.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddPerson;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox gbFindPerson;
        private System.Windows.Forms.ComboBox cbFindBy;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtFindPerson;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblFindby;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnUserSearch;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private UCPersonInfo ucPersonInfo1;
    }
}
