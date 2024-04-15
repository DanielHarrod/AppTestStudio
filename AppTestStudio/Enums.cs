//AppTestStudio 
//Copyright(C) 2016-2024 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System;
using System.Drawing;

namespace AppTestStudio
{

    public enum WindowAction
    {
        DoNothing,
        ActivateWindow
    }

    public enum Platform
    {
        NoxPlayer,
        BlueStacks,
        Steam,
        Application
    }

    public enum MouseMode
    {
        Passive,
        Active
    }

    public enum WindowNameFilterType
    {
        Equals,
        StartsWith,
        Contains
    }

    public enum GameNodeType
    {
        Workspace,
        Games,
        Game,
        Events,
        //        Event, - No longer used Moved to Action
        Action,
        Objects,
        ObjectScreenshot,
        Object
    }

    public enum AfterCompletionType
    {
        Continue,
        Home,
        Parent,
        Stop,
        ContinueProcess,
        Recycle
    }

    public enum ActionType
    {
        Action,
        Event,
        RNG,
        RNGContainer
    }

    public enum KeyboardButtonStates
    {
        Normal,
        Down,
        Up,
        Error,
        None
    }

    public enum ActivateWindowResult
    {
        WindowAlreadyActivated,
        WindowActivated,
        Timeout
    }

    public enum TimeoutAction
    {
        Abort,
        Continue
    }

    public enum WaitType
    {
        Iteration,
        Time,
        Session
    }

    public enum Mode
    {
        RangeClick,
        ClickDragRelease,
        MouseMove,
        Keyboard
    }

    public enum ClickDragReleaseMode
    {
        Start,
        End,
        None
    }

    /// <summary>
    /// Usage:
    /// Options: None or the OR of any Top, Right, Bottom, Left
    /// </summary>
    public enum AnchorMode
    {
        None = 0,
        Top = 1,
        Right = 2,
        Bottom = 4,
        Left = 8,
        Default = Left | Top
    }


    [Flags]
    public enum MouseEventFlags : uint
    {
        Move = 0x0001,
        LeftDown = 0x0002,
        LeftUp = 0x0004,
        RightDown = 0x0008,
        RightUp = 0x0010,
        MiddleDown = 0x0020,
        MiddleUp = 0x0040,
        XDown = 0x0080,
        XUp = 0x0100,
        Wheel = 0x0800,
        VirtualDesk = 0x4000,
        Absolute = 0x8000,
        Blank = 0x0
    }

    public static class AnchorModeButtonColors
    {
        public static Color EnabledColor()
        {
            return SystemColors.ControlDark;
        }

        public static Color DisabledColor()
        {
            return SystemColors.Control;
        }
    }

    /// <summary>
    /// See frmMain.ImageList1
    /// </summary>
    public static class IconNames 
    {
        public const int VideoGameController = 0;
        public const int OrangeComputer = 1;
        public const int AngularLightningBolt = 2;
        public const int ArrowToCircle = 3;
        public const int RNGContainer = 4;
        public const int RNG = 5;
        public const int AngularLightningBoltNo = 6;
        public const int AngularLightningBoltYes = 7;
        public const int HelpIcon = 8;
        public const int Mobile = 9;
        public const int Mobiles = 10;
        public const int EncapsulateField = 11;
        public const int EditMulitpleObjects = 12;
        public const int RectangularScreenshot = 13;
        public const int RectangularSelection = 14;
        public const int Event = 15;
        public const int ButtonClick = 16;
        public const int Home = 17;
        public const int Application = 18;
        public const int AppRoot = 19;
        public const int SearchAndApps = 20;
        public const int DependencyArrow = 21;
        public const int DownChevron = 22;
        public const int LeftChevron = 23;
        public const int RNGGray = 24;
        public const int EventGray = 25;
        public const int ButtonClickGray = 26;
        public const int ClickDragReleaseGray = 27;
        public const int RNGContainerGray = 28;
        public const int SearchGray = 29;
        public const int Group = 30;
        public const int GroupGray = 31;
        public const int Move = 32;
        public const int Keyboard = 33;
    }

