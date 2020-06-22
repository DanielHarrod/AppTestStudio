using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AppTestStudio.API;

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

            AppTestStudio.Utils.ClickOnWindow(k, 100, 100, 0);
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
            AppTestStudio.API.Point lefttop; // Practicaly both are 0
            lefttop.X = crect.Left;
            lefttop.Y = crect.Top;
            ClientToScreen(hwnd, ref lefttop);
            AppTestStudio.API.Point rightbottom;
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
