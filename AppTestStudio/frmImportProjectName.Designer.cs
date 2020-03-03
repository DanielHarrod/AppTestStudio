namespace AppTestStudio
{
    partial class frmImportProjectName
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
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblDirectoryName = new System.Windows.Forms.Label();
            this.lblNameIsInvalid = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.cmdCheck = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdImport = new System.Windows.Forms.Button();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(18, 146);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(61, 13);
            this.lblFileName.TabIndex = 15;
            this.lblFileName.Text = "lblFileName";
            // 
            // lblDirectoryName
            // 
            this.lblDirectoryName.AutoSize = true;
            this.lblDirectoryName.Location = new System.Drawing.Point(18, 109);
            this.lblDirectoryName.Name = "lblDirectoryName";
            this.lblDirectoryName.Size = new System.Drawing.Size(87, 13);
            this.lblDirectoryName.TabIndex = 16;
            this.lblDirectoryName.Text = "lblDirectoryName";
            // 
            // lblNameIsInvalid
            // 
            this.lblNameIsInvalid.AutoSize = true;
            this.lblNameIsInvalid.Location = new System.Drawing.Point(18, 70);
            this.lblNameIsInvalid.Name = "lblNameIsInvalid";
            this.lblNameIsInvalid.Size = new System.Drawing.Size(84, 13);
            this.lblNameIsInvalid.TabIndex = 14;
            this.lblNameIsInvalid.Text = "lblNameIsInvalid";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(15, 53);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(486, 13);
            this.Label2.TabIndex = 13;
            this.Label2.Text = "Project with this name already exists, choose a different name and Check or press" +
    " Import to Overwrite.";
            // 
            // cmdCheck
            // 
            this.cmdCheck.Location = new System.Drawing.Point(563, 210);
            this.cmdCheck.Name = "cmdCheck";
            this.cmdCheck.Size = new System.Drawing.Size(116, 23);
            this.cmdCheck.TabIndex = 12;
            this.cmdCheck.Text = "Check";
            this.cmdCheck.UseVisualStyleBackColor = true;
            this.cmdCheck.Click += new System.EventHandler(this.cmdCheck_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(11, 239);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 11;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdImport
            // 
            this.cmdImport.Location = new System.Drawing.Point(563, 239);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(116, 23);
            this.cmdImport.TabIndex = 10;
            this.cmdImport.Text = "Import";
            this.cmdImport.UseVisualStyleBackColor = true;
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(15, 26);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(572, 20);
            this.txtProjectName.TabIndex = 9;
            this.txtProjectName.TextChanged += new System.EventHandler(this.txtProjectName_TextChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(116, 13);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Choose a project name";
            // 
            // frmImportProjectName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 277);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.lblDirectoryName);
            this.Controls.Add(this.lblNameIsInvalid);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cmdCheck);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdImport);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.Label1);
            this.Name = "frmImportProjectName";
            this.Text = "frmImportProjectName";
            this.Load += new System.EventHandler(this.frmImportProjectName_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblFileName;
        internal System.Windows.Forms.Label lblDirectoryName;
        internal System.Windows.Forms.Label lblNameIsInvalid;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button cmdCheck;
        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.Button cmdImport;
        internal System.Windows.Forms.TextBox txtProjectName;
        internal System.Windows.Forms.Label Label1;
    }
}