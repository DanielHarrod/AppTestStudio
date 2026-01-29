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
            splitContainer1 = new SplitContainer();
            PanelScreenshot = new Panel();
            PictureBoxSearchArea = new PictureBox();
            cmdRetestDesignImage = new Button();
            cmdRetestCurrentWindow = new Button();
            panelRightPixelSearchProperties = new Panel();
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
            label105 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            PanelScreenshot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxSearchArea).BeginInit();
            panelRightPixelSearchProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchBNeg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchBPos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchGPos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchGNeg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchRPos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchRNeg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchR).BeginInit();
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
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(cmdRetestDesignImage);
            splitContainer1.Panel2.Controls.Add(cmdRetestCurrentWindow);
            splitContainer1.Panel2.Controls.Add(panelRightPixelSearchProperties);
            splitContainer1.Panel2MinSize = 250;
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 474;
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
            PanelScreenshot.Size = new Size(474, 450);
            PanelScreenshot.TabIndex = 11;
            // 
            // PictureBoxSearchArea
            // 
            PictureBoxSearchArea.Location = new Point(3, 0);
            PictureBoxSearchArea.Margin = new Padding(3, 4, 3, 4);
            PictureBoxSearchArea.Name = "PictureBoxSearchArea";
            PictureBoxSearchArea.Size = new Size(100, 50);
            PictureBoxSearchArea.SizeMode = PictureBoxSizeMode.AutoSize;
            PictureBoxSearchArea.TabIndex = 0;
            PictureBoxSearchArea.TabStop = false;
            PictureBoxSearchArea.Paint += PictureBoxSearchArea_Paint;
            // 
            // cmdRetestDesignImage
            // 
            cmdRetestDesignImage.Location = new Point(18, 45);
            cmdRetestDesignImage.Name = "cmdRetestDesignImage";
            cmdRetestDesignImage.Size = new Size(173, 23);
            cmdRetestDesignImage.TabIndex = 45;
            cmdRetestDesignImage.Text = "Re-Test Design Image";
            cmdRetestDesignImage.UseVisualStyleBackColor = true;
            cmdRetestDesignImage.Click += cmdRetestDesignImage_Click;
            // 
            // cmdRetestCurrentWindow
            // 
            cmdRetestCurrentWindow.Location = new Point(15, 14);
            cmdRetestCurrentWindow.Name = "cmdRetestCurrentWindow";
            cmdRetestCurrentWindow.Size = new Size(176, 23);
            cmdRetestCurrentWindow.TabIndex = 44;
            cmdRetestCurrentWindow.Text = "Re-Test Current Window";
            cmdRetestCurrentWindow.UseVisualStyleBackColor = true;
            cmdRetestCurrentWindow.Click += cmdRetestCurrentWindow_Click;
            // 
            // panelRightPixelSearchProperties
            // 
            panelRightPixelSearchProperties.BorderStyle = BorderStyle.FixedSingle;
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
            panelRightPixelSearchProperties.Controls.Add(label105);
            panelRightPixelSearchProperties.Location = new Point(2, 108);
            panelRightPixelSearchProperties.Margin = new Padding(2);
            panelRightPixelSearchProperties.Name = "panelRightPixelSearchProperties";
            panelRightPixelSearchProperties.Size = new Size(326, 185);
            panelRightPixelSearchProperties.TabIndex = 43;
            // 
            // lblPixelSearchPreview
            // 
            lblPixelSearchPreview.Location = new Point(209, 52);
            lblPixelSearchPreview.Name = "lblPixelSearchPreview";
            lblPixelSearchPreview.Size = new Size(100, 84);
            lblPixelSearchPreview.TabIndex = 19;
            // 
            // label119
            // 
            label119.AutoSize = true;
            label119.Location = new Point(210, 30);
            label119.Name = "label119";
            label119.Size = new Size(46, 15);
            label119.TabIndex = 18;
            label119.Text = "Sample";
            // 
            // label118
            // 
            label118.AutoSize = true;
            label118.Location = new Point(125, 30);
            label118.Name = "label118";
            label118.Size = new Size(51, 15);
            label118.TabIndex = 18;
            label118.Text = "+ Range";
            // 
            // label116
            // 
            label116.AutoSize = true;
            label116.Location = new Point(71, 30);
            label116.Name = "label116";
            label116.Size = new Size(48, 15);
            label116.TabIndex = 18;
            label116.Text = "- Range";
            // 
            // label115
            // 
            label115.AutoSize = true;
            label115.Location = new Point(25, 30);
            label115.Name = "label115";
            label115.Size = new Size(36, 15);
            label115.TabIndex = 18;
            label115.Text = "Color";
            // 
            // label113
            // 
            label113.AutoSize = true;
            label113.Location = new Point(7, 108);
            label113.Name = "label113";
            label113.Size = new Size(14, 15);
            label113.TabIndex = 17;
            label113.Text = "B";
            // 
            // label110
            // 
            label110.AutoSize = true;
            label110.Location = new Point(7, 80);
            label110.Name = "label110";
            label110.Size = new Size(15, 15);
            label110.TabIndex = 17;
            label110.Text = "G";
            // 
            // label109
            // 
            label109.AutoSize = true;
            label109.Location = new Point(7, 52);
            label109.Name = "label109";
            label109.Size = new Size(14, 15);
            label109.TabIndex = 17;
            label109.Text = "R";
            // 
            // numPixelSearchB
            // 
            numPixelSearchB.Location = new Point(25, 108);
            numPixelSearchB.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numPixelSearchB.Name = "numPixelSearchB";
            numPixelSearchB.Size = new Size(42, 23);
            numPixelSearchB.TabIndex = 16;
            numPixelSearchB.Value = new decimal(new int[] { 255, 0, 0, 0 });
            // 
            // numPixelSearchG
            // 
            numPixelSearchG.Location = new Point(25, 80);
            numPixelSearchG.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numPixelSearchG.Name = "numPixelSearchG";
            numPixelSearchG.Size = new Size(42, 23);
            numPixelSearchG.TabIndex = 16;
            numPixelSearchG.Value = new decimal(new int[] { 255, 0, 0, 0 });
            // 
            // numPixelSearchBNeg
            // 
            numPixelSearchBNeg.Location = new Point(77, 108);
            numPixelSearchBNeg.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            numPixelSearchBNeg.Minimum = new decimal(new int[] { 255, 0, 0, int.MinValue });
            numPixelSearchBNeg.Name = "numPixelSearchBNeg";
            numPixelSearchBNeg.Size = new Size(45, 23);
            numPixelSearchBNeg.TabIndex = 16;
            // 
            // numPixelSearchBPos
            // 
            numPixelSearchBPos.Location = new Point(134, 108);
            numPixelSearchBPos.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numPixelSearchBPos.Name = "numPixelSearchBPos";
            numPixelSearchBPos.Size = new Size(42, 23);
            numPixelSearchBPos.TabIndex = 16;
            // 
            // numPixelSearchGPos
            // 
            numPixelSearchGPos.Location = new Point(134, 80);
            numPixelSearchGPos.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numPixelSearchGPos.Name = "numPixelSearchGPos";
            numPixelSearchGPos.Size = new Size(42, 23);
            numPixelSearchGPos.TabIndex = 16;
            // 
            // numPixelSearchGNeg
            // 
            numPixelSearchGNeg.Location = new Point(77, 80);
            numPixelSearchGNeg.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            numPixelSearchGNeg.Minimum = new decimal(new int[] { 255, 0, 0, int.MinValue });
            numPixelSearchGNeg.Name = "numPixelSearchGNeg";
            numPixelSearchGNeg.Size = new Size(45, 23);
            numPixelSearchGNeg.TabIndex = 16;
            // 
            // numPixelSearchRPos
            // 
            numPixelSearchRPos.Location = new Point(134, 52);
            numPixelSearchRPos.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numPixelSearchRPos.Name = "numPixelSearchRPos";
            numPixelSearchRPos.Size = new Size(42, 23);
            numPixelSearchRPos.TabIndex = 16;
            // 
            // numPixelSearchRNeg
            // 
            numPixelSearchRNeg.Location = new Point(77, 52);
            numPixelSearchRNeg.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            numPixelSearchRNeg.Minimum = new decimal(new int[] { 255, 0, 0, int.MinValue });
            numPixelSearchRNeg.Name = "numPixelSearchRNeg";
            numPixelSearchRNeg.Size = new Size(45, 23);
            numPixelSearchRNeg.TabIndex = 16;
            // 
            // numPixelSearchR
            // 
            numPixelSearchR.Location = new Point(25, 52);
            numPixelSearchR.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numPixelSearchR.Name = "numPixelSearchR";
            numPixelSearchR.Size = new Size(42, 23);
            numPixelSearchR.TabIndex = 16;
            numPixelSearchR.Value = new decimal(new int[] { 255, 0, 0, 0 });
            // 
            // label105
            // 
            label105.Location = new Point(12, 141);
            label105.Margin = new Padding(2, 0, 2, 0);
            label105.Name = "label105";
            label105.Size = new Size(284, 38);
            label105.TabIndex = 15;
            label105.Text = "Click Image to Select a color, and Drag a cropping window on the screen.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 332);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 46;
            label1.Text = "label1";
            // 
            // frmTestPixelSearch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "frmTestPixelSearch";
            Text = "frmTestPixelSearch";
            Load += frmTestPixelSearch_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            PanelScreenshot.ResumeLayout(false);
            PanelScreenshot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxSearchArea).EndInit();
            panelRightPixelSearchProperties.ResumeLayout(false);
            panelRightPixelSearchProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchB).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchG).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchBNeg).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchBPos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchGPos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchGNeg).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchRPos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchRNeg).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPixelSearchR).EndInit();
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
        private Label label105;
        private Button cmdRetestDesignImage;
        private Button cmdRetestCurrentWindow;
        private Label label1;
    }
}