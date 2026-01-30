namespace AppTestStudio
{
    partial class frmTestPixelSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestPixelSearch));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            splitContainer1 = new SplitContainer();
            PanelScreenshot = new Panel();
            PictureBoxSearchArea = new PictureBox();
            splitContainer2 = new SplitContainer();
            flowLayoutPanel1 = new FlowLayoutPanel();
            cmdRetestCurrentWindow = new Button();
            cmdRetestThisWindow = new Button();
            cmdRetestDesignImage = new Button();
            panelRightPixelSearchProperties = new Panel();
            groupBox1 = new GroupBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            numMaskWidth = new NumericUpDown();
            numMaskY = new NumericUpDown();
            numMaskHeight = new NumericUpDown();
            numMaskX = new NumericUpDown();
            cmdLoadSettings = new Button();
            cmdMoveSettingsToProject = new Button();
            lblPixelSearchPreview = new Label();
            label119 = new Label();
            label118 = new Label();
            label116 = new Label();
            label115 = new Label();
            label113 = new Label();
            label110 = new Label();
            label109 = new Label();
            numPixelSearchB = new NumericUpDown();
            numPixelSearchG = new NumericUpDown();
            numPixelSearchBNeg = new NumericUpDown();
            numPixelSearchBPos = new NumericUpDown();
            numPixelSearchGPos = new NumericUpDown();
            numPixelSearchGNeg = new NumericUpDown();
            numPixelSearchRPos = new NumericUpDown();
            numPixelSearchRNeg = new NumericUpDown();
            numPixelSearchR = new NumericUpDown();
            label1 = new Label();
            panelRightColorAtPointer = new Panel();
            lblRHSColor = new Label();
            cmdRightColorAtPointer = new Button();
            lblRHSXY = new Label();
            PictureBox2 = new PictureBox();
            PanelSelectedColor = new Panel();
            dataGridView1 = new DataGridView();
            colCount = new DataGridViewTextBoxColumn();
            colX = new DataGridViewTextBoxColumn();
            colY = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            PanelScreenshot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxSearchArea).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panelRightPixelSearchProperties.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMaskWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaskY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaskHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaskX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchBNeg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchBPos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchGPos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchGNeg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchRPos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchRNeg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchR).BeginInit();
            panelRightColorAtPointer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(PanelScreenshot);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Panel2MinSize = 250;
            splitContainer1.Size = new Size(1307, 1136);
            splitContainer1.SplitterDistance = 981;
            splitContainer1.TabIndex = 11;
            // 
            // PanelScreenshot
            // 
            PanelScreenshot.AutoScroll = true;
            PanelScreenshot.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PanelScreenshot.Controls.Add(PictureBoxSearchArea);
            PanelScreenshot.Dock = DockStyle.Fill;
            PanelScreenshot.Location = new Point(0, 0);
            PanelScreenshot.Margin = new Padding(3, 4, 3, 4);
            PanelScreenshot.Name = "PanelScreenshot";
            PanelScreenshot.Size = new Size(981, 1136);
            PanelScreenshot.TabIndex = 11;
            // 
            // PictureBoxSearchArea
            // 
            PictureBoxSearchArea.Cursor = Cursors.Cross;
            PictureBoxSearchArea.Location = new Point(3, 0);
            PictureBoxSearchArea.Margin = new Padding(3, 4, 3, 4);
            PictureBoxSearchArea.Name = "PictureBoxSearchArea";
            PictureBoxSearchArea.Size = new Size(100, 50);
            PictureBoxSearchArea.SizeMode = PictureBoxSizeMode.AutoSize;
            PictureBoxSearchArea.TabIndex = 0;
            PictureBoxSearchArea.TabStop = false;
            PictureBoxSearchArea.Click += PictureBoxSearchArea_Click;
            PictureBoxSearchArea.Paint += PictureBoxSearchArea_Paint;
            PictureBoxSearchArea.MouseDown += PictureBoxSearchArea_MouseDown;
            PictureBoxSearchArea.MouseMove += PictureBoxSearchArea_MouseMove;
            PictureBoxSearchArea.MouseUp += PictureBoxSearchArea_MouseUp;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.IsSplitterFixed = true;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(flowLayoutPanel1);
            splitContainer2.Panel1MinSize = 0;
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(dataGridView1);
            splitContainer2.Size = new Size(322, 1136);
            splitContainer2.SplitterDistance = 630;
            splitContainer2.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(cmdRetestCurrentWindow);
            flowLayoutPanel1.Controls.Add(cmdRetestThisWindow);
            flowLayoutPanel1.Controls.Add(cmdRetestDesignImage);
            flowLayoutPanel1.Controls.Add(panelRightPixelSearchProperties);
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(panelRightColorAtPointer);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(322, 630);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // cmdRetestCurrentWindow
            // 
            cmdRetestCurrentWindow.Location = new Point(3, 3);
            cmdRetestCurrentWindow.Name = "cmdRetestCurrentWindow";
            cmdRetestCurrentWindow.Size = new Size(309, 23);
            cmdRetestCurrentWindow.TabIndex = 44;
            cmdRetestCurrentWindow.Text = "Re-Test Current Target Window";
            cmdRetestCurrentWindow.UseVisualStyleBackColor = true;
            cmdRetestCurrentWindow.Click += cmdRetestCurrentWindow_Click;
            // 
            // cmdRetestThisWindow
            // 
            cmdRetestThisWindow.Location = new Point(3, 32);
            cmdRetestThisWindow.Name = "cmdRetestThisWindow";
            cmdRetestThisWindow.Size = new Size(309, 23);
            cmdRetestThisWindow.TabIndex = 44;
            cmdRetestThisWindow.Text = "Re-Test This Image";
            cmdRetestThisWindow.UseVisualStyleBackColor = true;
            cmdRetestThisWindow.Click += cmdRetestThisWindow_Click;
            // 
            // cmdRetestDesignImage
            // 
            cmdRetestDesignImage.Location = new Point(3, 61);
            cmdRetestDesignImage.Name = "cmdRetestDesignImage";
            cmdRetestDesignImage.Size = new Size(309, 23);
            cmdRetestDesignImage.TabIndex = 45;
            cmdRetestDesignImage.Text = "Re-Test Project Image";
            cmdRetestDesignImage.UseVisualStyleBackColor = true;
            cmdRetestDesignImage.Click += cmdRetestDesignImage_Click;
            // 
            // panelRightPixelSearchProperties
            // 
            panelRightPixelSearchProperties.BorderStyle = BorderStyle.FixedSingle;
            panelRightPixelSearchProperties.Controls.Add(groupBox1);
            panelRightPixelSearchProperties.Controls.Add(cmdLoadSettings);
            panelRightPixelSearchProperties.Controls.Add(cmdMoveSettingsToProject);
            panelRightPixelSearchProperties.Controls.Add(lblPixelSearchPreview);
            panelRightPixelSearchProperties.Controls.Add(label119);
            panelRightPixelSearchProperties.Controls.Add(label118);
            panelRightPixelSearchProperties.Controls.Add(label116);
            panelRightPixelSearchProperties.Controls.Add(label115);
            panelRightPixelSearchProperties.Controls.Add(label113);
            panelRightPixelSearchProperties.Controls.Add(label110);
            panelRightPixelSearchProperties.Controls.Add(label109);
            panelRightPixelSearchProperties.Controls.Add(numPixelSearchB);
            panelRightPixelSearchProperties.Controls.Add(numPixelSearchG);
            panelRightPixelSearchProperties.Controls.Add(numPixelSearchBNeg);
            panelRightPixelSearchProperties.Controls.Add(numPixelSearchBPos);
            panelRightPixelSearchProperties.Controls.Add(numPixelSearchGPos);
            panelRightPixelSearchProperties.Controls.Add(numPixelSearchGNeg);
            panelRightPixelSearchProperties.Controls.Add(numPixelSearchRPos);
            panelRightPixelSearchProperties.Controls.Add(numPixelSearchRNeg);
            panelRightPixelSearchProperties.Controls.Add(numPixelSearchR);
            panelRightPixelSearchProperties.Location = new Point(2, 89);
            panelRightPixelSearchProperties.Margin = new Padding(2);
            panelRightPixelSearchProperties.Name = "panelRightPixelSearchProperties";
            panelRightPixelSearchProperties.Size = new Size(326, 245);
            panelRightPixelSearchProperties.TabIndex = 43;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(numMaskWidth);
            groupBox1.Controls.Add(numMaskY);
            groupBox1.Controls.Add(numMaskHeight);
            groupBox1.Controls.Add(numMaskX);
            groupBox1.Location = new Point(7, 112);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(298, 72);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Mask";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(134, 50);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 5;
            label5.Text = "Width";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(134, 21);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 4;
            label4.Text = "Height";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 49);
            label3.Name = "label3";
            label3.Size = new Size(14, 15);
            label3.TabIndex = 3;
            label3.Text = "Y";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 20);
            label2.Name = "label2";
            label2.Size = new Size(14, 15);
            label2.TabIndex = 2;
            label2.Text = "X";
            // 
            // numMaskWidth
            // 
            numMaskWidth.Location = new Point(181, 46);
            numMaskWidth.Name = "numMaskWidth";
            numMaskWidth.Size = new Size(49, 23);
            numMaskWidth.TabIndex = 1;
            numMaskWidth.ValueChanged += numMaskWidth_ValueChanged;
            // 
            // numMaskY
            // 
            numMaskY.Location = new Point(56, 46);
            numMaskY.Name = "numMaskY";
            numMaskY.Size = new Size(49, 23);
            numMaskY.TabIndex = 1;
            numMaskY.ValueChanged += numMaskY_ValueChanged;
            // 
            // numMaskHeight
            // 
            numMaskHeight.Location = new Point(182, 17);
            numMaskHeight.Name = "numMaskHeight";
            numMaskHeight.Size = new Size(49, 23);
            numMaskHeight.TabIndex = 0;
            numMaskHeight.ValueChanged += numMaskHeight_ValueChanged;
            // 
            // numMaskX
            // 
            numMaskX.Location = new Point(57, 17);
            numMaskX.Name = "numMaskX";
            numMaskX.Size = new Size(49, 23);
            numMaskX.TabIndex = 0;
            numMaskX.ValueChanged += numMaskX_ValueChanged;
            // 
            // cmdLoadSettings
            // 
            cmdLoadSettings.Location = new Point(23, 188);
            cmdLoadSettings.Name = "cmdLoadSettings";
            cmdLoadSettings.Size = new Size(284, 23);
            cmdLoadSettings.TabIndex = 20;
            cmdLoadSettings.Text = "Load settings from project";
            cmdLoadSettings.UseVisualStyleBackColor = true;
            cmdLoadSettings.Click += cmdLoadSettings_Click;
            // 
            // cmdMoveSettingsToProject
            // 
            cmdMoveSettingsToProject.Location = new Point(23, 213);
            cmdMoveSettingsToProject.Name = "cmdMoveSettingsToProject";
            cmdMoveSettingsToProject.Size = new Size(282, 23);
            cmdMoveSettingsToProject.TabIndex = 20;
            cmdMoveSettingsToProject.Text = "Move ALL settings to project";
            cmdMoveSettingsToProject.UseVisualStyleBackColor = true;
            cmdMoveSettingsToProject.Click += cmdMoveSettingsToProject_Click;
            // 
            // lblPixelSearchPreview
            // 
            lblPixelSearchPreview.Location = new Point(209, 27);
            lblPixelSearchPreview.Name = "lblPixelSearchPreview";
            lblPixelSearchPreview.Size = new Size(100, 84);
            lblPixelSearchPreview.TabIndex = 19;
            // 
            // label119
            // 
            label119.AutoSize = true;
            label119.Location = new Point(210, 5);
            label119.Name = "label119";
            label119.Size = new Size(46, 15);
            label119.TabIndex = 18;
            label119.Text = "Sample";
            // 
            // label118
            // 
            label118.AutoSize = true;
            label118.Location = new Point(125, 5);
            label118.Name = "label118";
            label118.Size = new Size(51, 15);
            label118.TabIndex = 18;
            label118.Text = "+ Range";
            // 
            // label116
            // 
            label116.AutoSize = true;
            label116.Location = new Point(71, 5);
            label116.Name = "label116";
            label116.Size = new Size(48, 15);
            label116.TabIndex = 18;
            label116.Text = "- Range";
            // 
            // label115
            // 
            label115.AutoSize = true;
            label115.Location = new Point(25, 5);
            label115.Name = "label115";
            label115.Size = new Size(36, 15);
            label115.TabIndex = 18;
            label115.Text = "Color";
            // 
            // label113
            // 
            label113.AutoSize = true;
            label113.Location = new Point(7, 83);
            label113.Name = "label113";
            label113.Size = new Size(14, 15);
            label113.TabIndex = 17;
            label113.Text = "B";
            // 
            // label110
            // 
            label110.AutoSize = true;
            label110.Location = new Point(7, 55);
            label110.Name = "label110";
            label110.Size = new Size(15, 15);
            label110.TabIndex = 17;
            label110.Text = "G";
            // 
            // label109
            // 
            label109.AutoSize = true;
            label109.Location = new Point(7, 27);
            label109.Name = "label109";
            label109.Size = new Size(14, 15);
            label109.TabIndex = 17;
            label109.Text = "R";
            // 
            // numPixelSearchB
            // 
            numPixelSearchB.Location = new Point(25, 83);
            numPixelSearchB.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numPixelSearchB.Name = "numPixelSearchB";
            numPixelSearchB.Size = new Size(42, 23);
            numPixelSearchB.TabIndex = 7;
            numPixelSearchB.Value = new decimal(new int[] { 255, 0, 0, 0 });
            numPixelSearchB.ValueChanged += numPixelSearchB_ValueChanged;
            // 
            // numPixelSearchG
            // 
            numPixelSearchG.Location = new Point(25, 55);
            numPixelSearchG.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numPixelSearchG.Name = "numPixelSearchG";
            numPixelSearchG.Size = new Size(42, 23);
            numPixelSearchG.TabIndex = 4;
            numPixelSearchG.Value = new decimal(new int[] { 255, 0, 0, 0 });
            numPixelSearchG.ValueChanged += numPixelSearchG_ValueChanged;
            // 
            // numPixelSearchBNeg
            // 
            numPixelSearchBNeg.Location = new Point(77, 83);
            numPixelSearchBNeg.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            numPixelSearchBNeg.Minimum = new decimal(new int[] { 255, 0, 0, int.MinValue });
            numPixelSearchBNeg.Name = "numPixelSearchBNeg";
            numPixelSearchBNeg.Size = new Size(45, 23);
            numPixelSearchBNeg.TabIndex = 8;
            // 
            // numPixelSearchBPos
            // 
            numPixelSearchBPos.Location = new Point(134, 83);
            numPixelSearchBPos.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numPixelSearchBPos.Name = "numPixelSearchBPos";
            numPixelSearchBPos.Size = new Size(42, 23);
            numPixelSearchBPos.TabIndex = 9;
            // 
            // numPixelSearchGPos
            // 
            numPixelSearchGPos.Location = new Point(134, 55);
            numPixelSearchGPos.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numPixelSearchGPos.Name = "numPixelSearchGPos";
            numPixelSearchGPos.Size = new Size(42, 23);
            numPixelSearchGPos.TabIndex = 6;
            // 
            // numPixelSearchGNeg
            // 
            numPixelSearchGNeg.Location = new Point(77, 55);
            numPixelSearchGNeg.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            numPixelSearchGNeg.Minimum = new decimal(new int[] { 255, 0, 0, int.MinValue });
            numPixelSearchGNeg.Name = "numPixelSearchGNeg";
            numPixelSearchGNeg.Size = new Size(45, 23);
            numPixelSearchGNeg.TabIndex = 5;
            // 
            // numPixelSearchRPos
            // 
            numPixelSearchRPos.Location = new Point(134, 27);
            numPixelSearchRPos.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numPixelSearchRPos.Name = "numPixelSearchRPos";
            numPixelSearchRPos.Size = new Size(42, 23);
            numPixelSearchRPos.TabIndex = 3;
            // 
            // numPixelSearchRNeg
            // 
            numPixelSearchRNeg.Location = new Point(77, 27);
            numPixelSearchRNeg.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            numPixelSearchRNeg.Minimum = new decimal(new int[] { 255, 0, 0, int.MinValue });
            numPixelSearchRNeg.Name = "numPixelSearchRNeg";
            numPixelSearchRNeg.Size = new Size(45, 23);
            numPixelSearchRNeg.TabIndex = 2;
            // 
            // numPixelSearchR
            // 
            numPixelSearchR.Location = new Point(25, 27);
            numPixelSearchR.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numPixelSearchR.Name = "numPixelSearchR";
            numPixelSearchR.Size = new Size(42, 23);
            numPixelSearchR.TabIndex = 1;
            numPixelSearchR.Value = new decimal(new int[] { 255, 0, 0, 0 });
            numPixelSearchR.ValueChanged += numPixelSearchR_ValueChanged;
            // 
            // label1
            // 
            label1.Location = new Point(3, 336);
            label1.Name = "label1";
            label1.Size = new Size(316, 20);
            label1.TabIndex = 46;
            label1.Text = "label1";
            // 
            // panelRightColorAtPointer
            // 
            panelRightColorAtPointer.BorderStyle = BorderStyle.FixedSingle;
            panelRightColorAtPointer.Controls.Add(lblRHSColor);
            panelRightColorAtPointer.Controls.Add(cmdRightColorAtPointer);
            panelRightColorAtPointer.Controls.Add(lblRHSXY);
            panelRightColorAtPointer.Controls.Add(PictureBox2);
            panelRightColorAtPointer.Controls.Add(PanelSelectedColor);
            panelRightColorAtPointer.Location = new Point(4, 359);
            panelRightColorAtPointer.Margin = new Padding(4, 3, 4, 3);
            panelRightColorAtPointer.Name = "panelRightColorAtPointer";
            panelRightColorAtPointer.Size = new Size(326, 264);
            panelRightColorAtPointer.TabIndex = 47;
            // 
            // lblRHSColor
            // 
            lblRHSColor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRHSColor.AutoSize = true;
            lblRHSColor.BackColor = Color.Transparent;
            lblRHSColor.Location = new Point(100, 233);
            lblRHSColor.Margin = new Padding(4, 0, 4, 0);
            lblRHSColor.Name = "lblRHSColor";
            lblRHSColor.Size = new Size(71, 15);
            lblRHSColor.TabIndex = 2;
            lblRHSColor.Text = "[lblColorXY]";
            // 
            // cmdRightColorAtPointer
            // 
            cmdRightColorAtPointer.BackColor = SystemColors.ButtonShadow;
            cmdRightColorAtPointer.Cursor = Cursors.Hand;
            cmdRightColorAtPointer.Dock = DockStyle.Top;
            cmdRightColorAtPointer.FlatAppearance.BorderSize = 0;
            cmdRightColorAtPointer.FlatStyle = FlatStyle.Flat;
            cmdRightColorAtPointer.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            cmdRightColorAtPointer.ForeColor = SystemColors.ButtonFace;
            cmdRightColorAtPointer.ImageAlign = ContentAlignment.MiddleLeft;
            cmdRightColorAtPointer.ImageIndex = 22;
            cmdRightColorAtPointer.Location = new Point(0, 0);
            cmdRightColorAtPointer.Margin = new Padding(4, 3, 4, 3);
            cmdRightColorAtPointer.Name = "cmdRightColorAtPointer";
            cmdRightColorAtPointer.Size = new Size(324, 27);
            cmdRightColorAtPointer.TabIndex = 0;
            cmdRightColorAtPointer.Text = "Color At Pointer";
            cmdRightColorAtPointer.TextAlign = ContentAlignment.MiddleLeft;
            cmdRightColorAtPointer.TextImageRelation = TextImageRelation.ImageBeforeText;
            cmdRightColorAtPointer.UseVisualStyleBackColor = false;
            // 
            // lblRHSXY
            // 
            lblRHSXY.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRHSXY.AutoSize = true;
            lblRHSXY.BackColor = Color.Transparent;
            lblRHSXY.Location = new Point(107, 218);
            lblRHSXY.Margin = new Padding(4, 0, 4, 0);
            lblRHSXY.Name = "lblRHSXY";
            lblRHSXY.Size = new Size(64, 15);
            lblRHSXY.TabIndex = 3;
            lblRHSXY.Text = "[lblRHSXY]";
            // 
            // PictureBox2
            // 
            PictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PictureBox2.Image = (Image)resources.GetObject("PictureBox2.Image");
            PictureBox2.Location = new Point(50, 30);
            PictureBox2.Margin = new Padding(4, 3, 4, 3);
            PictureBox2.Name = "PictureBox2";
            PictureBox2.Size = new Size(187, 185);
            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox2.TabIndex = 0;
            PictureBox2.TabStop = false;
            // 
            // PanelSelectedColor
            // 
            PanelSelectedColor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PanelSelectedColor.Location = new Point(51, 218);
            PanelSelectedColor.Margin = new Padding(4, 3, 4, 3);
            PanelSelectedColor.Name = "PanelSelectedColor";
            PanelSelectedColor.Size = new Size(187, 42);
            PanelSelectedColor.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colCount, colX, colY });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(322, 502);
            dataGridView1.TabIndex = 47;
            dataGridView1.CellMouseEnter += dataGridView1_CellMouseEnter;
            dataGridView1.MouseEnter += dataGridView1_MouseEnter;
            // 
            // colCount
            // 
            colCount.HeaderText = "Pixel";
            colCount.Name = "colCount";
            colCount.ReadOnly = true;
            colCount.Width = 50;
            // 
            // colX
            // 
            colX.FillWeight = 50F;
            colX.HeaderText = "X";
            colX.Name = "colX";
            colX.ReadOnly = true;
            colX.Width = 50;
            // 
            // colY
            // 
            colY.HeaderText = "Y";
            colY.Name = "colY";
            colY.ReadOnly = true;
            colY.Width = 50;
            // 
            // frmTestPixelSearch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1307, 1136);
            Controls.Add(splitContainer1);
            Name = "frmTestPixelSearch";
            Text = "Test Pixel Search";
            Load += frmTestPixelSearch_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            PanelScreenshot.ResumeLayout(false);
            PanelScreenshot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxSearchArea).EndInit();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            panelRightPixelSearchProperties.ResumeLayout(false);
            panelRightPixelSearchProperties.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMaskWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaskY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaskHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaskX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchB).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchG).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchBNeg).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchBPos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchGPos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchGNeg).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchRPos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchRNeg).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchR).EndInit();
            panelRightColorAtPointer.ResumeLayout(false);
            panelRightColorAtPointer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        internal Panel PanelScreenshot;
        internal PictureBox PictureBoxSearchArea;
        private Panel panelRightPixelSearchProperties;
        private Label lblPixelSearchPreview;
        private Label label119;
        private Label label118;
        private Label label116;
        private Label label115;
        private Label label113;
        private Label label110;
        private Label label109;
        private NumericUpDown numPixelSearchB;
        private NumericUpDown numPixelSearchG;
        private NumericUpDown numPixelSearchBNeg;
        private NumericUpDown numPixelSearchBPos;
        private NumericUpDown numPixelSearchGPos;
        private NumericUpDown numPixelSearchGNeg;
        private NumericUpDown numPixelSearchRPos;
        private NumericUpDown numPixelSearchRNeg;
        private NumericUpDown numPixelSearchR;
        private Button cmdRetestDesignImage;
        private Button cmdRetestCurrentWindow;
        private Label label1;
        private DataGridView dataGridView1;
        private Button cmdMoveSettingsToProject;
        private DataGridViewTextBoxColumn colCount;
        private DataGridViewTextBoxColumn colX;
        private DataGridViewTextBoxColumn colY;
        private SplitContainer splitContainer2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button cmdLoadSettings;
        private Panel panelRightColorAtPointer;
        internal Label lblRHSColor;
        private Button cmdRightColorAtPointer;
        internal Label lblRHSXY;
        internal PictureBox PictureBox2;
        internal Panel PanelSelectedColor;
        private Button cmdRetestThisWindow;
        private GroupBox groupBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private NumericUpDown numMaskWidth;
        private NumericUpDown numMaskY;
        private NumericUpDown numMaskHeight;
        private NumericUpDown numMaskX;
    }
}