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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            lblPoints = new Label();
            PictureBoxTest = new PictureBox();
            PanelTest = new Panel();
            lblTestWindow = new Label();
            SplitContainer4 = new SplitContainer();
            PictureBox1 = new PictureBox();
            PanelScreenshot = new Panel();
            lblReference = new Label();
            SplitContainer3 = new SplitContainer();
            SplitContainer1 = new SplitContainer();
            cmdRetest = new Button();
            Label3 = new Label();
            Label2 = new Label();
            dgv = new DataGridView();
            dgvRed = new DataGridViewTextBoxColumn();
            dgvGreen = new DataGridViewTextBoxColumn();
            dgvBlue = new DataGridViewTextBoxColumn();
            dgvX = new DataGridViewTextBoxColumn();
            dgvY = new DataGridViewTextBoxColumn();
            dgvReferencePassFail = new DataGridViewTextBoxColumn();
            dvgReferenceRange = new DataGridViewTextBoxColumn();
            dgvReferenceRemove = new DataGridViewButtonColumn();
            txtResolution = new TextBox();
            txtResult = new TextBox();
            SplitContainer2 = new SplitContainer();
            dgvTest = new DataGridView();
            dgvColorTestRed = new DataGridViewTextBoxColumn();
            dgvColorTestGreen = new DataGridViewTextBoxColumn();
            dgvColorTestBlue = new DataGridViewTextBoxColumn();
            dgvXTest = new DataGridViewTextBoxColumn();
            dgvYTest = new DataGridViewTextBoxColumn();
            dgvPassFail = new DataGridViewTextBoxColumn();
            dvgRange = new DataGridViewTextBoxColumn();
            cmdClose = new Button();
            txtLogic = new TextBox();
            txtLogic2 = new TextBox();
            txtLogic3 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)PictureBoxTest).BeginInit();
            PanelTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SplitContainer4).BeginInit();
            SplitContainer4.Panel1.SuspendLayout();
            SplitContainer4.Panel2.SuspendLayout();
            SplitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            PanelScreenshot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SplitContainer3).BeginInit();
            SplitContainer3.Panel1.SuspendLayout();
            SplitContainer3.Panel2.SuspendLayout();
            SplitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SplitContainer1).BeginInit();
            SplitContainer1.Panel1.SuspendLayout();
            SplitContainer1.Panel2.SuspendLayout();
            SplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SplitContainer2).BeginInit();
            SplitContainer2.Panel1.SuspendLayout();
            SplitContainer2.Panel2.SuspendLayout();
            SplitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTest).BeginInit();
            SuspendLayout();
            // 
            // lblPoints
            // 
            lblPoints.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPoints.AutoSize = true;
            lblPoints.Location = new Point(1211, 414);
            lblPoints.Margin = new Padding(4, 0, 4, 0);
            lblPoints.Name = "lblPoints";
            lblPoints.Size = new Size(41, 15);
            lblPoints.TabIndex = 42;
            lblPoints.Text = "Label1";
            // 
            // PictureBoxTest
            // 
            PictureBoxTest.Location = new Point(0, 0);
            PictureBoxTest.Margin = new Padding(4, 3, 4, 3);
            PictureBoxTest.Name = "PictureBoxTest";
            PictureBoxTest.Size = new Size(100, 50);
            PictureBoxTest.SizeMode = PictureBoxSizeMode.AutoSize;
            PictureBoxTest.TabIndex = 0;
            PictureBoxTest.TabStop = false;
            PictureBoxTest.Paint += PictureBoxTest_Paint;
            // 
            // PanelTest
            // 
            PanelTest.AutoScroll = true;
            PanelTest.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PanelTest.Controls.Add(PictureBoxTest);
            PanelTest.Dock = DockStyle.Fill;
            PanelTest.Location = new Point(0, 0);
            PanelTest.Margin = new Padding(4, 3, 4, 3);
            PanelTest.Name = "PanelTest";
            PanelTest.Size = new Size(676, 343);
            PanelTest.TabIndex = 9;
            // 
            // lblTestWindow
            // 
            lblTestWindow.AutoSize = true;
            lblTestWindow.Dock = DockStyle.Left;
            lblTestWindow.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTestWindow.Location = new Point(0, 0);
            lblTestWindow.Margin = new Padding(4, 0, 4, 0);
            lblTestWindow.Name = "lblTestWindow";
            lblTestWindow.Size = new Size(120, 24);
            lblTestWindow.TabIndex = 1;
            lblTestWindow.Text = "Test Window";
            // 
            // SplitContainer4
            // 
            SplitContainer4.Dock = DockStyle.Fill;
            SplitContainer4.Location = new Point(0, 0);
            SplitContainer4.Margin = new Padding(4, 3, 4, 3);
            SplitContainer4.Name = "SplitContainer4";
            SplitContainer4.Orientation = Orientation.Horizontal;
            // 
            // SplitContainer4.Panel1
            // 
            SplitContainer4.Panel1.Controls.Add(lblTestWindow);
            // 
            // SplitContainer4.Panel2
            // 
            SplitContainer4.Panel2.Controls.Add(PanelTest);
            SplitContainer4.Size = new Size(676, 377);
            SplitContainer4.SplitterDistance = 29;
            SplitContainer4.SplitterWidth = 5;
            SplitContainer4.TabIndex = 10;
            // 
            // PictureBox1
            // 
            PictureBox1.Location = new Point(0, 0);
            PictureBox1.Margin = new Padding(4, 3, 4, 3);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new Size(100, 50);
            PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            PictureBox1.TabIndex = 0;
            PictureBox1.TabStop = false;
            PictureBox1.Paint += PictureBox1_Paint;
            // 
            // PanelScreenshot
            // 
            PanelScreenshot.AutoScroll = true;
            PanelScreenshot.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PanelScreenshot.Controls.Add(PictureBox1);
            PanelScreenshot.Dock = DockStyle.Fill;
            PanelScreenshot.Location = new Point(0, 0);
            PanelScreenshot.Margin = new Padding(4, 3, 4, 3);
            PanelScreenshot.Name = "PanelScreenshot";
            PanelScreenshot.Size = new Size(676, 350);
            PanelScreenshot.TabIndex = 8;
            // 
            // lblReference
            // 
            lblReference.AutoSize = true;
            lblReference.Dock = DockStyle.Left;
            lblReference.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReference.Location = new Point(0, 0);
            lblReference.Margin = new Padding(4, 0, 4, 0);
            lblReference.Name = "lblReference";
            lblReference.Size = new Size(98, 24);
            lblReference.TabIndex = 0;
            lblReference.Text = "Reference";
            // 
            // SplitContainer3
            // 
            SplitContainer3.Dock = DockStyle.Fill;
            SplitContainer3.Location = new Point(0, 0);
            SplitContainer3.Margin = new Padding(4, 3, 4, 3);
            SplitContainer3.Name = "SplitContainer3";
            SplitContainer3.Orientation = Orientation.Horizontal;
            // 
            // SplitContainer3.Panel1
            // 
            SplitContainer3.Panel1.Controls.Add(lblReference);
            // 
            // SplitContainer3.Panel2
            // 
            SplitContainer3.Panel2.Controls.Add(PanelScreenshot);
            SplitContainer3.Size = new Size(676, 384);
            SplitContainer3.SplitterDistance = 29;
            SplitContainer3.SplitterWidth = 5;
            SplitContainer3.TabIndex = 9;
            // 
            // SplitContainer1
            // 
            SplitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SplitContainer1.Location = new Point(19, 115);
            SplitContainer1.Margin = new Padding(4, 3, 4, 3);
            SplitContainer1.Name = "SplitContainer1";
            SplitContainer1.Orientation = Orientation.Horizontal;
            // 
            // SplitContainer1.Panel1
            // 
            SplitContainer1.Panel1.Controls.Add(SplitContainer3);
            // 
            // SplitContainer1.Panel2
            // 
            SplitContainer1.Panel2.Controls.Add(SplitContainer4);
            SplitContainer1.Size = new Size(676, 766);
            SplitContainer1.SplitterDistance = 384;
            SplitContainer1.SplitterWidth = 5;
            SplitContainer1.TabIndex = 37;
            // 
            // cmdRetest
            // 
            cmdRetest.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmdRetest.Location = new Point(1185, 62);
            cmdRetest.Margin = new Padding(4, 3, 4, 3);
            cmdRetest.Name = "cmdRetest";
            cmdRetest.Size = new Size(71, 27);
            cmdRetest.TabIndex = 43;
            cmdRetest.Text = "Re-Test";
            cmdRetest.UseVisualStyleBackColor = true;
            cmdRetest.Click += cmdRetest_Click;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label3.Location = new Point(5, 0);
            Label3.Margin = new Padding(4, 0, 4, 0);
            Label3.Name = "Label3";
            Label3.Size = new Size(179, 24);
            Label3.TabIndex = 12;
            Label3.Text = "Test Window Colors";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label2.Location = new Point(5, 5);
            Label2.Margin = new Padding(4, 0, 4, 0);
            Label2.Name = "Label2";
            Label2.Size = new Size(98, 24);
            Label2.TabIndex = 11;
            Label2.Text = "Reference";
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv.ColumnHeadersHeight = 34;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.Columns.AddRange(new DataGridViewColumn[] { dgvRed, dgvGreen, dgvBlue, dgvX, dgvY, dgvReferencePassFail, dvgReferenceRange, dgvReferenceRemove });
            dgv.Cursor = Cursors.Hand;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgv.DefaultCellStyle = dataGridViewCellStyle2;
            dgv.Location = new Point(6, 32);
            dgv.Margin = new Padding(4, 3, 4, 3);
            dgv.MultiSelect = false;
            dgv.Name = "dgv";
            dgv.RowHeadersWidth = 62;
            dgv.ScrollBars = ScrollBars.Vertical;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(472, 261);
            dgv.TabIndex = 10;
            dgv.CellClick += dgv_CellClick;
            dgv.CellContentClick += dgv_CellContentClick;
            dgv.SelectionChanged += dgv_SelectionChanged;
            // 
            // dgvRed
            // 
            dgvRed.HeaderText = "Red";
            dgvRed.MinimumWidth = 8;
            dgvRed.Name = "dgvRed";
            // 
            // dgvGreen
            // 
            dgvGreen.HeaderText = "Green";
            dgvGreen.MinimumWidth = 8;
            dgvGreen.Name = "dgvGreen";
            // 
            // dgvBlue
            // 
            dgvBlue.HeaderText = "Blue";
            dgvBlue.MinimumWidth = 8;
            dgvBlue.Name = "dgvBlue";
            // 
            // dgvX
            // 
            dgvX.HeaderText = "X";
            dgvX.MinimumWidth = 8;
            dgvX.Name = "dgvX";
            // 
            // dgvY
            // 
            dgvY.HeaderText = "Y";
            dgvY.MinimumWidth = 8;
            dgvY.Name = "dgvY";
            // 
            // dgvReferencePassFail
            // 
            dgvReferencePassFail.HeaderText = "Status";
            dgvReferencePassFail.MinimumWidth = 8;
            dgvReferencePassFail.Name = "dgvReferencePassFail";
            // 
            // dvgReferenceRange
            // 
            dvgReferenceRange.HeaderText = "Points";
            dvgReferenceRange.MinimumWidth = 8;
            dvgReferenceRange.Name = "dvgReferenceRange";
            // 
            // dgvReferenceRemove
            // 
            dgvReferenceRemove.HeaderText = "Remove";
            dgvReferenceRemove.MinimumWidth = 8;
            dgvReferenceRemove.Name = "dgvReferenceRemove";
            dgvReferenceRemove.Text = "Remove";
            // 
            // txtResolution
            // 
            txtResolution.BorderStyle = BorderStyle.None;
            txtResolution.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtResolution.Location = new Point(532, 1);
            txtResolution.Margin = new Padding(4, 3, 4, 3);
            txtResolution.Name = "txtResolution";
            txtResolution.ReadOnly = true;
            txtResolution.Size = new Size(496, 22);
            txtResolution.TabIndex = 41;
            txtResolution.TextAlign = HorizontalAlignment.Center;
            // 
            // txtResult
            // 
            txtResult.BackColor = SystemColors.AppWorkspace;
            txtResult.BorderStyle = BorderStyle.None;
            txtResult.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtResult.Location = new Point(21, 1);
            txtResult.Margin = new Padding(4, 3, 4, 3);
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.Size = new Size(496, 22);
            txtResult.TabIndex = 40;
            txtResult.TextAlign = HorizontalAlignment.Center;
            // 
            // SplitContainer2
            // 
            SplitContainer2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SplitContainer2.Location = new Point(696, 115);
            SplitContainer2.Margin = new Padding(4, 3, 4, 3);
            SplitContainer2.Name = "SplitContainer2";
            SplitContainer2.Orientation = Orientation.Horizontal;
            // 
            // SplitContainer2.Panel1
            // 
            SplitContainer2.Panel1.Controls.Add(Label2);
            SplitContainer2.Panel1.Controls.Add(dgv);
            // 
            // SplitContainer2.Panel2
            // 
            SplitContainer2.Panel2.Controls.Add(Label3);
            SplitContainer2.Panel2.Controls.Add(dgvTest);
            SplitContainer2.Size = new Size(479, 610);
            SplitContainer2.SplitterDistance = 298;
            SplitContainer2.SplitterWidth = 5;
            SplitContainer2.TabIndex = 38;
            // 
            // dgvTest
            // 
            dgvTest.AllowUserToAddRows = false;
            dgvTest.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvTest.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTest.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvTest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvTest.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvTest.Columns.AddRange(new DataGridViewColumn[] { dgvColorTestRed, dgvColorTestGreen, dgvColorTestBlue, dgvXTest, dgvYTest, dgvPassFail, dvgRange });
            dgvTest.Cursor = Cursors.Hand;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvTest.DefaultCellStyle = dataGridViewCellStyle4;
            dgvTest.Location = new Point(2, 27);
            dgvTest.Margin = new Padding(4, 3, 4, 3);
            dgvTest.Name = "dgvTest";
            dgvTest.RowHeadersWidth = 62;
            dgvTest.ScrollBars = ScrollBars.Vertical;
            dgvTest.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTest.Size = new Size(472, 275);
            dgvTest.TabIndex = 11;
            dgvTest.SelectionChanged += dgvTest_SelectionChanged;
            // 
            // dgvColorTestRed
            // 
            dgvColorTestRed.HeaderText = "Red";
            dgvColorTestRed.MinimumWidth = 8;
            dgvColorTestRed.Name = "dgvColorTestRed";
            // 
            // dgvColorTestGreen
            // 
            dgvColorTestGreen.HeaderText = "Green";
            dgvColorTestGreen.MinimumWidth = 8;
            dgvColorTestGreen.Name = "dgvColorTestGreen";
            // 
            // dgvColorTestBlue
            // 
            dgvColorTestBlue.HeaderText = "Blue";
            dgvColorTestBlue.MinimumWidth = 8;
            dgvColorTestBlue.Name = "dgvColorTestBlue";
            // 
            // dgvXTest
            // 
            dgvXTest.HeaderText = "X";
            dgvXTest.MinimumWidth = 8;
            dgvXTest.Name = "dgvXTest";
            // 
            // dgvYTest
            // 
            dgvYTest.HeaderText = "Y";
            dgvYTest.MinimumWidth = 8;
            dgvYTest.Name = "dgvYTest";
            // 
            // dgvPassFail
            // 
            dgvPassFail.HeaderText = "Status";
            dgvPassFail.MinimumWidth = 8;
            dgvPassFail.Name = "dgvPassFail";
            // 
            // dvgRange
            // 
            dvgRange.HeaderText = "Points";
            dvgRange.MinimumWidth = 8;
            dvgRange.Name = "dvgRange";
            // 
            // cmdClose
            // 
            cmdClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmdClose.Location = new Point(1185, 23);
            cmdClose.Margin = new Padding(4, 3, 4, 3);
            cmdClose.Name = "cmdClose";
            cmdClose.Size = new Size(71, 31);
            cmdClose.TabIndex = 36;
            cmdClose.Text = "Close";
            cmdClose.UseVisualStyleBackColor = true;
            cmdClose.Click += cmdClose_Click;
            // 
            // txtLogic
            // 
            txtLogic.BackColor = SystemColors.AppWorkspace;
            txtLogic.BorderStyle = BorderStyle.None;
            txtLogic.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtLogic.Location = new Point(21, 25);
            txtLogic.Margin = new Padding(4, 3, 4, 3);
            txtLogic.Name = "txtLogic";
            txtLogic.ReadOnly = true;
            txtLogic.Size = new Size(1007, 19);
            txtLogic.TabIndex = 41;
            txtLogic.TextAlign = HorizontalAlignment.Center;
            // 
            // txtLogic2
            // 
            txtLogic2.BackColor = SystemColors.ActiveCaption;
            txtLogic2.BorderStyle = BorderStyle.None;
            txtLogic2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtLogic2.Location = new Point(21, 50);
            txtLogic2.Margin = new Padding(4, 3, 4, 3);
            txtLogic2.Name = "txtLogic2";
            txtLogic2.ReadOnly = true;
            txtLogic2.Size = new Size(1007, 19);
            txtLogic2.TabIndex = 41;
            txtLogic2.TextAlign = HorizontalAlignment.Center;
            // 
            // txtLogic3
            // 
            txtLogic3.BorderStyle = BorderStyle.None;
            txtLogic3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtLogic3.Location = new Point(21, 75);
            txtLogic3.Margin = new Padding(4, 3, 4, 3);
            txtLogic3.Name = "txtLogic3";
            txtLogic3.ReadOnly = true;
            txtLogic3.Size = new Size(1007, 19);
            txtLogic3.TabIndex = 41;
            txtLogic3.TextAlign = HorizontalAlignment.Center;
            // 
            // frmTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1278, 892);
            Controls.Add(lblPoints);
            Controls.Add(SplitContainer1);
            Controls.Add(cmdRetest);
            Controls.Add(txtLogic3);
            Controls.Add(txtLogic2);
            Controls.Add(txtLogic);
            Controls.Add(txtResolution);
            Controls.Add(txtResult);
            Controls.Add(SplitContainer2);
            Controls.Add(cmdClose);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmTest";
            Text = "Single Test";
            ((System.ComponentModel.ISupportInitialize)PictureBoxTest).EndInit();
            PanelTest.ResumeLayout(false);
            PanelTest.PerformLayout();
            SplitContainer4.Panel1.ResumeLayout(false);
            SplitContainer4.Panel1.PerformLayout();
            SplitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SplitContainer4).EndInit();
            SplitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            PanelScreenshot.ResumeLayout(false);
            PanelScreenshot.PerformLayout();
            SplitContainer3.Panel1.ResumeLayout(false);
            SplitContainer3.Panel1.PerformLayout();
            SplitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SplitContainer3).EndInit();
            SplitContainer3.ResumeLayout(false);
            SplitContainer1.Panel1.ResumeLayout(false);
            SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SplitContainer1).EndInit();
            SplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            SplitContainer2.Panel1.ResumeLayout(false);
            SplitContainer2.Panel1.PerformLayout();
            SplitContainer2.Panel2.ResumeLayout(false);
            SplitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SplitContainer2).EndInit();
            SplitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTest).EndInit();
            ResumeLayout(false);
            PerformLayout();

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