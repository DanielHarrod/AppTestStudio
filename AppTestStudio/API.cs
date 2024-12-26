//AppTestStudio 
//Copyright(C) 2016-2024 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using static AppTestStudio.NativeMethods;

namespace AppTestStudio
{
    public static class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Point
        {
            public int X;
            public int Y;

            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public static implicit operator System.Drawing.Point(Point p)
            {
                return new System.Drawing.Point(p.X, p.Y);
            }

            public static implicit operator Point(System.Drawing.Point p)
            {
                return new Point(p.X, p.Y);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KeyboardInput
        {
            public ushort VirtualKeyCode;
            public ushort ScanCode;
            public uint Flags;
            public uint Time;
            public IntPtr ExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MouseInput
        {
            public int X;
            public int Y;
            public uint MouseData;
            public uint Flags;
            public uint Time;
            public IntPtr ExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HardwareInput
        {
            public uint Message;
            public ushort lParam;
            public ushort hParam;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)] public MouseInput MouseInput;
            [FieldOffset(0)] public KeyboardInput KeyboardInput;
            [FieldOffset(0)] public HardwareInput HardwareInput;
        }

        public struct Input
        {
            public int Type;
            public InputUnion u;
        }


        [DllImport("user32.dll", EntryPoint = "GetDC")]
        internal static extern IntPtr GetDC(IntPtr ptr);

        [DllImport("user32.dll")]
        internal static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC", SetLastError = true)]
        internal static extern IntPtr CreateCompatibleDC([In] IntPtr hdc);

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleBitmap")]
        internal static extern IntPtr CreateCompatibleBitmap([In] IntPtr hdc, int nWidth, int nHeight);

        [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
        internal static extern IntPtr SelectObject([In] IntPtr hdc, [In] IntPtr hgdiobj);

        [DllImport("user32.dll")]
        internal static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);

        [DllImport("user32.dll")]
        internal static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll", EntryPoint = "DeleteDC")]
        internal static extern bool DeleteDC([In] IntPtr hdc);

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        internal static extern bool DeleteObject([In] IntPtr hObject);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

        //[DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        //internal static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [DllImport("user32.dll")]
        internal static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        public static bool PostMessage(IntPtr hwnd, int Msg, int wParam, int lParam)
        {
            return PostMessage(hwnd, (uint)Msg, wParam, lParam);
        }

        public delegate bool EnumWindowsProc(IntPtr hWnd, ref IntPtr lParam);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool EnumChildWindows(IntPtr window, EnumWindowsProc callback, IntPtr i);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        internal static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        internal static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern int GetSystemMetrics(SystemMetric smIndex);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int Width, int Height, bool Repaint);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern uint SendInput(uint nInputs, Input[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        internal static extern IntPtr GetMessageExtraInfo();

        [DllImport("user32.dll")]
        internal static extern bool GetCursorPos(out Point lpPoint);

        [DllImport("user32.dll")]
        internal static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern IntPtr GetForegroundWindow();

        public enum GetAncestorFlags
        {
            GetParent = 1,
            GetRoot = 2,
            GetRootOwner = 3
        }

        [DllImport("user32.dll", ExactSpelling = true)]
        internal static extern IntPtr GetAncestor(IntPtr hwnd, GetAncestorFlags flags);

        public enum DWMWINDOWATTRIBUTE : uint
        {
            NCRenderingEnabled = 1,
            NCRenderingPolicy,
            TransitionsForceDisabled,
            AllowNCPaint,
            CaptionButtonBounds,
            NonClientRtlLayout,
            ForceIconicRepresentation,
            Flip3DPolicy,
            ExtendedFrameBounds,
            HasIconicBitmap,
            DisallowPeek,
            ExcludedFromPeek,
            Cloak,
            Cloaked,
            FreezeRepresentation
        }

        [DllImport("dwmapi.dll")]
        internal static extern int DwmGetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE dwAttribute, out RECT pvAttribute, int cbAttribute);

        [DllImport("User32.dll")]
        internal static extern bool SystemParametersInfo(int uiAction, int uiParam, ref int ipParam, int fWinIni);

        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern IntPtr WindowFromPoint(System.Drawing.Point p);


        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        internal static extern IntPtr GetDesktopWindow();

        
        [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        internal static extern short VkKeyScan(char ch);


        [DllImport("User32.dll")]
        internal static extern ushort MapVirtualKey(uint uCode, uint uMapType);

        [DllImport("user32.dll")]
        internal static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool LockSetForegroundWindow(uint LockCode);

        [DllImport("user32.dll")]
        internal static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        internal delegate bool EnumWindowProc(IntPtr hwnd, IntPtr lParam);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr lParam);

        internal delegate bool EnumMonitorsDelegate(IntPtr hMonitor, IntPtr hdcMonitor, NativeMethods.RECT rect, IntPtr dwData);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, EnumMonitorsDelegate lpfnEnum, IntPtr dwData);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetMonitorInfo(IntPtr hmonitor, [In, Out] NativeMethods.MONITORINFO info);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
        internal class MONITORINFO
        {
            internal int Size = Marshal.SizeOf(typeof(NativeMethods.MONITORINFO));
            internal NativeMethods.RECT rcMonitor = new NativeMethods.RECT();
            internal NativeMethods.RECT rcWork = new NativeMethods.RECT();
            internal int dwFlags;
        }

        internal enum DpiType
        {
            Effective = 0,
            Angular = 1,
            Raw = 2,
        }

        [DllImport("Shcore.dll")]
        internal static extern IntPtr GetDpiForMonitor([In] IntPtr hmonitor, [In] DpiType dpiType, [Out] out uint dpiX, [Out] out uint dpiY);

        [DllImport("User32.dll")]
        internal static extern IntPtr MonitorFromPoint([In] System.Drawing.Point pt, [In] uint dwFlags);

    }
}
