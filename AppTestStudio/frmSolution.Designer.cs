namespace AppTestStudio
{
    partial class frmSolution
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
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            splitContainer1 = new SplitContainer();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            cmdAddImageToProject = new Button();
            label1 = new Label();
            lblProject = new Label();
            label2 = new Label();
            lblRunTime = new Label();
            grd = new DataGridView();
            colCurrent = new DataGridViewTextBoxColumn();
            colID = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colAction = new DataGridViewTextBoxColumn();
            colPosition = new DataGridViewTextBoxColumn();
            colX = new DataGridViewTextBoxColumn();
            colY = new DataGridViewTextBoxColumn();
            colXTime = new DataGridViewTextBoxColumn();
            colTime = new DataGridViewTextBoxColumn();
            colCTime = new DataGridViewTextBoxColumn();
            grdTiming = new DataGridView();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdTiming).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(2, 2);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(721, 413);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(8, 620);
            textBox1.Margin = new Padding(2);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(765, 599);
            textBox1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.AutoScroll = true;
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            splitContainer1.Panel1.Controls.Add(textBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(flowLayoutPanel1);
            splitContainer1.Size = new Size(1566, 758);
            splitContainer1.SplitterDistance = 803;
            splitContainer1.SplitterWidth = 3;
            splitContainer1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Controls.Add(grd);
            flowLayoutPanel1.Controls.Add(grdTiming);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(760, 758);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.Controls.Add(cmdAddImageToProject);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblProject);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lblRunTime);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(741, 94);
            panel1.TabIndex = 13;
            // 
            // cmdAddImageToProject
            // 
            cmdAddImageToProject.Location = new Point(479, 9);
            cmdAddImageToProject.Name = "cmdAddImageToProject";
            cmdAddImageToProject.Size = new Size(270, 52);
            cmdAddImageToProject.TabIndex = 11;
            cmdAddImageToProject.Text = "Add Image to Project";
            cmdAddImageToProject.UseVisualStyleBackColor = true;
            cmdAddImageToProject.Click += cmdAddImageToProject_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 10);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 2;
            label1.Text = "Project";
            // 
            // lblProject
            // 
            lblProject.AutoSize = true;
            lblProject.Location = new Point(71, 9);
            lblProject.Margin = new Padding(2, 0, 2, 0);
            lblProject.Name = "lblProject";
            lblProject.Size = new Size(57, 15);
            lblProject.TabIndex = 3;
            lblProject.Text = "lblProject";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 28);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 4;
            label2.Text = "RunTime";
            // 
            // lblRunTime
            // 
            lblRunTime.AutoSize = true;
            lblRunTime.Location = new Point(71, 28);
            lblRunTime.Margin = new Padding(2, 0, 2, 0);
            lblRunTime.Name = "lblRunTime";
            lblRunTime.Size = new Size(68, 15);
            lblRunTime.TabIndex = 5;
            lblRunTime.Text = "lblRunTime";
            // 
            // grd
            // 
            grd.AllowUserToAddRows = false;
            grd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grd.Columns.AddRange(new DataGridViewColumn[] { colCurrent, colID, colName, colAction, colPosition, colX, colY, colXTime, colTime, colCTime });
            grd.Location = new Point(2, 102);
            grd.Margin = new Padding(2);
            grd.Name = "grd";
            grd.ReadOnly = true;
            grd.RowHeadersVisible = false;
            grd.RowHeadersWidth = 62;
            grd.Size = new Size(742, 211);
            grd.TabIndex = 6;
            grd.CellMouseDown += grd_CellMouseDown;
            grd.CellMouseEnter += grd_CellMouseEnter;
            // 
            // colCurrent
            // 
            colCurrent.Frozen = true;
            colCurrent.HeaderText = "->";
            colCurrent.MinimumWidth = 36;
            colCurrent.Name = "colCurrent";
            colCurrent.ReadOnly = true;
            colCurrent.Width = 36;
            // 
            // colID
            // 
            colID.Frozen = true;
            colID.HeaderText = "ID";
            colID.MinimumWidth = 60;
            colID.Name = "colID";
            colID.ReadOnly = true;
            colID.Width = 60;
            // 
            // colName
            // 
            colName.Frozen = true;
            colName.HeaderText = "Name";
            colName.MinimumWidth = 80;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 250;
            // 
            // colAction
            // 
            colAction.Frozen = true;
            colAction.HeaderText = "Action";
            colAction.MinimumWidth = 80;
            colAction.Name = "colAction";
            colAction.ReadOnly = true;
            colAction.Width = 220;
            // 
            // colPosition
            // 
            colPosition.Frozen = true;
            colPosition.HeaderText = "Pos";
            colPosition.MinimumWidth = 80;
            colPosition.Name = "colPosition";
            colPosition.ReadOnly = true;
            colPosition.Width = 80;
            // 
            // colX
            // 
            colX.Frozen = true;
            colX.HeaderText = "X";
            colX.MinimumWidth = 65;
            colX.Name = "colX";
            colX.ReadOnly = true;
            colX.Width = 65;
            // 
            // colY
            // 
            colY.HeaderText = "Y";
            colY.MinimumWidth = 65;
            colY.Name = "colY";
            colY.ReadOnly = true;
            colY.Width = 65;
            // 
            // colXTime
            // 
            colXTime.HeaderText = "Execution Time";
            colXTime.Name = "colXTime";
            colXTime.ReadOnly = true;
            // 
            // colTime
            // 
            colTime.HeaderText = "Time (ms)";
            colTime.MinimumWidth = 100;
            colTime.Name = "colTime";
            colTime.ReadOnly = true;
            colTime.Width = 150;
            // 
            // colCTime
            // 
            colCTime.HeaderText = "T Time (ms)";
            colCTime.MinimumWidth = 8;
            colCTime.Name = "colCTime";
            colCTime.ReadOnly = true;
            colCTime.Width = 150;
            // 
            // grdTiming
            // 
            grdTiming.AllowUserToAddRows = false;
            grdTiming.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdTiming.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn9 });
            grdTiming.Location = new Point(2, 317);
            grdTiming.Margin = new Padding(2);
            grdTiming.Name = "grdTiming";
            grdTiming.ReadOnly = true;
            grdTiming.RowHeadersVisible = false;
            grdTiming.RowHeadersWidth = 62;
            grdTiming.Size = new Size(742, 430);
            grdTiming.TabIndex = 14;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.Frozen = true;
            dataGridViewTextBoxColumn3.HeaderText = "Name";
            dataGridViewTextBoxColumn3.MinimumWidth = 80;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 250;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.HeaderText = "Time (ms)";
            dataGridViewTextBoxColumn9.MinimumWidth = 100;
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.ReadOnly = true;
            dataGridViewTextBoxColumn9.Width = 150;
            // 
            // frmSolution
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1566, 758);
            Controls.Add(splitContainer1);
            Margin = new Padding(2);
            Name = "frmSolution";
            Text = "Solution Viewer";
            Load += frmSolution_Load;
            Resize += frmSolution_Resize;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grd).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdTiming).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox textBox1;
        private SplitContainer splitContainer1;
        private Label label1;
        private Label lblRunTime;
        private Label label2;
        private Label lblProject;
        private DataGridView grd;
        private Button cmdAddImageToProject;
        private DataGridViewTextBoxColumn colCurrent;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colAction;
        private DataGridViewTextBoxColumn colPosition;
        private DataGridViewTextBoxColumn colX;
        private DataGridViewTextBoxColumn colY;
        private DataGridViewTextBoxColumn colXTime;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colCTime;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private DataGridView grdTiming;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}