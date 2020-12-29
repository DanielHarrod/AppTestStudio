using System;
using System.Diagnostics;
using AppTestStudio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.InteropServices;
using static AppTestStudio.API;

namespace AppTestStudioUnitTest
{
    [TestClass]
    public class SystemTesting
    {

        [TestMethod]
        public void SystemParametersInfoSPI_GETMOUSESPEED()
        {
                const int SPI_GETMOUSESPEED = 0x0070;

            //int speed=0;
            //    API.SystemParametersInfo(
            //        SPI_GETMOUSESPEED,
            //        0,
            //        new IntPtr(speed),
            //        0);
            //    Debug.WriteLine(speed

            int x=0;
            IntPtr y = new IntPtr(x);

        //Retrieves the current mouse speed.The mouse speed determines how far the pointer will move based on the distance the mouse moves.
        //The pvParam parameter must point to an integer that receives a value which ranges between 1(slowest) and 20(fastest).
//            A value of 10 is the default.
  //              The value can be set by an end - user using the mouse control panel application or by an application using SPI_SETMOUSESPEED.
        API.SystemParametersInfo(SPI_GETMOUSESPEED, 0, ref x, 0);

        }

        [TestMethod]
        public void RunEveryGetSystemMetricsForLocalDebugWatch()
        {
            /*
             *         
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
             * */
        }

