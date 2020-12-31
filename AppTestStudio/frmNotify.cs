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
    public partial class frmNotify : Form
    {
        public frmNotify()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> LetsQuit;

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;            
            Hide();

            EventHandler<EventArgs> raiseEvent = LetsQuit;
            raiseEvent(this, new EventArgs());

        }
    }
}
