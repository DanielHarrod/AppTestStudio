//AppTestStudio 
//Copyright (C) 2016-2023 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System;
using System.Diagnostics;
using AppTestStudio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppTestStudioUnitTest
{
    [TestClass]
    public class UnitTestActiveMouse
    {
        [TestMethod]
        public void TestClickOnWindowActiveMode()
        {
            IntPtr x = new IntPtr(0x028B2682);
            AppTestStudio.Utils.ClickOnWindowActiveMode(x, 100, 100,100);
        }

        [TestMethod]
        public void TestGetWindowRectOnDualMonitor()
        {
            IntPtr x = new IntPtr(0x028B2682);
            AppTestStudio.API.RECT R;
            AppTestStudio.API.GetWindowRect(x, out R);
        }

        [TestMethod]
        public void TestSetForegroundWindow()
        {
            IntPtr x = new IntPtr(0x028B2682);
            bool Result = AppTestStudio.API.SetForegroundWindow(x);
            Debug.WriteLine("SetForegroundWindow returns:" +Result);
        }

        [TestMethod]
        public void TestGetForegroundWindow()
        {
            IntPtr x = AppTestStudio.API.GetForegroundWindow();
            Debug.WriteLine("GetForegroundWindow returns:" + x.ToInt32().ToString("X"));
        }

        [TestMethod]
        public void GetAncestor()
        {
            IntPtr x = AppTestStudio.API.GetForegroundWindow();

            x = AppTestStudio.Utils.GetWindowHandleByWindowName("Hades' Star", "");

            IntPtr Parent = API.GetAncestor(x, API.GetAncestorFlags.GetParent);
            IntPtr Root = API.GetAncestor(x, API.GetAncestorFlags.GetRoot);
            IntPtr RootOwner = API.GetAncestor(x, API.GetAncestorFlags.GetRootOwner);


        }

        [TestMethod]
        public void MouseMove()
        {
            IntPtr x = AppTestStudio.API.GetForegroundWindow();

            int Count = AppTestStudio.Utils.MoveMousePassive(x, 0, 3843, 746, 1927, 784, 485, 10);  // needs to be ~150
            int Count2 = AppTestStudio.Utils.MoveMousePassive(x, 0, 1934, 784, 1927, 3848, 125, 10);  // needs to be ~20
            int Count3 = AppTestStudio.Utils.MoveMousePassive(x, 0, 1934, 784, 1927, 3848, 0, 10);  // needs to be ~2

        }

        [TestMethod]
        public void MouseMoveActive0Speed()
        {
            IntPtr x = AppTestStudio.Utils.GetWindowHandleByWindowName("ATS2Window", "");

            int Count = AppTestStudio.Utils.MoveMouseActiveFromSystemPosition(x, MouseEventFlags.Blank, 10, 10,6000);

        }

        [TestMethod]
        public void MouseMoveActive500PixelsPerSecond()
        {
            IntPtr x = AppTestStudio.Utils.GetWindowHandleByWindowName("ATS2Window", "");

            int Count = AppTestStudio.Utils.MoveMouseActiveFromSystemPosition(x, MouseEventFlags.Blank, 10, 10,500);
        }


        [TestMethod]
        public void MouseMoveActive3000PixelsPerSecond()
        {
            IntPtr x = AppTestStudio.Utils.GetWindowHandleByWindowName("ATS2Window", "");

            int Count = AppTestStudio.Utils.MoveMouseActiveFromSystemPosition(x, MouseEventFlags.Blank, 10, 10, 3000);

        }



        [TestMethod]
        public void MouseMoveTesting()
        {
            int Count = AppTestStudio.Utils.MoveMousePassive(new IntPtr(0x1650a2e), 1, 740, 337, 59, 336, 500,10);
        }

        /// <summary>
        /// Hmm. script_autoit.cpp, I wasn't sure what I was seeing here. watned to Debug it
        /// An intersting implementation.
        /// </summary>
        [TestMethod]

        public void DoIncrementalMouseMove_AutoITVersion()
        {
            int aX1 = 3843;
            int aY1 = 746;
            int aX2 = 1746;
            int aY2 = 784;
            int aSpeed = 32;  //(0 to 100)

            int delta;
            int INCR_MOUSE_MIN_SPEED = 32;
            int Iterations = 0;
            while (aX1 != aX2 || aY1 != aY2)
            {
                Iterations++;
                if (aX1 < aX2)
                {
                    delta = (aX2 - aX1) / aSpeed;
                    if (delta == 0 || delta < INCR_MOUSE_MIN_SPEED)
                        delta = INCR_MOUSE_MIN_SPEED;
                    if ((aX1 + delta) > aX2)
                        aX1 = aX2;
                    else
                        aX1 += delta;
                }
                else
                    if (aX1 > aX2)
                {
                    delta = (aX1 - aX2) / aSpeed;
                    if (delta == 0 || delta < INCR_MOUSE_MIN_SPEED)
                        delta = INCR_MOUSE_MIN_SPEED;
                    if ((aX1 - delta) < aX2)
                        aX1 = aX2;
                    else
                        aX1 -= delta;
                }

                if (aY1 < aY2)
                {
                    delta = (aY2 - aY1) / aSpeed;
                    if (delta == 0 || delta < INCR_MOUSE_MIN_SPEED)
                        delta = INCR_MOUSE_MIN_SPEED;
                    if ((aY1 + delta) > aY2)
                        aY1 = aY2;
                    else
                        aY1 += delta;
                }
                else
                    if (aY1 > aY2)
                {
                    delta = (aY1 - aY2) / aSpeed;
                    if (delta == 0 || delta < INCR_MOUSE_MIN_SPEED)
                        delta = INCR_MOUSE_MIN_SPEED;
                    if ((aY1 - delta) < aY2)
                        aY1 = aY2;
                    else
                        aY1 -= delta;
                }

                Debug.WriteLine(Iterations + " MouseEvent(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, 0, " + aX1 + ", " + aY1 + ");");

            }
        }



    }
}
