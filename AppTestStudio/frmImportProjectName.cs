using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
