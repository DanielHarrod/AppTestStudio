//AppTestStudio 
//Copyright(C) 2016-2024 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System;

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

        public static class KeyboardStates
        {
            //            Bits Meaning
            //0-15	The repeat count for the current message.The value is the number of times the keystroke is autorepeated as a result of the user holding down the key.The repeat count is always 1 for a WM_KEYUP message.
            //16-23	The scan code.The value depends on the OEM.
            //24	Indicates whether the key is an extended key, such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key keyboard. The value is 1 if it is an extended key; otherwise, it is 0.
            //25-28	Reserved; do not use.
            //29	The context code.The value is always 0 for a WM_KEYUP message.
            //30	The previous key state. The value is always 1 for a WM_KEYUP message.
            //31	The transition state.The value is always 1 for a WM_KEYUP message.

            //https://learn.microsoft.com/en-us/windows/win32/inputdev/about-keyboard-input#keystroke-message-flagsa
            //https://learn.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes

            public static int WM_KEYUP = 0x0101;

            public static int WM_KEYDOWN = 0x0100;
            public static int WM_CHAR = 0x0102;
        }

        public static class KeyboardCodes
        {
            public static int INPUT_KEYBOARD = 1;
            public static uint KEYEVENTF_SCANCODE = 0x0008;
            public static uint KEYEVENTF_KEYUP = 0x0002;
        }

        //file:///C:/Users/djhar/Downloads/translate.pdf
        public static class ScanCodes
        {
            public static int SK_A = 0x1E0000;
            public static int SK_B = 0x300000;
            public static int SK_C = 0x2E0000;
            public static int SK_D = 0x200000;
            public static int SK_E = 0x120000;
            public static int SK_F = 0x210000;
            public static int SK_G = 0x220000;
            public static int SK_H = 0x230000;
            public static int SK_I = 0x170000;
            public static int SK_J = 0x240000;
            public static int SK_K = 0x250000;
            public static int SK_L = 0x260000;
            public static int SK_M = 0x320000;
            public static int SK_N = 0x310000;
            public static int SK_O = 0x180000;
            public static int SK_P = 0x190000;
            public static int SK_Q = 0x100000;
            public static int SK_R = 0x130000;
            public static int SK_S = 0x1F0000;
            public static int SK_T = 0x140000;
            public static int SK_U = 0x160000;
            public static int SK_V = 0x2F0000;
            public static int SK_W = 0x110000;
            public static int SK_X = 0x2D0000;
            public static int SK_Y = 0x150000;
            public static int SK_Z = 0x2C0000;
            public static uint SK_TILDE = 0x29;

        }

        public static class VirtualKeyCodeText
        {
            public const string VK_F1 = "f1";
            public const string VK_F2 = "f2";
            public const string VK_F3 = "f3";
            public const string VK_F4 = "f4";
            public const string VK_F5 = "f5";
            public const string VK_F6 = "f6";
            public const string VK_F7 = "f7";
            public const string VK_F8 = "f8";
            public const string VK_F9 = "f9";
            public const string VK_F10 = "f10";
            public const string VK_F11 = "f11";
            public const string VK_F12 = "f12";

            public const string VK_LEFT = "left"; //Left Arrow Key
            public const string VK_UP = "up";
            public const string VK_RIGHT = "right";
            public const string VK_DOWN = "down";

            public const string VK_ESCAPE = "esc"; // Escape key
            public const string VK_SPACE = "space"; // Space
            public const string VK_PRIOR = "pgup"; //Page-Up
            public const string VK_NEXT = "pgdown"; //Page-Down
            public const string VK_END = "end"; //
            public const string VK_HOME = "home"; // Home Key

            public const string VK_BACK = "back"; //Backspace key
            public const string VK_BACKSPACE = "backspace"; // Not a real VK

            public const string VK_TAB = "tab"; // TAB key

            public const string VK_RETURN = "enter"; //Enter key

            public const string VK_SHIFT = "shift"; // Shift key
            public const string VK_CONTROL = "ctrl"; //CTRL
            public const string VK_PAUSE = "pause";

            public const string VK_NUMLOCK = "numl";
            public const string VK_SCROLL = "scroll"; //Scroll-Lock
            
            public const string VK_LSHIFT = "lshift";
            public const string VK_LSHIFT_DOWN = "lshiftdown";
            public const string VK_LSHIFT_UP = "lshiftup";

            public const string VK_RSHIFT = "rshift";
            public const string VK_RSHIFT_DOWN = "rshiftdown";
            public const string VK_RSHIFT_UP = "rshiftup";

            public const string VK_LCONTROL = "lctrl";
            public const string VK_LCONTROL_DOWN = "lctrldown";
            public const string VK_LCONTROL_UP = "lctrlup";

            public const string VK_RCONTROL = "rctrl";
            public const string VK_RCONTROL_DOWN = "rctrldown";
            public const string VK_RCONTROL_UP = "rctrlup";

            public const string VK_LMENU = "lalt"; // Left Alt key
            public const string VK_LMENU_DOWN = "laltdown"; 
            public const string VK_LMENU_UP = "laltup";

            public const string VK_RMENU = "ralt"; // Right Alt key
            public const string VK_RMENU_DOWN = "raltdown"; // Right Alt key
            public const string VK_RMENU_UP = "raltup"; // Right Alt key

            public const string VK_LWIN = "lwin";
            public const string VK_LWIN_DOWN = "lwindown";
            public const string VK_LWIN_UP = "lwinup";

            public const string VK_RWIN = "rwin";
            public const string VK_RWIN_DOWN = "rwindown";
            public const string VK_RWIN_UP = "rwinup";

            public const string VK_INSERT = "insert"; // Insert Key
            public const string VK_DELETE = "delete";

            public const string VK_CAPITAL = "caps";
        }

        public static class VirtualKeyCode
        {
            public static ushort VK_LBUTTON = 0X01; // Left mouse button
            public static ushort VK_RBUTTON = 0X02; // Right mouse button
            public static ushort VK_CANCEL = 0X03;  // Control-break processing
            public static ushort VK_MBUTTON = 0X04; // Middle mouse button
            public static ushort VK_XBUTTON1 = 0X05; // Middle mouse button
            public static ushort VK_XBUTTON2 = 0X06; // Middle mouse button
            // 0x07 Reserved
            public static ushort VK_BACK = 0X08; //Backspace key
            public static ushort VK_TAB = 0X09; // TAB key,
            // 0x0A Reserved
            // 0x0B Reserved
            public static ushort VK_CLEAR = 0x0C; // Clear key
            public static uint VK_RETURN = 0X0D; //Enter key
            // 0x0E Unassigned
            // OX0F Unassigned
            public static ushort VK_SHIFT = 0x10; // Shift key
            public static ushort VK_CONTROL = 0X11; //CTRL
            public static ushort VK_MENU = 0X12; // Alt Key
            public static ushort VK_PAUSE = 0X13;
            public static ushort VK_CAPITAL = 0X14; // Caps Lock Key
            // 0x15-0x1A IME keys.
            public static ushort VK_ESCAPE = 0X1B; // Escape key
            // 0x1C-Ox1F IME
            public static ushort VK_SPACE = 0X20;
            public static ushort VK_PRIOR = 0X21; //Page-Up
            public static ushort VK_NEXT = 0X22; //Page-Down
            public static ushort VK_END = 0X23; //
            public static ushort VK_HOME = 0X24; // Home Key
            public static ushort VK_LEFT = 0X25; //Left Arrow Key
            public static ushort VK_UP = 0X26;
            public static ushort VK_RIGHT = 0X27;
            public static ushort VK_DOWN = 0X28;
            public static ushort VK_SELECT = 0X29;
            public static ushort VK_PRINT = 0X2A;
            public static ushort VK_EXECUTE = 0X2B;
            public static ushort VK_SNAPSHOT = 0X2C; //Print Screen
            public static ushort VK_INSERT = 0X2D; // Insert Key
            public static ushort VK_DELETE = 0X2E;
            public static ushort VK_HELP = 0X2F;

            public static ushort VK_0 = 0X30;
            public static ushort VK_1 = 0X31;
            public static ushort VK_2 = 0X32;
            public static ushort VK_3 = 0X33;
            public static ushort VK_4 = 0X34;
            public static ushort VK_5 = 0X35;
            public static ushort VK_6 = 0X36;
            public static ushort VK_7 = 0X37;
            public static ushort VK_8 = 0X38;
            public static ushort VK_9 = 0X39;

            public static ushort VK_A = 0X41;
            public static ushort VK_B = 0X42;
            public static ushort VK_C = 0X43;
            public static ushort VK_D = 0X44;
            public static ushort VK_E = 0X45;
            public static ushort VK_F = 0X46;
            public static ushort VK_G = 0X47;
            public static ushort VK_H = 0X48;
            public static ushort VK_I = 0X49;
            public static ushort VK_J = 0X4A;
            public static ushort VK_K = 0X4B;
            public static ushort VK_L = 0X4C;
            public static ushort VK_M = 0X4D;
            public static ushort VK_N = 0X4E;
            public static ushort VK_O = 0X4F;
            public static ushort VK_P = 0X50;
            public static ushort VK_Q = 0X51;
            public static ushort VK_R = 0X52;
            public static ushort VK_S = 0X53;
            public static ushort VK_T = 0X54;
            public static ushort VK_U = 0X55;
            public static ushort VK_V = 0X56;
            public static ushort VK_W = 0X57;  // 87
            public static ushort VK_X = 0X58;
            public static ushort VK_Y = 0X59;
            public static ushort VK_Z = 0X5A;
            public static ushort VK_LWIN = 0x5B;
            public static ushort VK_RWIN = 0x5C;
            public static ushort VK_APPS = 0x5D;
            // 5E Reserved
            public static ushort VK_SLEEP = 0x5F;

            public static ushort VK_NUMPAD0 = 0X60;
            public static ushort VK_NUMPAD1 = 0X61;
            public static ushort VK_NUMPAD2 = 0X62;
            public static ushort VK_NUMPAD3 = 0X63;
            public static ushort VK_NUMPAD4 = 0X64;
            public static ushort VK_NUMPAD5 = 0X65;
            public static ushort VK_NUMPAD6 = 0X66;
            public static ushort VK_NUMPAD7 = 0X67;
            public static ushort VK_NUMPAD8 = 0X68;
            public static ushort VK_NUMPAD9 = 0X69;

            public static ushort VK_MULTIPLY = 0X6A;
            public static ushort VK_ADD = 0X6B;

            public static ushort VK_SEPERATOR = 0X6C; // PIPE | 
            public static ushort VK_SUBTRACT = 0X6D;  // -
            public static ushort VK_DECIMAL = 0X6E;   // .
            public static ushort VK_DIVIDE = 0X6F;   // /

            public static ushort VK_F1 = 0X70;
            public static ushort VK_F2 = 0X71;
            public static ushort VK_F3 = 0X72;
            public static ushort VK_F4 = 0X73;
            public static ushort VK_F5 = 0X74;
            public static ushort VK_F6 = 0X75;
            public static ushort VK_F7 = 0X76;
            public static ushort VK_F8 = 0X77;
            public static ushort VK_F9 = 0X78;
            public static ushort VK_F10 = 0X79;
            public static ushort VK_F11 = 0X7A;
            public static ushort VK_F12 = 0X7B;
            public static ushort VK_F13 = 0X7C;
            public static ushort VK_F14 = 0X7D;
            public static ushort VK_F15 = 0X7E;
            public static ushort VK_F16 = 0X7F;
            public static ushort VK_F17 = 0X80;
            public static ushort VK_F18 = 0X81;
            public static ushort VK_F19 = 0X82;
            public static ushort VK_F20 = 0X83;
            public static ushort VK_F21 = 0X84;
            public static ushort VK_F22 = 0X85;
            public static ushort VK_F23 = 0X86;
            public static ushort VK_F24 = 0X87;
            // 0x88-0x8F Reserved
            public static ushort VK_NUMLOCK = 0X90;
            public static ushort VK_SCROLL = 0X91; //Scroll-Lock
            public static ushort VK_LSHIFT = 0XA0;
            public static ushort VK_RSHIFT = 0XA1;
            public static ushort VK_LCONTROL = 0XA2;
            public static ushort VK_RCONTROL = 0XA3;
            public static ushort VK_LMENU = 0XA4; // Left Alt key
            public static ushort VK_RMENU = 0XA5; // Right Alt key

            // A6-B9 Browser/Apps/Reserved
            public static ushort VK_OEM_PLUS = 0XBB; // +
            public static ushort VK_OEM_COMMA = 0XBC; // ,
            public static ushort VK_OEM_MINUS = 0XBC; // -
            public static ushort VK_OEM_PERIOD = 0XBE; // -

            public static ushort VK_OEM_2 = 0XBF; // / or ?
            public static ushort VK_OEM_3 = 0XC0; // ` or ~
            public static ushort VK_OEM_4 = 0XDB; // [ or {
            public static ushort VK_OEM_5 = 0XDC; // \ or |
            public static ushort VK_OEM_6 = 0XDD; // ] or }
            public static ushort VK_OEM_7 = 0XDE; // ' or "
            public static ushort VK_OEM_102 = 0XE2; // <> (US)



        }
    }
}
