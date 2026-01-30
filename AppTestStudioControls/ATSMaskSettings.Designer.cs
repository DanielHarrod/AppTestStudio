namespace AppTestStudioControls
{
    partial class ATSMaskSettings
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
            groupBox1 = new GroupBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            numMaskWidth = new NumericUpDown();
            numMaskY = new NumericUpDown();
            numMaskHeight = new NumericUpDown();
            numMaskX = new NumericUpDown();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMaskWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaskY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaskHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaskX).BeginInit();
            SuspendLayout();
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
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(263, 84);
            groupBox1.TabIndex = 22;
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
            // 
            // numMaskY
            // 
            numMaskY.Location = new Point(56, 46);
            numMaskY.Name = "numMaskY";
            numMaskY.Size = new Size(49, 23);
            numMaskY.TabIndex = 1;
            // 
            // numMaskHeight
            // 
            numMaskHeight.Location = new Point(182, 17);
            numMaskHeight.Name = "numMaskHeight";
            numMaskHeight.Size = new Size(49, 23);
            numMaskHeight.TabIndex = 0;
            // 
            // numMaskX
            // 
            numMaskX.Location = new Point(57, 17);
            numMaskX.Name = "numMaskX";
            numMaskX.Size = new Size(49, 23);
            numMaskX.TabIndex = 0;
            numMaskX.ValueChanged += numMaskX_ValueChanged;
            // 
            // ATSMaskSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "ATSMaskSettings";
            Size = new Size(263, 84);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMaskWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaskY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaskHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaskX).EndInit();
            ResumeLayout(false);
        }

        #endregion

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
