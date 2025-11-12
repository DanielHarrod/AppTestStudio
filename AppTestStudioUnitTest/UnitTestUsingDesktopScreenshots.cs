using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace AppTestStudioUnitTest
{
    [TestClass]
    public class UnitTestUsingDesktopScreenshots
    {
        [TestMethod]
        public void TestMethod1()
        {
            IntPtr DesktopHWND = AppTestStudio.NativeMethods.GetDesktopWindow();

            Boolean Success = false;
            Bitmap bmp = AppTestStudio.Utils.GetBitmapFromWindowHandle(ref Success, DesktopHWND);
            bmp.Save("C:\\test\\Test.bmp");
        }

        [TestMethod]
        public void TestSysInfoVirtualScreen()
        {
            int screenLeft = SystemInformation.VirtualScreen.Left;
            int screenTop = SystemInformation.VirtualScreen.Top;
            int screenWidth = SystemInformation.VirtualScreen.Width;
            int screenHeight = SystemInformation.VirtualScreen.Height;

            // Create a bitmap of the appropriate size to receive the screenshot.
            using (Bitmap bmp = new Bitmap(screenWidth, screenHeight))
            {
                // Draw the screenshot into our bitmap.
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(screenLeft, screenTop, 0, 0, bmp.Size);
                }

                // Do something with the Bitmap here, like save it to a file:
                bmp.Save("C:\\test\\Test.jpg", ImageFormat.Jpeg);
            }
        }
    }
}
