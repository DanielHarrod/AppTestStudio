using AppTestStudio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AppTestStudioUnitTest
{
    [TestClass]
    public class UnitTestNW
    {
        [TestMethod]
        public void TestMethod1()
        {
            System.Threading.Thread.Sleep(1000);
            IntPtr k = AppTestStudio.Utils.GetWindowHandleByWindowName("World of New", "");

            NativeMethods.GetCursorPos(out NativeMethods.Point point);
            short xStart = (short) point.X;
            short yStart = (short) point.Y;
            //Utils.ClickOnWindow(k,MouseMode.Active,false)
            //Utils.ClickOnWindowActiveMode(k, xStart, yStart, 100);
            Utils.ClickOnWindowActiveMode(k, 1920, 1096, 200);
            System.Threading.Thread.Sleep(4000);
            Utils.ClickOnWindowActiveMode(k, 1920, 1096, 100);

            return;
            System.Threading.Thread.Sleep(2000);

            //System.Drawing.Bitmap b = AppTestStudio.Utils.GetBitmapFromWindowHandle(k);

            NativeMethods.GetCursorPos(out point);
             xStart = (short)point.X;
             yStart = (short)point.Y;
            Utils.ClickOnWindowActiveMode(k, xStart, yStart, 200);
        }
    }
}
