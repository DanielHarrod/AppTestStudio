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
            // frmTestAllRuntimeImages
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1486, 723);
            Controls.Add(fp);
            Name = "frmTestAllRuntimeImages";
            Text = "frmTestAllRuntimeImages";
            WindowState = FormWindowState.Maximized;
            Load += frmTestAllRuntimeImages_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel fp;
    }
}