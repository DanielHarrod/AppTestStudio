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
    public partial class frmTerms : Form
    {
        public Boolean  IsAgree { get; set; }
        public frmTerms()
        {
            InitializeComponent();
        }

        private void cmdAgree_Click(object sender, EventArgs e)
        {
            IsAgree = true;
            Hide();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
