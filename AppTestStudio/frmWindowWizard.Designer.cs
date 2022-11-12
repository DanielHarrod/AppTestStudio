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
            this.lstPrimary = new System.Windows.Forms.ListBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdUse = new System.Windows.Forms.Button();
            this.lstSecondaryWindow = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSecondaryWindowFilter = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPrimaryWindowFilter = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSecondaryWindowName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPrimaryWindowName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSteamSecondaryWindowNameFilter = new System.Windows.Forms.ComboBox();
            this.cboSteamPrimaryWindowNameFilter = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPrimaryWindowsFound = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lstSecondary = new System.Windows.Forms.ListBox();
            this.cmdSecondarySearch = new System.Windows.Forms.Button();
            this.lblSecondaryWindowsFound = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSecondaryWindowName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PanelScreenshot = new System.Windows.Forms.Panel();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.lstWindowsFound = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmdRefreshList = new System.Windows.Forms.Button();
            this.cmdUseWindowFound = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cmdUseSecondaryWindowFound = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblChangeSecondaryWindowFilter = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblChangePrimaryWindowFilter = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblChangeSecondaryWindowName = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblChangePrimaryWindowName = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.PanelScreenshot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPrimaryWindowName
            // 
            this.txtPrimaryWindowName.Location = new System.Drawing.Point(89, 43);
            this.txtPrimaryWindowName.Name = "txtPrimaryWindowName";
            this.txtPrimaryWindowName.Size = new System.Drawing.Size(135, 20);
            this.txtPrimaryWindowName.TabIndex = 0;
            this.txtPrimaryWindowName.TextChanged += new System.EventHandler(this.txtPrimaryWindowName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pattern";
            // 
            // lstPrimary
            // 
            this.lstPrimary.FormattingEnabled = true;
            this.lstPrimary.Location = new System.Drawing.Point(89, 98);
            this.lstPrimary.Name = "lstPrimary";
            this.lstPrimary.Size = new System.Drawing.Size(194, 121);
            this.lstPrimary.TabIndex = 2;
            this.lstPrimary.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(89, 69);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(75, 23);
            this.cmdSearch.TabIndex = 3;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(13, 94);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(259, 23);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdUse
            // 
            this.cmdUse.Location = new System.Drawing.Point(6, 94);
            this.cmdUse.Name = "cmdUse";
            this.cmdUse.Size = new System.Drawing.Size(263, 23);
            this.cmdUse.TabIndex = 5;
            this.cmdUse.Text = "Use";
            this.cmdUse.UseVisualStyleBackColor = true;
            this.cmdUse.Click += new System.EventHandler(this.cmdUse_Click);
            // 
            // lstSecondaryWindow
            // 
            this.lstSecondaryWindow.FormattingEnabled = true;
            this.lstSecondaryWindow.Location = new System.Drawing.Point(610, 26);
            this.lstSecondaryWindow.Name = "lstSecondaryWindow";
            this.lstSecondaryWindow.Size = new System.Drawing.Size(194, 225);
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
            this.groupBox2.Controls.Add(this.cmdCancel);
            this.groupBox2.Location = new System.Drawing.Point(12, 370);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 123);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Original Values";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "SecondaryWindowFilter ";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "PrimaryWindowFilter ";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "SecondaryWindowName ";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "PrimaryWindowName ";
            // 
            // cboSteamSecondaryWindowNameFilter
            // 
            this.cboSteamSecondaryWindowNameFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSteamSecondaryWindowNameFilter.FormattingEnabled = true;
            this.cboSteamSecondaryWindowNameFilter.Items.AddRange(new object[] {
            "Equals",
            "Starts With",
            "Contains"});
            this.cboSteamSecondaryWindowNameFilter.Location = new System.Drawing.Point(89, 19);
            this.cboSteamSecondaryWindowNameFilter.Name = "cboSteamSecondaryWindowNameFilter";
            this.cboSteamSecondaryWindowNameFilter.Size = new System.Drawing.Size(75, 21);
            this.cboSteamSecondaryWindowNameFilter.TabIndex = 13;
            this.cboSteamSecondaryWindowNameFilter.SelectedIndexChanged += new System.EventHandler(this.cboSteamSecondaryWindowNameFilter_SelectedIndexChanged);
            // 
            // cboSteamPrimaryWindowNameFilter
            // 
            this.cboSteamPrimaryWindowNameFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSteamPrimaryWindowNameFilter.FormattingEnabled = true;
            this.cboSteamPrimaryWindowNameFilter.Items.AddRange(new object[] {
            "Equals",
            "Starts With",
            "Contains"});
            this.cboSteamPrimaryWindowNameFilter.Location = new System.Drawing.Point(89, 16);
            this.cboSteamPrimaryWindowNameFilter.Name = "cboSteamPrimaryWindowNameFilter";
            this.cboSteamPrimaryWindowNameFilter.Size = new System.Drawing.Size(135, 21);
            this.cboSteamPrimaryWindowNameFilter.TabIndex = 12;
            this.cboSteamPrimaryWindowNameFilter.SelectedIndexChanged += new System.EventHandler(this.cboSteamPrimaryWindowNameFilter_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboSteamPrimaryWindowNameFilter);
            this.groupBox3.Controls.Add(this.txtPrimaryWindowName);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lblPrimaryWindowsFound);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.lstPrimary);
            this.groupBox3.Controls.Add(this.cmdSearch);
            this.groupBox3.Location = new System.Drawing.Point(308, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(293, 249);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Primary";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Filter";
            // 
            // lblPrimaryWindowsFound
            // 
            this.lblPrimaryWindowsFound.AutoSize = true;
            this.lblPrimaryWindowsFound.Location = new System.Drawing.Point(89, 225);
            this.lblPrimaryWindowsFound.Name = "lblPrimaryWindowsFound";
            this.lblPrimaryWindowsFound.Size = new System.Drawing.Size(125, 13);
            this.lblPrimaryWindowsFound.TabIndex = 15;
            this.lblPrimaryWindowsFound.Text = "lblPrimaryWindowsFound";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 225);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Windows Found";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lstSecondary);
            this.groupBox4.Controls.Add(this.cmdSecondarySearch);
            this.groupBox4.Controls.Add(this.lblSecondaryWindowsFound);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.cboSteamSecondaryWindowNameFilter);
            this.groupBox4.Controls.Add(this.txtSecondaryWindowName);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(847, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(315, 249);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Secondary Search";
            // 
            // lstSecondary
            // 
            this.lstSecondary.FormattingEnabled = true;
            this.lstSecondary.Location = new System.Drawing.Point(89, 98);
            this.lstSecondary.Name = "lstSecondary";
            this.lstSecondary.Size = new System.Drawing.Size(216, 121);
            this.lstSecondary.TabIndex = 17;
            // 
            // cmdSecondarySearch
            // 
            this.cmdSecondarySearch.Location = new System.Drawing.Point(89, 69);
            this.cmdSecondarySearch.Name = "cmdSecondarySearch";
            this.cmdSecondarySearch.Size = new System.Drawing.Size(75, 23);
            this.cmdSecondarySearch.TabIndex = 18;
            this.cmdSecondarySearch.Text = "Search";
            this.cmdSecondarySearch.UseVisualStyleBackColor = true;
            this.cmdSecondarySearch.Click += new System.EventHandler(this.cmdSecondarySearch_Click);
            // 
            // lblSecondaryWindowsFound
            // 
            this.lblSecondaryWindowsFound.AutoSize = true;
            this.lblSecondaryWindowsFound.Location = new System.Drawing.Point(89, 222);
            this.lblSecondaryWindowsFound.Name = "lblSecondaryWindowsFound";
            this.lblSecondaryWindowsFound.Size = new System.Drawing.Size(142, 13);
            this.lblSecondaryWindowsFound.TabIndex = 15;
            this.lblSecondaryWindowsFound.Text = "lblSecondaryWindowsFound";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Windows Found";
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
            // txtSecondaryWindowName
            // 
            this.txtSecondaryWindowName.Location = new System.Drawing.Point(89, 43);
            this.txtSecondaryWindowName.Name = "txtSecondaryWindowName";
            this.txtSecondaryWindowName.Size = new System.Drawing.Size(135, 20);
            this.txtSecondaryWindowName.TabIndex = 0;
            this.txtSecondaryWindowName.TextChanged += new System.EventHandler(this.txtSecondaryWindowName_TextChanged);
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
            // PanelScreenshot
            // 
            this.PanelScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelScreenshot.AutoScroll = true;
            this.PanelScreenshot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelScreenshot.Controls.Add(this.PictureBox1);
            this.PanelScreenshot.Location = new System.Drawing.Point(10, 19);
            this.PanelScreenshot.Name = "PanelScreenshot";
            this.PanelScreenshot.Size = new System.Drawing.Size(335, 170);
            this.PanelScreenshot.TabIndex = 16;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBox1.Location = new System.Drawing.Point(0, 0);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(335, 170);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            // 
            // lstWindowsFound
            // 
            this.lstWindowsFound.FormattingEnabled = true;
            this.lstWindowsFound.Location = new System.Drawing.Point(12, 23);
            this.lstWindowsFound.Name = "lstWindowsFound";
            this.lstWindowsFound.Size = new System.Drawing.Size(253, 238);
            this.lstWindowsFound.TabIndex = 17;
            this.lstWindowsFound.SelectedIndexChanged += new System.EventHandler(this.lstWindowsFound_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Windows Found";
            // 
            // cmdRefreshList
            // 
            this.cmdRefreshList.Location = new System.Drawing.Point(190, 2);
            this.cmdRefreshList.Name = "cmdRefreshList";
            this.cmdRefreshList.Size = new System.Drawing.Size(75, 23);
            this.cmdRefreshList.TabIndex = 19;
            this.cmdRefreshList.Text = "Refresh List";
            this.cmdRefreshList.UseVisualStyleBackColor = true;
            this.cmdRefreshList.Click += new System.EventHandler(this.cmdRefreshList_Click);
            // 
            // cmdUseWindowFound
            // 
            this.cmdUseWindowFound.Enabled = false;
            this.cmdUseWindowFound.Location = new System.Drawing.Point(271, 19);
            this.cmdUseWindowFound.Name = "cmdUseWindowFound";
            this.cmdUseWindowFound.Size = new System.Drawing.Size(31, 23);
            this.cmdUseWindowFound.TabIndex = 20;
            this.cmdUseWindowFound.Text = ">>";
            this.cmdUseWindowFound.UseVisualStyleBackColor = true;
            this.cmdUseWindowFound.Click += new System.EventHandler(this.cmdUseWindowFound_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(607, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Secondary Windows";
            // 
            // cmdUseSecondaryWindowFound
            // 
            this.cmdUseSecondaryWindowFound.Enabled = false;
            this.cmdUseSecondaryWindowFound.Location = new System.Drawing.Point(810, 21);
            this.cmdUseSecondaryWindowFound.Name = "cmdUseSecondaryWindowFound";
            this.cmdUseSecondaryWindowFound.Size = new System.Drawing.Size(31, 23);
            this.cmdUseSecondaryWindowFound.TabIndex = 20;
            this.cmdUseSecondaryWindowFound.Text = ">>";
            this.cmdUseSecondaryWindowFound.UseVisualStyleBackColor = true;
            this.cmdUseSecondaryWindowFound.Click += new System.EventHandler(this.cmdUseSecondaryWindowFound_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.PanelScreenshot);
            this.groupBox5.Location = new System.Drawing.Point(810, 305);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(351, 195);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Window Preview";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblChangeSecondaryWindowFilter);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lblChangePrimaryWindowFilter);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.lblChangeSecondaryWindowName);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.lblChangePrimaryWindowName);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.cmdUse);
            this.groupBox1.Location = new System.Drawing.Point(296, 370);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 129);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Changes";
            // 
            // lblChangeSecondaryWindowFilter
            // 
            this.lblChangeSecondaryWindowFilter.AutoSize = true;
            this.lblChangeSecondaryWindowFilter.Location = new System.Drawing.Point(141, 77);
            this.lblChangeSecondaryWindowFilter.Name = "lblChangeSecondaryWindowFilter";
            this.lblChangeSecondaryWindowFilter.Size = new System.Drawing.Size(122, 13);
            this.lblChangeSecondaryWindowFilter.TabIndex = 0;
            this.lblChangeSecondaryWindowFilter.Text = "SecondaryWindowFilter ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 77);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(122, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "SecondaryWindowFilter ";
            // 
            // lblChangePrimaryWindowFilter
            // 
            this.lblChangePrimaryWindowFilter.AutoSize = true;
            this.lblChangePrimaryWindowFilter.Location = new System.Drawing.Point(141, 58);
            this.lblChangePrimaryWindowFilter.Name = "lblChangePrimaryWindowFilter";
            this.lblChangePrimaryWindowFilter.Size = new System.Drawing.Size(105, 13);
            this.lblChangePrimaryWindowFilter.TabIndex = 0;
            this.lblChangePrimaryWindowFilter.Text = "PrimaryWindowFilter ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 58);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(105, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "PrimaryWindowFilter ";
            // 
            // lblChangeSecondaryWindowName
            // 
            this.lblChangeSecondaryWindowName.AutoSize = true;
            this.lblChangeSecondaryWindowName.Location = new System.Drawing.Point(141, 39);
            this.lblChangeSecondaryWindowName.Name = "lblChangeSecondaryWindowName";
            this.lblChangeSecondaryWindowName.Size = new System.Drawing.Size(128, 13);
            this.lblChangeSecondaryWindowName.TabIndex = 0;
            this.lblChangeSecondaryWindowName.Text = "SecondaryWindowName ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 39);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(128, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "SecondaryWindowName ";
            // 
            // lblChangePrimaryWindowName
            // 
            this.lblChangePrimaryWindowName.AutoSize = true;
            this.lblChangePrimaryWindowName.Location = new System.Drawing.Point(141, 20);
            this.lblChangePrimaryWindowName.Name = "lblChangePrimaryWindowName";
            this.lblChangePrimaryWindowName.Size = new System.Drawing.Size(111, 13);
            this.lblChangePrimaryWindowName.TabIndex = 0;
            this.lblChangePrimaryWindowName.Text = "PrimaryWindowName ";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(7, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(111, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "PrimaryWindowName ";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(317, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(284, 40);
            this.label8.TabIndex = 22;
            this.label8.Text = "1.) Use the filter and pattern to identify a single window, use search button to " +
    "test your work.";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(844, 259);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(284, 43);
            this.label15.TabIndex = 22;
            this.label15.Text = "2.) Use the filter and pattern to identify a single window, use search button to " +
    "test your work.  If Secondary windows.";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(302, 324);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(272, 43);
            this.label17.TabIndex = 23;
            this.label17.Text = "3.) Use Primary and Secondary Filter/Patterns to identify a single window and/or " +
    "single sub window, press the use button to set the values in your project.";
            // 
            // frmWindowWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 511);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.lstSecondaryWindow);
            this.Controls.Add(this.cmdUseSecondaryWindowFound);
            this.Controls.Add(this.cmdUseWindowFound);
            this.Controls.Add(this.cmdRefreshList);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lstWindowsFound);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmWindowWizard";
            this.Text = "Window Wizard";
            this.Load += new System.EventHandler(this.frmWindowWizard_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.PanelScreenshot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrimaryWindowName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstPrimary;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdUse;
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
        private System.Windows.Forms.Label lblSecondaryWindowsFound;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSecondaryWindowName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Panel PanelScreenshot;
        internal System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.ListBox lstWindowsFound;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button cmdRefreshList;
        private System.Windows.Forms.Button cmdUseWindowFound;
        private System.Windows.Forms.ListBox lstSecondary;
        private System.Windows.Forms.Button cmdSecondarySearch;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button cmdUseSecondaryWindowFound;
        private System.Windows.Forms.Label lblPrimaryWindowsFound;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.Label lblChangeSecondaryWindowFilter;
        public System.Windows.Forms.Label lblChangePrimaryWindowFilter;
        public System.Windows.Forms.Label lblChangeSecondaryWindowName;
        public System.Windows.Forms.Label lblChangePrimaryWindowName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
    }
}