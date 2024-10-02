//AppTestStudio 
//Copyright (C) 2016-2024 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
