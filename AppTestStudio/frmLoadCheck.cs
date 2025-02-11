//AppTestStudio 
//Copyright (C) 2016-2023 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

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
    // What actions do to before loading a new form
    public partial class frmLoadCheck : Form
    {
        public enum LoadCheckResult
        {
            Save,
            DontSave,
            Cancel,
            DefaultValue                
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
        public LoadCheckResult Result { get; set; }

        public frmLoadCheck()
        {
            InitializeComponent();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Result = LoadCheckResult.Save;
            Close();
        }

        private void cmdDontSave_Click(object sender, EventArgs e)
        {
            Result = LoadCheckResult.DontSave;
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Result = LoadCheckResult.Cancel;
            Close();
        }

        private void frmLoadCheck_Load(object sender, EventArgs e)
        {
            cmdSave.Focus();
        }
    }
}
