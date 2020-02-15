namespace AppTestStudio
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerWorkspace = new System.Windows.Forms.SplitContainer();
            this.splitContainerSearch = new System.Windows.Forms.SplitContainer();
            this.splitContainerTree = new System.Windows.Forms.SplitContainer();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tvMain = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerWorkspace)).BeginInit();
            this.splitContainerWorkspace.Panel1.SuspendLayout();
            this.splitContainerWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSearch)).BeginInit();
            this.splitContainerSearch.Panel1.SuspendLayout();
            this.splitContainerSearch.Panel2.SuspendLayout();
            this.splitContainerSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTree)).BeginInit();
            this.splitContainerTree.Panel1.SuspendLayout();
            this.splitContainerTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 49);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerWorkspace);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.textBox1);
            this.splitContainerMain.Size = new System.Drawing.Size(800, 401);
            this.splitContainerMain.SplitterDistance = 340;
            this.splitContainerMain.TabIndex = 2;
            // 
            // splitContainerWorkspace
            // 
            this.splitContainerWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerWorkspace.Location = new System.Drawing.Point(0, 0);
            this.splitContainerWorkspace.Name = "splitContainerWorkspace";
            // 
            // splitContainerWorkspace.Panel1
            // 
            this.splitContainerWorkspace.Panel1.Controls.Add(this.splitContainerSearch);
            this.splitContainerWorkspace.Size = new System.Drawing.Size(800, 340);
            this.splitContainerWorkspace.SplitterDistance = 266;
            this.splitContainerWorkspace.TabIndex = 0;
            // 
            // splitContainerSearch
            // 
            this.splitContainerSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSearch.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSearch.Name = "splitContainerSearch";
            this.splitContainerSearch.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSearch.Panel1
            // 
            this.splitContainerSearch.Panel1.Controls.Add(this.txtSearch);
            // 
            // splitContainerSearch.Panel2
            // 
            this.splitContainerSearch.Panel2.Controls.Add(this.splitContainerTree);
            this.splitContainerSearch.Size = new System.Drawing.Size(266, 340);
            this.splitContainerSearch.SplitterDistance = 25;
            this.splitContainerSearch.TabIndex = 0;
            // 
            // splitContainerTree
            // 
            this.splitContainerTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTree.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTree.Name = "splitContainerTree";
            this.splitContainerTree.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTree.Panel1
            // 
            this.splitContainerTree.Panel1.Controls.Add(this.tvMain);
            this.splitContainerTree.Size = new System.Drawing.Size(266, 311);
            this.splitContainerTree.SplitterDistance = 280;
            this.splitContainerTree.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(266, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // tvMain
            // 
            this.tvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMain.Location = new System.Drawing.Point(0, 0);
            this.tvMain.Name = "tvMain";
            this.tvMain.Size = new System.Drawing.Size(266, 280);
            this.tvMain.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(800, 57);
            this.textBox1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "App Test Studio";
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerWorkspace.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerWorkspace)).EndInit();
            this.splitContainerWorkspace.ResumeLayout(false);
            this.splitContainerSearch.Panel1.ResumeLayout(false);
            this.splitContainerSearch.Panel1.PerformLayout();
            this.splitContainerSearch.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSearch)).EndInit();
            this.splitContainerSearch.ResumeLayout(false);
            this.splitContainerTree.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTree)).EndInit();
            this.splitContainerTree.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerWorkspace;
        private System.Windows.Forms.SplitContainer splitContainerSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.SplitContainer splitContainerTree;
        private System.Windows.Forms.TreeView tvMain;
        private System.Windows.Forms.TextBox textBox1;
    }
}