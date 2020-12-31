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
    public partial class frmNotify : Form
    {
        // there is not _Load event so the Timeout will need to be long enough for the window to show.
        public frmNotify(int TimeoutMS)
        {
            InitializeComponent();
            timer1.Interval = TimeoutMS;
            timer1.Enabled = true;
        }

        public event EventHandler<EventArgs> LetsQuit;

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;            
            Hide();

            EventHandler<EventArgs> raiseEvent = LetsQuit;
            raiseEvent(this, new EventArgs());

        }

        private void frmNotify_Load(object sender, EventArgs e)
        {
            // Just a note 
            //this doesn't ever get called due to the way the window is being shown.
        }
    }
}
