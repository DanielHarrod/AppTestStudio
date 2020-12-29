//AppTestStudio 
//Copyright(C) 2016-2021 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

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
