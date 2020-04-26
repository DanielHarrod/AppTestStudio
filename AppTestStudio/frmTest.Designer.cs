namespace AppTestStudio
{
    partial class frmTest
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblPoints = new System.Windows.Forms.Label();
            this.PictureBoxTest = new System.Windows.Forms.PictureBox();
            this.PanelTest = new System.Windows.Forms.Panel();
            this.lblTestWindow = new System.Windows.Forms.Label();
            this.SplitContainer4 = new System.Windows.Forms.SplitContainer();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.PanelScreenshot = new System.Windows.Forms.Panel();
            this.lblReference = new System.Windows.Forms.Label();
            this.SplitContainer3 = new System.Windows.Forms.SplitContainer();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmdRetest = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.dgvGreen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBlue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvReferencePassFail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvgReferenceRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvReferenceRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtResolution = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvTest = new System.Windows.Forms.DataGridView();
            this.dgvColorTestRed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColorTestGreen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColorTestBlue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvXTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvYTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPassFail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvgRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdClose = new System.Windows.Forms.Button();
            this.txtLogic = new System.Windows.Forms.TextBox();
            this.txtLogic2 = new System.Windows.Forms.TextBox();
            this.txtLogic3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTest)).BeginInit();
            this.PanelTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer4)).BeginInit();
            this.SplitContainer4.Panel1.SuspendLayout();
            this.SplitContainer4.Panel2.SuspendLayout();
            this.SplitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.PanelScreenshot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer3)).BeginInit();
            this.SplitContainer3.Panel1.SuspendLayout();
            this.SplitContainer3.Panel2.SuspendLayout();
            this.SplitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).BeginInit();
            this.SplitContainer2.Panel1.SuspendLayout();
            this.SplitContainer2.Panel2.SuspendLayout();
            this.SplitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTest)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPoints
            // 
            this.lblPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPoints.AutoSize = true;
            this.lblPoints.Location = new System.Drawing.Point(911, 359);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(39, 13);
            this.lblPoints.TabIndex = 42;
            this.lblPoints.Text = "Label1";
            // 
            // PictureBoxTest
            // 
            this.PictureBoxTest.Location = new System.Drawing.Point(0, 0);
            this.PictureBoxTest.Name = "PictureBoxTest";
            this.PictureBoxTest.Size = new System.Drawing.Size(100, 50);
            this.PictureBoxTest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBoxTest.TabIndex = 0;
            this.PictureBoxTest.TabStop = false;
            this.PictureBoxTest.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxTest_Paint);
            // 
            // PanelTest
            // 
            this.PanelTest.AutoScroll = true;
            this.PanelTest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelTest.Controls.Add(this.PictureBoxTest);
            this.PanelTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelTest.Location = new System.Drawing.Point(0, 0);
            this.PanelTest.Name = "PanelTest";
            this.PanelTest.Size = new System.Drawing.Size(452, 244);
            this.PanelTest.TabIndex = 9;
            // 
            // lblTestWindow
            // 
            this.lblTestWindow.AutoSize = true;
            this.lblTestWindow.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTestWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestWindow.Location = new System.Drawing.Point(0, 0);
            this.lblTestWindow.Name = "lblTestWindow";
            this.lblTestWindow.Size = new System.Drawing.Size(120, 24);
            this.lblTestWindow.TabIndex = 1;
            this.lblTestWindow.Text = "Test Window";
            // 
            // SplitContainer4
            // 
            this.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer4.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer4.Name = "SplitContainer4";
            this.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer4.Panel1
            // 
            this.SplitContainer4.Panel1.Controls.Add(this.lblTestWindow);
            // 
            // SplitContainer4.Panel2
            // 
            this.SplitContainer4.Panel2.Controls.Add(this.PanelTest);
            this.SplitContainer4.Size = new System.Drawing.Size(452, 274);
            this.SplitContainer4.SplitterDistance = 26;
            this.SplitContainer4.TabIndex = 10;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Location = new System.Drawing.Point(0, 0);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(100, 50);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            this.PictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox1_Paint);
            // 
            // PanelScreenshot
            // 
            this.PanelScreenshot.AutoScroll = true;
            this.PanelScreenshot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelScreenshot.Controls.Add(this.PictureBox1);
            this.PanelScreenshot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelScreenshot.Location = new System.Drawing.Point(0, 0);
            this.PanelScreenshot.Name = "PanelScreenshot";
            this.PanelScreenshot.Size = new System.Drawing.Size(452, 257);
            this.PanelScreenshot.TabIndex = 8;
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReference.Location = new System.Drawing.Point(0, 0);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(98, 24);
            this.lblReference.TabIndex = 0;
            this.lblReference.Text = "Reference";
            // 
            // SplitContainer3
            // 
            this.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer3.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer3.Name = "SplitContainer3";
            this.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer3.Panel1
            // 
            this.SplitContainer3.Panel1.Controls.Add(this.lblReference);
            // 
            // SplitContainer3.Panel2
            // 
            this.SplitContainer3.Panel2.Controls.Add(this.PanelScreenshot);
            this.SplitContainer3.Size = new System.Drawing.Size(452, 287);
            this.SplitContainer3.SplitterDistance = 26;
            this.SplitContainer3.TabIndex = 9;
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitContainer1.Location = new System.Drawing.Point(16, 100);
            this.SplitContainer1.Name = "SplitContainer1";
            this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.SplitContainer3);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.SplitContainer4);
            this.SplitContainer1.Size = new System.Drawing.Size(452, 565);
            this.SplitContainer1.SplitterDistance = 287;
            this.SplitContainer1.TabIndex = 37;
            // 
            // cmdRetest
            // 
            this.cmdRetest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRetest.Location = new System.Drawing.Point(889, 54);
            this.cmdRetest.Name = "cmdRetest";
            this.cmdRetest.Size = new System.Drawing.Size(61, 23);
            this.cmdRetest.TabIndex = 43;
            this.cmdRetest.Text = "Re-Test";
            this.cmdRetest.UseVisualStyleBackColor = true;
            this.cmdRetest.Click += new System.EventHandler(this.cmdRetest_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(179, 24);
            this.Label3.TabIndex = 12;
            this.Label3.Text = "Test Window Colors";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(4, 4);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(98, 24);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "Reference";
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvGreen,
            this.dgvBlue,
            this.dgvRed,
            this.dgvX,
            this.dgvY,
            this.dgvReferencePassFail,
            this.dvgReferenceRange,
            this.dgvReferenceRemove});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgv.Location = new System.Drawing.Point(5, 28);
            this.dgv.Name = "dgv";
            this.dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(405, 281);
            this.dgv.TabIndex = 10;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // dgvGreen
            // 
            this.dgvGreen.HeaderText = "Green";
            this.dgvGreen.Name = "dgvGreen";
            this.dgvGreen.Width = 35;
            // 
            // dgvBlue
            // 
            this.dgvBlue.HeaderText = "Blue";
            this.dgvBlue.Name = "dgvBlue";
            this.dgvBlue.Width = 35;
            // 
            // dgvRed
            // 
            this.dgvRed.HeaderText = "Red";
            this.dgvRed.Name = "dgvRed";
            this.dgvRed.Width = 35;
            // 
            // dgvX
            // 
            this.dgvX.HeaderText = "X";
            this.dgvX.Name = "dgvX";
            this.dgvX.Width = 35;
            // 
            // dgvY
            // 
            this.dgvY.HeaderText = "Y";
            this.dgvY.Name = "dgvY";
            this.dgvY.Width = 35;
            // 
            // dgvReferencePassFail
            // 
            this.dgvReferencePassFail.HeaderText = "Status";
            this.dgvReferencePassFail.Name = "dgvReferencePassFail";
            this.dgvReferencePassFail.Width = 55;
            // 
            // dvgReferenceRange
            // 
            this.dvgReferenceRange.HeaderText = "Points";
            this.dvgReferenceRange.Name = "dvgReferenceRange";
            this.dvgReferenceRange.Width = 55;
            // 
            // dgvReferenceRemove
            // 
            this.dgvReferenceRemove.HeaderText = "Remove";
            this.dgvReferenceRemove.Name = "dgvReferenceRemove";
            this.dgvReferenceRemove.Text = "Remove";
            this.dgvReferenceRemove.Width = 55;
            // 
            // txtResolution
            // 
            this.txtResolution.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResolution.Location = new System.Drawing.Point(456, 1);
            this.txtResolution.Name = "txtResolution";
            this.txtResolution.ReadOnly = true;
            this.txtResolution.Size = new System.Drawing.Size(425, 22);
            this.txtResolution.TabIndex = 41;
            this.txtResolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(18, 1);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(425, 22);
            this.txtResult.TabIndex = 40;
            this.txtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SplitContainer2
            // 
            this.SplitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitContainer2.Location = new System.Drawing.Point(470, 100);
            this.SplitContainer2.Name = "SplitContainer2";
            this.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer2.Panel1
            // 
            this.SplitContainer2.Panel1.Controls.Add(this.Label2);
            this.SplitContainer2.Panel1.Controls.Add(this.dgv);
            // 
            // SplitContainer2.Panel2
            // 
            this.SplitContainer2.Panel2.Controls.Add(this.Label3);
            this.SplitContainer2.Panel2.Controls.Add(this.dgvTest);
            this.SplitContainer2.Size = new System.Drawing.Size(411, 529);
            this.SplitContainer2.SplitterDistance = 264;
            this.SplitContainer2.TabIndex = 38;
            // 
            // dgvTest
            // 
            this.dgvTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColorTestRed,
            this.dgvColorTestGreen,
            this.dgvColorTestBlue,
            this.dgvXTest,
            this.dgvYTest,
            this.dgvPassFail,
            this.dvgRange});
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTest.DefaultCellStyle = dataGridViewCellStyle20;
            this.dgvTest.Location = new System.Drawing.Point(2, 23);
            this.dgvTest.Name = "dgvTest";
            this.dgvTest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTest.Size = new System.Drawing.Size(405, 278);
            this.dgvTest.TabIndex = 11;
            // 
            // dgvColorTestRed
            // 
            this.dgvColorTestRed.HeaderText = "Red";
            this.dgvColorTestRed.Name = "dgvColorTestRed";
            this.dgvColorTestRed.Width = 35;
            // 
            // dgvColorTestGreen
            // 
            this.dgvColorTestGreen.HeaderText = "Green";
            this.dgvColorTestGreen.Name = "dgvColorTestGreen";
            this.dgvColorTestGreen.Width = 35;
            // 
            // dgvColorTestBlue
            // 
            this.dgvColorTestBlue.HeaderText = "Blue";
            this.dgvColorTestBlue.Name = "dgvColorTestBlue";
            this.dgvColorTestBlue.Width = 35;
            // 
            // dgvXTest
            // 
            this.dgvXTest.HeaderText = "X";
            this.dgvXTest.Name = "dgvXTest";
            this.dgvXTest.Width = 35;
            // 
            // dgvYTest
            // 
            this.dgvYTest.HeaderText = "Y";
            this.dgvYTest.Name = "dgvYTest";
            this.dgvYTest.Width = 35;
            // 
            // dgvPassFail
            // 
            this.dgvPassFail.HeaderText = "Status";
            this.dgvPassFail.Name = "dgvPassFail";
            this.dgvPassFail.Width = 55;
            // 
            // dvgRange
            // 
            this.dvgRange.HeaderText = "Points";
            this.dvgRange.Name = "dvgRange";
            this.dvgRange.Width = 55;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Location = new System.Drawing.Point(889, 20);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(61, 27);
            this.cmdClose.TabIndex = 36;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // txtLogic
            // 
            this.txtLogic.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtLogic.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLogic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogic.Location = new System.Drawing.Point(18, 22);
            this.txtLogic.Name = "txtLogic";
            this.txtLogic.ReadOnly = true;
            this.txtLogic.Size = new System.Drawing.Size(863, 19);
            this.txtLogic.TabIndex = 41;
            this.txtLogic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLogic2
            // 
            this.txtLogic2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtLogic2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLogic2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogic2.Location = new System.Drawing.Point(18, 43);
            this.txtLogic2.Name = "txtLogic2";
            this.txtLogic2.ReadOnly = true;
            this.txtLogic2.Size = new System.Drawing.Size(863, 19);
            this.txtLogic2.TabIndex = 41;
            this.txtLogic2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLogic3
            // 
            this.txtLogic3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLogic3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogic3.Location = new System.Drawing.Point(18, 65);
            this.txtLogic3.Name = "txtLogic3";
            this.txtLogic3.ReadOnly = true;
            this.txtLogic3.Size = new System.Drawing.Size(863, 19);
            this.txtLogic3.TabIndex = 41;
            this.txtLogic3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 652);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.cmdRetest);
            this.Controls.Add(this.txtLogic3);
            this.Controls.Add(this.txtLogic2);
            this.Controls.Add(this.txtLogic);
            this.Controls.Add(this.txtResolution);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.SplitContainer2);
            this.Controls.Add(this.cmdClose);
            this.Name = "frmTest";
            this.Text = "Single Test";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTest)).EndInit();
            this.PanelTest.ResumeLayout(false);
            this.PanelTest.PerformLayout();
            this.SplitContainer4.Panel1.ResumeLayout(false);
            this.SplitContainer4.Panel1.PerformLayout();
            this.SplitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer4)).EndInit();
            this.SplitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.PanelScreenshot.ResumeLayout(false);
            this.PanelScreenshot.PerformLayout();
            this.SplitContainer3.Panel1.ResumeLayout(false);
            this.SplitContainer3.Panel1.PerformLayout();
            this.SplitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer3)).EndInit();
            this.SplitContainer3.ResumeLayout(false);
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.SplitContainer2.Panel1.ResumeLayout(false);
            this.SplitContainer2.Panel1.PerformLayout();
            this.SplitContainer2.Panel2.ResumeLayout(false);
            this.SplitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).EndInit();
            this.SplitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblPoints;
        internal System.Windows.Forms.PictureBox PictureBoxTest;
        internal System.Windows.Forms.Panel PanelTest;
        internal System.Windows.Forms.Label lblTestWindow;
        internal System.Windows.Forms.SplitContainer SplitContainer4;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Panel PanelScreenshot;
        internal System.Windows.Forms.Label lblReference;
        internal System.Windows.Forms.SplitContainer SplitContainer3;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.Button cmdRetest;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.DataGridView dgv;
        internal System.Windows.Forms.TextBox txtResolution;
        internal System.Windows.Forms.TextBox txtResult;
        internal System.Windows.Forms.SplitContainer SplitContainer2;
        internal System.Windows.Forms.DataGridView dgvTest;
        internal System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColorTestRed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColorTestGreen;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColorTestBlue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvXTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvYTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPassFail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvgRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvGreen;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBlue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvX;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvY;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvReferencePassFail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvgReferenceRange;
        private System.Windows.Forms.DataGridViewButtonColumn dgvReferenceRemove;
        internal System.Windows.Forms.TextBox txtLogic;
        internal System.Windows.Forms.TextBox txtLogic2;
        internal System.Windows.Forms.TextBox txtLogic3;
    }
}