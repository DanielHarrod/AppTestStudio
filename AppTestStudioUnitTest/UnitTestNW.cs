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
            IntPtr k = AppTestStudio.Utils.GetWindowHandleByWindowName("World of New :)", "");

            API.GetCursorPos(out API.Point point);
            short xStart = (short) point.X;
            short yStart = (short) point.Y;
            Utils.ClickOnWindowActiveMode(k, xStart, yStart, 100);

            System.Threading.Thread.Sleep(2000);

            //System.Drawing.Bitmap b = AppTestStudio.Utils.GetBitmapFromWindowHandle(k);

            API.GetCursorPos(out point);
             xStart = (short)point.X;
             yStart = (short)point.Y;
            Utils.ClickOnWindowActiveMode(k, xStart, yStart, 200);
        }
    }
}
