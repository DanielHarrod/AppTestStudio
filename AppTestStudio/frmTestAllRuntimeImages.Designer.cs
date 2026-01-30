namespace AppTestStudio
{
    partial class frmTestAllRuntimeImages
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
            fp = new FlowLayoutPanel();
            cboScale = new ComboBox();
            lblScale = new Label();
            SuspendLayout();
            // 
            // fp
            // 
            fp.Dock = DockStyle.Fill;
            fp.Location = new Point(0, 0);
            fp.Name = "fp";
            fp.Size = new Size(1486, 723);
            fp.TabIndex = 2;
            // 
            // cboScale
            // 
            cboScale.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboScale.DropDownStyle = ComboBoxStyle.DropDownList;
            cboScale.FormattingEnabled = true;
            cboScale.Location = new Point(1357, 6);
            cboScale.Name = "cboScale";
            cboScale.Size = new Size(121, 23);
            cboScale.TabIndex = 0;
            cboScale.SelectedIndexChanged += cboScale_SelectedIndexChanged;
            // 
            // lblScale
            // 
            lblScale.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblScale.AutoSize = true;
            lblScale.Location = new Point(1322, 10);
            lblScale.Name = "lblScale";
            lblScale.Size = new Size(34, 15);
            lblScale.TabIndex = 0;
            lblScale.Text = "Scale";
            // 
            // frmTestAllRuntimeImages
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1486, 723);
            Controls.Add(cboScale);
            Controls.Add(lblScale);
            Controls.Add(fp);
            Name = "frmTestAllRuntimeImages";
            Text = "Test Runtime Images";
            WindowState = FormWindowState.Maximized;
            Load += frmTestAllRuntimeImages_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel fp;
        private ComboBox cboScale;
        private Label lblScale;
    }
}