//AppTestStudio 
//Copyright (C) 2016-2023 Daniel Harrod
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details. You should have received a copy of the GNU General Public License along with this program. If not, see<https://www.gnu.org/licenses/>.

using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AppTestStudio.NativeMethods;

namespace AppTestStudioUnitTest
{
    [TestClass]
    public class UnitTestSodaDungeon
    {
        [TestMethod]
        public void TestNonNoxgame()
        {
            IntPtr k = AppTestStudio.Utils.GetWindowHandleByWindowName("Soda Dungeon","");

            Bitmap b = AppTestStudio.Utils.GetBitmapFromWindowHandle(k);

            // Deprecated
            //AppTestStudio.Utils.ClickOnWindowPassiveMode(k, 100, 100, 0);
        }


        [TestMethod]
        public void TestSystemInformation()
        {
            //System.Diagnostics.Debug.Write(System.Windows.Forms.SystemInformation.tit)

            IntPtr hwnd = AppTestStudio.Utils.GetWindowHandleByWindowName("Soda Dungeon", "");

            RECT wrect;
            GetWindowRect(hwnd, out wrect);
            RECT crect;
            GetClientRect(hwnd,  out crect);
            AppTestStudio.NativeMethods.Point lefttop; // Practicaly both are 0
            lefttop.X = crect.Left;
            lefttop.Y = crect.Top;
            ClientToScreen(hwnd, ref lefttop);
            AppTestStudio.NativeMethods.Point rightbottom;
            rightbottom.X = crect.Right;
            rightbottom.Y = crect.Bottom;
            ClientToScreen(hwnd, ref rightbottom);

            int left_border = lefttop.X - wrect.Left; // Windows 10: includes transparent part
            int right_border = wrect.Right - rightbottom.X; // As above
            int bottom_border = wrect.Bottom - rightbottom.Y; // As above
            int top_border_with_title_bar = lefttop.Y - wrect.Top; // There is no transparent part

        }
    }
}
