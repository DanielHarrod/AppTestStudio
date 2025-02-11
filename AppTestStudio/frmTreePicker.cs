//AppTestStudio 
//Copyright (C) 2016-2025 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.


using System.ComponentModel;

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
