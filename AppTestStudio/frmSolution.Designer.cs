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
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            splitContainer1 = new SplitContainer();
            hScrollBar1 = new HScrollBar();
            cmdAnimate = new Button();
            lblCurrent = new Label();
            grd = new DataGridView();
            colCurrent = new DataGridViewTextBoxColumn();
            colID = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colAction = new DataGridViewTextBoxColumn();
            colX = new DataGridViewTextBoxColumn();
            colY = new DataGridViewTextBoxColumn();
            colTime = new DataGridViewTextBoxColumn();
            colCTime = new DataGridViewTextBoxColumn();
            lblRunTime = new Label();
            label2 = new Label();
            lblProject = new Label();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grd).BeginInit();
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
            splitContainer1.Panel2.Controls.Add(hScrollBar1);
            splitContainer1.Panel2.Controls.Add(cmdAnimate);
            splitContainer1.Panel2.Controls.Add(lblCurrent);
            splitContainer1.Panel2.Controls.Add(grd);
            splitContainer1.Panel2.Controls.Add(lblRunTime);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(lblProject);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Size = new Size(1566, 758);
            splitContainer1.SplitterDistance = 803;
            splitContainer1.SplitterWidth = 3;
            splitContainer1.TabIndex = 2;
            // 
            // hScrollBar1
            // 
            hScrollBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            hScrollBar1.Location = new Point(3, 86);
            hScrollBar1.Maximum = 500;
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(758, 39);
            hScrollBar1.TabIndex = 10;
            // 
            // cmdAnimate
            // 
            cmdAnimate.Enabled = false;
            cmdAnimate.Location = new Point(70, 54);
            cmdAnimate.Margin = new Padding(2);
            cmdAnimate.Name = "cmdAnimate";
            cmdAnimate.Size = new Size(78, 20);
            cmdAnimate.TabIndex = 9;
            cmdAnimate.Text = "Animate";
            cmdAnimate.UseVisualStyleBackColor = true;
            cmdAnimate.Click += cmdAnimate_Click;
            // 
            // lblCurrent
            // 
            lblCurrent.AutoSize = true;
            lblCurrent.Location = new Point(9, 59);
            lblCurrent.Margin = new Padding(2, 0, 2, 0);
            lblCurrent.Name = "lblCurrent";
            lblCurrent.Size = new Size(47, 15);
            lblCurrent.TabIndex = 8;
            lblCurrent.Text = "Current";
            // 
            // grd
            // 
            grd.AllowUserToAddRows = false;
            grd.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grd.Columns.AddRange(new DataGridViewColumn[] { colCurrent, colID, colName, colAction, colX, colY, colTime, colCTime });
            grd.Location = new Point(7, 127);
            grd.Margin = new Padding(2);
            grd.Name = "grd";
            grd.ReadOnly = true;
            grd.RowHeadersVisible = false;
            grd.RowHeadersWidth = 62;
            grd.Size = new Size(752, 629);
            grd.TabIndex = 6;
            grd.CellMouseDown += grd_CellMouseDown;
            grd.CellMouseEnter += grd_CellMouseEnter;
            // 
            // colCurrent
            // 
            colCurrent.HeaderText = "->";
            colCurrent.MinimumWidth = 36;
            colCurrent.Name = "colCurrent";
            colCurrent.ReadOnly = true;
            colCurrent.Width = 36;
            // 
            // colID
            // 
            colID.HeaderText = "ID";
            colID.MinimumWidth = 60;
            colID.Name = "colID";
            colID.ReadOnly = true;
            colID.Width = 60;
            // 
            // colName
            // 
            colName.HeaderText = "Name";
            colName.MinimumWidth = 80;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 250;
            // 
            // colAction
            // 
            colAction.HeaderText = "Action";
            colAction.MinimumWidth = 80;
            colAction.Name = "colAction";
            colAction.ReadOnly = true;
            colAction.Width = 250;
            // 
            // colX
            // 
            colX.HeaderText = "X";
            colX.MinimumWidth = 80;
            colX.Name = "colX";
            colX.ReadOnly = true;
            colX.Width = 80;
            // 
            // colY
            // 
            colY.HeaderText = "Y";
            colY.MinimumWidth = 80;
            colY.Name = "colY";
            colY.ReadOnly = true;
            colY.Width = 80;
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
            // lblRunTime
            // 
            lblRunTime.AutoSize = true;
            lblRunTime.Location = new Point(70, 26);
            lblRunTime.Margin = new Padding(2, 0, 2, 0);
            lblRunTime.Name = "lblRunTime";
            lblRunTime.Size = new Size(68, 15);
            lblRunTime.TabIndex = 5;
            lblRunTime.Text = "lblRunTime";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 26);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 4;
            label2.Text = "RunTime";
            // 
            // lblProject
            // 
            lblProject.AutoSize = true;
            lblProject.Location = new Point(70, 7);
            lblProject.Margin = new Padding(2, 0, 2, 0);
            lblProject.Name = "lblProject";
            lblProject.Size = new Size(57, 15);
            lblProject.TabIndex = 3;
            lblProject.Text = "lblProject";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 8);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 2;
            label1.Text = "Project";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // frmSolution
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1566, 758);
            Controls.Add(splitContainer1);
            Margin = new Padding(2);
            Name = "frmSolution";
            Text = "frmSolution";
            Load += frmSolution_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grd).EndInit();
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
        private DataGridViewTextBoxColumn colCurrent;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colAction;
        private DataGridViewTextBoxColumn colX;
        private DataGridViewTextBoxColumn colY;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colCTime;
        private Button cmdAnimate;
        private Label lblCurrent;
        private HScrollBar hScrollBar1;
        private System.Windows.Forms.Timer timer1;
    }
}