        int SM_CXSCREEN = GetSystemMetrics(SystemMetric.SM_CXSCREEN);
        int SM_CYSCREEN = GetSystemMetrics(SystemMetric.SM_CYSCREEN);
        int SM_CXVSCROLL = GetSystemMetrics(SystemMetric.SM_CXVSCROLL);
        int SM_CYHSCROLL = GetSystemMetrics(SystemMetric.SM_CYHSCROLL);
        int SM_CYCAPTION = GetSystemMetrics(SystemMetric.SM_CYCAPTION);
        int SM_CXBORDER = GetSystemMetrics(SystemMetric.SM_CXBORDER);
        int SM_CYBORDER = GetSystemMetrics(SystemMetric.SM_CYBORDER);
        int SM_CXDLGFRAME = GetSystemMetrics(SystemMetric.SM_CXDLGFRAME);
        int SM_CXFIXEDFRAME = GetSystemMetrics(SystemMetric.SM_CXFIXEDFRAME);
        int SM_CYDLGFRAME = GetSystemMetrics(SystemMetric.SM_CYDLGFRAME);
        int SM_CYFIXEDFRAME = GetSystemMetrics(SystemMetric.SM_CYFIXEDFRAME);
        int SM_CYVTHUMB = GetSystemMetrics(SystemMetric.SM_CYVTHUMB);
        int SM_CXHTHUMB = GetSystemMetrics(SystemMetric.SM_CXHTHUMB);
        int SM_CXICON = GetSystemMetrics(SystemMetric.SM_CXICON);
        int SM_CYICON = GetSystemMetrics(SystemMetric.SM_CYICON);
        int SM_CXCURSOR = GetSystemMetrics(SystemMetric.SM_CXCURSOR);
        int SM_CYCURSOR = GetSystemMetrics(SystemMetric.SM_CYCURSOR);
        int SM_CYMENU = GetSystemMetrics(SystemMetric.SM_CYMENU);
        int SM_CXFULLSCREEN = GetSystemMetrics(SystemMetric.SM_CXFULLSCREEN);
        int SM_CYFULLSCREEN = GetSystemMetrics(SystemMetric.SM_CYFULLSCREEN);
        int SM_CYKANJIWINDOW = GetSystemMetrics(SystemMetric.SM_CYKANJIWINDOW);
        int SM_MOUSEPRESENT = GetSystemMetrics(SystemMetric.SM_MOUSEPRESENT);
        int SM_CYVSCROLL = GetSystemMetrics(SystemMetric.SM_CYVSCROLL);
        int SM_CXHSCROLL = GetSystemMetrics(SystemMetric.SM_CXHSCROLL);
        int SM_DEBUG = GetSystemMetrics(SystemMetric.SM_DEBUG);
        int SM_SWAPBUTTON = GetSystemMetrics(SystemMetric.SM_SWAPBUTTON);
        int SM_CXMIN = GetSystemMetrics(SystemMetric.SM_CXMIN);
        int SM_CYMIN = GetSystemMetrics(SystemMetric.SM_CYMIN);
        int SM_CXSIZE = GetSystemMetrics(SystemMetric.SM_CXSIZE);
        int SM_CYSIZE = GetSystemMetrics(SystemMetric.SM_CYSIZE);
        int SM_CXSIZEFRAME = GetSystemMetrics(SystemMetric.SM_CXSIZEFRAME);
        int SM_CXFRAME = GetSystemMetrics(SystemMetric.SM_CXFRAME);
        int SM_CYSIZEFRAME = GetSystemMetrics(SystemMetric.SM_CYSIZEFRAME);
        int SM_CYFRAME = GetSystemMetrics(SystemMetric.SM_CYFRAME);
        int SM_CXMINTRACK = GetSystemMetrics(SystemMetric.SM_CXMINTRACK);
        int SM_CYMINTRACK = GetSystemMetrics(SystemMetric.SM_CYMINTRACK);
        int SM_CXDOUBLECLK = GetSystemMetrics(SystemMetric.SM_CXDOUBLECLK);
        int SM_CYDOUBLECLK = GetSystemMetrics(SystemMetric.SM_CYDOUBLECLK);
        int SM_CXICONSPACING = GetSystemMetrics(SystemMetric.SM_CXICONSPACING);
        int SM_CYICONSPACING = GetSystemMetrics(SystemMetric.SM_CYICONSPACING);
        int SM_MENUDROPALIGNMENT = GetSystemMetrics(SystemMetric.SM_MENUDROPALIGNMENT);
        int SM_PENWINDOWS = GetSystemMetrics(SystemMetric.SM_PENWINDOWS);
        int SM_DBCSENABLED = GetSystemMetrics(SystemMetric.SM_DBCSENABLED);
        int SM_CMOUSEBUTTONS = GetSystemMetrics(SystemMetric.SM_CMOUSEBUTTONS);
        int SM_SECURE = GetSystemMetrics(SystemMetric.SM_SECURE);
        int SM_CXEDGE = GetSystemMetrics(SystemMetric.SM_CXEDGE);
        int SM_CYEDGE = GetSystemMetrics(SystemMetric.SM_CYEDGE);
        int SM_CXMINSPACING = GetSystemMetrics(SystemMetric.SM_CXMINSPACING);
        int SM_CYMINSPACING = GetSystemMetrics(SystemMetric.SM_CYMINSPACING);
        int SM_CXSMICON = GetSystemMetrics(SystemMetric.SM_CXSMICON);
        int SM_CYSMICON = GetSystemMetrics(SystemMetric.SM_CYSMICON);
        int SM_CYSMCAPTION = GetSystemMetrics(SystemMetric.SM_CYSMCAPTION);
        int SM_CXSMSIZE = GetSystemMetrics(SystemMetric.SM_CXSMSIZE);
        int SM_CYSMSIZE = GetSystemMetrics(SystemMetric.SM_CYSMSIZE);
        int SM_CXMENUSIZE = GetSystemMetrics(SystemMetric.SM_CXMENUSIZE);
        int SM_CYMENUSIZE = GetSystemMetrics(SystemMetric.SM_CYMENUSIZE);
        int SM_ARRANGE = GetSystemMetrics(SystemMetric.SM_ARRANGE);
        int SM_CXMINIMIZED = GetSystemMetrics(SystemMetric.SM_CXMINIMIZED);
        int SM_CYMINIMIZED = GetSystemMetrics(SystemMetric.SM_CYMINIMIZED);
        int SM_CXMAXTRACK = GetSystemMetrics(SystemMetric.SM_CXMAXTRACK);
        int SM_CYMAXTRACK = GetSystemMetrics(SystemMetric.SM_CYMAXTRACK);
        int SM_CXMAXIMIZED = GetSystemMetrics(SystemMetric.SM_CXMAXIMIZED);
        int SM_CYMAXIMIZED = GetSystemMetrics(SystemMetric.SM_CYMAXIMIZED);
        int SM_NETWORK = GetSystemMetrics(SystemMetric.SM_NETWORK);
        int SM_CLEANBOOT = GetSystemMetrics(SystemMetric.SM_CLEANBOOT);
        int SM_CXDRAG = GetSystemMetrics(SystemMetric.SM_CXDRAG);
        int SM_CYDRAG = GetSystemMetrics(SystemMetric.SM_CYDRAG);
        int SM_SHOWSOUNDS = GetSystemMetrics(SystemMetric.SM_SHOWSOUNDS);
        int SM_CXMENUCHECK = GetSystemMetrics(SystemMetric.SM_CXMENUCHECK);
        int SM_CYMENUCHECK = GetSystemMetrics(SystemMetric.SM_CYMENUCHECK);
        int SM_SLOWMACHINE = GetSystemMetrics(SystemMetric.SM_SLOWMACHINE);
        int SM_MIDEASTENABLED = GetSystemMetrics(SystemMetric.SM_MIDEASTENABLED);
        int SM_MOUSEWHEELPRESENT = GetSystemMetrics(SystemMetric.SM_MOUSEWHEELPRESENT);
        int SM_XVIRTUALSCREEN = GetSystemMetrics(SystemMetric.SM_XVIRTUALSCREEN);
        int SM_YVIRTUALSCREEN = GetSystemMetrics(SystemMetric.SM_YVIRTUALSCREEN);
        int SM_CXVIRTUALSCREEN = GetSystemMetrics(SystemMetric.SM_CXVIRTUALSCREEN);
        int SM_CYVIRTUALSCREEN = GetSystemMetrics(SystemMetric.SM_CYVIRTUALSCREEN);
        int SM_CMONITORS = GetSystemMetrics(SystemMetric.SM_CMONITORS);
        int SM_SAMEDISPLAYFORMAT = GetSystemMetrics(SystemMetric.SM_SAMEDISPLAYFORMAT);
        int SM_IMMENABLED = GetSystemMetrics(SystemMetric.SM_IMMENABLED);
        int SM_CXFOCUSBORDER = GetSystemMetrics(SystemMetric.SM_CXFOCUSBORDER);
        int SM_CYFOCUSBORDER = GetSystemMetrics(SystemMetric.SM_CYFOCUSBORDER);
        int SM_TABLETPC = GetSystemMetrics(SystemMetric.SM_TABLETPC);
        int SM_MEDIACENTER = GetSystemMetrics(SystemMetric.SM_MEDIACENTER);
        int SM_STARTER = GetSystemMetrics(SystemMetric.SM_STARTER);
        int SM_SERVERR2 = GetSystemMetrics(SystemMetric.SM_SERVERR2);
        int SM_MOUSEHORIZONTALWHEELPRESENT = GetSystemMetrics(SystemMetric.SM_MOUSEHORIZONTALWHEELPRESENT);
        int SM_CXPADDEDBORDER = GetSystemMetrics(SystemMetric.SM_CXPADDEDBORDER);
        int SM_DIGITIZER = GetSystemMetrics(SystemMetric.SM_DIGITIZER);
        int SM_MAXIMUMTOUCHES = GetSystemMetrics(SystemMetric.SM_MAXIMUMTOUCHES);
        int SM_REMOTESESSION = GetSystemMetrics(SystemMetric.SM_REMOTESESSION);
        int SM_SHUTTINGDOWN = GetSystemMetrics(SystemMetric.SM_SHUTTINGDOWN);
        int SM_REMOTECONTROL = GetSystemMetrics(SystemMetric.SM_REMOTECONTROL);
        int SM_CONVERTIBLESLATEMODE = GetSystemMetrics(SystemMetric.SM_CONVERTIBLESLATEMODE);
        int SM_SYSTEMDOCKED = GetSystemMetrics(SystemMetric.SM_SYSTEMDOCKED);




    }
}
