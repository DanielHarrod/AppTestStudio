using AppTestStudio.solution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppTestStudio
{
    public partial class frmAddNewNode : Form
    {
        frmMain frmMain;
        frmSolution frmSolution;
        GamePassSolution gamePassSolution;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Boolean ExitAndTargetNewNode { get; set; } = false;
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
        public Boolean UseRootNode { get; set; } = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Boolean IsAction { get; set; } = false;

        public string NodeName
        {
            get { return txtNodeName.Text.Trim(); }
        }

        internal frmAddNewNode(GamePassSolution gamePassSolution, frmMain frmMain, frmSolution frmSolution)
        {
            this.frmMain = frmMain;
            this.frmSolution = frmSolution;
            this.gamePassSolution = gamePassSolution;
            InitializeComponent();
        }

        private void cmdCreate_Click(object sender, EventArgs e)
        {
            ExitAndTargetNewNode = true;
            UseRootNode = rdoRootNode.Checked;
            IsAction = rdoAction.Checked;

            Hide();            
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void frmAddNewNode_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = gamePassSolution.Bitmap;
            try
            {
                lblSelectedNode.Text = frmMain.tv.SelectedNode.FullPath;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"frmMain.tv.SelectedNode.FullPath access failed. ex={ex.Message}");
            }
        }

    }
}
