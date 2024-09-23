using Gma.System.MouseKeyHook;
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
    public partial class frmMouseRecorder : Form
    {
        public frmMouseRecorder()
        {
            InitializeComponent();
        }

        private IKeyboardMouseEvents GlobalMouseKeyHook;
        private void frmMouseRecorder_Load(object sender, EventArgs e)
        {
            // Note: for the application hook, use the Hook.AppEvents() instead
            GlobalMouseKeyHook = Hook.GlobalEvents();
            GlobalMouseKeyHook.KeyPress += GlobalMouseKeyHook_KeyPress; ;
            GlobalMouseKeyHook.KeyUp += GlobalMouseKeyHook_KeyUp; ;
            GlobalMouseKeyHook.MouseClick += GlobalMouseKeyHook_MouseClick; ;
            GlobalMouseKeyHook.MouseDragStarted += GlobalMouseKeyHook_MouseDragStarted; ;
            GlobalMouseKeyHook.MouseDragFinished += GlobalMouseKeyHook_MouseDragFinished; ;
            GlobalMouseKeyHook.MouseMoveExt += GlobalMouseKeyHook_MouseMoveExt;

        }

        private void GlobalMouseKeyHook_MouseMoveExt(object sender, MouseEventExtArgs e)
        {
            Debug.WriteLine($"GMKH.GlobalMouseKeyHook_MouseMoveExt {e.X},{e.Y},{e.Button},{e.Clicks},{e.Delta},{e.Timestamp}");
            DateTime dt = DateTime.Now;
            dt.AddMilliseconds(e.Timestamp - Environment.TickCount);
            Debug.WriteLine($"{dt.ToString()}");

            if (IsRecording)
            {
                Recordings.Add(e);
            }
        }

        private void GlobalMouseKeyHook_MouseDragFinished(object sender, MouseEventArgs e)
        {
            Debug.WriteLine($"GMKH.GlobalMouseKeyHook_MouseDragFinished {e.X},{e.Y},{e.Button},{e.Clicks},{e.Delta}");
            if (IsRecording)
            {
                Recordings.Add(e);
            }
        }

        private void GlobalMouseKeyHook_MouseDragStarted(object sender, MouseEventArgs e)
        {
            Debug.WriteLine($"GMKH.GlobalMouseKeyHook_MouseDragStarted {e.X},{e.Y},{e.Button},{e.Clicks},{e.Delta}");
            if (IsRecording)
            {
                Recordings.Add(e);
            }
        }

        private void GlobalMouseKeyHook_MouseClick(object sender, MouseEventArgs e)
        {
            Debug.WriteLine($"GMKH.MouseClick {e.X},{e.Y},{e.Button},{e.Clicks},{e.Delta}");
            if (IsRecording)
            {
                Recordings.Add(e);
            }
        }

        private void GlobalMouseKeyHook_KeyPress(object sender, KeyPressEventArgs e)
        {
            Debug.WriteLine("GlobalMouseKeyHook_KeyPress:" + e.KeyChar);
            if (IsRecording)
            {
                Recordings.Add(e);
            }
        }

        private void GlobalMouseKeyHook_KeyUp(object sender, KeyEventArgs e)
        {
            Debug.WriteLine($"GlobalMouseKeyHook_KeyUp:" + e.ToString());
            if (IsRecording)
            {
                Recordings.Add(e);
            }
        }


        private void frmMouseRecorder_FormClosed(object sender, FormClosedEventArgs e)
        {
            GlobalMouseKeyHook.KeyPress -= GlobalMouseKeyHook_KeyPress; ;
            GlobalMouseKeyHook.KeyUp -= GlobalMouseKeyHook_KeyUp; ;
            GlobalMouseKeyHook.MouseClick -= GlobalMouseKeyHook_MouseClick; ;
            GlobalMouseKeyHook.MouseDragStarted -= GlobalMouseKeyHook_MouseDragStarted; ;
            GlobalMouseKeyHook.MouseDragFinished -= GlobalMouseKeyHook_MouseDragFinished; ;
            GlobalMouseKeyHook.MouseMoveExt -= GlobalMouseKeyHook_MouseMoveExt; ;

            //GlobalMouseKeyHook.KeyUp += GlobalMouseKeyHook_KeyUp;

            //It is recommened to dispose it
            GlobalMouseKeyHook.Dispose();
        }

        List<EventArgs> Recordings = new List<EventArgs>();


        Boolean IsRecording = false;
        private void cmdStartStopRecording_Click(object sender, EventArgs e)
        {
            if (IsRecording )
            {
                IsRecording = false;
            }
            else
            {
                IsRecording = true;
            }

            if (IsRecording)
            {
                Recordings = new List<EventArgs>();
            }
        }
    }
}
