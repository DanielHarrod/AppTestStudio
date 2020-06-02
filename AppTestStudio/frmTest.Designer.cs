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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.txtResolution = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvTest = new System.Windows.Forms.DataGridView();
            this.cmdClose = new System.Windows.Forms.Button();
            this.txtLogic = new System.Windows.Forms.TextBox();
            this.txtLogic2 = new System.Windows.Forms.TextBox();
            this.txtLogic3 = new System.Windows.Forms.TextBox();
            this.dgvRed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvGreen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBlue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvReferencePassFail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvgReferenceRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvReferenceRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgvColorTestRed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColorTestGreen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColorTestBlue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvXTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvYTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPassFail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvgRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.lblPoints.Location = new System.Drawing.Point(1038, 359);
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
            this.PanelTest.Size = new System.Drawing.Size(579, 352);
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
            this.SplitContainer4.Size = new System.Drawing.Size(579, 391);
            this.SplitContainer4.SplitterDistance = 35;
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
            this.PanelScreenshot.Size = new System.Drawing.Size(579, 366);
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
            this.SplitContainer3.Size = new System.Drawing.Size(579, 404);
            this.SplitContainer3.SplitterDistance = 34;
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
            this.SplitContainer1.Size = new System.Drawing.Size(579, 799);
            this.SplitContainer1.SplitterDistance = 404;
            this.SplitContainer1.TabIndex = 37;
            // 
            // cmdRetest
            // 
            this.cmdRetest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRetest.Location = new System.Drawing.Point(1016, 54);
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
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvRed,
            this.dgvGreen,
            this.dgvBlue,
            this.dgvX,
            this.dgvY,
            this.dgvReferencePassFail,
            this.dvgReferenceRange,
            this.dgvReferenceRemove});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Location = new System.Drawing.Point(5, 28);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 62;
            this.dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(405, 281);
            this.dgv.TabIndex = 10;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
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
            this.SplitContainer2.Location = new System.Drawing.Point(597, 100);
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
            this.SplitContainer2.SplitterDistance = 262;
            this.SplitContainer2.TabIndex = 38;
            // 
            // dgvTest
            // 
            this.dgvTest.AllowUserToAddRows = false;
            this.dgvTest.AllowUserToResizeRows = false;
            this.dgvTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTest.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColorTestRed,
            this.dgvColorTestGreen,
            this.dgvColorTestBlue,
            this.dgvXTest,
            this.dgvYTest,
            this.dgvPassFail,
            this.dvgRange});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTest.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTest.Location = new System.Drawing.Point(2, 23);
            this.dgvTest.Name = "dgvTest";
            this.dgvTest.RowHeadersWidth = 62;
            this.dgvTest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTest.Size = new System.Drawing.Size(405, 278);
            this.dgvTest.TabIndex = 11;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Location = new System.Drawing.Point(1016, 20);
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
            // dgvRed
            // 
            this.dgvRed.HeaderText = "Red";
            this.dgvRed.MinimumWidth = 8;
            this.dgvRed.Name = "dgvRed";
            // 
            // dgvGreen
            // 
            this.dgvGreen.HeaderText = "Green";
            this.dgvGreen.MinimumWidth = 8;
            this.dgvGreen.Name = "dgvGreen";
            // 
            // dgvBlue
            // 
            this.dgvBlue.HeaderText = "Blue";
            this.dgvBlue.MinimumWidth = 8;
            this.dgvBlue.Name = "dgvBlue";
            // 
            // dgvX
            // 
            this.dgvX.HeaderText = "X";
            this.dgvX.MinimumWidth = 8;
            this.dgvX.Name = "dgvX";
            // 
            // dgvY
            // 
            this.dgvY.HeaderText = "Y";
            this.dgvY.MinimumWidth = 8;
            this.dgvY.Name = "dgvY";
            // 
            // dgvReferencePassFail
            // 
            this.dgvReferencePassFail.HeaderText = "Status";
            this.dgvReferencePassFail.MinimumWidth = 8;
            this.dgvReferencePassFail.Name = "dgvReferencePassFail";
            // 
            // dvgReferenceRange
            // 
            this.dvgReferenceRange.HeaderText = "Points";
            this.dvgReferenceRange.MinimumWidth = 8;
            this.dvgReferenceRange.Name = "dvgReferenceRange";
            // 
            // dgvReferenceRemove
            // 
            this.dgvReferenceRemove.HeaderText = "Remove";
            this.dgvReferenceRemove.MinimumWidth = 8;
            this.dgvReferenceRemove.Name = "dgvReferenceRemove";
            this.dgvReferenceRemove.Text = "Remove";
            // 
            // dgvColorTestRed
            // 
            this.dgvColorTestRed.HeaderText = "Red";
            this.dgvColorTestRed.MinimumWidth = 8;
            this.dgvColorTestRed.Name = "dgvColorTestRed";
            // 
            // dgvColorTestGreen
            // 
            this.dgvColorTestGreen.HeaderText = "Green";
            this.dgvColorTestGreen.MinimumWidth = 8;
            this.dgvColorTestGreen.Name = "dgvColorTestGreen";
            // 
            // dgvColorTestBlue
            // 
            this.dgvColorTestBlue.HeaderText = "Blue";
            this.dgvColorTestBlue.MinimumWidth = 8;
            this.dgvColorTestBlue.Name = "dgvColorTestBlue";
            // 
            // dgvXTest
            // 
            this.dgvXTest.HeaderText = "X";
            this.dgvXTest.MinimumWidth = 8;
            this.dgvXTest.Name = "dgvXTest";
            // 
            // dgvYTest
            // 
            this.dgvYTest.HeaderText = "Y";
            this.dgvYTest.MinimumWidth = 8;
            this.dgvYTest.Name = "dgvYTest";
            // 
            // dgvPassFail
            // 
            this.dgvPassFail.HeaderText = "Status";
            this.dgvPassFail.MinimumWidth = 8;
            this.dgvPassFail.Name = "dgvPassFail";
            // 
            // dvgRange
            // 
            this.dvgRange.HeaderText = "Points";
            this.dvgRange.MinimumWidth = 8;
            this.dvgRange.Name = "dvgRange";
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 692);
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
        internal System.Windows.Forms.TextBox txtLogic;
        internal System.Windows.Forms.TextBox txtLogic2;
        internal System.Windows.Forms.TextBox txtLogic3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvGreen;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvBlue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvX;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvY;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvReferencePassFail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvgReferenceRange;
        private System.Windows.Forms.DataGridViewButtonColumn dgvReferenceRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColorTestRed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColorTestGreen;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColorTestBlue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvXTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvYTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPassFail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvgRange;
    }
}