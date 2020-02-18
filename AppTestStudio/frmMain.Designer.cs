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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wizardRecommendedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.importExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimalExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerWorkspace = new System.Windows.Forms.SplitContainer();
            this.tabTree = new System.Windows.Forms.TabControl();
            this.tabDesign = new System.Windows.Forms.TabPage();
            this.splitContainerDesignSearch = new System.Windows.Forms.SplitContainer();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.splitContainerTreeSupport = new System.Windows.Forms.SplitContainer();
            this.tv = new System.Windows.Forms.TreeView();
            this.tabRun = new System.Windows.Forms.TabPage();
            this.tabSchedule = new System.Windows.Forms.TabPage();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.toolStripMain = new AppTestStudioControls.AppTestStudioToolStrip();
            this.toolStripLoadScript = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveScript = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRunScript = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStartEmmulatorLaunchAppRunScript = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStartEmmulatorLaunchApp = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStartEmmulator = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonToggleScript = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelScheduler = new System.Windows.Forms.ToolStripLabel();
            this.lstThreads = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerWorkspace)).BeginInit();
            this.splitContainerWorkspace.Panel1.SuspendLayout();
            this.splitContainerWorkspace.SuspendLayout();
            this.tabTree.SuspendLayout();
            this.tabDesign.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDesignSearch)).BeginInit();
            this.splitContainerDesignSearch.Panel1.SuspendLayout();
            this.splitContainerDesignSearch.Panel2.SuspendLayout();
            this.splitContainerDesignSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTreeSupport)).BeginInit();
            this.splitContainerTreeSupport.Panel1.SuspendLayout();
            this.splitContainerTreeSupport.SuspendLayout();
            this.tabRun.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1273, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator1,
            this.importExportToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wizardRecommendedToolStripMenuItem,
            this.manualToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // wizardRecommendedToolStripMenuItem
            // 
            this.wizardRecommendedToolStripMenuItem.Name = "wizardRecommendedToolStripMenuItem";
            this.wizardRecommendedToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.wizardRecommendedToolStripMenuItem.Text = "Wizard (Recommended)";
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.manualToolStripMenuItem.Text = "Manual";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // importExportToolStripMenuItem
            // 
            this.importExportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.importExportToolStripMenuItem.Name = "importExportToolStripMenuItem";
            this.importExportToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.importExportToolStripMenuItem.Text = "Import/Export";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullExportToolStripMenuItem,
            this.minimalExportToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // fullExportToolStripMenuItem
            // 
            this.fullExportToolStripMenuItem.Name = "fullExportToolStripMenuItem";
            this.fullExportToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.fullExportToolStripMenuItem.Text = "Full Export";
            // 
            // minimalExportToolStripMenuItem
            // 
            this.minimalExportToolStripMenuItem.Name = "minimalExportToolStripMenuItem";
            this.minimalExportToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.minimalExportToolStripMenuItem.Text = "Minimal Export";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exitToolStripMenuItem.Text = "Exit";
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
            this.splitContainerMain.Panel2.Controls.Add(this.txtLog);
            this.splitContainerMain.Size = new System.Drawing.Size(1273, 449);
            this.splitContainerMain.SplitterDistance = 380;
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
            this.splitContainerWorkspace.Panel1.Controls.Add(this.tabTree);
            this.splitContainerWorkspace.Size = new System.Drawing.Size(1273, 380);
            this.splitContainerWorkspace.SplitterDistance = 424;
            this.splitContainerWorkspace.TabIndex = 0;
            // 
            // tabTree
            // 
            this.tabTree.Controls.Add(this.tabDesign);
            this.tabTree.Controls.Add(this.tabRun);
            this.tabTree.Controls.Add(this.tabSchedule);
            this.tabTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTree.Location = new System.Drawing.Point(0, 0);
            this.tabTree.Name = "tabTree";
            this.tabTree.SelectedIndex = 0;
            this.tabTree.Size = new System.Drawing.Size(424, 380);
            this.tabTree.TabIndex = 0;
            // 
            // tabDesign
            // 
            this.tabDesign.Controls.Add(this.splitContainerDesignSearch);
            this.tabDesign.Location = new System.Drawing.Point(4, 22);
            this.tabDesign.Name = "tabDesign";
            this.tabDesign.Padding = new System.Windows.Forms.Padding(3);
            this.tabDesign.Size = new System.Drawing.Size(416, 354);
            this.tabDesign.TabIndex = 0;
            this.tabDesign.Text = "Design";
            this.tabDesign.UseVisualStyleBackColor = true;
            // 
            // splitContainerDesignSearch
            // 
            this.splitContainerDesignSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDesignSearch.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerDesignSearch.Location = new System.Drawing.Point(3, 3);
            this.splitContainerDesignSearch.Name = "splitContainerDesignSearch";
            this.splitContainerDesignSearch.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerDesignSearch.Panel1
            // 
            this.splitContainerDesignSearch.Panel1.Controls.Add(this.txtSearch);
            // 
            // splitContainerDesignSearch.Panel2
            // 
            this.splitContainerDesignSearch.Panel2.Controls.Add(this.splitContainerTreeSupport);
            this.splitContainerDesignSearch.Size = new System.Drawing.Size(410, 348);
            this.splitContainerDesignSearch.SplitterDistance = 25;
            this.splitContainerDesignSearch.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(410, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // splitContainerTreeSupport
            // 
            this.splitContainerTreeSupport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTreeSupport.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerTreeSupport.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTreeSupport.Name = "splitContainerTreeSupport";
            this.splitContainerTreeSupport.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTreeSupport.Panel1
            // 
            this.splitContainerTreeSupport.Panel1.Controls.Add(this.tv);
            this.splitContainerTreeSupport.Panel2MinSize = 15;
            this.splitContainerTreeSupport.Size = new System.Drawing.Size(410, 319);
            this.splitContainerTreeSupport.SplitterDistance = 293;
            this.splitContainerTreeSupport.SplitterWidth = 1;
            this.splitContainerTreeSupport.TabIndex = 0;
            // 
            // tv
            // 
            this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv.Location = new System.Drawing.Point(0, 0);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(410, 293);
            this.tv.TabIndex = 0;
            this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            // 
            // tabRun
            // 
            this.tabRun.Controls.Add(this.lstThreads);
            this.tabRun.Location = new System.Drawing.Point(4, 22);
            this.tabRun.Name = "tabRun";
            this.tabRun.Padding = new System.Windows.Forms.Padding(3);
            this.tabRun.Size = new System.Drawing.Size(416, 354);
            this.tabRun.TabIndex = 1;
            this.tabRun.Text = "Run";
            this.tabRun.UseVisualStyleBackColor = true;
            // 
            // tabSchedule
            // 
            this.tabSchedule.Location = new System.Drawing.Point(4, 22);
            this.tabSchedule.Name = "tabSchedule";
            this.tabSchedule.Size = new System.Drawing.Size(416, 354);
            this.tabSchedule.TabIndex = 2;
            this.tabSchedule.Text = "Schedule";
            this.tabSchedule.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(1273, 65);
            this.txtLog.TabIndex = 0;
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLoadScript,
            this.toolStripButtonSaveScript,
            this.toolStripSeparator3,
            this.toolStripButtonRunScript,
            this.toolStripButtonStartEmmulatorLaunchAppRunScript,
            this.toolStripButtonStartEmmulatorLaunchApp,
            this.toolStripButtonStartEmmulator,
            this.toolStripSeparator4,
            this.toolStripButtonToggleScript,
            this.toolStripSeparator5,
            this.toolStripLabelScheduler});
            this.toolStripMain.Location = new System.Drawing.Point(0, 24);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1273, 25);
            this.toolStripMain.TabIndex = 1;
            this.toolStripMain.Text = "toolStripMain";
            // 
            // toolStripLoadScript
            // 
            this.toolStripLoadScript.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLoadScript.Image")));
            this.toolStripLoadScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLoadScript.Name = "toolStripLoadScript";
            this.toolStripLoadScript.Size = new System.Drawing.Size(86, 22);
            this.toolStripLoadScript.Text = "Load Script";
            this.toolStripLoadScript.Click += new System.EventHandler(this.toolStripLoadScript_Click);
            // 
            // toolStripButtonSaveScript
            // 
            this.toolStripButtonSaveScript.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSaveScript.Image")));
            this.toolStripButtonSaveScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveScript.Name = "toolStripButtonSaveScript";
            this.toolStripButtonSaveScript.Size = new System.Drawing.Size(84, 22);
            this.toolStripButtonSaveScript.Text = "Save Script";
            this.toolStripButtonSaveScript.Click += new System.EventHandler(this.toolStripButtonSaveScript_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonRunScript
            // 
            this.toolStripButtonRunScript.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRunScript.Image")));
            this.toolStripButtonRunScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRunScript.Name = "toolStripButtonRunScript";
            this.toolStripButtonRunScript.Size = new System.Drawing.Size(81, 22);
            this.toolStripButtonRunScript.Text = "Run Script";
            // 
            // toolStripButtonStartEmmulatorLaunchAppRunScript
            // 
            this.toolStripButtonStartEmmulatorLaunchAppRunScript.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStartEmmulatorLaunchAppRunScript.Image")));
            this.toolStripButtonStartEmmulatorLaunchAppRunScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStartEmmulatorLaunchAppRunScript.Name = "toolStripButtonStartEmmulatorLaunchAppRunScript";
            this.toolStripButtonStartEmmulatorLaunchAppRunScript.Size = new System.Drawing.Size(259, 22);
            this.toolStripButtonStartEmmulatorLaunchAppRunScript.Text = "Start Emmulator + Launch App + Run Script";
            this.toolStripButtonStartEmmulatorLaunchAppRunScript.Click += new System.EventHandler(this.toolStripButtonStartEmmulatorLaunchAppRunScript_Click);
            // 
            // toolStripButtonStartEmmulatorLaunchApp
            // 
            this.toolStripButtonStartEmmulatorLaunchApp.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStartEmmulatorLaunchApp.Image")));
            this.toolStripButtonStartEmmulatorLaunchApp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStartEmmulatorLaunchApp.Name = "toolStripButtonStartEmmulatorLaunchApp";
            this.toolStripButtonStartEmmulatorLaunchApp.Size = new System.Drawing.Size(191, 22);
            this.toolStripButtonStartEmmulatorLaunchApp.Text = "Start Emmulator + Launch App";
            this.toolStripButtonStartEmmulatorLaunchApp.Click += new System.EventHandler(this.toolStripButtonStartEmmulatorLaunchApp_Click);
            // 
            // toolStripButtonStartEmmulator
            // 
            this.toolStripButtonStartEmmulator.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStartEmmulator.Image")));
            this.toolStripButtonStartEmmulator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStartEmmulator.Name = "toolStripButtonStartEmmulator";
            this.toolStripButtonStartEmmulator.Size = new System.Drawing.Size(113, 22);
            this.toolStripButtonStartEmmulator.Text = "Start Emmulator";
            this.toolStripButtonStartEmmulator.Click += new System.EventHandler(this.toolStripButtonStartEmmulator_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonToggleScript
            // 
            this.toolStripButtonToggleScript.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonToggleScript.Image")));
            this.toolStripButtonToggleScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonToggleScript.Name = "toolStripButtonToggleScript";
            this.toolStripButtonToggleScript.Size = new System.Drawing.Size(91, 22);
            this.toolStripButtonToggleScript.Text = "Pause Script";
            this.toolStripButtonToggleScript.Click += new System.EventHandler(this.toolStripButtonToggleScript_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabelScheduler
            // 
            this.toolStripLabelScheduler.Name = "toolStripLabelScheduler";
            this.toolStripLabelScheduler.Size = new System.Drawing.Size(100, 22);
            this.toolStripLabelScheduler.Text = "Scheduler Paused";
            // 
            // lstThreads
            // 
            this.lstThreads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstThreads.FormattingEnabled = true;
            this.lstThreads.Location = new System.Drawing.Point(3, 3);
            this.lstThreads.Name = "lstThreads";
            this.lstThreads.Size = new System.Drawing.Size(410, 348);
            this.lstThreads.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 498);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "App Test Studio";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerWorkspace.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerWorkspace)).EndInit();
            this.splitContainerWorkspace.ResumeLayout(false);
            this.tabTree.ResumeLayout(false);
            this.tabDesign.ResumeLayout(false);
            this.splitContainerDesignSearch.Panel1.ResumeLayout(false);
            this.splitContainerDesignSearch.Panel1.PerformLayout();
            this.splitContainerDesignSearch.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDesignSearch)).EndInit();
            this.splitContainerDesignSearch.ResumeLayout(false);
            this.splitContainerTreeSupport.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTreeSupport)).EndInit();
            this.splitContainerTreeSupport.ResumeLayout(false);
            this.tabRun.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.MenuStrip menuStrip1;
        private AppTestStudioControls.AppTestStudioToolStrip toolStripMain;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerWorkspace;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wizardRecommendedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem importExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimalExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripLoadScript;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveScript;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonRunScript;
        private System.Windows.Forms.ToolStripButton toolStripButtonStartEmmulatorLaunchAppRunScript;
        private System.Windows.Forms.ToolStripButton toolStripButtonStartEmmulatorLaunchApp;
        private System.Windows.Forms.ToolStripButton toolStripButtonStartEmmulator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonToggleScript;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel toolStripLabelScheduler;
        private System.Windows.Forms.TabControl tabTree;
        private System.Windows.Forms.TabPage tabDesign;
        private System.Windows.Forms.TabPage tabRun;
        private System.Windows.Forms.TabPage tabSchedule;
        private System.Windows.Forms.SplitContainer splitContainerDesignSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.SplitContainer splitContainerTreeSupport;
        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.ListBox lstThreads;
    }
}