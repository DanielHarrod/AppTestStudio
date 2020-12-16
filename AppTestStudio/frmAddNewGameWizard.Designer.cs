namespace AppTestStudio
{
    partial class frmAddNewGameWizard
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
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainerMainVertical = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanelLeftNav = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxNaming = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBoxPlatform = new System.Windows.Forms.PictureBox();
            this.pictureBoxStart = new System.Windows.Forms.PictureBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.pictureBoxPicker = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tableLayoutPanelRightSide = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdWizardCancel = new System.Windows.Forms.Button();
            this.cmdFinish = new System.Windows.Forms.Button();
            this.cmdNext = new System.Windows.Forms.Button();
            this.cmdPrevious = new System.Windows.Forms.Button();
            this.cmdStartOver = new System.Windows.Forms.Button();
            this.panelWorkspace = new System.Windows.Forms.Panel();
            this.panelWorkspaceNaming = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.txtFinishAppID = new System.Windows.Forms.TextBox();
            this.lblFinishAppID = new System.Windows.Forms.Label();
            this.lblSelectedPlatform = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblNameIsInvalid = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panelWorkspacePicker = new System.Windows.Forms.Panel();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label10 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmdHome = new System.Windows.Forms.Button();
            this.cmdBack = new System.Windows.Forms.Button();
            this.cmdForward = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.lblSafeName = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblAppID = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panelWorkspacePlatform = new System.Windows.Forms.Panel();
            this.groupBoxAutomationConsiderations = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblAppInstallation = new System.Windows.Forms.Label();
            this.lblDPIControl = new System.Windows.Forms.Label();
            this.lblSizeControl = new System.Windows.Forms.Label();
            this.cboPlatform = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelWorkspaceStart = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblDetectable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainVertical)).BeginInit();
            this.splitContainerMainVertical.Panel1.SuspendLayout();
            this.splitContainerMainVertical.Panel2.SuspendLayout();
            this.splitContainerMainVertical.SuspendLayout();
            this.tableLayoutPanelLeftNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNaming)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlatform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPicker)).BeginInit();
            this.tableLayoutPanelRightSide.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelWorkspace.SuspendLayout();
            this.panelWorkspaceNaming.SuspendLayout();
            this.panelWorkspacePicker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.panelWorkspacePlatform.SuspendLayout();
            this.groupBoxAutomationConsiderations.SuspendLayout();
            this.panelWorkspaceStart.SuspendLayout();
            this.SuspendLayout();
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Tick += new System.EventHandler(this.tmrWaitForBrowserInitialization_Tick);
            // 
            // splitContainerMainVertical
            // 
            this.splitContainerMainVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMainVertical.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMainVertical.Name = "splitContainerMainVertical";
            // 
            // splitContainerMainVertical.Panel1
            // 
            this.splitContainerMainVertical.Panel1.Controls.Add(this.tableLayoutPanelLeftNav);
            // 
            // splitContainerMainVertical.Panel2
            // 
            this.splitContainerMainVertical.Panel2.Controls.Add(this.tableLayoutPanelRightSide);
            this.splitContainerMainVertical.Size = new System.Drawing.Size(1563, 1078);
            this.splitContainerMainVertical.SplitterDistance = 174;
            this.splitContainerMainVertical.TabIndex = 2;
            // 
            // tableLayoutPanelLeftNav
            // 
            this.tableLayoutPanelLeftNav.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanelLeftNav.ColumnCount = 2;
            this.tableLayoutPanelLeftNav.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelLeftNav.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeftNav.Controls.Add(this.pictureBoxNaming, 0, 3);
            this.tableLayoutPanelLeftNav.Controls.Add(this.label7, 1, 1);
            this.tableLayoutPanelLeftNav.Controls.Add(this.pictureBoxPlatform, 0, 1);
            this.tableLayoutPanelLeftNav.Controls.Add(this.pictureBoxStart, 0, 0);
            this.tableLayoutPanelLeftNav.Controls.Add(this.lblStart, 1, 0);
            this.tableLayoutPanelLeftNav.Controls.Add(this.pictureBoxPicker, 0, 2);
            this.tableLayoutPanelLeftNav.Controls.Add(this.label8, 1, 2);
            this.tableLayoutPanelLeftNav.Controls.Add(this.label9, 1, 3);
            this.tableLayoutPanelLeftNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLeftNav.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelLeftNav.Name = "tableLayoutPanelLeftNav";
            this.tableLayoutPanelLeftNav.RowCount = 5;
            this.tableLayoutPanelLeftNav.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelLeftNav.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelLeftNav.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelLeftNav.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelLeftNav.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeftNav.Size = new System.Drawing.Size(174, 1078);
            this.tableLayoutPanelLeftNav.TabIndex = 0;
            // 
            // pictureBoxNaming
            // 
            this.pictureBoxNaming.Image = global::AppTestStudio.Properties.Resources.Next_16x;
            this.pictureBoxNaming.InitialImage = global::AppTestStudio.Properties.Resources.Next_16x;
            this.pictureBoxNaming.Location = new System.Drawing.Point(3, 123);
            this.pictureBoxNaming.Name = "pictureBoxNaming";
            this.pictureBoxNaming.Size = new System.Drawing.Size(34, 34);
            this.pictureBoxNaming.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxNaming.TabIndex = 5;
            this.pictureBoxNaming.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(43, 43);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 29);
            this.label7.TabIndex = 3;
            this.label7.Text = "Platform";
            // 
            // pictureBoxPlatform
            // 
            this.pictureBoxPlatform.Image = global::AppTestStudio.Properties.Resources.Next_16x;
            this.pictureBoxPlatform.InitialImage = global::AppTestStudio.Properties.Resources.Next_16x;
            this.pictureBoxPlatform.Location = new System.Drawing.Point(3, 43);
            this.pictureBoxPlatform.Name = "pictureBoxPlatform";
            this.pictureBoxPlatform.Size = new System.Drawing.Size(34, 34);
            this.pictureBoxPlatform.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPlatform.TabIndex = 2;
            this.pictureBoxPlatform.TabStop = false;
            // 
            // pictureBoxStart
            // 
            this.pictureBoxStart.Image = global::AppTestStudio.Properties.Resources.Next_16x;
            this.pictureBoxStart.InitialImage = global::AppTestStudio.Properties.Resources.Next_16x;
            this.pictureBoxStart.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxStart.Name = "pictureBoxStart";
            this.pictureBoxStart.Size = new System.Drawing.Size(34, 34);
            this.pictureBoxStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxStart.TabIndex = 0;
            this.pictureBoxStart.TabStop = false;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.Location = new System.Drawing.Point(43, 3);
            this.lblStart.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(67, 29);
            this.lblStart.TabIndex = 1;
            this.lblStart.Text = "Start";
            // 
            // pictureBoxPicker
            // 
            this.pictureBoxPicker.Image = global::AppTestStudio.Properties.Resources.Next_16x;
            this.pictureBoxPicker.InitialImage = global::AppTestStudio.Properties.Resources.Next_16x;
            this.pictureBoxPicker.Location = new System.Drawing.Point(3, 83);
            this.pictureBoxPicker.Name = "pictureBoxPicker";
            this.pictureBoxPicker.Size = new System.Drawing.Size(34, 34);
            this.pictureBoxPicker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPicker.TabIndex = 4;
            this.pictureBoxPicker.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(43, 83);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 29);
            this.label8.TabIndex = 6;
            this.label8.Text = "Picker";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(43, 123);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 29);
            this.label9.TabIndex = 7;
            this.label9.Text = "Naming";
            // 
            // tableLayoutPanelRightSide
            // 
            this.tableLayoutPanelRightSide.ColumnCount = 1;
            this.tableLayoutPanelRightSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRightSide.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanelRightSide.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanelRightSide.Controls.Add(this.panelWorkspace, 0, 1);
            this.tableLayoutPanelRightSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRightSide.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelRightSide.Name = "tableLayoutPanelRightSide";
            this.tableLayoutPanelRightSide.RowCount = 3;
            this.tableLayoutPanelRightSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanelRightSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRightSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelRightSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelRightSide.Size = new System.Drawing.Size(1385, 1078);
            this.tableLayoutPanelRightSide.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lblSubTitle);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1379, 94);
            this.panel1.TabIndex = 0;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitle.Location = new System.Drawing.Point(19, 52);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(151, 32);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "lblSubTitle";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(19, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(135, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "lblTitle";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.cmdWizardCancel);
            this.panel2.Controls.Add(this.cmdFinish);
            this.panel2.Controls.Add(this.cmdNext);
            this.panel2.Controls.Add(this.cmdPrevious);
            this.panel2.Controls.Add(this.cmdStartOver);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 1021);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1379, 54);
            this.panel2.TabIndex = 1;
            // 
            // cmdWizardCancel
            // 
            this.cmdWizardCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdWizardCancel.Location = new System.Drawing.Point(1295, 11);
            this.cmdWizardCancel.Name = "cmdWizardCancel";
            this.cmdWizardCancel.Size = new System.Drawing.Size(75, 30);
            this.cmdWizardCancel.TabIndex = 1;
            this.cmdWizardCancel.Text = "Cancel";
            this.cmdWizardCancel.UseVisualStyleBackColor = true;
            this.cmdWizardCancel.Click += new System.EventHandler(this.cmdWizardCancel_Click);
            // 
            // cmdFinish
            // 
            this.cmdFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdFinish.Location = new System.Drawing.Point(1213, 11);
            this.cmdFinish.Name = "cmdFinish";
            this.cmdFinish.Size = new System.Drawing.Size(75, 30);
            this.cmdFinish.TabIndex = 1;
            this.cmdFinish.Text = "Finish";
            this.cmdFinish.UseVisualStyleBackColor = true;
            this.cmdFinish.Click += new System.EventHandler(this.cmdFinish_Click);
            // 
            // cmdNext
            // 
            this.cmdNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNext.Location = new System.Drawing.Point(1131, 11);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(75, 30);
            this.cmdNext.TabIndex = 1;
            this.cmdNext.Text = "Next >";
            this.cmdNext.UseVisualStyleBackColor = true;
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // cmdPrevious
            // 
            this.cmdPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPrevious.Location = new System.Drawing.Point(1049, 11);
            this.cmdPrevious.Name = "cmdPrevious";
            this.cmdPrevious.Size = new System.Drawing.Size(75, 30);
            this.cmdPrevious.TabIndex = 1;
            this.cmdPrevious.Text = "< Prev";
            this.cmdPrevious.UseVisualStyleBackColor = true;
            this.cmdPrevious.Click += new System.EventHandler(this.cmdPrevious_Click);
            // 
            // cmdStartOver
            // 
            this.cmdStartOver.Location = new System.Drawing.Point(14, 11);
            this.cmdStartOver.Name = "cmdStartOver";
            this.cmdStartOver.Size = new System.Drawing.Size(126, 30);
            this.cmdStartOver.TabIndex = 0;
            this.cmdStartOver.Text = "<< Start Over";
            this.cmdStartOver.UseVisualStyleBackColor = true;
            this.cmdStartOver.Click += new System.EventHandler(this.cmdStartOver_Click);
            // 
            // panelWorkspace
            // 
            this.panelWorkspace.Controls.Add(this.panelWorkspacePlatform);
            this.panelWorkspace.Controls.Add(this.panelWorkspaceNaming);
            this.panelWorkspace.Controls.Add(this.panelWorkspacePicker);
            this.panelWorkspace.Controls.Add(this.panelWorkspaceStart);
            this.panelWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorkspace.Location = new System.Drawing.Point(3, 103);
            this.panelWorkspace.Name = "panelWorkspace";
            this.panelWorkspace.Size = new System.Drawing.Size(1379, 912);
            this.panelWorkspace.TabIndex = 2;
            // 
            // panelWorkspaceNaming
            // 
            this.panelWorkspaceNaming.Controls.Add(this.label19);
            this.panelWorkspaceNaming.Controls.Add(this.txtFinishAppID);
            this.panelWorkspaceNaming.Controls.Add(this.lblFinishAppID);
            this.panelWorkspaceNaming.Controls.Add(this.lblSelectedPlatform);
            this.panelWorkspaceNaming.Controls.Add(this.label18);
            this.panelWorkspaceNaming.Controls.Add(this.label17);
            this.panelWorkspaceNaming.Controls.Add(this.label13);
            this.panelWorkspaceNaming.Controls.Add(this.lblNameIsInvalid);
            this.panelWorkspaceNaming.Controls.Add(this.txtName);
            this.panelWorkspaceNaming.Controls.Add(this.label11);
            this.panelWorkspaceNaming.Location = new System.Drawing.Point(52, 546);
            this.panelWorkspaceNaming.Name = "panelWorkspaceNaming";
            this.panelWorkspaceNaming.Size = new System.Drawing.Size(1125, 324);
            this.panelWorkspaceNaming.TabIndex = 5;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(699, 161);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(261, 20);
            this.label19.TabIndex = 14;
            this.label19.Text = "Press the Finish button when ready.";
            // 
            // txtFinishAppID
            // 
            this.txtFinishAppID.Location = new System.Drawing.Point(165, 125);
            this.txtFinishAppID.Name = "txtFinishAppID";
            this.txtFinishAppID.Size = new System.Drawing.Size(524, 26);
            this.txtFinishAppID.TabIndex = 13;
            // 
            // lblFinishAppID
            // 
            this.lblFinishAppID.AutoSize = true;
            this.lblFinishAppID.Location = new System.Drawing.Point(24, 125);
            this.lblFinishAppID.Name = "lblFinishAppID";
            this.lblFinishAppID.Size = new System.Drawing.Size(55, 20);
            this.lblFinishAppID.TabIndex = 12;
            this.lblFinishAppID.Text = "AppID";
            // 
            // lblSelectedPlatform
            // 
            this.lblSelectedPlatform.AutoSize = true;
            this.lblSelectedPlatform.Location = new System.Drawing.Point(161, 39);
            this.lblSelectedPlatform.Name = "lblSelectedPlatform";
            this.lblSelectedPlatform.Size = new System.Drawing.Size(146, 20);
            this.lblSelectedPlatform.TabIndex = 11;
            this.lblSelectedPlatform.Text = "lblSelectedPlatform";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 39);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(135, 20);
            this.label18.TabIndex = 10;
            this.label18.Text = "Selected Platform";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(698, 70);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(384, 101);
            this.label17.TabIndex = 9;
            this.label17.Text = "Setting the project and folder name, names need to have characters that can be us" +
    "ed in folder names.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 20);
            this.label13.TabIndex = 8;
            this.label13.Text = "Project Name";
            // 
            // lblNameIsInvalid
            // 
            this.lblNameIsInvalid.AutoSize = true;
            this.lblNameIsInvalid.Location = new System.Drawing.Point(161, 98);
            this.lblNameIsInvalid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNameIsInvalid.Name = "lblNameIsInvalid";
            this.lblNameIsInvalid.Size = new System.Drawing.Size(211, 20);
            this.lblNameIsInvalid.TabIndex = 7;
            this.lblNameIsInvalid.Text = "Name has invalid characters ";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(165, 67);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(524, 26);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 32);
            this.label11.TabIndex = 0;
            this.label11.Text = "Finish";
            // 
            // panelWorkspacePicker
            // 
            this.panelWorkspacePicker.Controls.Add(this.SplitContainer1);
            this.panelWorkspacePicker.Location = new System.Drawing.Point(400, 208);
            this.panelWorkspacePicker.Name = "panelWorkspacePicker";
            this.panelWorkspacePicker.Size = new System.Drawing.Size(1314, 767);
            this.panelWorkspacePicker.TabIndex = 2;
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SplitContainer1.Name = "SplitContainer1";
            this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.label10);
            this.SplitContainer1.Panel1.Controls.Add(this.GroupBox2);
            this.SplitContainer1.Panel1.Controls.Add(this.GroupBox1);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.webBrowser1);
            this.SplitContainer1.Size = new System.Drawing.Size(1314, 767);
            this.SplitContainer1.SplitterDistance = 195;
            this.SplitContainer1.SplitterWidth = 6;
            this.SplitContainer1.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 32);
            this.label10.TabIndex = 2;
            this.label10.Text = "Picker";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.label6);
            this.GroupBox2.Controls.Add(this.cmdSearch);
            this.GroupBox2.Controls.Add(this.txtSearch);
            this.GroupBox2.Controls.Add(this.cmdHome);
            this.GroupBox2.Controls.Add(this.cmdBack);
            this.GroupBox2.Controls.Add(this.cmdForward);
            this.GroupBox2.Location = new System.Drawing.Point(13, 103);
            this.GroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GroupBox2.Size = new System.Drawing.Size(1314, 88);
            this.GroupBox2.TabIndex = 5;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Browser Navigator Controls";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(400, 23);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(336, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Enter Search information to search for an app.";
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(842, 45);
            this.cmdSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(112, 35);
            this.cmdSearch.TabIndex = 5;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(405, 48);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(426, 26);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // cmdHome
            // 
            this.cmdHome.Location = new System.Drawing.Point(9, 29);
            this.cmdHome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdHome.Name = "cmdHome";
            this.cmdHome.Size = new System.Drawing.Size(112, 35);
            this.cmdHome.TabIndex = 1;
            this.cmdHome.Text = "Home";
            this.cmdHome.UseVisualStyleBackColor = true;
            this.cmdHome.Click += new System.EventHandler(this.cmdHome_Click);
            // 
            // cmdBack
            // 
            this.cmdBack.Location = new System.Drawing.Point(130, 29);
            this.cmdBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(112, 35);
            this.cmdBack.TabIndex = 2;
            this.cmdBack.Text = "Back";
            this.cmdBack.UseVisualStyleBackColor = true;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // cmdForward
            // 
            this.cmdForward.Location = new System.Drawing.Point(252, 29);
            this.cmdForward.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdForward.Name = "cmdForward";
            this.cmdForward.Size = new System.Drawing.Size(112, 35);
            this.cmdForward.TabIndex = 3;
            this.cmdForward.Text = "Forward";
            this.cmdForward.UseVisualStyleBackColor = true;
            this.cmdForward.Click += new System.EventHandler(this.cmdForward_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.lblSafeName);
            this.GroupBox1.Controls.Add(this.lblAppName);
            this.GroupBox1.Controls.Add(this.lblAppID);
            this.GroupBox1.Location = new System.Drawing.Point(116, 5);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GroupBox1.Size = new System.Drawing.Size(819, 88);
            this.GroupBox1.TabIndex = 4;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Detected Info";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(635, 13);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(93, 20);
            this.Label5.TabIndex = 1;
            this.Label5.Text = "Safe Name:";
            this.Label5.Visible = false;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(10, 58);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(88, 20);
            this.Label4.TabIndex = 1;
            this.Label4.Text = "App Name:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(10, 31);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(55, 20);
            this.Label3.TabIndex = 1;
            this.Label3.Text = "AppID";
            // 
            // lblSafeName
            // 
            this.lblSafeName.AutoSize = true;
            this.lblSafeName.Location = new System.Drawing.Point(638, 31);
            this.lblSafeName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSafeName.Name = "lblSafeName";
            this.lblSafeName.Size = new System.Drawing.Size(100, 20);
            this.lblSafeName.TabIndex = 0;
            this.lblSafeName.Text = "lblSafeName";
            this.lblSafeName.Visible = false;
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Location = new System.Drawing.Point(118, 58);
            this.lblAppName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(95, 20);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "lblAppName";
            // 
            // lblAppID
            // 
            this.lblAppID.AutoSize = true;
            this.lblAppID.Location = new System.Drawing.Point(118, 31);
            this.lblAppID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAppID.Name = "lblAppID";
            this.lblAppID.Size = new System.Drawing.Size(70, 20);
            this.lblAppID.TabIndex = 0;
            this.lblAppID.Text = "lblAppID";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(30, 31);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(1314, 566);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
            // 
            // panelWorkspacePlatform
            // 
            this.panelWorkspacePlatform.Controls.Add(this.groupBoxAutomationConsiderations);
            this.panelWorkspacePlatform.Controls.Add(this.cboPlatform);
            this.panelWorkspacePlatform.Controls.Add(this.label2);
            this.panelWorkspacePlatform.Location = new System.Drawing.Point(165, 78);
            this.panelWorkspacePlatform.Name = "panelWorkspacePlatform";
            this.panelWorkspacePlatform.Size = new System.Drawing.Size(1075, 480);
            this.panelWorkspacePlatform.TabIndex = 4;
            // 
            // groupBoxAutomationConsiderations
            // 
            this.groupBoxAutomationConsiderations.Controls.Add(this.label20);
            this.groupBoxAutomationConsiderations.Controls.Add(this.label16);
            this.groupBoxAutomationConsiderations.Controls.Add(this.label15);
            this.groupBoxAutomationConsiderations.Controls.Add(this.label14);
            this.groupBoxAutomationConsiderations.Controls.Add(this.label12);
            this.groupBoxAutomationConsiderations.Controls.Add(this.lblDetectable);
            this.groupBoxAutomationConsiderations.Controls.Add(this.lblStatus);
            this.groupBoxAutomationConsiderations.Controls.Add(this.lblAppInstallation);
            this.groupBoxAutomationConsiderations.Controls.Add(this.lblDPIControl);
            this.groupBoxAutomationConsiderations.Controls.Add(this.lblSizeControl);
            this.groupBoxAutomationConsiderations.Location = new System.Drawing.Point(569, 19);
            this.groupBoxAutomationConsiderations.Name = "groupBoxAutomationConsiderations";
            this.groupBoxAutomationConsiderations.Size = new System.Drawing.Size(443, 216);
            this.groupBoxAutomationConsiderations.TabIndex = 4;
            this.groupBoxAutomationConsiderations.TabStop = false;
            this.groupBoxAutomationConsiderations.Text = "Automation Considerations";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 161);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 20);
            this.label16.TabIndex = 2;
            this.label16.Text = "Status";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 98);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 20);
            this.label15.TabIndex = 2;
            this.label15.Text = "App Installation";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 20);
            this.label14.TabIndex = 2;
            this.label14.Text = "DPI Control";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(155, 20);
            this.label12.TabIndex = 2;
            this.label12.Text = "Window Size Control";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(184, 161);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(71, 20);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "lblStatus";
            // 
            // lblAppInstallation
            // 
            this.lblAppInstallation.AutoSize = true;
            this.lblAppInstallation.Location = new System.Drawing.Point(184, 98);
            this.lblAppInstallation.Name = "lblAppInstallation";
            this.lblAppInstallation.Size = new System.Drawing.Size(130, 20);
            this.lblAppInstallation.TabIndex = 3;
            this.lblAppInstallation.Text = "lblAppInstallation";
            // 
            // lblDPIControl
            // 
            this.lblDPIControl.AutoSize = true;
            this.lblDPIControl.Location = new System.Drawing.Point(184, 64);
            this.lblDPIControl.Name = "lblDPIControl";
            this.lblDPIControl.Size = new System.Drawing.Size(102, 20);
            this.lblDPIControl.TabIndex = 3;
            this.lblDPIControl.Text = "lblDPIControl";
            // 
            // lblSizeControl
            // 
            this.lblSizeControl.AutoSize = true;
            this.lblSizeControl.Location = new System.Drawing.Point(184, 32);
            this.lblSizeControl.Name = "lblSizeControl";
            this.lblSizeControl.Size = new System.Drawing.Size(106, 20);
            this.lblSizeControl.TabIndex = 3;
            this.lblSizeControl.Text = "lblSizeControl";
            // 
            // cboPlatform
            // 
            this.cboPlatform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlatform.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPlatform.FormattingEnabled = true;
            this.cboPlatform.Location = new System.Drawing.Point(130, 3);
            this.cboPlatform.Name = "cboPlatform";
            this.cboPlatform.Size = new System.Drawing.Size(330, 37);
            this.cboPlatform.TabIndex = 1;
            this.cboPlatform.SelectedIndexChanged += new System.EventHandler(this.cboPlatform_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Platform";
            // 
            // panelWorkspaceStart
            // 
            this.panelWorkspaceStart.Controls.Add(this.label1);
            this.panelWorkspaceStart.Location = new System.Drawing.Point(249, 313);
            this.panelWorkspaceStart.Name = "panelWorkspaceStart";
            this.panelWorkspaceStart.Size = new System.Drawing.Size(507, 357);
            this.panelWorkspaceStart.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(16, 129);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(87, 20);
            this.label20.TabIndex = 2;
            this.label20.Text = "Detectable";
            // 
            // lblDetectable
            // 
            this.lblDetectable.AutoSize = true;
            this.lblDetectable.Location = new System.Drawing.Point(184, 129);
            this.lblDetectable.Name = "lblDetectable";
            this.lblDetectable.Size = new System.Drawing.Size(102, 20);
            this.lblDetectable.TabIndex = 3;
            this.lblDetectable.Text = "lblDetectable";
            // 
            // frmAddNewGameWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1563, 1078);
            this.Controls.Add(this.splitContainerMainVertical);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAddNewGameWizard";
            this.Text = "Add New App Wizard";
            this.Load += new System.EventHandler(this.frmAddNewGameWizard_Load);
            this.splitContainerMainVertical.Panel1.ResumeLayout(false);
            this.splitContainerMainVertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMainVertical)).EndInit();
            this.splitContainerMainVertical.ResumeLayout(false);
            this.tableLayoutPanelLeftNav.ResumeLayout(false);
            this.tableLayoutPanelLeftNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNaming)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlatform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPicker)).EndInit();
            this.tableLayoutPanelRightSide.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelWorkspace.ResumeLayout(false);
            this.panelWorkspaceNaming.ResumeLayout(false);
            this.panelWorkspaceNaming.PerformLayout();
            this.panelWorkspacePicker.ResumeLayout(false);
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel1.PerformLayout();
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.panelWorkspacePlatform.ResumeLayout(false);
            this.panelWorkspacePlatform.PerformLayout();
            this.groupBoxAutomationConsiderations.ResumeLayout(false);
            this.groupBoxAutomationConsiderations.PerformLayout();
            this.panelWorkspaceStart.ResumeLayout(false);
            this.panelWorkspaceStart.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.SplitContainer splitContainerMainVertical;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLeftNav;
        private System.Windows.Forms.PictureBox pictureBoxStart;
        private System.Windows.Forms.PictureBox pictureBoxNaming;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBoxPlatform;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.PictureBox pictureBoxPicker;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRightSide;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cmdWizardCancel;
        private System.Windows.Forms.Button cmdFinish;
        private System.Windows.Forms.Button cmdNext;
        private System.Windows.Forms.Button cmdPrevious;
        private System.Windows.Forms.Button cmdStartOver;
        private System.Windows.Forms.Panel panelWorkspace;
        private System.Windows.Forms.Panel panelWorkspaceNaming;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panelWorkspacePlatform;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelWorkspaceStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelWorkspacePicker;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Button cmdSearch;
        internal System.Windows.Forms.TextBox txtSearch;
        internal System.Windows.Forms.Button cmdHome;
        internal System.Windows.Forms.Button cmdBack;
        internal System.Windows.Forms.Button cmdForward;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label lblSafeName;
        internal System.Windows.Forms.Label lblAppName;
        internal System.Windows.Forms.Label lblAppID;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ComboBox cboPlatform;
        private System.Windows.Forms.GroupBox groupBoxAutomationConsiderations;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblAppInstallation;
        private System.Windows.Forms.Label lblDPIControl;
        private System.Windows.Forms.Label lblSizeControl;
        internal System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label lblNameIsInvalid;
        private System.Windows.Forms.TextBox txtFinishAppID;
        private System.Windows.Forms.Label lblFinishAppID;
        private System.Windows.Forms.Label lblSelectedPlatform;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblDetectable;
    }
}