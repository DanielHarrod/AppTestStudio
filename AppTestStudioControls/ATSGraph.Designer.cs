

namespace AppTestStudioControls
{ 
    partial class ATSGraph
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMax = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblMid = new System.Windows.Forms.Label();
            this.lblAverage = new System.Windows.Forms.Label();
            this.lblHighest = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLowest = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(3, 0);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(30, 15);
            this.lblMax.TabIndex = 0;
            this.lblMax.Text = "Max";
            // 
            // lblCurrent
            // 
            this.lblCurrent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Location = new System.Drawing.Point(21, 143);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(47, 15);
            this.lblCurrent.TabIndex = 1;
            this.lblCurrent.Text = "Current";
            this.lblCurrent.Visible = false;
            // 
            // lblMid
            // 
            this.lblMid.AutoSize = true;
            this.lblMid.Location = new System.Drawing.Point(18, 126);
            this.lblMid.Name = "lblMid";
            this.lblMid.Size = new System.Drawing.Size(28, 15);
            this.lblMid.TabIndex = 2;
            this.lblMid.Text = "Mid";
            // 
            // lblAverage
            // 
            this.lblAverage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAverage.AutoSize = true;
            this.lblAverage.Location = new System.Drawing.Point(21, 158);
            this.lblAverage.Name = "lblAverage";
            this.lblAverage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAverage.Size = new System.Drawing.Size(50, 15);
            this.lblAverage.TabIndex = 3;
            this.lblAverage.Text = "Average";
            this.lblAverage.Visible = false;
            // 
            // lblHighest
            // 
            this.lblHighest.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHighest.AutoSize = true;
            this.lblHighest.Location = new System.Drawing.Point(21, 21);
            this.lblHighest.Name = "lblHighest";
            this.lblHighest.Size = new System.Drawing.Size(61, 15);
            this.lblHighest.TabIndex = 4;
            this.lblHighest.Text = "lblHighest";
            this.lblHighest.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.lblMax);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(440, 18);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // lblLowest
            // 
            this.lblLowest.AutoSize = true;
            this.lblLowest.Location = new System.Drawing.Point(21, 272);
            this.lblLowest.Name = "lblLowest";
            this.lblLowest.Size = new System.Drawing.Size(44, 15);
            this.lblLowest.TabIndex = 7;
            this.lblLowest.Text = "Lowest";
            this.lblLowest.Visible = false;
            // 
            // ATSGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblAverage);
            this.Controls.Add(this.lblHighest);
            this.Controls.Add(this.lblMid);
            this.Controls.Add(this.lblLowest);
            this.Controls.Add(this.lblCurrent);
            this.DoubleBuffered = true;
            this.Name = "ATSGraph";
            this.Size = new System.Drawing.Size(440, 296);
            this.Load += new System.EventHandler(this.ProcessVisualization_Load);
            this.SizeChanged += new System.EventHandler(this.ProcessVisualization_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ProcessVisualization_Paint);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Label lblMid;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.Label lblHighest;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblLowest;
    }
}