    public enum SystemMetric
    {
        SM_CXSCREEN = 0,  // 0x00
        SM_CYSCREEN = 1,  // 0x01
        SM_CXVSCROLL = 2,  // 0x02
        SM_CYHSCROLL = 3,  // 0x03
        SM_CYCAPTION = 4,  // 0x04
        SM_CXBORDER = 5,  // 0x05
        SM_CYBORDER = 6,  // 0x06
        SM_CXDLGFRAME = 7,  // 0x07
        SM_CXFIXEDFRAME = 7,  // 0x07
        SM_CYDLGFRAME = 8,  // 0x08
        SM_CYFIXEDFRAME = 8,  // 0x08
        SM_CYVTHUMB = 9,  // 0x09
        SM_CXHTHUMB = 10, // 0x0A
        SM_CXICON = 11, // 0x0B
        SM_CYICON = 12, // 0x0C
        SM_CXCURSOR = 13, // 0x0D
        SM_CYCURSOR = 14, // 0x0E
        SM_CYMENU = 15, // 0x0F
        SM_CXFULLSCREEN = 16, // 0x10
        SM_CYFULLSCREEN = 17, // 0x11
        SM_CYKANJIWINDOW = 18, // 0x12
        SM_MOUSEPRESENT = 19, // 0x13
        SM_CYVSCROLL = 20, // 0x14
        SM_CXHSCROLL = 21, // 0x15
        SM_DEBUG = 22, // 0x16
        SM_SWAPBUTTON = 23, // 0x17
        SM_CXMIN = 28, // 0x1C
        SM_CYMIN = 29, // 0x1D
        SM_CXSIZE = 30, // 0x1E
        SM_CYSIZE = 31, // 0x1F
        SM_CXSIZEFRAME = 32, // 0x20
        SM_CXFRAME = 32, // 0x20
        SM_CYSIZEFRAME = 33, // 0x21
        SM_CYFRAME = 33, // 0x21
        SM_CXMINTRACK = 34, // 0x22
        SM_CYMINTRACK = 35, // 0x23
        SM_CXDOUBLECLK = 36, // 0x24
        SM_CYDOUBLECLK = 37, // 0x25
        SM_CXICONSPACING = 38, // 0x26
        SM_CYICONSPACING = 39, // 0x27
        SM_MENUDROPALIGNMENT = 40, // 0x28
        SM_PENWINDOWS = 41, // 0x29
        SM_DBCSENABLED = 42, // 0x2A
        SM_CMOUSEBUTTONS = 43, // 0x2B
        SM_SECURE = 44, // 0x2C
        SM_CXEDGE = 45, // 0x2D
        SM_CYEDGE = 46, // 0x2E
        SM_CXMINSPACING = 47, // 0x2F
        SM_CYMINSPACING = 48, // 0x30
        SM_CXSMICON = 49, // 0x31
        SM_CYSMICON = 50, // 0x32
        SM_CYSMCAPTION = 51, // 0x33
        SM_CXSMSIZE = 52, // 0x34
        SM_CYSMSIZE = 53, // 0x35
        SM_CXMENUSIZE = 54, // 0x36
        SM_CYMENUSIZE = 55, // 0x37
        SM_ARRANGE = 56, // 0x38
        SM_CXMINIMIZED = 57, // 0x39
        SM_CYMINIMIZED = 58, // 0x3A
        SM_CXMAXTRACK = 59, // 0x3B
        SM_CYMAXTRACK = 60, // 0x3C
        SM_CXMAXIMIZED = 61, // 0x3D
        SM_CYMAXIMIZED = 62, // 0x3E
        SM_NETWORK = 63, // 0x3F
        SM_CLEANBOOT = 67, // 0x43
        SM_CXDRAG = 68, // 0x44
        SM_CYDRAG = 69, // 0x45
        SM_SHOWSOUNDS = 70, // 0x46
        SM_CXMENUCHECK = 71, // 0x47
        SM_CYMENUCHECK = 72, // 0x48
        SM_SLOWMACHINE = 73, // 0x49
        SM_MIDEASTENABLED = 74, // 0x4A
        SM_MOUSEWHEELPRESENT = 75, // 0x4B
        SM_XVIRTUALSCREEN = 76, // 0x4C
        SM_YVIRTUALSCREEN = 77, // 0x4D
        SM_CXVIRTUALSCREEN = 78, // 0x4E
        SM_CYVIRTUALSCREEN = 79, // 0x4F
        SM_CMONITORS = 80, // 0x50
        SM_SAMEDISPLAYFORMAT = 81, // 0x51
        SM_IMMENABLED = 82, // 0x52
        SM_CXFOCUSBORDER = 83, // 0x53
        SM_CYFOCUSBORDER = 84, // 0x54
        SM_TABLETPC = 86, // 0x56
        SM_MEDIACENTER = 87, // 0x57
        SM_STARTER = 88, // 0x58
        SM_SERVERR2 = 89, // 0x59
        SM_MOUSEHORIZONTALWHEELPRESENT = 91, // 0x5B
        SM_CXPADDEDBORDER = 92, // 0x5C
        SM_DIGITIZER = 94, // 0x5E
        SM_MAXIMUMTOUCHES = 95, // 0x5F
        SM_REMOTESESSION = 0x1000, // 0x1000
        SM_SHUTTINGDOWN = 0x2000, // 0x2000
        SM_REMOTECONTROL = 0x2001, // 0x2001
        SM_CONVERTIBLESLATEMODE = 0x2003,
        SM_SYSTEMDOCKED = 0x2004,
    }

}
