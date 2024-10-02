//AppTestStudio 
//Copyright (C) 2016-2024 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System;
using System.Windows.Forms;

namespace AppTestStudio
{
     public partial class frmImportProjectName : Form
    {
        public Boolean IsImporting { get; set; }
        public frmImportProjectName()
        {
            InitializeComponent();
        }

        private void txtProjectName_TextChanged(object sender, EventArgs e)
        {
            int IndexOfInvalidCharacter = txtProjectName.Text.IndexOfAny(System.IO.Path.GetInvalidFileNameChars());
        if (IndexOfInvalidCharacter == -1)
            {

                if (txtProjectName.Text.Trim().Length == 0)
                {
                    cmdCheck.Enabled = false;
                }

            }
            else
            {

                char BadCharacter = txtProjectName.Text[IndexOfInvalidCharacter];
                lblNameIsInvalid.Text = "Name has invalid character: " + BadCharacter;
                txtProjectName.Enabled = false;
          }

        }

        private void cmdImport_Click(object sender, EventArgs e)
        {
            IsImporting = true;
            Close();
        }

        private void cmdCheck_Click(object sender, EventArgs e)
        {
            lblDirectoryName.Text = "";
            lblFileName.Text = "";
            String ApplicationFolderName = Utils.GetApplicationFolder();

String TargetFolderName = ApplicationFolderName + @"\" + txtProjectName.Text.Trim();

Boolean DirectoryExists = false;

        if (System.IO.Directory.Exists(TargetFolderName))
            {
                DirectoryExists = true;
                lblDirectoryName.Text = "Error: Folder already exists choose a different name " + System.Environment.NewLine + TargetFolderName;
        }

            //'Dim TargetFileName As String = TargetFolderName & ".xml.ATS"

            //'Dim FileExists As Boolean = false
            //'if (System.IO.File.Exists(TargetFileName) ) {
            //'    FileExists = true
            //'    lblFileName.Text = "Error: File already exists choose a different name " & vbCrLf & TargetFileName
            //'}
            //'‪C:\Users\djhar\OneDrive\Documents\App Test Studio\Holyday City Tycoon- Idle Resource Management.xml.ATS
            cmdImport.Enabled = false;
        if (DirectoryExists == false)
            {

                cmdImport.Enabled = true;
        }

        }

        private void frmImportProjectName_Load(object sender, EventArgs e)
        {
            lblNameIsInvalid.Text = "";
            lblDirectoryName.Text = "";
            lblFileName.Text = "";
            cmdImport.Enabled = false;
        }
    }
}
