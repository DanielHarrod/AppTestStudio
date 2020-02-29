// This code is distributed under MIT license. 
// Copyright (c) 2016-2020 Daniel Harrod
// See LICENSE or https://mit-license.org/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppTestStudioControls
{
    public class AppTestStudioToolStrip : System.Windows.Forms.ToolStrip
    {
        const int WM_MOUSEACTIVE = 0x21;

        // Enable clicking when window is not active
        protected override void WndProc(ref Message m)
        {
            try
            {
                if (m.Msg == WM_MOUSEACTIVE)
                {
                    if (CanFocus)
                    {
                        if (Focused == false)
                        {
                            this.Focus();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            base.WndProc(ref m);
        }
    }
}
