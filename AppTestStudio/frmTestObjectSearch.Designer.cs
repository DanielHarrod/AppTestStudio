namespace AppTestStudio
{
    partial class frmTestObjectSearch
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
            this.Button1 = new System.Windows.Forms.Button();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.PictureBoxObject = new System.Windows.Forms.PictureBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.cboChannel = new System.Windows.Forms.ComboBox();
            this.cmdChannel = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.NumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.cmdSetAcceptanceThreshold = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lblHideAndSeek = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.lblPoint = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.lblDetectedThreashold = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.TabControl2 = new System.Windows.Forms.TabControl();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.PanelScreenshot = new System.Windows.Forms.Panel();
            this.PictureBoxSearchArea = new System.Windows.Forms.PictureBox();
            this.TabPage4 = new System.Windows.Forms.TabPage();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.TabPage5 = new System.Windows.Forms.TabPage();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.TabPage6 = new System.Windows.Forms.TabPage();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.PictureBox3 = new System.Windows.Forms.PictureBox();
            this.cmdUpdateScreenshot = new System.Windows.Forms.Button();
            this.GroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxObject)).BeginInit();
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown1)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.TabControl2.SuspendLayout();
            this.TabPage3.SuspendLayout();
            this.PanelScreenshot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxSearchArea)).BeginInit();
            this.TabPage4.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.TabPage5.SuspendLayout();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.TabPage6.SuspendLayout();
            this.Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 500;
            // 
            // Button1
            // 
            this.Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button1.Location = new System.Drawing.Point(809, 68);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(222, 24);
            this.Button1.TabIndex = 53;
            this.Button1.Text = "Re-Test From Reference";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox4.Controls.Add(this.PictureBoxObject);
            this.GroupBox4.Location = new System.Drawing.Point(808, 328);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(222, 139);
            this.GroupBox4.TabIndex = 52;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Search Object";
            // 
            // PictureBoxObject
            // 
            this.PictureBoxObject.Location = new System.Drawing.Point(11, 19);
            this.PictureBoxObject.Name = "PictureBoxObject";
            this.PictureBoxObject.Size = new System.Drawing.Size(106, 50);
            this.PictureBoxObject.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBoxObject.TabIndex = 9;
            this.PictureBoxObject.TabStop = false;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox3.Controls.Add(this.cboChannel);
            this.GroupBox3.Controls.Add(this.cmdChannel);
            this.GroupBox3.Location = new System.Drawing.Point(809, 160);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(222, 75);
            this.GroupBox3.TabIndex = 51;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Channel";
            // 
            // cboChannel
            // 
            this.cboChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChannel.FormattingEnabled = true;
            this.cboChannel.Items.AddRange(new object[] {
            "Red Channel",
            "Green Channel",
            "Blue Channel"});
            this.cboChannel.Location = new System.Drawing.Point(8, 19);
            this.cboChannel.Name = "cboChannel";
            this.cboChannel.Size = new System.Drawing.Size(204, 21);
            this.cboChannel.TabIndex = 4;
            this.cboChannel.SelectedIndexChanged += new System.EventHandler(this.cboChannel_SelectedIndexChanged);
            // 
            // cmdChannel
            // 
            this.cmdChannel.Location = new System.Drawing.Point(8, 45);
            this.cmdChannel.Name = "cmdChannel";
            this.cmdChannel.Size = new System.Drawing.Size(204, 23);
            this.cmdChannel.TabIndex = 19;
            this.cmdChannel.Text = "Use this Channel";
            this.cmdChannel.UseVisualStyleBackColor = true;
            this.cmdChannel.Click += new System.EventHandler(this.cmdChannel_Click);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox2.Controls.Add(this.NumericUpDown1);
            this.GroupBox2.Controls.Add(this.cmdSetAcceptanceThreshold);
            this.GroupBox2.Location = new System.Drawing.Point(808, 98);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(222, 56);
            this.GroupBox2.TabIndex = 50;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Acceptance Threshold";
            // 
            // NumericUpDown1
            // 
            this.NumericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NumericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericUpDown1.Location = new System.Drawing.Point(11, 19);
            this.NumericUpDown1.Name = "NumericUpDown1";
            this.NumericUpDown1.Size = new System.Drawing.Size(59, 30);
            this.NumericUpDown1.TabIndex = 12;
            this.NumericUpDown1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // cmdSetAcceptanceThreshold
            // 
            this.cmdSetAcceptanceThreshold.Location = new System.Drawing.Point(85, 22);
            this.cmdSetAcceptanceThreshold.Name = "cmdSetAcceptanceThreshold";
            this.cmdSetAcceptanceThreshold.Size = new System.Drawing.Size(131, 23);
            this.cmdSetAcceptanceThreshold.TabIndex = 19;
            this.cmdSetAcceptanceThreshold.Text = "Use this Threshold";
            this.cmdSetAcceptanceThreshold.UseVisualStyleBackColor = true;
            this.cmdSetAcceptanceThreshold.Click += new System.EventHandler(this.cmdSetAcceptanceThreshold_Click);
            // 
            // Label5
            // 
            this.Label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Red;
            this.Label5.Location = new System.Drawing.Point(805, 500);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(223, 50);
            this.Label5.TabIndex = 49;
            this.Label5.Text = "Always test on every screen!  This will ALWAYS identify Something.  Adjust the Th" +
    "reshold and Use the Mask Accordingly.";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.lblHideAndSeek);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.lblPoint);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.lblDetectedThreashold);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Location = new System.Drawing.Point(809, 241);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(222, 73);
            this.GroupBox1.TabIndex = 48;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Results";
            // 
            // lblHideAndSeek
            // 
            this.lblHideAndSeek.AutoSize = true;
            this.lblHideAndSeek.Location = new System.Drawing.Point(126, 53);
            this.lblHideAndSeek.Name = "lblHideAndSeek";
            this.lblHideAndSeek.Size = new System.Drawing.Size(83, 13);
            this.lblHideAndSeek.TabIndex = 5;
            this.lblHideAndSeek.Text = "lblHideAndSeek";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(7, 54);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(104, 13);
            this.Label6.TabIndex = 4;
            this.Label6.Text = "Hide and Seek Time";
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.Location = new System.Drawing.Point(126, 36);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(41, 13);
            this.lblPoint.TabIndex = 3;
            this.lblPoint.Text = "lblPoint";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(7, 37);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(31, 13);
            this.Label4.TabIndex = 2;
            this.Label4.Text = "Point";
            // 
            // lblDetectedThreashold
            // 
            this.lblDetectedThreashold.AutoSize = true;
            this.lblDetectedThreashold.Location = new System.Drawing.Point(126, 19);
            this.lblDetectedThreashold.Name = "lblDetectedThreashold";
            this.lblDetectedThreashold.Size = new System.Drawing.Size(108, 13);
            this.lblDetectedThreashold.TabIndex = 1;
            this.lblDetectedThreashold.Text = "lblDetectedThreshold";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(7, 20);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(101, 13);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Detected Threshold";
            // 
            // Label2
            // 
            this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Label2.Location = new System.Drawing.Point(805, 558);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(226, 50);
            this.Label2.TabIndex = 47;
            this.Label2.Text = "This test will find the closest result to the object.  Every situation is differe" +
    "nt set the threshold to the acceptable level to pass the test.";
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(18, 9);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(1013, 23);
            this.lblResult.TabIndex = 46;
            // 
            // TabControl2
            // 
            this.TabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl2.Controls.Add(this.TabPage3);
            this.TabControl2.Controls.Add(this.TabPage4);
            this.TabControl2.Controls.Add(this.TabPage5);
            this.TabControl2.Controls.Add(this.TabPage6);
            this.TabControl2.Location = new System.Drawing.Point(11, 43);
            this.TabControl2.Name = "TabControl2";
            this.TabControl2.SelectedIndex = 0;
            this.TabControl2.Size = new System.Drawing.Size(791, 569);
            this.TabControl2.TabIndex = 44;
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.PanelScreenshot);
            this.TabPage3.Location = new System.Drawing.Point(4, 22);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage3.Size = new System.Drawing.Size(783, 543);
            this.TabPage3.TabIndex = 0;
            this.TabPage3.Text = "Original";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // PanelScreenshot
            // 
            this.PanelScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelScreenshot.AutoScroll = true;
            this.PanelScreenshot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelScreenshot.Controls.Add(this.PictureBoxSearchArea);
            this.PanelScreenshot.Location = new System.Drawing.Point(0, 3);
            this.PanelScreenshot.Name = "PanelScreenshot";
            this.PanelScreenshot.Size = new System.Drawing.Size(777, 546);
            this.PanelScreenshot.TabIndex = 9;
            // 
            // PictureBoxSearchArea
            // 
            this.PictureBoxSearchArea.Location = new System.Drawing.Point(0, 0);
            this.PictureBoxSearchArea.Name = "PictureBoxSearchArea";
            this.PictureBoxSearchArea.Size = new System.Drawing.Size(100, 50);
            this.PictureBoxSearchArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBoxSearchArea.TabIndex = 0;
            this.PictureBoxSearchArea.TabStop = false;
            this.PictureBoxSearchArea.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxSearchArea_Paint);
            // 
            // TabPage4
            // 
            this.TabPage4.Controls.Add(this.Panel1);
            this.TabPage4.Location = new System.Drawing.Point(4, 22);
            this.TabPage4.Name = "TabPage4";
            this.TabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage4.Size = new System.Drawing.Size(783, 543);
            this.TabPage4.TabIndex = 1;
            this.TabPage4.Text = "Red Channel";
            this.TabPage4.UseVisualStyleBackColor = true;
            // 
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel1.AutoScroll = true;
            this.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Panel1.Controls.Add(this.PictureBox1);
            this.Panel1.Location = new System.Drawing.Point(3, 4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(777, 519);
            this.Panel1.TabIndex = 10;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Location = new System.Drawing.Point(0, 0);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(100, 50);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            // 
            // TabPage5
            // 
            this.TabPage5.Controls.Add(this.Panel2);
            this.TabPage5.Location = new System.Drawing.Point(4, 22);
            this.TabPage5.Name = "TabPage5";
            this.TabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage5.Size = new System.Drawing.Size(783, 543);
            this.TabPage5.TabIndex = 2;
            this.TabPage5.Text = "Green Channel";
            this.TabPage5.UseVisualStyleBackColor = true;
            // 
            // Panel2
            // 
            this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel2.AutoScroll = true;
            this.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Panel2.Controls.Add(this.PictureBox2);
            this.Panel2.Location = new System.Drawing.Point(3, 4);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(777, 519);
            this.Panel2.TabIndex = 10;
            // 
            // PictureBox2
            // 
            this.PictureBox2.Location = new System.Drawing.Point(0, 0);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(100, 50);
            this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox2.TabIndex = 0;
            this.PictureBox2.TabStop = false;
            // 
            // TabPage6
            // 
            this.TabPage6.Controls.Add(this.Panel3);
            this.TabPage6.Location = new System.Drawing.Point(4, 22);
            this.TabPage6.Name = "TabPage6";
            this.TabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage6.Size = new System.Drawing.Size(783, 543);
            this.TabPage6.TabIndex = 3;
            this.TabPage6.Text = "Blue Channel";
            this.TabPage6.UseVisualStyleBackColor = true;
            // 
            // Panel3
            // 
            this.Panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel3.AutoScroll = true;
            this.Panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Panel3.Controls.Add(this.PictureBox3);
            this.Panel3.Location = new System.Drawing.Point(3, 4);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(777, 519);
            this.Panel3.TabIndex = 10;
            // 
            // PictureBox3
            // 
            this.PictureBox3.Location = new System.Drawing.Point(0, 0);
            this.PictureBox3.Name = "PictureBox3";
            this.PictureBox3.Size = new System.Drawing.Size(100, 50);
            this.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox3.TabIndex = 0;
            this.PictureBox3.TabStop = false;
            // 
            // cmdUpdateScreenshot
            // 
            this.cmdUpdateScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUpdateScreenshot.Location = new System.Drawing.Point(809, 43);
            this.cmdUpdateScreenshot.Name = "cmdUpdateScreenshot";
            this.cmdUpdateScreenshot.Size = new System.Drawing.Size(222, 24);
            this.cmdUpdateScreenshot.TabIndex = 45;
            this.cmdUpdateScreenshot.Text = "Re-Test Current Window";
            this.cmdUpdateScreenshot.UseVisualStyleBackColor = true;
            this.cmdUpdateScreenshot.Click += new System.EventHandler(this.cmdUpdateScreenshot_Click);
            // 
            // frmTestObjectSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 628);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.TabControl2);
            this.Controls.Add(this.cmdUpdateScreenshot);
            this.Name = "frmTestObjectSearch";
            this.Text = "Test Object Search";
            this.Load += new System.EventHandler(this.frmTestObjectSearch_Load);
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxObject)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown1)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.TabControl2.ResumeLayout(false);
            this.TabPage3.ResumeLayout(false);
            this.PanelScreenshot.ResumeLayout(false);
            this.PanelScreenshot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxSearchArea)).EndInit();
            this.TabPage4.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.TabPage5.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.TabPage6.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Timer Timer1;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.PictureBox PictureBoxObject;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.ComboBox cboChannel;
        internal System.Windows.Forms.Button cmdChannel;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.NumericUpDown NumericUpDown1;
        internal System.Windows.Forms.Button cmdSetAcceptanceThreshold;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label lblHideAndSeek;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label lblPoint;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label lblDetectedThreashold;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label lblResult;
        internal System.Windows.Forms.TabControl TabControl2;
        internal System.Windows.Forms.TabPage TabPage3;
        internal System.Windows.Forms.Panel PanelScreenshot;
        internal System.Windows.Forms.PictureBox PictureBoxSearchArea;
        internal System.Windows.Forms.TabPage TabPage4;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.TabPage TabPage5;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.PictureBox PictureBox2;
        internal System.Windows.Forms.TabPage TabPage6;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.PictureBox PictureBox3;
        internal System.Windows.Forms.Button cmdUpdateScreenshot;
    }
}