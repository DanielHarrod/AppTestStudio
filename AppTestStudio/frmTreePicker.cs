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
    public partial class frmTreePicker : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String AcceptedText { get; set; } = "";
        public frmTreePicker()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void frmTreePicker_Load(object sender, EventArgs e)
        {
            lblSelection.Text = "";
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            

        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            AcceptedText = lblSelection.Text;
            Hide();
        }

        private int AfterSelectCount = 0;

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (AfterSelectCount > 0)
            {
                TreeNode node = (sender as TreeView).SelectedNode;
                String[] Nodelist = node.FullPath.Split('\\');
                if (Nodelist.Length > 1)
                {
                    int FirstEntryLength = Nodelist[0].Length;
                    lblSelection.Text = node.FullPath.Substring(FirstEntryLength + 1, node.FullPath.Length - FirstEntryLength - 1);
                }
                else
                {
                    lblSelection.Text = "";
                }
            }
            AfterSelectCount++;
        }
    }
}
