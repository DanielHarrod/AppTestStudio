namespace AppTestStudio
{
    partial class frmWindowWizard
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
            this.txtPrimaryWindowName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lst = new System.Windows.Forms.ListBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdUse = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblChoosenWindow = new System.Windows.Forms.Label();
            this.lstSecondaryWindow = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPrimaryWindowName = new System.Windows.Forms.Label();
            this.lblSecondaryWindowName = new System.Windows.Forms.Label();
            this.lblPrimaryWindowFilter = new System.Windows.Forms.Label();
            this.lblSecondaryWindowFilter = new System.Windows.Forms.Label();
            this.cboSteamSecondaryWindowNameFilter = new System.Windows.Forms.ComboBox();
            this.cboSteamPrimaryWindowNameFilter = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSecondaryWindowName = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSecondaryWindowsFound = new System.Windows.Forms.Label();
            this.lblTargetWindowName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.PanelScreenshot = new System.Windows.Forms.Panel();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.PanelScreenshot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPrimaryWindowName
            // 
            this.txtPrimaryWindowName.Location = new System.Drawing.Point(53, 46);
            this.txtPrimaryWindowName.Name = "txtPrimaryWindowName";
            this.txtPrimaryWindowName.Size = new System.Drawing.Size(135, 20);
            this.txtPrimaryWindowName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pattern";
            // 
            // lst
            // 
            this.lst.FormattingEnabled = true;
            this.lst.Location = new System.Drawing.Point(53, 101);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(216, 121);
            this.lst.TabIndex = 2;
            this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(53, 72);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(75, 23);
            this.cmdSearch.TabIndex = 3;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(60, 390);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdUse
            // 
            this.cmdUse.Location = new System.Drawing.Point(348, 421);
            this.cmdUse.Name = "cmdUse";
            this.cmdUse.Size = new System.Drawing.Size(75, 23);
            this.cmdUse.TabIndex = 5;
            this.cmdUse.Text = "Use";
            this.cmdUse.UseVisualStyleBackColor = true;
            this.cmdUse.Click += new System.EventHandler(this.cmdUse_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblChoosenWindow);
            this.groupBox1.Location = new System.Drawing.Point(204, 410);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 41);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Window Selected";
            // 
            // lblChoosenWindow
            // 
            this.lblChoosenWindow.AutoSize = true;
            this.lblChoosenWindow.Location = new System.Drawing.Point(17, 16);
            this.lblChoosenWindow.Name = "lblChoosenWindow";
            this.lblChoosenWindow.Size = new System.Drawing.Size(98, 13);
            this.lblChoosenWindow.TabIndex = 6;
            this.lblChoosenWindow.Text = "lblChoosenWindow";
            // 
            // lstSecondaryWindow
            // 
            this.lstSecondaryWindow.FormattingEnabled = true;
            this.lstSecondaryWindow.Location = new System.Drawing.Point(6, 19);
            this.lstSecondaryWindow.Name = "lstSecondaryWindow";
            this.lstSecondaryWindow.Size = new System.Drawing.Size(166, 95);
            this.lstSecondaryWindow.TabIndex = 2;
            this.lstSecondaryWindow.SelectedIndexChanged += new System.EventHandler(this.lstSecondaryWindow_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSecondaryWindowFilter);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblPrimaryWindowFilter);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblSecondaryWindowName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblPrimaryWindowName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(60, 271);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 94);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Original Values";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "PrimaryWindowName ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "SecondaryWindowName ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "PrimaryWindowFilter ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "SecondaryWindowFilter ";
            // 
            // lblPrimaryWindowName
            // 
            this.lblPrimaryWindowName.AutoSize = true;
            this.lblPrimaryWindowName.Location = new System.Drawing.Point(141, 20);
            this.lblPrimaryWindowName.Name = "lblPrimaryWindowName";
            this.lblPrimaryWindowName.Size = new System.Drawing.Size(111, 13);
            this.lblPrimaryWindowName.TabIndex = 0;
            this.lblPrimaryWindowName.Text = "PrimaryWindowName ";
            // 
            // lblSecondaryWindowName
            // 
            this.lblSecondaryWindowName.AutoSize = true;
            this.lblSecondaryWindowName.Location = new System.Drawing.Point(141, 39);
            this.lblSecondaryWindowName.Name = "lblSecondaryWindowName";
            this.lblSecondaryWindowName.Size = new System.Drawing.Size(128, 13);
            this.lblSecondaryWindowName.TabIndex = 0;
            this.lblSecondaryWindowName.Text = "SecondaryWindowName ";
            // 
            // lblPrimaryWindowFilter
            // 
            this.lblPrimaryWindowFilter.AutoSize = true;
            this.lblPrimaryWindowFilter.Location = new System.Drawing.Point(141, 58);
            this.lblPrimaryWindowFilter.Name = "lblPrimaryWindowFilter";
            this.lblPrimaryWindowFilter.Size = new System.Drawing.Size(105, 13);
            this.lblPrimaryWindowFilter.TabIndex = 0;
            this.lblPrimaryWindowFilter.Text = "PrimaryWindowFilter ";
            // 
            // lblSecondaryWindowFilter
            // 
            this.lblSecondaryWindowFilter.AutoSize = true;
            this.lblSecondaryWindowFilter.Location = new System.Drawing.Point(141, 77);
            this.lblSecondaryWindowFilter.Name = "lblSecondaryWindowFilter";
            this.lblSecondaryWindowFilter.Size = new System.Drawing.Size(122, 13);
            this.lblSecondaryWindowFilter.TabIndex = 0;
            this.lblSecondaryWindowFilter.Text = "SecondaryWindowFilter ";
            // 
            // cboSteamSecondaryWindowNameFilter
            // 
            this.cboSteamSecondaryWindowNameFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSteamSecondaryWindowNameFilter.FormattingEnabled = true;
            this.cboSteamSecondaryWindowNameFilter.Items.AddRange(new object[] {
            "Equals",
            "Starts With",
            "Contains"});
            this.cboSteamSecondaryWindowNameFilter.Location = new System.Drawing.Point(124, 16);
            this.cboSteamSecondaryWindowNameFilter.Name = "cboSteamSecondaryWindowNameFilter";
            this.cboSteamSecondaryWindowNameFilter.Size = new System.Drawing.Size(75, 21);
            this.cboSteamSecondaryWindowNameFilter.TabIndex = 13;
            // 
            // cboSteamPrimaryWindowNameFilter
            // 
            this.cboSteamPrimaryWindowNameFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSteamPrimaryWindowNameFilter.FormattingEnabled = true;
            this.cboSteamPrimaryWindowNameFilter.Items.AddRange(new object[] {
            "Equals",
            "Starts With",
            "Contains"});
            this.cboSteamPrimaryWindowNameFilter.Location = new System.Drawing.Point(53, 19);
            this.cboSteamPrimaryWindowNameFilter.Name = "cboSteamPrimaryWindowNameFilter";
            this.cboSteamPrimaryWindowNameFilter.Size = new System.Drawing.Size(135, 21);
            this.cboSteamPrimaryWindowNameFilter.TabIndex = 12;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.cboSteamPrimaryWindowNameFilter);
            this.groupBox3.Controls.Add(this.txtPrimaryWindowName);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.lst);
            this.groupBox3.Controls.Add(this.cmdSearch);
            this.groupBox3.Location = new System.Drawing.Point(60, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(464, 227);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Primary";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblTargetWindowName);
            this.groupBox4.Controls.Add(this.lblSecondaryWindowsFound);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.cboSteamSecondaryWindowNameFilter);
            this.groupBox4.Controls.Add(this.txtSecondaryWindowName);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(530, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(354, 224);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Secondary Search";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Filter";
            // 
            // txtSecondaryWindowName
            // 
            this.txtSecondaryWindowName.Location = new System.Drawing.Point(124, 43);
            this.txtSecondaryWindowName.Name = "txtSecondaryWindowName";
            this.txtSecondaryWindowName.Size = new System.Drawing.Size(135, 20);
            this.txtSecondaryWindowName.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lstSecondaryWindow);
            this.groupBox5.Location = new System.Drawing.Point(276, 98);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(178, 123);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Secondary Windows";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Windows Found";
            // 
            // lblSecondaryWindowsFound
            // 
            this.lblSecondaryWindowsFound.AutoSize = true;
            this.lblSecondaryWindowsFound.Location = new System.Drawing.Point(124, 78);
            this.lblSecondaryWindowsFound.Name = "lblSecondaryWindowsFound";
            this.lblSecondaryWindowsFound.Size = new System.Drawing.Size(142, 13);
            this.lblSecondaryWindowsFound.TabIndex = 15;
            this.lblSecondaryWindowsFound.Text = "lblSecondaryWindowsFound";
            // 
            // lblTargetWindowName
            // 
            this.lblTargetWindowName.AutoSize = true;
            this.lblTargetWindowName.Location = new System.Drawing.Point(124, 98);
            this.lblTargetWindowName.Name = "lblTargetWindowName";
            this.lblTargetWindowName.Size = new System.Drawing.Size(115, 13);
            this.lblTargetWindowName.TabIndex = 16;
            this.lblTargetWindowName.Text = "lblTargetWindowName";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Target Window Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Filter";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Pattern";
            // 
            // PanelScreenshot
            // 
            this.PanelScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelScreenshot.AutoScroll = true;
            this.PanelScreenshot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelScreenshot.Controls.Add(this.PictureBox1);
            this.PanelScreenshot.Location = new System.Drawing.Point(446, 242);
            this.PanelScreenshot.Name = "PanelScreenshot";
            this.PanelScreenshot.Size = new System.Drawing.Size(438, 238);
            this.PanelScreenshot.TabIndex = 16;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PictureBox1.Location = new System.Drawing.Point(0, 0);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(100, 50);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            // 
            // frmWindowWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 492);
            this.Controls.Add(this.PanelScreenshot);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdUse);
            this.Controls.Add(this.cmdCancel);
            this.Name = "frmWindowWizard";
            this.Text = "Window Wizard";
            this.Load += new System.EventHandler(this.frmWindowWizard_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.PanelScreenshot.ResumeLayout(false);
            this.PanelScreenshot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrimaryWindowName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lst;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdUse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblChoosenWindow;
        private System.Windows.Forms.ListBox lstSecondaryWindow;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSecondaryWindowFilter;
        private System.Windows.Forms.Label lblPrimaryWindowFilter;
        private System.Windows.Forms.Label lblSecondaryWindowName;
        private System.Windows.Forms.Label lblPrimaryWindowName;
        private System.Windows.Forms.ComboBox cboSteamSecondaryWindowNameFilter;
        private System.Windows.Forms.ComboBox cboSteamPrimaryWindowNameFilter;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblSecondaryWindowsFound;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSecondaryWindowName;
        private System.Windows.Forms.Label lblTargetWindowName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Panel PanelScreenshot;
        internal System.Windows.Forms.PictureBox PictureBox1;
    }
}