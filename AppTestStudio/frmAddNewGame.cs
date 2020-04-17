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
    public partial class frmAddNewGame : Form
    {

        public String TargetFileName { get; set; }
        public Boolean IsValid { get; set; }
        public frmAddNewGame()
        {
            InitializeComponent();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            cmdSave.Enabled = true;
            int IndexOfInvalidCharacter = txtName.Text.IndexOfAny(System.IO.Path.GetInvalidFileNameChars());
        if (IndexOfInvalidCharacter == -1)
            {

                if (txtName.Text.Trim().Length == 0)
                {
                    cmdSave.Enabled = false;
                }
                else
                {
                    lblNameIsInvalid.Text = "";
              }

            }
            else
            {

                String BadCharacter = txtName.Text.Substring(IndexOfInvalidCharacter,1);
                lblNameIsInvalid.Text = "Name has invalid character: " + BadCharacter;
                cmdSave.Enabled = false;
          }

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            String ApplicationName = txtName.Text.Trim();
            String ApplicationFolder = Utils.GetApplicationFolder();

            String DirectoryName = System.IO.Path.Combine(ApplicationFolder, ApplicationName);

            TargetFileName = System.IO.Path.Combine(DirectoryName, "Default.xml");
            DialogResult Result = DialogResult.Yes;
        if (System.IO.Directory.Exists(TargetFileName))
            {
                Result = MessageBox.Show("Project Folder already exists with that name: " + ApplicationName + " Do you want to overwrite?","Overwrite?",MessageBoxButtons.YesNoCancel );
        }

            if (Result == DialogResult.Cancel)
            {
                return;
                }

            if (Result == DialogResult.No)
            {
                IsValid = false;
                //'do nothing
            }

            if (Result == DialogResult.Yes)
            {
                IsValid = true;

                String Directory = System.IO.Path.Combine(ApplicationFolder, ApplicationName, "Pictures");
            if (System.IO.Directory.Exists(Directory))
                {
                    //'do nothing
                }
                else
                {
                    System.IO.Directory.CreateDirectory(Directory);
                }
            }

            Hide();
        }
    }
}
