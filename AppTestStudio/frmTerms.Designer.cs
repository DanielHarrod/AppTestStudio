namespace AppTestStudio
{
    partial class frmTerms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTerms));
            this.txtTerms = new System.Windows.Forms.TextBox();
            this.cmdAgree = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTerms
            // 
            this.txtTerms.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTerms.Location = new System.Drawing.Point(13, 13);
            this.txtTerms.Multiline = true;
            this.txtTerms.Name = "txtTerms";
            this.txtTerms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTerms.Size = new System.Drawing.Size(1320, 722);
            this.txtTerms.TabIndex = 0;
            this.txtTerms.Text = resources.GetString("txtTerms.Text");
            // 
            // cmdAgree
            // 
            this.cmdAgree.Location = new System.Drawing.Point(664, 746);
            this.cmdAgree.Name = "cmdAgree";
            this.cmdAgree.Size = new System.Drawing.Size(75, 37);
            this.cmdAgree.TabIndex = 1;
            this.cmdAgree.Text = "I Agree";
            this.cmdAgree.UseVisualStyleBackColor = true;
            this.cmdAgree.Click += new System.EventHandler(this.cmdAgree_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(576, 746);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(82, 37);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmTerms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1345, 795);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAgree);
            this.Controls.Add(this.txtTerms);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTerms";
            this.Text = "AppTestStudio - Terms of Use";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTerms;
        private System.Windows.Forms.Button cmdAgree;
        private System.Windows.Forms.Button cmdCancel;
    }
}