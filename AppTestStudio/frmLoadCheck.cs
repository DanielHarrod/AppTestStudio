// This code is distributed under MIT license. 
// Copyright (c) 2016-2020 Daniel Harrod
// See LICENSE or https://mit-license.org/

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
    }
}
