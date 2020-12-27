// This code is distributed under MIT license. 
// Copyright (c) 2016-2020 Daniel Harrod
// See LICENSE or https://mit-license.org/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace AppTestStudio
{
    public static class Definitions
    {
        public static String NoxWorkWindowName = "ScreenBoardClassWindow";
        public static String BlueStacksSecondaryWindowNameFilter = "BlueStacks";

        public static class MouseKeyStates
        {
            // The CTRL key is down.
            public static int MK_CONTROL = 0x0008;

            // No Mouse buttons down - Key state.  
            public static int MK_NONE = 0x0000;

            // Left mouse button - Key state.
            public static int MK_LBUTTON = 0x0001;

            // Middle mouse button - Key state.
            public static int MK_MBUTTON = 0x0010;

            // Right Mouse Button - Key state
            public static int MK_RBUTTON = 0x0002;

            // Shift key - Key state.
            public static int MK_SHIFT = 0x0004;

        }

        public static class MouseInputNotifications
        {
            // Posted when the mouse moves.
            public static int WM_MOUSEMOVE = 0x200;

            public static int WM_LBUTTONDOWN = 0x201;

            public static int WM_LBUTTONUP = 0x202;

        }
    }
}
