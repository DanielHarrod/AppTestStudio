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
                m1.Dispose();
                m2.Dispose();

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
            Timer1 = new System.Windows.Forms.Timer(components);
            cmdReTestFromReference = new System.Windows.Forms.Button();
            GroupBox4 = new System.Windows.Forms.GroupBox();
            PictureBoxObject = new System.Windows.Forms.PictureBox();
            GroupBox3 = new System.Windows.Forms.GroupBox();
            cboChannel = new System.Windows.Forms.ComboBox();
            cmdChannel = new System.Windows.Forms.Button();
            GroupBox2 = new System.Windows.Forms.GroupBox();
            NumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            cmdSetAcceptanceThreshold = new System.Windows.Forms.Button();
            Label5 = new System.Windows.Forms.Label();
            GroupBox1 = new System.Windows.Forms.GroupBox();
            lblHideAndSeek = new System.Windows.Forms.Label();
            Label6 = new System.Windows.Forms.Label();
            lblPoint = new System.Windows.Forms.Label();
            Label4 = new System.Windows.Forms.Label();
            lblDetectedThreashold = new System.Windows.Forms.Label();
            Label3 = new System.Windows.Forms.Label();
            Label2 = new System.Windows.Forms.Label();
            lblResult = new System.Windows.Forms.Label();
            TabControl2 = new System.Windows.Forms.TabControl();
            TabPage3 = new System.Windows.Forms.TabPage();
            PanelScreenshot = new System.Windows.Forms.Panel();
            PictureBoxSearchArea = new System.Windows.Forms.PictureBox();
            TabPage4 = new System.Windows.Forms.TabPage();
            Panel1 = new System.Windows.Forms.Panel();
            PictureBox1 = new System.Windows.Forms.PictureBox();
            TabPage5 = new System.Windows.Forms.TabPage();
            Panel2 = new System.Windows.Forms.Panel();
            PictureBox2 = new System.Windows.Forms.PictureBox();
            TabPage6 = new System.Windows.Forms.TabPage();
            Panel3 = new System.Windows.Forms.Panel();
            PictureBox3 = new System.Windows.Forms.PictureBox();
            cmdUpdateScreenshot = new System.Windows.Forms.Button();
            GroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxObject).BeginInit();
            GroupBox3.SuspendLayout();
            GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericUpDown1).BeginInit();
            GroupBox1.SuspendLayout();
            TabControl2.SuspendLayout();
            TabPage3.SuspendLayout();
            PanelScreenshot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxSearchArea).BeginInit();
            TabPage4.SuspendLayout();
            Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            TabPage5.SuspendLayout();
            Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox2).BeginInit();
            TabPage6.SuspendLayout();
            Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox3).BeginInit();
            SuspendLayout();
            // 
            // Timer1
            // 
            Timer1.Enabled = true;
            Timer1.Interval = 500;
            // 
            // cmdReTestFromReference
            // 
            cmdReTestFromReference.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmdReTestFromReference.Location = new System.Drawing.Point(1349, 131);
            cmdReTestFromReference.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cmdReTestFromReference.Name = "cmdReTestFromReference";
            cmdReTestFromReference.Size = new System.Drawing.Size(370, 46);
            cmdReTestFromReference.TabIndex = 53;
            cmdReTestFromReference.Text = "Re-Test From Reference";
            cmdReTestFromReference.UseVisualStyleBackColor = true;
            cmdReTestFromReference.Click += cmdReTestFromReference_Click;
            // 
            // GroupBox4
            // 
            GroupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            GroupBox4.Controls.Add(PictureBoxObject);
            GroupBox4.Location = new System.Drawing.Point(1347, 631);
            GroupBox4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            GroupBox4.Name = "GroupBox4";
            GroupBox4.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            GroupBox4.Size = new System.Drawing.Size(370, 268);
            GroupBox4.TabIndex = 52;
            GroupBox4.TabStop = false;
            GroupBox4.Text = "Search Object";
            // 
            // PictureBoxObject
            // 
            PictureBoxObject.Location = new System.Drawing.Point(18, 36);
            PictureBoxObject.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            PictureBoxObject.Name = "PictureBoxObject";
            PictureBoxObject.Size = new System.Drawing.Size(106, 50);
            PictureBoxObject.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            PictureBoxObject.TabIndex = 9;
            PictureBoxObject.TabStop = false;
            // 
            // GroupBox3
            // 
            GroupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            GroupBox3.Controls.Add(cboChannel);
            GroupBox3.Controls.Add(cmdChannel);
            GroupBox3.Location = new System.Drawing.Point(1349, 308);
            GroupBox3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            GroupBox3.Name = "GroupBox3";
            GroupBox3.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            GroupBox3.Size = new System.Drawing.Size(370, 144);
            GroupBox3.TabIndex = 51;
            GroupBox3.TabStop = false;
            GroupBox3.Text = "Channel";
            // 
            // cboChannel
            // 
            cboChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboChannel.FormattingEnabled = true;
            cboChannel.Items.AddRange(new object[] { "Red Channel", "Green Channel", "Blue Channel" });
            cboChannel.Location = new System.Drawing.Point(13, 36);
            cboChannel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cboChannel.Name = "cboChannel";
            cboChannel.Size = new System.Drawing.Size(337, 33);
            cboChannel.TabIndex = 4;
            cboChannel.SelectedIndexChanged += cboChannel_SelectedIndexChanged;
            // 
            // cmdChannel
            // 
            cmdChannel.Location = new System.Drawing.Point(13, 86);
            cmdChannel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cmdChannel.Name = "cmdChannel";
            cmdChannel.Size = new System.Drawing.Size(340, 44);
            cmdChannel.TabIndex = 19;
            cmdChannel.Text = "Use this Channel";
            cmdChannel.UseVisualStyleBackColor = true;
            cmdChannel.Click += cmdChannel_Click;
            // 
            // GroupBox2
            // 
            GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            GroupBox2.Controls.Add(NumericUpDown1);
            GroupBox2.Controls.Add(cmdSetAcceptanceThreshold);
            GroupBox2.Location = new System.Drawing.Point(1347, 189);
            GroupBox2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            GroupBox2.Name = "GroupBox2";
            GroupBox2.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            GroupBox2.Size = new System.Drawing.Size(370, 108);
            GroupBox2.TabIndex = 50;
            GroupBox2.TabStop = false;
            GroupBox2.Text = "Acceptance Threshold";
            // 
            // NumericUpDown1
            // 
            NumericUpDown1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            NumericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            NumericUpDown1.Location = new System.Drawing.Point(18, 36);
            NumericUpDown1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            NumericUpDown1.Name = "NumericUpDown1";
            NumericUpDown1.Size = new System.Drawing.Size(98, 41);
            NumericUpDown1.TabIndex = 12;
            NumericUpDown1.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // cmdSetAcceptanceThreshold
            // 
            cmdSetAcceptanceThreshold.Location = new System.Drawing.Point(142, 42);
            cmdSetAcceptanceThreshold.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cmdSetAcceptanceThreshold.Name = "cmdSetAcceptanceThreshold";
            cmdSetAcceptanceThreshold.Size = new System.Drawing.Size(218, 44);
            cmdSetAcceptanceThreshold.TabIndex = 19;
            cmdSetAcceptanceThreshold.Text = "Use this Threshold";
            cmdSetAcceptanceThreshold.UseVisualStyleBackColor = true;
            cmdSetAcceptanceThreshold.Click += cmdSetAcceptanceThreshold_Click;
            // 
            // Label5
            // 
            Label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            Label5.ForeColor = System.Drawing.Color.Red;
            Label5.Location = new System.Drawing.Point(1342, 961);
            Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Label5.Name = "Label5";
            Label5.Size = new System.Drawing.Size(371, 96);
            Label5.TabIndex = 49;
            Label5.Text = "Always test on every screen!  This will ALWAYS identify Something.  Adjust the Threshold and Use the Mask Accordingly.";
            // 
            // GroupBox1
            // 
            GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            GroupBox1.Controls.Add(lblHideAndSeek);
            GroupBox1.Controls.Add(Label6);
            GroupBox1.Controls.Add(lblPoint);
            GroupBox1.Controls.Add(Label4);
            GroupBox1.Controls.Add(lblDetectedThreashold);
            GroupBox1.Controls.Add(Label3);
            GroupBox1.Location = new System.Drawing.Point(1349, 464);
            GroupBox1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            GroupBox1.Size = new System.Drawing.Size(370, 140);
            GroupBox1.TabIndex = 48;
            GroupBox1.TabStop = false;
            GroupBox1.Text = "Results";
            // 
            // lblHideAndSeek
            // 
            lblHideAndSeek.AutoSize = true;
            lblHideAndSeek.Location = new System.Drawing.Point(210, 102);
            lblHideAndSeek.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblHideAndSeek.Name = "lblHideAndSeek";
            lblHideAndSeek.Size = new System.Drawing.Size(138, 25);
            lblHideAndSeek.TabIndex = 5;
            lblHideAndSeek.Text = "lblHideAndSeek";
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Location = new System.Drawing.Point(11, 104);
            Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Label6.Name = "Label6";
            Label6.Size = new System.Drawing.Size(169, 25);
            Label6.TabIndex = 4;
            Label6.Text = "Hide and Seek Time";
            // 
            // lblPoint
            // 
            lblPoint.AutoSize = true;
            lblPoint.Location = new System.Drawing.Point(210, 69);
            lblPoint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPoint.Name = "lblPoint";
            lblPoint.Size = new System.Drawing.Size(71, 25);
            lblPoint.TabIndex = 3;
            lblPoint.Text = "lblPoint";
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Location = new System.Drawing.Point(11, 71);
            Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Label4.Name = "Label4";
            Label4.Size = new System.Drawing.Size(52, 25);
            Label4.TabIndex = 2;
            Label4.Text = "Point";
            // 
            // lblDetectedThreashold
            // 
            lblDetectedThreashold.AutoSize = true;
            lblDetectedThreashold.Location = new System.Drawing.Point(210, 36);
            lblDetectedThreashold.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblDetectedThreashold.Name = "lblDetectedThreashold";
            lblDetectedThreashold.Size = new System.Drawing.Size(180, 25);
            lblDetectedThreashold.TabIndex = 1;
            lblDetectedThreashold.Text = "lblDetectedThreshold";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Location = new System.Drawing.Point(11, 39);
            Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Label3.Name = "Label3";
            Label3.Size = new System.Drawing.Size(166, 25);
            Label3.TabIndex = 0;
            Label3.Text = "Detected Threshold";
            // 
            // Label2
            // 
            Label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            Label2.Location = new System.Drawing.Point(1342, 1072);
            Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Label2.Name = "Label2";
            Label2.Size = new System.Drawing.Size(377, 96);
            Label2.TabIndex = 47;
            Label2.Text = "This test will find the closest result to the object.  Every situation is different set the threshold to the acceptable level to pass the test.";
            // 
            // lblResult
            // 
            lblResult.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblResult.Location = new System.Drawing.Point(30, 18);
            lblResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblResult.Name = "lblResult";
            lblResult.Size = new System.Drawing.Size(1689, 44);
            lblResult.TabIndex = 46;
            // 
            // TabControl2
            // 
            TabControl2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TabControl2.Controls.Add(TabPage3);
            TabControl2.Controls.Add(TabPage4);
            TabControl2.Controls.Add(TabPage5);
            TabControl2.Controls.Add(TabPage6);
            TabControl2.Location = new System.Drawing.Point(18, 82);
            TabControl2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            TabControl2.Name = "TabControl2";
            TabControl2.SelectedIndex = 0;
            TabControl2.Size = new System.Drawing.Size(1318, 1094);
            TabControl2.TabIndex = 44;
            // 
            // TabPage3
            // 
            TabPage3.Controls.Add(PanelScreenshot);
            TabPage3.Location = new System.Drawing.Point(4, 34);
            TabPage3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            TabPage3.Name = "TabPage3";
            TabPage3.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            TabPage3.Size = new System.Drawing.Size(1310, 1056);
            TabPage3.TabIndex = 0;
            TabPage3.Text = "Original";
            TabPage3.UseVisualStyleBackColor = true;
            // 
            // PanelScreenshot
            // 
            PanelScreenshot.AutoScroll = true;
            PanelScreenshot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            PanelScreenshot.Controls.Add(PictureBoxSearchArea);
            PanelScreenshot.Dock = System.Windows.Forms.DockStyle.Fill;
            PanelScreenshot.Location = new System.Drawing.Point(4, 6);
            PanelScreenshot.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            PanelScreenshot.Name = "PanelScreenshot";
            PanelScreenshot.Size = new System.Drawing.Size(1302, 1044);
            PanelScreenshot.TabIndex = 9;
            // 
            // PictureBoxSearchArea
            // 
            PictureBoxSearchArea.Location = new System.Drawing.Point(4, 0);
            PictureBoxSearchArea.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            PictureBoxSearchArea.Name = "PictureBoxSearchArea";
            PictureBoxSearchArea.Size = new System.Drawing.Size(100, 50);
            PictureBoxSearchArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            PictureBoxSearchArea.TabIndex = 0;
            PictureBoxSearchArea.TabStop = false;
            PictureBoxSearchArea.Paint += PictureBoxSearchArea_Paint;
            // 
            // TabPage4
            // 
            TabPage4.Controls.Add(Panel1);
            TabPage4.Location = new System.Drawing.Point(4, 34);
            TabPage4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            TabPage4.Name = "TabPage4";
            TabPage4.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            TabPage4.Size = new System.Drawing.Size(1310, 1056);
            TabPage4.TabIndex = 1;
            TabPage4.Text = "Red Channel";
            TabPage4.UseVisualStyleBackColor = true;
            // 
            // Panel1
            // 
            Panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            Panel1.AutoScroll = true;
            Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Panel1.Controls.Add(PictureBox1);
            Panel1.Location = new System.Drawing.Point(4, 8);
            Panel1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            Panel1.Name = "Panel1";
            Panel1.Size = new System.Drawing.Size(1296, 998);
            Panel1.TabIndex = 10;
            // 
            // PictureBox1
            // 
            PictureBox1.Location = new System.Drawing.Point(0, 0);
            PictureBox1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new System.Drawing.Size(100, 50);
            PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            PictureBox1.TabIndex = 0;
            PictureBox1.TabStop = false;
            // 
            // TabPage5
            // 
            TabPage5.Controls.Add(Panel2);
            TabPage5.Location = new System.Drawing.Point(4, 34);
            TabPage5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            TabPage5.Name = "TabPage5";
            TabPage5.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            TabPage5.Size = new System.Drawing.Size(1310, 1056);
            TabPage5.TabIndex = 2;
            TabPage5.Text = "Green Channel";
            TabPage5.UseVisualStyleBackColor = true;
            // 
            // Panel2
            // 
            Panel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            Panel2.AutoScroll = true;
            Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Panel2.Controls.Add(PictureBox2);
            Panel2.Location = new System.Drawing.Point(4, 8);
            Panel2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            Panel2.Name = "Panel2";
            Panel2.Size = new System.Drawing.Size(1296, 998);
            Panel2.TabIndex = 10;
            // 
            // PictureBox2
            // 
            PictureBox2.Location = new System.Drawing.Point(0, 0);
            PictureBox2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            PictureBox2.Name = "PictureBox2";
            PictureBox2.Size = new System.Drawing.Size(100, 50);
            PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            PictureBox2.TabIndex = 0;
            PictureBox2.TabStop = false;
            // 
            // TabPage6
            // 
            TabPage6.Controls.Add(Panel3);
            TabPage6.Location = new System.Drawing.Point(4, 34);
            TabPage6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            TabPage6.Name = "TabPage6";
            TabPage6.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            TabPage6.Size = new System.Drawing.Size(1310, 1056);
            TabPage6.TabIndex = 3;
            TabPage6.Text = "Blue Channel";
            TabPage6.UseVisualStyleBackColor = true;
            // 
            // Panel3
            // 
            Panel3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            Panel3.AutoScroll = true;
            Panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Panel3.Controls.Add(PictureBox3);
            Panel3.Location = new System.Drawing.Point(4, 8);
            Panel3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            Panel3.Name = "Panel3";
            Panel3.Size = new System.Drawing.Size(1296, 998);
            Panel3.TabIndex = 10;
            // 
            // PictureBox3
            // 
            PictureBox3.Location = new System.Drawing.Point(0, 0);
            PictureBox3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            PictureBox3.Name = "PictureBox3";
            PictureBox3.Size = new System.Drawing.Size(100, 50);
            PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            PictureBox3.TabIndex = 0;
            PictureBox3.TabStop = false;
            // 
            // cmdUpdateScreenshot
            // 
            cmdUpdateScreenshot.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmdUpdateScreenshot.Location = new System.Drawing.Point(1349, 82);
            cmdUpdateScreenshot.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            cmdUpdateScreenshot.Name = "cmdUpdateScreenshot";
            cmdUpdateScreenshot.Size = new System.Drawing.Size(370, 46);
            cmdUpdateScreenshot.TabIndex = 45;
            cmdUpdateScreenshot.Text = "Re-Test Current Window";
            cmdUpdateScreenshot.UseVisualStyleBackColor = true;
            cmdUpdateScreenshot.Click += cmdUpdateScreenshot_Click;
            // 
            // frmTestObjectSearch
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1738, 1208);
            Controls.Add(cmdReTestFromReference);
            Controls.Add(GroupBox4);
            Controls.Add(GroupBox3);
            Controls.Add(GroupBox2);
            Controls.Add(Label5);
            Controls.Add(GroupBox1);
            Controls.Add(Label2);
            Controls.Add(lblResult);
            Controls.Add(TabControl2);
            Controls.Add(cmdUpdateScreenshot);
            Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            Name = "frmTestObjectSearch";
            Text = "Test Object Search";
            Load += frmTestObjectSearch_Load;
            GroupBox4.ResumeLayout(false);
            GroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxObject).EndInit();
            GroupBox3.ResumeLayout(false);
            GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NumericUpDown1).EndInit();
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            TabControl2.ResumeLayout(false);
            TabPage3.ResumeLayout(false);
            PanelScreenshot.ResumeLayout(false);
            PanelScreenshot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxSearchArea).EndInit();
            TabPage4.ResumeLayout(false);
            Panel1.ResumeLayout(false);
            Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            TabPage5.ResumeLayout(false);
            Panel2.ResumeLayout(false);
            Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox2).EndInit();
            TabPage6.ResumeLayout(false);
            Panel3.ResumeLayout(false);
            Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion
        internal System.Windows.Forms.Timer Timer1;
        internal System.Windows.Forms.Button cmdReTestFromReference;
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